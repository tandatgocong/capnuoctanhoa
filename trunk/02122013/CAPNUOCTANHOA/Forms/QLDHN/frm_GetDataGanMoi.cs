using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Configuration;
using ExcelCOM = Microsoft.Office.Interop.Excel;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_GetDataGanMoi : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_GetDataGanMoi()
        {
            InitializeComponent();
            loadCombox();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
        //dataGridView1.DataSource = DAL.OledbConnection.getDataTable(, "SELECT * FROM BAOTHAY  ORDER BY SOBANGKE ASC");
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_GetDataGanMoi).Name);

        void loadCombox()
        {
            string sql = "SELECT DotThiCong FROM [T07 DANH SACH HO SO HOAN CONG] WHERE Right (DotThiCong,2)>='12' AND LEFT (DotThiCong,1)='Q' GROUP BY  DotThiCong";
            DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
            cbDotBangKe.DataSource = table;
            cbDotBangKe.DisplayMember = "DotThiCong";
            cbDotBangKe.ValueMember = "DotThiCong";
            //foreach (var item in table.Rows)
            //{
            //    DataRow r = (DataRow)item;
            //    namesCollection.Add(r["DotThiCong"].ToString());
            //}
            //cbDotBangKe.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cbDotBangKe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbDotBangKe.AutoCompleteCustomSource = namesCollection;
        }
        void formatRows()
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                dataGanMoiBK.Rows[i].Cells["STT"].Value = i + 1;
                if (i % 2 == 0)
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dataGanMoiBK.Rows[i].Cells["DANHBO"].Value = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "") : dataGanMoiBK.Rows[i].Cells["DANHBO"].Value;
                }
                catch (Exception)
                {

                }

            }
        }



        private void btThem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT danhbo,hopdong,HoTen,DiaChi,maPQ FROM [T07 DANH SACH HO SO HOAN CONG] WHERE DotThiCong='" + cbDotBangKe.Text + "' AND danhbo <> '' ORDER BY hopdong ASC ";
            DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
            dataGanMoiBK.DataSource = table;
            formatRows();
        }

        private void next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                string[] row1 = new string[] { "", dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "", dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "" };
                dataGridViewTH.Rows.Add(row1);

            }

            for (int i = 0; i < dataGridViewTH.Rows.Count; i++)
            {
                dataGridViewTH.Rows[i].Cells["TH_STT"].Value = i + 1;
                if (i % 2 == 0)
                {
                    dataGridViewTH.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dataGridViewTH.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void tungdot_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ExcelCOM.Application exApp = new ExcelCOM.Application();
            //    Microsoft.Office.Interop.Excel._Workbook workbook = exApp.Workbooks.Add(Type.Missing);
            //    ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)workbook.Worksheets[1];

            //    //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //    //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //    //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //    //app.Visible = true;
            //    //ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)workbook.Worksheets[1];
            //    //worksheet.Name = "Danh Sach";
            //    //for (int i = 1; i < dataGanMoiBK.Columns.Count + 1; i++)
            //    //{
            //    //    worksheet.Cells[1, i] = dataGanMoiBK.Columns[i - 1].HeaderText;
            //    //}

            //    for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dataGanMoiBK.Columns.Count; j++)
            //        {
            //            exSheet.Cells[i + 2, j + 1] = dataGanMoiBK.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                //  string[] arrFile = Utilities.Files.getFileOnServer();//get file onserver

              //  ExcelCOM.Application exApp = new ExcelCOM.Application();
                ExcelCOM.Application exApp = new ExcelCOM.ApplicationClass();
                System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                exApp.Workbooks.Add();
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

                string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\News.xls";
                ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];


                exSheet.Cells[1, 1] = 0;
                int rows = 2; 
                for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
                {
                    exSheet.Cells[rows, 1] = (dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "").Replace(" ", "");
                    rows++;
                }
                 
                exApp.Visible = false;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text Files";
                saveFileDialog1.DefaultExt = ".xls";
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName; ;
                    exBook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                        null, null, false, false,
                        ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                        false, false, false, false, false);
                }

                exBook.Close(false, false, false);
                exApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            }
            catch (Exception ex)
            {
                log.Error("Export File Loi" + ex.Message);
                MessageBox.Show(this, "Xuất File Lỗi. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void tatCa_Click(object sender, EventArgs e)
        {
            try
            {
                //  string[] arrFile = Utilities.Files.getFileOnServer();//get file onserver

                ExcelCOM.Application exApp = new ExcelCOM.Application();
                string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\News.xls";
                ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];
                int rows = 1; 
                for (int i = 0; i < dataGridViewTH.Rows.Count; i++)
                {
                    exSheet.Cells[rows, 1] = (dataGridViewTH.Rows[i].Cells["TH_DANHBO"].Value + "").Replace(" ", "");
                    rows++;
                }
                 
                exApp.Visible = false;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text Files";
                saveFileDialog1.DefaultExt = ".xls";
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName; ;
                    exBook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                        null, null, false, false,
                        ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                        false, false, false, false, false);
                }

                exBook.Close(false, false, false);
                exApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            }
            catch (Exception ex)
            {
                log.Error("Export File Loi" + ex.Message);
                MessageBox.Show(this, "Xuất File Lỗi. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}