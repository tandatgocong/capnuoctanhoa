using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_ChuyenDinhMuc
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ChuyenDinhMuc).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static void Insert(TB_CHUYENDINHMUC chuyendm)
        {
            try
            {
                db.TB_CHUYENDINHMUCs.InsertOnSubmit(chuyendm);
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

        public static DataTable getThonTinDieuChinh(string danhbo)
        {
            string sql = "SELECT TOP(1) ds.KY,ds.DOT,YEAR(ds.NGAYGHI) AS 'NAM', ds.TODS, DANHBO, ds.MALOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM, ds.TBTHU";
            sql += " FROM DocSo_PHT.dbo.DS" + DateTime.Now.Year.ToString() + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND  ds.DANHBA ='" + danhbo + "' ORDER BY ds.KY DESC ";
             return LinQConnection.getDataTable(sql);
        }
        public static DataTable getListDCByDate(string ngay) {
            string sql = " SELECT ID, KY, DOT, DANHBO, LOTRINH, HOTEN, DIACHI, HOPDONG, GB, DM,TTBQ , CONGDUNG  FROM TB_CHUYENDINHMUC WHERE NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        
        }
        public static int DeleteBYID(string id)
        {
              return LinQConnection.ExecuteCommand("DELETE FROM TB_CHUYENDINHMUC WHERE ID='"+id+"'");
        }

        public static TB_CHUYENDINHMUC findByID(int id) {
            try
            {
                var query = from q in db.TB_CHUYENDINHMUCs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        public static TB_CHUYENDINHMUC findByDanhBoChuyenDM(string danhbo, DateTime ngayyc)
        {
            try
            {
                var query = from q in db.TB_CHUYENDINHMUCs where q.DANHBO == danhbo && q.NGAYLAP == ngayyc select q;
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
            string query = " SELECT *  FROM TB_CHUYENDINHMUC WHERE NGAYLAP='" + ngay + "' AND TODS='" + DAL.SYS.C_USERS._toDocSo + "' ORDER BY DANHBO ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_CHUYENDINHMUC");
            
            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }

    }
}
