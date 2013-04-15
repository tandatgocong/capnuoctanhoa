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

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_TheoDoiDM : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_TheoDoiDM).Name);
        public frm_TheoDoiDM()
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
          //  dateNgayGan.Value = DateTime.Now.Date;
            LoadData();
            cbLoaiChungTu.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_LOAICHUNGTU ");
            cbLoaiChungTu.DisplayMember = "TENCT";
            cbLoaiChungTu.ValueMember = "MACT";
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

            ////  ReportDocument rp = new rpt_GanHopBaoVe();

            //      rp.SetDataSource(DAL.QLDHN.C_GanHopBaoVe.getReport(this.txtNgayGan.Value.ToShortDateString()));
            //      frm_Reports frm = new frm_Reports(rp);
            //      frm.ShowDialog();

        }


        public void LoadData()
        {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_GanHopBaoVe.getListGanHopByDate(this.txtNgayGan.Value.ToShortDateString());
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
                string G_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string HOPDONG = dataBangKe.Rows[e.RowIndex].Cells["HOPDONG"].Value + "";
                string GB = dataBangKe.Rows[e.RowIndex].Cells["GB"].Value + "";
                string DM = dataBangKe.Rows[e.RowIndex].Cells["DM"].Value + "";
                string HIEUDHN = dataBangKe.Rows[e.RowIndex].Cells["HIEUDHN"].Value + "";
                string CO = dataBangKe.Rows[e.RowIndex].Cells["CO"].Value + "";
                string GHICHU = dataBangKe.Rows[e.RowIndex].Cells["GHICHU"].Value + "";

                this.txtCoDHN.Text = CO;
                this.txtLoTrinh.Text = LOTRINH;
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ", "");
                this.txtTenKH.Text = G_TENKH;
                this.txtDiaChi.Text = G_DIACHI;
                this.txtHopDong.Text = HOPDONG;
                this.txtGB.Text = GB;
                this.txtDMCu.Text = DM;
                this.txtHieuDHN.Text = HIEUDHN;
                this.txtSoPhieu.Text = GHICHU;
                btcapNhat.Enabled = true;
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
                if (kh != null)
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

                    txtDiaChi.Text = dc; ;
                    txtGB.Text = kh.GIABIEU;
                    txtDMCu.Text = kh.DINHMUC;
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

        public void Add()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            //ID, , , , , , , , , HIEU, CO, GHICHU, NGAYLAP, GANHOP, GH_GHICHU, CREATEDATE, CREATEBY, MODIFYDATE, MODIFYBY
            KTKS_THEODOIDM gb = new KTKS_THEODOIDM();
            gb.DANHBO = sodanhbo;
            gb.LOAICT = this.cbLoaiChungTu.SelectedValue.ToString();
            gb.SOPHIEUYC = this.txtSoPhieu.Text;
            gb.HIEULUC = this.txtHieuLuc.Text;
            gb.DMCU = this.txtDMCu.Text;
            gb.DMMOI = this.txtDMMoi.Text;
            gb.NGAYDK = this.dateNgayKy.Value;
            gb.NGAYHETHAN = this.dateNgayHetHan.Value;
            gb.GHICHU = this.txtGhiChu.Text;
            DAL.BANKTKS.C_TheoDoiDM.InsertThongTinDM(gb);


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
                Add();

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

                string mess = "Xóa Gắn Hộp Bảo Vệ Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.QLDHN.C_GanHopBaoVe.DeleteBYID(ID);
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
                TB_GANHOPBV thaydh = DAL.QLDHN.C_GanHopBaoVe.findByID(int.Parse(ID));
                string mess = "Cập Nhật Gắn Hộp Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh != null)
                {
                    thaydh.TODS = DAL.SYS.C_USERS._toDocSo;
                    thaydh.LOTRINH = this.txtLoTrinh.Text;
                    thaydh.HOTEN = this.txtTenKH.Text;
                    thaydh.DIACHI = this.txtDiaChi.Text;
                    thaydh.HOPDONG = this.txtHopDong.Text;
                    thaydh.GB = this.txtGB.Text;
                    thaydh.DM = this.txtDMCu.Text;
                    thaydh.HIEU = this.txtHieuDHN.Text;
                    thaydh.CO = this.txtCoDHN.Text;
                    thaydh.GHICHU = this.txtSoPhieu.Text;
                    thaydh.NGAYLAP = this.txtNgayGan.Value.Date;
                    thaydh.MODIFYDATE = DateTime.Now;
                    thaydh.MODIFYBY = DAL.SYS.C_USERS._userName;

                    DAL.QLDHN.C_GanHopBaoVe.Update();
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

        public void CLEAR()
        {
            txtLoTrinh.Text = "";
            //txtKY.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtGB.Text = "";
            txtDMCu.Text = "";
            txtHieuDHN.Text = "";
            txtCoDHN.Text = "";
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

        private void dataBangKe_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT();
        }

    }
}