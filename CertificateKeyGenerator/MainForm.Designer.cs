namespace CertificateKeyGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupExtract = new System.Windows.Forms.GroupBox();
            this.groupExtractFromFiles = new System.Windows.Forms.GroupBox();
            this.btnExtractFolderCertBegin = new System.Windows.Forms.Button();
            this.btnExtractPvkSelectFiles = new System.Windows.Forms.Button();
            this.cbExtractDeleteFiles = new System.Windows.Forms.CheckBox();
            this.btnExtractXmlSelectFiles = new System.Windows.Forms.Button();
            this.groupExtractFromStore = new System.Windows.Forms.GroupBox();
            this.panelExtractKeystoreCombo = new System.Windows.Forms.Panel();
            this.comboExtractKeystoreName = new System.Windows.Forms.ComboBox();
            this.comboExtractKeystoreLocation = new System.Windows.Forms.ComboBox();
            this.cbExtractAllKeystore = new System.Windows.Forms.CheckBox();
            this.btnExtractKeystore = new System.Windows.Forms.Button();
            this.groupGenerateCryptoAPI = new System.Windows.Forms.GroupBox();
            this.cbGenerateOnlyPrimes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGenerateKeysize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGenerateTimeout = new System.Windows.Forms.TextBox();
            this.tbGenerateQuantity = new System.Windows.Forms.TextBox();
            this.btnGenerateQuantity = new System.Windows.Forms.Button();
            this.panelCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupGenerate = new System.Windows.Forms.GroupBox();
            this.groupGenerateOpenSSL = new System.Windows.Forms.GroupBox();
            this.btnGenerateOpenSSL = new System.Windows.Forms.Button();
            this.tbGenerateOpenSSLCommandText = new System.Windows.Forms.TextBox();
            this.groupAllControls = new System.Windows.Forms.Panel();
            this.cbExportOnlyPQ = new System.Windows.Forms.CheckBox();
            this.groupExtract.SuspendLayout();
            this.groupExtractFromFiles.SuspendLayout();
            this.groupExtractFromStore.SuspendLayout();
            this.panelExtractKeystoreCombo.SuspendLayout();
            this.groupGenerateCryptoAPI.SuspendLayout();
            this.panelCancel.SuspendLayout();
            this.groupGenerate.SuspendLayout();
            this.groupGenerateOpenSSL.SuspendLayout();
            this.groupAllControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupExtract
            // 
            this.groupExtract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupExtract.Controls.Add(this.groupExtractFromFiles);
            this.groupExtract.Controls.Add(this.groupExtractFromStore);
            this.groupExtract.ForeColor = System.Drawing.Color.Black;
            this.groupExtract.Location = new System.Drawing.Point(3, 3);
            this.groupExtract.Name = "groupExtract";
            this.groupExtract.Size = new System.Drawing.Size(604, 155);
            this.groupExtract.TabIndex = 0;
            this.groupExtract.TabStop = false;
            this.groupExtract.Text = "Extract public && private keys";
            // 
            // groupExtractFromFiles
            // 
            this.groupExtractFromFiles.Controls.Add(this.cbExportOnlyPQ);
            this.groupExtractFromFiles.Controls.Add(this.btnExtractFolderCertBegin);
            this.groupExtractFromFiles.Controls.Add(this.btnExtractPvkSelectFiles);
            this.groupExtractFromFiles.Controls.Add(this.cbExtractDeleteFiles);
            this.groupExtractFromFiles.Controls.Add(this.btnExtractXmlSelectFiles);
            this.groupExtractFromFiles.Location = new System.Drawing.Point(18, 72);
            this.groupExtractFromFiles.Name = "groupExtractFromFiles";
            this.groupExtractFromFiles.Size = new System.Drawing.Size(576, 69);
            this.groupExtractFromFiles.TabIndex = 4;
            this.groupExtractFromFiles.TabStop = false;
            this.groupExtractFromFiles.Text = "Extract and save <RSAKeyValue> data from: *.xml files, *.pvk files OR *.cer files" +
    "";
            // 
            // btnExtractFolderCertBegin
            // 
            this.btnExtractFolderCertBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractFolderCertBegin.Location = new System.Drawing.Point(234, 19);
            this.btnExtractFolderCertBegin.Name = "btnExtractFolderCertBegin";
            this.btnExtractFolderCertBegin.Size = new System.Drawing.Size(100, 23);
            this.btnExtractFolderCertBegin.TabIndex = 2;
            this.btnExtractFolderCertBegin.Text = "Select CER Files";
            this.btnExtractFolderCertBegin.UseVisualStyleBackColor = true;
            this.btnExtractFolderCertBegin.Click += new System.EventHandler(this.btnExtractFolderCertBegin_Click);
            // 
            // btnExtractPvkSelectFiles
            // 
            this.btnExtractPvkSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractPvkSelectFiles.Location = new System.Drawing.Point(131, 19);
            this.btnExtractPvkSelectFiles.Name = "btnExtractPvkSelectFiles";
            this.btnExtractPvkSelectFiles.Size = new System.Drawing.Size(100, 23);
            this.btnExtractPvkSelectFiles.TabIndex = 3;
            this.btnExtractPvkSelectFiles.Text = "Select PVK files...";
            this.btnExtractPvkSelectFiles.UseVisualStyleBackColor = true;
            this.btnExtractPvkSelectFiles.Click += new System.EventHandler(this.btnExtractPvkSelectFiles_Click);
            // 
            // cbExtractDeleteFiles
            // 
            this.cbExtractDeleteFiles.AutoSize = true;
            this.cbExtractDeleteFiles.Location = new System.Drawing.Point(154, 46);
            this.cbExtractDeleteFiles.Name = "cbExtractDeleteFiles";
            this.cbExtractDeleteFiles.Size = new System.Drawing.Size(186, 17);
            this.cbExtractDeleteFiles.TabIndex = 1;
            this.cbExtractDeleteFiles.Text = "Delete source files after extraction";
            this.cbExtractDeleteFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbExtractDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // btnExtractXmlSelectFiles
            // 
            this.btnExtractXmlSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractXmlSelectFiles.Location = new System.Drawing.Point(28, 19);
            this.btnExtractXmlSelectFiles.Name = "btnExtractXmlSelectFiles";
            this.btnExtractXmlSelectFiles.Size = new System.Drawing.Size(100, 23);
            this.btnExtractXmlSelectFiles.TabIndex = 2;
            this.btnExtractXmlSelectFiles.Text = "Select XML files...";
            this.btnExtractXmlSelectFiles.UseVisualStyleBackColor = true;
            this.btnExtractXmlSelectFiles.Click += new System.EventHandler(this.btnExtractXmlSelectFiles_Click);
            // 
            // groupExtractFromStore
            // 
            this.groupExtractFromStore.Controls.Add(this.panelExtractKeystoreCombo);
            this.groupExtractFromStore.Controls.Add(this.cbExtractAllKeystore);
            this.groupExtractFromStore.Controls.Add(this.btnExtractKeystore);
            this.groupExtractFromStore.Location = new System.Drawing.Point(18, 19);
            this.groupExtractFromStore.Name = "groupExtractFromStore";
            this.groupExtractFromStore.Size = new System.Drawing.Size(576, 47);
            this.groupExtractFromStore.TabIndex = 3;
            this.groupExtractFromStore.TabStop = false;
            this.groupExtractFromStore.Text = "From a certificate store";
            // 
            // panelExtractKeystoreCombo
            // 
            this.panelExtractKeystoreCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExtractKeystoreCombo.Controls.Add(this.comboExtractKeystoreName);
            this.panelExtractKeystoreCombo.Controls.Add(this.comboExtractKeystoreLocation);
            this.panelExtractKeystoreCombo.Location = new System.Drawing.Point(153, 12);
            this.panelExtractKeystoreCombo.Name = "panelExtractKeystoreCombo";
            this.panelExtractKeystoreCombo.Size = new System.Drawing.Size(310, 32);
            this.panelExtractKeystoreCombo.TabIndex = 2;
            // 
            // comboExtractKeystoreName
            // 
            this.comboExtractKeystoreName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboExtractKeystoreName.FormattingEnabled = true;
            this.comboExtractKeystoreName.Items.AddRange(new object[] {
            "AddressBook",
            "AuthRoot",
            "CertificateAuthority",
            "Disallowed",
            "My",
            "Root",
            "TrustedPeople",
            "TrustedPublisher"});
            this.comboExtractKeystoreName.Location = new System.Drawing.Point(144, 5);
            this.comboExtractKeystoreName.Name = "comboExtractKeystoreName";
            this.comboExtractKeystoreName.Size = new System.Drawing.Size(124, 21);
            this.comboExtractKeystoreName.TabIndex = 1;
            this.comboExtractKeystoreName.Text = "CertificateAuthority";
            // 
            // comboExtractKeystoreLocation
            // 
            this.comboExtractKeystoreLocation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboExtractKeystoreLocation.FormattingEnabled = true;
            this.comboExtractKeystoreLocation.Items.AddRange(new object[] {
            "CurrentUser",
            "LocalMachine"});
            this.comboExtractKeystoreLocation.Location = new System.Drawing.Point(32, 5);
            this.comboExtractKeystoreLocation.Name = "comboExtractKeystoreLocation";
            this.comboExtractKeystoreLocation.Size = new System.Drawing.Size(106, 21);
            this.comboExtractKeystoreLocation.TabIndex = 0;
            this.comboExtractKeystoreLocation.Text = "CurrentUser";
            // 
            // cbExtractAllKeystore
            // 
            this.cbExtractAllKeystore.AutoSize = true;
            this.cbExtractAllKeystore.Location = new System.Drawing.Point(30, 19);
            this.cbExtractAllKeystore.Name = "cbExtractAllKeystore";
            this.cbExtractAllKeystore.Size = new System.Drawing.Size(117, 17);
            this.cbExtractAllKeystore.TabIndex = 1;
            this.cbExtractAllKeystore.Text = "All certificate stores";
            this.cbExtractAllKeystore.UseVisualStyleBackColor = true;
            this.cbExtractAllKeystore.CheckedChanged += new System.EventHandler(this.cbExtractAllKeystore_CheckedChanged);
            // 
            // btnExtractKeystore
            // 
            this.btnExtractKeystore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtractKeystore.Location = new System.Drawing.Point(470, 15);
            this.btnExtractKeystore.Name = "btnExtractKeystore";
            this.btnExtractKeystore.Size = new System.Drawing.Size(100, 23);
            this.btnExtractKeystore.TabIndex = 0;
            this.btnExtractKeystore.Text = "Extract";
            this.btnExtractKeystore.UseVisualStyleBackColor = true;
            this.btnExtractKeystore.Click += new System.EventHandler(this.btnExtractKeystore_Click);
            // 
            // groupGenerateCryptoAPI
            // 
            this.groupGenerateCryptoAPI.Controls.Add(this.cbGenerateOnlyPrimes);
            this.groupGenerateCryptoAPI.Controls.Add(this.label4);
            this.groupGenerateCryptoAPI.Controls.Add(this.label3);
            this.groupGenerateCryptoAPI.Controls.Add(this.tbGenerateKeysize);
            this.groupGenerateCryptoAPI.Controls.Add(this.label2);
            this.groupGenerateCryptoAPI.Controls.Add(this.label1);
            this.groupGenerateCryptoAPI.Controls.Add(this.tbGenerateTimeout);
            this.groupGenerateCryptoAPI.Controls.Add(this.tbGenerateQuantity);
            this.groupGenerateCryptoAPI.Controls.Add(this.btnGenerateQuantity);
            this.groupGenerateCryptoAPI.Location = new System.Drawing.Point(18, 19);
            this.groupGenerateCryptoAPI.Name = "groupGenerateCryptoAPI";
            this.groupGenerateCryptoAPI.Size = new System.Drawing.Size(576, 72);
            this.groupGenerateCryptoAPI.TabIndex = 2;
            this.groupGenerateCryptoAPI.TabStop = false;
            this.groupGenerateCryptoAPI.Text = "Generate from Microsoft Cryptographic API";
            // 
            // cbGenerateOnlyPrimes
            // 
            this.cbGenerateOnlyPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGenerateOnlyPrimes.AutoSize = true;
            this.cbGenerateOnlyPrimes.Checked = true;
            this.cbGenerateOnlyPrimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGenerateOnlyPrimes.Location = new System.Drawing.Point(492, 44);
            this.cbGenerateOnlyPrimes.Name = "cbGenerateOnlyPrimes";
            this.cbGenerateOnlyPrimes.Size = new System.Drawing.Size(77, 17);
            this.cbGenerateOnlyPrimes.TabIndex = 8;
            this.cbGenerateOnlyPrimes.Text = "Only P && Q";
            this.cbGenerateOnlyPrimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbGenerateOnlyPrimes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "(seconds)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keysize:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbGenerateKeysize
            // 
            this.tbGenerateKeysize.Location = new System.Drawing.Point(76, 19);
            this.tbGenerateKeysize.Name = "tbGenerateKeysize";
            this.tbGenerateKeysize.Size = new System.Drawing.Size(53, 20);
            this.tbGenerateKeysize.TabIndex = 5;
            this.tbGenerateKeysize.Text = "2048";
            this.tbGenerateKeysize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Timeout:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbGenerateTimeout
            // 
            this.tbGenerateTimeout.Location = new System.Drawing.Point(202, 41);
            this.tbGenerateTimeout.Name = "tbGenerateTimeout";
            this.tbGenerateTimeout.Size = new System.Drawing.Size(53, 20);
            this.tbGenerateTimeout.TabIndex = 2;
            this.tbGenerateTimeout.Text = "3600";
            this.tbGenerateTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbGenerateQuantity
            // 
            this.tbGenerateQuantity.Location = new System.Drawing.Point(202, 19);
            this.tbGenerateQuantity.Name = "tbGenerateQuantity";
            this.tbGenerateQuantity.Size = new System.Drawing.Size(53, 20);
            this.tbGenerateQuantity.TabIndex = 1;
            this.tbGenerateQuantity.Text = "300";
            this.tbGenerateQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenerateQuantity
            // 
            this.btnGenerateQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateQuantity.Location = new System.Drawing.Point(470, 20);
            this.btnGenerateQuantity.Name = "btnGenerateQuantity";
            this.btnGenerateQuantity.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateQuantity.TabIndex = 0;
            this.btnGenerateQuantity.Text = "Generate";
            this.btnGenerateQuantity.UseVisualStyleBackColor = true;
            this.btnGenerateQuantity.Click += new System.EventHandler(this.btnGenerateQuantity_Click);
            // 
            // panelCancel
            // 
            this.panelCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCancel.BackColor = System.Drawing.Color.Transparent;
            this.panelCancel.Controls.Add(this.btnCancel);
            this.panelCancel.Location = new System.Drawing.Point(215, 152);
            this.panelCancel.Name = "panelCancel";
            this.panelCancel.Size = new System.Drawing.Size(192, 52);
            this.panelCancel.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 48);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Click here to cancel...";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.tbCancel_Click);
            // 
            // groupGenerate
            // 
            this.groupGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupGenerate.Controls.Add(this.groupGenerateOpenSSL);
            this.groupGenerate.Controls.Add(this.groupGenerateCryptoAPI);
            this.groupGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupGenerate.Location = new System.Drawing.Point(3, 173);
            this.groupGenerate.Name = "groupGenerate";
            this.groupGenerate.Size = new System.Drawing.Size(604, 194);
            this.groupGenerate.TabIndex = 6;
            this.groupGenerate.TabStop = false;
            this.groupGenerate.Text = "Generate keys";
            // 
            // groupGenerateOpenSSL
            // 
            this.groupGenerateOpenSSL.Controls.Add(this.btnGenerateOpenSSL);
            this.groupGenerateOpenSSL.Controls.Add(this.tbGenerateOpenSSLCommandText);
            this.groupGenerateOpenSSL.Enabled = false;
            this.groupGenerateOpenSSL.Location = new System.Drawing.Point(18, 97);
            this.groupGenerateOpenSSL.Name = "groupGenerateOpenSSL";
            this.groupGenerateOpenSSL.Size = new System.Drawing.Size(576, 83);
            this.groupGenerateOpenSSL.TabIndex = 3;
            this.groupGenerateOpenSSL.TabStop = false;
            this.groupGenerateOpenSSL.Text = "Open SSL via command line";
            // 
            // btnGenerateOpenSSL
            // 
            this.btnGenerateOpenSSL.Location = new System.Drawing.Point(385, 50);
            this.btnGenerateOpenSSL.Name = "btnGenerateOpenSSL";
            this.btnGenerateOpenSSL.Size = new System.Drawing.Size(185, 23);
            this.btnGenerateOpenSSL.TabIndex = 1;
            this.btnGenerateOpenSSL.Text = "Not implemented yet";
            this.btnGenerateOpenSSL.UseVisualStyleBackColor = true;
            // 
            // tbGenerateOpenSSLCommandText
            // 
            this.tbGenerateOpenSSLCommandText.Location = new System.Drawing.Point(14, 24);
            this.tbGenerateOpenSSLCommandText.Name = "tbGenerateOpenSSLCommandText";
            this.tbGenerateOpenSSLCommandText.Size = new System.Drawing.Size(555, 20);
            this.tbGenerateOpenSSLCommandText.TabIndex = 0;
            this.tbGenerateOpenSSLCommandText.Text = "OPENSSL.EXE GENRSA -OUT \"%OutputFilename%\" 1024";
            // 
            // groupAllControls
            // 
            this.groupAllControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAllControls.Controls.Add(this.groupGenerate);
            this.groupAllControls.Controls.Add(this.groupExtract);
            this.groupAllControls.Location = new System.Drawing.Point(12, 11);
            this.groupAllControls.Margin = new System.Windows.Forms.Padding(0);
            this.groupAllControls.Name = "groupAllControls";
            this.groupAllControls.Size = new System.Drawing.Size(610, 370);
            this.groupAllControls.TabIndex = 7;
            // 
            // cbExportOnlyPQ
            // 
            this.cbExportOnlyPQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportOnlyPQ.AutoSize = true;
            this.cbExportOnlyPQ.Location = new System.Drawing.Point(70, 46);
            this.cbExportOnlyPQ.Name = "cbExportOnlyPQ";
            this.cbExportOnlyPQ.Size = new System.Drawing.Size(77, 17);
            this.cbExportOnlyPQ.TabIndex = 9;
            this.cbExportOnlyPQ.Text = "Only P && Q";
            this.cbExportOnlyPQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbExportOnlyPQ.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 396);
            this.Controls.Add(this.groupAllControls);
            this.Controls.Add(this.panelCancel);
            this.MinimumSize = new System.Drawing.Size(650, 434);
            this.Name = "MainForm";
            this.Text = "Keygen analysis for bias";
            this.groupExtract.ResumeLayout(false);
            this.groupExtractFromFiles.ResumeLayout(false);
            this.groupExtractFromFiles.PerformLayout();
            this.groupExtractFromStore.ResumeLayout(false);
            this.groupExtractFromStore.PerformLayout();
            this.panelExtractKeystoreCombo.ResumeLayout(false);
            this.groupGenerateCryptoAPI.ResumeLayout(false);
            this.groupGenerateCryptoAPI.PerformLayout();
            this.panelCancel.ResumeLayout(false);
            this.groupGenerate.ResumeLayout(false);
            this.groupGenerateOpenSSL.ResumeLayout(false);
            this.groupGenerateOpenSSL.PerformLayout();
            this.groupAllControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupExtract;
        private System.Windows.Forms.Button btnExtractFolderCertBegin;
        private System.Windows.Forms.CheckBox cbExtractDeleteFiles;
        private System.Windows.Forms.GroupBox groupGenerateCryptoAPI;
        private System.Windows.Forms.TextBox tbGenerateQuantity;
        private System.Windows.Forms.Button btnGenerateQuantity;
        private System.Windows.Forms.TextBox tbGenerateTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGenerateKeysize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbGenerateOnlyPrimes;
        private System.Windows.Forms.GroupBox groupExtractFromStore;
        private System.Windows.Forms.Panel panelExtractKeystoreCombo;
        private System.Windows.Forms.CheckBox cbExtractAllKeystore;
        private System.Windows.Forms.Button btnExtractKeystore;
        private System.Windows.Forms.ComboBox comboExtractKeystoreName;
        private System.Windows.Forms.ComboBox comboExtractKeystoreLocation;
        private System.Windows.Forms.GroupBox groupExtractFromFiles;
        private System.Windows.Forms.Button btnExtractXmlSelectFiles;
        private System.Windows.Forms.Button btnExtractPvkSelectFiles;
        private System.Windows.Forms.Panel panelCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupGenerate;
        private System.Windows.Forms.GroupBox groupGenerateOpenSSL;
        private System.Windows.Forms.Button btnGenerateOpenSSL;
        private System.Windows.Forms.TextBox tbGenerateOpenSSLCommandText;
        private System.Windows.Forms.Panel groupAllControls;
        private System.Windows.Forms.CheckBox cbExportOnlyPQ;
    }
}

