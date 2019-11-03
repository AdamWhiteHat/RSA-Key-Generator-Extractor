using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CertificateKeyGenerator
{
    public partial class MainForm : Form
    {
        public int KeySize { get { return int.Parse(tbGenerateKeysize.Text); } }
        public int Timeout { get { return int.Parse(tbGenerateTimeout.Text); } }
        public int Quantity { get { return int.Parse(tbGenerateQuantity.Text); } }
        //public bool DeleteFiles { get { return cbFolderDeleteFiles.Checked; } private set { cbFolderDeleteFiles.Checked = value; } }
        //public bool PrivateKeys { get { return radioPQOnly.Checked; } private set { radioPQOnly.Checked = value; } }

        private CancellationTokenSource cancleSource;

        private AsyncBackgroundTask cerBackgroundTask;
        private AsyncBackgroundTask pvkBackgroundTask;
        private AsyncBackgroundTask xmlBackgroundTask;
        private AsyncBackgroundTask cryptoApiBackgroundTask;
        private AsyncBackgroundTask keystoreBackgroundTask;
        private string lastDirectory;

        private static string modulusElementName = "Modulus";
        private static string DefaultDirectory = @"C:\Maths\My Applications\FactorByGenerating";

        public MainForm()
        {
            InitializeComponent();

            cancleSource = new CancellationTokenSource();

            cbExtractAllKeystore.Checked = true;
            cbExtractAllKeystore.Enabled = false;

            lastDirectory = DefaultDirectory;

            panelCancel.BackColor = Color.FromArgb(120, Color.FromKnownColor(KnownColor.Control));
            panelCancel.Visible = false;

            pvkBackgroundTask = new AsyncBackgroundTask();
            xmlBackgroundTask = new AsyncBackgroundTask();
            cerBackgroundTask = new AsyncBackgroundTask();
            keystoreBackgroundTask = new AsyncBackgroundTask();
            cryptoApiBackgroundTask = new AsyncBackgroundTask();
        }

        #region Winforms Events

        private void btnExtractPvkSelectFiles_Click(object sender, EventArgs e)
        {
            if (!pvkBackgroundTask.IsBusy)
            {
                string directory = FileDialogs.BrowseDialog();
                if (directory == null)
                {
                    return;
                }

                string outFile = FileDialogs.SaveDialog();
                if (outFile == null)
                {
                    return;
                }

                bool delFiles = cbExtractDeleteFiles.Checked;
                bool exportOnlyPQ = cbExportOnlyPQ.Checked;

                pvkBackgroundTask = new AsyncBackgroundTask();
                pvkBackgroundTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (a, b) =>
                {
                    pvkBackgroundTask.SetWorkerStatus(false);
                    EnableControl(groupAllControls, true);
                });

                pvkBackgroundTask.DoWork += new DoWorkEventHandler((sndr, args) =>
                {
                    PvkTaskMethod(cancleSource.Token, directory, outFile, delFiles, exportOnlyPQ);
                });
                pvkBackgroundTask.RunWorkerAsync();
            }
        }

        private void btnExtractXmlSelectFiles_Click(object sender, EventArgs e)
        {
            if (!xmlBackgroundTask.IsBusy)
            {
                string inFile = FileDialogs.OpenDialog();
                if (inFile == null)
                {
                    return;
                }

                string outFile = FileDialogs.SaveDialog();
                if (outFile == null)
                {
                    return;
                }

                //bool privKeys = false;
                //if (radioExtractPQOnly.Checked)
                //{
                //    privKeys = radioExtractPQOnly.Checked;
                //}

                xmlBackgroundTask = new AsyncBackgroundTask();
                xmlBackgroundTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (a, b) =>
                    {
                        xmlBackgroundTask.SetWorkerStatus(false);
                        EnableControl(groupAllControls, true);
                    });

                xmlBackgroundTask.DoWork += new DoWorkEventHandler((sndr, args) =>
                {
                    XmlTaskMethod(cancleSource.Token, inFile, outFile);
                });
                xmlBackgroundTask.RunWorkerAsync();
            }
        }

        private void cbExtractAllKeystore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExtractAllKeystore.Checked)
            {
                panelExtractKeystoreCombo.Enabled = false;
            }
            else
            {
                panelExtractKeystoreCombo.Enabled = true;
            }
        }

        private void btnExtractFolderCertBegin_Click(object sender, EventArgs e)
        {
            if (!cerBackgroundTask.IsBusy)
            {
                string directory = FileDialogs.BrowseDialog();
                if (directory == null)
                {
                    return;
                }

                string filename = FileDialogs.SaveDialog();
                if (filename == null)
                {
                    return;
                }

                bool privKeys = cbExportOnlyPQ.Checked;
                bool deleteFiles = cbExtractDeleteFiles.Checked;

                cerBackgroundTask = new AsyncBackgroundTask();
                cerBackgroundTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (a, b) =>
                {
                    EnableControl(groupAllControls, true);
                    cerBackgroundTask.SetWorkerStatus(false);
                });

                cerBackgroundTask.DoWork += new DoWorkEventHandler((sndr, args) =>
                {
                    CerTaskMethod(directory, filename, privKeys, deleteFiles);
                });
                cerBackgroundTask.RunWorkerAsync();
            }
        }

        private void btnGenerateQuantity_Click(object sender, EventArgs e)
        {
            if (!cryptoApiBackgroundTask.IsBusy)
            {
                int keySize = KeySize;
                int quantity = Quantity;
                int timeout = Timeout;
                bool onlyGeneratePQ = cbGenerateOnlyPrimes.Checked;

                cryptoApiBackgroundTask = new AsyncBackgroundTask();
                cryptoApiBackgroundTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (a, b) =>
                {
                    EnableControl(groupAllControls, true);
                    cryptoApiBackgroundTask.SetWorkerStatus(false);
                });

                cryptoApiBackgroundTask.DoWork += new DoWorkEventHandler((sndr, args) =>
                {
                    GenerateCryptoAPIKeysTask(keySize, quantity, timeout, onlyGeneratePQ);
                });
                cryptoApiBackgroundTask.RunWorkerAsync();
            }
        }

        private void btnExtractKeystore_Click(object sender, EventArgs e)
        {
            if (!keystoreBackgroundTask.IsBusy)
            {
                string directory = FileDialogs.BrowseDialog();
                if (directory == null)
                {
                    return;
                }

                string outFile = FileDialogs.SaveDialog();
                if (outFile == null)
                {
                    return;
                }

                bool delFiles = cbExtractDeleteFiles.Checked;

                keystoreBackgroundTask = new AsyncBackgroundTask();
                keystoreBackgroundTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (a, b) =>
                {
                    EnableControl(groupAllControls, true);
                });

                keystoreBackgroundTask.DoWork += new DoWorkEventHandler((sndr, args) =>
                {
                    ExtractKeystoreTask();
                });
                keystoreBackgroundTask.RunWorkerAsync();
            }
        }

        private void tbCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        #endregion

        #region Task Methods

        private void GenerateCryptoAPIKeysTask(int keySize, int quantity, int timeout, bool onlyExtractPQ)
        {
            EnableControl(groupAllControls, false);
            GenerateKeys.CryptoAPI(keySize, quantity, timeout, onlyExtractPQ);
        }

        private void ExtractKeystoreTask()
        {
            EnableControl(groupAllControls, false);
            ExtractKeystore.Extract();
        }

        private void PvkTaskMethod(CancellationToken cancelToken, string directory, string outFile, bool delFiles, bool exportOnlyPQ)
        {
            EnableControl(groupAllControls, false);
            ExtractPvkFile pvkFile = new ExtractPvkFile(cancelToken, directory, outFile, delFiles, exportOnlyPQ);
            pvkFile.Begin();
            pvkFile = null;
        }

        private void XmlTaskMethod(CancellationToken cancelToken, string inFile, string outFile)
        {
            EnableControl(groupAllControls, false);
            XDocument document = XDocument.Load(inFile);
            XElement rootElement = document.Element(GenerateKeys.ElementKeys);
            List<XElement> inElements = rootElement.Elements().ToList();

            List<XElement> outElements = new List<XElement>();
            foreach (XElement element in inElements)
            {
                outElements.Add(element.Element(modulusElementName));
            }

            inElements.Clear();
            rootElement = null;
            document = null;

            File.WriteAllLines(outFile, outElements.Select(el => el.Value));
            outElements.Clear();
        }

        private void CerTaskMethod(string searchDir, string saveFilename, bool privKeys, bool deleteFiles)
        {
            EnableControl(groupAllControls, false);
            panelCancel.Visible = true;
            panelCancel.BringToFront();
            CertificateFileCollection certificates = new CertificateFileCollection(searchDir, privKeys, deleteFiles);
            if (certificates != null)
            {
                File.WriteAllLines(saveFilename, certificates.GetKeys());
                certificates = null;
            }
        }

        #endregion

        #region Helper Methods

        private void EnableControl(Control control, bool enable)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(() => { EnableControl(control, enable); }));
            }
            else
            {
                control.Enabled = enable;
                if (!enable)
                {
                    ShowCancelPanel();
                }
                else
                {
                    Cancel();
                }

            }
        }

        private void ShowCancelPanel()
        {
            if (panelCancel.InvokeRequired)
            {
                panelCancel.Invoke(new MethodInvoker(() => ShowCancelPanel()));
            }
            else
            {
                if (!panelCancel.Visible)
                {
                    panelCancel.Visible = true;
                    groupAllControls.Enabled = false;
                    panelCancel.BringToFront();
                }
            }
        }

        private void Cancel()
        {
            if (panelCancel.InvokeRequired)
            {
                panelCancel.Invoke(new MethodInvoker(() => Cancel()));
            }
            else
            {
                if (cerBackgroundTask.IsBusy)
                {
                    cerBackgroundTask.CancelAsync();
                }
                else if (xmlBackgroundTask.IsBusy)
                {
                    xmlBackgroundTask.CancelAsync();
                }
                else if (pvkBackgroundTask.IsBusy)
                {
                    pvkBackgroundTask.CancelAsync();
                }

                if (panelCancel.Visible)
                {
                    panelCancel.Visible = false;
                    groupAllControls.Enabled = true;
                    groupAllControls.BringToFront();
                }
            }
        }

        #endregion

    }
}
