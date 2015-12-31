using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoCaoTongKet : UserControl
    {
        public frm_BaoCaoTongKet()
        {
            InitializeComponent();
        }

        private void radioThayDinhKy_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tbTongKetDinhKy());
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tb_TinhHinhBaoThay());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tab_TongKetHandHeld());
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tab_TieuThuThap());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tab_TongKetLoaiHinhKD());
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new F_tab_TongKetLoaiHinhKD_TieuThuThap());
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new G_tab_DiemCodeTieuThu());
        }

        private void ThongKeDHN(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new AA_tab_ThongKeDHN());

        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
             this.splitContainer1.Panel2.Controls.Clear();
             this.splitContainer1.Panel2.Controls.Add(new H_tab_BienDocCS());
            
        }
      
        private void radioButton8_Click(object sender, EventArgs e)
        {
             this.splitContainer1.Panel2.Controls.Clear();
             this.splitContainer1.Panel2.Controls.Add(new I_tab_BangChamCong());
        }

        private void rptDSCode_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new J_tab_DanhSachCodeK());
        }

        private void rptGanMoi_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new K_tab_ThongKeGanMoi());
        }

        private void rptThayDoi_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new L_tab_LoTrinhThayDoi());
            
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
              this.splitContainer1.Panel2.Controls.Clear();
              this.splitContainer1.Panel2.Controls.Add(new M_tab_SoLieuTongKet());
            
            
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new N_tab_DongHoHieuCu());
        }

        private void radioTKHOADON_Click(object sender, EventArgs e)
        {
             this.splitContainer1.Panel2.Controls.Clear();
             this.splitContainer1.Panel2.Controls.Add(new M_tab_ThongHoaDon());
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioTheoDoiHD0_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioTheoDoiHD0_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new O_tab_TheoDoiHoaDon0());
         
        }

        private void radioButtonTheodoicamKet_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new P_tab_TheoDoiCamKet());
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new O_tab_TheoDoiHoaDon0());
        }

        private void radioButton11_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new P_tab_ThongKeGhiChu());
        }

        private void rHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new W_tab_ThongKeHoaDon());
        }

      
    }
}
