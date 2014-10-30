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
using System.Xml;
using System.Collections;

namespace INN570_TranslationMemory
{
    public partial class TranslationMemory : Form
    {
        const string TableName = "TranslationMemory";
        const string stringIDCol = "StringID";
        const string sourceCol = "Source";
        const string targetCol = "Target";
        const int GridLineWidth = 1;
        const int NumColumns = 3;             
        const string Separator = ";";          
        private DataTable tm_Editor_Table;
        string defaultResxFilename = null;
        string currentTMFilename = null;
        string currentCultureName = null;
        string targetCultureName = null;


        public TranslationMemory()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBook_Load(object sender, EventArgs e)
        { 
            this.tm_Editor_Table = new DataTable(TableName);
            this.tm_Editor_Table.Columns.Add(new DataColumn(stringIDCol, Type.GetType("System.String")));
            this.tm_Editor_Table.Columns.Add(new DataColumn(sourceCol, Type.GetType("System.String")));
            this.tm_Editor_Table.Columns.Add(new DataColumn(targetCol, Type.GetType("System.String")));
            TMGrid.DataSource = tm_Editor_Table;

            TMGrid.Columns[stringIDCol].Width = (TMGrid.Width - TMGrid.RowHeadersWidth - 2 * GridLineWidth) / NumColumns
                  - GridLineWidth;
            TMGrid.Columns[sourceCol].Width = TMGrid.Columns[stringIDCol].Width;
            TMGrid.Columns[stringIDCol].ReadOnly = true;
            TMGrid.Columns[sourceCol].ReadOnly = true;
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Format = "C2";
            TMGrid.Columns[targetCol].DefaultCellStyle = cs;

            CultureInfo[] translateCultures;
            translateCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culturelist in translateCultures) 
            { 
                trsCulture.Items.Add(culturelist.Name + " _ " + culturelist.EnglishName); 
            }
            trsCulture.SelectedIndex = trsCulture.FindString("zh-TW");
         }
       
        private void openXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openxml = new OpenFileDialog();
            openxml.Reset();
            openxml.Filter = " xml (*.xml)|*.xml|tmx (*.tmx)|*.tmx";
            if (openxml.ShowDialog() == DialogResult.OK)
            {
                tm_Editor_Table.Clear();

                XmlDocument doc = new XmlDocument();
                doc.Load(openxml.FileName);

                XmlNodeList nodelist = doc.SelectNodes("//body//tu//tuv");
                String[] currentlang = new string[2];
                int fetchTimeCulture = 2;
                for (int i = 0; i < fetchTimeCulture; i++)
                {
                    XmlNode inputNode = nodelist[i];
                    if (inputNode.Attributes != null)
                    {
                        foreach (XmlAttribute inputAttribute in inputNode.Attributes)
                        {
                            currentlang[i] = inputAttribute.Value;
                        }
                    }
                }

                int controlSeg = 0;
                int createARow = 0;
                string tmpName = null;
                string tmpBD = null;

                nodelist = doc.SelectNodes("//body//tu//tuv//seg");
                foreach (XmlNode oneNode in nodelist)
                {
                    DataRow newrow = tm_Editor_Table.NewRow();

                    if (controlSeg == 0)
                    {
                        tmpName = oneNode.InnerText;
                        controlSeg = 1;
                        createARow++;
                    }
                    else
                    {
                        tmpBD = oneNode.InnerText;
                        controlSeg = 0;
                        createARow++;
                    }
                    if (createARow == 2)
                    {
                        newrow["StringID"] = tmpName;
                        newrow["Source"] = tmpBD;
                        newrow["Target"] = "No Match";

                        tm_Editor_Table.Rows.Add(newrow);
                        createARow = 0;
                    }
                }
            }
        }
        private void openTMFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTMFile = new OpenFileDialog();
            openTMFile.Reset();
            openTMFile.Filter = " Translation Memory File(*.tmx)|*.tmx";

            if (openTMFile.ShowDialog() == DialogResult.OK)
            {
                currentTMFilename = openTMFile.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(openTMFile.FileName);

                XmlNodeList nodelist = doc.SelectNodes("//body//tu//tuv");
                String[] currentlang = new string[2];
                int fetchTimeCulture = 2;
                for (int i = 0; i < fetchTimeCulture; i++)
                {
                    XmlNode inputNode = nodelist[i];
                    if (inputNode.Attributes != null)
                    {
                        foreach (XmlAttribute inputAttribute in inputNode.Attributes)
                        {
                            currentlang[i] = inputAttribute.Value;
                        }
                    }
                }

                currentCultureName = currentlang[0];
                targetCultureName=currentlang[1];
                currentCultureLab.Text = currentCultureName;
                targetCultureLab.Text = targetCultureName;

                int controlSeg = 0;
                foreach (DataRow resxRow in tm_Editor_Table.Rows)
                {
                    nodelist = doc.SelectNodes("//body//tu//tuv//seg");
                    foreach (XmlNode oneNode in nodelist)
                    {
                        if (controlSeg == 0)
                        {
                            if (resxRow[sourceCol].ToString().Trim() == oneNode.InnerText.Trim())
                            {
                                controlSeg = 1;
                            }
                        }
                        else if (controlSeg == 1)
                        {
                            resxRow[targetCol] = oneNode.InnerText.Trim();
                            controlSeg = 0;
                            break;
                        }
                    }
                }
            }
        }
        private void openResx_Click(object sender, EventArgs e)
        {
            OpenFileDialog openResxFile = new OpenFileDialog();
            openResxFile.Reset();
            openResxFile.Filter = " Resource File (*.resx)|*.resx";
            
            if (openResxFile.ShowDialog() == DialogResult.OK)
            {
                tm_Editor_Table.Clear();
                defaultResxFilename = openResxFile.FileName;
               
                ResXResourceReader resxReader = new ResXResourceReader(openResxFile.FileName);
                foreach (DictionaryEntry collectionDE in resxReader)
                {
                    DataRow newrow = tm_Editor_Table.NewRow();
                    newrow["StringID"] = collectionDE.Key.ToString();
                    newrow["Source"] = collectionDE.Value.ToString();
                    newrow["Target"] = "No Match";
                    tm_Editor_Table.Rows.Add(newrow);
                }

                currentCultureName = "en-US";
                targetCultureName = defaultResxFilename;
                targetCultureName = targetCultureName.Split('.')[1] == "resx" ? "zh-TW" : targetCultureName.Split('.')[1];
                currentCultureLab.Text = currentCultureName;
                targetCultureLab.Text = targetCultureName;
                trsCulture.SelectedIndex = trsCulture.FindString(targetCultureName);
            }
        }

        private void saveResxFile_Click(object sender, EventArgs e)
        {
            if (defaultResxFilename == null)
            {
                MessageBox.Show("Please choose a resource file first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                SaveFileDialog saveResxFile = new SaveFileDialog();
                saveResxFile.Filter = "Resources File|*.resx";
                string[] filename = defaultResxFilename.Split('\\');
                string tmpFileName=filename[filename.Length - 1];
                tmpFileName = tmpFileName.Split('.')[0] + "." + targetCultureName + ".resx";
                saveResxFile.FileName = tmpFileName;
           
                if (saveResxFile.ShowDialog() == DialogResult.OK)
                {
                    ResXResourceWriter resxWriter = new ResXResourceWriter(saveResxFile.FileName);
                    foreach (DataRow resxRow in tm_Editor_Table.Rows)
                    {
                        string tmpId = resxRow[stringIDCol].ToString().Trim();
                        string tmpvalue = resxRow[sourceCol].ToString();
                        if (resxRow[targetCol].ToString() == "No Match")
                        {
                            resxWriter.AddResource(tmpId,tmpvalue);
                        }
                        else
                        {
                            tmpvalue = resxRow[targetCol].ToString().Trim();
                            resxWriter.AddResource(tmpId, tmpvalue);
                        }     
                    }
                    resxWriter.Close();
                    MessageBox.Show(tmpFileName+" is saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void saveCurrentTM_Click(object sender, EventArgs e)
        {
            string[] filename = currentTMFilename.Split('\\');
            string tmpFileName = filename[filename.Length - 1];

            if (currentTMFilename == null)
            {
                MessageBox.Show("***Please choose a Translation Memory File first***", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Are you sure to save " + tmpFileName + " ?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    XmlDocument doc = new XmlDocument();
                    doc.Load(currentTMFilename);

                    // get two cultures from TMs
                    XmlNodeList nodelist = null;

                    //fetch data to compare with TM
                    foreach (DataRow resxRow in tm_Editor_Table.Rows)
                    {
                        Boolean addNodeControl = true;
                        if (resxRow[sourceCol].ToString() != resxRow[targetCol].ToString() && resxRow[targetCol].ToString() != "No Match") 
                        {
                            nodelist = doc.SelectNodes("//body//tu//tuv//seg");
                            foreach (XmlNode oneNode in nodelist)
                            {
                                if (resxRow[stringIDCol].ToString().Trim() == oneNode.InnerText.Trim())
                                {
                                    String tmpNextNode = oneNode.NextSibling == null ? "" : oneNode.NextSibling.InnerText;
                                    String tmpSoureCol = resxRow[targetCol] == null ? "" : resxRow[targetCol].ToString().Trim();
                                    if (tmpSoureCol != tmpNextNode && oneNode.NextSibling != null)
                                    {
                                        oneNode.NextSibling.InnerText = tmpSoureCol;
                                        break;
                                    }
                                    addNodeControl = false;
                                }
                            }

                            if (addNodeControl) 
                            {
                                //add new node
                                XmlNode addnewNode = doc.SelectSingleNode("//body");
                                int tuvNum = (nodelist.Count / 2) + 1;
                                XmlElement addtuElement = doc.CreateElement("tu");
                                addtuElement.SetAttribute("tuid", tuvNum.ToString());
                                addnewNode.AppendChild(addtuElement);

                                int createTwoCulture = 2;
                                for (int i = 0; i <= createTwoCulture; i += 2)
                                {
                                    XmlElement tuvElement = doc.CreateElement("tuv");
                                    tuvElement.SetAttribute("xml:lang", i <= 0 ? currentCultureName : targetCultureName);
                                    addtuElement.AppendChild(tuvElement);

                                    XmlElement segElement = doc.CreateElement("seg");
                                    segElement.InnerText = i <= 0 ? resxRow[sourceCol].ToString().Trim() : resxRow[targetCol].ToString().Trim();
                                    tuvElement.AppendChild(segElement);
                                }
                            }
                        }
                        
                    }
                    doc.Save(currentTMFilename);
                }
        }

        private void saveNewTM_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveNewTMFile = new SaveFileDialog();
            saveNewTMFile.Reset();
            saveNewTMFile.Filter = " Translation Memory File (*.tmx)|*.tmx";
            saveNewTMFile.FileName = targetCultureName + "-" + "TranslationMemory";
            if (saveNewTMFile.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();

                XmlNode xmlnode;
                xmlnode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                doc.AppendChild(xmlnode);

                XmlElement docelements = doc.CreateElement("tmx");
                
                XmlElement CultureElement = doc.CreateElement("header");
                XmlElement BodyElement = doc.CreateElement("body");

                docelements.SetAttribute("version", "1.4");
                docelements.AppendChild(CultureElement);
                docelements.AppendChild(BodyElement);

                int countTUID = 1;
                foreach (DataRow dr in tm_Editor_Table.Rows)
                {
                    if (dr[targetCol].ToString() != "No Match")
                    {
                        XmlElement tuElement = doc.CreateElement("tu");
                        tuElement.SetAttribute("tuid", countTUID.ToString());
                        BodyElement.AppendChild(tuElement);

                        int createTwoCulture = 2;
                        for (int i = 0; i <= createTwoCulture; i += 2)
                        {
                            XmlElement tuvElement = doc.CreateElement("tuv");
                            tuvElement.SetAttribute("xml:lang", i <= 0 ? currentCultureName : targetCultureName);
                            tuElement.AppendChild(tuvElement);

                            XmlElement segElement = doc.CreateElement("seg");
                            segElement.InnerText = dr[i].ToString();
                            tuvElement.AppendChild(segElement);
                        }
                        countTUID++;
                    }          
                }
                doc.AppendChild(docelements);
                doc.Save(saveNewTMFile.FileName);
                currentTMFilename = saveNewTMFile.FileName;
            }
        }

        private void bingTranslation_Click(object sender, EventArgs e)
        {
            if (defaultResxFilename == null)
            {
                MessageBox.Show("Please select a resource file first");
            }
            else 
            { 
                MSTranslator mst = new MSTranslator();
                String translatedResult = null;
                targetCultureName = trsCulture.SelectedItem.ToString();
                targetCultureName = targetCultureName.Split('_')[0];
                foreach (DataRow dr in tm_Editor_Table.Rows)
                {
                    if (dr[stringIDCol] == null)
                    {
                        MessageBox.Show("please select a resoure file first");
                        break;
                    }
                    translatedResult = mst.TranslateMethod(dr[sourceCol].ToString(), currentCultureName.ToString(), targetCultureName.ToString());

                    if (translatedResult != dr[sourceCol].ToString())
                    {
                        dr[targetCol] = translatedResult;
                    }
                }
            }        
        }

        private void trsCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trsCulture != null)
            {
                targetCultureName = trsCulture.SelectedItem.ToString();
                targetCultureLab.Text = targetCultureName;
            }
        }
    }
}
