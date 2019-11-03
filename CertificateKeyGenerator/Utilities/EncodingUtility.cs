using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Numerics;
using System.Xml.XPath;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics.Contracts;

namespace CertificateKeyGenerator
{
    public static class EncodingUtility
    {
        private static string RSAKeyValue = "RSAKeyValue";
        private static BigInteger ByteMax = new BigInteger(256);

        public static string[] ExtractPandQ(string xmlString)
        {
            XElement rootElement = XDocument.Parse(xmlString, LoadOptions.None)
                                            .Element(RSAKeyValue);
            return new string[] { rootElement.Element("P").Value, rootElement.Element("Q").Value };
        }

        public static string ExtractModulus(string xmlString)
        {
            XElement rootElement = XDocument.Parse(xmlString, LoadOptions.None)
                                            .Element(RSAKeyValue);
            return rootElement.Element("Modulus").Value;
        }

        public static string DeBase64RSAKey(string xmlString)
        {
            XDocument xdoc = XDocument.Parse(xmlString, LoadOptions.None);
            XElement rootElement = xdoc.Element(RSAKeyValue);
            IEnumerable<XElement> childElements = rootElement.Elements();

            foreach (XElement element in childElements)
            {
                string base64String = new string(element.Value.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                byte[] elementBytes = Convert.FromBase64String(base64String);
                BigInteger value = CalculateValue(elementBytes);
                element.SetValue(value.ToString());
            }

            return xdoc.ToString(SaveOptions.None);
        }

        public static byte[] AsBytes(BigInteger value)
        {
            byte[] results = value.ToByteArray();
            Array.Reverse(results);
            return results;
        }

        public static void AssertValidRSAPrivateKey(ANS1PrivateKey key)
        {
            BigInteger pMinusOne = (key.P - 1);
            BigInteger qMinusOne = (key.Q - 1);
            BigInteger phi = BigInteger.Multiply(pMinusOne, qMinusOne);

            Contract.Assert(key.Modulus == (key.P * key.Q), "Modulus ≠ P*Q");
            Contract.Assert(key.DP == (key.D % pMinusOne), "DP ≢ D (mod P-1)");
            Contract.Assert(key.DQ == (key.D % qMinusOne), "DQ ≢ D (mod Q-1)");
            Contract.Assert(1 == ((key.D * key.Exponent) % phi), "D*Exponent ≢ 1 (mod phi(N))"); // (d) (e) mod phi(n) = 1
            Contract.Assert(1 == ((key.InverseQ * key.Q) % key.P), "Q*Q¯¹ ≢ 1 (mod P)"); //(InverseQ)(q) = 1 mod p
        }

        internal static BigInteger CalculateValue(byte[] input)
        {
            byte[] localCopy = new List<byte>(input).ToArray();
            Array.Reverse(localCopy);

            int counter = 0;
            BigInteger placeValue = new BigInteger(0);
            BigInteger result = new BigInteger(0);
            foreach (byte octet in localCopy)
            {
                placeValue = BigInteger.Pow(ByteMax, counter);
                placeValue *= octet;
                result += placeValue;
                counter++;
            }
            return result;
        }
    }
}
