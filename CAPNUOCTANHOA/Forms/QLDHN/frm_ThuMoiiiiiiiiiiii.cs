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
using CAPNUOCTANHOA.DAL.THUTIEN;
using CAPNUOCTANHOA.DAL;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh
{
    public partial class frm_ThuMoiiiiiiiiiiii : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DanhSachKT).Name);
        public frm_ThuMoiiiiiiiiiiii()
        {
            InitializeComponent();
            formLoad();
        }
        

        public void loadghichu(string danhbo)
        {
            string sql = "SELECT LOAI,LAN,NGAYLAP,VEVIEC FROM TB_THUMOII WHERE DANHBO='" + danhbo + "'  ORDER BY CREATEDATE DESC";
            lichsuGhiCHu.DataSource = LinQConnection.getDataTable(sql);

         
        }
        void formLoad()
        {


            namesCollection.Add("Chất đồ nhiều kỳ không đọc được Chỉ số nước");
            namesCollection.Add("ĐHN bị ngập nước");
            namesCollection.Add("ĐHN bị lấp ");
            namesCollection.Add("Khách hàng không hợp tác để biên đọc Chỉ số nước");
            txtCongDung.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCongDung.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCongDung.AutoCompleteCustomSource = namesCollection;


            txtNgayGan.Value = DateTime.Now.Date;
            dateNgayDen.Value = DateTime.Now.Date;

          
            cbLoai.SelectedIndex = 1;
            cbNguoiKy.SelectedIndex = 0;
            LoadData();
        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }

        public  DataSet Thumoi()
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "SELECT TOP(2) *  FROM TB_DULIEUKHACHHANG  ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DULIEUKHACHHANG");
            return ds;
        }

        private void btInMAU_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_ThuMoi_MAU();
            rp.SetDataSource(Thumoi());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();  
        }

        private void btIn_Click(object sender, EventArgs e)
        {

            //ReportDocument rp = new rpt_DSKiemTra();                         
            //    rp.SetDataSource(DAL.BANKTKS.C_DSKiemTra.getReport(this.txtNgayGan.Value.ToShortDateString()));
            //    rp.SetParameterValue("Title", this.txtTile.Text);
            //    rp.SetParameterValue("phong", DAL.SYS.C_USERS._maphong);
            //    frm_Reports frm = new frm_Reports(rp);
            //    frm.ShowDialog();

            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT *  FROM TB_THUMOII WHERE NGAYLAP='" + this.txtNgayGan.Value.ToShortDateString() + "'   ORDER BY DANHBO ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THUMOII");


            ReportDocument rp = new rpt_ThuMoi();
            if (cbNguoiKy.SelectedIndex == 0)
                rp = new rpt_ThuMoi_AN();
            rp.SetDataSource(ds);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
       
        public void LoadData()
        {
            try
            {
                string sql = " SELECT ID, DANHBO,HOTEN,DIACHI,NGAYDEN,VEVIEC  FROM TB_THUMOII WHERE NGAYLAP='" + this.txtNgayGan.Value.ToShortDateString() + "'   ORDER BY DANHBO ASC ";
                dataBangKe.DataSource = LinQConnection.getDataTable(sql);

                Utilities.DataGridV.formatRows(dataBangKe);
                lbTC.Text = "TỔNG CỘNG : " + dataBangKe.RowCount + " DANH BỘ";
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
                this.TXTid.Text = ID;
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
                    //dataGridView2.DataSource = C_ThuTien.getHoaDon(sodanhbo);
                }
                loadghichu(sodanhbo);
                
            }
        }
        private void txtSoDanhBo_Leave(object sender, EventArgs e)
        {
            LoadThongTinDB();
        }
        public int getLan()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");

            string sql = "SELECT ISNULL(MAX(DANHBO),0)  FROM TB_THUMOII WHERE DANHBO='" + sodanhbo + "'";
            return LinQConnection.ExecuteCommand(sql);
        }
        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
                this.txtLan.Text = (getLan() + 1) + "";

            }
        }

        public void Add()
        {

            TB_THUMOII chuyendm = new TB_THUMOII();
            chuyendm.LOAI = this.cbLoai.Text;
            chuyendm.LAN = int.Parse(this.txtLan.Text);
            chuyendm.DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
            chuyendm.LOTRINH = this.txtLoTrinh.Text;
            chuyendm.HOTEN = this.txtTenKH.Text;
            chuyendm.DIACHI = this.txtDiaChi.Text;
            chuyendm.HOPDONG = this.txtHopDong.Text;
            chuyendm.GB = this.txtGB.Text;
            chuyendm.DM = this.txtDM.Text;
            chuyendm.CHISO = this.txtVaoLUc.Text;
            chuyendm.HIEUDHN = this.txtHieuDhn.Text;
            chuyendm.CODHN = this.txtCo.Text;
            chuyendm.SOTHAN = this.txtSoThan.Text;
            chuyendm.VEVIEC = this.txtCongDung.Text;
            chuyendm.NGAYDEN = this.dateNgayDen.Value.Date;
            chuyendm.NGAYLAP = this.txtNgayGan.Value.Date;
            chuyendm.CREATEDATE = DateTime.Now;
            chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
            DAL.BANKTKS.C_DSKiemTra.Insert_TM(chuyendm);
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
            //btcapNhat.Enabled = false;
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

                LinQConnection.ExecuteCommand("DELETE FROM TB_THUMOII WHERE ID='" + ID + "'");
                  
                    LoadData();
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
            //btcapNhat.Enabled = false;
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

       

        
    }
}