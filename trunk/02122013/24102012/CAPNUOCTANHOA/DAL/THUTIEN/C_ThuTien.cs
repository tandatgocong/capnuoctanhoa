using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.DAL.QLDHN;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.THUTIEN
{
    public static class C_ThuTien
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ThuTien).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        static HoaDonDataContext hd = new HoaDonDataContext();
        public static bool Insert(TB_DONGNUOC th_dhn)
        {
            try
            {
                db.TB_DONGNUOCs.InsertOnSubmit(th_dhn);
                db.SubmitChanges();
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

        public static bool delete(TB_DONGNUOC dongnuoc)
        {
            try
            {
                db.TB_DONGNUOCs.DeleteOnSubmit(dongnuoc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static int DeleteByID(string ID) {

            string sql = "DELETE FROM TB_DONGNUOC WHERE ID='"+ID+"'";
            return DAL.LinQConnection.ExecuteCommand_(ID);
        }

        public static DataTable getDongNuocByDate(string month)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY NGAYDONGNUOC  DESC) [STT],ID, DANHBO, HOTEN, SONHA, TENDUONG, NGAYDONGNUOC,CSDONG, NGAYMONUOC,CSMO, NOIDUNG, HOPDONG,QUAN,PHUONG ";
            sql += " FROM TB_DONGNUOC WHERE MONTH(NGAYDONGNUOC)='" + month + "'  AND YEAR(NGAYDONGNUOC)='" + DateTime.Now.Date.Year.ToString() + "' ORDER BY NGAYDONGNUOC DESC";
            return LinQConnection.getDataTable(sql);
        }


        public static TB_DONGNUOC finByDanhBo(string danhbo)
        {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_DONGNUOCs where q.DANHBO == danhbo && q.NGAYDONGNUOC.Value.Year== DateTime.Now.Year orderby q.ID descending select q;
                return (TB_DONGNUOC)query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static string noidung(string danhbo) {
            try
            {
                string result = "Nợ hóa đơn kỳ ";
               
                var query = from q in hd.HDs where q.DBo == danhbo orderby q.KyHD ascending, q.NamHD descending select q;
                foreach (var item in query.ToList())
                {
                    HD hd_ = (HD)item;
                    result += " " + hd_.KyHD + "/" + hd_.NamHD + ": " + String.Format("{0:0,0}", hd_.TNuoc).Replace(",", ".") + " ; ";
                }
                return result;
        
            }
            catch (Exception)
            {
                
            }
            return "";    
        }
       
        public static DataSet ReportByDate(string month)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * ";
            query += " FROM TB_DONGNUOC WHERE MONTH(NGAYDONGNUOC)='" + month + "' AND YEAR(NGAYDONGNUOC)='" + DateTime.Now.Date.Year.ToString() + "'  ORDER BY NGAYDONGNUOC DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DONGNUOC");

            //query = "select * FROM TB_DHN_BAOCAO";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
        }
        public static DataSet ReportByYear(string month)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * ";
            query += " FROM TB_DONGNUOC WHERE YEAR(NGAYDONGNUOC)='" + month + "'  ORDER BY NGAYDONGNUOC DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DONGNUOC");

            //query = "select * FROM TB_DHN_BAOCAO";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
        }

        public static DataSet ReportByToDate(string tungay, string denngay)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * ";
            query += " FROM TB_DONGNUOC WHERE CONVERT(DATETIME,NGAYDONGNUOC,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103)  ORDER BY NGAYDONGNUOC DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DONGNUOC");
            return ds;
        }

        public static DataSet ReportByDate(string thang, string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * ";
            query += " FROM TB_DONGNUOC WHERE MONTH(NGAYDONGNUOC)='" + thang + "' AND YEAR(NGAYDONGNUOC)='" + nam + "'  ORDER BY NGAYDONGNUOC DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DONGNUOC");
            return ds;
        }

        public static DataSet ReportByDay( string ngay)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT * ";
            query += " FROM TB_DONGNUOC WHERE CONVERT(DATETIME,NGAYDONGNUOC,103) = CONVERT(DATETIME,'" + ngay + "',103) ORDER BY NGAYDONGNUOC DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DONGNUOC");
            return ds;
        }


        //public static TB_THA YDHN finByBaoThay(int sobangke, string danhbo)
        //{
        //    try
        //    {
        //        db = new CapNuocTanHoaDataContext();
        //        var query = from q in db.TB_THAYDHNs where q.DHN_SOBANGKE == sobangke && q.DHN_DANHBO == danhbo && q.DHN_TODS == DAL.SYS.C_USERS._toDocSo && q.DHN_LOAIBANGKE == "DK" orderby q.DHN_SOBANGKE descending select q;
        //        List<TB_THAYDHN> th = query.ToList();
        //        if (th.Count >= 1)
        //            return th[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}
        //public static TB_DHN_BAOCAO getBaoCao()
        //{
        //    try
        //    {
        //        var query = from q in db.TB_DHN_BAOCAOs where q.ID_BC == 1 select q;
        //        return query.SingleOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}
    }
}
