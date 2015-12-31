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
    public static class LinQConnectionTT
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);


        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            HoaDonDataContext db = new HoaDonDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
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