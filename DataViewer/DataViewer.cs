using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DataViewer
{
    enum FileType
    {
        XML,
        JSON,
        CSV
    }

    public partial class DataViewer : Form
    {
        private bool isXmlLoadedData = false;

        private bool isJsonLoadedData = false;

        private bool isCsvLoadedData = false;

        private string xmlLoadedData = string.Empty;

        private string jsonLoadedData = string.Empty;

        private string csvLoadedData = string.Empty;

        private List<string> lstCities;

        private DataSet dsFinalData;

        //private string LOCATION_XML = "location_desc";
        //private string LONGITUDE_XML = "longitude";
        //private string LATITUDE_XML = "latitude";
        //private string LINK_XML = "link";
        //private string LOCATION_CSV = "Main Road|Cross Street";
        //private string LONGITUDE_CSV = "Longitude";
        //private string LATITUDE_CSV = "Latitude";
        //private string LINK_CSV = "Traffic Image";
        //private string LOCATION_JSON = "Location";
        //private string LONGITUDE_JSON = "Longitude";
        //private string LATITUDE_JSON = "Latitude";
        //private string LINK_JSON = "IMAGE";
        private string LOCATION_TEMP = string.Empty;
        private string LONGITUDE_TEMP = string.Empty;
        private string LATITUDE_TEMP = string.Empty;
        private string LINK_TEMP = string.Empty;
        List<string> lstLocations = new List<string>();
        List<string> lstLongitude = new List<string>();
        List<string> lstLatitude = new List<string>();
        List<string> lstLink = new List<string>();
        private string EXTRACT_LOCATION = string.Empty;
        private const string LOCATION_FINAL = "Location";
        private const string LONGITUDE_FINAL = "Longitude";
        private const string LATITUDE_FINAL = "Latitude";
        private const string LINK_FINAL = "Link";

        public DataViewer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstCities = new List<string>() { "Ottawa", "Surrey", "Toronto" };

            lstLocations.AddRange(ConfigurationManager.AppSettings["LOCATION_LIST"].Split(','));
            lstLongitude.AddRange(ConfigurationManager.AppSettings["LONGITUDE_LIST"].Split(','));
            lstLatitude.AddRange(ConfigurationManager.AppSettings["LATITUDE_LIST"].Split(','));
            lstLink.AddRange(ConfigurationManager.AppSettings["LINK_LIST"].Split(','));
            EXTRACT_LOCATION = ConfigurationManager.AppSettings["Extract_Location"];

            dsFinalData = new DataSet();
        }

        private void UploadFile(string fileLocation, FileType fileType)
        {
            if (dsFinalData.Tables.Contains(fileLocation))
            {
                MessageBox.Show("File with same name already uploaded");
            }
            else
            {
                DataTable finalData = new DataTable();
                string city = string.Empty;
                foreach (string item in lstCities)
                {
                    if (fileLocation.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        city = item;
                        break;
                    }
                }

                finalData.TableName = fileLocation;

                finalData.Columns.Add(LOCATION_FINAL);
                finalData.Columns.Add(LONGITUDE_FINAL);
                finalData.Columns.Add(LATITUDE_FINAL);
                finalData.Columns.Add(LINK_FINAL);
                finalData.Columns.Add("City");
                finalData.Columns["City"].DefaultValue = city;
                switch (fileType)
                {
                    case FileType.XML:
                        DataSet xmlDataSet = new DataSet();

                        xmlDataSet.ReadXml(fileLocation);
                        if (xmlDataSet != null && xmlDataSet.Tables.Count > 0 && xmlDataSet.Tables[0].Rows.Count > 0)
                        {
                            foreach (var item in lstLocations)
                            {
                                if (xmlDataSet.Tables[0].Columns.Contains(item.Split('|')[0]))
                                {
                                    LOCATION_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLongitude)
                            {
                                if (xmlDataSet.Tables[0].Columns.Contains(item))
                                {
                                    LONGITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLatitude)
                            {
                                if (xmlDataSet.Tables[0].Columns.Contains(item))
                                {
                                    LATITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLink)
                            {
                                if (xmlDataSet.Tables[0].Columns.Contains(item))
                                {
                                    LINK_TEMP = item;
                                    break;
                                }
                            }
                            foreach (DataRow dr in xmlDataSet.Tables[0].AsEnumerable().OrderBy(x => Convert.ToString(x[LOCATION_TEMP])))
                            {
                                DataRow drFinal = finalData.NewRow();
                                if (xmlDataSet.Tables[0].Columns.Contains(LOCATION_TEMP))
                                    drFinal[LOCATION_FINAL] = dr[LOCATION_TEMP];
                                if (xmlDataSet.Tables[0].Columns.Contains(LONGITUDE_TEMP))
                                    drFinal[LONGITUDE_FINAL] = dr[LONGITUDE_TEMP];
                                if (xmlDataSet.Tables[0].Columns.Contains(LATITUDE_TEMP))
                                    drFinal[LATITUDE_FINAL] = dr[LATITUDE_TEMP];
                                if (xmlDataSet.Tables[0].Columns.Contains(LINK_TEMP))
                                    drFinal[LINK_FINAL] = dr[LINK_TEMP];
                                finalData.Rows.Add(drFinal);
                            }
                            dsFinalData.Tables.Add(finalData);
                            gridUploadedData.DataSource = xmlDataSet.Tables[0];
                            MessageBox.Show("Data Uploaded Successfully.");
                        }
                        else
                            MessageBox.Show("No data in file.");
                        break;
                    case FileType.JSON:
                        string jsonFileData = File.ReadAllText(fileLocation);
                        DataTable jsonData = new DataTable();
                        if (string.IsNullOrEmpty(jsonFileData))
                        {
                            MessageBox.Show("No data in file");
                            return;
                        }

                        object lstJSONData = new JavaScriptSerializer().DeserializeObject(jsonFileData);
                        IList list = (IList)lstJSONData;

                        if (list.Count > 0)
                        {

                            Dictionary<string, object> dictJSONDataSchema = new Dictionary<string, object>((Dictionary<String, Object>)list[0], StringComparer.OrdinalIgnoreCase);
                            foreach (var item in lstLocations)
                            {
                                if (dictJSONDataSchema.Keys.Contains(item.Split('|')[0]))
                                {
                                    LOCATION_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLongitude)
                            {
                                if (dictJSONDataSchema.Keys.Contains(item))
                                {
                                    LONGITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLatitude)
                            {
                                if (dictJSONDataSchema.Keys.Contains(item))
                                {
                                    LATITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLink)
                            {
                                if (dictJSONDataSchema.Keys.Contains(item))
                                {
                                    LINK_TEMP = item;
                                    break;
                                }
                            }

                            foreach (string key in dictJSONDataSchema.Keys)
                            {
                                if (!jsonData.Columns.Contains(key))
                                    jsonData.Columns.Add(key);
                            }
                            foreach (var item in list)
                            {
                                Dictionary<string, object> dictJSONData = new Dictionary<string, object>((Dictionary<String, Object>)item, StringComparer.OrdinalIgnoreCase);

                                DataRow dr = jsonData.NewRow();
                                foreach (KeyValuePair<string, object> kvp in dictJSONData)
                                {
                                    if (jsonData.Columns.Contains(kvp.Key))
                                        dr[kvp.Key] = kvp.Value;
                                }

                                jsonData.Rows.Add(dr);
                            }


                            foreach (var item in list)
                            {
                                Dictionary<string, object> dictJSONData = new Dictionary<string, object>((Dictionary<String, Object>)item, StringComparer.OrdinalIgnoreCase);

                                DataRow drFinal = finalData.NewRow();
                                if (dictJSONData.Keys.Contains(LOCATION_TEMP))
                                    drFinal[LOCATION_FINAL] = dictJSONData[LOCATION_TEMP];
                                if (dictJSONData.Keys.Contains(LONGITUDE_TEMP))
                                    drFinal[LONGITUDE_FINAL] = dictJSONData[LONGITUDE_TEMP];
                                if (dictJSONData.Keys.Contains(LATITUDE_TEMP))
                                    drFinal[LATITUDE_FINAL] = dictJSONData[LATITUDE_TEMP];
                                if (dictJSONData.Keys.Contains(LINK_TEMP))
                                    drFinal[LINK_FINAL] = dictJSONData[LINK_TEMP];

                                finalData.Rows.Add(drFinal);
                            }
                            finalData = finalData.AsEnumerable().OrderBy(x => Convert.ToString(x[LOCATION_FINAL])).CopyToDataTable();
                            finalData.TableName = fileLocation;
                            dsFinalData.Tables.Add(finalData);
                            gridUploadedData.DataSource = jsonData;
                            MessageBox.Show("Data Uploaded Successfully.");
                        }
                        else
                            MessageBox.Show("No data in file.");
                        break;
                    case FileType.CSV:
                        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + Path.GetDirectoryName(fileLocation) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");

                        conn.Open();

                        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileLocation) + "]", conn);

                        DataSet ds = new DataSet("Temp");
                        adapter.Fill(ds);

                        conn.Close();

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (var item in lstLocations)
                            {
                                if (ds.Tables[0].Columns.Contains(item.Split('|')[0]))
                                {
                                    LOCATION_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLongitude)
                            {
                                if (ds.Tables[0].Columns.Contains(item))
                                {
                                    LONGITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLatitude)
                            {
                                if (ds.Tables[0].Columns.Contains(item))
                                {
                                    LATITUDE_TEMP = item;
                                    break;
                                }
                            }
                            foreach (var item in lstLink)
                            {
                                if (ds.Tables[0].Columns.Contains(item))
                                {
                                    LINK_TEMP = item;
                                    break;
                                }
                            }
                            string[] locationArr = LOCATION_TEMP.Split('|');
                            foreach (DataRow dr in ds.Tables[0].AsEnumerable().OrderBy(x => ((locationArr.Length > 1) ? Convert.ToString(x[locationArr[0]]) + " And " + Convert.ToString(x[locationArr[1]]) : Convert.ToString(x[locationArr[0]]))))
                            {
                                DataRow drFinal = finalData.NewRow();
                                if (ds.Tables[0].Columns.Contains(locationArr[0]))
                                    drFinal[LOCATION_FINAL] = Convert.ToString(dr[locationArr[0]]);
                                if (locationArr.Length > 1 && ds.Tables[0].Columns.Contains(locationArr[1]))
                                    drFinal[LOCATION_FINAL] = Convert.ToString(drFinal[LOCATION_FINAL]) + " And " + Convert.ToString(dr[locationArr[1]]);
                                if (ds.Tables[0].Columns.Contains(LONGITUDE_TEMP))
                                    drFinal[LONGITUDE_FINAL] = dr[LONGITUDE_TEMP];
                                if (ds.Tables[0].Columns.Contains(LATITUDE_TEMP))
                                    drFinal[LATITUDE_FINAL] = dr[LATITUDE_TEMP];
                                if (ds.Tables[0].Columns.Contains(LINK_TEMP))
                                    drFinal[LINK_FINAL] = dr[LINK_TEMP];
                                finalData.Rows.Add(drFinal);
                            }
                            dsFinalData.Tables.Add(finalData);
                            gridUploadedData.DataSource = ds.Tables[0];
                            MessageBox.Show("Data Uploaded Successfully.");
                        }
                        else
                            MessageBox.Show("No data in file.");
                        break;
                }
            }
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                lblXMLLoc.Text = fileToOpen;
                if (fileToOpen.EndsWith(".xml"))
                {
                    UploadFile(fileToOpen, FileType.XML);
                }
                else if (fileToOpen.EndsWith(".json"))
                {
                    UploadFile(fileToOpen, FileType.JSON);
                }
                else if (fileToOpen.EndsWith(".csv"))
                {
                    UploadFile(fileToOpen, FileType.CSV);
                }
                else
                {
                    isXmlLoadedData = false;
                    MessageBox.Show("File format incorrect.");
                }
            }
        }

        private void btnViewAllData_Click(object sender, EventArgs e)
        {
            DataTable finalData = new DataTable();

            if (dsFinalData != null && dsFinalData.Tables.Count > 0)
            {
                foreach (DataTable dt in dsFinalData.Tables)
                {
                    finalData.Merge(dt);
                }
            }

            if (finalData != null && finalData.Rows.Count > 0)
            {
                finalData = finalData.AsEnumerable().OrderBy(x => Convert.ToString(x["City"])).ThenBy(x => Convert.ToString(x[LOCATION_FINAL])).CopyToDataTable();
                gridUploadedData.DataSource = finalData;
                MessageBox.Show("Data Uploaded Successfully.");
            }
            else
            {
                MessageBox.Show("No data uploaded.");
            }
        }

        private void btnExtractAll_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable finalData = new DataTable();
            ds.Tables.Add(finalData);
            if (dsFinalData != null && dsFinalData.Tables.Count > 0)
            {
                foreach (DataTable dt in dsFinalData.Tables)
                {
                    finalData.Merge(dt);
                }
                finalData = finalData.AsEnumerable().OrderBy(x => Convert.ToString(x["City"])).ThenBy(x => Convert.ToString(x[LOCATION_FINAL])).CopyToDataTable();
            }
            if (finalData.Rows.Count > 0)
            {
                ds.WriteXml(EXTRACT_LOCATION + @"\AllData.xml");
                MessageBox.Show("Extract generated successfully");
            }
            else
                MessageBox.Show("No data uploaded");
        }

        private void btnExtractDataFiles_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable finalData = new DataTable();
            if (dsFinalData != null && dsFinalData.Tables.Count > 0)
            {
                foreach (DataTable dt in dsFinalData.Tables)
                {
                    ds = new DataSet();
                    string fileName = Path.GetFileNameWithoutExtension(dt.TableName);
                    finalData = dt.Copy();
                    finalData.TableName = "XMLData";
                    ds.Tables.Add(finalData);
                    ds.WriteXml(EXTRACT_LOCATION + @"\" + fileName + ".xml");
                }
                MessageBox.Show("Extracts generated successfully");
            }
            else
                MessageBox.Show("No data uploaded");
        }

        #region Old
        private void RefreshGridData()
        {
            //try
            //{
            //    DataSet xmlDataSet = null;
            //    DataTable finalData = new DataTable();
            //    string city = string.Empty;

            //    if (isXmlLoadedData)
            //    {
            //        city = string.Empty;
            //        foreach (string item in lstCities)
            //        {
            //            if (xmlLoadedData.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
            //            {
            //                city = item;
            //                break;
            //            }
            //        }
            //        xmlDataSet = new DataSet();
            //        xmlDataSet.ReadXml(xmlLoadedData);
            //        if (xmlDataSet != null && xmlDataSet.Tables.Count > 0 && xmlDataSet.Tables[0].Rows.Count > 0)
            //        {
            //            finalData = xmlDataSet.Tables[0];

            //            if (finalData.Columns.Contains("id"))
            //                finalData.Columns.Remove("id");

            //            if (finalData.Columns.Contains(LOCATION_XML))
            //                finalData.Columns[LOCATION_XML].ColumnName = LOCATION_FINAL;
            //            else if (!finalData.Columns.Contains(LOCATION_FINAL))
            //                finalData.Columns.Add(LOCATION_FINAL);

            //            if (finalData.Columns.Contains(LONGITUDE_XML))
            //                finalData.Columns[LONGITUDE_XML].ColumnName = LONGITUDE_FINAL;
            //            else if (!finalData.Columns.Contains(LONGITUDE_FINAL))
            //                finalData.Columns.Add(LONGITUDE_FINAL);

            //            if (finalData.Columns.Contains(LATITUDE_XML))
            //                finalData.Columns[LATITUDE_XML].ColumnName = LATITUDE_FINAL;
            //            else if (!finalData.Columns.Contains(LATITUDE_FINAL))
            //                finalData.Columns.Add(LATITUDE_FINAL);

            //            if (finalData.Columns.Contains(LINK_XML))
            //                finalData.Columns[LINK_XML].ColumnName = LINK_FINAL;
            //            else if (!finalData.Columns.Contains(LINK_FINAL))
            //                finalData.Columns.Add(LINK_FINAL);

            //            if (!finalData.Columns.Contains("City"))
            //            {
            //                DataColumn dc = new DataColumn("City");
            //                dc.DefaultValue = city;
            //                finalData.Columns.Add(dc);
            //            }
            //        }
            //    }

            //    if (isJsonLoadedData)
            //    {
            //        city = string.Empty;
            //        foreach (string item in lstCities)
            //        {
            //            if (jsonLoadedData.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
            //            {
            //                city = item;
            //                break;
            //            }
            //        }
            //        object lstJSONData = new JavaScriptSerializer().DeserializeObject(File.ReadAllText(jsonLoadedData));
            //        IList list = (IList)lstJSONData;

            //        if (!finalData.Columns.Contains(LOCATION_FINAL))
            //            finalData.Columns.Add(LOCATION_FINAL);
            //        if (!finalData.Columns.Contains(LONGITUDE_FINAL))
            //            finalData.Columns.Add(LONGITUDE_FINAL);
            //        if (!finalData.Columns.Contains(LATITUDE_FINAL))
            //            finalData.Columns.Add(LATITUDE_FINAL);
            //        if (!finalData.Columns.Contains(LINK_FINAL))
            //            finalData.Columns.Add(LINK_FINAL);
            //        if (!finalData.Columns.Contains("City"))
            //        {
            //            finalData.Columns.Add("City");
            //            finalData.Columns["City"].DefaultValue = city;
            //        }

            //        foreach (var item in list)
            //        {
            //            Dictionary<string, object> dictJSONData = new Dictionary<string, object>((Dictionary<String, Object>)item, StringComparer.OrdinalIgnoreCase);

            //            DataRow dr = finalData.NewRow();
            //            if (dictJSONData.ContainsKey(LOCATION_JSON))
            //                dr[LOCATION_FINAL] = dictJSONData[LOCATION_JSON];
            //            if (dictJSONData.ContainsKey(LONGITUDE_JSON))
            //                dr[LONGITUDE_FINAL] = dictJSONData[LONGITUDE_JSON];
            //            if (dictJSONData.ContainsKey(LATITUDE_JSON))
            //                dr[LATITUDE_FINAL] = dictJSONData[LATITUDE_JSON];
            //            if (dictJSONData.ContainsKey(LINK_JSON))
            //                dr[LINK_FINAL] = dictJSONData[LINK_JSON];

            //            dr["City"] = city;

            //            finalData.Rows.Add(dr);
            //        }
            //    }

            //    if (isCsvLoadedData)
            //    {
            //        city = string.Empty;
            //        foreach (string item in lstCities)
            //        {
            //            if (csvLoadedData.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
            //            {
            //                city = item;
            //                break;
            //            }
            //        }
            //        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + Path.GetDirectoryName(csvLoadedData) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");

            //        conn.Open();

            //        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(csvLoadedData) + "]", conn);

            //        DataSet ds = new DataSet("Temp");
            //        adapter.Fill(ds);

            //        conn.Close();

            //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //        {
            //            if (!finalData.Columns.Contains(LOCATION_FINAL))
            //                finalData.Columns.Add(LOCATION_FINAL);
            //            if (!finalData.Columns.Contains(LONGITUDE_FINAL))
            //                finalData.Columns.Add(LONGITUDE_FINAL);
            //            if (!finalData.Columns.Contains(LATITUDE_FINAL))
            //                finalData.Columns.Add(LATITUDE_FINAL);
            //            if (!finalData.Columns.Contains(LINK_FINAL))
            //                finalData.Columns.Add(LINK_FINAL);
            //            if (!finalData.Columns.Contains("City"))
            //            {
            //                finalData.Columns.Add("City");
            //                finalData.Columns["City"].DefaultValue = city;
            //            }

            //            string[] locationArr = LOCATION_CSV.Split('|');
            //            foreach (DataRow drTemp in ds.Tables[0].Rows)
            //            {
            //                DataRow dr = finalData.NewRow();
            //                if (ds.Tables[0].Columns.Contains(locationArr[0]))
            //                    dr[LOCATION_FINAL] = Convert.ToString(drTemp[locationArr[0]]);
            //                if (locationArr.Length > 1 && ds.Tables[0].Columns.Contains(locationArr[1]))
            //                    dr[LOCATION_FINAL] = " And " + Convert.ToString(drTemp[locationArr[1]]);
            //                if (ds.Tables[0].Columns.Contains(LONGITUDE_CSV))
            //                    dr[LONGITUDE_FINAL] = drTemp[LONGITUDE_CSV];
            //                if (ds.Tables[0].Columns.Contains(LATITUDE_CSV))
            //                    dr[LATITUDE_FINAL] = drTemp[LATITUDE_CSV];
            //                if (ds.Tables[0].Columns.Contains(LINK_CSV))
            //                    dr[LINK_FINAL] = drTemp[LINK_CSV];

            //                dr["City"] = city;

            //                finalData.Rows.Add(dr);
            //            }
            //        }
            //    }
            //    gridUploadedData.DataSource = null;
            //    if (finalData != null && finalData.Rows.Count > 0)
            //    {
            //        finalData = finalData.AsEnumerable().OrderBy(x => Convert.ToString(x["City"])).ThenBy(x => Convert.ToString(x[LOCATION_FINAL])).CopyToDataTable();
            //        gridUploadedData.DataSource = finalData;
            //        MessageBox.Show("Data Uploaded Successfully.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No data in file.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    gridUploadedData.DataSource = null;
            //    MessageBox.Show("Failed while populating grid data with error : " + Environment.NewLine + ex.ToString());
            //}
            //finally
            //{
            //}
        }

        private void btnXMLUpload_Click(object sender, EventArgs e)
        {
            //var FD = new OpenFileDialog();
            //if (FD.ShowDialog() == DialogResult.OK)
            //{
            //    string fileToOpen = FD.FileName;
            //    lblXMLLoc.Text = fileToOpen;
            //    if (fileToOpen.EndsWith(".xml"))
            //    {
            //        isXmlLoadedData = true;
            //        xmlLoadedData = fileToOpen;
            //    }
            //    else
            //    {
            //        isXmlLoadedData = false;
            //        MessageBox.Show("File format incorrect.");
            //    }
            //}
        }

        private void btnJSONUpload_Click(object sender, EventArgs e)
        {
            //var FD = new OpenFileDialog();
            //if (FD.ShowDialog() == DialogResult.OK)
            //{
            //    string fileToOpen = FD.FileName;
            //    lblJSONLoc.Text = fileToOpen;
            //    if (fileToOpen.EndsWith(".json"))
            //    {
            //        isJsonLoadedData = true;
            //        jsonLoadedData = fileToOpen;
            //    }
            //    else
            //    {
            //        isJsonLoadedData = false;
            //        jsonLoadedData = string.Empty;
            //        MessageBox.Show("File format incorrect.");
            //    }
            //}
        }

        private void btnCSVUpload_Click(object sender, EventArgs e)
        {
            //var FD = new OpenFileDialog();
            //if (FD.ShowDialog() == DialogResult.OK)
            //{
            //    string fileToOpen = FD.FileName;
            //    lblCSVLoc.Text = fileToOpen;
            //    if (fileToOpen.EndsWith(".csv"))
            //    {
            //        isCsvLoadedData = true;
            //        csvLoadedData = fileToOpen;
            //    }
            //    else
            //    {
            //        isCsvLoadedData = false;
            //        MessageBox.Show("File format incorrect.");
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RefreshGridData();
        }

        private void btnViewXMLData_Click(object sender, EventArgs e)
        {
            //DataTable xmlData;
            //DataSet xmlDataSet = new DataSet();

            //gridUploadedData.DataSource = null;
            //if (!isXmlLoadedData)
            //{
            //    MessageBox.Show("Location not provided or is incorrect");
            //    return;
            //}

            //xmlDataSet.ReadXml(xmlLoadedData);

            //xmlData = xmlDataSet.Tables[0];
            //if (xmlDataSet != null && xmlDataSet.Tables.Count > 0)
            //{
            //    xmlData = xmlData.AsEnumerable().OrderBy(x => Convert.ToString(x[LOCATION_XML])).CopyToDataTable();
            //    gridUploadedData.DataSource = xmlData;
            //    MessageBox.Show("Data Uploaded Successfully.");
            //}
            //else
            //    MessageBox.Show("No data in file.");
        }

        private void btnViewJSONData_Click(object sender, EventArgs e)
        {
            //DataTable jsonData = new DataTable();

            //gridUploadedData.DataSource = null;
            //if (!isJsonLoadedData)
            //{
            //    MessageBox.Show("Location not provided or is incorrect");
            //    return;
            //}

            //string jsonFileData = File.ReadAllText(jsonLoadedData);
            //if (string.IsNullOrEmpty(jsonFileData))
            //{
            //    MessageBox.Show("No data in file");
            //    return;
            //}

            //object lstJSONData = new JavaScriptSerializer().DeserializeObject(jsonFileData);
            //IList list = (IList)lstJSONData;

            //if (list.Count > 0)
            //{
            //    Dictionary<string, object> dictJSONDataScema = new Dictionary<string, object>((Dictionary<String, Object>)list[0], StringComparer.OrdinalIgnoreCase);
            //    foreach (string key in dictJSONDataScema.Keys)
            //    {
            //        if (!jsonData.Columns.Contains(key))
            //            jsonData.Columns.Add(key);
            //    }
            //    foreach (var item in list)
            //    {
            //        Dictionary<string, object> dictJSONData = new Dictionary<string, object>((Dictionary<String, Object>)item, StringComparer.OrdinalIgnoreCase);

            //        DataRow dr = jsonData.NewRow();
            //        foreach (KeyValuePair<string, object> kvp in dictJSONData)
            //        {
            //            if (jsonData.Columns.Contains(kvp.Key))
            //                dr[kvp.Key] = kvp.Value;
            //        }

            //        jsonData.Rows.Add(dr);
            //    }
            //    jsonData = jsonData.AsEnumerable().OrderBy(x => Convert.ToString(x[LOCATION_JSON])).CopyToDataTable();
            //    if (jsonData != null)
            //        gridUploadedData.DataSource = jsonData;
            //    MessageBox.Show("Data Uploaded Successfully.");
            //}
            //else
            //    MessageBox.Show("No data in file.");
        }

        private void btnViewCSVData_Click(object sender, EventArgs e)
        {
            //DataTable csvData;

            //gridUploadedData.DataSource = null;
            //if (!isCsvLoadedData)
            //{
            //    MessageBox.Show("Location not provided or is incorrect");
            //    return;
            //}

            //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + Path.GetDirectoryName(csvLoadedData) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");

            //conn.Open();

            //OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(csvLoadedData) + "]", conn);

            //DataSet ds = new DataSet("Temp");
            //adapter.Fill(ds);

            //conn.Close();

            //csvData = ds.Tables[0];
            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    string[] locationArr = LOCATION_CSV.Split('|');
            //    if (locationArr.Length > 1)
            //        csvData = csvData.AsEnumerable().OrderBy(x => Convert.ToString(x[locationArr[0]])).ThenBy(x => Convert.ToString(x[locationArr[1]])).CopyToDataTable();
            //    else
            //        csvData = csvData.AsEnumerable().OrderBy(x => Convert.ToString(x[locationArr[0]])).CopyToDataTable();
            //    gridUploadedData.DataSource = csvData;
            //    MessageBox.Show("Data Uploaded Successfully.");
            //}
            //else
            //    MessageBox.Show("No data in file.");
        }
        #endregion
    }
}
