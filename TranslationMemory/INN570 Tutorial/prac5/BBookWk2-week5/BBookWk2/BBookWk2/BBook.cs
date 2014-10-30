using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace BBookWk2
{
    public partial class BBook : Form
    {

        const string TableName = "Birthdays";
        const string NameCol = "Name";
        const string DateCol = "Birthday";
        const int GridLineWidth = 1;
        const int NumColumns = 2;               // Number of columns
        const string Separator = ";";           // Field separator

        private DataTable m_BBookTable;	  //stores the birthdays 

        public BBook()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBook_Load(object sender, EventArgs e)
        {
            //Initialize everything on startup
            //Create a data table with two columns
            this.m_BBookTable = new DataTable(TableName);
            this.m_BBookTable.Columns.Add(new DataColumn(NameCol, Type.GetType("System.String")));
            this.m_BBookTable.Columns.Add(new DataColumn(DateCol, Type.GetType("System.DateTime")));
            BBookGrid.DataSource = m_BBookTable;

            //Set up a better looking table 
            BBookGrid.Columns[NameCol].Width = (BBookGrid.Width - BBookGrid.RowHeadersWidth - 2 * GridLineWidth) / NumColumns
                  - GridLineWidth;
            BBookGrid.Columns[DateCol].Width = BBookGrid.Columns[NameCol].Width;

            //read bytes, decoding, and then add to the table 
            FileStream fsSource = new FileStream("inpututf8.txt", FileMode.Open, FileAccess.Read); 
            byte[] bytes = new byte[fsSource.Length]; 
            fsSource.Read(bytes, 0, bytes.Length);
            string contents;

            //decoding to get a string of character 
            contents = Encoding.UTF8.GetString(bytes); 
            //split the string into an array of strings 
            //each string in the array is a sentence from the input file 
            string [] sentences=contents.Split(new Char[]{'\n'});

            //get each sentence and add it onto the birthday table 
            for (int j = 0; j < sentences.Length; j++) 
            { 
                DataRow new_row = m_BBookTable.NewRow(); 
                new_row["Name"] = sentences[j]; m_BBookTable.Rows.Add(new_row); 
            } 
            fsSource.Close();

            //create an object of Decoder 
            Decoder d = Encoding.UTF8.GetDecoder(); 
            int charsDecodedCount = d.GetCharCount(bytes, 0, bytes.Length);
            char[] chars = new char[charsDecodedCount];
            //using decoder class method GetChars to decode and convert 
            //the bytes in byte array ‘bytes’ which has been declared above 
            int numChar = d.GetChars(bytes, 0, bytes.Length, chars, 0);
            //split the string into an array of strings 
            //each string in the array is a sentence from the input file contents = new String(chars); sentences = contents.Split(new Char[] { '\n' });
            //get each sentence and add it onto the birthday table 
            for (int j = 0; j < sentences.Length; j++) 
            { 
                DataRow new_row = m_BBookTable.NewRow(); 
                new_row["Name"] = sentences[j]; 
                m_BBookTable.Rows.Add(new_row); 
            }

            //create a streamReader object 
            StreamReader streamIn; 
            //read strings from an input file 
            streamIn = new StreamReader("inpututf8.txt");
            string line; 
            //read each line in the input file and add into the birthday table 
            while ((line = streamIn.ReadLine()) != null) 
            { 
                DataRow dr = m_BBookTable.NewRow(); dr["Name"] = line; 
                m_BBookTable.Rows.Add(dr); 
            } 
            streamIn.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog.Reset();
            OpenDialog.InitialDirectory = Directory.GetCurrentDirectory();
            OpenDialog.RestoreDirectory = false;
            OpenDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader MyStream = new StreamReader(OpenDialog.FileName);
                BBookGrid.DataSource = null;
                m_BBookTable.Clear();  //Clear the existing table
                BBookGrid.DataSource = m_BBookTable;
                try
                {
                    while (true)
                    {
                        String MyLine = MyStream.ReadLine();
                        if (MyLine == null)
                        {
                            break;
                        }
                        else if (MyLine.Length != 0)
                        {
                            String[] fields = MyLine.Split(Separator.ToCharArray());
                            if (fields.GetLength(0) == 2)
                            {
                                m_BBookTable.Rows.Add(m_BBookTable.NewRow());
                                m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][NameCol] =
                                                                         fields[0].Trim();
                                m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][DateCol] =
                                                                         fields[1].Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fatal Error" + ex.ToString());
                    Application.Exit();
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog.Reset();
            SaveDialog.InitialDirectory = Directory.GetCurrentDirectory();
            SaveDialog.RestoreDirectory = false;
            SaveDialog.Filter =
                             "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    StreamWriter MyStream = new
                                          StreamWriter(SaveDialog.FileName);

                    foreach (DataRow MyRow in m_BBookTable.Rows)
                    {
                        MyStream.WriteLine(MyRow[NameCol].ToString() +
                           Separator + MyRow[DateCol].ToString());
                    }
                    MyStream.Flush();
                    MyStream.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fatal Error\n" + ex.ToString());
                    Application.Exit();
                }
            }

        }
    }
}
