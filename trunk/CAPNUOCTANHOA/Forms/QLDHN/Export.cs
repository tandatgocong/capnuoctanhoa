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
namespace CAPNUOCTANHOA.Forms.QLDHN
{
    class Export
    {
        public static string export(DataGridView dataGridView1, int ky, int nam)
        {
            ExcelCOM.Application exApp = new ExcelCOM.Application();
            string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\LOTRINH.xls";
            ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
            ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];


            exSheet.Name = "th_dc_malotrinh " + (ky < 10 ? "0" + ky : ky+"") + "." + nam;
            string hieuluc_ky = (ky<10? "0"+ky:ky+"") + "/" + nam;
         //   exSheet.Cells[4, 5] = "TP.Hồ Chí Minh, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            int rows = 2;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                //string stt = dataGridView1.Rows[i].Cells["DC_STT"].Value + "";
                string dbo = dataGridView1.Rows[i].Cells["DC_DANHBO"].Value + "";
                string lotrinhMoi = dataGridView1.Rows[i].Cells["DC_LOTRINHMOI"].Value + "";
                string lotrinhCu = dataGridView1.Rows[i].Cells["DC_LT_CU"].Value + "";

                string dot_cu = lotrinhCu.Substring(0, 2);
                string dot_moi = lotrinhMoi.Substring(0, 2);
                string so_moi = lotrinhMoi.Substring(2, 2);
                string stt_moi = lotrinhMoi.Substring(4, 5);
                string pgcs_moi=lotrinhMoi;
                string pgcs_cu=lotrinhCu;
                exSheet.Cells[rows, 4] = dbo.Replace(" ","");
                exSheet.Cells[rows,5] = dot_cu;                
                exSheet.Cells[rows,6] = dot_moi;
                exSheet.Cells[rows, 7] = so_moi;
                exSheet.Cells[rows, 8] = stt_moi;
                exSheet.Cells[rows, 9] = pgcs_moi;
                exSheet.Cells[rows, 10] = pgcs_cu;
                exSheet.Cells[rows, 11] = hieuluc_ky;
                         
                
                rows++;

            }
            //rows = rows + 1;
            //exSheet.Cells[rows, 2] = "Trân trọng kính chào !";
            //exSheet.Cells[rows + 1, 2] = "* Nơi Nhận";
            //exSheet.Cells[rows + 2, 2] = "  - Như trên.";
            //exSheet.Cells[rows + 3, 2] = "  - Đội Thu Tiền để biết.";
            //exSheet.Cells[rows + 4, 2] = "  - Ban KTKS để biết.";
            //exSheet.Cells[rows + 5, 2] = "  - Lưu.";

            //exSheet.Cells[rows, 6] = "KT.GIÁM ĐỐC";
            //exSheet.Cells[rows + 1, 6] = "PHÓ GIÁM ĐỐC KINH DOANH";
            //exSheet.Cells[rows + 3, 6] = "  (đã ký)";
            //exSheet.Cells[rows + 5, 6] = " LÊ VĂN SƠN ";

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
