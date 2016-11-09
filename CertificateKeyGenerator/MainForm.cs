using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CertificateKeyGenerator
{
    public partial class MainForm : Form
    {
        public int KeySize { get { return int.Parse(tbGenerateKeysize.Text); } }
        public int Timeout { get { return int.Parse(tbGenerateTimeout.Text); } }
        public int Quantity { get { return int.Parse(tbGenerateQuantity.Text); } }
        public string SearchDirectory { get { return tbFolderSearchPath.Text; } private set { tbFolderSearchPath.Text = value; } }
        public bool DeleteFiles { get { return cbFolderDeleteFiles.Checked; } private set { cbFolderDeleteFiles.Checked = value; } }
        public bool PrivateKeys { get { return cbFolderPrivateKeys.Checked; } private set { cbFolderPrivateKeys.Checked = value; } }

        private int fileCounter;
        private string rootKeysElement = "Keys";
        private AsyncBackgroundTask backgroundTask;
        private CertificateFileCollection certificates;
        private string lastDirectory;

        private static string DefaultDirectory = @"C:\Maths\My Applications\FactorByGenerating";
        private static string DefaultFileName = "PrivateKeys.{0}.Output.txt";

        public MainForm()
        {
            InitializeComponent();

            fileCounter = 0;
            cbStoreAll.Checked = true;
            cbStoreAll.Enabled = false;
            btnFolderCertBegin.Enabled = false;
            radioXmlModulus.Checked = true;
            //cbDeleteFiles.Checked = true;
            lastDirectory = DefaultDirectory;
            backgroundTask = new AsyncBackgroundTask();
        }

        #region Winforms Events

        private void buttonPvkSelectFiles_Click(object sender, EventArgs e)
        {
            string directory = BrowseDialog();
            if (directory == null)
            {
                return;
            }

            string outFile = SaveDialog();
            if (outFile == null)
            {
                return;
            }

            // Disable UI
            groupControls.Enabled = false;

            PvkFileExtractor pvkFile = new PvkFileExtractor(directory, outFile, cbXmlPkvDeleteFiles.Checked);
            pvkFile.Begin();


            // Enable the UI again
            groupControls.Enabled = true;
        }

        private void buttonXmlSelectFiles_Click(object sender, EventArgs e)
        {
            string inFile = OpenDialog();
            if (inFile == null)
            {
                return;
            }

            string outFile = SaveDialog();
            if (outFile == null)
            {
                return;
            }

            // Disable UI
            groupControls.Enabled = false;

            string extractName = "Modulus";

            if (radioXmlPQ.Checked)
            {

            }

            XDocument document = XDocument.Load(inFile);
            XElement rootElement = document.Element(rootKeysElement);
            IEnumerable<XElement> inElements = rootElement.Elements();

            List<XElement> outElements = new List<XElement>();
            foreach (XElement element in inElements)
            {
                outElements.Add(element.Element(extractName));
            }

            File.WriteAllLines(outFile, outElements.Select(el => el.Value));

            // Enable the UI again
            groupControls.Enabled = true;
        }

        private void cbStoreAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStoreAll.Checked)
            {
                panelStoreCombo.Enabled = false;
            }
            else
            {
                panelStoreCombo.Enabled = true;
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            string directory = BrowseDialog();
            if (directory == null)
            {
                return;
            }

            SearchDirectory = directory;

            btnFolderCertBegin.Enabled = true;
        }

        private void btnFolderCertBegin_Click(object sender, EventArgs e)
        {
            string filename = SaveDialog();
            if (filename == null)
            {
                return;
            }

            // Disable UI
            groupControls.Enabled = false;

            certificates = new CertificateFileCollection(SearchDirectory, PrivateKeys);
            if (certificates == null)
            {
                return;
            }

            btnFolderCertBegin.Enabled = false;
            btnFolderSelect.Enabled = false;
            backgroundTask.DoWork += TaskWork;
            backgroundTask.RunWorkerCompleted += TaskCleanup;
            backgroundTask.RunWorkerAsync(filename);

            // Enable the UI again
            groupControls.Enabled = true;
        }

        Timer generateKeysTimer = new Timer();
        private void btnGenerateQuantity_Click(object sender, EventArgs e)
        {
            string filename = SaveDialog();
            if (filename == null)
            {
                return;
            }

            int keySize = KeySize;
            if (keySize % 8 != 0)
            {
                MessageBox.Show("The key size must be a multiple of 8.", "Key size error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Disable UI
            groupControls.Enabled = false;
            StringBuilder fileBuilder = new StringBuilder();
            bool onlyPrimes = cbGenerateOnlyPrimes.Checked;

            try
            {
                if (!onlyPrimes)
                {
                    File.AppendAllText(filename, $"<{rootKeysElement}>");
                }
                // Timeout
                DateTime quitTime = DateTime.Now.Add(TimeSpan.FromSeconds(Timeout));

                int counter = 0;
                int quantity = Quantity;
                int writeSize = 409600;


                while (counter++ < quantity)
                {
                    if (DateTime.Now > quitTime)
                    {
                        break;
                    }
                    fileBuilder.AppendLine(onlyPrimes ? string.Join(Environment.NewLine, PrivateKeySerializer.GetPrivateKeyPQ(keySize)) : PrivateKeySerializer.GetPrivateKeyPair(keySize));
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
                    File.AppendAllText(filename, $"</{rootKeysElement}>");
                }

                // Enable the UI again
                groupControls.Enabled = true;
            }
        }

        private void btnStoreExtract_Click(object sender, EventArgs e)
        {
            string filename = SaveDialog();
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

            // Disable UI
            groupControls.Enabled = false;

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

            // Enable the UI again
            groupControls.Enabled = true;
        }

        #endregion

        #region Task Methods

        private void TaskWork(object s, DoWorkEventArgs e)
        {
            string outputFilename = (string)e.Argument;
            List<string> keys = certificates.GetKeys();
            File.WriteAllLines(outputFilename, keys);

            if (File.Exists(outputFilename))
            {
                if (cbFolderDeleteFiles.Checked)
                {
                    certificates.RemoveAllFiles();
                }
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }

        private void TaskCleanup(object s, RunWorkerCompletedEventArgs e)
        {
            btnFolderSelect.Enabled = true;
            tbFolderSearchPath.Text = string.Empty;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = (bool)e.Result;
                if (!success)
                {
                    MessageBox.Show("BackgroundWorker returned a result of unsuccessful.\nNo exception was thrown.");
                }
            }
        }

        #endregion

        public string BrowseDialog()
        {
            using (FolderBrowserDialog browseForFolder = new FolderBrowserDialog())
            {
                browseForFolder.Description = "Select search folder";
                browseForFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                browseForFolder.SelectedPath = lastDirectory;
                if (browseForFolder.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = browseForFolder.SelectedPath;
                    return browseForFolder.SelectedPath;
                }
            }
            return null;
        }

        public string SaveDialog()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Select output file";
                saveDialog.OverwritePrompt = false;               
                saveDialog.InitialDirectory = lastDirectory;                
                saveDialog.FileName = string.Format(DefaultFileName, fileCounter++);                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = Path.GetDirectoryName(saveDialog.FileName);
                    return saveDialog.FileName;
                }
            }
            return null;
        }

        public string OpenDialog()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Select file to open";
                openDialog.InitialDirectory = lastDirectory;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = Path.GetDirectoryName(openDialog.FileName);
                    return openDialog.FileName;
                }
            }
            return null;
        }
    }
}
