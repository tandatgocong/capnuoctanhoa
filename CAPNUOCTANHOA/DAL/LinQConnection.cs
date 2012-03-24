using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL
{
    public static class LinQConnection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);

        public static int ExecuteCommand( string sql)
        {
            int result=0;
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }


        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }
    }
}
