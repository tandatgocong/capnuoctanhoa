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

        public void Add()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            //ID, , , , , , , , , HIEU, CO, GHICHU, NGAYLAP, GANHOP, GH_GHICHU, CREATEDATE, CREATEBY, MODIFYDATE, MODIFYBY
            TB_DHNAMSAU chuyendm = DAL.QLDHN.C_DhnAmSau.findByDanhBo(sodanhbo);
            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
            if (chuyendm != null)
            {
                string mess = "Danh Bộ Đã Nâng ĐHN Ngày " + Utilities.DateToString.NgayVNVN(chuyendm.NGAYLAP.Value) + ", Có Muốn Tiếp Tục ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chuyendm = new TB_DHNAMSAU();
                    chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                    chuyendm.DANHBO = sodanhbo;
                    chuyendm.LOTRINH = kh.LOTRINH;
                    chuyendm.HOTEN = kh.HOTEN;
                    chuyendm.DIACHI = kh.SONHA + " " + kh.TENDUONG;
                    chuyendm.HOPDONG = kh.HOPDONG;
                    chuyendm.HIEU = kh.HIEUDH;
                    chuyendm.CO = kh.CODH;
                    chuyendm.GHICHU = this.txtKetQuaThucHien.Text;
                    chuyendm.NGAYLAP = DateTime.Now.Date;
                    chuyendm.CREATEDATE = DateTime.Now;
                    chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;

                    DAL.QLDHN.C_DhnAmSau.Insert(chuyendm);
                }
            }
            else
            {
                chuyendm = new TB_DHNAMSAU();
                chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                chuyendm.DANHBO = sodanhbo;
                chuyendm.LOTRINH = kh.LOTRINH;
                chuyendm.HOTEN = kh.HOTEN;
                chuyendm.DIACHI = kh.SONHA + " " + kh.TENDUONG;
                chuyendm.HOPDONG = kh.HOPDONG;
                chuyendm.HIEU = kh.HIEUDH;
                chuyendm.CO = kh.CODH;
                chuyendm.GHICHU = this.txtKetQuaThucHien.Text;
                chuyendm.NGAYLAP = DateTime.Now.Date;
                chuyendm.CREATEDATE = DateTime.Now;
                chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;

                DAL.QLDHN.C_DhnAmSau.Insert(chuyendm);
            }
            // DAL.DULIEUKH.C_DuLieuKhachHang.UpdateBaoThay(this.txtSoDanhBo.Text.Replace("-", ""), "True");
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (thaydhn != null)
            {
                thaydhn.XLT_XULY = true;
                if (txtBoPhanChuyen.Text.Equals("ĐỘI TCTB"))
                {
                    Add();
                    thaydhn.XLT_XULY = true;
                    thaydhn.XLT_CHUYENXL = "TCTB";
                    thaydhn.XLT_NGAYCHUYEN = DateTime.Now.Date;
                    if (this.baothaylai.Checked == true)
                    {
                        DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");
                    }
                    DAL.QLDHN.C_BaoThay.Update();
                }
                else
                {
                    if ("".Equals(this.txtKetQuaThucHien.Text) == false)
                    {
                        thaydhn.XLT_TRAKQ = true;
                        thaydhn.XLT_KETQUA = txtKetQuaThucHien.Text;
                        thaydhn.XLT_NGAYCAPNHAT = DateTime.Now.Date;
                        if (this.baothaylai.Checked == true)
                        {
                            DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");
                        }
                        DAL.QLDHN.C_BaoThay.Update();
                    }
                }
            }
        }
    }
}