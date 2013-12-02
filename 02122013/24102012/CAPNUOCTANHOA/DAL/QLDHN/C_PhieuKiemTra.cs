using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using log4net;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_PhieuKiemTra
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoThay).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
      
        public static void Insert(TB_CHUYENKIEMTRA chuyenkt)
        {
            try
            {
                db.TB_CHUYENKIEMTRAs.InsertOnSubmit(chuyenkt);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static DataTable getListByCode( int tods, int dot, int ky, int nam, string code)
        {
            string sql = "SELECT MAY,DANHBO,ds.MALOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,ds.CODECU, ds.CSCU";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND ds.TODS='"+tods+"' AND ds.KY='" + ky + "' AND ds.CODE IN (" + code + ") ";
            if (dot != 0) {
                sql += " AND ds.DOT='"+dot+"'"; 
            }
            sql += " AND DANHBO NOT IN (SELECT DANHBO FROM TB_CHUYENKIEMTRA WHERE KY='" + ky + "' AND DOT='" + dot + "' AND NAM='" + nam + "' )";
            sql += " ORDER BY DANHBO ASC"; 
            
            return LinQConnection.getDataTable(sql);
        }
        public static DataSet getListDanhBoReport(string listDanhBo)
        {
            string sql = "SELECT DANHBO,HOTEN,(SONHA+' '+TENDUONG) as 'DIACHI'";
            sql += "FROM  TB_DULIEUKHACHHANG WHERE DANHBO IN (" + listDanhBo + ") ORDER BY DANHBO ASC ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(ds, "DANHSACH");
            return ds;
        }
        public static DataSet getListHoaDonReport(string danhba, int nam, int ky, int dot)
        {
            //DocSoDataContext db = new DocSoDataContext();
            //DataSet ds = new DataSet();
            //string query2 = "SELECT  kh.*, ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.TENNHANVIEN  ";
            //query2 += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSo_PHT.dbo.NHANVIEN nv ";
            //query2 += "WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.KY=" + ky + " AND ds.DOT=" + dot + " AND ds.DANHBA='" + danhba + "' ";

            //SqlDataAdapter adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            //adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");


            //string query = "SELECT  TOP(5)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
            //      " KH.CO, KH.SOTHAN, H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
            //    " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TIEUTHU");
            //int scl = 5 - ds.Tables["TIEUTHU"].Rows.Count;
            //if (scl > 0)
            //{
            //    nam = nam - 1;
            //    DataTable b_Old = DAL.LinQConnectionDS.getDataTable("SELECT  TOP(" + scl + ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
            //          " KH.CO, KH.SOTHAN, H.KY, " + nam + " AS NAM , H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
            //          " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ");
            //    ds.Tables["TIEUTHU"].Merge(b_Old);
            //}

            //query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_DHN_BAOCAO");
            //return ds;

            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
            string query2 = "SELECT  kh.*, ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.TENNHANVIEN  ";
            query2 += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSo_PHT.dbo.NHANVIEN nv ";
            query2 += "WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.KY=" + ky + " AND ds.DOT=" + dot + " AND ds.DANHBA='" + danhba + "' ";

            SqlDataAdapter adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");


            string query = "SELECT  TOP(1)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                  " KH.CO, KH.SOTHAN, H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.NGAYGHI, 103) AS DENNGAY, H.TIEUTHU AS 'LNCC' FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = "SELECT  TOP(4)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                " KH.CO, KH.SOTHAN, H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
              " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionDS.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = 5 - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                nam = nam - 1;
                DataTable b_Old = DAL.LinQConnectionDS.getDataTable("SELECT  TOP(" + scl + ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                      " KH.CO, KH.SOTHAN, H.KY, " + nam + " AS NAM , H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.NGAYGHI, 103) AS DENNGAY, H.TIEUTHU AS 'LNCC' FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                      " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ");
                ds.Tables["TIEUTHU"].Merge(b_Old);
            }

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;

        }
   

    }
}