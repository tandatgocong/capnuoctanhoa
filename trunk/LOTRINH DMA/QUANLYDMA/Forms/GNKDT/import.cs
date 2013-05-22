using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace CAPNUOCTANHOA.Forms.GNKDT
{
    class import
    {
        public string ImportFile(string duongdan)
        {
            string msg = "Import DMA Sheet ";
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
           Excel.Worksheet xlWorkSheet;
           Excel.Range range;
           

            int rCnt = 0;


            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(duongdan, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            int soSheet = xlWorkBook.Worksheets.Count;

            for (int isheet = 1; isheet <= soSheet; isheet++)
            {

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(isheet);
                string nameSheet = "TH-" + xlWorkSheet.Name;

                range = xlWorkSheet.UsedRange;
                if (checkFormat(range) == false)
                {
                   
                    releaseObject(xlWorkSheet);
                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    return (msg + " thành công !, Sheet " + nameSheet + " thất bại !");
                }
                else
                {
                    for (rCnt = 4; rCnt <= range.Rows.Count; rCnt++)
                    {

                        string maDanhBo = (range.Cells[rCnt, 2] as Excel.Range).Value2.ToString();

                        DAL.DULIEUKH.C_DuLieuKhachHang.CapNhatKHTheoDB(maDanhBo, nameSheet);


                    }
                    msg += nameSheet + ",";
                    releaseObject(xlWorkSheet);
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();


            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            
            return msg;
        }
        private bool checkFormat(Excel.Range range)
        {
            bool kq = true;
            if ((string)(range.Cells[3, 1] as Excel.Range).Value2 != "STT")
                return false;
            if ((string)(range.Cells[3, 2] as Excel.Range).Value2 != "DANHBO")
                return false;
            if ((string)(range.Cells[3, 3] as Excel.Range).Value2 != "CODH")
                return false;
            if ((string)(range.Cells[3, 4] as Excel.Range).Value2 != "HOPDONG")
                return false;
            if ((string)(range.Cells[3, 5] as Excel.Range).Value2 != "TENKH")
                return false;
            if ((string)(range.Cells[3, 6] as Excel.Range).Value2 != "SONHA")
                return false;
            if ((string)(range.Cells[3, 7] as Excel.Range).Value2 != "DUONG")
                return false;
            if ((string)(range.Cells[3, 8] as Excel.Range).Value2 != "GIABIEU")
                return false;
            if ((string)(range.Cells[3, 9] as Excel.Range).Value2 != "DINHMUC")
                return false;
            if ((string)(range.Cells[3, 10] as Excel.Range).Value2 != "GHICHU")
                return false;
            return kq;

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch 
            {
                obj = null;
               
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
