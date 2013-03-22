using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.GNKDT;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoThayDHN : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_BaoThayDHN()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbMaDMA.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM GNKDT_THONGTINDMA ORDER BY MADMA ASC ");
            cbMaDMA.ValueMember = "MADMA";
            cbMaDMA.DisplayMember = "MADMA";
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Load() {
            try
            {
                string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
                string nam = this.txtNam.Text;
                string madm = cbMaDMA.SelectedValue.ToString();
                if (this.rptHanheld.Checked)
                {
                    dataBangKe.DataSource = DAL.GNKDT.C_GNKDT.getThongTinDMAByHandheld(madm, ky, nam);
                    Utilities.DataGridV.formatRows(dataBangKe, "STT");
                }
                else if (this.rptHoaDon.Checked)
                {
                    dataBangKe.DataSource = DAL.GNKDT.C_GNKDT.getThongTinDMAByHoaDon(madm, ky, nam);
                    Utilities.DataGridV.formatRows(dataBangKe, "STT");
                }

            }
            catch (Exception)
            {

            }
}
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            GNKDT.Export.export(dataBangKe, cbMaDMA.SelectedValue.ToString());
        }

        private void dataBangKe_MouseClick(object sender, MouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        private void dataBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmDieuChinhDMA of = new frmDieuChinhDMA();
            if (of.ShowDialog() == DialogResult.OK) {
                Load();
            }
        }
    }
}