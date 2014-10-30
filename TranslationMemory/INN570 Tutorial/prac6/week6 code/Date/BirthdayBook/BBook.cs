using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BirthdayBook
{
    public partial class BBook : Form
    {
        public BBook()
        {
            InitializeComponent();
        }

        private void BBook_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}