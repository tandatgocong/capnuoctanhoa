using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using log4net;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.DULIEUKH
{
    class C_PhienLoTrinh
    {
        static DocSoDataContext ds = new DocSoDataContext();
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(C_PhienLoTrinh).Name);
        public static List<MAYDOCSO> getListMayDS(int tods)
        {
            try
            {
                var query = from q in ds.MAYDOCSOs where q.TODS == tods orderby q.MAY ascending select q;
                return query.ToList();

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static int CapNhatLoTrinh_KHACHHANG(string danhbo, string lotrinh)
        {

            string sql = "UPDATE TB_DULIEUKHACHHANG SET LOTRINH ='" + lotrinh + "' WHERE DANHBO='" + danhbo + "'  ";
            return DAL.LinQConnection.ExecuteCommand(sql);
        }
        public static int CapNhatLoTrinh_DOCSO(string danhbo, string lotrinh)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                string sql = "UPDATE KHACHHANG SET MALOTRINH='" + lotrinh + "',MALOTRINH2='" + lotrinh + "' WHERE DANHBA='" + danhbo + "' ";
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int CapNhatThongTinHandHeld(string danhbo, string hieudh, string sothan, string chithan, string chigoc)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                string sql = "UPDATE KhachHang SET Hieu='" + hieudh + "', SoThan='" + sothan + "', ChiThan='" + chithan + "', ChiCo='" + chigoc + "' WHERE DanhBa='" + danhbo + "' ";
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Thong Tin Thay That Bai." + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int CapNhatGhiChu(string danhbo, string ghichu)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                string sql = "UPDATE KHACHHANG SET GHICHUVANPHONG=N'" + ghichu + "' WHERE DANHBA='" + danhbo + "' ";
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Thong Tin Thay That Bai." + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int CapNhatThongTinHandHeld(string danhbo, string hieudh, string sothan, string chithan, string chigoc, string vitri)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                string sql = "UPDATE KHACHHANG SET HIEU='" + hieudh + "', SOTHAN='" + sothan + "', MACHITHAN='" + chithan + "', MACHIGOC='" + chigoc + "', VITRI='" + vitri + "' WHERE DANHBA='" + danhbo + "' ";
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Thong Tin Thay That Bai." + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int InsertBaoThayHandHeld(string sql)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Insert Thong Tin Thay That Bai" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int InsertBaoThayHandHeldTH(string sql)
        {
            int result = 0;
            DocSoTHDataContext db = new DocSoTHDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Insert Thong Tin Thay That Bai" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static void InsertYeuCauDC(TB_YEUCAUDC yc) {
            try
            {
                db.TB_YEUCAUDCs.InsertOnSubmit(yc);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static TB_YEUCAUDC findByDanhBoDC(string danhbo, int ky, int nam)
        {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_YEUCAUDCs where q.DANHBO == danhbo && q.KY == ky && q.NAM == nam && q.DACHUYEN ==false select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
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
        public static DataSet getReportDieuChinh(int ky, int nam)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_YEUCAUDC WHERE KY ='" + ky + "' AND NAM='" + nam + "' AND DACHUYEN ='False'  ORDER BY LTCU ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_YEUCAUDC");

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }
    }
}
