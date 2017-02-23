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
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_NhapDanhGia : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_NhapDanhGia).Name);
        int tods = 0;
        TB_BANGCHAMCONG_DANHGIA dgg = null;
        string tento = "ĐỘI";
        public frm_NhapDanhGia()
        {
            InitializeComponent();
           
            
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
            if ("TB01".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 1;
                tento = "TỔ TÂN BÌNH 01";
            }
            cbNhanVien.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getTable_CHAMCONG(tods);
            cbNhanVien.DisplayMember = "FULLNAME";
            cbNhanVien.ValueMember = "MAYDS";
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
        }

        void refesh()
        {
            n1_F2S.Value = 0;
            t1_F2D.Text = "0";

            n1_F2S.Value = 0;
            t1_F2D.Text = "0";


            n1_F3S.Value = 0;
            t1_F3D.Text = "0";
            this.s1_FTONG.Text = "0";

            ///////////////
            nks1.Value = 0;
            c1N.Checked = false;
            sNgung1.Text = "0";

            nks2.Value = 0;
            c2N.Checked = false;
            sNgung2.Text = "0";

            nks3.Value = 0;
            c3N.Checked = false;
            sNgung3.Text = "0";

            this.sNTong.Text = "";

            ///////////////
            nks1.Value = 0;
            c1K.Checked = false;
            dks1.Text = "0";

            nks2.Value = 0;
            c2K.Checked = false;
            dks3.Text = "0";

            nks3.Value = 0;
            c3K.Checked = false;
            dks3.Text = "0";

            this.dksTong.Text = "0"; ;
            ///////////////
            dcsl.Value = 0;
            dcdiem.Text = "0";
            dcTong.Text = "0";
            //////

            khsl.Value = 0;
            khdiem1.Text = "0";
            khdon.Value = 0;
            khdiem2.Text = "0";
            this.khTong.Text = "0";
            ///////////////
            this.t6.Text = ""; 
            ///////////
            bgianlan.Value = 0;
            gianlandiem.Text = "0";
            this.tonggianglan.Text = "0";
            ///////////
            tonhacnho.Value = 0;
            todiem.Text = "0";
            doinhacnho.Value = 0;
            doidiem.Text = "0";
            this.tongnhacnho.Text = "0";
            ////////
            nDocsai.Value = 0;
            diemdocsai.Text = "0";
            this.tongdocsai.Text = "0";
            ////////
            this.diemnangxuat10.Text = "";
            this.txtDiemCuoiKy.Text = "";
        }
        private void cbNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int nam = int.Parse(txtNam.Text.Trim());
                int nv = int.Parse(this.cbNhanVien.SelectedValue + "");
                dgg = DAL.QLDHN.C_QuanLyDongHoNuoc.finByChamCongDanhGia(ky, nam, nv);
                if (dgg != null)
                {
                    n1_F2S.Value = decimal.Parse(dgg._1_F1S + "");
                    t1_F2D.Text = dgg._1_F1D + "";

                    n1_F2S.Value = decimal.Parse(dgg._1_F2S + "");
                    t1_F2D.Text = dgg._1_F2D + "";


                    n1_F3S.Value = decimal.Parse(n1_F3S.Value + "");
                    t1_F3D.Text = dgg._1_F3D + "";
                    this.s1_FTONG.Text = dgg._1_FTONG;

                    ///////////////
                    nks1.Value = decimal.Parse(dgg._2_NF1S + "");
                    c1N.Checked = dgg._2_N1P.Value;
                    sNgung1.Text = dgg._2_N1D + "";

                    nks2.Value = decimal.Parse(dgg._2_N2S + "");
                    c2N.Checked = dgg._2_N2P.Value;
                    sNgung2.Text = dgg._2_N3D + "";

                    nks3.Value = decimal.Parse(dgg._2_N3S + "");
                    c3N.Checked = dgg._2_N3P.Value;
                    sNgung3.Text = dgg._2_N3S + "";

                    this.sNTong.Text = dgg._2_NTONG;

                    ///////////////
                    nks1.Value = int.Parse(dgg._3_K1S + "");
                    c1K.Checked = dgg._3_K1P.Value;
                    dks1.Text = dgg._3_K2S + "";

                    nks2.Value = int.Parse(dgg._3_K2S + "");
                    c2K.Checked = dgg._3_K2P.Value;
                    dks3.Text = dgg._3_K2S + "";

                    nks3.Value = int.Parse(dgg._3_K3S + "");
                    c3K.Checked = dgg._3_K3P.Value;
                    dks3.Text = dgg._3_K3S + "";

                    this.dksTong.Text = dgg._3_KTONG;
                    ///////////////
                    dcsl.Value = int.Parse(dgg._4_DS + "");
                    dcdiem.Text = dgg._4_DD + "";
                    dcTong.Text = dgg._4_DTONG;
                    //////

                    khsl.Value = int.Parse(dgg._5_TCKGT + "");
                    khdiem1.Text = dgg._5_SLKGT + "";
                    khdon.Value = int.Parse(dgg._5_SLGT + "");
                    khdiem2.Text = dgg._5_DGT + "";
                    this.khTong.Text = dgg._5_KNTONG;
                    ///////////////
                    this.t6.Text = dgg._6_TCTONG;
                    ///////////
                    bgianlan.Value = int.Parse(dgg._7_GLC + "");
                    gianlandiem.Text = dgg._7_GLTC + "";
                    this.tonggianglan.Text = dgg._7_GLTONG;
                    ///////////
                    tonhacnho.Value = int.Parse(dgg._8_TNN + "");
                    todiem.Text = dgg._8_TNNS + "";
                    doinhacnho.Value = int.Parse(dgg._8_DNN + "");
                    doidiem.Text = dgg._8_DNNS + "";
                    this.tongnhacnho.Text = dgg._8_NNTONG;
                    ////////
                    nDocsai.Value = int.Parse(dgg._9_DSCS + "");
                    diemdocsai.Text = dgg._9_DSCSS + "";
                    this.tongdocsai.Text = dgg._9_DSTONG;
                    ////////
                    this.diemnangxuat10.Text = dgg._10_TONG;
                    this.txtDiemCuoiKy.Text = dgg.TONGDIEM;
                }
                else
                {
                    refesh();
                }

            }
            catch (Exception ex)
            {
                dgg = null;
                refesh();
                log.Error(ex.Message);               
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgg != null)
                {
                    DAL.LinQConnection.ExecuteCommand_("DELETE FROM TB_BANGCHAMCONG_DANHGIA WHERE ID='" + dgg.ID + "'  ");
                
                }
                int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int nam = int.Parse(txtNam.Text.Trim());
                int nv = int.Parse(this.cbNhanVien.SelectedValue + "");
                int f = 0;
                TB_BANGCHAMCONG_DANHGIA dg = new TB_BANGCHAMCONG_DANHGIA();
                dg.MAYDS = nv;
                dg.KY = ky;
                dg.NAM = nam;
                dg.TODS = tods;
                dg.NAME = this.cbNhanVien.Text;
                dg.FULLNAME = this.cbNhanVien.Text;
                ////////////////
                dg._1_F1S = int.Parse(n1_F2S.Value + "");
                dg._1_F1D = int.Parse(t1_F2D.Text + "");

                dg._1_F2S = int.Parse(n1_F2S.Value + "");
                dg._1_F2D = int.Parse(t1_F2D.Text + "");

                dg._1_F3S = int.Parse(n1_F3S.Value + "");
                dg._1_F3D = int.Parse(t1_F3D.Text + "");
                dg._1_FTONG = this.s1_FTONG.Text;

                ///////////////
                dg._2_NF1S = int.Parse(nks1.Value + "");
                dg._2_N1P = c1N.Checked;
                dg._2_N1D = int.Parse(sNgung1.Text + "");

                dg._2_N2S = int.Parse(nks2.Value + "");
                dg._2_N2P = c2N.Checked;
                dg._2_N2D = int.Parse(sNgung2.Text + "");

                dg._2_N3S = int.Parse(nks3.Value + "");
                dg._2_N3P = c3N.Checked;
                dg._2_N3D = int.Parse(sNgung3.Text + "");

                dg._2_NTONG = this.sNTong.Text;

                ///////////////
                dg._3_K1S = int.Parse(nks1.Value + "");
                dg._3_K1P = c1K.Checked;
                dg._3_K1D = int.Parse(dks1.Text + "");

                dg._3_K2S = int.Parse(nks2.Value + "");
                dg._3_K2P = c2K.Checked;
                dg._3_K2D = int.Parse(dks3.Text + "");

                dg._3_K3S = int.Parse(nks3.Value + "");
                dg._3_K3P = c3K.Checked;
                dg._3_K3D = int.Parse(dks3.Text + "");

                dg._3_KTONG = this.dksTong.Text;
                ///////////////
                dg._4_DS = int.Parse(dcsl.Value + "");
                dg._4_DD = int.Parse(dcdiem.Text + "");
                dg._4_DTONG = dcTong.Text;
                //////

                dg._5_TCKGT = int.Parse(khsl.Value + "");
                dg._5_SLKGT = int.Parse(khdiem1.Text + "");
                dg._5_SLGT = int.Parse(khdon.Value + "");
                dg._5_DGT = int.Parse(khdiem2.Text + "");
                dg._5_KNTONG = this.khTong.Text;
                ///////////////
                dg._6_KTC = 0;
                dg._6_DKTC = 0;
                dg._6_TCTONG = this.t6.Text;
                ///////////
                dg._7_GLC = int.Parse(bgianlan.Value + "");
                dg._7_GLTC = int.Parse(gianlandiem.Text + "");
                dg._7_GLTONG = this.tonggianglan.Text;
                ///////////
                dg._8_TNN = int.Parse(tonhacnho.Value + "");
                dg._8_TNNS = int.Parse(todiem.Text + "");
                dg._8_DNN = int.Parse(doinhacnho.Value + "");
                dg._8_DNNS = int.Parse(doidiem.Text + "");
                dg._8_NNTONG = this.tongnhacnho.Text;
                ////////
                dg._9_DSCS = int.Parse(nDocsai.Value + "");
                dg._9_DSCSS = int.Parse(diemdocsai.Text + "");
                dg._9_DSTONG = this.tongdocsai.Text;
                ////////
                dg._10_TONG = this.diemnangxuat10.Text;

                dg.TONGDIEM = this.txtDiemCuoiKy.Text;

                dg.CREATEBY = DAL.SYS.C_USERS._userName;
                dg.CREATEDATE = DateTime.Now.Date;

                DAL.QLDHN.C_QuanLyDongHoNuoc.InsertDanhGia(dg);

                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(this, "Lỗi !", "..: Thông Báo :..", MessageBoxButtons.OK);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

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
            if (n1_F1S.Value <= 10)
                f = 10;
            else if (n1_F1S.Value > 10 && n1_F1S.Value <= 20)
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
               
            }
            ////////////
            int ketso = 0;
            try
            {
                ketso = int.Parse(dksTong.Text);
            }
            catch (Exception)
            {
               
            }

            ////////////
            int dutchi = 0;
            try
            {
                dutchi = int.Parse(dcTong.Text);
            }
            catch (Exception)
            {
                
            }
            ////////////
            int khieunai = 0;
            try
            {
                khieunai = int.Parse(khTong.Text);
            }
            catch (Exception)
            {
                
            }
            ////////////
            if (!loai.Equals(t6.Text))
            {
                if (!"C".Equals(t6.Text))
                    loai = "C";
                else
                    loai = "B";
            }
            int tiepcam = 0;
            try
            {
                tiepcam = int.Parse(t6.Text);
            }
            catch (Exception)
            {

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
               
            }
            loai = diemnangxuat10.Text;
            
             if (!"".Equals(loai.Replace(" ", "")))
                 this.txtDiemCuoiKy.Text = loai;
             else
             {
                 int tong = dongcua + ngung + ketso + dutchi + khieunai + gianglan + nhacnho + doclo + tiepcam;
                 this.txtDiemCuoiKy.Text = (100+ tong) + "";
             
             }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_BangChamCongDanhGia();
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());



            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.reportDanhGia(txtNam.Text.Trim(), ky, tods));
            rp.SetParameterValue("TODS", tento);
            rp.SetParameterValue("KYDS", cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim());
            frm_Reports f = new frm_Reports(rp);
            f.ShowDialog();
        }

    }
}
