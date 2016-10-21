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

namespace CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh
{
    public partial class frm_DieuChinh : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_DieuChinh()
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
             
                ReportDocument rp = new rpt_PhieuChuyenDinhMuc();                         
                rp.SetDataSource(DAL.QLDHN.C_ChuyenDinhMuc.getReport(this.txtNgayGan.Value.ToShortDateString()));
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            
        }

       
        public void LoadData()
        {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_ChuyenDinhMuc.getListDCByDate(this.txtNgayGan.Value.ToShortDateString());
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
                string LOTRINH = dataBangKe.Rows[e.RowIndex].Cells["LOTRINH"].Value + "";
                string ky = dataBangKe.Rows[e.RowIndex].Cells["ky"].Value + "";
                string DOT = dataBangKe.Rows[e.RowIndex].Cells["DOT"].Value + "";
                string NAM = dataBangKe.Rows[e.RowIndex].Cells["NAM"].Value + "";
                string G_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string HOPDONG = dataBangKe.Rows[e.RowIndex].Cells["HOPDONG"].Value + "";
                string GB = dataBangKe.Rows[e.RowIndex].Cells["GB"].Value + "";
                string DM = dataBangKe.Rows[e.RowIndex].Cells["DM"].Value + "";
                string TTBQ = dataBangKe.Rows[e.RowIndex].Cells["TTBQ"].Value + "";
                string CONGDUNG = dataBangKe.Rows[e.RowIndex].Cells["CONGDUNG"].Value + "";

                this.TXTid.Text = ID;
                this.txtLoTrinh.Text = LOTRINH;
                this.txtKY.Text = ky;
                this.txtDot.Text = DOT;
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ","");
                this.txtTenKH.Text = G_TENKH;
                this.txtDiaChi.Text = G_DIACHI;
                this.txtHopDong.Text = HOPDONG;
                this.txtGB.Text = GB;
                this.txtDM.Text = DM;
                this.txtBQ.Text = TTBQ;
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
                DataTable table = DAL.QLDHN.C_ChuyenDinhMuc.getThonTinDieuChinh(sodanhbo);
                if (table.Rows.Count > 0)
                {
                    txtDot.Text = table.Rows[0]["DOT"] + "";
                    txtLoTrinh.Text = table.Rows[0]["MALOTRINH"] + "";
                    txtKY.Text = table.Rows[0]["KY"] + "";                     
                    txtTenKH.Text = table.Rows[0]["HOTEN"] + "";
                    txtDiaChi.Text = table.Rows[0]["DIACHI"] + "";
                    txtGB.Text = table.Rows[0]["GB"] + "";
                    txtDM.Text = table.Rows[0]["DM"] + "";
                    txtBQ.Text = table.Rows[0]["TBTHU"] + "";
                    txtHopDong.Text = table.Rows[0]["HOPDONG"] + "";
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

            TB_CHUYENDINHMUC chuyendm = new TB_CHUYENDINHMUC();
            chuyendm.KY = int.Parse(txtKY.Text);
            chuyendm.DOT = int.Parse(txtDot.Text);
            chuyendm.NAM = DateTime.Now.Date.Year;
            chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
            chuyendm.DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
            chuyendm.LOTRINH = this.txtLoTrinh.Text;
            chuyendm.HOTEN = this.txtTenKH.Text;
            chuyendm.DIACHI = this.txtDiaChi.Text;
            chuyendm.HOPDONG = this.txtHopDong.Text;
            chuyendm.GB = this.txtGB.Text;
            chuyendm.DM = this.txtDM.Text;
            chuyendm.TTBQ = int.Parse(this.txtBQ.Text);
            chuyendm.CONGDUNG = this.txtCongDung.Text;
            chuyendm.NGAYLAP = this.txtNgayGan.Value.Date;
            chuyendm.CREATEDATE = DateTime.Now;
            chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
            DAL.QLDHN.C_ChuyenDinhMuc.Insert(chuyendm);
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
                TB_CHUYENDINHMUC dc = DAL.QLDHN.C_ChuyenDinhMuc.findByTB_CHUYENDINHMUC_khacgnay(sodanhbo.Replace(" ", ""), this.txtNgayGan.Value.Date);
                if (dc != null)
                {
                    string ngay = Utilities.DateToString.NgayVNVN(dc.NGAYLAP.Value);
                    string mess = "Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " đã báo ngày " + ngay + " , Báo tiếp ?";
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
                
                string mess = "Xóa Thay Đổi Định Mức Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.QLDHN.C_ChuyenDinhMuc.DeleteBYID(ID);
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
                TB_CHUYENDINHMUC thaydh = DAL.QLDHN.C_ChuyenDinhMuc.findByID(int.Parse(ID));
                string mess = "Cập Nhật Thay Đổi Định Mức Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh != null)
                {
                    thaydh.KY = int.Parse(txtKY.Text);
                    thaydh.DOT = int.Parse(txtDot.Text);
                    thaydh.NAM = DateTime.Now.Date.Year;
                    thaydh.TODS = DAL.SYS.C_USERS._toDocSo;
                    thaydh.DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
                    thaydh.LOTRINH = this.txtLoTrinh.Text;
                    thaydh.HOTEN = this.txtTenKH.Text;
                    thaydh.DIACHI = this.txtDiaChi.Text;
                    thaydh.HOPDONG = this.txtHopDong.Text;
                    thaydh.GB = this.txtGB.Text;
                    thaydh.DM = this.txtDM.Text;
                    thaydh.TTBQ = int.Parse(this.txtBQ.Text);
                    thaydh.CONGDUNG = this.txtCongDung.Text;
                    thaydh.MODIFYDATE = DateTime.Now;
                    thaydh.MODIFYBY = DAL.SYS.C_USERS._userName;

                    DAL.QLDHN.C_ChuyenDinhMuc.Update();
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
            txtDot.Text = "";
            txtLoTrinh.Text = "";
            txtKY.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtGB.Text = "";
            txtDM.Text = "";
            txtBQ.Text = "";
            txtHopDong.Text = "";
            txtSoDanhBo.Text = "";
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

        private void dataBangKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_DieuChinh_Load(object sender, EventArgs e)
        {

        }
    }
}