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
    public partial class frm_CapNhatTroNgaiThay : Form
    {
        TB_THAYDHN thaydhn = null;
        public frm_CapNhatTroNgaiThay(string id)
        {
            InitializeComponent();
            try
            {
                thaydhn = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(id));
                if (thaydhn != null)
                {

                    txtSoDanhBo.Text = thaydhn.DHN_DANHBO;
                    TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(thaydhn.DHN_DANHBO);
                    if (kh != null)
                    {
                        txtDiaChi.Text = kh.SONHA + " " + kh.TENDUONG;
                        txtTenKH.Text = kh.HOTEN;
                    }

                    txtCo.Text = thaydhn.DHN_CODH;
                    txtLyDoThay.Text = thaydhn.DHN_LYDOTHAY;
                    txtHieuDHN.Text = thaydhn.DHN_HIEUDHN;
                    txtSoThan.Text = thaydhn.DHN_SOTHAN;
                    txtTroNgaiThay.Text = thaydhn.HCT_LYDOTRONGAI;
                    txtBoPhanChuyen.Text = thaydhn.XLT_CHUYENXL;
                }
            }
            catch (Exception)
            {


            }

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (thaydhn != null)
            {
                if("".Equals(this.txtKetQuaThucHien.Text)==false){
                    thaydhn.XLT_TRAKQ = true;
                    thaydhn.XLT_KETQUA = txtKetQuaThucHien.Text;
                    thaydhn.XLT_NGAYCAPNHAT = DateTime.Now.Date;
                    if (this.baothaylai.Checked == true) {
                        DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");
                    }                    
                    DAL.QLDHN.C_BaoThay.Update();
                }
               
            }
        }
    }
}