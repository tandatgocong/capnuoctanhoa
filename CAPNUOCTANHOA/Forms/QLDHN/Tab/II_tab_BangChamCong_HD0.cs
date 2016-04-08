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

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class II_tab_BangChamCong_HD0 : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(I_tab_BangChamCong).Name);
        public II_tab_BangChamCong_HD0()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            ReportDocument rp = new rpt_tab_BangChamCong();
            int tods = 1;
            string tento = "TỔ TÂN BÌNH 01";
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo)) {
                 tods = 2;
                 tento = "TỔ TÂN BÌNH 02";
            }
            if ("TP01".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 3;
                tento = "TỔ TÂN PHÚ 01 ";
            }
            if ("TP02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 4;
                tento = "TỔ TÂN PHÚ 02";
            }
            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.reportChamCong_1(txtNam.Text.Trim(), ky, tods));
            rp.SetParameterValue("TODS", tento);
            rp.SetParameterValue("KYDS", ky);
            rp.SetParameterValue("TONGDHN", 12563);
            rp.SetParameterValue("TONGDC", txtNam.Text.Trim());
            crystalReportViewer1.ReportSource = rp;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            ReportDocument rp = new rpt_tab_BangChamCongHD0();
            int tods = 1;
            string tento = "TỔ TÂN BÌNH 01";
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 2;
                tento = "TỔ TÂN BÌNH 02";
            }
            if ("TP01".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 3;
                tento = "TỔ TÂN PHÚ 01 ";
            }
            if ("TP02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 4;
                tento = "TỔ TÂN PHÚ 02";
            }
            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.reportChamCongHD0(txtNam.Text.Trim(), ky, tods));
            rp.SetParameterValue("TODS", tento);
            rp.SetParameterValue("KYDS", ky);
            rp.SetParameterValue("TONGDHN", 12563);
            rp.SetParameterValue("TONGDC", txtNam.Text.Trim());
            crystalReportViewer1.ReportSource = rp;
        }

        //private void buttonX2_Click(object sender, EventArgs e)
        //{
        //    frm_NhapTangCuong frm = new frm_NhapTangCuong();
        //    if (frm.ShowDialog() == DialogResult.OK) {
        //        int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
        //        ReportDocument rp = new rpt_tab_BangChamCong();
        //        int tods = 1;
        //        string tento = "TỔ TÂN BÌNH 01";
        //        if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
        //        {
        //            tods = 2;
        //            tento = "TỔ TÂN BÌNH 02";
        //        }
        //        if ("TP01".Equals(DAL.SYS.C_USERS._toDocSo))
        //        {
        //            tods = 3;
        //            tento = "TỔ TÂN PHÚ 01 ";
        //        }
        //        if ("TP02".Equals(DAL.SYS.C_USERS._toDocSo))
        //        {
        //            tods = 4;
        //            tento = "TỔ TÂN PHÚ 02";
        //        }
        //        rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.reportChamCong_1(txtNam.Text.Trim(), ky, tods));
        //        rp.SetParameterValue("TODS", tento);
        //        rp.SetParameterValue("KYDS", ky);
        //        rp.SetParameterValue("TONGDHN", 12563);
        //        rp.SetParameterValue("TONGDC", txtNam.Text.Trim());
        //        crystalReportViewer1.ReportSource = rp;
        //    }
        //}

    }
}
