namespace UTCompress
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblUccExe = new System.Windows.Forms.Label();
            this.tbUccExePath = new System.Windows.Forms.TextBox();
            this.btnBrowseUccExe = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colStat = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompress = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.openFileDialogUccExe = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFiles = new System.Windows.Forms.OpenFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.removeAllFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new UTCompress.Win7Progress.Windows7ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUccExe
            // 
            this.lblUccExe.AutoSize = true;
            this.lblUccExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUccExe.Location = new System.Drawing.Point(8, 9);
            this.lblUccExe.Name = "lblUccExe";
            this.lblUccExe.Size = new System.Drawing.Size(56, 17);
            this.lblUccExe.TabIndex = 0;
            this.lblUccExe.Text = "ucc.exe";
            // 
            // tbUccExePath
            // 
            this.tbUccExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUccExePath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbUccExePath.Location = new System.Drawing.Point(70, 9);
            this.tbUccExePath.Name = "tbUccExePath";
            this.tbUccExePath.ReadOnly = true;
            this.tbUccExePath.Size = new System.Drawing.Size(362, 20);
            this.tbUccExePath.TabIndex = 1;
            // 
            // btnBrowseUccExe
            // 
            this.btnBrowseUccExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseUccExe.Location = new System.Drawing.Point(438, 8);
            this.btnBrowseUccExe.Name = "btnBrowseUccExe";
            this.btnBrowseUccExe.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseUccExe.TabIndex = 2;
            this.btnBrowseUccExe.Text = "Browse";
            this.btnBrowseUccExe.UseVisualStyleBackColor = true;
            this.btnBrowseUccExe.Click += new System.EventHandler(this.btnBrowseUccExe_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStat,
            this.colFile,
            this.colCompress});
            this.dataGridView.Location = new System.Drawing.Point(15, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(498, 248);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseClick);
            // 
            // colStat
            // 
            this.colStat.FillWeight = 35F;
            this.colStat.HeaderText = "State";
            this.colStat.Name = "colStat";
            this.colStat.ReadOnly = true;
            this.colStat.Width = 35;
            // 
            // colFile
            // 
            this.colFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFile.HeaderText = "File";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            // 
            // colCompress
            // 
            this.colCompress.HeaderText = "Compress type";
            this.colCompress.Items.AddRange(new object[] {
            "Compress",
            "Decompress"});
            this.colCompress.Name = "colCompress";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(15, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add files";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(133, 333);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(110, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAll.Location = new System.Drawing.Point(249, 333);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "Remove all";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // openFileDialogUccExe
            // 
            this.openFileDialogUccExe.FileName = "ucc.exe";
            this.openFileDialogUccExe.Filter = "ucc.exe|ucc.exe";
            this.openFileDialogUccExe.Title = "Set ucc.exe file!";
            // 
            // openFileDialogFiles
            // 
            this.openFileDialogFiles.Filter = resources.GetString("openFileDialogFiles.Filter");
            this.openFileDialogFiles.Multiselect = true;
            this.openFileDialogFiles.Title = "Select UT files";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(403, 333);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start process";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.removeSelectedFilesToolStripMenuItem,
            this.toolStripSeparator,
            this.removeAllFileToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(212, 76);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::UTCompress.Properties.Resources.add;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addFilesToolStripMenuItem.Text = "Add files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // removeSelectedFilesToolStripMenuItem
            // 
            this.removeSelectedFilesToolStripMenuItem.Image = global::UTCompress.Properties.Resources.delete;
            this.removeSelectedFilesToolStripMenuItem.Name = "removeSelectedFilesToolStripMenuItem";
            this.removeSelectedFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeSelectedFilesToolStripMenuItem.Text = "Remove selected files";
            this.removeSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(208, 6);
            // 
            // removeAllFileToolStripMenuItem
            // 
            this.removeAllFileToolStripMenuItem.Image = global::UTCompress.Properties.Resources.delete;
            this.removeAllFileToolStripMenuItem.Name = "removeAllFileToolStripMenuItem";
            this.removeAllFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.removeAllFileToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeAllFileToolStripMenuItem.Text = "Remove all file";
            this.removeAllFileToolStripMenuItem.Click += new System.EventHandler(this.removeAllFileToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ContainerControl = this;
            this.progressBar.Location = new System.Drawing.Point(15, 302);
            this.progressBar.MarqueeAnimationSpeed = 20;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(498, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 368);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnBrowseUccExe);
            this.Controls.Add(this.tbUccExePath);
            this.Controls.Add(this.lblUccExe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(541, 406);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UT Compress by Sektor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUccExe;
        private System.Windows.Forms.TextBox tbUccExePath;
        private System.Windows.Forms.Button btnBrowseUccExe;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.OpenFileDialog openFileDialogUccExe;
        private System.Windows.Forms.OpenFileDialog openFileDialogFiles;
        private System.Windows.Forms.Button btnStart;
        //private System.Windows.Forms.ProgressBar progressBar;
        private Win7Progress.Windows7ProgressBar progressBar;
        private System.Windows.Forms.DataGridViewImageColumn colStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCompress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    }
}

