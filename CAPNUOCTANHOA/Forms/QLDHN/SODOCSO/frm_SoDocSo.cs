using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CAPNUOCTANHOA.Forms.QLDHN.SODOCSO
{
    public partial class frm_SoDocSo : Form
    {
        public frm_SoDocSo()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Nhập Lộ Trình Đọc Số.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_SoDocSo();
                rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.SoDocSo(txtSoBangKe.Text));                
                crystalReportViewer1.ReportSource = rp;
                this.crystalReportViewer1.Visible = true;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {

                if ("".Equals(this.txtSoBangKe.Text))
                {
                    MessageBox.Show(this, "Nhập Lộ Trình Đọc Số.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSoBangKe.Focus();
                }
                else
                {
                    ReportDocument rp = new rpt_SoDocSo();
                    rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.SoDocSo(txtSoBangKe.Text));
                    crystalReportViewer1.ReportSource = rp;
                    this.crystalReportViewer1.Visible = true;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }
    }
}
