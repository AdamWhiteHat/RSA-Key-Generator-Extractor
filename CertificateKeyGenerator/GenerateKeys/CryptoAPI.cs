using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CertificateKeyGenerator
{
    public partial class GenerateKeys
    {
        public static string ElementKeys = "Keys";

        public static void CryptoAPI(int keySize, int quantity, int timeout, bool onlyExtractPQ)
        {
            string filename = FileDialogs.SaveDialog();
            if (filename == null)
            {
                return;
            }

            if (keySize % 8 != 0)
            {
                MessageBox.Show("The key size must be a multiple of 8.", "Key size error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            StringBuilder fileBuilder = new StringBuilder();
            bool onlyPrimes = onlyExtractPQ;

            try
            {
                if (!onlyPrimes)
                {
                    File.AppendAllText(filename, $"<{ElementKeys}>");
                }
                // Timeout
                DateTime quitTime = DateTime.Now.Add(TimeSpan.FromSeconds(timeout));

                int counter = 0;
                int writeSize = 409600;


                while (counter++ < quantity)
                {
                    if (DateTime.Now > quitTime)
                    {
                        break;
                    }
                    fileBuilder.AppendLine(onlyPrimes ? string.Join(Environment.NewLine, PrivateKeySerializer.GetPrivateKeyPQ(keySize)) : PrivateKeySerializer.GetPrivateKey(keySize));
                    if (fileBuilder.Length > writeSize)
                    {
                        File.AppendAllText(filename, fileBuilder.ToString());
                        fileBuilder.Clear();
                    }
                }
            }
            finally
            {
                if (fileBuilder != null && fileBuilder.Length > 0)
                {
                    File.AppendAllText(filename, fileBuilder.ToString());
                }

                if (!onlyPrimes)
                {
                    File.AppendAllText(filename, $"</{ElementKeys}>");
                }
            }
        }
    }
}
