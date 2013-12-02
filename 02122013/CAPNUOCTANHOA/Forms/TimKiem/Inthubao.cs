using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.Forms.TimKiem
{
    public partial class Inthubao : UserControl
    {
        public Inthubao()
        {
            InitializeComponent();
            ReportDocument rp = new rpt_INTHUMOI();
            rp.SetDataSource(getData());
            crystalReportViewer1.ReportSource = rp;
        }
        private DataSet getData()
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();

            string query = "select * FROM W_THUMOI_";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);

            adapter.Fill(ds, "W_THUMOI_");
            return ds;
        }
    }
}
