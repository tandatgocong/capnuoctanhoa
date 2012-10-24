using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GIAMHOADON.LinQ;
using System.Data.SqlClient;

namespace GIAMHOADON.DAL.QLDHN
{
    class C_tab_BaoCao
    {
        

        public static DataSet tb_Report(string query, string table)
        {
            DataSet ds = new DataSet();
            GIAMHOADONDataContext db = new GIAMHOADONDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, table);
            return ds;
        }
        public static DataSet tb_Report(string query1, string table1, string query2, string table2)
        {
            DataSet ds = new DataSet();
            GIAMHOADONDataContext db = new GIAMHOADONDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query1, db.Connection.ConnectionString);
            adapter.Fill(ds, table1);

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, table2);

            return ds;
        }
    }
}
