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
    public partial class frm_DUTCHITHAN : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_DUTCHITHAN()
        {
            InitializeComponent();
            // this.cbLoaiBangKe.Focus(); 
            formLoad();
            comboBoxDutChi.SelectedIndex = 0;
            comboBoxTitle.SelectedIndex = 0;
           
        }

        void formLoad()
        {

            txtNgayGan.Value = DateTime.Now.Date;
            LoadData();


            try
            {
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                int max=DAL.QLDHN.C_BaoThay.getMaxBangKe_DC();
                if (max >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe_DC() + 1) + "";
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
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        private void btIn_Click(object sender, EventArgs e)
        {
            int lan = 1;
            if (tabControl1.SelectedIndex == 1)
            {
                lan = 2;
            }

            if (comboBoxDutChi.SelectedIndex == 0) {
                ReportDocument rp = new rpt_TLKDutChi();
                rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(this.txtNgayGan.Value.Date.ToShortDateString(),0, comboBoxTitle.SelectedIndex, lan, int.Parse(this.txtSoBangKe.Text)));
                rp.SetParameterValue("type", DAL.SYS.C_USERS._toDocSo + '-'+this.txtSoBangKe.Text );
                rp.SetParameterValue("lan", lan);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
            else if (comboBoxDutChi.SelectedIndex == 1) {
                ReportDocument rp = new rpt_TLKDutChi_Goc_();
                rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(this.txtNgayGan.Value.Date.ToShortDateString(), 1, lan, int.Parse(this.txtSoBangKe.Text)));
                rp.SetParameterValue("NGUOILAP",DAL.SYS.C_USERS._fullName.ToUpper());
                rp.SetParameterValue("lan", "");
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
            

        }

       
        public void LoadData()
        {
            try
            {


                dataBangKe.DataSource = DAL.QLDHN.C_DhnAmSau.getListDutChiByDate_SoBK(this.txtNgayGan.Value.ToShortDateString(), comboBoxDutChi.SelectedIndex, 1, int.Parse(this.txtSoBangKe.Text));
                dataGridViewL2.DataSource = DAL.QLDHN.C_DhnAmSau.getListDutChiByDate_SoBK(this.txtNgayGan.Value.ToShortDateString(), comboBoxDutChi.SelectedIndex, 2, int.Parse(this.txtSoBangKe.Text));
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }
        

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = dataBangKe.Rows[e.RowIndex].Cells["ID"].Value + "";
                string LOTRINH = dataBangKe.Rows[e.RowIndex].Cells["LOTRINH"].Value + "";
                string G_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string HOPDONG = dataBangKe.Rows[e.RowIndex].Cells["HOPDONG"].Value + "";
                string HIEUDHN = dataBangKe.Rows[e.RowIndex].Cells["HIEUDHN"].Value + "";
                string CO = dataBangKe.Rows[e.RowIndex].Cells["CO"].Value + "";

                string sT = dataBangKe.Rows[e.RowIndex].Cells["SOTHAN"].Value + "";
                this.txtSoThan.Text = sT;
                string GB_ = dataBangKe.Rows[e.RowIndex].Cells["GB"].Value + "";
                this.TXTGB.Text = GB_;

                string DM_ = dataBangKe.Rows[e.RowIndex].Cells["DM"].Value + "";

                this.TXTDM.Text = DM_;
                this.txtCoDHN.Text = CO;
                this.txtLoTrinh.Text = LOTRINH;               
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ","");
                this.txtTenKH.Text = G_TENKH;
                this.txtDiaChi.Text = G_DIACHI;
                this.txtHopDong.Text = HOPDONG;             
                this.txtHieuDHN.Text = HIEUDHN;
                btXoa.Enabled = true;
            }
            catch (Exception)
            {

            }
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT();
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {

        }

        void LoadThongTinDB()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (kh!=null)
                {
                   
                    txtLoTrinh.Text = kh.LOTRINH;
                    txtTenKH.Text = kh.HOTEN;
                    string dc = "";
                    
                    try
                    {
                        LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(kh.QUAN));
                        if (q != null)
                        {
                            LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, kh.PHUONG.Trim());
                            dc = kh.SONHA + " " + kh.TENDUONG + ", P." + ph.TENPHUONG + "";
                        }
                    }
                    catch (Exception)
                    {
                    }

                    txtDiaChi.Text = dc;
                    txtSoThan.Text = kh.SOTHANDH;
                    TXTGB.Text = kh.GIABIEU;
                    TXTDM.Text = kh.DINHMUC;
                    txtHopDong.Text = kh.HOPDONG;
                    txtCoDHN.Text = kh.CODH;
                    TB_HIEUDONGHO hieudh = null;
                    try
                    {
                        hieudh = DAL.QLDHN.C_BaoThay.finByHieuDH(kh.HIEUDH.Substring(0, 3));
                    }
                    catch (Exception)
                    {
                    }
                    txtHieuDHN.Text = hieudh != null ? hieudh.TENDONGHO : kh.HIEUDH;
                    
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

        public void Add(string sodanhbo, int lan)
        {
            TB_TLKDUTCHI dc = DAL.QLDHN.C_DhnAmSau.findByDanhBoDutChi(sodanhbo.Replace(" ", ""), this.txtNgayGan.Value.Date);
            if (dc != null)
            {
                dc.TODS = DAL.SYS.C_USERS._toDocSo;
                dc.SOBANGKE = int.Parse(this.txtSoBangKe.Text);
                dc.DANHBO = sodanhbo;
                dc.LOTRINH = txtLoTrinh.Text.Replace(".","");
                dc.HOTEN = txtTenKH.Text;
                dc.DIACHI =txtDiaChi.Text;
                dc.HOPDONG = txtHopDong.Text;
                dc.GB = TXTGB.Text;
                dc.DM = TXTDM.Text;
                dc.HIEU = txtHieuDHN.Text;
                dc.CO = txtCoDHN.Text;
                dc.TYPE = comboBoxDutChi.SelectedIndex;
                dc.SONAM = comboBoxTitle.SelectedIndex;
                dc.SOTHAN = txtSoThan.Text;
                dc.NGAYBAO = this.txtNgayGan.Value.Date;
                dc.GHICHU = this.txtGhiCHu.Text;
                dc.MODIFYDATE = DateTime.Now;
                dc.LAN = lan;
                dc.MODIFYBY = DAL.SYS.C_USERS._userName;
                DAL.QLDHN.C_DhnAmSau.Update();
            }
            else
            {
                dc = new TB_TLKDUTCHI();
                dc.TODS = DAL.SYS.C_USERS._toDocSo;
                dc.SOBANGKE = int.Parse(this.txtSoBangKe.Text);
                dc.DANHBO = sodanhbo;
                dc.LOTRINH = txtLoTrinh.Text.Replace(".", "");
                dc.HOTEN = txtTenKH.Text;
                dc.DIACHI = txtDiaChi.Text;
                dc.HOPDONG = txtHopDong.Text;
                dc.GB = TXTGB.Text;
                dc.DM = TXTDM.Text;
                dc.HIEU = txtHieuDHN.Text;
                dc.CO = txtCoDHN.Text;
                dc.TYPE = comboBoxDutChi.SelectedIndex;
                dc.SONAM = comboBoxTitle.SelectedIndex;
                dc.SOTHAN = txtSoThan.Text;
                dc.NGAYBAO = this.txtNgayGan.Value.Date;
                dc.GHICHU = this.txtGhiCHu.Text;
                dc.LAN = lan;
                dc.CREATEDATE = DateTime.Now;
                dc.CREATEBY = DAL.SYS.C_USERS._userName;
                DAL.QLDHN.C_DhnAmSau.Insert(dc);
            }
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
          //  btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            txtSoDanhBo.Focus();

        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                TB_TLKDUTCHI dc = DAL.QLDHN.C_DhnAmSau.findByDanhBoDutChi_khacgnay(sodanhbo.Replace(" ", ""), this.txtNgayGan.Value.Date);
                if (dc != null)
                {
                    string ngay= Utilities.DateToString.NgayVNVN(dc.NGAYBAO.Value);
                    string mess = "Danh Bộ " + this.txtSoDanhBo.Text + " đã báo đứt chì ngày " + ngay + " , Báo Lần 2 chọn Yes, Báo Lần 1 Chọn No  ?";
                    DialogResult dr =MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Add(sodanhbo, 2);
                    }
                    else if (dr == DialogResult.No)
                    { Add(sodanhbo, 1); }

                }
                else
                {
                    Add(sodanhbo,1);
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
                string ID = "";
                if (tabControl1.SelectedIndex == 1)
                {
                    ID = dataGridViewL2.Rows[dataGridViewL2.CurrentRow.Index].Cells["dataGridViewTextBoxColumn1"].Value + "";
                }
                else
                {
                    ID = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID"].Value + "";
                }
                

                string mess = "Xóa Nâng ĐHN Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.LinQConnection.ExecuteCommand_("DELETE FROM TB_TLKDUTCHI WHERE ID='"+ID+"'");
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
            //try
            //{
            //    string ID = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID"].Value + "";
            //    TB_TLKDUTCHI thaydh = DAL.QLDHN.C_DhnAmSau.findByID(int.Parse(ID));
            //    string mess = "Cập Nhật Nâng ĐHN Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
            //    if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh != null)
            //    {
            //        thaydh.TODS = DAL.SYS.C_USERS._toDocSo;
            //        thaydh.LOTRINH = this.txtLoTrinh.Text;
            //        thaydh.HOTEN = this.txtTenKH.Text;
            //        thaydh.DIACHI = this.txtDiaChi.Text;
            //        thaydh.HOPDONG = this.txtHopDong.Text;
            //        thaydh.HIEU = this.txtHieuDHN.Text;
            //        thaydh.CO = this.txtCoDHN.Text;
            //        thaydh.NGAYLAP = this.txtNgayGan.Value.Date;                    
            //        thaydh.MODIFYDATE = DateTime.Now;
            //        thaydh.MODIFYBY = DAL.SYS.C_USERS._userName;

            //        DAL.QLDHN.C_DhnAmSau.Update();
            //        LoadData();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}

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
            txtLoTrinh.Text = "";
            //txtKY.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtHieuDHN.Text = "";
            txtCoDHN.Text = "";
            txtHopDong.Text = "";
            txtSoDanhBo.Text = "";
            txtSoDanhBo.Focus();
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

        private void dataBangKe_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT();
        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string ID = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID"].Value + "";
            //    TB_DHNAMSAU thaydh = DAL.QLDHN.C_DhnAmSau.findByID(int.Parse(ID));
            //    string mess = "Cập Nhật Hoàn Công Nâng ĐHN Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
            //    if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh != null)
            //    {
            //        thaydh.NANG = checkGanHop.Checked;
            //        thaydh.NGAYNANG = dateNgayGan.Value.Date;
            //        thaydh.NANG_GHICHU = hc_ChiChu.Text;
            //        DAL.QLDHN.C_DhnAmSau.Update();
            //        MessageBox.Show(this, "Cập Nhật Nâng ĐHN Thành Công ", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}
        }

        private void loai_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDutChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDutChi.SelectedIndex == 1)
            {
                comboBoxTitle.Visible = false;
            }
            else {
                comboBoxTitle.Visible = true;
                comboBoxTitle.SelectedIndex = 0;
            }
            LoadData();
        }

        private void dataGridViewL2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = dataGridViewL2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value + "";
                string G_DANHBO = dataGridViewL2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value + "";
               
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ", "");
                btXoa.Enabled = true;
            }
            catch (Exception)
            {

            }
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT();
        }

        private void txtSoBangKe_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
                LoadData();
        }
    }
}