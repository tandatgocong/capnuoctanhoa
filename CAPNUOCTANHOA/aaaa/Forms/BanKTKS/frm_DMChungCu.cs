using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using log4net;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_DMChungCu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DMChungCu).Name);
        public frm_DMChungCu()
        {
            InitializeComponent();
            FormLoad();

        }
        void FormLoad()
        {
            try
            {
                
                string recordKT = ConfigurationManager.AppSettings["locc"].ToString();
                string[] words = Regex.Split(recordKT, ",");
                for (int i = 0; i < words.Length; i++)
                {
                    cbLoCC.Items.Add(words[i]);
                }
                this.cbLoCC.SelectedIndex = 0;
                //
                cbLoaiChungTu.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_LOAICHUNGTU ");
                cbLoaiChungTu.DisplayMember = "TENCT";
                cbLoaiChungTu.ValueMember = "MACT";

                cbDonViChuyen.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_DONVICAPNUOC ");
                cbDonViChuyen.DisplayMember = "NAME";
                cbDonViChuyen.ValueMember = "MACN";

                this.txtHSDinhMuc.Text = ConfigurationManager.AppSettings["hsDinhmuc"].ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }


        private void cbLoaiChungTu_SelectedValueChanged(object sender, EventArgs e)
        {
            if ("HKH".Equals(this.cbLoaiChungTu.SelectedValue.ToString()))
            {
                lbNgayDK.Visible = false;
                ngayDK.Visible = false;
            }
            else
            {
                lbNgayDK.Visible = true;
                ngayDK.Visible = true;
            }
        }

        public void Refesh()
        {
            LOTRINH.Text = "";
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            GIABIEU.Text = "";
            DINHMUC.Text = "";
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
                    SONHA.Text = khachhang.SONHA + " " + khachhang.TENDUONG;
                    txtDot.Text = khachhang.LOTRINH.Substring(0, 2);
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    txtDMCu.Text = khachhang.DINHMUC;
                    LoadThongTin();
                    tongsonk();
                }
                else
                {

                    MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refesh();
                }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }

        private void checkChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChuyen.Checked)
            {
                cbDonViChuyen.Visible = true;
                txtDiaChiChuyen.Visible = true;
            }
            else
            {
                cbDonViChuyen.Visible = false;
                txtDiaChiChuyen.Visible = false;
            }
        }
        public void LoadThongTin() {

            dataGridViewThongTinDM.DataSource = DAL.LinQConnection.getDataTable("SELECT ID,SOPHONG, SOCHUNGTU, HOTEN, SONK, GHICHU FROM KTKS_THONGTINDINHMUC_TMP WHERE DANHBO = '" + this.txtDanhBo.Text.Replace("-", "") + "' AND LOCC='"+this.cbLoCC.Text+"' AND CAPDINHMUC='false' ORDER BY SOPHONG ASC ");
        }
        public void tongsonk() {
            try
            {
                int result = 0;
                for (int i = 0; i < dataGridViewThongTinDM.Rows.Count; i++) {
                    try
                    {
                        result += chuyenso(dataGridViewThongTinDM.Rows[i].Cells["SONK"].Value + "");
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);   
                    }
                }
                this.txtTongNhanKhau.Text = result + "";
                int yeucauthemdm = result * chuyenso(this.txtHSDinhMuc.Text.Replace(" ", ""));
                this.txtDMThem.Text = yeucauthemdm + "";
                this.txtDMMoi.Text = (chuyenso(txtDMThem.Text) + chuyenso(txtDMCu.Text)) + "";

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);    
            }

        }
        public int chuyenso(string kq) {

            try
            {
                return int.Parse(kq);
            }
            catch (Exception)
            {
            }
            return 0;
        }
        private void btNhapDM_Click(object sender, EventArgs e)
        {
            try
            {
                KTKS_THONGTINDINHMUC_TMP ttdm = new KTKS_THONGTINDINHMUC_TMP();
                ttdm.DANHBO = this.txtDanhBo.Text.Replace("-", "");
                ttdm.LOAICT = this.cbLoaiChungTu.SelectedValue.ToString();
                ttdm.SOCHUNGTU = this.txtSoCT.Text;
                if (!"HKH".Equals(this.cbLoaiChungTu.SelectedValue.ToString()))
                {
                    ttdm.NGAYHETHAN = this.ngayDK.Value.Date;
                }
                ttdm.HOTEN = this.txtKhCapDM.Text.ToUpper();
                ttdm.SOPHONG = this.txtSoPhong.Text.Replace(" ", "");
                ttdm.LOCC = cbLoCC.Text;
                int snk = 0;
                int.TryParse(this.txtSoNhanKhau.Text, out snk);
                ttdm.SONK = snk;
                ttdm.GHICHU = this.txtGhiChu.Text;
                if (this.checkChuyen.Checked)
                {
                    ttdm.CHUYEN = true;
                    ttdm.DONVICN = this.cbDonViChuyen.SelectedValue + "";
                    ttdm.DIACHI = this.txtDiaChiChuyen.Text;
                }
                ttdm.CAPDINHMUC = false;
                ttdm.CREATEDATE = DateTime.Now;
                ttdm.CREATEBY = DAL.SYS.C_USERS._userName;
                DAL.BANKTKS.C_BANKTKS.InsertThongTinDM_TMP(ttdm);
                LoadThongTin();
                tongsonk();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(this, "Thêm Định Mức Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLoCC_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadThongTin();
                tongsonk();
            }
            catch (Exception)
            {
                
            }
        }
    }
}