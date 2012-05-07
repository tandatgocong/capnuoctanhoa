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

        public static int CapNhatThongTinHandHeld(string danhbo, string hieudh, string sothan)
        {
            int result = 0;
            DocSoDataContext db = new DocSoDataContext();
            try
            {
                string sql = "UPDATE KHACHHANG SET HIEU='" + hieudh + "', SOTHAN='" + sothan + "' WHERE DANHBA='" + danhbo + "' ";
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
    }
}
