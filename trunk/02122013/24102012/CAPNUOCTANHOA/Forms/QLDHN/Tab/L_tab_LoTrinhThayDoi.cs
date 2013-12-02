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
    public partial class L_tab_LoTrinhThayDoi : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(L_tab_LoTrinhThayDoi).Name);
        public L_tab_LoTrinhThayDoi()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month;

        }

        public DataSet getTheoDoiBienDocChiSo(string KY, string NAM)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT DANHBO,LTCU,LTMOI ";
 query += " FROM TB_YEUCAUDC ";
 query += " WHERE DANHBO NOT IN (SELECT DANHBO FROM TB_GANMOI WHERE HIEULUC='"+KY+"/"+NAM+"') ";
 query += " AND KY=" + int.Parse(KY) + " AND NAM=" + int.Parse(NAM) + " " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "LTCU");
 query += " ORDER BY LTCU ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_YEUCAUDC");
            return ds;
        }

 
        private void btThem_Click(object sender, EventArgs e)
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            ReportDocument rp = new rpt_DanhSachThayDoiLoTrinh();

            string title_ = "DANH SÁCH LỘ TRÌNH THAY ĐỔI KỲ  " + ky + "/" + nam;

            rp.SetDataSource(getTheoDoiBienDocChiSo(ky, nam));
            rp.SetParameterValue("title_", title_);
            crystalReportViewer1.ReportSource = rp ;
        }
    }
}