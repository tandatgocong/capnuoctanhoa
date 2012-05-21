using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_DieuChinhThongTin : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DieuChinhThongTin).Name);
        public frm_DieuChinhThongTin()
        {
            InitializeComponent();

            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            HIEUDH.AutoCompleteMode = AutoCompleteMode.Suggest;
            HIEUDH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            HIEUDH.AutoCompleteCustomSource = namesCollection;

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
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
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    HIEUDH.Text = khachhang.HIEUDH;
                    CO.Text = khachhang.CODH;
                    CAP.Text = khachhang.CAP;
                    SOTHAN.Text = khachhang.SOTHANDH;
                    VITRI.Text = khachhang.VITRIDHN;
                    CHITHAN.Text = khachhang.CHITHAN;
                    CHIGOC.Text = khachhang.CHIGOC;
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Refesh() {
            LOTRINH.Text ="";
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
            HIEUDH.Text =  "";
            CO.Text =  "";
            CAP.Text =  "";
            SOTHAN.Text  = "";
            VITRI.Text = "";
            CHITHAN.Text = "";
            CHIGOC.Text = "";
            txtDanhBo.Text = "";
            txtDanhBo.Focus();
        
        }
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (khachhang != null)
            {
                khachhang.HOTEN = HOTEN.Text.ToUpper();
                khachhang.SONHA = SONHA.Text.ToUpper();
                khachhang.TENDUONG = TENDUONG.Text.ToUpper();
                if (!"".Equals(this.NGAYGAN.ValueObject + ""))
                {
                    khachhang.NGAYTHAY = this.NGAYGAN.Value;
                }
                if (!"".Equals(this.KIEMDINH.ValueObject + ""))
                {
                    khachhang.NGAYKIEMDINH = this.KIEMDINH.Value;
                }
                khachhang.HIEUDH = HIEUDH.Text.ToUpper();
                khachhang.CODH = CO.Text;
                khachhang.CAP = CAP.Text;
                khachhang.SOTHANDH = SOTHAN.Text;
                khachhang.VITRIDHN = VITRI.Text;
                khachhang.CHITHAN = CHITHAN.Text;
                khachhang.CHIGOC = CHIGOC.Text;
                khachhang.MODIFYBY = DAL.SYS.C_USERS._userName;
                khachhang.MODIFYDATE = DateTime.Now;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.Update())
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refesh();
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.txtNam.Text = DateTime.Now.Year.ToString();
            this.rNam.Text = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 12)
            {
                cbKyDS.SelectedIndex = 0;
                rHieuLuc.SelectedIndex = 0;
            }
            else
            {
                cbKyDS.SelectedIndex = DateTime.Now.Month;
                rHieuLuc.SelectedIndex = DateTime.Now.Month;
            }

        }

        /// <summary>
        /// Hủy Danh Bộ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        TB_DULIEUKHACHHANG huyDanhBo = null;
        void LoadThongTinHuy()
        {
            string sodanhbo = this.huy_danhbo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                huyDanhBo = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (huyDanhBo != null)
                {
                    H_LOTRINH.Text = huyDanhBo.LOTRINH;
                    H_DOT.Text = huyDanhBo.DOT;
                    H_HOPDONG.Text = huyDanhBo.HOPDONG;
                    H_HOTEN.Text = huyDanhBo.HOTEN;
                    H_SONHA.Text = huyDanhBo.SONHA;
                    H_TENDUONG.Text = huyDanhBo.TENDUONG;
                    try
                    {
                        LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(huyDanhBo.QUAN));
                        if (q != null)
                        {
                            H_QUAN.Text = q.TENQUAN;
                            LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, huyDanhBo.PHUONG.Trim());
                            H_PHUONG.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    H_GIABIEU.Text = huyDanhBo.GIABIEU;
                    H_DINHMUC.Text = huyDanhBo.DINHMUC;
                    H_SOPHIEU.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void huy_danhbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinHuy();
            }
        }

        private void btHuyDanhBo_Click(object sender, EventArgs e)
        {
            if (huyDanhBo != null)
            {
                TB_DULIEUKHACHHANG_HUYDB hKhacHang = new TB_DULIEUKHACHHANG_HUYDB();
                hKhacHang.KHU = huyDanhBo.KHU;
                hKhacHang.DOT = huyDanhBo.DOT;
                hKhacHang.CUON_GCS = huyDanhBo.CUON_GCS;
                hKhacHang.CUON_STT = huyDanhBo.CUON_STT;
                hKhacHang.DANHBO = huyDanhBo.DANHBO;
                hKhacHang.LOTRINH = huyDanhBo.LOTRINH;
                hKhacHang.NGAYGANDH = huyDanhBo.NGAYGANDH;
                hKhacHang.HOPDONG = huyDanhBo.HOPDONG;
                hKhacHang.HOTEN = huyDanhBo.HOTEN;
                hKhacHang.SONHA = huyDanhBo.SONHA;
                hKhacHang.TENDUONG = huyDanhBo.TENDUONG;
                hKhacHang.PHUONG = huyDanhBo.PHUONG;
                hKhacHang.QUAN = huyDanhBo.QUAN;
                hKhacHang.CHUKY = huyDanhBo.CHUKY;
                hKhacHang.CODE = huyDanhBo.CODE;
                hKhacHang.CODEFU = huyDanhBo.CODEFU;
                hKhacHang.GIABIEU = huyDanhBo.GIABIEU;
                hKhacHang.DINHMUC = huyDanhBo.DINHMUC;
                hKhacHang.SH = huyDanhBo.SH;
                hKhacHang.HCSN = huyDanhBo.HCSN;
                hKhacHang.SX = huyDanhBo.SX;
                hKhacHang.DV = huyDanhBo.DV;
                hKhacHang.CODH = huyDanhBo.CODH;
                hKhacHang.HIEUDH = huyDanhBo.HIEUDH;
                hKhacHang.CAP = huyDanhBo.CAP;
                hKhacHang.SOTHANDH = huyDanhBo.SOTHANDH;
                hKhacHang.CHITHAN = huyDanhBo.CHITHAN;
                hKhacHang.CHIGOC = huyDanhBo.CHIGOC;
                hKhacHang.VITRIDHN = huyDanhBo.VITRIDHN;
                hKhacHang.NGAYTHAY = huyDanhBo.NGAYTHAY;
                hKhacHang.NGAYKIEMDINH = huyDanhBo.NGAYKIEMDINH;
                hKhacHang.SODHN = huyDanhBo.SODHN;
                hKhacHang.MSTHUE = huyDanhBo.MSTHUE;
                hKhacHang.SOHO = huyDanhBo.SOHO;
                hKhacHang.CHISOKYTRUOC = huyDanhBo.CHISOKYTRUOC;
                hKhacHang.SOPHIEU = this.H_SOPHIEU.Text;
                hKhacHang.NGAYHUY = DateTime.Now.Date;
                hKhacHang.HIEULUCHUY = cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + this.txtNam.Text;
                hKhacHang.NGUYENNHAN = this.NGUYENNHAN.Text;
                hKhacHang.GHICHU = this.GHICHU.Text; ;
                hKhacHang.CREATEDATE = DateTime.Now;
                hKhacHang.CREATEBY = DAL.SYS.C_USERS._userName;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.HuyDanhBo(hKhacHang, huyDanhBo))
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.huy_danhbo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btXemHuyDanhBo_Click(object sender, EventArgs e)
        {
            string hieuluc = rHieuLuc.Items[rHieuLuc.SelectedIndex].ToString() + "/" + this.rNam.Text;
            DataTable table = new DataTable();
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("TODS", typeof(string));
            table.Columns.Add("TENTO", typeof(string));
            table.Columns.Add("SOLUONG",typeof(string));

            DataRow myDataRow = table.NewRow();
            myDataRow["STT"] = 1;
            myDataRow["TODS"] = "TB01";
            myDataRow["TENTO"] = "TÂN BÌNH 01";
            int tb01 = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("TB01", hieuluc);
            myDataRow["SOLUONG"] = tb01;
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = 2;
            myDataRow["TODS"] = "TB02";
            myDataRow["TENTO"] = "TÂN BÌNH 02";
            int tb02 = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("TB02", hieuluc);
            myDataRow["SOLUONG"] = tb02;
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = 3;
            myDataRow["TODS"] = "TP";
            myDataRow["TENTO"] = "TÂN PHÚ";
            int tp = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("TP", hieuluc);
            myDataRow["SOLUONG"] = tp;
            table.Rows.Add(myDataRow);


            // tong ket

            myDataRow = table.NewRow();
            myDataRow["STT"] = "";
            myDataRow["TODS"] = "";
            myDataRow["TENTO"] = "";
            myDataRow["SOLUONG"] = tb01+tb02+tp;
            table.Rows.Add(myDataRow);
            dataGridView1.DataSource = table;





            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "DANHSACH")
            {
                string hieuluc = rHieuLuc.Items[rHieuLuc.SelectedIndex].ToString() + "/" + this.rNam.Text;

                string tods = dataGridView1.Rows[e.RowIndex].Cells["TODS"].Value + "";
                string tento = "".Equals((dataGridView1.Rows[e.RowIndex].Cells["TENTO"].Value + "")) ? "" : "TỔ " + (dataGridView1.Rows[e.RowIndex].Cells["TENTO"].Value + "");

                ReportDocument rp = new rpt_HuyDanhBo();
                rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.DanhSachHuyDB(tods, hieuluc));
                rp.SetParameterValue("title", "DANH SÁCH KHÁCH HÀNG HỦY DANH BỘ KỲ " + hieuluc + " " + tento);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

       

        /// <summary>
        /// Đì
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tabItem6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(new tab_DieuChinhDS());
        }

        private void huy_danhbo_Leave(object sender, EventArgs e)
        {
            LoadThongTinHuy();
        }

        private void tabDieuChinh_Click(object sender, EventArgs e)
        {
            panelDieuChinh.Controls.Clear();
            panelDieuChinh.Controls.Add(new frm_DieuChinh());
            
        }
    }
}