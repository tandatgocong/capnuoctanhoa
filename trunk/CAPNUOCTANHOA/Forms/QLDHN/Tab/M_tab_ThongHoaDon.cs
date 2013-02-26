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
    public partial class M_tab_ThongHoaDon : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(I_tab_BangChamCong).Name);
        public M_tab_ThongHoaDon()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }
        DataSet getTheoDoiBienDocChiSo(string ky)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            /*
            string query = "SELECT DOT,COUNT(CASE WHEN LNCC=0 THEN 1 ELSE NULL END) AS HD0 ";
            query += " ,COUNT(CASE WHEN LNCC=1 THEN 1 ELSE NULL END) AS HD1";
            query += " ,COUNT(CASE WHEN LNCC=2 THEN 1 ELSE NULL END) AS HD2 ";
            query += " ,COUNT(CASE WHEN LNCC=3 THEN 1 ELSE NULL END) AS HD3 ";
            query += " ,COUNT(CASE WHEN LNCC=4 THEN 1 ELSE NULL END) AS HD4 ";
            query += " FROM [CAPNUOCTANHOA].[dbo].[HOADONTH" + ky + "_" + txtNam.Text.Trim() + "] ";
            query += " GROUP BY DOT ";
            query += " ORDER BY DOT ASC "; */


            string query = " SELECT DOT,COUNT(CASE WHEN [TIEUTHU]=0 THEN 1 ELSE NULL END) AS HD0   ";
            query += " ,COUNT(CASE WHEN [TIEUTHU]=1 THEN 1 ELSE NULL END) AS HD1  ";
            query += " ,COUNT(CASE WHEN [TIEUTHU]=2 THEN 1 ELSE NULL END) AS HD2  ";
            query += "  ,COUNT(CASE WHEN [TIEUTHU]=3 THEN 1 ELSE NULL END) AS HD3  ";
            query += "   ,COUNT(CASE WHEN [TIEUTHU]=4 THEN 1 ELSE NULL END) AS HD4  ";
            query += "  FROM [DocSo_PHT].[dbo].[DS" + txtNam.Text.Trim() + "] ";
            query += "  WHERE [KY]=" + ky;
            query += "  GROUP BY DOT   ";
            query += "  ORDER BY DOT ASC   ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "THONGKE_HOADON");
            return ds;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
                string nam = this.txtNam.Text;
                ReportDocument rp = new rpt_ThongKeHoaDon();

                rp.SetDataSource(getTheoDoiBienDocChiSo(ky));
                rp.SetParameterValue("KY", ky);
                rp.SetParameterValue("NAM", nam);

                crystalReportViewer1.ReportSource = rp;
            }
            catch (Exception)
            {

            }

        }
    }
}