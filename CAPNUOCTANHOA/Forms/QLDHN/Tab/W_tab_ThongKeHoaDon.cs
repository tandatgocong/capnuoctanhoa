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
    public partial class W_tab_ThongKeHoaDon : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(L_tab_LoTrinhThayDoi).Name);
        public W_tab_ThongKeHoaDon()
        {
            InitializeComponent();
            txtNam.Text = DateTime.Now.Year.ToString();
        }

       

       

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int nam = int.Parse(txtNam.Text);

                string sql = "SELECT  * FROM HOADON WHERE NAM=" + (nam - 1) + "  AND DANHBA='" + txtDanhBo.Text.Replace("-", "") + "' ";
                string sql1 = "SELECT  * FROM HOADON WHERE NAM=" + nam + "  AND DANHBA='" + txtDanhBo.Text.Replace("-", "") + "' ";

                DataTable bang = DAL.LinQConnectionTT.getDataTable(sql);
                DataTable bang2 = DAL.LinQConnectionTT.getDataTable(sql1);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", bang));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", bang2));

                this.reportViewer1.RefreshReport();
            }
        }
    }
}