using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;  

using System.IO;
using System.Globalization;
using System.Threading;

namespace BirthdayBook
{
    public partial class BBook : Form
    {
        const string TableName = "TheTranslationMemoroyEditor";
        const string NameCol = "StringID";
        const string DateCol = "Source";
        const string BudgetCol = "Target"; 
        const int GridLineWidth = 1;
        const int NumColumns = 3;               // Number of columns
        const string Separator = ";";           // Field separator
        private DataTable TMs_Table;	 
        protected CultureInfo originalCulture;

        public BBook()
        {
            InitializeComponent();
        }

        //new method (week 8) 
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            SelectCulture s = new SelectCulture();
            if (s.ShowDialog() == DialogResult.OK)
            {
                LoadUIStrings();
            }
        }

        //new method (week 8)
        private void LoadUIStrings()
        {
            ResourceManager res = new ResourceManager("BirthdayBook.UIStrings", this.GetType().Assembly);
            cmdExit.Text = res.GetString("Exit");
            fileToolStripMenuItem.Text = res.GetString("File");
            this.Text = res.GetString("BirthdayBook");

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBook_Load(object sender, EventArgs e)
        {
            //Initialize everything on startup
            //Create a data table with two columns
            this.TMs_Table = new DataTable(TableName);
            this.TMs_Table.Columns.Add(new DataColumn(NameCol, Type.GetType("System.String")));
            this.TMs_Table.Columns.Add(new DataColumn(DateCol, Type.GetType("System.DateTime")));
            this.TMs_Table.Columns.Add(new DataColumn(BudgetCol, Type.GetType("System.Decimal")));
            BBookGrid.DataSource = TMs_Table;

            //Set up a better looking table 
            BBookGrid.Columns[NameCol].Width = (BBookGrid.Width - BBookGrid.RowHeadersWidth - 2 * GridLineWidth) / NumColumns
                  - GridLineWidth;
            BBookGrid.Columns[DateCol].Width = BBookGrid.Columns[NameCol].Width;

            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Format = "C2";
            BBookGrid.Columns[BudgetCol].DefaultCellStyle = cs;
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
                String cultureName = MyStream.ReadLine();
                CultureInfo format = new CultureInfo(cultureName, true);

                //Set Current Culture as the Culture in the text file to replace the previous culture (week8)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);

                originalCulture = Thread.CurrentThread.CurrentCulture;
                currentCultureLabel.Text = originalCulture.Name + " " + originalCulture.DisplayName;

                BBookGrid.DataSource = null;
                TMs_Table.Clear(); //Clear the existing table
                BBookGrid.DataSource = TMs_Table;
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
                                TMs_Table.Rows.Add(TMs_Table.NewRow());
                                TMs_Table.Rows[TMs_Table.Rows.Count - 1][NameCol] = fields[0].Trim();
                                TMs_Table.Rows[TMs_Table.Rows.Count - 1][DateCol] = DateTime.Parse(fields[1].Trim(), format, DateTimeStyles.NoCurrentDateDefault);

                                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                                TMs_Table.Rows[TMs_Table.Rows.Count - 1][BudgetCol] = Decimal.Parse(fields[2].Trim(), style, CultureInfo.CreateSpecificCulture(cultureName));
                            
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
                    StreamWriter MyStream = new StreamWriter(SaveDialog.FileName);

                    String cultureName = Thread.CurrentThread.CurrentCulture.Name;
                    MyStream.WriteLine(cultureName);

                    foreach (DataRow MyRow in TMs_Table.Rows)
                    {

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
