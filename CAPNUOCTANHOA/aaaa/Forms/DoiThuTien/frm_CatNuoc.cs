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
using log4net;

namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    public partial class frm_CatNuoc : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_CatNuoc).Name);
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
            CSMO.Text = "";
            CSDONG.Text = "";
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
                    PHUONGT.Text = dongnuoc.PHUONG;
                    QUAN.Text = dongnuoc.QUAN;
                    NGAYDONG.ValueObject = dongnuoc.NGAYDONGNUOC;
                    NGAYMO.ValueObject = dongnuoc.NGAYMONUOC;
                    CSDONG.Text = dongnuoc.CSDONG.ToString(); 
                    CSMO.Text = dongnuoc.CSMO.ToString();
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

        public void InsertDongNuoc( TB_DULIEUKHACHHANG kh, DateTime NGAY, string csdong) {
            if (kh != null)
            {
                string insertGM = "INSERT INTO LENHDONGNUOC(DANHBA, HIEU, CO, SOTHAN,LOAI_LENH, NGAYTHUCHIEN, GHICHU, NGAYCAPNHAT, SOLENH, NAM, CSDONG_MO) ";
                insertGM += " VALUES ('" + kh.DANHBO + "','" + kh.HIEUDH + "','" + kh.CODH + "','" + kh.SOTHANDH + "','0','" + NGAY + "','DOI THU TIEN DONG NUOC',GETDATE(),'123','" + NGAY.Year.ToString() + "','" + csdong + "')";
                log.Info("+++++++++++ LENHDONGNUOC : " + kh.DANHBO + "");
                DAL.DULIEUKH.C_GanMoi.InsertDocSo_(insertGM);
            }
        }

        public void InsertMoNuoc(TB_DULIEUKHACHHANG kh, DateTime NGAY, string csmo)
        {
            if (kh != null)
            {
                string insertGM = "INSERT INTO LENHDONGNUOC(DANHBA, HIEU, CO, SOTHAN,LOAI_LENH, NGAYTHUCHIEN, GHICHU, NGAYCAPNHAT, SOLENH, NAM, CSDONG_MO) ";
                insertGM += " VALUES ('" + kh.DANHBO + "','" + kh.HIEUDH + "','" + kh.CODH + "','" + kh.SOTHANDH + "','2','" + NGAY + "','DOI THU TIEN MO NUOC NUOC',GETDATE(),'123','" + NGAY.Year.ToString() + "','" + csmo + "')";
                log.Info("+++++++++++ LENHDONGNUOC : " + kh.DANHBO + "");
                DAL.DULIEUKH.C_GanMoi.InsertDocSo_(insertGM);
            }
        }

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
            int csdong_;
            int csmo_;
            
            if (!"".Equals(this.NGAYDONG.ValueObject + ""))
            {
                dn.NGAYDONGNUOC = NGAYDONG.Value.Date;
                int.TryParse(this.CSDONG.Text, out csdong_);
                dn.CSDONG = csdong_;
                InsertDongNuoc(DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtDanhBo.Text.Replace("-", "")), NGAYDONG.Value.Date, csdong_.ToString());
            }
            if (!"".Equals(this.NGAYMO.ValueObject + ""))
            {
                dn.NGAYMONUOC = NGAYMO.Value.Date;
                int.TryParse(this.CSMO.Text, out csmo_);
                dn.CSMO = csmo_;
                InsertMoNuoc(DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtDanhBo.Text.Replace("-", "")), NGAYMO.Value.Date,csmo_.ToString());
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
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string s_thaotat = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["deltete"].Value + "";
                if (dataBangKe.CurrentCell.OwningColumn.Name == "deltete")
                {
                    string _shs = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["G_ID"].Value + "";
                    try
                    {
                        string sql = "DELETE FROM TB_DONGNUOC WHERE ID='"+_shs+"'";
                        MessageBox.Show(this, "" + _shs);
                        DAL.LinQConnection.ExecuteCommand_(sql);
                        dataBangKe.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
                        //dataBangKe.DataSource = C_ThuTien.getDongNuocByDate(DateTime.Now.Month.ToString());
                        //Utilities.DataGridV.formatRows(dataBangKe);

                    }
                    catch (Exception ex)
                    {
                        log.Error("Them Dot THi Cong Loi " + ex.Message);
                    }
                    
                }
            }
            catch (Exception)
            {

            }
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
                int csdong_;
                int csmo_;

                if (!"".Equals(this.NGAYDONG.ValueObject + ""))
                {
                    dongnuoc.NGAYDONGNUOC = NGAYDONG.Value.Date;
                    int.TryParse(this.CSDONG.Text, out csdong_);
                    dongnuoc.CSDONG = csdong_;
                    InsertDongNuoc(DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtDanhBo.Text.Replace("-", "")), NGAYDONG.Value.Date,csdong_.ToString());
                }
                if (!"".Equals(this.NGAYMO.ValueObject + ""))
                {
                    dongnuoc.NGAYMONUOC = NGAYMO.Value.Date;
                    int.TryParse(this.CSMO.Text, out csmo_);
                    dongnuoc.CSMO = csmo_;
                    InsertMoNuoc(DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtDanhBo.Text.Replace("-", "")), NGAYMO.Value.Date, csmo_.ToString());
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
            rp.SetDataSource(DAL.THUTIEN.C_ThuTien.ReportByDate(DateTime.Now.Month.ToString()));
            rp.SetParameterValue("title", "THÔNG TIN ĐÓNG NƯỚC THÁNG " + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }
}