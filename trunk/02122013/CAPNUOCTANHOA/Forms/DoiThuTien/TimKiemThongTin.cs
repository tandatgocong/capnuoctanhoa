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
using CAPNUOCTANHOA.DAL.THUTIEN;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiThuTien.BC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    public partial class TimKiemThongTin : UserControl
    {
        public TimKiemThongTin()
        {
            InitializeComponent();
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
            DOT.Text = "";
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
                    DOT.Text = khachhang.DOT;
                    HOPDONG.Text = khachhang.HOPDONG;
                    HOTEN.Text = khachhang.HOTEN;
                    SONHA.Text = khachhang.SONHA;
                    TENDUONG.Text = khachhang.TENDUONG;
                    txtDienThoai.Text = khachhang.DIENTHOAI;
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

                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   Refesh();
                }
            }
        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (khachhang != null)
            {
                khachhang.DIENTHOAI = txtDienThoai.Text;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.Update())
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDanhBo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}