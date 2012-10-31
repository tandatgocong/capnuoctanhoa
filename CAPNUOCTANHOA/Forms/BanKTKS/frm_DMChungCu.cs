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
        int hsDinhmuc = 0;
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
                //
                cbLoaiChungTu.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_LOAICHUNGTU ");
                cbLoaiChungTu.DisplayMember = "TENCT";
                cbLoaiChungTu.ValueMember = "MACT";
               // hsDinhmuc =int.Parse();
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
            else {
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
                    txtDienThoai.Text = khachhang.DIENTHOAI;
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
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
            if (e.KeyChar == 13) {
                LoadThongTinDB();
            }
        }
    }
}
