using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.DAL.BANKTKS
{
    class C_TheoDoiDM
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BANKTKS).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        public static KTKS_THEODOIDM findThongTiDMbyID(int id)
        {

            var query = from q in db.KTKS_THEODOIDMs where q.ID == id select q;
            return query.SingleOrDefault();
        }
        public static bool InsertThongTinDM(KTKS_THEODOIDM ttdm)
        {
            try
            {
                db.KTKS_THEODOIDMs.InsertOnSubmit(ttdm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
                log.Error(ex);
            }
            return false;
        }
        public static bool DeleteThongTinDM(KTKS_THEODOIDM ttdm)
        {

            try
            {
                db.KTKS_THEODOIDMs.InsertOnSubmit(ttdm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return false;
        }
    }
}
