using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CertificateKeyGenerator
{
    public class ANS1PrivateKey : IDisposable
    {
        public BigInteger Modulus = BigInteger.MinusOne;
        public BigInteger Exponent = BigInteger.MinusOne;
        public BigInteger D = BigInteger.MinusOne;
        public BigInteger P = BigInteger.MinusOne;
        public BigInteger Q = BigInteger.MinusOne;
        public BigInteger DP = BigInteger.MinusOne;
        public BigInteger DQ = BigInteger.MinusOne;
        public BigInteger QInverse = BigInteger.MinusOne;

        private int byteCount;
        private IEnumerable<byte> byteBuffer;

        private static byte SequenceTag = 0x30; // ASN.1 tag for sequence
        private static byte IntTag = 0x02; // ASN.1 tag for int; Length encoded on next byte
        private static byte Version0 = 0x00; // Version 0; RSA private key with 2 primes       

        public ANS1PrivateKey(byte[] bytes)
        {
            byteCount = bytes.Length;
            byteBuffer = bytes.ToList();
        }

        public void Dispose()
        {
            byteCount = -1;
            byteBuffer = null;
            Modulus = Exponent = D = P = Q = DP = DQ = QInverse = BigInteger.MinusOne;
        }

        private byte PeekBuffer()
        {
            return byteBuffer.First();
        }

        private byte TakeBuffer()
        {
            byte result = byteBuffer.First();
            byteBuffer = byteBuffer.Skip(1);
            return result;
        }

        private byte[] TakeBuffer(int count)
        {
            byte[] result = byteBuffer.Take(count).ToArray();
            byteBuffer = byteBuffer.Skip(count);
            return result;
        }

        private FormatException ThrowFormatException(object expected = null, object actual = null)
        {
            string additionalInfo = "";
            if (expected != null && actual != null)
            {
                int offset = byteCount - byteBuffer.Count();
                additionalInfo = $"Byte #{offset}:  Expected value: {expected.ToString()}, Actual value: {actual.ToString()}.";
            }

            throw new FormatException($"Not a valid Version 0 (private key) ASN.1 sequence. {additionalInfo}");
        }

        private void AssertNextValueIs(byte value)
        {
            byte bufferValue = TakeBuffer();
            if (!bufferValue.Equals(value))
            {
                ThrowFormatException(bufferValue, value);
            }
        }

        private void AssertNextValueIs(byte[] value)
        {
            byte[] chunk = TakeBuffer(value.Length);
            if (chunk.Length != value.Length)
            {
                ThrowFormatException(chunk.Length, value.Length);
            }

            int counter = 0;
            foreach (byte bite in chunk)
            {
                if (!bite.Equals(value[counter]))
                {
                    ThrowFormatException(bite, value[counter]);
                }
                counter++;
            }
            chunk = null;
        }

        private BigInteger GetNextVariableValue()
        {
            AssertNextValueIs(IntTag);
            int readSize = 0;
            byte variableSize = TakeBuffer();
            if (variableSize > 127)
            {
                if (variableSize.Equals(0x81))
                {
                    readSize = TakeBuffer();
                }
                else if (variableSize.Equals(0x82))
                {
                    readSize = (int)EncodingUtility.CalculateValue(TakeBuffer(2));
                }
                else if (variableSize.Equals(0x83))
                {
                    readSize = (int)EncodingUtility.CalculateValue(TakeBuffer(3));
                }
                else if (variableSize.Equals(0x84))
                {
                    readSize = (int)EncodingUtility.CalculateValue(TakeBuffer(4));
                }
                else
                {
                    throw new OverflowException("This class does not support parsing integers with a byte size greater than int.MaxValue");
                }
            }
            else
            {
                readSize = variableSize;
            }

            byte peek = PeekBuffer();
            if (peek.Equals(0x00))
            {
                TakeBuffer();
                readSize--;
            }

            byte[] variableBytes = TakeBuffer(readSize);
            BigInteger variableValue = EncodingUtility.CalculateValue(variableBytes);
            variableBytes = null;
            return variableValue;
        }

        public void ParseBuffer()
        {
            AssertNextValueIs(SequenceTag);

            byte prefixLength = TakeBuffer();
            BigInteger bodyLength = EncodingUtility.CalculateValue(TakeBuffer(2));

            int bufferLen = byteBuffer.Count();
            if (!bodyLength.Equals(bufferLen))
            {
                ThrowFormatException(bodyLength, bufferLen);
            }

            AssertNextValueIs(IntTag);
            AssertNextValueIs(0x01);
            AssertNextValueIs(Version0);

            Modulus = GetNextVariableValue();
            Exponent = GetNextVariableValue();
            D = GetNextVariableValue();
            P = GetNextVariableValue();
            Q = GetNextVariableValue();
            DP = GetNextVariableValue();
            DQ = GetNextVariableValue();
            QInverse = GetNextVariableValue();
        }

        /* **Format of RSAPrivateKey encoded in ASN.1**
        SequenceTag, 1 byte;
        Length of prefix, 1 byte;
        Length of body, 2 bytes;
        IntTag, 1 byte;
        Value, 1 byte;
        Version0, 1 byte;       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // public modulus n (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // public exponent e (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // private exponent d (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // secret prime p (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // secret prime q (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // dp=d mod p−1 (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // dq=d mod q−1 (big-endian, leftmost bit is sign)       
        IntTag, 1 byte;
        Length, 1 byte;
        Value, Length bytes; // qinv=q^−1 mod p (big-endian, leftmost bit is sign)
        */
    }
}
