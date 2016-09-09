using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.DULIEUKH
{
    class C_DieuChinhDanhBo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DieuChinhDanhBo).Name);

        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static TB_DIEUCHINHDANHBO finBySoPhieu(string sophieu)
        {
            try
            {
                var query = from q in db.TB_DIEUCHINHDANHBOs where q.SOPHIEU == sophieu select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }


        public static void Insert(TB_DIEUCHINHDANHBO tb)
        {
            try
            {
                db.TB_DIEUCHINHDANHBOs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static void InsertCV(TB_CONGVAN cv)
        {
            try
            {
                db.TB_CONGVANs.InsertOnSubmit(cv);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
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
    }
}
