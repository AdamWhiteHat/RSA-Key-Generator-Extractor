using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CertificateKeyGenerator
{
    public class ExtractKeystore
    {
        public static void Extract()
        {
            string filename = FileDialogs.SaveDialog();
            if (filename == null)
            {
                return;
            }

            List<StoreLocation> ListOfStoreLocation =
                new List<StoreLocation>()
                {
                    StoreLocation.CurrentUser,
                    StoreLocation.LocalMachine
                };

            List<StoreName> ListOfStoreNames =
                new List<StoreName>()
                {
                    StoreName.Disallowed,
                    StoreName.AddressBook,
                    StoreName.AuthRoot,
                    StoreName.CertificateAuthority,
                    StoreName.My,
                    StoreName.Root,
                    StoreName.TrustedPeople,
                    StoreName.TrustedPublisher
                };

            List<CertificateFile> certList = new List<CertificateFile>();
            foreach (StoreLocation location in ListOfStoreLocation)
            {
                foreach (StoreName name in ListOfStoreNames)
                {
                    X509Store store = new X509Store(name, location);
                    store.Open(OpenFlags.ReadOnly);

                    foreach (X509Certificate2 cert in store.Certificates)
                    {
                        CertificateFile newRow = new CertificateFile(cert);
                        certList.Add(newRow);
                    }

                    store.Close();
                }
            }

            CertificateFileCollection storeCollection = new CertificateFileCollection(certList);

            List<string> keys = storeCollection.GetPublicKeys();

            File.AppendAllLines(filename, keys);
        }
    }
}
