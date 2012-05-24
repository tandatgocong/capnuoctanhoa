using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;
using aejw.Network;
using log4net;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.VisualStyles;
namespace CAPNUOCTANHOA.Forms.QLDHN
{
    class Export
    {
        public static string export(DataGridView dataGridView1)
        {
            int ky = DateTime.Now.Month + 1;
            int nam = DateTime.Now.Year;
            if (ky == 12)
            {
                ky = 1;
                nam = nam + 1;
            }
            else { ky = ky + 1; }
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\LOTRINH.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

            exSheet.Name = ky + "." + nam;
            exSheet.Cells[4, 5] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            int rows = 16;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                string stt = dataGridView1.Rows[i].Cells["DC_STT"].Value + "";
                string danhbo = dataGridView1.Rows[i].Cells["DC_DANHBO"].Value + "";
                string lotrinhMoi = dataGridView1.Rows[i].Cells["DC_LOTRINHMOI"].Value + "";
                string lotrinhCu = dataGridView1.Rows[i].Cells["DC_LT_CU"].Value + "";
                exSheet.Cells[rows, 2] = stt;
                exSheet.Cells[rows,3] = danhbo;
                exSheet.Cells[rows,4] = lotrinhMoi;
                exSheet.Cells[rows, 5] = lotrinhCu;
                rows++;

            }
            rows = rows + 1;
            exSheet.Cells[rows, 2] = "Trân trọng kính chào !";
            exSheet.Cells[rows + 1, 2] = "* Nơi Nhận";
            exSheet.Cells[rows + 2, 2] = "  - Như trên.";
            exSheet.Cells[rows + 3, 2] = "  - Đội Thu Tiền để biết.";
            exSheet.Cells[rows + 4, 2] = "  - Ban KTKS để biết.";
            exSheet.Cells[rows + 5, 2] = "  - Lưu.";

            exSheet.Cells[rows, 6] = "KT.GIÁM ĐỐC";
            exSheet.Cells[rows + 1, 6] = "PHÓ GIÁM ĐỐC KINH DOANH";


            //ExcelCOM.Range tR;
            //tR = exSheet.get_Range("X11", "X" + (rows - 1));
            //tR.VerticalAlignment = ExcelCOM.XlVAlign.xlVAlignCenter;
            //tR.ShrinkToFit = false;
            //tR.MergeCells = true;
            //tR.Value2 = "Sau khi thi công xong(chậm nhất là 48 giờ tính từ khi bắt đầu khởi công)";
            string file = "ThayDoiPhienLoTrinh." + ky + "." + nam + ".xls";
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
