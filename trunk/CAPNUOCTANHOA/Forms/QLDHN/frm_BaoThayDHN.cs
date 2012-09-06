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

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoThayDHN : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_BaoThayDHN()
        {
            InitializeComponent();
            this.cbLoaiBangKe.Focus(); 
            formLoad();
          //  MessageBox.Show(this, DAL.SYS.C_USERS._tenDocSo);
         //     MessageBox.Show(this, DAL.QLDHN.C_BaoThay.getMaxBangKe() + "");

        }

        void formLoad() {

            cbLoaiBangKe.DataSource = DAL.QLDHN.C_BaoThay.getLoaiBangKe();
            cbLoaiBangKe.ValueMember="LOAIBK";
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.SelectedValue = "DK";

            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            txtHieu.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieu.AutoCompleteCustomSource = namesCollection;
            try
            {
                string balap =  DateTime.Now.Year.ToString().Substring(2)+"001";
                if (DAL.QLDHN.C_BaoThay.getMaxBangKe() >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
                }
                else {
                    txtSoBangKe.Text = balap;
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public void setSTT() {
            for (int i = 0; i < dataBangKe.Rows.Count; i++) {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        private void btIn_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else {
                ReportDocument rp = new rpt_BCBangKe_A3();
                if("A4".Equals(Utilities.Files.pageSize.Trim())){
                    rp = new rpt_BCBangKe_A4();
                }                
                rp.SetDataSource(DAL.QLDHN.C_BaoThay.ReportBaoThay(txtSoBangKe.Text));
                rp.SetParameterValue("lapbk", DAL.SYS.C_USERS._fullName);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void cbLoaiBangKe_SelectedValueChanged(object sender, EventArgs e)
        {
            if ("HC".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            {
                title.Text = "BẢNG KÊ BÁO THAY HẠ CỞ ĐỒNG HỒ NƯỚC ";
                txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            }
            else if ("TH".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            {
                title.Text = "BẢNG KÊ BÁO THAY THỬ ĐỒNG HỒ NƯỚC";
                txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            }
            else if ("BB".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            {
                title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC THEO BIÊN BẢN KIỂM TRA";
                txtLyDo.Text = "BBKT NGÀY ";
            }
            else
            {
                title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC " + this.cbLoaiBangKe.Text;
                txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            }
          //  txtSoBangKe.Focus();
         
        }

        public void LoadData() {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay(int.Parse(txtSoBangKe.Text.Trim()));
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                  log.Error("Loi Load Du Lieu Thay "+ ex.Message);
            }
          
        }

        public void LoadData_DT()
        {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay(txtSoBangKe.Text.Trim());
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                {
                    LoadData_DT();
                }
                else {
                    LoadData();
                }
                
                //btIn.Enabled = true;
            }
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string DHN_LOAIBANGKE = dataBangKe.Rows[e.RowIndex].Cells["DHN_LOAIBANGKE"].Value + "";
                string DHN_SOBANGKE = dataBangKe.Rows[e.RowIndex].Cells["DHN_SOBANGKE"].Value + "";
                string ID_BAOTHAY = dataBangKe.Rows[e.RowIndex].Cells["ID_BAOTHAY"].Value + "";
                string DHN_STT = dataBangKe.Rows[e.RowIndex].Cells["DHN_STT"].Value + "";
                string DHN_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string HOTEN = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string DHN_NGAYBAOTHAY = dataBangKe.Rows[e.RowIndex].Cells["DHN_NGAYBAOTHAY"].Value + "";
                string DHN_NGAYGAN = dataBangKe.Rows[e.RowIndex].Cells["DHN_NGAYGAN"].Value + "";
                string DHN_CHITHAN = dataBangKe.Rows[e.RowIndex].Cells["DHN_CHITHAN"].Value + "";
                string DHN_CHIGOC = dataBangKe.Rows[e.RowIndex].Cells["DHN_CHIGOC"].Value + "";
                string DHN_HIEUDHN = dataBangKe.Rows[e.RowIndex].Cells["G_HIEUDHN"].Value + "";
                string DHN_CODH = dataBangKe.Rows[e.RowIndex].Cells["G_CODHN"].Value + "";
                string DHN_SOTHAN = dataBangKe.Rows[e.RowIndex].Cells["G_SOTHAN"].Value + "";
                string DHN_CHISO = dataBangKe.Rows[e.RowIndex].Cells["G_CHISO"].Value + "";
                string DHN_LYDOTHAY = dataBangKe.Rows[e.RowIndex].Cells["G_LYDO"].Value + "";

                cbLoaiBangKe.SelectedValue = DHN_LOAIBANGKE;
              //  txtSoBangKe.Text = DHN_SOBANGKE;
                txtSoDanhBo.Text = DHN_DANHBO.Replace(" ", "");
                txtTenKH.Text = HOTEN;
                txtDiaChi.Text = DIACHI;
                txtNgayGan.ValueObject = DHN_NGAYGAN;
                txtHieu.Text = DHN_HIEUDHN;
                txtCo.Text = DHN_CODH;
                txtSoThan.Text = DHN_SOTHAN;
                txtChiThan.Text = DHN_CHITHAN;
                txtChiGoc.Text = DHN_CHIGOC;
                txtChiSoThay.Text = DHN_CHISO;
                txtLyDo.Text = DHN_LYDOTHAY;
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

        void LoadThongTinDB() {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
                if (table.Rows.Count > 0)
                {
                    histotyThay.DataSource = table;
                    histotyThay.Visible = true;
                    resultBT.Visible = true;
                    resultBT.Text = "CÓ " + table.Rows.Count + " LẦN THAY >>";
                }
                else
                {
                    histotyThay.Visible = false;
                    resultBT.Visible = false;
                }
                TB_DULIEUKHACHHANG khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    txtTenKH.Text = khachhang.HOTEN;
                    txtDiaChi.Text = khachhang.SONHA + " " + khachhang.TENDUONG;
                    txtNgayGan.ValueObject = khachhang.NGAYTHAY;
                    TB_HIEUDONGHO hieudh=null;
                    try
                    {
                        hieudh = DAL.QLDHN.C_BaoThay.finByHieuDH(khachhang.HIEUDH.Substring(0, 3));
                    }
                    catch (Exception)
                    {
                    }
                    txtHieu.Text = hieudh != null ? hieudh.TENDONGHO : khachhang.HIEUDH;
                    txtCo.Text = khachhang.CODH;
                    txtSoThan.Text = khachhang.SOTHANDH;
                    txtChiThan.Text = "CON";
                    txtChiGoc.Text = "CON";
                    txtChiSoThay.Text = khachhang.CHISOKYTRUOC;
                    
                    txtDot.Text = khachhang.DOT;
                    txtMaLoTrinh.Text = khachhang.LOTRINH;
                }
            }
        }
        private void txtSoDanhBo_Leave(object sender, EventArgs e)
        {
            LoadThongTinDB();
        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            histotyThay.Visible = false;
            histotyThay.Visible = false;
            resultBT.Visible = false;
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }

        public void Add() {

            TB_THAYDHN thaydh = new TB_THAYDHN();
            thaydh.DHN_CHIGOC = this.txtChiGoc.Text.ToUpper();
            thaydh.DHN_CHISO = int.Parse(this.txtChiSoThay.Text.Trim());
            thaydh.DHN_CHITHAN = this.txtChiThan.Text.ToUpper();
            thaydh.DHN_CODH = this.txtCo.Text;
            thaydh.DHN_DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
            thaydh.DHN_DOT = this.txtDot.Text;
            thaydh.DHN_HIEUDHN = this.txtHieu.Text.ToUpper();
            thaydh.DHN_LANTHAY = histotyThay.Rows.Count+1;
            thaydh.DHN_LOAIBANGKE = this.cbLoaiBangKe.SelectedValue + "";
            thaydh.DHN_LYDOTHAY = this.txtLyDo.Text.ToUpper();
            thaydh.DHN_NGAYBAOTHAY = DateTime.Now.Date;
            thaydh.DHN_NGAYGAN = txtNgayGan.Value;
            thaydh.DHN_SOBANGKE = int.Parse(this.txtSoBangKe.Text.Trim());
            thaydh.DHN_SOTHAN = this.txtSoThan.Text.ToUpper();
            thaydh.DHN_STT=dataBangKe.Rows.Count + 1;
            thaydh.DHN_LYDOTHAY = this.txtLyDo.Text;
            thaydh.DHN_GHICHU = this.txtGhiChu.Text;
            thaydh.DHN_TODS = DAL.SYS.C_USERS._toDocSo;
            thaydh.DHN_CREATEBY = DAL.SYS.C_USERS._userName;
            thaydh.DHN_CREATEDATE = DateTime.Now.Date;
            
            DAL.QLDHN.C_BaoThay.Insert(thaydh);
            DAL.DULIEUKH.C_DuLieuKhachHang.UpdateBaoThay(this.txtSoDanhBo.Text.Replace("-", ""), "True");
            LoadData();
        }

        public void refeshInser() {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGan.ValueObject = null;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiThan.Text = "";
            txtChiGoc.Text = "";
            txtChiSoThay.Text = "";
            txtMaLoTrinh.Text = "";
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            txtSoDanhBo.Focus();
           
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataBangKe.Rows.Count <= (int.Parse(Utilities.Files.numberRecord)-1))
                {
                    string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                    if ("".Equals(this.txtSoBangKe.Text))
                    {
                        MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtSoBangKe.Focus();
                    }
                    else if (sodanhbo.Length != 11)
                    {
                        MessageBox.Show(this, "Cần nhập số danh bộ .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtSoDanhBo.Focus();

                    }
                    else
                    {
                        Add();
                        
                        refeshInser();
                    }
                }
                else {
                    MessageBox.Show(this, "Bảng Kê Báo Thay " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string ID_BAOTHAY = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                TB_THAYDHN thay = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY.Replace(" ","")));
                string mess = "Xóa Báo Thay Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thay.DHN_DANHBO, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.QLDHN.C_BaoThay.deleteBAOTHAY(thay);
                    if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        LoadData_DT();
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(  ex.Message);
            }
           
        }

        private void btcapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_BAOTHAY = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                TB_THAYDHN thaydh = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY));
                string mess = "Cập Nhật Báo Thay Cho Danh Bộ  " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thaydh.DHN_DANHBO, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh!=null)
                {
                    thaydh.DHN_CHIGOC = this.txtChiGoc.Text;
                    thaydh.DHN_CHISO = int.Parse(this.txtChiSoThay.Text.Trim());
                    thaydh.DHN_CHITHAN = this.txtChiThan.Text;
                    thaydh.DHN_CODH = this.txtCo.Text;
                    thaydh.DHN_DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
                    thaydh.DHN_HIEUDHN = this.txtHieu.Text;
                    thaydh.DHN_LOAIBANGKE = this.cbLoaiBangKe.SelectedValue + "";
                    thaydh.DHN_GHICHU = this.txtGhiChu.Text;
                    thaydh.DHN_LYDOTHAY = this.txtLyDo.Text;
                    thaydh.DHN_NGAYBAOTHAY = DateTime.Now.Date;
                    thaydh.DHN_NGAYGAN = txtNgayGan.Value;
                    thaydh.DHN_SOTHAN = this.txtSoThan.Text;
                    thaydh.DHN_MODIFYBY = DAL.SYS.C_USERS._userName;
                    thaydh.DHN_MODIFYDATE = DateTime.Now;

                    DAL.QLDHN.C_BaoThay.Update();
                    if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        LoadData_DT();
                    }
                    else
                    {
                        LoadData();
                    }
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
            try
            {
                string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
                if (table.Rows.Count > 0)
                {
                    histotyThay.DataSource = table;
                    histotyThay.Visible = true;
                    resultBT.Visible = true;
                    resultBT.Text = "CÓ " + table.Rows.Count + " LẦN THAY >>";
                }
                else
                {
                    histotyThay.Visible = false;
                    resultBT.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
        }

        private void btTaoMoi_Click_1(object sender, EventArgs e)
        {
            this.cbLoaiBangKe.SelectedValue = "DK";
            txtSoBangKe.Text = "";
            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGan.ValueObject = null;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiThan.Text = "";
            txtChiGoc.Text = "";
            txtChiSoThay.Text = "";
            txtMaLoTrinh.Text = "";
            btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            // btIn.Enabled = false;
            this.histotyThay.Visible = false;
            txtSoBangKe.Focus();
            this.dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay(999999);
            try
            {
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                if (DAL.QLDHN.C_BaoThay.getMaxBangKe() >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
                }
                else
                {
                    txtSoBangKe.Text = balap;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
