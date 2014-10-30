namespace INN570_TranslationMemory
{
    partial class TranslationMemory
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
            this.TMGrid = new System.Windows.Forms.DataGridView();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmdExit = new System.Windows.Forms.Button();
            this.currentCulture = new System.Windows.Forms.Label();
            this.currentCultureLab = new System.Windows.Forms.Label();
            this.targetCulture = new System.Windows.Forms.Label();
            this.targetCultureLab = new System.Windows.Forms.Label();
            this.openResx = new System.Windows.Forms.Button();
            this.openTMFile = new System.Windows.Forms.Button();
            this.saveResxFile = new System.Windows.Forms.Button();
            this.saveCurrentTM = new System.Windows.Forms.Button();
            this.saveNewTM = new System.Windows.Forms.Button();
            this.bingTranslation = new System.Windows.Forms.Button();
            this.trsCulture = new System.Windows.Forms.ComboBox();
            this.transelateCultureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TMGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TMGrid
            // 
            this.TMGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TMGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.TMGrid.Location = new System.Drawing.Point(0, 0);
            this.TMGrid.Name = "TMGrid";
            this.TMGrid.RowTemplate.Height = 24;
            this.TMGrid.Size = new System.Drawing.Size(711, 231);
            this.TMGrid.TabIndex = 0;
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // cmdExit
            // 
            this.cmdExit.AutoSize = true;
            this.cmdExit.Location = new System.Drawing.Point(575, 243);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(124, 97);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // currentCulture
            // 
            this.currentCulture.AutoSize = true;
            this.currentCulture.Location = new System.Drawing.Point(26, 242);
            this.currentCulture.Name = "currentCulture";
            this.currentCulture.Size = new System.Drawing.Size(83, 13);
            this.currentCulture.TabIndex = 5;
            this.currentCulture.Text = "Current Culture :";
            // 
            // currentCultureLab
            // 
            this.currentCultureLab.AutoSize = true;
            this.currentCultureLab.Location = new System.Drawing.Point(155, 243);
            this.currentCultureLab.Name = "currentCultureLab";
            this.currentCultureLab.Size = new System.Drawing.Size(0, 13);
            this.currentCultureLab.TabIndex = 6;
            // 
            // targetCulture
            // 
            this.targetCulture.AutoSize = true;
            this.targetCulture.Location = new System.Drawing.Point(233, 243);
            this.targetCulture.Name = "targetCulture";
            this.targetCulture.Size = new System.Drawing.Size(80, 13);
            this.targetCulture.TabIndex = 7;
            this.targetCulture.Text = "Target Culture :";
            // 
            // targetCultureLab
            // 
            this.targetCultureLab.AutoSize = true;
            this.targetCultureLab.Location = new System.Drawing.Point(351, 242);
            this.targetCultureLab.Name = "targetCultureLab";
            this.targetCultureLab.Size = new System.Drawing.Size(0, 13);
            this.targetCultureLab.TabIndex = 8;
            // 
            // openResx
            // 
            this.openResx.Location = new System.Drawing.Point(19, 317);
            this.openResx.Name = "openResx";
            this.openResx.Size = new System.Drawing.Size(133, 23);
            this.openResx.TabIndex = 9;
            this.openResx.Text = "Select Resource File";
            this.openResx.UseVisualStyleBackColor = true;
            this.openResx.Click += new System.EventHandler(this.openResx_Click);
            // 
            // openTMFile
            // 
            this.openTMFile.Location = new System.Drawing.Point(284, 288);
            this.openTMFile.Name = "openTMFile";
            this.openTMFile.Size = new System.Drawing.Size(285, 23);
            this.openTMFile.TabIndex = 10;
            this.openTMFile.Text = "Look up TM";
            this.openTMFile.UseVisualStyleBackColor = true;
            this.openTMFile.Click += new System.EventHandler(this.openTMFile_Click);
            // 
            // saveResxFile
            // 
            this.saveResxFile.Location = new System.Drawing.Point(158, 317);
            this.saveResxFile.Name = "saveResxFile";
            this.saveResxFile.Size = new System.Drawing.Size(124, 23);
            this.saveResxFile.TabIndex = 11;
            this.saveResxFile.Text = "Save Resource File";
            this.saveResxFile.UseVisualStyleBackColor = true;
            this.saveResxFile.Click += new System.EventHandler(this.saveResxFile_Click);
            // 
            // saveCurrentTM
            // 
            this.saveCurrentTM.Location = new System.Drawing.Point(425, 317);
            this.saveCurrentTM.Name = "saveCurrentTM";
            this.saveCurrentTM.Size = new System.Drawing.Size(144, 23);
            this.saveCurrentTM.TabIndex = 12;
            this.saveCurrentTM.Text = "Save Current TM";
            this.saveCurrentTM.UseVisualStyleBackColor = true;
            this.saveCurrentTM.Click += new System.EventHandler(this.saveCurrentTM_Click);
            // 
            // saveNewTM
            // 
            this.saveNewTM.Location = new System.Drawing.Point(287, 317);
            this.saveNewTM.Name = "saveNewTM";
            this.saveNewTM.Size = new System.Drawing.Size(133, 23);
            this.saveNewTM.TabIndex = 13;
            this.saveNewTM.Text = "Save as a new TM";
            this.saveNewTM.UseVisualStyleBackColor = true;
            this.saveNewTM.Click += new System.EventHandler(this.saveNewTM_Click);
            // 
            // bingTranslation
            // 
            this.bingTranslation.Location = new System.Drawing.Point(19, 288);
            this.bingTranslation.Name = "bingTranslation";
            this.bingTranslation.Size = new System.Drawing.Size(263, 23);
            this.bingTranslation.TabIndex = 14;
            this.bingTranslation.Text = "The Bing (Translation)";
            this.bingTranslation.UseVisualStyleBackColor = true;
            this.bingTranslation.Click += new System.EventHandler(this.bingTranslation_Click);
            // 
            // trsCulture
            // 
            this.trsCulture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trsCulture.ForeColor = System.Drawing.SystemColors.WindowText;
            this.trsCulture.FormattingEnabled = true;
            this.trsCulture.Location = new System.Drawing.Point(127, 261);
            this.trsCulture.Name = "trsCulture";
            this.trsCulture.Size = new System.Drawing.Size(442, 21);
            this.trsCulture.TabIndex = 15;
            this.trsCulture.SelectedIndexChanged += new System.EventHandler(this.trsCulture_SelectedIndexChanged);
            // 
            // transelateCultureLabel
            // 
            this.transelateCultureLabel.AutoSize = true;
            this.transelateCultureLabel.Location = new System.Drawing.Point(25, 264);
            this.transelateCultureLabel.Name = "transelateCultureLabel";
            this.transelateCultureLabel.Size = new System.Drawing.Size(96, 13);
            this.transelateCultureLabel.TabIndex = 16;
            this.transelateCultureLabel.Text = "Transelate Culture:";
            // 
            // TranslationMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 343);
            this.Controls.Add(this.transelateCultureLabel);
            this.Controls.Add(this.trsCulture);
            this.Controls.Add(this.bingTranslation);
            this.Controls.Add(this.saveNewTM);
            this.Controls.Add(this.saveCurrentTM);
            this.Controls.Add(this.saveResxFile);
            this.Controls.Add(this.openTMFile);
            this.Controls.Add(this.openResx);
            this.Controls.Add(this.targetCultureLab);
            this.Controls.Add(this.targetCulture);
            this.Controls.Add(this.currentCultureLab);
            this.Controls.Add(this.currentCulture);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.TMGrid);
            this.Name = "TranslationMemory";
            this.Text = "Translation Memory";
            this.Load += new System.EventHandler(this.BBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TMGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TMGrid;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label currentCulture;
        private System.Windows.Forms.Label currentCultureLab;
        private System.Windows.Forms.Label targetCulture;
        private System.Windows.Forms.Label targetCultureLab;
        private System.Windows.Forms.Button openResx;
        private System.Windows.Forms.Button openTMFile;
        private System.Windows.Forms.Button saveResxFile;
        private System.Windows.Forms.Button saveCurrentTM;
        private System.Windows.Forms.Button saveNewTM;
        private System.Windows.Forms.Button bingTranslation;
        private System.Windows.Forms.ComboBox trsCulture;
        private System.Windows.Forms.Label transelateCultureLabel; 
    }
}

