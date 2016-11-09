using System;
using System.Linq;
using System.Text;
using System.Security;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace CertificateKeyGenerator
{
    public class PvkFileExtractor
    {
        private string OutputFilename;
        private string SearchDirectory;
        private IEnumerable<string> filePaths;

        private static string SearchExtension = "*.pvk";
        private static string Header = "-----BEGIN RSA PRIVATE KEY-----";
        private static string Footer = "-----END RSA PRIVATE KEY-----";

        public PvkFileExtractor(string searchDirectory, string outFile)
        {
            if (!Directory.Exists(searchDirectory)) { throw new DirectoryNotFoundException(searchDirectory); }

            OutputFilename = outFile;
            SearchDirectory = searchDirectory;
        }

        public void Begin()
        {
            filePaths = Directory.EnumerateFiles(SearchDirectory, SearchExtension, SearchOption.TopDirectoryOnly);

            if (filePaths == null)
            {
                throw new Exception("No files to process!");
            }

            byte[] bytes = new byte[] { };
            ANS1PrivateKey ans1Key = null;
            StringBuilder resultsBuilder = new StringBuilder();
            foreach (string file in filePaths)
            {
                bytes = GetEncodedBytes(file);
                if(bytes == null)
                {
                    continue;
                }

                ans1Key = new ANS1PrivateKey(bytes);
                resultsBuilder.AppendLine(ans1Key.P.ToString());
                resultsBuilder.AppendLine(ans1Key.Q.ToString());                

                File.AppendAllText(OutputFilename, resultsBuilder.ToString());

                File.Delete(file);
                resultsBuilder.Clear();
                ans1Key.Dispose();
                ans1Key = null;
            }
            if (ans1Key != null)
            {
                ans1Key.Dispose();
            }
            resultsBuilder = null;
            filePaths = null;
            bytes = null;
        }

        private byte[] GetEncodedBytes(string filename)
        {
            if(!File.Exists(filename))
            {
                return null;
            }

            string fileText = File.ReadAllText(filename);
            if (string.IsNullOrWhiteSpace(fileText))
            {
                File.Delete(filename);
                return null;
            }

            fileText = fileText
                .Replace(PvkFileExtractor.Header, "")
                .Replace(PvkFileExtractor.Footer, "")
                .Replace("\r", "")
                .Replace("\n", "");

            byte[] result = Convert.FromBase64String(fileText);
            fileText = null;
            return result;
        }

    }
}
