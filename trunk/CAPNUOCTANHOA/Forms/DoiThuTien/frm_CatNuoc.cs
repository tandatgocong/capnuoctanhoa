using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.DoiTCTB.Tab;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    public partial class frm_CatNuoc : UserControl
    {
        public frm_CatNuoc()
        {
            InitializeComponent();
            title.Text = "CẬP NHẬT THÔNG TIN ĐÓNG NƯỚC NĂM " + DateTime.Now.Year.ToString();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }
        public void Refesh()
        {
            LOTRINH.Text = "";
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            TENDUONG.Text = "";
            QUAN.Text = "";
            PHUONGT.Text = "";
            txtDanhBo.Focus();

        }

        TB_DULIEUKHACHHANG khachhang = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    LOTRINH.Text = khachhang.LOTRINH;
                    HOPDONG.Text = khachhang.HOPDONG;
                    HOTEN.Text = khachhang.HOTEN;
                    SONHA.Text = khachhang.SONHA;
                    TENDUONG.Text = khachhang.TENDUONG;
                    try
                    {
                        LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(khachhang.QUAN));
                        if (q != null)
                        {
                            QUAN.Text = q.TENQUAN;
                            LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, khachhang.PHUONG.Trim());
                            PHUONGT.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    txtGhiChu.Text = "";
                }
                else
                {
                    TB_DULIEUKHACHHANG_HUYDB khachhanghuy = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        LOTRINH.Text = khachhanghuy.LOTRINH;
                        HOPDONG.Text = khachhanghuy.HOPDONG;
                        HOTEN.Text = khachhanghuy.HOTEN;
                        SONHA.Text = khachhanghuy.SONHA;
                        TENDUONG.Text = khachhanghuy.TENDUONG;
                        try
                        {
                            LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(khachhanghuy.QUAN));
                            if (q != null)
                            {
                                QUAN.Text = q.TENQUAN;
                                LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, khachhanghuy.PHUONG.Trim());
                                PHUONGT.Text = ph.TENPHUONG;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        NGAYDONG.ValueObject = khachhanghuy.NGAYTHAY;
                        NGAYMO.ValueObject = khachhanghuy.NGAYKIEMDINH;
                    }
                    else
                    {

                        MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Refesh();
                    }
                }
            }
        }
    }
}