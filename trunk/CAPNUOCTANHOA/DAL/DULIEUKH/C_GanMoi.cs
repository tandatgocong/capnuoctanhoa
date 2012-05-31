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
    class C_GanMoi
    {
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(C_GanMoi).Name);
        
        public static bool Insert(TB_GANMOI gm) {
            try
            {
                db.TB_GANMOIs.InsertOnSubmit(gm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static TB_GANMOI finByDanhBo(string danhbo) {

            try
            {
                var query = from q in db.TB_GANMOIs where q.DANHBO == danhbo select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }

        public static TB_GANMOI finByDanhBoGanMoi(string danhbo)
        {

            try
            {
                var query = from q in db.TB_GANMOIs where q.DANHBO == danhbo && (q.CHUYEN==false || q.CHUYEN==null) select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }

        public static bool Update() {

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return false;
        }

        public static DataTable getDataGanMoi(string tods, string dotds, string mayds, string hieuluc) {
            string sql = "SELECT DANHBO, (SONHA+' '+ DUONG) as DIACHI, (MAQUAN+MAPHUONG) AS QUANPHUONG,PLT,BANGKE  FROM TB_GANMOI ";
            sql += " WHERE (CHUYEN IS NULL  OR CHUYEN='False') AND TODS='" + tods + "'  AND MAYDS='" + mayds + "' AND HIEULUC='"+hieuluc+"' ORDER BY PLT ASC";
            //AND DOT='" + dotds + "'
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getPhienLoTrinhGM(string lotrinh, string hieuluc)
        {
            string sql = "SELECT DANHBO, (SONHA+' '+ DUONG) as DIACHI, (MAQUAN+MAPHUONG) AS QUANPHUONG,PLT,BANGKE  FROM TB_GANMOI ";
            sql += " WHERE (CHUYEN IS NULL  OR CHUYEN='False') AND  LEFT(PLT,4)='" + lotrinh + "' AND HIEULUC='" + hieuluc + "' ORDER BY PLT ASC";
            //AND DOT='" + dotds + "'
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getPhienLoTrinh(string lotrinh) {
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH,'' as 'M_LOTRINH' FROM TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + lotrinh + "' ORDER BY LOTRINH ASC ";
            return LinQConnection.getDataTable(sql);
        }

        public static int InsertDocSo_(string sql)
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
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static DataTable getMaxLoTrinh(string dotmay) {
            return DAL.LinQConnection.getDataTable("SELECT MAX(LOTRINH) FROM  TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + dotmay + "'");
        }
    }
}
