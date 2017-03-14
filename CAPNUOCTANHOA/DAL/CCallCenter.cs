﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.DAL
{
    class CCallCenter
    {
        protected static dbCallCenterDataContext _db = new dbCallCenterDataContext();

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public void Refresh()
        {
            _db = new dbCallCenterDataContext();
        }
        public static int ExecuteCommand(string sql)
        {
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(_db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                _db.Connection.Close();
                _db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _db.Connection.Close();
            }
            _db.SubmitChanges();
            return result;
        }

        public static int ExecuteCommand_(string sql)
        {
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(_db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                _db.Connection.Close();
                _db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {


            }
            finally
            {
                _db.Connection.Close();
            }
            _db.SubmitChanges();
            return result;
        }
        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                if (_db.Connection.State == ConnectionState.Open)
                {
                    _db.Connection.Close();
                }
                _db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, _db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _db.Connection.Close();
            }
            return table;
        }

    }
}
