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
