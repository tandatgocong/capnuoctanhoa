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

        public static DataTable getDHN(string madma, string ky, string nam)
        {
            string query = " SELECT LEFT(tb1.HIEUDH,3) as HIEUDHN,CAP,COUNT(*) as SL ";
            query += "      FROM ( SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS,YEAR(NGAYTHAY) AS 'NAMLD',HIEUDH,CAP            ";
            query += "  		FROM TB_DULIEUKHACHHANG WHERE  NAM<=" + nam + " AND KY_<=" + ky + " AND MADMA='" + madma + "'";
            query += "  		 UNION      ";
            query += "  		SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC',CHUKYDS,YEAR(NGAYTHAY) AS 'NAMLD',HIEUDH ,CAP ";
            query += "  		FROM TB_DULIEUKHACHHANG_HUYDB WHERE HIEULUCHUY='" + ky + "/" + nam + "' AND   MADMA='" + madma + "'  ) as tb1       ";
            query += "      GROUP BY LEFT(tb1.HIEUDH,3),CAP  ";

            return DAL.LinQConnection.getDataTable(query.Replace("\t", ""));
        }

        public static DataTable getThongTinDMAByHoaDon(string madma, string ky, string nam)
        {

            string query = "  SELECT T1.*,(CONVERT(VARCHAR,KH.KY)+'/'+CONVERT(VARCHAR,KH.NAM) ) as 'HIEULUC',YEAR(KH.NGAYTHAY) AS 'NAMLD',KH.HIEUDH FROM  ";
            query += "   (  ";
            query += "     SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY tb2.MALOTRINH  DESC) [STT],  tb2.MALOTRINH AS LOTRINH,DANHBA AS DANHBO,tb2.HOPDONG,TENKH AS HOTEN,SO AS SONHA,DUONG AS TENDUONG,tb2.CODH,GB AS GIABIEU, DM AS DINHMUC,   ";
            query += "     DATEDIFF(DD,tb2.TUNGAY,tb2.DENNGAY) as 'CHUKY', tb2.CODE,tb2.TIEUTHU  as 'LNCC' ,(convert(float,tb2.TIEUTHU)/DATEDIFF(DD,tb2.TUNGAY,tb2.DENNGAY)) as 'TBTT'  ";
            query += "      FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] tb2  ";
            query += "               WHERE tb2.MaDMA='" + madma + "' AND tb2.KY=" + ky + " AND tb2.NAM=" + nam;
            query += "   ) AS T1  ";
            query += "  LEFT JOIN TB_DULIEUKHACHHANG KH  ";
            query += "  ON KH.DANHBO= T1.DANHBO  ";
            query += "   ORDER BY LOTRINH ASC ";

            //string query = "  SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY tb2.MALOTRINH  DESC) [STT],  tb2.MALOTRINH AS LOTRINH,DANHBA AS DANHBO,tb2.HOPDONG,TENKH AS HOTEN,SO AS SONHA,DUONG AS TENDUONG,tb2.CODH,GB AS GIABIEU, DM AS DINHMUC,  ";
            //query += "       (CONVERT(VARCHAR,tb2.KY)+'/'+CONVERT(VARCHAR,tb2.NAM) ) as 'HIEULUC',' ' AS 'NAMLD', ' ' AS HIEUDH , DATEDIFF(DD,tb2.TUNGAY,tb2.DENNGAY) as 'CHUKY', tb2.CODE,tb2.TIEUTHU  as 'LNCC' ,(convert(float,tb2.TIEUTHU)/DATEDIFF(DD,tb2.TUNGAY,tb2.DENNGAY)) as 'TBTT' ";
            //query += "              FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] tb2 ";
            //query += "               WHERE tb2.MaDMA='" + madma + "' AND tb2.KY=" + ky + " AND tb2.NAM="+nam;
            //query += "   ORDER BY MALOTRINH ASC ";
            return DAL.LinQConnection.getDataTable(query);
        }
        

        public static DataTable getThongTinDMAByHandheld(string madma, string ky, string nam)
        {

            string query = " SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT], LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC,DATEDIFF(DD,tb2.TUNGAYDOCSO,tb2.DENNGAYDOCSO) as 'CHUKY', HIEULUC ,NAMLD, tb2.CODE,tb2.TIEUTHU as 'LNCC',(convert(float,tb2.TIEUTHU)/DATEDIFF(DD,tb2.TUNGAYDOCSO,tb2.DENNGAYDOCSO)) as 'TBTT',HIEUDH    ";
            query += "      FROM ( SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS,YEAR(NGAYTHAY) AS 'NAMLD',HIEUDH            ";
            query += "  		FROM TB_DULIEUKHACHHANG WHERE  NAM<="+nam+" AND KY_<="+ky+" AND MADMA='" + madma + "'";
            query += "  		 UNION      ";
            query += "  		SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC',CHUKYDS,YEAR(NGAYTHAY) AS 'NAMLD',HIEUDH ";
            query += "  		FROM TB_DULIEUKHACHHANG_HUYDB WHERE HIEULUCHUY='" + ky + "/" + nam + "' AND   MADMA='" + madma + "'  ) as tb1       ";
            query += "      LEFT JOIN  (SELECT * FROM [DocSo_PHT].[dbo].[DS" + nam + "] WHERE KY=" + ky + "  ) as tb2  ";
            query += "      ON tb2.DANHBA = tb1.DANHBO   ";
            query += "      ORDER BY LOTRINH ";

            return DAL.LinQConnection.getDataTable(query.Replace("\t", ""));
        }


        public static DataTable getThongTinDMAByHandheld_Thay(string madma, string ky, string nam)
        {

            string query = " SELECT DISTINCT  ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT], LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, HIEULUC ,DATEDIFF(DD,tb2.TUNGAYDOCSO,tb2.DENNGAYDOCSO) as 'CHUKY', tb2.CODE,tb2.TIEUTHU as 'LNCC',(convert(float,tb2.TIEUTHU)/DATEDIFF(DD,tb2.TUNGAYDOCSO,tb2.DENNGAYDOCSO)) as 'TBTT',HIEUDH   ";
            query += "      FROM ( SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS            ";
            query += "  		FROM TB_DULIEUKHACHHANG WHERE  MADMA='" + madma + "'";
            query += "  		 UNION      ";
            query += "  		SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC',CHUKYDS           ";
            query += "  		FROM TB_DULIEUKHACHHANG_HUYDB WHERE  MADMA='" + madma + "'  ) as tb1       ";
            query += "      INNER  JOIN  (SELECT * FROM [DocSo_PHT].[dbo].[DS" + nam + "] WHERE KY=" + ky + " AND LEFT(CODE,1)='8' ) as tb2  ";
            query += "      ON tb1.DANHBO = tb2.DANHBA  ";
            query += "      ORDER BY LOTRINH ";

            return DAL.LinQConnection.getDataTable(query.Replace("\t", ""));
        }


        public static DataTable getThongTinDMAByHoaDon_Thay(string madma, string ky, string nam)
        {

            string query = "  SELECT DISTINCT  ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT],tb1.*, tb2.CHUKY, tb2.CODE,tb2.LNCC,(convert(float,tb2.LNCC)/tb2.CHUKY) as 'TBTT' ";
            query += "       FROM (SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC' ";
            query += "              FROM TB_DULIEUKHACHHANG WHERE MADMA='" + madma + "'";
            query += "              UNION ";
            query += "              SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC' ";
            query += "              FROM TB_DULIEUKHACHHANG_HUYDB WHERE MADMA='" + madma + "'";
            query += "             ) as tb1 ";
            query += "   LEFT JOIN  HOADONTH" + ky + "_" + nam + " tb2 WHERE LEFT(CODE,1)='8'";
            query += "   ON tb2.DANHBO = tb1.DANHBO";
            query += "   ORDER BY LOTRINH";
            return DAL.LinQConnection.getDataTable(query);
        }
    }
}