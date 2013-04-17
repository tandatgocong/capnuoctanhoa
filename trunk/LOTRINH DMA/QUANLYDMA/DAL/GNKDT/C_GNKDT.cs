using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.GNKDT
{
    class C_GNKDT
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_GNKDT).Name);

        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable getThongTinDMAByHoaDon(string madma, string ky, string nam)
        {

            string query = "  SELECT DISTINCT tb1.*, tb2.CHUKY, tb2.CODE,tb2.LNCC,(convert(float,tb2.LNCC)/tb2.CHUKY) as 'TBTT' ";
            query += "       FROM (SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, '' 'HIEULUC' ";
            query += "              FROM TB_DULIEUKHACHHANG WHERE MADMA='" + madma + "'";
            query += "              UNION ";
            query += "              SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC , N'Hủy' as 'HIEULUC' ";
            query += "              FROM TB_DULIEUKHACHHANG_HUYDB WHERE MADMA='"+madma+"'";
            query += "             ) as tb1 ";
            query += "   INNER JOIN  HOADONTH" + ky + "_" + nam + " tb2 ";
            query += "   ON tb1.DANHBO = tb2.DANHBO";
            query += "   ORDER BY LOTRINH";
            return DAL.LinQConnection.getDataTable(query);
        }

        public static DataTable getThongTinDMAByHandheld(string madma, string ky, string nam)
        {

            string query = "    SELECT DISTINCT tb1.*, tb2.CODE,tb2.TIEUTHU as 'LNCC',(convert(float,tb2.TIEUTHU)/tb1.CHUKYDS) as 'TBTT' ";
            query += "   FROM (SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, '' 'HIEULUC',CHUKYDS  ";
            query += "         FROM TB_DULIEUKHACHHANG WHERE MADMA='" + madma + "'";
            query += "   UNION  ";
            query += "   SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC , N'Hủy' as 'HIEULUC',CHUKYDS  ";
            query += "         FROM TB_DULIEUKHACHHANG_HUYDB WHERE MADMA='" + madma + "'";
            query += "   ) as tb1  ";
            query += "   INNER JOIN  [DocSo_PHT].[dbo].[DS" + nam + "] tb2 ";
            query += "   ON tb1.DANHBO = tb2.DANHBA ";
            query += "   where tb2.KY=" + ky;
            query += "   ORDER BY LOTRINH";
            return DAL.LinQConnection.getDataTable(query);
        }
    }
}