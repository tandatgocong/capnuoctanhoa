﻿using System;
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

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class I_tab_BangChamCong : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(I_tab_BangChamCong).Name);
        public I_tab_BangChamCong()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            ReportDocument rp = new rpt_ThongKeDongHoNuoc_();
            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getThongKeDHN(ky,nam,DAL.SYS.C_USERS._toDocSo));
            rp.SetParameterValue("KY", ky);
            rp.SetParameterValue("NAM", nam);
          //  crystalReportViewer1.ReportSource = rp;
        }

    }
}
