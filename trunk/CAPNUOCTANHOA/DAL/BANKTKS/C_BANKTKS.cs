using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.DAL.BANKTKS
{
    public static class C_BANKTKS
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BANKTKS).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        /* KTKS_THONGTINDINHMUC */
        public static KTKS_THONGTINDINHMUC findThongTiDMbyID(int id) {

            var query = from q in db.KTKS_THONGTINDINHMUCs where q.ID == id select q;
            return query.SingleOrDefault();
        }
        public static bool InsertThongTinDM(KTKS_THONGTINDINHMUC ttdm) {
            try
            {
                db.KTKS_THONGTINDINHMUCs.InsertOnSubmit(ttdm);
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
        public static bool DeleteThongTinDM(KTKS_THONGTINDINHMUC ttdm)
        {

            try
            {
                db.KTKS_THONGTINDINHMUCs.InsertOnSubmit(ttdm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return false;
        }

        /* KTKS_THONGTINDINHMUC_TMP */
        public static KTKS_THONGTINDINHMUC_TMP findThongTiDMbyID_TMP(int id)
        {

            var query = from q in db.KTKS_THONGTINDINHMUC_TMPs where q.ID == id select q;
            return query.SingleOrDefault();
        }
        public static bool InsertThongTinDM_TMP(KTKS_THONGTINDINHMUC_TMP ttdm)
        {
            try
            {
                db.KTKS_THONGTINDINHMUC_TMPs.InsertOnSubmit(ttdm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return false;
        }

        public static bool DeleteThongTinDM(KTKS_THONGTINDINHMUC_TMP ttdm)
        {

            try
            {
                db.KTKS_THONGTINDINHMUC_TMPs.InsertOnSubmit(ttdm);
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
