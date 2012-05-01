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
    }
}
