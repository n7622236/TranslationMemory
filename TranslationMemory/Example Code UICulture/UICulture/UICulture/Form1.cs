using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using System.Resources;

namespace UICulture
{
    public partial class Form1 : Form
    {
        //current culture
        protected CultureInfo originalCulture;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo[] list;
            String name;

            //current culture
            originalCulture = Thread.CurrentThread.CurrentCulture;
            label4.Text = originalCulture.Name + " " + originalCulture.DisplayName;

            //Get a list of cultures 
            list = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures);

            //Clean the combo boxes
            comboSelectCulture.Items.Clear();

            //There is a culture name and a display name in each culture
            foreach (CultureInfo ci in list)
            {
                //bind the names together and show for culture 
                name = ci.Name + " " + ci.DisplayName;
                comboSelectCulture.Items.Add(name);
            }
           comboSelectCulture.SelectedIndex = 0;
        }

        //Change culture and display welcome message upon changes of the culture selction 
        private void comboSelectCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Auxiliary variables 
            int spaceIndex = 0;

            //Grab the string-based culture identifier of the selected culture
            String cultureID = comboSelectCulture.Text;

            if (cultureID.Length != 0)
            {
                spaceIndex = cultureID.IndexOf(" ");
                if (spaceIndex >= 0)
                {
                    cultureID = cultureID.Substring(0, spaceIndex);
                }

                //Now set the CurrentCulture
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureID);
            }

            ResourceManager rm = new ResourceManager("UICulture.Form1", typeof(Form1).Assembly);
            try
            {
                //set UIculture to be the same as the current culture
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

                //retrieve data for labelGreeting, you can retrieve data for other UI components
                labelGreeting.Text = rm.GetString("labelGreeting.Text");
            }
            catch (MissingManifestResourceException e1)
            {
               labelGreeting.Text = e1.Message;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Generate a new form1
        private static void ThreadProc()
        {
            Application.Run(new Form1());
        }

        private void buttonNewForm_Click(object sender, EventArgs e)
        {
            //create a new Thread object which calls method ThreadProc()
            Thread newForm = new Thread(ThreadProc);
            newForm.Start();
        }

    }
}
