using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_CapNhatGhiChu : Form
    {
        TB_GHICHU ghichu = null;
        public frm_CapNhatGhiChu(string id)
        {
            InitializeComponent();
            try
            {
                ghichu = DAL.DULIEUKH.C_DuLieuKhachHang.findGhiChuByID(int.Parse(id));
                if (ghichu != null)
                {

                    txtSoDanhBo.Text = ghichu.DANHBO;
                    txtGhiChu.Text = ghichu.NOIDUNG;

                }
            }
            catch (Exception)
            {


            }

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (ghichu != null)
            {
                if("".Equals(this.txtGhiChu.Text)==false){
                    ghichu.NOIDUNG = txtGhiChu.Text;
                    ghichu.DONVI=DAL.SYS.C_USERS._maphong; 
                    ghichu.MODIFYDATE= DateTime.Now;
                    ghichu.MODIFYBY = DAL.SYS.C_USERS._userName;
                    DAL.DULIEUKH.C_PhienLoTrinh.CapNhatGhiChu(this.txtSoDanhBo.Text.Replace("-", ""), txtGhiChu.Text);
                    DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                }
               
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}