using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Configuration;
using CAPNUOCTANHOA.Forms.QLDHN;
using CAPNUOCTANHOA.View.Users;
using CAPNUOCTANHOA.Forms.DoiTCTB;
using CAPNUOCTANHOA.Forms.QLDHN.SODOCSO;
using CAPNUOCTANHOA.Forms.TimKiem;
using CAPNUOCTANHOA.Forms.BanKTKS;
using CAPNUOCTANHOA.Forms.DoiThuTien;
namespace CAPNUOCTANHOA
{
    public partial class frm_Main : Form
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(frm_Main).Name);
        public frm_Main()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Utilities.Files.getFileOnServer();
        }
        public static frm_Login dn = new frm_Login();
        public void dangnhap()
        {
            CNTANHOA.CNTANHOA.Conecttionstring();
            dn.ShowDialog();
            if (DAL.SYS.C_USERS._roles != null)
            {
                role(DAL.SYS.C_USERS._roles);
            }
            this.Text = "Tan Hoa Water Co., ltd - Nhân Viên : " + DAL.SYS.C_USERS._fullName;
        }
        public void role(string role)
        {

            if ("AD".Equals(DAL.SYS.C_USERS._roles.Trim()))
            {
                this.menuDoiQLDHN.Visible = true;
                this.menuDTCTB.Visible = true;
                this.banKTKS.Visible = true;
                ribbonDoiThuTien.Visible = true;
            }
            else
            {
                menuDieuChinhThongSo.Visible = false;
                if ("QLDHN".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                {
                    ribbonDoiThuTien.Visible = false;
                    this.menuDoiQLDHN.Visible = true;
                    this.menuDTCTB.Visible = false;
                    menuDieuChinhThongSo.Visible = true;
                    if ("GM,TH".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        cmdBaoThay.Visible=false;
                        menuKiemTra.Visible=false;
                        yeucaukiemtra.Visible = false;
                        menuDieuChinhKH.Visible = true;
                        btLoTrinh.Visible = true;
                        handHeld.Visible = false;
                    }else{
                        cmdBaoThay.Visible = true;
                        menuKiemTra.Visible = true;
                        btLoTrinh.Visible = true; 
                        yeucaukiemtra.Visible = true;
                        handHeld.Visible = true;
                    }if ("GM".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        menuDieuChinhKH.Visible = false;
                    }if ("TK".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        handHeld.Visible = false;
                    }
                }
                else if ("DTCTB".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                {
                    ribbonDoiThuTien.Visible = false;
                    this.menuDoiQLDHN.Visible = false;
                    this.menuDTCTB.Visible = true;

                }
                else if ("BANKTKS".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                {
                    ribbonDoiThuTien.Visible = false;
                    this.menuDoiQLDHN.Visible = false;
                    this.menuDTCTB.Visible = false;
                    this.banKTKS.Visible = true;
                }
                else if ("THUTIEN".Equals(DAL.SYS.C_USERS._maphong.Trim())){
                    ribbonDoiThuTien.Visible = true;
                    this.menuDoiQLDHN.Visible = false;
                    this.menuDTCTB.Visible = false;
                    this.banKTKS.Visible = false;
                }
            }
            this.subDoiMatKhau.Visible = true;
            this.subDangXuat.Visible = true;
            this.subdangnhap.Visible = false;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            this.Show();
            dangnhap();            
        }

        private void caculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void microsoftWord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void microsoftAccess_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSACCESS.EXE");
        }

        private void microsoftExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }

        private void webBrowserTool_Click(object sender, EventArgs e)
        {
            try
            {
                this.PanelContent.Controls.Clear();
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Navigate("http://office.capnuoctanhoa.com.vn/security/login.aspx?action=expired");
                webBrowser.Dock = DockStyle.Fill;
                this.PanelContent.Controls.Add(webBrowser);
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Form " + ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void cmdBaoThay_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_BaoThayVaXuLy baothay = new frm_BaoThayVaXuLy();
            baothay.Height = PanelContent.Size.Height-20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void menuHoanCongThay_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frmHoanCongThay baothay = new frmHoanCongThay();
            baothay.Height = PanelContent.Size.Height-20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
            
        }

        private void menuKiemTra_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_KiemTraThayDinhKy baothay = new frm_KiemTraThayDinhKy();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void subThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void subDangXuat_Click(object sender, EventArgs e)
        {
            this.menuDoiQLDHN.Visible = false;
            this.menuDTCTB.Visible = false;

            DAL.SYS.C_USERS._fullName = null;
            DAL.SYS.C_USERS._roles = null;
            DAL.SYS.C_USERS._userName = null;
            this.subDoiMatKhau.Visible = false;
            this.subDangXuat.Visible = false;
            this.subdangnhap.Visible = true;
        }

        private void subDoiMatKhau_Click(object sender, EventArgs e)
        {
            frm_ChangePassword chang = new frm_ChangePassword();
            chang.ShowDialog();
        }

        private void subdangnhap_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void baocaoTongKet_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_BaoCaoTongKet baothay = new frm_BaoCaoTongKet();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void menuHeThong_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(panelHome);
        }

        private void menuTCTB_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_BaoCaoTCTB baothay = new frm_BaoCaoTCTB();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void hcThayThuDHN_Click(object sender, EventArgs e)
        {

        }

        private void menuLayDuLieuGanMoi_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_GetDataGanMoi baothay = new frm_GetDataGanMoi();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void btChuyenBK_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_LoTrinhDocSo baothay = new frm_LoTrinhDocSo();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void chiso_Click(object sender, EventArgs e)
        {
            frm_SoDocSo frm = new frm_SoDocSo();
            frm.ShowDialog();
        }

        private void menuDieuChinhKH_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
           // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frm_DieuChinhThongTin baothay = new frm_DieuChinhThongTin();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height-5;
            baothay.Width = PanelContent.Size.Width-5;
            PanelContent.Controls.Add(baothay);
        }

        private void tbTraCuuThongTin_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frmPhieuChepTieuThu baothay = new frmPhieuChepTieuThu();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void yeucaukiemtra_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frm_PhieuKiemTra baothay = new frm_PhieuKiemTra();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void hcXuLyTroNgaiThay_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_BaoThayVaXuLy baothay = new frm_BaoThayVaXuLy();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void menuInPhieuTieuTHu_Click(object sender, EventArgs e)
        {
             PanelContent.Controls.Clear();
             frmPhieuChepTieuThu baothay = new frmPhieuChepTieuThu();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void chepTieuThu_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frmPhieuChepTieuThu baothay = new frmPhieuChepTieuThu();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void tracuuThay_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frmTimKiem baothay = new frmTimKiem();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            tb_ThayDoiBaoCao baothay = new tb_ThayDoiBaoCao();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void handHeld_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frm_CapNhatThongTin baothay = new frm_CapNhatThongTin();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            Inthubao baothay = new Inthubao();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void toolDongNuoc_Click(object sender, EventArgs e)
        {

            PanelContent.Controls.Clear();
            frm_CatNuoc baothay = new frm_CatNuoc();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void menuTraCuu_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            TimKiemThongTin baothay = new TimKiemThongTin();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void menuBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_ThongKe baothay = new frm_ThongKe();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void toolNhanDon_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_NhanDon_ baothay = new frm_NhanDon_();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void toolDmChungCu_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_DMChungCu baothay = new frm_DMChungCu();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void menuTheoDoiDM_Click(object sender, EventArgs e)
        {
             PanelContent.Controls.Clear();
             frm_TheoDoiDM baothay = new frm_TheoDoiDM();
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
            
        }
        
    }
}
