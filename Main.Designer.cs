namespace DCIMRecomp
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.btnSrc = new System.Windows.Forms.Button();
            this.btnDest = new System.Windows.Forms.Button();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCompressionLevel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBigImages = new System.Windows.Forms.CheckBox();
            this.bntImages = new System.Windows.Forms.CheckBox();
            this.btnMovies = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSizeBefore = new System.Windows.Forms.Label();
            this.lblSizeAfter = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStop = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSubDir = new System.Windows.Forms.CheckBox();
            this.btnWebSite = new System.Windows.Forms.LinkLabel();
            this.process2 = new System.Diagnostics.Process();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveOriginals = new System.Windows.Forms.CheckBox();
            this.btnShowAdvancedOptions = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSrcSpace = new System.Windows.Forms.Label();
            this.lblDestSpace = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.btnSaveParams = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnReorganise = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dossier source :";
            this.toolTip1.SetToolTip(this.label1, "L\'emplacement où se trouvent vos photos");
            // 
            // txtSrc
            // 
            this.txtSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrc.Location = new System.Drawing.Point(108, 212);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(256, 20);
            this.txtSrc.TabIndex = 7;
            this.txtSrc.TextChanged += new System.EventHandler(this.txtSrc_TextChanged);
            // 
            // btnSrc
            // 
            this.btnSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrc.Location = new System.Drawing.Point(370, 212);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(27, 23);
            this.btnSrc.TabIndex = 8;
            this.btnSrc.Text = "...";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // btnDest
            // 
            this.btnDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDest.Location = new System.Drawing.Point(370, 281);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(27, 23);
            this.btnDest.TabIndex = 12;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // txtDest
            // 
            this.txtDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDest.Location = new System.Drawing.Point(108, 284);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(256, 20);
            this.txtDest.TabIndex = 11;
            this.txtDest.TextChanged += new System.EventHandler(this.txtDest_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dossier destination :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCompressionLevel);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBigImages);
            this.groupBox1.Location = new System.Drawing.Point(12, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lblCompressionLevel
            // 
            this.lblCompressionLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompressionLevel.Location = new System.Drawing.Point(13, 79);
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            this.lblCompressionLevel.Size = new System.Drawing.Size(35, 13);
            this.lblCompressionLevel.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(145, 43);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 25;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(201, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 75;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Qualité de recompression (100 = sans perte)";
            // 
            // btnBigImages
            // 
            this.btnBigImages.AutoSize = true;
            this.btnBigImages.Location = new System.Drawing.Point(15, 23);
            this.btnBigImages.Name = "btnBigImages";
            this.btnBigImages.Size = new System.Drawing.Size(231, 17);
            this.btnBigImages.TabIndex = 14;
            this.btnBigImages.Text = "Ne traiter que les images de plus de 200 Ko";
            this.btnBigImages.UseVisualStyleBackColor = true;
            // 
            // bntImages
            // 
            this.bntImages.AutoSize = true;
            this.bntImages.Location = new System.Drawing.Point(18, 334);
            this.bntImages.Name = "bntImages";
            this.bntImages.Size = new System.Drawing.Size(79, 17);
            this.bntImages.TabIndex = 13;
            this.bntImages.Text = "Les images";
            this.bntImages.UseVisualStyleBackColor = true;
            this.bntImages.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnMovies
            // 
            this.btnMovies.AutoSize = true;
            this.btnMovies.Location = new System.Drawing.Point(12, 449);
            this.btnMovies.Name = "btnMovies";
            this.btnMovies.Size = new System.Drawing.Size(169, 17);
            this.btnMovies.TabIndex = 16;
            this.btnMovies.Text = "Convertir les .MOV an .AVI  in ";
            this.btnMovies.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(385, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(27, 79);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Démarrer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8739360";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // lblSizeBefore
            // 
            this.lblSizeBefore.AutoSize = true;
            this.lblSizeBefore.Location = new System.Drawing.Point(12, 146);
            this.lblSizeBefore.Name = "lblSizeBefore";
            this.lblSizeBefore.Size = new System.Drawing.Size(150, 13);
            this.lblSizeBefore.TabIndex = 14;
            this.lblSizeBefore.Tag = "Taille avant conversion : {0} Mo";
            this.lblSizeBefore.Text = "Taille avant conversion : 0 Mo";
            // 
            // lblSizeAfter
            // 
            this.lblSizeAfter.AutoSize = true;
            this.lblSizeAfter.Location = new System.Drawing.Point(199, 146);
            this.lblSizeAfter.Name = "lblSizeAfter";
            this.lblSizeAfter.Size = new System.Drawing.Size(149, 13);
            this.lblSizeAfter.TabIndex = 15;
            this.lblSizeAfter.Tag = "Taille après conversion : {0} Mo";
            this.lblSizeAfter.Text = "Taille après conversion : 0 Mo";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(108, 79);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stopper";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnSubDir
            // 
            this.btnSubDir.AutoSize = true;
            this.btnSubDir.Location = new System.Drawing.Point(108, 238);
            this.btnSubDir.Name = "btnSubDir";
            this.btnSubDir.Size = new System.Drawing.Size(151, 17);
            this.btnSubDir.TabIndex = 9;
            this.btnSubDir.Text = "Inclure les sous répertoires";
            this.btnSubDir.UseVisualStyleBackColor = true;
            // 
            // btnWebSite
            // 
            this.btnWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebSite.AutoSize = true;
            this.btnWebSite.Location = new System.Drawing.Point(250, 97);
            this.btnWebSite.Name = "btnWebSite";
            this.btnWebSite.Size = new System.Drawing.Size(147, 13);
            this.btnWebSite.TabIndex = 5;
            this.btnWebSite.TabStop = true;
            this.btnWebSite.Text = "http://DCIMPRecomp.m4f.eu";
            this.btnWebSite.Visible = false;
            this.btnWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnWebSite_LinkClicked);
            // 
            // process2
            // 
            this.process2.StartInfo.Domain = "";
            this.process2.StartInfo.FileName = "http://dcimrecomp.m4f.eu";
            this.process2.StartInfo.LoadUserProfile = false;
            this.process2.StartInfo.Password = null;
            this.process2.StartInfo.StandardErrorEncoding = null;
            this.process2.StartInfo.StandardOutputEncoding = null;
            this.process2.StartInfo.UserName = "";
            this.process2.SynchronizingObject = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "1) Connectez votre appareil photo ou insérez votre carte mémoire";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "2) Donnez un nom pour ces photos (facultatif)";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(233, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 20);
            this.txtName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "3) Appuyez sur le bouton démarrer";
            // 
            // btnRemoveOriginals
            // 
            this.btnRemoveOriginals.AutoSize = true;
            this.btnRemoveOriginals.Location = new System.Drawing.Point(266, 239);
            this.btnRemoveOriginals.Name = "btnRemoveOriginals";
            this.btnRemoveOriginals.Size = new System.Drawing.Size(134, 17);
            this.btnRemoveOriginals.TabIndex = 10;
            this.btnRemoveOriginals.Text = "Supprimer les originaux";
            this.btnRemoveOriginals.UseVisualStyleBackColor = true;
            // 
            // btnShowAdvancedOptions
            // 
            this.btnShowAdvancedOptions.AutoSize = true;
            this.btnShowAdvancedOptions.Location = new System.Drawing.Point(15, 179);
            this.btnShowAdvancedOptions.Name = "btnShowAdvancedOptions";
            this.btnShowAdvancedOptions.Size = new System.Drawing.Size(159, 17);
            this.btnShowAdvancedOptions.TabIndex = 6;
            this.btnShowAdvancedOptions.Text = "Afficher les options avancés";
            this.btnShowAdvancedOptions.UseVisualStyleBackColor = true;
            this.btnShowAdvancedOptions.CheckedChanged += new System.EventHandler(this.btnShowAdvancedOptions_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(291, 79);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Faire un don (paypal)";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Espace disponible sur la source :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Espace disponible sur la destination :";
            // 
            // lblSrcSpace
            // 
            this.lblSrcSpace.AutoSize = true;
            this.lblSrcSpace.Location = new System.Drawing.Point(183, 258);
            this.lblSrcSpace.Name = "lblSrcSpace";
            this.lblSrcSpace.Size = new System.Drawing.Size(0, 13);
            this.lblSrcSpace.TabIndex = 26;
            // 
            // lblDestSpace
            // 
            this.lblDestSpace.AutoSize = true;
            this.lblDestSpace.Location = new System.Drawing.Point(200, 313);
            this.lblDestSpace.Name = "lblDestSpace";
            this.lblDestSpace.Size = new System.Drawing.Size(0, 13);
            this.lblDestSpace.TabIndex = 27;
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.ForeColor = System.Drawing.Color.Red;
            this.lblFinished.Location = new System.Drawing.Point(147, 165);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(114, 13);
            this.lblFinished.TabIndex = 28;
            this.lblFinished.Text = "Le transfert est terminé";
            this.lblFinished.Visible = false;
            // 
            // btnSaveParams
            // 
            this.btnSaveParams.Location = new System.Drawing.Point(266, 487);
            this.btnSaveParams.Name = "btnSaveParams";
            this.btnSaveParams.Size = new System.Drawing.Size(134, 23);
            this.btnSaveParams.TabIndex = 29;
            this.btnSaveParams.Text = "Sauver les paramètres";
            this.btnSaveParams.UseVisualStyleBackColor = true;
            this.btnSaveParams.Click += new System.EventHandler(this.btnSaveParams_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ".mp4",
            ".avi"});
            this.comboBox1.Location = new System.Drawing.Point(186, 447);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // btnReorganise
            // 
            this.btnReorganise.AutoSize = true;
            this.btnReorganise.Location = new System.Drawing.Point(12, 473);
            this.btnReorganise.Name = "btnReorganise";
            this.btnReorganise.Size = new System.Drawing.Size(140, 17);
            this.btnReorganise.TabIndex = 31;
            this.btnReorganise.Text = "Organiser en YYYY/MM";
            this.btnReorganise.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 522);
            this.Controls.Add(this.btnReorganise);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSaveParams);
            this.Controls.Add(this.lblFinished);
            this.Controls.Add(this.lblDestSpace);
            this.Controls.Add(this.lblSrcSpace);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnShowAdvancedOptions);
            this.Controls.Add(this.btnRemoveOriginals);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnWebSite);
            this.Controls.Add(this.btnSubDir);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblSizeAfter);
            this.Controls.Add(this.lblSizeBefore);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnMovies);
            this.Controls.Add(this.bntImages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDest);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 100);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "DCIMRecomp version 1.0 -- version {0}.{1} disponible";
            this.Text = "DCIMRecomp version 1.0 - logiciel gratuit";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox btnBigImages;
        private System.Windows.Forms.CheckBox bntImages;
        private System.Windows.Forms.Label lblCompressionLevel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox btnMovies;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStart;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblSizeBefore;
        private System.Windows.Forms.Label lblSizeAfter;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox btnSubDir;
        private System.Windows.Forms.LinkLabel btnWebSite;
        private System.Diagnostics.Process process2;
        private System.Windows.Forms.CheckBox btnRemoveOriginals;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox btnShowAdvancedOptions;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblDestSpace;
        private System.Windows.Forms.Label lblSrcSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFinished;
        private System.Windows.Forms.Button btnSaveParams;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox btnReorganise;
    }
}

