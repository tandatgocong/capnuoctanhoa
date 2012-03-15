using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL
{

    public static class OledbConnection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OledbConnection).Name);
      //  static string connectionSting = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFileLyLichDHN"].ConnectionString;
        
        public static int ExecuteCommand(string connectionSting, string sql)
        {
            OleDbConnection objConnection = new OleDbConnection(connectionSting);
            try
            {
                objConnection.Open();
                OleDbCommand objCmd = new OleDbCommand(sql, objConnection);
                return objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection ExecuteCommand" + ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return 0;
        }


        public static DataTable getDataTable(string connectionSting,string sql)
        {

            OleDbConnection conn = new OleDbConnection(connectionSting);
            try
            { 
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, conn);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }


    }
}
