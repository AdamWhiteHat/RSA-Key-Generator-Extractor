using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CertificateKeyGenerator
{
    public class CertificateFile
    {
        public static string PublicKeyFileExtension = "*.cer";
        public static string PrivateKeyFileExtension = "*.pfx";
        public string FileLocation { get; private set; }
        public X509Certificate2 Certificate { get; private set; }

        public CertificateFile(X509Certificate2 cert)
        {
            Certificate = cert;
        }

        public CertificateFile(string fileLocation)
        {
            if (string.IsNullOrWhiteSpace(fileLocation)) { throw new ArgumentException(); }
            if (!File.Exists(fileLocation)) { throw new FileNotFoundException(); }

            this.FileLocation = fileLocation;
            this.Certificate = new X509Certificate2(FileLocation, "", X509KeyStorageFlags.Exportable);
        }

        public string GetPublicKey()
        {
            return EncodingUtility.ExtractModulus(EncodingUtility.DeBase64RSAKey(Certificate.PublicKey.Key.ToXmlString(false)));
        }

        public string GetPrivateKey()
        {
            if (Certificate.HasPrivateKey)
            {
                return EncodingUtility.DeBase64RSAKey(Certificate.PrivateKey.ToXmlString(true));

            }
            else
            {
                return EncodingUtility.DeBase64RSAKey(Certificate.PublicKey.Key.ToXmlString(false));
            }
        }

        public string GetThumbprint()
        {
            return Certificate.Thumbprint;
        }

        public void Remove()
        {            
            if (!string.IsNullOrWhiteSpace(FileLocation) && File.Exists(FileLocation))
            {
                File.Delete(FileLocation);
                FileLocation = null;
            }

            if (Certificate != null)
            {
                Certificate.Reset();
                Certificate = null;
            }
        }
    }
}
