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
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class tab_DieuChinhDS : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DieuChinhDS).Name);

        public tab_DieuChinhDS()
        {
            InitializeComponent();
            cbLoaiDieuChinh.SelectedIndex = 0;

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }
        TB_DULIEUKHACHHANG_HUYDB khachhang = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                if (khachhang != null)
                {
                    LOTRINH.Text = khachhang.LOTRINH;
                    DOT.Text = khachhang.DOT;
                    HOPDONG.Text = khachhang.HOPDONG;
                    HOTEN.Text = khachhang.HOTEN;
                    SONHA.Text = khachhang.SONHA;
                    TENDUONG.Text = khachhang.TENDUONG;
                    QUAN.Text = khachhang.QUAN;
                    PHUONGT.Text = khachhang.PHUONG;
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    HIEUDH.Text = khachhang.HIEUDH;
                    CO.Text = khachhang.CODH;
                    CAP.Text = khachhang.CAP;
                    SOTHAN.Text = khachhang.SOTHANDH;
                    VITRI.Text = khachhang.VITRIDHN;
                    khachhang.TAILAPDB = true;
                    khachhang.NGAYTAILAP = DateTime.Now;
                    khachhang.MODIFYBY = DAL.SYS.C_USERS._userName;
                    khachhang.MODIFYDATE = DateTime.Now;
                    this.cbMayDocSo.SelectedIndex = 0;
                    this.cbDotDS.SelectedIndex = 0;
                    this.cbToDocSo.SelectedIndex = 1;
                }
            }
        }

        private void btTaiLapDanhBo_Click(object sender, EventArgs e)
        {
            try
            {
                khachhang.TL_SOPHIEU = SOPHIEU.Text;
                khachhang.TL_HIEULUC = HIEULUC.Text;
                khachhang.TL_DOT = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
                DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                string SHS = "";
                string DANHBO = this.txtDanhBo.Text.Replace("-", "");
                string HOPDONG = this.HOPDONG.Text;
                DateTime NGAYGAN = this.NGAYGAN.Value;
                string GIABIEU = this.GIABIEU.Text;
                string DINHMUC = this.DINHMUC.Text;
                string HOTEN = this.HOTEN.Text;
                string SONHA = this.SONHA.Text;
                string DUONG = this.TENDUONG.Text;
                string PHUONG = this.PHUONGT.Text;
                string QUAN = this.QUAN.Text;
                string HIEU = this.QUAN.Text;
                string COTLK = this.CO.Text;
                string SOTLK = this.SOTHAN.Text;
                string CHISOTLK = "0";
                string MAYDS = cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString();
                string DOTDS = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
                string TODS = "TB01";
                if (this.cbToDocSo.SelectedIndex == 1)
                {
                    TODS = "TB02";
                }
                else if (this.cbToDocSo.SelectedIndex == 2)
                {
                    TODS = "TP";
                }
                else
                {
                    TODS = "TB01";
                }
                TB_GANMOI tb = DAL.DULIEUKH.C_GanMoi.finByDanhBo(DANHBO);
                if (tb == null)
                {
                    tb = new TB_GANMOI();
                    tb.SHS = SHS;
                    tb.DANHBO = DANHBO;
                    tb.HOPDONG = HOPDONG;
                    tb.HOTEN = HOTEN;
                    tb.SONHA = SONHA;
                    tb.DUONG = DUONG;
                    tb.MAPHUONG = PHUONG;
                    tb.MAQUAN = QUAN;
                    tb.GIABIEU = GIABIEU;
                    tb.DINHMUC = DINHMUC;
                    tb.HIEULUC = "";
                    tb.NGAYGANTLK = NGAYGAN;
                    tb.HIEU = HIEU;
                    tb.COTLK = COTLK;
                    tb.SOTLK = SOTLK;
                    tb.CHISOTLK = CHISOTLK;
                    tb.SOHO = "1";
                    tb.TODS = TODS;
                    tb.DOT = DOTDS;
                    tb.MAYDS = MAYDS;
                    tb.CREATEDATE = DateTime.Now;
                    tb.CREATEBY = DAL.SYS.C_USERS._userName;
                    if (DAL.DULIEUKH.C_GanMoi.Insert(tb))
                    {
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    tb.HOPDONG = HOPDONG;
                    tb.HOTEN = HOTEN;
                    tb.SONHA = SONHA;
                    tb.DUONG = DUONG;
                    tb.MAPHUONG = PHUONG;
                    tb.MAQUAN = QUAN;
                    tb.GIABIEU = GIABIEU;
                    tb.DINHMUC = DINHMUC;
                    tb.HIEULUC = "";
                    tb.NGAYGANTLK = NGAYGAN;
                    tb.HIEU = HIEU;
                    tb.COTLK = COTLK;
                    tb.SOTLK = SOTLK;
                    tb.CHISOTLK = CHISOTLK;
                    tb.SOHO = "1";
                    tb.TODS = TODS;
                    tb.DOT = DOTDS;
                    tb.MAYDS = MAYDS;
                    tb.MODIFYDATE = DateTime.Now;
                    tb.MODIFYBY = DAL.SYS.C_USERS._userName;
                    if (DAL.DULIEUKH.C_GanMoi.Update())
                    {
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btInPhieuDieuChinh_Click(object sender, EventArgs e)
        {

            ReportDocument rp = new rpt_PhieuDCTLDBO();
            rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.reportHuyDB(this.txtDanhBo.Text.Replace("-", "")));           
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }
}
