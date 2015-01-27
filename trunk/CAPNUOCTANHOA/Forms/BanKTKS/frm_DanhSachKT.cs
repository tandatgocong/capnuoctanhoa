using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.BanKTKS.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh
{
    public partial class frm_DanhSachKT : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DanhSachKT).Name);
        public frm_DanhSachKT()
        {
            InitializeComponent();
            // this.cbLoaiBangKe.Focus(); 
            formLoad();
            //  MessageBox.Show(this, DAL.SYS.C_USERS._tenDocSo);
            //     MessageBox.Show(this, DAL.QLDHN.C_BaoThay.getMaxBangKe() + "");

        }

        void formLoad()
        {

            txtNgayGan.Value = DateTime.Now.Date;
            LoadData();
        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        private void btIn_Click(object sender, EventArgs e)
        {

            ReportDocument rp = new rpt_DSKiemTra();                         
                rp.SetDataSource(DAL.BANKTKS.C_DSKiemTra.getReport(this.txtNgayGan.Value.ToShortDateString()));
                rp.SetParameterValue("Title", this.txtTile.Text);
                rp.SetParameterValue("phong", DAL.SYS.C_USERS._maphong);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            
        }

       
        public void LoadData()
        {
            try
            {
                dataBangKe.DataSource = DAL.BANKTKS.C_DSKiemTra.getListDCByDate(this.txtNgayGan.Value.ToShortDateString());
                Utilities.DataGridV.formatRows(dataBangKe);
              //  setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }
        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadData();
                //btIn.Enabled = true;
            }
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = dataBangKe.Rows[e.RowIndex].Cells["ID"].Value + "";
                string G_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string LOTRINH = dataBangKe.Rows[e.RowIndex].Cells["LOTRINH"].Value + "";
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string GB = dataBangKe.Rows[e.RowIndex].Cells["GB"].Value + "";
                string DM = dataBangKe.Rows[e.RowIndex].Cells["DM"].Value + "";
                string G_HIEU = dataBangKe.Rows[e.RowIndex].Cells["G_HIEU"].Value + "";
                string gCODHN = dataBangKe.Rows[e.RowIndex].Cells["gCODHN"].Value + "";
                string G_SOTHAN = dataBangKe.Rows[e.RowIndex].Cells["G_SOTHAN"].Value + "";
                string GHICHU = dataBangKe.Rows[e.RowIndex].Cells["GHICHU"].Value + "";
                string GCHISO = dataBangKe.Rows[e.RowIndex].Cells["GCHISO"].Value + "";
                string HOPDONG = dataBangKe.Rows[e.RowIndex].Cells["HOPDONG"].Value + "";
                string CONGDUNG = dataBangKe.Rows[e.RowIndex].Cells["GHICHU"].Value + ""; 
                this.TXTid.Text = ID;
                this.txtLoTrinh.Text = LOTRINH;
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ", "");
                this.txtTenKH.Text = G_TENKH;
                this.txtDiaChi.Text = G_DIACHI;
                this.txtHopDong.Text = HOPDONG;
                this.txtGB.Text = GB;
                this.txtDM.Text = DM;
                this.txtCongDung.Text = GHICHU;
                this.txtHieuDhn.Text = G_HIEU;
                this.txtCo.Text = gCODHN;
                this.txtSoThan.Text = G_SOTHAN;
                this.txtCS.Text = GCHISO;
                this.txtCongDung.Text = CONGDUNG;
                btcapNhat.Enabled = true;
                btXoa.Enabled = true;
            }
            catch (Exception)
            {

            }

        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {

        }

        void LoadThongTinDB()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                DataTable table = DAL.BANKTKS.C_DSKiemTra.getThonTinDieuChinh(sodanhbo);
                if (table.Rows.Count > 0)
                {
                    txtLoTrinh.Text = table.Rows[0]["MALOTRINH"] + "";
                    txtTenKH.Text = table.Rows[0]["HOTEN"] + "";
                    txtDiaChi.Text = table.Rows[0]["DIACHI"] + "";
                    txtGB.Text = table.Rows[0]["GB"] + "";
                    txtDM.Text = table.Rows[0]["DM"] + "";
                    txtHopDong.Text = table.Rows[0]["HOPDONG"] + "";
                    txtHieuDhn.Text = table.Rows[0]["HIEUDH"] + "";
                    txtCo.Text = table.Rows[0]["CODH"] + "";
                    txtSoThan.Text = table.Rows[0]["SOTHANDH"] + "";
                    txtCS.Text = table.Rows[0]["CSMOI"] + "";

                }

            }
        }
        private void txtSoDanhBo_Leave(object sender, EventArgs e)
        {
            LoadThongTinDB();
        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }

        public void Add()
        {

            KTKS_DANHSACHKT chuyendm = new KTKS_DANHSACHKT();
            chuyendm.DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
            chuyendm.LOTRINH = this.txtLoTrinh.Text;
            chuyendm.HOTEN = this.txtTenKH.Text;
            chuyendm.DIACHI = this.txtDiaChi.Text;
            chuyendm.HOPDONG = this.txtHopDong.Text;
            chuyendm.GB = this.txtGB.Text;
            chuyendm.DM = this.txtDM.Text;
            chuyendm.CHISO = this.txtCS.Text;
            chuyendm.HIEUDHN = this.txtHieuDhn.Text;
            chuyendm.CODHN = this.txtCo.Text;
            chuyendm.SOTHAN = this.txtSoThan.Text;
            chuyendm.CONGDUNG = this.txtCongDung.Text;
            chuyendm.NGAYLAP = this.txtNgayGan.Value.Date;
            chuyendm.CREATEDATE = DateTime.Now;
            chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
            DAL.BANKTKS.C_DSKiemTra.Insert(chuyendm);
            // DAL.DULIEUKH.C_DuLieuKhachHang.UpdateBaoThay(this.txtSoDanhBo.Text.Replace("-", ""), "True");
            LoadData();
            CLEAR();
        }

        public void refeshInser()
        {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGan.ValueObject = null;
            //txtHieu.Text = "";
            //txtCo.Text = "";
            //txtSoThan.Text = "";
            //txtChiThan.Text = "";
            //txtChiGoc.Text = "";
            //txtChiSoThay.Text = "";
            //txtMaLoTrinh.Text = "";
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            txtSoDanhBo.Focus();

        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                KTKS_DANHSACHKT dc = DAL.BANKTKS.C_DSKiemTra.findByC_DSKiemTra_khacgnay(sodanhbo.Replace(" ", ""), this.txtNgayGan.Value.Date);
                if (dc != null)
                {
                    string ngay = Utilities.DateToString.NgayVNVN(dc.NGAYLAP.Value);
                    string mess = "Danh Bộ " + this.txtSoDanhBo.Text + " đã báo ngày " + ngay + " , Báo tiếp ?";
                    if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Add();
                    }
                }
                else
                {
                    Add();
                }

              

            }
            catch (Exception ex)
            {
                log.Error("Them Bao Thay Ko Thanh Cong" + ex.Message);
            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                 
                string ID = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID"].Value + "";
                
                string mess = "Xóa Yêu Cầu Kiếm Tra Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   DAL.BANKTKS.C_DSKiemTra.DeleteBYID(ID);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void btcapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID"].Value + "";
                KTKS_DANHSACHKT thaydh = DAL.BANKTKS.C_DSKiemTra.findByID(int.Parse(ID));
                string mess = "Cập Nhật Thay Đổi  Danh Bộ " + txtSoDanhBo.Text + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh != null)
                {
                    thaydh.DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
                    thaydh.LOTRINH = this.txtLoTrinh.Text;
                    thaydh.HOTEN = this.txtTenKH.Text;
                    thaydh.DIACHI = this.txtDiaChi.Text;
                    thaydh.HOPDONG = this.txtHopDong.Text;
                    thaydh.GB = this.txtGB.Text;
                    thaydh.DM = this.txtDM.Text;
                    thaydh.CHISO = this.txtCS.Text;
                    thaydh.HIEUDHN = this.txtHieuDhn.Text;
                    thaydh.CODHN = this.txtCo.Text;
                    thaydh.SOTHAN = this.txtSoThan.Text;
                    thaydh.NGAYLAP = this.txtNgayGan.Value.Date;
                    thaydh.CONGDUNG = this.txtCongDung.Text;
                    thaydh.MODIFYDATE = DateTime.Now;
                    thaydh.MODIFYBY = DAL.SYS.C_USERS._userName;

                    DAL.BANKTKS.C_DSKiemTra.Update();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void txtChiSoThay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoDanhBo_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            //    DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
            //    if (table.Rows.Count > 0)
            //    {
            //        histotyThay.DataSource = table;
            //        histotyThay.Visible = true;
            //        resultBT.Visible = true;
            //        resultBT.Text = "CÓ " + table.Rows.Count + " LẦN THAY >>";
            //    }
            //    else
            //    {
            //        histotyThay.Visible = false;
            //        resultBT.Visible = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}

        }

        public void CLEAR() {
            txtHieuDhn.Text = "";
            txtLoTrinh.Text = "";
            txtCo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtGB.Text = "";
            txtDM.Text = "";
            txtSoThan.Text = "";
            txtHopDong.Text = "";
            txtSoDanhBo.Text = "";
            this.txtCS.Text = "";
            txtSoDanhBo.Focus();
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;
        }
        private void btTaoMoi_Click_1(object sender, EventArgs e)
        {

            CLEAR();
            
        }

        private void txtNgayGan_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void labelX13_Click(object sender, EventArgs e)
        {

        }

        private void txtCongDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataBangKe_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
    }
}