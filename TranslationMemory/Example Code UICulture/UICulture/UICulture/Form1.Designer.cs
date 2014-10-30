namespace UICulture
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboSelectCulture = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGreeting = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNewForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboSelectCulture
            // 
            this.comboSelectCulture.DropDownWidth = 240;
            this.comboSelectCulture.FormattingEnabled = true;
            resources.ApplyResources(this.comboSelectCulture, "comboSelectCulture");
            this.comboSelectCulture.Name = "comboSelectCulture";
            this.comboSelectCulture.Sorted = true;
            this.comboSelectCulture.SelectedIndexChanged += new System.EventHandler(this.comboSelectCulture_SelectedIndexChanged);
            // 
            // label1 
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelGreeting
            // 
            this.labelGreeting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.labelGreeting, "labelGreeting");
            this.labelGreeting.ForeColor = System.Drawing.Color.Teal;
            this.labelGreeting.Name = "labelGreeting";
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // buttonNewForm
            // 
            resources.ApplyResources(this.buttonNewForm, "buttonNewForm");
            this.buttonNewForm.Name = "buttonNewForm";
            this.buttonNewForm.UseVisualStyleBackColor = true;
            this.buttonNewForm.Click += new System.EventHandler(this.buttonNewForm_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNewForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelGreeting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSelectCulture);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox comboSelectCulture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGreeting;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonNewForm;

    }
}

