using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_tab_BaoCao
    {
        

        public static DataSet tb_Report(string query, string table)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, table);
            return ds;
        }
    }
}
