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
 

namespace CAPNUOCTANHOA
{
    public partial class frm_Main : Form
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(frm_Main).Name);
        public frm_Main()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            //     frm_BaoThayDHN frm = new frm_BaoThayDHN();
            //frm.MdiParent = this;
            //frm.Show();
           // dataGridView1.DataSource = DAL.OledbConnection.getDataTable(ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString,"SELECT * FROM LyLichDHN WHERE DOT='20'"); 
           

            
        }
        public static frm_Login dn = new frm_Login();
        public void dangnhap()
        {
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
                //menuQuanTri.Visible = true;
                //this.PanelContent.Controls.Clear();
                //this.PanelContent.Controls.Add(new Admin_Main());
            }
            else if ("US".Equals(DAL.SYS.C_USERS._roles.Trim()))
            {
                //menuQuanTri.Visible = false;
                if ("QLDHN".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                {
                    this.menuDoiQLDHN.Visible = true;
                    this.menuDTCTB.Visible = false;

                }
                else if ("DTCTB".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                {
                    this.menuDoiQLDHN.Visible = false;
                    this.menuDTCTB.Visible = true;

                }
                //else if ("DHN".Equals(DAL.SYS.C_USERS._maphong.Trim()))
                //{
                //    this.menuQLDHNuoc.Visible = true;
                //    this.iconMenuPanel.Controls.Clear();
                //    this.iconMenuPanel.Controls.Add(group_DoiDHN);
                //    group_DoiDHN.Visible = true;

                //}
            }
            //else if ("QT".Equals(DAL.C_USERS._roles.Trim()))
            //{

            //    this.menuToThietKe.Visible = true;
            //    this.iconMenuPanel.Controls.Clear();
            //    this.menuKHVT.Visible = true;
            //    this.menuQLDHNuoc.Visible = true;
            //}
 
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
            frm_BaoThayDHN baothay = new frm_BaoThayDHN();
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
            if (MessageBox.Show(this, "Thoát Chương Trình ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
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
            PanelContent.Controls.Clear();
            frmHoanCongThayThu baothay = new frmHoanCongThayThu();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);

        }

        private void menuLayDuLieuGanMoi_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_GetDataGanMoi baothay = new frm_GetDataGanMoi();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

    }
}
