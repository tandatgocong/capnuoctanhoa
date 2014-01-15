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

namespace CAPNUOCTANHOA.Forms.GNKDT
{
    class Export
    {
        public static string export(DataGridView dataGridView1,string dma, string ky, string nam)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\LOTRINH.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            //exSheet.Name = ky + "." + nam;
            //exSheet.Cells[4, 5] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Cells[1, 1] = "DANH SÁCH NHỮNG ĐỒNG HỒ NƯỚC TRONG VÙNG DMA " + dma + " KỲ " + ky + "/"+nam;
            int rows = 4;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string STT =dataGridView1.Rows[i].Cells["STT"].Value + "";
                string DANHBO=dataGridView1.Rows[i].Cells["DANHBO"].Value + "";
                string CODH=dataGridView1.Rows[i].Cells["CODHN"].Value + "";
                string HOPDONG=dataGridView1.Rows[i].Cells["HOPDONG"].Value + "";
                string TENKH=dataGridView1.Rows[i].Cells["HOTEN"].Value + "";
                string SONHA=dataGridView1.Rows[i].Cells["SONHA"].Value + "";
                string DUONG=dataGridView1.Rows[i].Cells["TENDUONG"].Value + "";
                string GIABIEU=dataGridView1.Rows[i].Cells["GB"].Value + "";
                string DINHMUC=dataGridView1.Rows[i].Cells["DM"].Value + "";
                string CODE=dataGridView1.Rows[i].Cells["CODE"].Value + "";
                string CHUKY=dataGridView1.Rows[i].Cells["CHUKY"].Value + "";
                string SANLUONG=dataGridView1.Rows[i].Cells["TIEUTHU"].Value + "";
                string BINHQUAN=dataGridView1.Rows[i].Cells["BINHQUAN"].Value + "";
                string NAMLD = dataGridView1.Rows[i].Cells["NAMLD"].Value + "";
                string HIEUDH = dataGridView1.Rows[i].Cells["HIEUDH"].Value + "";

                exSheet.Cells[rows, 1] = STT;
                exSheet.Cells[rows, 2] = DANHBO;
                exSheet.Cells[rows, 3] = CODH;
                exSheet.Cells[rows, 4] = HOPDONG;
                exSheet.Cells[rows, 5] = TENKH;
                exSheet.Cells[rows, 6] = SONHA;
                exSheet.Cells[rows, 7] = DUONG;
                exSheet.Cells[rows, 8] = GIABIEU;
                exSheet.Cells[rows, 9] = DINHMUC;
                exSheet.Cells[rows, 10] = CODE;
                exSheet.Cells[rows, 11] = CHUKY;
                exSheet.Cells[rows, 12] = SANLUONG;
                exSheet.Cells[rows, 13] = BINHQUAN;
                exSheet.Cells[rows, 14] = NAMLD;
                exSheet.Cells[rows, 15] = HIEUDH;

                rows++;

            }

            string file = "SAN LUONG DHN TRONG DMA " + dma + ".xls";
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
