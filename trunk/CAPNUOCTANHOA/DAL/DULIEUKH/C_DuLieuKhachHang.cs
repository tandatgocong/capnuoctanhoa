using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;

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
                var query = from q in db.TB_DULIEUKHACHHANGs where q.DANHBO == danhbo select q;
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
        public static void Update() {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
