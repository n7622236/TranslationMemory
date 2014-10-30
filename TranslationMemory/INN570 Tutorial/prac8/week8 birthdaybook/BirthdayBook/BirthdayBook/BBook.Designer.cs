namespace BirthdayBook
{
    partial class BBook
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
            this.BBookGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.currentCultureLabel = new System.Windows.Forms.Label();
            this.currentCulture = new System.Windows.Forms.Label();
            this.openResx = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BBookGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BBookGrid
            // 
            this.BBookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BBookGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.BBookGrid.Location = new System.Drawing.Point(0, 24);
            this.BBookGrid.Name = "BBookGrid";
            this.BBookGrid.RowTemplate.Height = 24;
            this.BBookGrid.Size = new System.Drawing.Size(596, 193);
            this.BBookGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(596, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // cmdExit
            // 
            this.cmdExit.AutoSize = true;
            this.cmdExit.Location = new System.Drawing.Point(474, 223);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(110, 25);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelect.AutoSize = true;
            this.cmdSelect.Location = new System.Drawing.Point(474, 253);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(110, 23);
            this.cmdSelect.TabIndex = 4;
            this.cmdSelect.Text = "Set Culture";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // currentCultureLabel
            // 
            this.currentCultureLabel.AutoSize = true;
            this.currentCultureLabel.Location = new System.Drawing.Point(23, 244);
            this.currentCultureLabel.Name = "currentCultureLabel";
            this.currentCultureLabel.Size = new System.Drawing.Size(83, 13);
            this.currentCultureLabel.TabIndex = 5;
            this.currentCultureLabel.Text = "Current Culture :";
            // 
            // currentCulture
            // 
            this.currentCulture.AutoSize = true;
            this.currentCulture.Location = new System.Drawing.Point(144, 244);
            this.currentCulture.Name = "currentCulture";
            this.currentCulture.Size = new System.Drawing.Size(0, 13);
            this.currentCulture.TabIndex = 6;
            // 
            // openResx
            // 
            this.openResx.Location = new System.Drawing.Point(358, 223);
            this.openResx.Name = "openResx";
            this.openResx.Size = new System.Drawing.Size(110, 23);
            this.openResx.TabIndex = 7;
            this.openResx.Text = "Select Source File";
            this.openResx.UseVisualStyleBackColor = true;
            // 
            // BBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 288);
            this.Controls.Add(this.openResx);
            this.Controls.Add(this.currentCulture);
            this.Controls.Add(this.currentCultureLabel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.BBookGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BBook";
            this.Text = "Birthday Book";
            this.Load += new System.EventHandler(this.BBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BBookGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BBookGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Label currentCultureLabel;
        private System.Windows.Forms.Label currentCulture;
        private System.Windows.Forms.Button openResx;
    }
}

