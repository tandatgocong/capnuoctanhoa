using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Data.SqlClient;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class N_tab_DongHoHieuCu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(L_tab_LoTrinhThayDoi).Name);
        public N_tab_DongHoHieuCu()
        {
            InitializeComponent();
            int nam = DateTime.Now.Year;
           
            txtHieuLuc.Text =  "<"+nam+"";

        }

        public DataSet getTheoDoiBienDocChiSo(string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string dk = "";
            string query = "";
            if (!"".Equals(nam))
            {
                query = "SELECT * FROM W_DH_HIEUCU WHERE  NAMLD " + nam + " " + DAL.SYS.C_USERS._gioihan + " ORDER BY NAME ASC,LOTRINH ASC ";
            }

            if (!"".Equals(this.comboBox1.Text.Replace(" ","")))
            {
                query = "SELECT * FROM W_DH_HIEUCU WHERE  LEFT(W_DH_HIEUCU.HIEUDH,3)  ='" + this.comboBox1.Text.Replace(" ", "") + "' " + DAL.SYS.C_USERS._gioihan + " ORDER BY NAME ASC,LOTRINH ASC ";
            }

            if (!"".Equals(nam) && !"".Equals(this.comboBox1.Text.Replace(" ", ""))) {
                query = "SELECT * FROM W_DH_HIEUCU WHERE  NAMLD " + nam + " AND LEFT(W_DH_HIEUCU.HIEUDH,3)  ='" + this.comboBox1.Text.Replace(" ", "") + "' " + DAL.SYS.C_USERS._gioihan + " ORDER BY NAME ASC,LOTRINH ASC ";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "W_DH_HIEUCU");
            return ds;
        }

 
        private void btThem_Click(object sender, EventArgs e)
        {
            string hieuluc = txtHieuLuc.Text.Trim();
            ReportDocument rp = new rpt_DongHoHieuCu();
            rp.SetDataSource(getTheoDoiBienDocChiSo(hieuluc));
            rp.SetParameterValue("NAM", hieuluc);
            crystalReportViewer1.ReportSource = rp ;
        }
    }
}