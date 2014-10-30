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
using System.Globalization;
using System.Threading;

namespace BirthdayBook
{
    public partial class BBook : Form
    {
        const string TableName = "Birthdays";
        const string NameCol = "Name";
        const string DateCol = "Birthday";
        const int GridLineWidth = 1;
        const int NumColumns = 3;              //changed from 2 to 3 (week6)  
        const string Separator = ";";           // Field separator
        private DataTable m_BBookTable;	  //stores the birthdays 

        const string BudgetCol = "Cost"; //added for the budget column (week6)

        public BBook()
        {

            InitializeComponent();
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


            //added the follwoing code for the budget column (week6)
            this.m_BBookTable.Columns.Add(new DataColumn(BudgetCol,
                                    Type.GetType("System.Decimal")));
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Format = "C2";
            BBookGrid.Columns[BudgetCol].DefaultCellStyle = cs;

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog.Reset();
            OpenDialog.InitialDirectory = Directory.GetCurrentDirectory();
            OpenDialog.RestoreDirectory = false;
            OpenDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader MyStream = new StreamReader(OpenDialog.FileName); //add two lines of code below to read the culture in input file (week6)

                String cultureName = MyStream.ReadLine();
                CultureInfo format = new CultureInfo(cultureName, true);//format is the culture in the input file

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
                            if (fields.GetLength(0) == NumColumns)
                            {
                                m_BBookTable.Rows.Add(m_BBookTable.NewRow());
                                m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][NameCol] = fields[0].Trim();
                                //m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][DateCol] = fields[1].Trim();//replace fields[1] in the following code (week6) 

                                m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][DateCol] = DateTime.Parse(fields[1].Trim(), format, DateTimeStyles.NoCurrentDateDefault);
                                
                                //add the following code for the budget column (week6)
                                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;

                                m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][BudgetCol] = Decimal.Parse(fields[2].Trim(), style,
                                                               CultureInfo.CreateSpecificCulture(cultureName));
                                DataGridViewCellStyle cs = new DataGridViewCellStyle();
                                cs.Format = "C2";
                                BBookGrid.Columns[BudgetCol].DefaultCellStyle = cs;

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
            SaveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    StreamWriter MyStream = new StreamWriter(SaveDialog.FileName); //add the following two lines of code to save the culture  (week6)

                    String cultureName = Thread.CurrentThread.CurrentCulture.Name;
                    MyStream.WriteLine(cultureName);
 
                    foreach (DataRow MyRow in m_BBookTable.Rows)
                    {
                      // MyStream.WriteLine(MyRow[NameCol].ToString() + Separator + MyRow[DateCol].ToString()); replaced with the following code which includes the budget column(week6)

                        MyStream.WriteLine(MyRow[NameCol].ToString() + Separator + MyRow[DateCol].ToString() + Separator + Decimal.Parse(MyRow[BudgetCol].ToString()).ToString("C2", CultureInfo.CreateSpecificCulture(cultureName)));
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
