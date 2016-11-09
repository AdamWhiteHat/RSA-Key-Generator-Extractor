using System;
using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Numerics;
using System.Xml.XPath;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace CertificateKeyGenerator
{
    public static class EncodingUtility
    {
        private static string RSAKeyValue = "RSAKeyValue";

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

        private static BigInteger ByteMax = new BigInteger(256);

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
