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
    public partial class M_tab_SoLieuTongKet : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(L_tab_LoTrinhThayDoi).Name);
        public M_tab_SoLieuTongKet()
        {
            InitializeComponent();
            int ky = DateTime.Now.Month + 1;
            int nam = DateTime.Now.Year;
            if (ky >= 13)
            {
                ky = 1;
                nam = nam + 1;
            }
            this.dateTuNgay.Value = DateTime.Now;
            this.dateDenNgay.Value = DateTime.Now;
            txtHieuLuc.Text = String.Format("{0:00}", ky) + "/" + nam;

        }

        public DataSet getTheoDoiBienDocChiSo(string hieuluc, string tungay, string den)
        {
            DAL.LinQConnection.ExecuteStoredProcedure_TK("BC_TONGKET", hieuluc, tungay, den);
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT * FROM BAOCAO_TONGKET ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "BAOCAO_TONGKET");
            return ds;
        }

 
        private void btThem_Click(object sender, EventArgs e)
        {
            string hieuluc = txtHieuLuc.Text.Trim();
            string tungay = Utilities.DateToString.NgayVN(dateTuNgay.Value.Date);
            string denngay = Utilities.DateToString.NgayVN(dateDenNgay.Value.Date);

            string title = "( KỲ " + hieuluc + " - TỪ NGÀY :  " + tungay + "  ĐẾN NGÀY : " + denngay + " )";
            ReportDocument rp = new rpt_TONGKETSOLIEU();

            rp.SetDataSource(getTheoDoiBienDocChiSo(hieuluc,tungay,denngay));
            rp.SetParameterValue("TITLE", title);
            crystalReportViewer1.ReportSource = rp ;
        }
    }
}