using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;
using System.Data.Linq.SqlClient;
using OnBarcode.Barcode;

namespace CAPNUOCTANHOA.DAL.DULIEUKH
{
    public static class C_DuLieuKhachHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DuLieuKhachHang).Name);
       
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static void UpdateBaoThay(string danhbo,string result) {
            try
            {
                string sql = "UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='"+result+"',  MODIFYBY='" + DAL.SYS.C_USERS._userName + "', MODIFYDATE='"+DateTime.Now+"' WHERE DANHBO='" + danhbo + "' ";
                DAL.LinQConnection.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static TB_DULIEUKHACHHANG finByDanhBo(string danhbo) {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_DULIEUKHACHHANGs where q.DANHBO == danhbo select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
       
        public static TB_DULIEUKHACHHANG finByLoTrinh(string lotrinh)
        {
            try
            {
                var query = from q in db.TB_DULIEUKHACHHANGs where q.LOTRINH == lotrinh select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
       
        public static TB_DULIEUKHACHHANG_HUYDB finByDanhBoHuy(string danhbo)
        {
            try
            {
                var query = (from q in db.TB_DULIEUKHACHHANG_HUYDBs where q.DANHBO == danhbo orderby q.CREATEDATE descending select q).Take(1);
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(TB_DULIEUKHACHHANG tb) {
            try
            {
                db.TB_DULIEUKHACHHANGs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        
        public static List<TB_DULIEUKHACHHANG> getAllKHACHHANG()
        {
            var query = from q in db.TB_DULIEUKHACHHANGs select q;
            return query.ToList();
        }
        public static bool Update() {
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

        public static DataSet SoDocSo(string sobangke)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * FROM TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + sobangke + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);            
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            
            ds.Tables[0].Columns.Add(new DataColumn("Barcode", typeof(byte[])));

            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE128;
            foreach (DataRow dr in ds.Tables["TB_DULIEUKHACHHANG"].Rows)
            {
                barcode.Data = dr["DANHBO"].ToString().Trim();
                byte[] imageData = barcode.drawBarcodeAsBytes();
                dr["Barcode"] = imageData;
            }

            return ds;
        }
        public static DataSet SoDocSo_cl(string sobangke)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * FROM TB_DULIEUKHACHHANG WHERE SH='" + sobangke + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        public static DataSet Thumoi()
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * FROM TB_DULIEUKHACHHANG WHERE  SX='1' ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }


        public static DataSet SoDocSo_GM(string sobangke, string ky, string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = " select ID, KHU, DOT, CUON_GCS, CUON_STT, LOTRINH, DANHBO, NGAYGANDH, HOPDONG, HOTEN, SONHA, TENDUONG,p.TENPHUONG as 'PHUONG', q.TENQUAN as 'QUAN', CHUKY, CODE, CODEFU, GIABIEU, DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, CHISOKYTRUOC, BAOTHAY, CREATEDATE, CREATEBY, MODIFYDATE, MODIFYBY, KY, NAM ";
            query += " from TB_DULIEUKHACHHANG tb, QUAN q, PHUONG p ";
            query += " where  tb.QUAN=q.MAQUAN AND q.MAQUAN = p.MAQUAN AND tb.PHUONG=p.MAPHUONG AND LEFT(LOTRINH,4)='" + sobangke + "' AND KY='" + ky + "' AND NAM='" + nam + "' ORDER BY LOTRINH ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        public static DataSet SoDocSo_GM_A4(string sobangke, string ky, string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * FROM TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + sobangke + "' AND KY='" + ky + "' AND NAM='" + nam + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        public static DataSet SoDocSo_GM_A4_(string sobangke, string ky, string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * FROM TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + sobangke + "' AND KY<='" + ky + "' AND NAM<='" + nam + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        public static DataSet SoDocSo_A3(string tulotrinh, string denlotrinh)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = " select ID, KHU, DOT, CUON_GCS, CUON_STT, LOTRINH, DANHBO, NGAYGANDH, HOPDONG, HOTEN, SONHA, TENDUONG,p.TENPHUONG as 'PHUONG', q.TENQUAN as 'QUAN', CHUKY, CODE, CODEFU, GIABIEU, DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, CHISOKYTRUOC, BAOTHAY, CREATEDATE, CREATEBY, MODIFYDATE, MODIFYBY, KY, NAM ";
            query += " from TB_DULIEUKHACHHANG tb, QUAN q, PHUONG p ";
            query += " where  tb.QUAN=q.MAQUAN AND q.MAQUAN = p.MAQUAN AND tb.PHUONG=p.MAPHUONG AND LOTRINH BETWEEN '" + tulotrinh + "' AND '" + denlotrinh + "' ORDER BY LOTRINH ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        public static bool HuyDanhBo(TB_DULIEUKHACHHANG_HUYDB huy, TB_DULIEUKHACHHANG kh) {

            try
            {
                db.TB_DULIEUKHACHHANG_HUYDBs.InsertOnSubmit(huy);
                db.TB_DULIEUKHACHHANGs.DeleteOnSubmit(kh);               
                // huy handheld
                LinQConnectionDS.ExecuteCommand("DELETE FROM KHACHHANG WHERE DANHBA='"+ kh.DANHBO +"'");
                db.SubmitChanges();
                //

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }


        public static int SoLuongHuy(string tods, string hieulucky) {

            string gioihan = DAL.SYS.C_USERS.findByToDS(tods) != null ? DAL.SYS.C_USERS.findByToDS(tods).GIOIHAN : "";
            string sql = "SELECT COUNT(*) FROM TB_DULIEUKHACHHANG_HUYDB WHERE (TAILAPDB IS NULL OR TAILAPDB='False') AND HIEULUCHUY=N'" + hieulucky + "' " + gioihan;
            try
            {
                return DAL.LinQConnection.ExecuteCommand(sql);
            }
            catch (Exception ex)
            { log.Error(ex.Message);      }
            return 0;
         
        }
        public static DataSet DanhSachHuyDB(string tods, string hieulucky)
        {
            string gioihan = DAL.SYS.C_USERS.findByToDS(tods) != null ? DAL.SYS.C_USERS.findByToDS(tods).GIOIHAN : "";
            string query = "SELECT * FROM TB_DULIEUKHACHHANG_HUYDB WHERE (TAILAPDB IS NULL OR TAILAPDB='False') AND HIEULUCHUY=N'" + hieulucky + "' " + gioihan;
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG_HUYDB");

            return ds;        

        }

        public static DataSet reportHuyDB(string danhbo)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select * from TB_DULIEUKHACHHANG_HUYDB where DANHBO='" + danhbo + "'  ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG_HUYDB");

            return ds;
        }
       
        public static List<TB_DULIEUKHACHHANG> getSoThanDHN(string sothan, string hieu)
        {
            try
            {
                var query = from q in db.TB_DULIEUKHACHHANGs where q.SOTHANDH == sothan && q.HIEUDH.StartsWith(hieu) select q;
                return query.ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static bool InsertGHICHU(TB_GHICHU gc)
        {
            try
            {
                db.TB_GHICHUs.InsertOnSubmit(gc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool InsertGHICHU_TT(TB_GHICHU_TT gc)
        {
            try
            {
                db.TB_GHICHU_TTs.InsertOnSubmit(gc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static DataTable lisGhiChu(string danhbo)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CREATEDATE,HIENTHI FROM TB_GHICHU WHERE DANHBO='" + danhbo + "'  ORDER BY CREATEDATE DESC";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable lisGhiChu_TT(string danhbo)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CREATEDATE FROM TB_GHICHU_TT WHERE DANHBO='" + danhbo + "' ORDER BY CREATEDATE DESC";
            return LinQConnection.getDataTable(sql);
        }

        public static TB_GHICHU findGhiChuByID(int id)
        {
            try
            {
                var query = from q in db.TB_GHICHUs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

    }
}
