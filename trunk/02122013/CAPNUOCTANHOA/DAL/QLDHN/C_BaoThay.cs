using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
     public static class C_BaoThay
    {
        
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoThay).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        
        public static DataTable getBangKeBaoThay(int sobangke) {
            string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY,DHN_GHICHU ";
            sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "' ORDER BY kh.LOTRINH ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getBangKeBaoThay(string sobangke)
        {
            string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY ";
            sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "'ORDER BY kh.LOTRINH ASC ";       
            return LinQConnection.getDataTable(sql);
        }
       

        public static int getMaxBangKe() {
            string sql = "SELECT MAX(DHN_SOBANGKE)  FROM TB_THAYDHN where DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "'";
            return LinQConnection.ExecuteCommand(sql);
        }
        public static int getMaxLanThay(string danhbo) {
            string sql = "SELECT MAX(DHN_LANTHAY) FROM TB_THAYDHN WHERE DHN_DANHBO='" + danhbo + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "'";
            return LinQConnection.ExecuteCommand(sql);
        }

        public static DataTable getLoaiBangKe() {
            string sql = "SELECT LOAIBK,TENBANGKE";
            sql += " FROM TB_LOAIBANGKE";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable HistoryThay(string danhbo)
        {
            string sql = "SELECT DHN_LANTHAY,DHN_LYDOTHAY AS 'TENBANGKE',DHN_SOBANGKE,DHN_NGAYBAOTHAY,HCT_NGAYGAN,HCT_TRONGAI";
            sql += " FROM  TB_THAYDHN thay WHERE DHN_DANHBO='" + danhbo + "' ORDER BY DHN_LANTHAY ASC  ";
            return LinQConnection.getDataTable(sql);
        }

        public static void Insert(TB_THAYDHN th_dhn) {
            try
            {
                db.TB_THAYDHNs.InsertOnSubmit(th_dhn);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static TB_THAYDHN finByID_BAOTHAY(int id) {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_THAYDHNs where q.ID_BAOTHAY == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static bool deleteBAOTHAY(TB_THAYDHN THAY)
        {
            try
            {
                db.TB_THAYDHNs.DeleteOnSubmit(THAY);
                db.SubmitChanges();
                LinQConnection.ExecuteCommand("UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='"+ THAY.DHN_DANHBO+"'");
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static bool Update()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static TB_HIEUDONGHO finByHieuDH(string mahieu)
        {
            try
            {
                var query = from q in db.TB_HIEUDONGHOs where q.HIEUDH == mahieu select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
    
        public static DataSet ReportBaoThay(string sobangke)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select *, N'" + DAL.SYS.C_USERS._fullName + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where DHN_SOBANGKE='" + sobangke + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "' ORDER BY TENBANGKE ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_DHN_BANGKE");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
         }
        public static TB_THAYDHN finByBaoThay(int sobangke, string danhbo)
        {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_THAYDHNs where q.DHN_SOBANGKE == sobangke && q.DHN_DANHBO == danhbo && q.DHN_TODS == DAL.SYS.C_USERS._toDocSo && q.DHN_LOAIBANGKE == "DK" orderby q.DHN_SOBANGKE descending select q;
                List<TB_THAYDHN> th = query.ToList();
                if(th.Count>=1)
                    return th[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        public static TB_DHN_BAOCAO getBaoCao()
        {
            try
            {
                var query = from q in db.TB_DHN_BAOCAOs where q.ID_BC == 1 select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        //public static DataTable getBaoThayDinhKy() {
        //    string sql = " SELECT TOP(300) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY FROM  TB_DULIEUKHACHHANG ";
        //    return LinQConnection.getDataTable(sql);
        //}
    }
}
