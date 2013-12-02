using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.DoiTCTB.Tab;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.DAL.THUTIEN;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiThuTien.BC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    public partial class frm_ThongKe : UserControl
    {
        public frm_ThongKe()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month;
        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {

            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            if (theoNgay.IsSelected)
            {
                ReportDocument rp = new crpt_ThongTinDongNuoc();
                rp.SetDataSource(DAL.THUTIEN.C_ThuTien.ReportByDay(Utilities.DateToString.NgayVN(dateTimePickernay)));
                rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC NGÀY " + Utilities.DateToString.NgayVN(dateTimePickernay));
                crystalReportViewer1.ReportSource = rp;
            }
            else if (theoThangNam.IsSelected)
            {

                if (ky == 0) {
                    ReportDocument rp = new crpt_ThongTinDongNuoc();
                    rp.SetDataSource(DAL.THUTIEN.C_ThuTien.ReportByYear(nam + ""));
                    rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC NĂM " + nam);
                    crystalReportViewer1.ReportSource = rp;
                }
                else
                {
                    ReportDocument rp = new crpt_ThongTinDongNuoc();
                    rp.SetDataSource(DAL.THUTIEN.C_ThuTien.ReportByDate(ky + "", nam + ""));
                    rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC THÁNG " + ky + "/" + nam);
                    crystalReportViewer1.ReportSource = rp;
                }
            }
            else if (tuNgay.IsSelected)
            {
                ReportDocument rp = new crpt_ThongTinDongNuoc();
                rp.SetDataSource(DAL.THUTIEN.C_ThuTien.ReportByToDate(Utilities.DateToString.NgayVN(dateTuNgay), Utilities.DateToString.NgayVN(dateDenNgay)));
                rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC TỪ NGÀY  " + Utilities.DateToString.NgayVN(dateTuNgay) + " ĐẾN NGÀY " + Utilities.DateToString.NgayVN(dateDenNgay));
                crystalReportViewer1.ReportSource = rp;
            }
        }
    }
}