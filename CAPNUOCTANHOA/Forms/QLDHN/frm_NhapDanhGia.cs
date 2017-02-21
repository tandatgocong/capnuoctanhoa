using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_NhapDanhGia : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_NhapDanhGia).Name);
        public frm_NhapDanhGia()
        {
            InitializeComponent();
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
            cbNhanVien.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getTable_CHAMCONG(tods);
            cbNhanVien.DisplayMember = "FULLNAME";
            cbNhanVien.ValueMember = "MAYDS";
        }

       

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //DONGHONUOC();
                //DONGCUA_();
                //TANGCUONG();
                DAL.QLDHN.C_QuanLyDongHoNuoc.Update();
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
        TB_BANGCHAMCONG chamcong = null;
        private void cbNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //DHN.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_DHN(int.Parse(this.cbNhanVien.SelectedValue + ""));
                //TANGCUONG_.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_TANGCUONG(int.Parse(this.cbNhanVien.SelectedValue + ""));
                //DONGCUA.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_DONGCUA(int.Parse(this.cbNhanVien.SelectedValue + ""));
                chamcong = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongBy(int.Parse(this.cbNhanVien.SelectedValue + ""));
            }
            catch (Exception)
            {

            }
        }

        #region loại dong cua
        public void tong_1()
        {
            if (("A,B,C").Contains(t1_F3D.Text.Replace(" ", ""))==true)
                s1_FTONG.Text = t1_F3D.Text;
            else
            {
                try
                {
                    s1_FTONG.Text = (int.Parse(this.t1_F1D.Text) + int.Parse(this.t1_F2D.Text) )+"";
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Lỗi ");
                }
            }


        }
        public int soluongdc()
        {
            int f = 0;
            if (n1_F1S.Value < 10)
                f = 10;
            else if (n1_F1S.Value > 10 && n1_F1S.Value < 20)
                f = 0;
            else
                f = -5;

            return f;
        }
        private void n1_F1S_ValueChanged(object sender, EventArgs e)
        {
            this.t1_F1D.Text = soluongdc() + "";
            tong_1();
        }

        private void n1_F2S_ValueChanged(object sender, EventArgs e)
        {
            this.t1_F2D.Text = ((-5) * n1_F2S.Value) + "";
            tong_1();
        }

        private void n1_F3S_ValueChanged(object sender, EventArgs e)
        {

        }
       

        private void t1_F3D_KeyPress(object sender, KeyPressEventArgs e)
        {
            tong_1();
        }
        #endregion

        #region loại ngung

        void tongngung()
        {
            if (("A,B,C").Contains(sNgung2.Text.Replace(" ", "")) == true)
                sNTong.Text = sNgung2.Text;
            else if (("A,B,C").Contains(sNgung3.Text.Replace(" ", "")) == true)
                sNTong.Text = sNgung3.Text;
            else
            {
                try
                {
                    sNTong.Text =(int.Parse(this.sNgung1.Text) + int.Parse(this.sNgung2.Text) + int.Parse(this.sNgung3.Text)) + "";
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Lỗi ");
                }    
            }
        }

        private void nNk1_ValueChanged(object sender, EventArgs e)
        {
            if (!c1N.Checked)
                sNgung1.Text = (nNk1.Value * 2)+"";
            else
                sNgung1.Text = (nNk1.Value * (-4)) + "";

            tongngung();
        }

        private void nNk2_ValueChanged(object sender, EventArgs e)
        {
            if (!c2N.Checked)
                sNgung2.Text = (nNk2.Value * (-5)) + "";
            else
                sNgung2.Text = (nNk2.Value * (-10)) + "";
            tongngung();
        }

        private void nNk3_ValueChanged(object sender, EventArgs e)
        {
            if (!c3N.Checked)
                sNgung3.Text = (nNk3.Value * (-10)) + "";
            else
                sNgung3.Text = (nNk3.Value * (-20)) + "";
            tongngung();
        }

        private void sNgung(object sender, KeyPressEventArgs e)
        {
            tongngung();
        }

        #endregion


        #region loại ketso

        void tongKetsso()
        {
            if (("A,B,C").Contains(dks3.Text.Replace(" ", "")) == true)
                dksTong.Text = dks3.Text;
            else
            {
                try
                {
                    dksTong.Text = (int.Parse(this.dks1.Text) + int.Parse(this.dks2.Text) + int.Parse(this.dks3.Text)) + "";
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Lỗi ");
                }
            }
        }
        private void nks1_ValueChanged(object sender, EventArgs e)
        {
            if (!c1K.Checked)
                dks1.Text = (nks1.Value * 10) + "";
            else
                dks1.Text = (nks1.Value * (0)) + "";

            tongKetsso();
        }

        private void nks2_ValueChanged(object sender, EventArgs e)
        {
            if (!c2K.Checked)
                dks2.Text = (nks2.Value * 0) + "";
            else
                dks2.Text = (nks2.Value * (-5)) + "";

            tongKetsso();
        }

        private void nks3_ValueChanged(object sender, EventArgs e)
        {
            if (!c3K.Checked)
                dks3.Text = (nks3.Value * (-5)) + "";
            else
                dks3.Text = (nks3.Value * (-10)) + "";

            tongKetsso();
        }
        
        private void dks3_TextChanged(object sender, EventArgs e)
        {
            tongKetsso();
        }

        #endregion

        #region loại đứt chì
       
        private void dcsl_ValueChanged(object sender, EventArgs e)
        {
            dcdiem.Text = (dcsl.Value * (-1)) + "";
            dcTong.Text = (dcsl.Value * (-1)) + "";
        }
        #endregion

        #region không tiếp cận
        public void tongtiepcan()
        {
            try
            {
                khTong.Text = (int.Parse(this.khdiem1.Text) + int.Parse(this.khdiem2.Text)  ) + "";
            }
            catch (Exception)
            {
                MessageBox.Show(this,"Lỗi ");
            }
        }
        private void khsl_ValueChanged(object sender, EventArgs e)
        {
            khdiem1.Text = (khsl.Value * (-10)) + "";
            tongtiepcan();
        }

        private void khdon_ValueChanged(object sender, EventArgs e)
        {
            khdiem2.Text = (khdon.Value * (-20)) + "";
            tongtiepcan();
        }  
        #endregion

        private void bgianlan_ValueChanged(object sender, EventArgs e)
        {
            gianlandiem.Text = (bgianlan.Value * (30)) + "";
            tonggianglan.Text = gianlandiem.Text;

        }

        #region nhắc nhở
        public void tongnhacnhoo()
        {
            try
            {
                tongnhacnho.Text = (int.Parse(this.todiem.Text) + int.Parse(this.doidiem.Text)) + "";
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Lỗi ");
            }
        }

        private void tonhacnho_ValueChanged(object sender, EventArgs e)
        {
            if (tonhacnho.Value == 1)
                this.todiem.Text = "0";
            else if (tonhacnho.Value == 2)
                this.todiem.Text = "-5";
            else if (tonhacnho.Value >= 3)
                this.todiem.Text = "-10";

            tongnhacnhoo();
        }

        private void doinhacnho_ValueChanged(object sender, EventArgs e)
        {
            if (doinhacnho.Value == 1)
                this.doidiem.Text = "0";
            else if (doinhacnho.Value == 2)
                this.doidiem.Text = "-10";
            else if (doinhacnho.Value >= 3)
                this.doidiem.Text = "-20";

            tongnhacnhoo();
        }
        #endregion

        private void nDocsai_ValueChanged(object sender, EventArgs e)
        {
            diemdocsai.Text = (nDocsai.Value * (-10)) + "";
            tongdocsai.Text = diemdocsai.Text;
        }

        private void btTinhDiem_ck(object sender, EventArgs e)
        {
            ////////////
            int dongcua = 0;
            string loai = "";
            try
            {
                dongcua = int.Parse(s1_FTONG.Text);
            }
            catch (Exception)
            {
                loai = s1_FTONG.Text;
            }
            ////////////
            int ngung = 0;
            try
            {
                ngung = int.Parse(sNTong.Text);
            }
            catch (Exception)
            {
                if (!loai.Equals(sNTong.Text))
                {
                    if (!"C".Equals(sNTong.Text))
                        loai = "C";
                    else
                        loai = "B";
                }
            }
            ////////////
            int ketso = 0;
            try
            {
                ketso = int.Parse(dksTong.Text);
            }
            catch (Exception)
            {
                if (!loai.Equals(dksTong.Text))
                {
                    if (!"C".Equals(dksTong.Text))
                        loai = "C";
                    else
                        loai = "B";
                }
            }

            ////////////
            int dutchi = 0;
            try
            {
                dutchi = int.Parse(dcTong.Text);
            }
            catch (Exception)
            {
                if (!loai.Equals(dcTong.Text))
                {
                    if (!"C".Equals(dcTong.Text))
                        loai = "C";
                    else
                        loai = "B";
                }
            }
            ////////////
            int khieunai = 0;
            try
            {
                khieunai = int.Parse(khTong.Text);
            }
            catch (Exception)
            {
                if (!loai.Equals(khTong.Text))
                {
                    if (!"C".Equals(khTong.Text))
                        loai = "C";
                    else
                        loai = "B";
                }
            }
            ////////////
            if (!loai.Equals(t6.Text))
            {
                if (!"C".Equals(t6.Text))
                    loai = "C";
                else
                    loai = "B";
            }
            //////////////
            int gianglan = 0;
            try
            {
                gianglan = int.Parse(tonggianglan.Text);
            }
            catch (Exception)
            {
            }
            ///////////
            int nhacnho = 0;
            try
            {
                nhacnho = int.Parse(tongnhacnho.Text);
            }
            catch (Exception)
            {
            }
            ////////////
            int doclo = 0;
            try
            {
                doclo = int.Parse(tongdocsai.Text);
            }
            catch (Exception)
            {
                if (!"C".Equals(tongdocsai.Text))
                    loai = "C";
                else
                    loai = "B";
            }

             if (!"C".Equals(diemnangxuat10.Text))
                    loai = "C";
             else if (!"B".Equals(diemnangxuat10.Text))
                    loai = "B";

             if (!"".Equals(loai.Replace(" ", "")))
                 this.txtDiemCuoiKy.Text = loai;
             else
             {
                 int tong = dongcua + ngung + ketso + dutchi + khieunai + gianglan + nhacnho + doclo;
                 this.txtDiemCuoiKy.Text = (100+ tong) + "";
             
             }
        }

    }
}
