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
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class H_tab_BienDocCS : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TongKetHandHeld).Name);
        public H_tab_BienDocCS()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            this.dateTime.Value = DateTime.Now.Date;
            cbDotDS.SelectedIndex = 2;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            DAL.QLDHN.C_QuanLyDongHoNuoc.CAPNHAT_BIENDOCCHISO(nam + "", ky, dot, dhnCL.Checked);
            ReportDocument rp = new rpt_KetQuaBienChiSo();
            string title = "(Ngày " + Utilities.DateToString.NgayVN(dateTime.Value) + " ; Đợt " + dot + " ; Kỳ " + ky + "/" + nam + " )";
            if (dot == 0) {
                title = "(Ngày " + Utilities.DateToString.NgayVN(dateTime.Value) + " ; Kỳ " + ky + "/" + nam + " )";
            }
           
            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getTheoDoiBienDocChiSo());
            rp.SetParameterValue("title", title);
            if (dhnCL.Checked)
                rp.SetParameterValue("dhn", "(ĐHN >= " + ConfigurationManager.AppSettings["codhn"].ToString() + ")");
            else
                 rp.SetParameterValue("dhn", "");
            crystalReportViewer1.ReportSource = rp;
        }

    }
}
