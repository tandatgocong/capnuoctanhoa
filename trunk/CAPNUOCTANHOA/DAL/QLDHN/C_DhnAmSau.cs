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
    
    /** DUT CHI THAN **/

        public static void Insert(TB_TLKDUTCHI dutchi)
        {
            try
            {
                db.TB_TLKDUTCHIs.InsertOnSubmit(dutchi);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
       
        public static DataTable getListTLKDutChiByDate(string ngay)
        {
            string sql = " SELECT DANHBO ,LOTRINH ,  HOTEN ,DIACHI ,HOPDONG,GB , DM ,HIEU ,CO ,SOTHAN FROM TB_TLKDUTCHI WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND NGAYBAO='" + ngay + "' ORDER BY LOTRINH ASC ";
            return LinQConnection.getDataTable(sql);

        }
        
        public static TB_TLKDUTCHI findByDanhBoDutChi(string danhbo, DateTime ngayyc)
        {
            try
            {
                var query = from q in db.TB_TLKDUTCHIs where q.DANHBO == danhbo && q.NGAYBAO==ngayyc select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        
        public static TB_TLKDUTCHI findByDanhBoDutChi_khacgnay(string danhbo, DateTime ngayyc)
        {
            try
            {
                var query = from q in db.TB_TLKDUTCHIs where q.DANHBO == danhbo && q.NGAYBAO != ngayyc select q;
                return query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static DataSet getReportDutChi(string listDanhbo, string ngay, int type)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_TLKDUTCHI WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND  NGAYBAO='" + ngay + "' AND DANHBO IN ("+listDanhbo+") AND [TYPE]='"+type+"' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_TLKDUTCHI");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }
        public static DataSet getReportDutChi(string listDanhbo, string ngay, int type, int loainam)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_TLKDUTCHI WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND  NGAYBAO='" + ngay + "' AND DANHBO IN (" + listDanhbo + ") AND [TYPE]='" + type + "' AND SONAM='" + loainam + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_TLKDUTCHI");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }

        public static DataSet getReportDutChi(string ngay, int type)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_TLKDUTCHI WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND  NGAYBAO='" + ngay + "' AND [TYPE]='" + type + "' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_TLKDUTCHI");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }
        public static DataSet getReportDutChi(string ngay, int type, int loainam)
        {
            DataSet ds = new DataSet();
            string query = " SELECT *  FROM TB_TLKDUTCHI WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND  NGAYBAO='" + ngay + "' AND [TYPE]='" + type + "' AND SONAM='"+loainam+"' ORDER BY LOTRINH ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_TLKDUTCHI");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }


        public static DataTable getListDutChiByDate(string ngay,int type)
        {
            string sql = " SELECT ID,DANHBO ,LOTRINH ,HOTEN ,DIACHI ,HOPDONG ,GB,DM,HIEU,CO,SOTHAN  FROM TB_TLKDUTCHI  WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND NGAYBAO='" + ngay + "' AND [TYPE]='" + type + "' ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);

        }
        
    }
}
