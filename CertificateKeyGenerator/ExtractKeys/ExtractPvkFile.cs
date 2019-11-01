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
        private bool DeleteFiles;
        private string OutputFilename;
        private string SearchDirectory;
        private IEnumerable<string> FilePaths;
        private CancellationToken cancel;

        private static string SearchExtension = "*.pvk";
        private static string[] Header = new string[] { "-----BEGIN RSA PRIVATE KEY-----", "-----BEGIN PRIVATE KEY-----", "-----", "PRIVATE KEY", "BEGIN ", "END ", "RSA ", "-" };
        private static string[] Footer = new string[] { "-----END RSA PRIVATE KEY-----", "-----END PRIVATE KEY-----" };

        public ExtractPvkFile(CancellationToken cancelToken, string searchDirectory, string outFile, bool deleteFilesAfter)
            : this(searchDirectory, outFile, deleteFilesAfter)
        {
            cancel = cancelToken;
        }

        public ExtractPvkFile(string searchDirectory, string outFile, bool deleteFilesAfter)
        {
            if (!Directory.Exists(searchDirectory)) { throw new DirectoryNotFoundException(searchDirectory); }

            OutputFilename = outFile;
            SearchDirectory = searchDirectory;
            DeleteFiles = deleteFilesAfter;
        }

        public void Begin()
        {
            if (cancel.IsCancellationRequested)
            {
                return;
            }
            FilePaths = Directory.EnumerateFiles(SearchDirectory, SearchExtension, SearchOption.TopDirectoryOnly);

            if (FilePaths == null)
            {
                throw new Exception("No files to process!");
            }

            // Could be config setting
            int batchSize = 1000;

            int counter = 0;
            byte[] bytes = new byte[] { };
            ANS1PrivateKey ans1Key = null;
            StringBuilder output = new StringBuilder();

            var pathBatch = FilePaths.Take(batchSize);

            while (pathBatch.Any() && !cancel.IsCancellationRequested)
            {
                foreach (string file in pathBatch)
                {
                    bytes = GetEncodedBytes(file);
                    if (bytes == null)
                    {
                        continue;
                    }

                    using (ans1Key = new ANS1PrivateKey(bytes))
                    {
                        ans1Key.ParseBuffer();
                        output.AppendLine(ans1Key.P.ToString());
                        output.AppendLine(ans1Key.Q.ToString());

                        counter++;
                        DeleteFile(file);
                    }
                }

                File.AppendAllText(OutputFilename, output.ToString());
                output.Clear();
                bytes = null;

                FilePaths = FilePaths.Skip(batchSize);
                pathBatch = FilePaths.Take(batchSize);
            }
        }

        private byte[] GetEncodedBytes(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            string fileText = File.ReadAllText(filename);
            if (string.IsNullOrWhiteSpace(fileText))
            {
                DeleteFile(filename);
                return null;
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

            byte[] result = Convert.FromBase64String(fileText);
            fileText = null;
            return result;
        }

        private void DeleteFile(string filename)
        {
            if (DeleteFiles && File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

    }
}
