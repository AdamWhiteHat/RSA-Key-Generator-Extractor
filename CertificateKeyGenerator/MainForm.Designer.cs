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
            this.groupControls = new System.Windows.Forms.GroupBox();
            this.groupBoxXml = new System.Windows.Forms.GroupBox();
            this.buttonPvkSelectFiles = new System.Windows.Forms.Button();
            this.buttonXmlSelectFiles = new System.Windows.Forms.Button();
            this.radioXmlPQ = new System.Windows.Forms.RadioButton();
            this.radioXmlModulus = new System.Windows.Forms.RadioButton();
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.panelStoreCombo = new System.Windows.Forms.Panel();
            this.comboStoreName = new System.Windows.Forms.ComboBox();
            this.comboStoreLocation = new System.Windows.Forms.ComboBox();
            this.cbStoreAll = new System.Windows.Forms.CheckBox();
            this.btnStoreExtract = new System.Windows.Forms.Button();
            this.groupBoxGenerate = new System.Windows.Forms.GroupBox();
            this.cbGenerateOnlyPrimes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGenerateKeysize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGenerateTimeout = new System.Windows.Forms.TextBox();
            this.tbGenerateQuantity = new System.Windows.Forms.TextBox();
            this.btnGenerateQuantity = new System.Windows.Forms.Button();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.cbFolderPrivateKeys = new System.Windows.Forms.CheckBox();
            this.btnFolderCertBegin = new System.Windows.Forms.Button();
            this.tbFolderSearchPath = new System.Windows.Forms.TextBox();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.cbFolderDeleteFiles = new System.Windows.Forms.CheckBox();
            this.cbXmlPkvDeleteFiles = new System.Windows.Forms.CheckBox();
            this.groupControls.SuspendLayout();
            this.groupBoxXml.SuspendLayout();
            this.groupBoxStore.SuspendLayout();
            this.panelStoreCombo.SuspendLayout();
            this.groupBoxGenerate.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControls
            // 
            this.groupControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControls.Controls.Add(this.groupBoxXml);
            this.groupControls.Controls.Add(this.groupBoxStore);
            this.groupControls.Controls.Add(this.groupBoxGenerate);
            this.groupControls.Controls.Add(this.groupBoxFolder);
            this.groupControls.Location = new System.Drawing.Point(12, 12);
            this.groupControls.Name = "groupControls";
            this.groupControls.Size = new System.Drawing.Size(610, 312);
            this.groupControls.TabIndex = 0;
            this.groupControls.TabStop = false;
            this.groupControls.Text = "Extract public & private keys";
            // 
            // groupBoxXml
            // 
            this.groupBoxXml.Controls.Add(this.cbXmlPkvDeleteFiles);
            this.groupBoxXml.Controls.Add(this.buttonPvkSelectFiles);
            this.groupBoxXml.Controls.Add(this.buttonXmlSelectFiles);
            this.groupBoxXml.Controls.Add(this.radioXmlPQ);
            this.groupBoxXml.Controls.Add(this.radioXmlModulus);
            this.groupBoxXml.Location = new System.Drawing.Point(18, 228);
            this.groupBoxXml.Name = "groupBoxXml";
            this.groupBoxXml.Size = new System.Drawing.Size(576, 71);
            this.groupBoxXml.TabIndex = 4;
            this.groupBoxXml.TabStop = false;
            this.groupBoxXml.Text = "From <RSAKeyValue> XML files or PVK files";
            // 
            // buttonPvkSelectFiles
            // 
            this.buttonPvkSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPvkSelectFiles.Location = new System.Drawing.Point(470, 40);
            this.buttonPvkSelectFiles.Name = "buttonPvkSelectFiles";
            this.buttonPvkSelectFiles.Size = new System.Drawing.Size(100, 23);
            this.buttonPvkSelectFiles.TabIndex = 3;
            this.buttonPvkSelectFiles.Text = "Select PVK files...";
            this.buttonPvkSelectFiles.UseVisualStyleBackColor = true;
            this.buttonPvkSelectFiles.Click += new System.EventHandler(this.buttonPvkSelectFiles_Click);
            // 
            // buttonXmlSelectFiles
            // 
            this.buttonXmlSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXmlSelectFiles.Location = new System.Drawing.Point(470, 15);
            this.buttonXmlSelectFiles.Name = "buttonXmlSelectFiles";
            this.buttonXmlSelectFiles.Size = new System.Drawing.Size(100, 23);
            this.buttonXmlSelectFiles.TabIndex = 2;
            this.buttonXmlSelectFiles.Text = "Select XML files...";
            this.buttonXmlSelectFiles.UseVisualStyleBackColor = true;
            this.buttonXmlSelectFiles.Click += new System.EventHandler(this.buttonXmlSelectFiles_Click);
            // 
            // radioXmlPQ
            // 
            this.radioXmlPQ.AutoSize = true;
            this.radioXmlPQ.Checked = true;
            this.radioXmlPQ.Location = new System.Drawing.Point(64, 38);
            this.radioXmlPQ.Name = "radioXmlPQ";
            this.radioXmlPQ.Size = new System.Drawing.Size(52, 17);
            this.radioXmlPQ.TabIndex = 1;
            this.radioXmlPQ.TabStop = true;
            this.radioXmlPQ.Text = "P && Q";
            this.radioXmlPQ.UseVisualStyleBackColor = true;
            // 
            // radioXmlModulus
            // 
            this.radioXmlModulus.AutoSize = true;
            this.radioXmlModulus.Location = new System.Drawing.Point(64, 19);
            this.radioXmlModulus.Name = "radioXmlModulus";
            this.radioXmlModulus.Size = new System.Drawing.Size(65, 17);
            this.radioXmlModulus.TabIndex = 0;
            this.radioXmlModulus.TabStop = true;
            this.radioXmlModulus.Text = "Modulus";
            this.radioXmlModulus.UseVisualStyleBackColor = true;
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.panelStoreCombo);
            this.groupBoxStore.Controls.Add(this.cbStoreAll);
            this.groupBoxStore.Controls.Add(this.btnStoreExtract);
            this.groupBoxStore.Location = new System.Drawing.Point(18, 19);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(576, 47);
            this.groupBoxStore.TabIndex = 3;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "From a certificate store";
            // 
            // panelStoreCombo
            // 
            this.panelStoreCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStoreCombo.Controls.Add(this.comboStoreName);
            this.panelStoreCombo.Controls.Add(this.comboStoreLocation);
            this.panelStoreCombo.Location = new System.Drawing.Point(153, 12);
            this.panelStoreCombo.Name = "panelStoreCombo";
            this.panelStoreCombo.Size = new System.Drawing.Size(310, 32);
            this.panelStoreCombo.TabIndex = 2;
            // 
            // comboStoreName
            // 
            this.comboStoreName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboStoreName.FormattingEnabled = true;
            this.comboStoreName.Items.AddRange(new object[] {
            "AddressBook",
            "AuthRoot",
            "CertificateAuthority",
            "Disallowed",
            "My",
            "Root",
            "TrustedPeople",
            "TrustedPublisher"});
            this.comboStoreName.Location = new System.Drawing.Point(144, 5);
            this.comboStoreName.Name = "comboStoreName";
            this.comboStoreName.Size = new System.Drawing.Size(124, 21);
            this.comboStoreName.TabIndex = 1;
            this.comboStoreName.Text = "CertificateAuthority";
            // 
            // comboStoreLocation
            // 
            this.comboStoreLocation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboStoreLocation.FormattingEnabled = true;
            this.comboStoreLocation.Items.AddRange(new object[] {
            "CurrentUser",
            "LocalMachine"});
            this.comboStoreLocation.Location = new System.Drawing.Point(32, 5);
            this.comboStoreLocation.Name = "comboStoreLocation";
            this.comboStoreLocation.Size = new System.Drawing.Size(106, 21);
            this.comboStoreLocation.TabIndex = 0;
            this.comboStoreLocation.Text = "CurrentUser";
            // 
            // cbStoreAll
            // 
            this.cbStoreAll.AutoSize = true;
            this.cbStoreAll.Location = new System.Drawing.Point(30, 19);
            this.cbStoreAll.Name = "cbStoreAll";
            this.cbStoreAll.Size = new System.Drawing.Size(117, 17);
            this.cbStoreAll.TabIndex = 1;
            this.cbStoreAll.Text = "All certificate stores";
            this.cbStoreAll.UseVisualStyleBackColor = true;
            this.cbStoreAll.CheckedChanged += new System.EventHandler(this.cbStoreAll_CheckedChanged);
            // 
            // btnStoreExtract
            // 
            this.btnStoreExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoreExtract.Location = new System.Drawing.Point(470, 15);
            this.btnStoreExtract.Name = "btnStoreExtract";
            this.btnStoreExtract.Size = new System.Drawing.Size(100, 23);
            this.btnStoreExtract.TabIndex = 0;
            this.btnStoreExtract.Text = "Extract";
            this.btnStoreExtract.UseVisualStyleBackColor = true;
            this.btnStoreExtract.Click += new System.EventHandler(this.btnStoreExtract_Click);
            // 
            // groupBoxGenerate
            // 
            this.groupBoxGenerate.Controls.Add(this.cbGenerateOnlyPrimes);
            this.groupBoxGenerate.Controls.Add(this.label4);
            this.groupBoxGenerate.Controls.Add(this.label3);
            this.groupBoxGenerate.Controls.Add(this.tbGenerateKeysize);
            this.groupBoxGenerate.Controls.Add(this.label2);
            this.groupBoxGenerate.Controls.Add(this.label1);
            this.groupBoxGenerate.Controls.Add(this.tbGenerateTimeout);
            this.groupBoxGenerate.Controls.Add(this.tbGenerateQuantity);
            this.groupBoxGenerate.Controls.Add(this.btnGenerateQuantity);
            this.groupBoxGenerate.Location = new System.Drawing.Point(18, 150);
            this.groupBoxGenerate.Name = "groupBoxGenerate";
            this.groupBoxGenerate.Size = new System.Drawing.Size(576, 72);
            this.groupBoxGenerate.TabIndex = 2;
            this.groupBoxGenerate.TabStop = false;
            this.groupBoxGenerate.Text = "Generate from Microsoft Cryptographic API";
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
            // groupBoxFolder
            // 
            this.groupBoxFolder.Controls.Add(this.cbFolderPrivateKeys);
            this.groupBoxFolder.Controls.Add(this.btnFolderCertBegin);
            this.groupBoxFolder.Controls.Add(this.tbFolderSearchPath);
            this.groupBoxFolder.Controls.Add(this.btnFolderSelect);
            this.groupBoxFolder.Controls.Add(this.cbFolderDeleteFiles);
            this.groupBoxFolder.Location = new System.Drawing.Point(18, 72);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Size = new System.Drawing.Size(576, 72);
            this.groupBoxFolder.TabIndex = 1;
            this.groupBoxFolder.TabStop = false;
            this.groupBoxFolder.Text = "From a folder containing certificate (*.cer) or private key (*.pvk) files";
            // 
            // cbFolderPrivateKeys
            // 
            this.cbFolderPrivateKeys.AutoSize = true;
            this.cbFolderPrivateKeys.Checked = true;
            this.cbFolderPrivateKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFolderPrivateKeys.Location = new System.Drawing.Point(116, 43);
            this.cbFolderPrivateKeys.Name = "cbFolderPrivateKeys";
            this.cbFolderPrivateKeys.Size = new System.Drawing.Size(85, 17);
            this.cbFolderPrivateKeys.TabIndex = 4;
            this.cbFolderPrivateKeys.Text = "Private Keys";
            this.cbFolderPrivateKeys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFolderPrivateKeys.UseVisualStyleBackColor = true;
            // 
            // btnFolderCertBegin
            // 
            this.btnFolderCertBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolderCertBegin.Location = new System.Drawing.Point(470, 41);
            this.btnFolderCertBegin.Name = "btnFolderCertBegin";
            this.btnFolderCertBegin.Size = new System.Drawing.Size(100, 23);
            this.btnFolderCertBegin.TabIndex = 2;
            this.btnFolderCertBegin.Text = "Begin";
            this.btnFolderCertBegin.UseVisualStyleBackColor = true;
            this.btnFolderCertBegin.Click += new System.EventHandler(this.btnFolderCertBegin_Click);
            // 
            // tbFolderSearchPath
            // 
            this.tbFolderSearchPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolderSearchPath.Location = new System.Drawing.Point(112, 21);
            this.tbFolderSearchPath.Name = "tbFolderSearchPath";
            this.tbFolderSearchPath.ReadOnly = true;
            this.tbFolderSearchPath.Size = new System.Drawing.Size(458, 20);
            this.tbFolderSearchPath.TabIndex = 2;
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Location = new System.Drawing.Point(6, 19);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(100, 23);
            this.btnFolderSelect.TabIndex = 0;
            this.btnFolderSelect.Text = "Select a folder...";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // cbFolderDeleteFiles
            // 
            this.cbFolderDeleteFiles.AutoSize = true;
            this.cbFolderDeleteFiles.Location = new System.Drawing.Point(206, 43);
            this.cbFolderDeleteFiles.Name = "cbFolderDeleteFiles";
            this.cbFolderDeleteFiles.Size = new System.Drawing.Size(102, 17);
            this.cbFolderDeleteFiles.TabIndex = 1;
            this.cbFolderDeleteFiles.Text = "Delete files after";
            this.cbFolderDeleteFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFolderDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // cbXmlPkvDeleteFiles
            // 
            this.cbXmlPkvDeleteFiles.AutoSize = true;
            this.cbXmlPkvDeleteFiles.Checked = true;
            this.cbXmlPkvDeleteFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbXmlPkvDeleteFiles.Location = new System.Drawing.Point(361, 44);
            this.cbXmlPkvDeleteFiles.Name = "cbXmlPkvDeleteFiles";
            this.cbXmlPkvDeleteFiles.Size = new System.Drawing.Size(102, 17);
            this.cbXmlPkvDeleteFiles.TabIndex = 4;
            this.cbXmlPkvDeleteFiles.Text = "Delete files after";
            this.cbXmlPkvDeleteFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbXmlPkvDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 336);
            this.Controls.Add(this.groupControls);
            this.MinimumSize = new System.Drawing.Size(650, 365);
            this.Name = "MainForm";
            this.Text = "Factoring RSA keys through generation";
            this.groupControls.ResumeLayout(false);
            this.groupBoxXml.ResumeLayout(false);
            this.groupBoxXml.PerformLayout();
            this.groupBoxStore.ResumeLayout(false);
            this.groupBoxStore.PerformLayout();
            this.panelStoreCombo.ResumeLayout(false);
            this.groupBoxGenerate.ResumeLayout(false);
            this.groupBoxGenerate.PerformLayout();
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupControls;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private System.Windows.Forms.Button btnFolderCertBegin;
        private System.Windows.Forms.TextBox tbFolderSearchPath;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.CheckBox cbFolderDeleteFiles;
        private System.Windows.Forms.GroupBox groupBoxGenerate;
        private System.Windows.Forms.TextBox tbGenerateQuantity;
        private System.Windows.Forms.Button btnGenerateQuantity;
        private System.Windows.Forms.TextBox tbGenerateTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGenerateKeysize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbGenerateOnlyPrimes;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.Panel panelStoreCombo;
        private System.Windows.Forms.CheckBox cbStoreAll;
        private System.Windows.Forms.Button btnStoreExtract;
        private System.Windows.Forms.ComboBox comboStoreName;
        private System.Windows.Forms.ComboBox comboStoreLocation;
        private System.Windows.Forms.GroupBox groupBoxXml;
        private System.Windows.Forms.RadioButton radioXmlPQ;
        private System.Windows.Forms.RadioButton radioXmlModulus;
        private System.Windows.Forms.Button buttonXmlSelectFiles;
        private System.Windows.Forms.Button buttonPvkSelectFiles;
        private System.Windows.Forms.CheckBox cbFolderPrivateKeys;
        private System.Windows.Forms.CheckBox cbXmlPkvDeleteFiles;
    }
}

