using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.GNKDT
{
    public partial class frmDieuChinhDMA : Form
    {
        public frmDieuChinhDMA()
        {
            InitializeComponent();
            cbMaDMA.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM GNKDT_THONGTINDMA ORDER BY MADMA ASC ");
            cbMaDMA.ValueMember = "MADMA";
            cbMaDMA.DisplayMember = "MADMA";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
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
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    HIEUDH.Text = khachhang.HIEUDH;
                    CO.Text = khachhang.CODH;
                    CAP.Text = khachhang.CAP;
                    txtChiKyDocSo.Text = khachhang.CHUKYDS + "";
                    try
                    {
                        cbMaDMA.SelectedValue = khachhang.MADMA;
                    }
                    catch (Exception)
                    {

                    }

                    btCapNhatThongTin.Enabled = true;



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
                        GIABIEU.Text = khachhanghuy.GIABIEU;
                        DINHMUC.Text = khachhanghuy.DINHMUC;
                        NGAYGAN.ValueObject = khachhanghuy.NGAYTHAY;
                        KIEMDINH.ValueObject = khachhanghuy.NGAYKIEMDINH;
                        HIEUDH.Text = khachhanghuy.HIEUDH;
                        CO.Text = khachhanghuy.CODH;
                        CAP.Text = khachhanghuy.CAP;
                        txtChiKyDocSo.Text = khachhanghuy.CHUKYDS + "";
                        try
                        {
                            cbMaDMA.SelectedValue = khachhanghuy.MADMA;
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
            GIABIEU.Text = "";
            DINHMUC.Text = "";
            NGAYGAN.ValueObject = DateTime.Now.Date;
            KIEMDINH.ValueObject = DateTime.Now.Date;
            HIEUDH.Text = "";
            CO.Text = "";
            CAP.Text = "";


            txtDanhBo.Focus();

        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (khachhang != null)
                {
                    khachhang.MADMA = this.cbMaDMA.SelectedValue.ToString();
                    try
                    {
                        khachhang.CHUKYDS = int.Parse(this.txtChiKyDocSo.Text);
                    }
                    catch (Exception)
                    {
                    }
                    DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                }
                if (khachhanghuy != null)
                {
                    khachhanghuy.MADMA = this.cbMaDMA.SelectedValue.ToString();
                    try
                    {
                        khachhanghuy.CHUKYDS = int.Parse(this.txtChiKyDocSo.Text);
                    }
                    catch (Exception)
                    {
                    }
                    DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                }
                string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
                string sql = "UPDATE HOADON SET MaDMA='" + this.cbMaDMA.SelectedValue.ToString() + "' WHERE DANHBA='" + sodanhbo + "' AND  NAM=YEAR(GETDATE()) AND KY= (SELECT MAX(KY) FROM HOADON WHERE DANHBA='" + sodanhbo + "' ) ";
                DAL.LinQConnectionHD.ExecuteCommand(sql);


                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (khachhang != null)
                {
                    khachhang.MADMA = null;
                    khachhang.CHUKYDS = null;
                    DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                }
                if (khachhanghuy != null)
                {
                    khachhanghuy.MADMA =  null;
                   
                    khachhanghuy.CHUKYDS = null;
                   
                    DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                }
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
    }
}