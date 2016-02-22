using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.BANKTKS
{
    class C_DSKiemTra
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DSKiemTra).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static void Insert(KTKS_DANHSACHKT chuyendm)
        {
            try
            {
                db.KTKS_DANHSACHKTs.InsertOnSubmit(chuyendm);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Update()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        public static KTKS_DANHSACHKT findByC_DSKiemTra_khacgnay(string danhbo, DateTime ngayyc)
        {
            try
            {// && q.NGAYLAP != ngayyc
                var query = from q in db.KTKS_DANHSACHKTs where q.DANHBO == danhbo orderby q.NGAYLAP descending select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static DataTable getThonTinDieuChinh(string danhbo)
        {
            string sql = "SELECT TOP(1) ds.KY,ds.DOT,YEAR(ds.NGAYGHI) AS 'NAM', ds.TODS, DANHBO, ds.MALOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM, ds.CSMOI,(kh.HIEUDH +'-'+ RIGHT(YEAR(kh.NGAYTHAY),2)) as HIEUDH,kh.CODH,kh.SOTHANDH";
            sql += " FROM DocSo_PHT.dbo.DS" + DateTime.Now.Year.ToString() + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND  ds.DANHBA ='" + danhbo + "' ORDER BY ds.KY DESC ";
            DataTable t1 =LinQConnection.getDataTable(sql);
            if (t1.Rows.Count == 0)
            {
                sql = "SELECT TOP(1) ds.KY,ds.DOT,YEAR(ds.NGAYGHI) AS 'NAM', ds.TODS, DANHBO, ds.MALOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM, ds.CSMOI,(kh.HIEUDH +'-'+ RIGHT(YEAR(kh.NGAYTHAY),2)) as HIEUDH,kh.CODH,kh.SOTHANDH";
                sql += " FROM DocSo_PHT.dbo.DS" + (DateTime.Now.Year -1) + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
                sql += "  WHERE  ds.DANHBA=kh.DANHBO AND  ds.DANHBA ='" + danhbo + "' ORDER BY ds.KY DESC ";
                t1 = LinQConnection.getDataTable(sql);
            }
            
            return t1;
        }
        public static DataTable getListDCByDate(string ngay) {
            string sql = " SELECT ID, DANHBO,LOTRINH,HOTEN,DIACHI,HOPDONG ,HIEUDHN ,CODHN,SOTHAN, GB ,DM ,CHISO ,CONGDUNG  FROM KTKS_DANHSACHKT WHERE NGAYLAP='" + ngay + "' AND CREATEBY='"+DAL.SYS.C_USERS._userName+"'  ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        
        }
        public static int DeleteBYID(string id)
        {
            return LinQConnection.ExecuteCommand("DELETE FROM KTKS_DANHSACHKT WHERE ID='" + id + "'");
        }

        public static KTKS_DANHSACHKT findByID(int id)
        {
            try
            {
                var query = from q in db.KTKS_DANHSACHKTs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        public static KTKS_DANHSACHKT findByDanhBoChuyenDM(string danhbo, DateTime ngayyc)
        {
            try
            {
                var query = from q in db.KTKS_DANHSACHKTs where q.DANHBO == danhbo && q.NGAYLAP == ngayyc select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }


        public static DataSet getReport(string ngay)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM KTKS_DANHSACHKT WHERE NGAYLAP='" + ngay + "' AND CREATEBY='" + DAL.SYS.C_USERS._userName + "' ORDER BY DANHBO ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "KTKS_DANHSACHKT");
            
            //query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }

    }
}
