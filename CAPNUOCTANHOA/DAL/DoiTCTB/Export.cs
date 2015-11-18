using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;
using aejw.Network;
using log4net;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.VisualStyles;

namespace CAPNUOCTANHOA.DAL.DoiTCTB
{
    class Export
    {
        public static string export(DataGridView dataGridView1,string quy)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\TONGHOPTHAY.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            //exSheet.Name = ky + "." + nam;
            //exSheet.Cells[4, 5] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[5, 1] = "BẢNG KÊ TỔNG HỢP DANH SÁCH KHÁCH HÀNG THAY ĐỒNG HỒ NƯỚC ĐỊNH KỲ QUÝ "+quy;
            int rows = 10;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string STT = dataGridView1.Rows[i].Cells["G_STT"].Value + "";
                string G_TENKH = dataGridView1.Rows[i].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataGridView1.Rows[i].Cells["G_DIACHI"].Value + "";
                string G_DANHBO = dataGridView1.Rows[i].Cells["G_DANHBO"].Value + "";
                string LOAIDHN = dataGridView1.Rows[i].Cells["LOTRINH"].Value +" ("+ dataGridView1.Rows[i].Cells["LoaiDH"].Value +")";
                string C_VATTU = dataGridView1.Rows[i].Cells["C_VATTU"].Value + "";
                string C_NHANCONG = dataGridView1.Rows[i].Cells["C_NHANCONG"].Value + "";
                string TONGCONG = dataGridView1.Rows[i].Cells["TONGCONG"].Value + "";
                string NGAYTHAY = dataGridView1.Rows[i].Cells["NGAYTHAY"].Value + "";
                string G_GHICHU = dataGridView1.Rows[i].Cells["G_GHICHU"].Value + "";
                string DOTBG = dataGridView1.Rows[i].Cells["DOTBG"].Value + "";
                
                exSheet.Cells[rows, 1] = STT;
                exSheet.Cells[rows, 2] = G_TENKH;
                exSheet.Cells[rows, 3] = G_DIACHI;
                exSheet.Cells[rows, 4] = G_DANHBO;
                exSheet.Cells[rows, 5] = LOAIDHN;
                exSheet.Cells[rows, 6] = C_VATTU;
                exSheet.Cells[rows, 7] = C_NHANCONG;
                exSheet.Cells[rows, 8] = TONGCONG;
                exSheet.Cells[rows, 9] = NGAYTHAY;
                exSheet.Cells[rows, 10] = G_GHICHU;

               

                rows++;

            }

            string file = "DANH SÁCH KHÁCH HÀNG THAY ĐỒNG HỒ NƯỚC ĐỊNH KỲ QUÝ " + quy;
            exApp.Visible = false;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.FileName = file;
            saveFileDialog1.DefaultExt = ".xls";
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            string path = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName; ;
                exBook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false,
                    ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                    false, false, false, false, false);
            }


            exBook.Close(false, false, false);
            exApp.Visible = false;
            //string path = "C:\\ThayDoiPhienLoTrinh." + ky + "." + nam + ".xls";
            //exBook.SaveAs(path.Replace("\\\\", "\\"), ExcelCOM.XlFileFormat.xlWorkbookNormal,
            //    null, null, false, false,
            //    ExcelCOM.XlSaveAsAccessMode.xlExclusive,
            //    false, false, false, false, false);
            //exBook.Close(false, false, false);
            //exApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            return path;
        }

    }
}