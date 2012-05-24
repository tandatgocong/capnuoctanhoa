using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_DhnAmSau
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DhnAmSau).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static void Insert(TB_DHNAMSAU chuyendm)
        {
            try
            {
                db.TB_DHNAMSAUs.InsertOnSubmit(chuyendm);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Update()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        
        public static DataTable getListGanHopByDate(string ngay)
        {
            string sql = " SELECT ID,DANHBO, HOTEN, DIACHI, HOPDONG, HIEU, CO, GHICHU  FROM TB_DHNAMSAU WHERE TODS='"+DAL.SYS.C_USERS._toDocSo+"' AND NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);

        }
        public static int DeleteBYID(string id)
        {
            return LinQConnection.ExecuteCommand("DELETE FROM TB_DHNAMSAU WHERE ID='" + id + "'");
        }

        public static TB_DHNAMSAU findByID(int id)
        {
            try
            {
                var query = from q in db.TB_DHNAMSAUs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static TB_DHNAMSAU findByDanhBo(string danhbo)
        {
            try
            {
                var query = from q in db.TB_DHNAMSAUs where q.DANHBO == danhbo select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static DataSet getReport(string ngay)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_DHNAMSAU WHERE TODS='"+DAL.SYS.C_USERS._toDocSo+"' AND  NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHNAMSAU");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }
    }
}
