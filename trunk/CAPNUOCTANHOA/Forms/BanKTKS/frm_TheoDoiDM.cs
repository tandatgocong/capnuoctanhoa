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
using System.Data.SqlClient;

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

            dateNgayKy.Value = DateTime.Now.Date;
            dateNgayHetHan.Value = DateTime.Now.Date;
            searchDate.Value = DateTime.Now.Date;
            //  dateNgayGan.Value = DateTime.Now.Date;
            LoadData();
            cbLoaiChungTu.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_LOAICHUNGTU ");
            cbLoaiChungTu.DisplayMember = "TENCT";
            cbLoaiChungTu.ValueMember = "MACT";
            cbLoaiChungTu.SelectedIndex = 1;
            cbTypeView.SelectedIndex = 1;
            LoadDataGridByDate();
        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        string sql_report = "";
        private void btIn_Click(object sender, EventArgs e)
        {

            ReportDocument rp = new rpt_DSTheoDoiDM();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_report, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_KTKS_THEODOIDM");



            rp.SetDataSource(ds);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();

        }


        public void LoadData()
        {
            //try
            //{
            //    dataBangKe.DataSource = DAL.QLDHN.C_GanHopBaoVe.getListGanHopByDate(this.txtNgayGan.Value.ToShortDateString());
            //    Utilities.DataGridV.formatRows(dataBangKe);
            //    setSTT();
            //}
            //catch (Exception ex)
            //{
            //    log.Error("Loi Load Du Lieu Thay " + ex.Message);
            //}

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
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string HOPDONG = dataBangKe.Rows[e.RowIndex].Cells["HOPDONG"].Value + "";
                string GB = dataBangKe.Rows[e.RowIndex].Cells["GB"].Value + "";
                string DMCU = dataBangKe.Rows[e.RowIndex].Cells["DMCU"].Value + "";
                string DMMOI = dataBangKe.Rows[e.RowIndex].Cells["DMMOI"].Value + "";
                string LOAICT = dataBangKe.Rows[e.RowIndex].Cells["LOAICT"].Value + "";
                string NGAYDK = dataBangKe.Rows[e.RowIndex].Cells["NGAYDK"].Value + "";
                string NGAYHH = dataBangKe.Rows[e.RowIndex].Cells["NGAYHH"].Value + "";
                string HIEULUC = dataBangKe.Rows[e.RowIndex].Cells["HIEULUC"].Value + "";
                string SOPHIEUYC = dataBangKe.Rows[e.RowIndex].Cells["SOPHIEUYC"].Value + "";
                string GHICHU = dataBangKe.Rows[e.RowIndex].Cells["GHICHU"].Value + "";

                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ", "");
                this.txtID.Text = ID;
                txtTenKH.Text = G_TENKH;
                txtDiaChi.Text = G_DIACHI;
                this.txtSoPhieu.Text = SOPHIEUYC;
                this.txtHieuLuc.Text = HIEULUC;
                this.txtHopDong.Text = HOPDONG;
                this.txtDMCu.Text = DMCU;
                this.txtDMMoi.Text = DMMOI;
                this.dateNgayKy.ValueObject = dataBangKe.Rows[e.RowIndex].Cells["NGAYDK"].Value;
                this.dateNgayHetHan.ValueObject = dataBangKe.Rows[e.RowIndex].Cells["NGAYHH"].Value;
                this.txtGhiChu.Text = "";
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
            gb.CREATEBY = DAL.SYS.C_USERS._userName;
            gb.CREATEDATE = DateTime.Now.Date;
            if (DAL.BANKTKS.C_TheoDoiDM.InsertThongTinDM(gb))
            {
                MessageBox.Show(this, "Thêm Thông Tin ĐM Thành Công ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, "Thêm Thông Tin ĐM Thất Bại ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void refeshInser()
        {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            this.txtSoPhieu.Text = "";
            this.txtHieuLuc.Text = "";
            this.txtDMCu.Text = "";
            this.txtDMMoi.Text = "";
            this.dateNgayKy.ValueObject = null;
            this.dateNgayHetHan.ValueObject = null;
            this.txtGhiChu.Text = "";
            btXoa.Enabled = false;
            txtSoDanhBo.Focus();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                LoadDataGridByDate();
                refeshInser();
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

            

                string mess = "Xóa Thông Tin ệ Danh Bộ " + this.txtSoDanhBo.Text + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.LinQConnection.ExecuteCommand_("DELETE FROM KTKS_THEODOIDM WHERE ID='" + this.txtID.Text + "'");
                    dataBangKe.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
                    setSTT();
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

        public void CalcNgay()
        {
            try
            {
                if ("HKH".Equals(cbLoaiChungTu.SelectedValue + ""))
                {

                }
                else if ("KT3".Equals(cbLoaiChungTu.SelectedValue + ""))
                {
                    dateNgayHetHan.Value = dateNgayKy.Value.Date.AddMonths(12);
                }
                else if ("TAT".Equals(cbLoaiChungTu.SelectedValue + ""))
                {
                    dateNgayHetHan.Value = dateNgayKy.Value.Date.AddMonths(6);
                }

            }
            catch (Exception)
            {

            }

        }
        public void LoadDataGridByDate()
        {
            string sql = "SELECT dm.ID,dm.DANHBO,dm.LOAICT,dm.NGAYDK,dm.NGAYHETHAN,DATEDIFF (D , NGAYHETHAN , GETDATE() ) as 'SONGAY',SOPHIEUYC,HIEULUC, dm.DMCU, dm.DMMOI,kh.HOTEN, (kh.SONHA + ' ' + kh.TENDUONG) AS 'DIACHI', kh.HOPDONG,kh.GIABIEU,dm.GHICHU ";
            sql += " FROM KTKS_THEODOIDM dm, TB_DULIEUKHACHHANG kh ";
            sql += " WHERE dm.DANHBO=kh.DANHBO ";
            sql += " AND CONVERT(DATETIME,NGAYDK,103) = CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(searchDate.Value.Date) + "',103) ";
            sql += " ORDER BY dm.NGAYDK DESC ";
            dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
            sql_report = sql;
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
            setSTT();

        }
        private void cbLoaiChungTu_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcNgay();
        }

        private void dateNgayKy_ValueChanged(object sender, EventArgs e)
        {
            CalcNgay();
        }

        private void searchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {

                try
                {
                    string sql = "SELECT dm.ID,dm.DANHBO,dm.LOAICT,dm.NGAYDK,dm.NGAYHETHAN,DATEDIFF (D , NGAYHETHAN , GETDATE() ) as 'SONGAY',SOPHIEUYC,HIEULUC, dm.DMCU, dm.DMMOI,kh.HOTEN, (kh.SONHA + ' ' + kh.TENDUONG) AS 'DIACHI', kh.HOPDONG,kh.GIABIEU,dm.GHICHU ";
                    sql += " FROM KTKS_THEODOIDM dm, TB_DULIEUKHACHHANG kh ";
                    sql += " WHERE dm.DANHBO=kh.DANHBO ";

                    if (cbTypeView.SelectedIndex == 0)
                    {
                    }
                    else if (cbTypeView.SelectedIndex == 1)
                    {
                        sql += " AND CONVERT(DATETIME,NGAYDK,103) = CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(searchDate.Value.Date) + "',103) ";
                    }
                    else if (cbTypeView.SelectedIndex == 2)
                    {
                        sql += " AND MONTH(NGAYDK)=  '" + this.searchText.Text + "' ";
                    }
                    else if (cbTypeView.SelectedIndex == 3)
                    {
                        sql += " AND YEAR(NGAYDK)=  '" + this.searchText.Text + "' ";
                    }
                    else if (cbTypeView.SelectedIndex == 4)
                    {
                        sql += " AND DATEDIFF (D , NGAYHETHAN , GETDATE() ) <0 AND  (DATEDIFF (D , NGAYHETHAN , GETDATE() ) + " + this.searchText.Text + ")>=0";
                    }
                    else if (cbTypeView.SelectedIndex == 5)
                    {
                        sql += " AND DATEDIFF (D , NGAYHETHAN , GETDATE() ) > 0";
                    }

                    sql += " ORDER BY dm.NGAYDK DESC ";
                    dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
                    Utilities.DataGridV.formatRows(dataBangKe, "STT");
                    setSTT();
                    sql_report = sql;
                }
                catch (Exception)
                {


                }

            }
        }

        private void searchDate_ValueChanged(object sender, EventArgs e)
        {

        }


        private void cbTypeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.searchText.Visible = false;
                this.searchText.Visible = false;
                btXoaHetHan.Visible = false;
                string sql = "SELECT dm.ID,dm.DANHBO,dm.LOAICT,dm.NGAYDK,dm.NGAYHETHAN,DATEDIFF (D , NGAYHETHAN , GETDATE() ) as 'SONGAY',SOPHIEUYC,HIEULUC, dm.DMCU, dm.DMMOI,kh.HOTEN, (kh.SONHA + ' ' + kh.TENDUONG) AS 'DIACHI', kh.HOPDONG,kh.GIABIEU,dm.GHICHU ";
                sql += " FROM KTKS_THEODOIDM dm, TB_DULIEUKHACHHANG kh ";
                sql += " WHERE dm.DANHBO=kh.DANHBO ";

                if (cbTypeView.SelectedIndex == 0)
                {
                }
                else if (cbTypeView.SelectedIndex == 1)
                {
                    this.searchText.Visible = false;
                    this.searchDate.Visible = true;
                    sql += " AND CONVERT(DATETIME,NGAYDK,103) = CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(searchDate.Value.Date) + "',103) ";
                }
                else if (cbTypeView.SelectedIndex == 2)
                {
                    this.searchText.Visible = true;
                    this.searchDate.Visible = false;
                    this.searchText.Text = DateTime.Now.Month.ToString();
                    sql += " AND MONTH(NGAYDK)=  '" + this.searchText.Text + "' ";
                }
                else if (cbTypeView.SelectedIndex == 3)
                {
                    this.searchText.Visible = true;
                    this.searchDate.Visible = false;

                    this.searchText.Text = DateTime.Now.Year.ToString();
                    sql += " AND YEAR(NGAYDK)=  '" + this.searchText.Text + "' ";
                }
                else if (cbTypeView.SelectedIndex == 4)
                {
                    this.searchText.Visible = true;
                    this.searchDate.Visible = false;

                    this.searchText.Text = "20";
                    sql += " AND DATEDIFF (D , NGAYHETHAN , GETDATE() ) <0 AND  (DATEDIFF (D , NGAYHETHAN , GETDATE() ) + " + this.searchText.Text + ")>=0";
                }
                else if (cbTypeView.SelectedIndex == 5)
                {
                    btXoaHetHan.Visible = true;
                    sql += " AND DATEDIFF (D , NGAYHETHAN , GETDATE() ) > 0";
                }
                sql += " ORDER BY dm.NGAYDK DESC ";
                dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
                sql_report = sql;
                Utilities.DataGridV.formatRows(dataBangKe, "STT");
                setSTT();
            }
            catch (Exception)
            {
                
                
            }

            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataBangKe.Rows.Count; i++)
                {
                     string ID = dataBangKe.Rows[i].Cells["ID"].Value + "";
                     DAL.LinQConnection.ExecuteCommand_("DELETE FROM KTKS_THEODOIDM WHERE ID='" + ID + "'");
                     dataBangKe.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
                }
                   
               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                string sql = "SELECT dm.ID,dm.DANHBO,dm.LOAICT,dm.NGAYDK,dm.NGAYHETHAN,DATEDIFF (D , NGAYHETHAN , GETDATE() ) as 'SONGAY',SOPHIEUYC,HIEULUC, dm.DMCU, dm.DMMOI,kh.HOTEN, (kh.SONHA + ' ' + kh.TENDUONG) AS 'DIACHI', kh.HOPDONG,kh.GIABIEU ";
                sql += " FROM KTKS_THEODOIDM dm, TB_DULIEUKHACHHANG kh ";
                sql += " WHERE dm.DANHBO=kh.DANHBO AND dm.DANHBO='"+this.maskedTextBox1.Text.Replace("-","")+"'";                
                sql += " ORDER BY dm.NGAYDK DESC ";
                dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
                Utilities.DataGridV.formatRows(dataBangKe, "STT");
                setSTT();
                sql_report = sql;
            }
        }
    }
}