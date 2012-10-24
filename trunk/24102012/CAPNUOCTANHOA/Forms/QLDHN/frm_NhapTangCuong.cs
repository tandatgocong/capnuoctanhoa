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
    public partial class frm_NhapTangCuong : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_NhapTangCuong).Name);
        public frm_NhapTangCuong()
        {
            InitializeComponent();
            int tods = 1;
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 2;
            }
            if ("TP".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 3;
            }
            cbNhanVien.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getTable_CHAMCONG(tods);
            cbNhanVien.DisplayMember = "FULLNAME";
            cbNhanVien.ValueMember = "MAYDS";
        }

        public void DONGHONUOC()
        {
            if (chamcong != null)
            {
                for (int i = 0; i < DHN.Rows.Count; i++)
                {
                    string DOT01 = DHN.Rows[i].Cells["DOT01"].Value + "";
                    string DOT02 = DHN.Rows[i].Cells["DOT02"].Value + "";
                    string DOT03 = DHN.Rows[i].Cells["DOT03"].Value + "";
                    string DOT04 = DHN.Rows[i].Cells["DOT04"].Value + "";
                    string DOT05 = DHN.Rows[i].Cells["DOT05"].Value + "";
                    string DOT06 = DHN.Rows[i].Cells["DOT06"].Value + "";
                    string DOT07 = DHN.Rows[i].Cells["DOT07"].Value + "";
                    string DOT08 = DHN.Rows[i].Cells["DOT08"].Value + "";
                    string DOT09 = DHN.Rows[i].Cells["DOT09"].Value + "";
                    string DOT10 = DHN.Rows[i].Cells["DOT10"].Value + "";
                    string DOT11 = DHN.Rows[i].Cells["DOT11"].Value + "";
                    string DOT12 = DHN.Rows[i].Cells["DOT12"].Value + "";
                    string DOT13 = DHN.Rows[i].Cells["DOT13"].Value + "";
                    string DOT14 = DHN.Rows[i].Cells["DOT14"].Value + "";
                    string DOT15 = DHN.Rows[i].Cells["DOT15"].Value + "";
                    string DOT16 = DHN.Rows[i].Cells["DOT16"].Value + "";
                    string DOT17 = DHN.Rows[i].Cells["DOT17"].Value + "";
                    string DOT18 = DHN.Rows[i].Cells["DOT18"].Value + "";
                    string DOT19 = DHN.Rows[i].Cells["DOT19"].Value + "";
                    string DOT20 = DHN.Rows[i].Cells["DOT20"].Value + "";
                    
                    try{
                        chamcong.DOT01 = int.Parse(DOT01.Replace(" ",""));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        chamcong.DOT02 = int.Parse(DOT02.Replace(" ", ""));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        chamcong.DOT03 = int.Parse(DOT03.Replace(" ", ""));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        chamcong.DOT04 = int.Parse(DOT04.Replace(" ", ""));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        chamcong.DOT05 = int.Parse(DOT05.Replace(" ", ""));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        chamcong.DOT06 = int.Parse(DOT06.Replace(" ", ""));
                    }
                    catch (Exception)
                    {
                    }

                    try { chamcong.DOT07 = int.Parse(DOT07.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT08 = int.Parse(DOT08.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT09 = int.Parse(DOT09.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT10 = int.Parse(DOT10.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT10 = int.Parse(DOT10.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT11 = int.Parse(DOT11.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT12 = int.Parse(DOT12.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT13 = int.Parse(DOT13.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT14 = int.Parse(DOT14.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT15 = int.Parse(DOT15.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT16 = int.Parse(DOT16.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT17 = int.Parse(DOT17.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT18 = int.Parse(DOT18.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT19 = int.Parse(DOT19.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT20 = int.Parse(DOT20.Replace(" ", "")); }
                    catch (Exception) { }
                }
            }


        }

        public void DONGCUA_()
        {
            if (chamcong != null)
            {
                for (int i = 0; i < DONGCUA.Rows.Count; i++)
                {
                    string DOT01_DC = DONGCUA.Rows[i].Cells["DOT01_DC"].Value + "";
                    string DOT02_DC = DONGCUA.Rows[i].Cells["DOT02_DC"].Value + "";
                    string DOT03_DC = DONGCUA.Rows[i].Cells["DOT03_DC"].Value + "";
                    string DOT04_DC = DONGCUA.Rows[i].Cells["DOT04_DC"].Value + "";
                    string DOT05_DC = DONGCUA.Rows[i].Cells["DOT05_DC"].Value + "";
                    string DOT06_DC = DONGCUA.Rows[i].Cells["DOT06_DC"].Value + "";
                    string DOT07_DC = DONGCUA.Rows[i].Cells["DOT07_DC"].Value + "";
                    string DOT08_DC = DONGCUA.Rows[i].Cells["DOT08_DC"].Value + "";
                    string DOT09_DC = DONGCUA.Rows[i].Cells["DOT09_DC"].Value + "";
                    string DOT10_DC = DONGCUA.Rows[i].Cells["DOT10_DC"].Value + "";
                    string DOT11_DC = DONGCUA.Rows[i].Cells["DOT11_DC"].Value + "";
                    string DOT12_DC = DONGCUA.Rows[i].Cells["DOT12_DC"].Value + "";
                    string DOT13_DC = DONGCUA.Rows[i].Cells["DOT13_DC"].Value + "";
                    string DOT14_DC = DONGCUA.Rows[i].Cells["DOT14_DC"].Value + "";
                    string DOT15_DC = DONGCUA.Rows[i].Cells["DOT15_DC"].Value + "";
                    string DOT16_DC = DONGCUA.Rows[i].Cells["DOT16_DC"].Value + "";
                    string DOT17_DC = DONGCUA.Rows[i].Cells["DOT17_DC"].Value + "";
                    string DOT18_DC = DONGCUA.Rows[i].Cells["DOT18_DC"].Value + "";
                    string DOT19_DC = DONGCUA.Rows[i].Cells["DOT19_DC"].Value + "";
                    string DOT20_DC = DONGCUA.Rows[i].Cells["DOT20_DC"].Value + "";

                    try { chamcong.DOT01_DC = int.Parse(DOT01_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT02_DC = int.Parse(DOT02_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT03_DC = int.Parse(DOT03_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT04_DC = int.Parse(DOT04_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT05_DC = int.Parse(DOT05_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT06_DC = int.Parse(DOT06_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT07_DC = int.Parse(DOT07_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT08_DC = int.Parse(DOT08_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT09_DC = int.Parse(DOT09_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT10_DC = int.Parse(DOT10_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT11_DC = int.Parse(DOT11_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT12_DC = int.Parse(DOT12_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT13_DC = int.Parse(DOT13_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT14_DC = int.Parse(DOT14_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT15_DC = int.Parse(DOT15_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT16_DC = int.Parse(DOT16_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT17_DC = int.Parse(DOT17_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT18_DC = int.Parse(DOT18_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT19_DC = int.Parse(DOT19_DC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT20_DC = int.Parse(DOT20_DC.Replace(" ", "")); }
                    catch (Exception) { }
                    
                   

                }
            }

        }
        // DAL.QLDHN.C_QuanLyDongHoNuoc.ExecuteUpdatetods(tods,"",""); 
        public void TANGCUONG()
        {
            if (chamcong != null)
            {
                int tods = int.Parse(this.cbNhanVien.SelectedValue + "");
                for (int i = 0; i < TANGCUONG_.Rows.Count; i++)
                {
                    string DOT01_TC = TANGCUONG_.Rows[i].Cells["DOT01_TC"].Value + "";
                    string DOT02_TC = TANGCUONG_.Rows[i].Cells["DOT02_TC"].Value + "";
                    string DOT03_TC = TANGCUONG_.Rows[i].Cells["DOT03_TC"].Value + "";
                    string DOT04_TC = TANGCUONG_.Rows[i].Cells["DOT04_TC"].Value + "";
                    string DOT05_TC = TANGCUONG_.Rows[i].Cells["DOT05_TC"].Value + "";
                    string DOT06_TC = TANGCUONG_.Rows[i].Cells["DOT06_TC"].Value + "";
                    string DOT07_TC = TANGCUONG_.Rows[i].Cells["DOT07_TC"].Value + "";
                    string DOT08_TC = TANGCUONG_.Rows[i].Cells["DOT08_TC"].Value + "";
                    string DOT09_TC = TANGCUONG_.Rows[i].Cells["DOT09_TC"].Value + "";
                    string DOT10_TC = TANGCUONG_.Rows[i].Cells["DOT10_TC"].Value + "";
                    string DOT11_TC = TANGCUONG_.Rows[i].Cells["DOT11_TC"].Value + "";
                    string DOT12_TC = TANGCUONG_.Rows[i].Cells["DOT12_TC"].Value + "";
                    string DOT13_TC = TANGCUONG_.Rows[i].Cells["DOT13_TC"].Value + "";
                    string DOT14_TC = TANGCUONG_.Rows[i].Cells["DOT14_TC"].Value + "";
                    string DOT15_TC = TANGCUONG_.Rows[i].Cells["DOT15_TC"].Value + "";
                    string DOT16_TC = TANGCUONG_.Rows[i].Cells["DOT16_TC"].Value + "";
                    string DOT17_TC = TANGCUONG_.Rows[i].Cells["DOT17_TC"].Value + "";
                    string DOT18_TC = TANGCUONG_.Rows[i].Cells["DOT18_TC"].Value + "";
                    string DOT19_TC = TANGCUONG_.Rows[i].Cells["DOT19_TC"].Value + "";
                    string DOT20_TC = TANGCUONG_.Rows[i].Cells["DOT20_TC"].Value + "";

                    try {  chamcong.DOT01_TC = int.Parse(DOT01_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT02_TC = int.Parse(DOT02_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT03_TC = int.Parse(DOT03_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT04_TC = int.Parse(DOT04_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT05_TC = int.Parse(DOT05_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT06_TC = int.Parse(DOT06_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT07_TC = int.Parse(DOT07_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT08_TC = int.Parse(DOT08_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT09_TC = int.Parse(DOT09_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT10_TC = int.Parse(DOT10_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT10_TC = int.Parse(DOT10_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT11_TC = int.Parse(DOT11_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT12_TC = int.Parse(DOT12_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT13_TC = int.Parse(DOT13_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT14_TC = int.Parse(DOT14_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT15_TC = int.Parse(DOT15_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT16_TC = int.Parse(DOT16_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT17_TC = int.Parse(DOT17_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT18_TC = int.Parse(DOT18_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT19_TC = int.Parse(DOT19_TC.Replace(" ", "")); }
                    catch (Exception) { }

                    try { chamcong.DOT20_TC = int.Parse(DOT20_TC.Replace(" ", "")); }
                    catch (Exception) { }
                    

                }
            }

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DONGHONUOC();
                DONGCUA_();
                TANGCUONG();
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
                DHN.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_DHN(int.Parse(this.cbNhanVien.SelectedValue + ""));
                TANGCUONG_.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_TANGCUONG(int.Parse(this.cbNhanVien.SelectedValue + ""));
                DONGCUA.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongNVDS_DONGCUA(int.Parse(this.cbNhanVien.SelectedValue + ""));
                chamcong = DAL.QLDHN.C_QuanLyDongHoNuoc.getChamCongBy(int.Parse(this.cbNhanVien.SelectedValue + ""));
            }
            catch (Exception)
            {

            }
        }
    }
}
