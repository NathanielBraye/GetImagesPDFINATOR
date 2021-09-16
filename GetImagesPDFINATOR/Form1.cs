using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImagesPDFINATOR
{
    public partial class Form1 : Form
    {

        //parameters
        public string oldSelectedPath = ConfigurationManager.AppSettings["OldSelectedPath"]; //Send back to where you have done your treatement while cliking buton

        public string filePathOfexe = System.Reflection.Assembly.GetEntryAssembly().Location;

        public string filePath = string.Empty;


        public List<string> pdfList = new List<string>();

        //    public List<MainFolderPath> mainFolderPathList = new List<MainFolderPath>();

        public List<MainFolderPath> historiqueLogList = new List<MainFolderPath>();


        //ID log historique
        public int idlog = 0;

        public int idExtract = 1;

        public Form1()
        {
            InitializeComponent();

            filePathOfexe = Path.GetDirectoryName(filePathOfexe) + @"\";

            if (!File.Exists(filePathOfexe + "GetImagesPDFINATOR.exe.config"))
            {
                File.Create(filePathOfexe + "GetImagesPDFINATOR.exe.config").Close();
                string tmpstringBase = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "\n" +
                                        "<configuration>" + "\n" +
                                        "<startup>" + "\n" +
                                        "<supportedRuntime version = \"v4.0\" sku=\".NETFramework,Version=v4.8\"/>" + "\n" +
                                        "</startup>" + "\n" +
                                        "<appSettings> " + "\n" +
                                        "<add key =\"OldSelectedPath\" value = \"\" /> " + "\n" +
                                        "<add key = \"ClientSettingsProvider.ServiceUri\" value = \"\" />" + "\n" +
                                        "</appSettings>" + "\n" +
                                        "<system.web>" + "\n" +
                                        "<membership defaultProvider = \"ClientAuthenticationMembershipProvider\">" + "\n" +
                                        "<providers>" + "\n" +
                                        "<add name = \"ClientAuthenticationMembershipProvider\" type=\"System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri = \"\" /> " + "\n" +
                                        "</providers>" + "\n" +
                                        "</membership>" + "\n" +
                                        "<roleManager defaultProvider = \"ClientRoleProvider\" enabled = \"true\" > " + "\n" +
                                        "<providers>" + "\n" +
                                        "<add name = \"ClientRoleProvider\" type = \"System.Web.ClientServices.Providers.ClientRoleProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri=\"\" cacheTimeout=\"86400\" />" + "\n" +
                                        "</providers>" + "\n" +
                                        "</roleManager>" + "\n" +
                                        "</system.web>" + "\n" +
                                        "</configuration>" + "\n";
                WriteTxt(tmpstringBase, filePathOfexe + "GetImagesPDFINATOR.exe.config");
            }

            DataGridView();
            prepareHistorique();

        }

        private void prepareHistorique()
        {
            if (!Directory.Exists(filePathOfexe + @"HistoriqueFolder"))
            {
                Directory.CreateDirectory(filePathOfexe + @"HistoriqueFolder");
            }

            if (!File.Exists(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt"))
            {
                //Create
                File.Create(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt").Close();
            }

            loadTxtToHistoriqueLogList();

            loadLogDataGridView();
        }

        private void loadTxtToHistoriqueLogList()
        {
            try
            {
                string text = File.ReadAllText(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");
                if (text != null && text != "")
                {
                    text = text.Replace("\r\n", "").Replace("\r", "");

                    string[] historiques = text.Split(new string[] { "\n" }, StringSplitOptions.None);
                    historiques = historiques.Where((item, index) => index != historiques.Length - 1).ToArray();


                    foreach (string historique in historiques)
                    {
                        string[] values = historique.Split(new string[] { "," }, StringSplitOptions.None);

                        MainFolderPath mainFolderPath = new MainFolderPath();
                        int i = 0;

                        foreach (string value in values)
                        {

                            if (i == 0)
                            {
                                mainFolderPath.id = Int32.Parse(value);
                            }
                            else if (i == 1)
                            {
                                mainFolderPath.name = value;
                            }
                            else if (i == 2)
                            {
                                mainFolderPath.date = Convert.ToDateTime(value);
                            }

                            i++;
                        }
                        historiqueLogList.Add(mainFolderPath);
                        idlog = mainFolderPath.id;
                    }
                }
            }
            catch (Exception ex)
            {
                List<MainFolderPath> newList = new List<MainFolderPath>();

                File.Delete(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");
                File.Create(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt").Close();

                historiqueLogList = newList;
                this.idlog = 0;
            }



        }

        private void DataGridView()
        {
            // Create an unbound DataGridView by declaring a column count.
            pdfsDataGridView.ColumnCount = 3;
            pdfsDataGridView.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 7, FontStyle.Bold);
            pdfsDataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            pdfsDataGridView.Columns[0].Name = "ID";
            pdfsDataGridView.Columns[1].Name = "PDF(s)";
            pdfsDataGridView.Columns[2].Name = "Path";


            pdfsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pdfsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pdfsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            pdfsDataGridView.Rows.Clear();


            ///////////////////////
            // Create an unbound DataGridView by declaring a column count.
            historiqueDataGridView.ColumnCount = 4;
            historiqueDataGridView.ColumnHeadersVisible = true;

            columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 7, FontStyle.Bold);
            historiqueDataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            historiqueDataGridView.Columns[0].Name = "ID";
            historiqueDataGridView.Columns[1].Name = "OldMainFolderTreated";
            historiqueDataGridView.Columns[2].Name = "Date";
            historiqueDataGridView.Columns[3].Name = "ALIVE";

            historiqueDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historiqueDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            historiqueDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            historiqueDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            historiqueDataGridView.Rows.Clear();

        }

        #region Button

        private void SelectPDFsButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "pdf (*.PDF)|*.PDF;";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (Directory.Exists(oldSelectedPath))
                {
                    openFileDialog.InitialDirectory = oldSelectedPath;
                }


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] pdfs = openFileDialog.FileNames;



                    filePath = openFileDialog.FileName;

                    //DefaultPathChanger
                    DirectoryInfo d = new DirectoryInfo(filePath);
                    string changefilePath = Path.GetDirectoryName(d.FullName);
                    SetSetting("OldSelectedPath", changefilePath);

                    mainFolderPathLabel.Text = changefilePath;
                    filePath = changefilePath;


                    TraitementPDFs(pdfs);

                    //  MessageBox.Show(this,"Vos images ont été fusionnées !", "Fusion gif", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // MessageBox.Show(this,"Sélectionner un gif!", "Fusion gif", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void goToMainFolderButton_Click(object sender, EventArgs e)
        {
            if (filePath != null && filePath != "")
            {
                if (Directory.Exists(filePath))
                {
                    Process.Start("explorer.exe", filePath);
                }
                //pictureBox1.Image.Dispose();
                //pictureBox1.Image = null;
                //pictureBox1.ImageLocation = null;
            }
        }

        private void TraitementPDFs(string[] pdfs)
        {

            //pdfsDataGridView.Rows.Clear();
            List<object[]> rows = new List<object[]>();

            foreach (string pdf in pdfs)
            {

                if (pdfList.FindIndex(x => x.Equals(pdf, StringComparison.OrdinalIgnoreCase)) == -1)
                {


                    pdfList.Add(pdf);

                    string[] row = new string[] { idExtract.ToString(), Path.GetFileName(pdf), Path.GetDirectoryName(pdf) };
                    rows.Add(row);
                    idExtract++;


                }
            }

            if (rows.Count != 0)
            {
                foreach (string[] rowArray in rows)
                {
                    pdfsDataGridView.Rows.Add(rowArray);
                }
            }
        }

        private void extractButton_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            foreach (string pdf in pdfList)
            {

                CreateFolder(Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf));
                /*
                if(!File.Exists(Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf) + @"\" + Path.GetFileName(pdf)))
                {
                    File.Copy(pdf, Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf) + @"\" + Path.GetFileName(pdf));
                }

                ExtractJpeg(Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf) + @"\" + Path.GetFileName(pdf));
                */

                ExtractJpeg(Path.GetDirectoryName(pdf) + @"\" + Path.GetFileName(pdf));

                //ExtractImagesFromPDF(Path.GetDirectoryName(pdf) + @"\" + Path.GetFileName(pdf), Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf));

                int index = historiqueLogList.FindIndex(x => Path.GetFileNameWithoutExtension(x.name).Equals(Path.GetFileNameWithoutExtension(pdf), StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                {
                    CreateHlog(idlog + 1, Path.GetDirectoryName(pdf) + @"\" + Path.GetFileNameWithoutExtension(pdf), date);
                }
                else
                {
                    historiqueLogList[index].date = date;
                    loadLogDataGridView();
                }


            }


            pdfsDataGridView.Rows.Clear();
            idExtract = 1;
            pdfList.Clear();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadLogDataGridView();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            pdfList.Clear();
            pdfsDataGridView.Rows.Clear();

            loadLogDataGridView();
        }

        #endregion

        #region appConfig modifier...
        private static void SetSetting(string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        #endregion
        #region Tool

        //Choisit un nombre entre min => Max
        public int RandomNumber(int min, int max)
        {
            Random r = new Random();
            int go = r.Next(min, max);
            return go;
        }
        //Write in a file TXT text
        public void WriteTxt(string[] Datatxt, string pathString)
        {
            using (StreamWriter sw = File.AppendText(pathString))
            {
                foreach (string txt in Datatxt)
                {
                    sw.WriteLine(txt);
                }
                sw.Close();
                sw.Dispose();
            }
        }
        public void WriteTxt(string txt, string pathString)
        {
            using (StreamWriter sw = File.AppendText(pathString))
            {
                sw.WriteLine(txt);
                sw.Close();
                sw.Dispose();
            }
        }
        private void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private void CreateRemoveFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }

        }



        #endregion

        private void ClearDeadPathButton_Click(object sender, EventArgs e)
        {
            List<MainFolderPath> newList = new List<MainFolderPath>();
            int i = 0;
            foreach (MainFolderPath hlog in historiqueLogList)
            {
                if (hlog.alive == true)
                {
                    hlog.id = i;
                    newList.Add(hlog);
                    i++;
                }
            }

            historiqueLogList = newList;

            if (!File.Exists(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt"))
            {
                //Create
                File.Create(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt").Close();
            }
            else
            {
                File.Delete(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");
                File.Create(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt").Close();
            }

            foreach (MainFolderPath hlog in historiqueLogList)
            {
                WriteTxt(hlog.ToString(), filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");

            }
            this.idlog = i - 1;

            loadLogDataGridView();

        }

        private void cleanHistoriqueButton_Click(object sender, EventArgs e)
        {
            List<MainFolderPath> newList = new List<MainFolderPath>();

            File.Delete(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");
            File.Create(filePathOfexe + @"HistoriqueFolder" + @"\historique.txt").Close();

            historiqueLogList = newList;

            this.idlog = 0;

            loadLogDataGridView();

        }

        private void CreateHlog(int idlog, string pathFile, DateTime date)
        {

            MainFolderPath hlog = new MainFolderPath(idlog, pathFile, date);
            historiqueLogList.Add(hlog);

            WriteTxt(hlog.ToString(), filePathOfexe + @"HistoriqueFolder" + @"\historique.txt");
            loadLogDataGridView();

            this.idlog = idlog++;

        }

        private void loadLogDataGridView()
        {
            historiqueDataGridView.Rows.Clear();

            List<object[]> rows = new List<object[]>();

            if (historiqueLogList.Count != 0)
            {
                foreach (MainFolderPath hlog in historiqueLogList)
                {
                    hlog.alive = true;
                    string alive = "yes";

                    if (!Directory.Exists(hlog.name))
                    {
                        hlog.alive = false;
                        alive = "no";
                    }

                    string[] row = new string[] { hlog.id.ToString(), hlog.name.ToString(), hlog.date.ToString(), alive.ToString() };
                    rows.Add(row);
                }
            }


            if (rows.Count != 0)
            {
                foreach (string[] rowArray in rows)
                {
                    historiqueDataGridView.Rows.Add(rowArray);
                }
            }
        }


        void ExtractJpeg(string file)
        {
            var dir1 = Path.GetDirectoryName(file);
            var fn = Path.GetFileNameWithoutExtension(file);
            var dir2 = Path.Combine(dir1, fn);
            if (!Directory.Exists(dir2)) Directory.CreateDirectory(dir2);

            var pdf = new PdfReader(file);
            int n = pdf.NumberOfPages;
            for (int i = 1; i <= n; i++)
            {
                var pg = pdf.GetPageN(i);
                var res = PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES)) as PdfDictionary;
                var xobj = PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT)) as PdfDictionary;
                if (xobj == null) continue;//empty pdf

                var keys = xobj.Keys;
                if (keys.Count == 0) continue;//no images pdf

                for (int j = 0; j <= keys.Count; j++)
                {
                    if (j != keys.Count)
                    {

                        var obj = xobj.Get(keys.ElementAt(j));
                        if (!obj.IsIndirect()) continue;

                        var tg = PdfReader.GetPdfObject(obj) as PdfDictionary;
                        var type = PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE)) as PdfName;
                        if (!PdfName.IMAGE.Equals(type)) continue;

                        int XrefIndex = (obj as PRIndirectReference).Number;
                        var pdfStream = pdf.GetPdfObject(XrefIndex) as PRStream;
                        var data = PdfReader.GetStreamBytesRaw(pdfStream);
                        var jpeg = Path.Combine(dir2, string.Format("page" + i + "{0:000}.jpg", j));
                        File.WriteAllBytes(jpeg, data);

                    }
                }
            }
        }


        private void historiqueDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = historiqueDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = historiqueDataGridView.Rows[selectedrowindex];

            string filePath = Convert.ToString(selectedRow.Cells["OldMainFolderTreated"].Value);

            if (Directory.Exists(filePath))
            {
                Process.Start("explorer.exe", filePath);
            }


        }

        private void pdfsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = pdfsDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = pdfsDataGridView.Rows[selectedrowindex];

            string filePath = Convert.ToString(selectedRow.Cells["Path"].Value);

            if (Directory.Exists(filePath))
            {
                Process.Start("explorer.exe", filePath);
            }

        }


        public static void ExtractImagesFromPDF(string sourcePdf, string outputPath)
        {
            // NOTE:  This will only get the first image it finds per page.
            PdfReader pdf = new PdfReader(sourcePdf);
            RandomAccessFileOrArray raf = new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf);

            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);

                    // recursively search pages, forms and groups for images.
                    PdfObject obj = FindImageInPDFDictionary(pg);
                    if (obj != null)
                    {

                        int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                        PdfStream pdfStrem = (PdfStream)pdfObj;
                        byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                        if ((bytes != null))
                        {
                            using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
                            {
                                memStream.Position = 0;
                                System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                                // must save the file while stream is open.
                                if (!Directory.Exists(outputPath))
                                    Directory.CreateDirectory(outputPath);

                                string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", pageNumber));
                                System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                                parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                                System.Drawing.Imaging.ImageCodecInfo jpegEncoder = GetImageEncoder("JPEG");
                                img.Save(path, jpegEncoder, parms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
                Console.WriteLine(ex.Message.ToString() + "\n\n" + ex.ToString() + "\n\n");

            }
            finally
            {
                pdf.Close();
                raf.Close();
            }
        }

        private static PdfObject FindImageInPDFDictionary(PdfDictionary pg)
        {
            PdfDictionary res =
                (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));


            PdfDictionary xobj =
              (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            if (xobj != null)
            {
                foreach (PdfName name in xobj.Keys)
                {

                    PdfObject obj = xobj.Get(name);
                    if (obj.IsIndirect())
                    {
                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);

                        PdfName type =
                          (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));

                        //image at the root of the pdf
                        if (PdfName.IMAGE.Equals(type))
                        {
                            return obj;
                        }// image inside a form
                        else if (PdfName.FORM.Equals(type))
                        {
                            return FindImageInPDFDictionary(tg);
                        } //image inside a group
                        else if (PdfName.GROUP.Equals(type))
                        {
                            return FindImageInPDFDictionary(tg);
                        }

                    }
                }
            }

            return null;

        }


        #region GetImageEncoder
        public static System.Drawing.Imaging.ImageCodecInfo GetImageEncoder(string imageType)
        {
            imageType = imageType.ToUpperInvariant();
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
            {
                if (info.FormatDescription == imageType)
                {
                    return info;
                }
            }
            return null;
        }
        #endregion











    }
}
