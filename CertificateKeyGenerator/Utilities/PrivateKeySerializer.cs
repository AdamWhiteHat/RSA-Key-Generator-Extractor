using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CertificateKeyGenerator
{
    public static class PrivateKeySerializer
    {
        private static CspParameters cspParams;

        static PrivateKeySerializer()
        {
            CspParameters csp = new CspParameters();
            csp.Flags = CspProviderFlags.UseArchivableKey | CspProviderFlags.NoPrompt | CspProviderFlags.CreateEphemeralKey;
            cspParams = csp;
        }

        public static string GetPrivateKey(int keySize)
        {
            using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(keySize, cspParams))
            {
                rsaCsp.PersistKeyInCsp = false;
                return ToXMLDocument(rsaCsp.ExportParameters(true));
            }
        }

        public static string[] GetPrivateKeyPQ(int keySize)
        {
            using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(keySize, cspParams))
            {
                rsaCsp.PersistKeyInCsp = false;
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

        public static RSAParameters ToRSAParameters(ANS1PrivateKey key)
        {
            RSAParameters result = new RSAParameters();
            result.Modulus = EncodingUtility.AsBytes(key.Modulus);
            result.Exponent = EncodingUtility.AsBytes(key.Exponent);
            result.P = EncodingUtility.AsBytes(key.P);
            result.Q = EncodingUtility.AsBytes(key.Q);
            result.DP = EncodingUtility.AsBytes(key.DP);
            result.DQ = EncodingUtility.AsBytes(key.DQ);
            result.D = EncodingUtility.AsBytes(key.D);
            result.InverseQ = EncodingUtility.AsBytes(key.InverseQ);
            return result;
        }

        public static string ToXMLDocument(RSAParameters key)
        {
            StringBuilder result = new StringBuilder();
            WriteXMLDocument(result, key);
            return result.ToString();
        }

        public static string ToXMLDocument(ANS1PrivateKey key)
        {
            StringBuilder result = new StringBuilder();
            WriteXMLDocument(result, key);
            return result.ToString();
        }

        public static void WritePQDocument(StringBuilder stringBuilder, ANS1PrivateKey key)
        {
            stringBuilder.AppendLine($"<RSAKeyValue>");
            stringBuilder.AppendLine($"  <P>{key.P}</P>");
            stringBuilder.AppendLine($"  <Q>{key.Q}</Q>");
            stringBuilder.AppendLine($"</RSAKeyValue>");
            stringBuilder.Append(Environment.NewLine);
        }

        public static void WriteXMLDocument(StringBuilder stringBuilder, RSAParameters key)
        {
            stringBuilder.AppendLine($"<RSAKeyValue>");
            stringBuilder.AppendLine($"  <Modulus>{EncodingUtility.CalculateValue(key.Modulus)}</Modulus>");
            stringBuilder.AppendLine($"  <Exponent>{EncodingUtility.CalculateValue(key.Exponent)}</Exponent>");
            stringBuilder.AppendLine($"  <P>{EncodingUtility.CalculateValue(key.P)}</P>");
            stringBuilder.AppendLine($"  <Q>{EncodingUtility.CalculateValue(key.Q)}</Q>");
            stringBuilder.AppendLine($"  <DP>{EncodingUtility.CalculateValue(key.DP)}</DP>");
            stringBuilder.AppendLine($"  <DQ>{EncodingUtility.CalculateValue(key.DQ)}</DQ>");
            stringBuilder.AppendLine($"  <InverseQ>{EncodingUtility.CalculateValue(key.InverseQ)}</InverseQ>");
            stringBuilder.AppendLine($"  <D>{EncodingUtility.CalculateValue(key.D)}</D>");
            stringBuilder.AppendLine($"</RSAKeyValue>");
            stringBuilder.Append(Environment.NewLine);
        }

        public static void WriteXMLDocument(StringBuilder stringBuilder, ANS1PrivateKey key)
        {
            stringBuilder.AppendLine($"<RSAKeyValue>");
            stringBuilder.AppendLine($"  <Modulus>{key.Modulus}</Modulus>");
            stringBuilder.AppendLine($"  <Exponent>{key.Exponent}</Exponent>");
            stringBuilder.AppendLine($"  <P>{key.P}</P>");
            stringBuilder.AppendLine($"  <Q>{key.Q}</Q>");
            stringBuilder.AppendLine($"  <DP>{key.DP}</DP>");
            stringBuilder.AppendLine($"  <DQ>{key.DQ}</DQ>");
            stringBuilder.AppendLine($"  <InverseQ>{key.InverseQ}</InverseQ>");
            stringBuilder.AppendLine($"  <D>{key.D}</D>");
            stringBuilder.AppendLine($"</RSAKeyValue>");
            stringBuilder.Append(Environment.NewLine);
        }
    }
}
