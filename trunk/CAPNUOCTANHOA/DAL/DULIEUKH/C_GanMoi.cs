using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using log4net;

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
    }
}
