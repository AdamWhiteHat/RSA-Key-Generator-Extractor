using System;
using System.Linq;
using System.Text;
using System.Security;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading;

namespace CertificateKeyGenerator
{
    public class ExtractPvkFile
    {
        private int BatchSize;
        private bool DeleteFiles;
        private bool ExportOnlyPQ;
        private string OutputFilename;
        private string SearchDirectory;
        private IEnumerable<string> FilePaths;
        private CancellationToken CancelToken;

        private static byte[] EmptyByteArray = new byte[0];
        //private static string SearchExtension = "*.pvk";
        private static string[] SearchExtensions = new string[] { "*.pvk", "*.key" };
        private static string[] Header = new string[] { "-----BEGIN RSA PRIVATE KEY-----", "-----BEGIN PRIVATE KEY-----", "-----", "PRIVATE KEY", "BEGIN ", "END ", "RSA ", "-" };
        private static string[] Footer = new string[] { "-----END RSA PRIVATE KEY-----", "-----END PRIVATE KEY-----" };

        public ExtractPvkFile(CancellationToken cancelToken, string searchDirectory, string outFile, bool deleteFilesAfter, bool exportOnlyPQ, int batchSize = 1000)
        {
            if (!Directory.Exists(searchDirectory)) { throw new DirectoryNotFoundException(searchDirectory); }

            CancelToken = cancelToken;
            OutputFilename = outFile;
            SearchDirectory = searchDirectory;
            DeleteFiles = deleteFilesAfter;
            ExportOnlyPQ = exportOnlyPQ;
            BatchSize = batchSize;
        }

        public void Begin()
        {
            if (CancelToken.IsCancellationRequested)
            {
                return;
            }

            FilePaths = SearchExtensions.SelectMany(searchPattern => Directory.EnumerateFiles(SearchDirectory, searchPattern, SearchOption.TopDirectoryOnly));
            //FilePaths = Directory.EnumerateFiles(SearchDirectory, SearchExtension, SearchOption.TopDirectoryOnly);

            if (FilePaths == null)
            {
                throw new Exception("No files to process!");
            }

            byte[] bytes = new byte[] { };
            ANS1PrivateKey ans1Key = null;
            StringBuilder output = new StringBuilder();

            List<string> filesToDelete = new List<string>();

            IEnumerable<string> pathBatch = FilePaths.Take(BatchSize);

            while (pathBatch.Any() && !CancelToken.IsCancellationRequested)
            {
                foreach (string file in pathBatch)
                {
                    bytes = GetEncodedBytes(file);

                    if (bytes == null)
                    {
                        continue;
                    }
                    else if (bytes == EmptyByteArray)
                    {
                        if (DeleteFiles)
                        {
                            filesToDelete.Add(file);
                        }
                    }

                    using (ans1Key = new ANS1PrivateKey(bytes))
                    {
                        ans1Key.ParseBuffer();

                        EncodingUtility.AssertValidRSAPrivateKey(ans1Key);

                        if (ExportOnlyPQ)
                        {
                            PrivateKeySerializer.WritePQDocument(output, ans1Key);
                        }
                        else
                        {
                            PrivateKeySerializer.WriteXMLDocument(output, ans1Key);
                        }

                        bytes = null;

                        if (DeleteFiles)
                        {
                            filesToDelete.Add(file);
                        }
                    }
                }

                File.AppendAllText(OutputFilename, output.ToString());
                output.Clear();
                bytes = null;

                if (DeleteFiles && filesToDelete.Any())
                {
                    foreach (string file in filesToDelete)
                    {
                        File.Delete(file);
                    }
                    filesToDelete.Clear();
                }

                FilePaths = FilePaths.Skip(BatchSize);
                pathBatch = FilePaths.Take(BatchSize);
            }
        }

        private byte[] GetEncodedBytes(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            StringBuilder fileText = new StringBuilder(File.ReadAllText(filename));
            if (fileText.Length == 0 || string.IsNullOrWhiteSpace(fileText.ToString()))
            {
                return EmptyByteArray;
            }

            // Remove file headers, footers, and stuff that is not part of the base64 encoded data
            foreach (string str in ExtractPvkFile.Header)
            {
                fileText = fileText.Replace(str, "");
            }
            foreach (string str in ExtractPvkFile.Footer)
            {
                fileText = fileText.Replace(str, "");
            }
            fileText = fileText.Replace("\t", "").Replace("\r", "").Replace("\n", "");

            byte[] result = Convert.FromBase64String(fileText.ToString());
            fileText.Clear();
            fileText = null;
            return result;
        }
    }
}
