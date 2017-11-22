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

namespace CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh
{
    public partial class frm_PhieuChuyennnnn : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DanhSachKT).Name);
        public frm_PhieuChuyennnnn()
        {
            InitializeComponent();
           
            formLoad();
            

        }
        public void loadghichu(string danhbo)
        {
            lichsuGhiCHu.DataSource = DAL.LinQConnection.getDataTable("SELECT BANGKE,KINHGUI,VEVIEC, NGAYLAP,  VANBANG, CONGDUNG   FROM TB_PHIEUCHUYEN WHERE DANHBO='" + danhbo + "' ORDER BY CREATEDATE DESC ");
        }
        public static int getMaxBangKe ()
        {
            string sql = "SELECT MAX(BANGKE)  FROM TB_PHIEUCHUYEN WHERE CREATEBY='" + DAL.SYS.C_USERS._userName + "' ";
            return LinQConnection.ExecuteCommand(sql);
        }

        void formLoad()
        {
            LoadData();
            this.txtTods.Text = DAL.SYS.C_USERS._toDocSo;
            try
            {
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                int id = getMaxBangKe();
                if (id >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (id + 1) + "";

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

            ReportDocument rp = new rpt_PhieuChuyennnnnnnn();
            rp.SetDataSource(DAL.BANKTKS.C_DSKiemTra.getReport_pc(this.txtSoBangKe.Text));


            rp.SetParameterValue("kg", this.kg.Text);
            rp.SetParameterValue("vv", this.vv.Text);
            rp.SetParameterValue("tods", this.txtTods.Text);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
            
        }

       
        public void LoadData()
        {
            try
            {

                string sql = " SELECT ID, DANHBO, HOTEN, DIACHI,  VANBANG, CONGDUNG  FROM TB_PHIEUCHUYEN WHERE BANGKE='" + this.txtSoBangKe.Text + "'  AND CREATEBY='" + DAL.SYS.C_USERS._userName + "'   ORDER BY CREATEDATE ASC ";
                dataBangKe.DataSource = LinQConnection.getDataTable(sql);
                Utilities.DataGridV.formatRows(dataBangKe);
                lbTC.Text = "TỔNG CỘNG : " + dataBangKe.RowCount + " DANH BỘ";
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
                string G_TENKH = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string G_DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";                
                string CONGDUNG = dataBangKe.Rows[e.RowIndex].Cells["GHICHU"].Value + ""; 
                this.TXTid.Text = ID;
                this.txtSoDanhBo.Text = G_DANHBO.Replace(" ", "");
                this.txtTenKH.Text = G_TENKH;
                this.txtDiaChi.Text = G_DIACHI;
                this.txtVanBang.Text = dataBangKe.Rows[e.RowIndex].Cells["G_VANBANG"].Value + ""; 
                this.txtCongDung.Text = CONGDUNG;
                
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
                    //txtLoTrinh.Text = table.Rows[0]["MALOTRINH"] + "";
                    txtTenKH.Text = table.Rows[0]["HOTEN"] + "";
                    txtDiaChi.Text = table.Rows[0]["DIACHI"] + "";
                    txtGB.Text = table.Rows[0]["GB"] + "";
                    txtDM.Text = table.Rows[0]["DM"] + "";
                   // txtHopDong.Text = table.Rows[0]["HOPDONG"] + "";
                    txtHieuDhn.Text = table.Rows[0]["HIEUDH"] + "";
                    txtCo.Text = table.Rows[0]["CODH"] + "";
                    txtSoThan.Text = table.Rows[0]["SOTHANDH"] + "";
                    txtCS.Text = table.Rows[0]["CSMOI"] + "";
                  //  dataGridView2.DataSource = C_ThuTien.getHoaDon(sodanhbo);
                }
                loadghichu(sodanhbo);
                
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

            TB_PHIEUCHUYEN chuyendm = new TB_PHIEUCHUYEN();
            chuyendm.BANGKE = this.txtSoBangKe.Text;
            chuyendm.KINHGUI = this.kg.Text;
            chuyendm.VEVIEC = this.vv.Text;
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
            chuyendm.VANBANG = this.txtVanBang.Text;
            chuyendm.CONGDUNG = this.txtCongDung.Text;
            chuyendm.NGAYLAP = DateTime.Now.Date;
            chuyendm.CREATEDATE = DateTime.Now;
            chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
            DAL.BANKTKS.C_DSKiemTra.Insert_pc(chuyendm);

            LoadData();
          
        }

        public void refeshInser()
        {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            //txtNgayGan.ValueObject = null;
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
                //string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                //KTKS_DANHSACHKT dc = DAL.BANKTKS.C_DSKiemTra.findByC_DSKiemTra_khacgnay(sodanhbo.Replace(" ", ""), this.txtNgayGan.Value.Date);
                //if (dc != null)
                //{
                //    string ngay = Utilities.DateToString.NgayVNVN(dc.NGAYLAP.Value);
                //    string mess = "Danh Bộ " + this.txtSoDanhBo.Text + " đã báo ngày " + ngay + " , Báo tiếp ?";
                //    if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        Add();
                //    }
                //}
                //else
                //{
                Add();
                if (chkTNThay.Checked)
                {
                    string noidung = "Đã chuyển" + kg.SelectedText + "  BK " +txtTods.Text+"- "  + txtSoBangKe.Text;
                    string sql = "INSERT INTO [CAPNUOCTANHOA].[dbo].[DHNTRONGAITHAY] ([TODS],[DOT],[LOTRINH],[DANHBO],[HD],[HOTEN],[SONHA],[TENDUONG],[HIEUDH],[CODH],[SOTHAN],[NGAYTHAY],[CODE],[NGAYKD],[GHICHU],[QUIUOC],NGUOITAO,NGAYTAO ) ";
                    sql += " SELECT  CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15')  ";
                    sql += "         THEN 'TB01' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30')  ";
                    sql += "         THEN 'TB02' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50')  ";
                    sql += "        THEN 'TP01' ELSE 'TP02' END END END AS TODS, DOT, LOTRINH, DANHBO, HOPDONG AS HD, HOTEN, SONHA, TENDUONG, HIEUDH, CODH, SOTHANDH AS SOTHAN, ";
                    sql += "        CONVERT(varchar(50), NGAYTHAY,103) AS  NGAYTHAY, CODE, CONVERT(varchar(50),NGAYKIEMDINH,103) AS NGAYKD, N'" + noidung + "' AS  GHICHU, '' AS QUIUOC, '" + DAL.SYS.C_USERS._userName + "' as NGUOITAO,GETDATE() as NGAYTAO ";
                    sql += " FROM TB_DULIEUKHACHHANG WHERE DANHBO='" + this.txtSoDanhBo.Text.Replace("-", "") + "'";//13222900540

                    DAL.LinQConnection.ExecuteCommand(sql);
                }
                chkTNThay.Checked = false;
                //}

                CLEAR();

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

                LinQConnection.ExecuteCommand("DELETE FROM TB_PHIEUCHUYEN WHERE ID='" + ID + "'");
                LoadData();

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
                   // thaydh.LOTRINH = this.txtLoTrinh.Text;
                    thaydh.HOTEN = this.txtTenKH.Text;
                    thaydh.DIACHI = this.txtDiaChi.Text;
                   /// thaydh.HOPDONG = this.txtHopDong.Text;
                    thaydh.GB = this.txtGB.Text;
                    thaydh.DM = this.txtDM.Text;
                    thaydh.CHISO = this.txtCS.Text;
                    thaydh.HIEUDHN = this.txtHieuDhn.Text;
                    thaydh.CODHN = this.txtCo.Text;
                    thaydh.SOTHAN = this.txtSoThan.Text;
                    //thaydh.NGAYLAP = this.txtNgayGan.Value.Date;
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
            //txtLoTrinh.Text = "";
            txtCo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtGB.Text = "";
            txtDM.Text = "";
            txtSoThan.Text = "";
           // txtHopDong.Text = "";
            txtSoDanhBo.Text = "";
            this.txtCS.Text = "";
            txtSoDanhBo.Focus();
           // btcapNhat.Enabled = false;
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