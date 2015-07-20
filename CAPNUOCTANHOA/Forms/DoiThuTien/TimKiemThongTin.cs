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
        TB_DULIEUKHACHHANG_HUYDB khachhanghuy = null;
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
                    txtHieuLuc.Text = String.Format("{0:00}", khachhang.KY) + "/" + khachhang.NAM;
                   

                    btCapNhatThongTin.Enabled = true;


                    loadghichu(khachhang.DANHBO);
                    txtGhiChu.Text = "";
                }
                else
                {
                    khachhanghuy = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        LOTRINH.Text = khachhanghuy.LOTRINH;
                        DOT.Text = khachhanghuy.DOT;
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
                        txtHieuLuc.Text = "Hết HL " + khachhanghuy.HIEULUCHUY;
                        //btCapNhatThongTin.Enabled = false;

                        loadghichu(khachhanghuy.DANHBO);
                    }
                    else
                    {

                        MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Refesh();
                    }
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
                    if ("".Equals(txtGhiChu.Text.Replace(" ", "")) == false)
                    {
                        TB_GHICHU_TT ghichu = new TB_GHICHU_TT();
                        ghichu.DANHBO = khachhang.DANHBO;
                        ghichu.NOIDUNG = txtGhiChu.Text;
                        ghichu.DONVI = DAL.SYS.C_USERS._maphong;
                        ghichu.CREATEDATE = DateTime.Now.Date;
                        ghichu.CREATEBY = DAL.SYS.C_USERS._userName;
                        DAL.DULIEUKH.C_DuLieuKhachHang.InsertGHICHU_TT(ghichu);
                        loadghichu(khachhang.DANHBO);
                      

                    }

                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDanhBo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (khachhanghuy != null)
            {
                
                    if ("".Equals(txtGhiChu.Text.Replace(" ", "")) == false)
                    {
                        TB_GHICHU_TT ghichu = new TB_GHICHU_TT();
                        ghichu.DANHBO = khachhanghuy.DANHBO;
                        ghichu.NOIDUNG = txtGhiChu.Text;
                        ghichu.DONVI = DAL.SYS.C_USERS._maphong;
                        ghichu.CREATEDATE = DateTime.Now.Date;
                        ghichu.CREATEBY = DAL.SYS.C_USERS._userName;
                        DAL.DULIEUKH.C_DuLieuKhachHang.InsertGHICHU_TT(ghichu);
                        loadghichu(khachhanghuy.DANHBO);


                    }

                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDanhBo.Focus();
              
            }
        }

        private void lichsuGhiCHu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lichsuGhiCHu, new Point(e.X, e.Y));
            }
        }
        public void loadghichu(string danhbo)
        {
            lichsuGhiCHu.DataSource = DAL.DULIEUKH.C_DuLieuKhachHang.lisGhiChu_TT(danhbo);
            for (int i = 0; i < lichsuGhiCHu.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        private void menuCapNhatKetQua_Click(object sender, EventArgs e)
        {
            string ID_ = this.lichsuGhiCHu.Rows[lichsuGhiCHu.CurrentRow.Index].Cells["ID"].Value + "";
            DAL.LinQConnection.ExecuteCommand_("DELETE FROM TB_GHICHU_TT WHERE ID='" + ID_ + "' AND DONVI='" + DAL.SYS.C_USERS._maphong + "'");
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            loadghichu(sodanhbo);
        }
    }
}