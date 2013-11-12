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
    class C_GanHopBaoVe
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ChuyenDinhMuc).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static void Insert(TB_GANHOPBV chuyendm)
        {
            try
            {
                db.TB_GANHOPBVs.InsertOnSubmit(chuyendm);
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
            string sql = " SELECT ID,DANHBO, LOTRINH, HOTEN, DIACHI, HOPDONG, GB, DM, HIEU, CO, GHICHU  FROM TB_GANHOPBV WHERE TODS='"+DAL.SYS.C_USERS._toDocSo+"' AND NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);

        }
        public static int DeleteBYID(string id)
        {
            return LinQConnection.ExecuteCommand("DELETE FROM TB_GANHOPBV WHERE ID='" + id + "'");
        }

        public static TB_GANHOPBV findByID(int id)
        {
            try
            {
                var query = from q in db.TB_GANHOPBVs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static TB_GANHOPBV findByDanhBo(string danhbo)
        {
            try
            {
                var query = from q in db.TB_GANHOPBVs where q.DANHBO == danhbo orderby q.NGAYLAP descending select q;
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
            string query = " SELECT *  FROM TB_GANHOPBV WHERE TODS='"+DAL.SYS.C_USERS._toDocSo+"' AND  NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_GANHOPBV");

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }
    }
}
