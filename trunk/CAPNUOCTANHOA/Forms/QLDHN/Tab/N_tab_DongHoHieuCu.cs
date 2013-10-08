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
            string query = "SELECT * FROM W_DH_HIEUCU WHERE DANHBO IS NOT NULL ";
            if (!"".Equals(nam))
            {
                query += " AND NAMLD " + nam + " ";
            }

            if (!"".Equals(this.comboBox1.Text.Replace(" ","")))
            {
                query += " AND LEFT(W_DH_HIEUCU.HIEUDH,3)  ='" + this.comboBox1.Text.Replace(" ", "") +"'";
            }

            if (!"".Equals(this.txtCoDHN.Text.Replace(" ", "")))
            {
                query += " AND CODH = " + this.txtCoDHN.Text.Replace(" ", "") ;
            }
            
            query+= DAL.SYS.C_USERS._gioihan + " ORDER BY LOTRINH ASC ";

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
            rp.SetParameterValue("title", "DANH SÁCH KHÁCH HÀNG ");            
            crystalReportViewer1.ReportSource = rp ;
        }
    }
}