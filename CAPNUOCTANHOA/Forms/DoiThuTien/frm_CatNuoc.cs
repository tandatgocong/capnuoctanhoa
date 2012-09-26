﻿using System;
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
    public partial class frm_CatNuoc : UserControl
    {
        public frm_CatNuoc()
        {
            InitializeComponent();
            title.Text = "CẬP NHẬT THÔNG TIN ĐÓNG NƯỚC NĂM " + DateTime.Now.Year.ToString();
            groupPanel1.Text = "DANH SÁCH ĐÓNG NƯỚC THÁNG " + DateTime.Now.Month.ToString();
            NGAYDONG.Value = DateTime.Now.Date;
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
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            TENDUONG.Text = "";
            QUAN.Text = "";
            PHUONGT.Text = "";
            this.NGAYDONG.Value = DateTime.Now.Date;
            this.txtGhiChu.Text = "";
            txtDanhBo.Focus();
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;

        }

        TB_DULIEUKHACHHANG khachhang = null;
        TB_DONGNUOC dongnuoc = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                dongnuoc = DAL.THUTIEN.C_ThuTien.finByDanhBo(sodanhbo);
                if (dongnuoc != null)
                {
                    HOPDONG.Text = dongnuoc.HOPDONG;
                    HOTEN.Text = dongnuoc.HOTEN;
                    SONHA.Text = dongnuoc.SONHA;
                    TENDUONG.Text = dongnuoc.TENDUONG;
                    try
                    {
                        LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(dongnuoc.QUAN));
                        if (q != null)
                        {
                            QUAN.Text = q.TENQUAN;
                            LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, dongnuoc.PHUONG.Trim());
                            PHUONGT.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    NGAYDONG.ValueObject = dongnuoc.NGAYDONGNUOC;
                    NGAYMO.ValueObject = dongnuoc.NGAYMONUOC;
                    txtGhiChu.Text = dongnuoc.NOIDUNG;

                    btcapNhat.Enabled = true;
                    btXoa.Enabled = true;
                }
                else
                {
                    khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                    if (khachhang != null)
                    {
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
                        txtGhiChu.Text = DAL.THUTIEN.C_ThuTien.noidung(khachhang.DANHBO);
                    }

                }
            }
        }

        private void frm_CatNuoc_Load(object sender, EventArgs e)
        {
            dataBangKe.DataSource = C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString());
            Utilities.DataGridV.formatRows(dataBangKe);
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            Refesh();
            Utilities.DataGridV.formatRows(dataBangKe);
        }

        #region MyRegion

        #endregion

        private void btThem_Click(object sender, EventArgs e)
        {
            TB_DONGNUOC dn = new TB_DONGNUOC();
            dn.DANHBO = this.txtDanhBo.Text.Replace("-", "");
            dn.HOPDONG = this.HOPDONG.Text;
            dn.HOTEN = this.HOTEN.Text;
            dn.SONHA = this.SONHA.Text;
            dn.TENDUONG = this.TENDUONG.Text;
            dn.PHUONG = this.PHUONGT.Text;
            dn.QUAN = QUAN.Text;

            if (!"".Equals(this.NGAYDONG.ValueObject + ""))
            {
                dn.NGAYDONGNUOC = NGAYDONG.Value.Date;
            }
            if (!"".Equals(this.NGAYMO.ValueObject + ""))
            {
                dn.NGAYMONUOC = NGAYMO.Value.Date;
            }
            dn.NOIDUNG = this.txtGhiChu.Text;
            dn.CREATEDATE = DateTime.Now.Date;
            dn.CREATEBY = DAL.SYS.C_USERS._userName;

            if (DAL.THUTIEN.C_ThuTien.Insert(dn))
            {
                MessageBox.Show(this, "Cập Nhật Đóng Nước Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataBangKe.DataSource = C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString());
                Utilities.DataGridV.formatRows(dataBangKe);
                Refesh();
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Đóng Nước Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btcapNhat.Enabled = true;
            btXoa.Enabled = true;
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string ID_ = dataBangKe.Rows[e.RowIndex].Cells["G_ID"].Value + "";
            //    string DANHBO_ = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
            //    string HOPDONG_ = dataBangKe.Rows[e.RowIndex].Cells["G_HOPDONG"].Value + "";
            //    string HOTEN_ = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
            //    string SONHA_ = dataBangKe.Rows[e.RowIndex].Cells["G_SONHA"].Value + "";
            //    string TENDUONG_ = dataBangKe.Rows[e.RowIndex].Cells["G_TENDUONG"].Value + "";
            //    string PHUONG_ = dataBangKe.Rows[e.RowIndex].Cells["G_PHUONG"].Value + "";
            //    string QUAN_ = dataBangKe.Rows[e.RowIndex].Cells["G_QUAN"].Value + "";
            //    object NGAYDONGNUOC_ = dataBangKe.Rows[e.RowIndex].Cells["G_NGAYDONG"].Value;
            //    object NGAYMONUOC_ = dataBangKe.Rows[e.RowIndex].Cells["G_NGAYMO"].Value;
            //    string NOIDUNG_ = dataBangKe.Rows[e.RowIndex].Cells["G_NOIDUNG"].Value + "";

            //    txtid.Text = ID_;
            //    txtDanhBo.Text = DANHBO_.Replace(" ","");
            //    HOPDONG.Text = DANHBO_;
            //    HOTEN.Text = HOTEN_;
            //    SONHA.Text = SONHA_;
            //    TENDUONG.Text = TENDUONG_;
            //    QUAN.Text = QUAN_;
            //    PHUONGT.Text = PHUONG_;
            //    NGAYDONG.ValueObject = NGAYDONGNUOC_;
            //    NGAYMO.ValueObject = NGAYMONUOC_;
            //    txtGhiChu.Text = NOIDUNG_;

            //    btcapNhat.Enabled = true;
            //    btXoa.Enabled = true;
            //}
            //catch (Exception)
            //{

            //}
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dongnuoc != null)
            {
                string mess = "Xóa Thông Tin Đóng Nước Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(dongnuoc.DANHBO, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.THUTIEN.C_ThuTien.delete(dongnuoc);
                    dataBangKe.DataSource = C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString());
                    Utilities.DataGridV.formatRows(dataBangKe);
                    Refesh();
                    this.txtDanhBo.Text = "";
                }

            }

        }

        private void btcapNhat_Click(object sender, EventArgs e)
        {
            if (dongnuoc != null)
            {
                dongnuoc.HOPDONG = this.HOPDONG.Text;
                dongnuoc.HOTEN = this.HOTEN.Text;
                dongnuoc.SONHA = this.SONHA.Text;
                dongnuoc.TENDUONG = this.TENDUONG.Text;
                dongnuoc.PHUONG = this.PHUONGT.Text;
                dongnuoc.QUAN = QUAN.Text;

                if (!"".Equals(this.NGAYDONG.ValueObject + ""))
                {
                    dongnuoc.NGAYDONGNUOC = NGAYDONG.Value.Date;
                }
                if (!"".Equals(this.NGAYMO.ValueObject + ""))
                {
                    dongnuoc.NGAYMONUOC = NGAYMO.Value.Date;
                }
                dongnuoc.NOIDUNG = this.txtGhiChu.Text;
                dongnuoc.MODIFYDATE = DateTime.Now.Date;
                dongnuoc.MODIFYBY = DAL.SYS.C_USERS._userName;

                if (DAL.THUTIEN.C_ThuTien.Update())
                {
                    MessageBox.Show(this, "Cập Nhật Đóng & Mở Nước Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBangKe.DataSource = C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString());
                    Utilities.DataGridV.formatRows(dataBangKe);
                    Refesh(); 
                    btcapNhat.Enabled = true;
                    btXoa.Enabled = true;
                    this.txtDanhBo.Text = "";
                    this.NGAYMO.ValueObject = null;
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Đóng & Mở Nước Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new crpt_ThongTinDongNuoc();
            rp.SetDataSource(DAL.THUTIEN.C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString()));
            rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC THÁNG " + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }
}