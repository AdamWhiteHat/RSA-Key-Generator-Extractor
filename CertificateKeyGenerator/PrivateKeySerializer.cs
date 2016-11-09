using System.Security.Cryptography;
using System.Text;

namespace CertificateKeyGenerator
{
    public static class PrivateKeySerializer
    {
        private static CspParameters cspParams;

        static PrivateKeySerializer()
        {
            CspParameters csp = new CspParameters();
            csp.Flags = CspProviderFlags.UseArchivableKey | CspProviderFlags.NoPrompt | CspProviderFlags.UseArchivableKey;
            cspParams = csp;
        }

        public static string GetPrivateKeyPair(int keySize)
        {
            using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(keySize, cspParams) { PersistKeyInCsp = false })
            {
                return ToXMLDocument(rsaCsp.ExportParameters(true));
            }
        }
        public static string[] GetPrivateKeyPQ(int keySize)
        {
            using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(keySize, cspParams) { PersistKeyInCsp = false })
            {
                return ExtractPQ(rsaCsp.ExportParameters(true));
            }
        }

        private static string[] ExtractPQ(RSAParameters key)
        {
            return new string[]
            {
                EncodingUtility.CalculateValue(key.P).ToString(),
                EncodingUtility.CalculateValue(key.Q).ToString()
            };
        }

        private static string ToXMLDocument(RSAParameters key)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<RSAKeyValue>");
            sb.AppendLine($"  <Modulus>{EncodingUtility.CalculateValue(key.Modulus)}</Modulus>");
            sb.AppendLine($"  <Exponent>{EncodingUtility.CalculateValue(key.Exponent)}</Exponent>");
            sb.AppendLine($"  <P>{EncodingUtility.CalculateValue(key.P)}</P>");
            sb.AppendLine($"  <Q>{EncodingUtility.CalculateValue(key.Q)}</Q>");
            sb.AppendLine($"  <DP>{EncodingUtility.CalculateValue(key.DP)}</DP>");
            sb.AppendLine($"  <DQ>{EncodingUtility.CalculateValue(key.DQ)}</DQ>");
            sb.AppendLine($"  <InverseQ>{EncodingUtility.CalculateValue(key.InverseQ)}</InverseQ>");
            sb.AppendLine($"  <D>{EncodingUtility.CalculateValue(key.D)}</D>");
            sb.AppendLine($"</RSAKeyValue>");
            return sb.ToString();
        }
    }


}
