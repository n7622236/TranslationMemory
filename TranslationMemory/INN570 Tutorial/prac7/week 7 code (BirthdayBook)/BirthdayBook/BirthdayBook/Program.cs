using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdayBook
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Now manage the selection form - and then set up 
            //an infinite selection loop
            SelectCulture cultures = new SelectCulture();

            while (cultures.ShowDialog() == DialogResult.OK)
            {
                BBook bb = new BBook();
                bb.ShowDialog();
            }
        }
    }
}
