using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoThayVaXuLy : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DieuChinhThongTin).Name);
        string sql_trongai = "";
        string sql_chuyentt = "";
        string sql_chuyenkt = "";

        public frm_BaoThayVaXuLy()
        {
            InitializeComponent();
            if ("QLDHN,TOCNTT".Contains(DAL.SYS.C_USERS._maphong.ToString()))
            {
                tabItem3.Visible = true;
                this.panelBaoThay.Controls.Clear();
                this.panelBaoThay.Controls.Add(new frm_BaoThayDHN());
            }
            else
            {
                tabControl2.SelectedTabIndex = 1;
            }

            dateTuNgay.ValueObject = DateTime.Now.Date;
            dateDenNgay.ValueObject = DateTime.Now.Date;
            dateInDSDutChi.ValueObject = DateTime.Now.Date;

            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string gioihan = DAL.SYS.C_USERS._gioihan;
                gioihan = gioihan.Replace("DANHBO", "DHN_DANHBO");

                sql_trongai = " SELECT ID_BAOTHAY,XLT_XULY,XLT_TRAKQ,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI',thay.XLT_KETQUA as 'TENBANGKE' ";
                sql_trongai += " , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , HCT_LYDOTRONGAI as 'TRONGAI' ";
                sql_trongai += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh ";
                sql_trongai += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' " + gioihan;
                sql_chuyenkt = sql_trongai + " AND XLT_CHUYENXL='BANKTKS' ";
                sql_chuyentt = sql_trongai + " AND XLT_CHUYENXL='TOTRUONG' ";
                if (tabItem1.IsSelected == true)
                {
                    sql_trongai += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";
                    sql_chuyenkt += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";
                    sql_chuyentt += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";
                }
                else if (tabItem4.IsSelected == true)
                {
                    sql_trongai += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_chuyenkt += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_chuyentt += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";

                }
                sql_trongai += " ORDER BY DHN_NGAYBAOTHAY DESC, DHN_DANHBO DESC ";
                dataGridLoi.DataSource = DAL.LinQConnection.getDataTable(sql_trongai);


                Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
                Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void indsTroNgai_Click(object sender, EventArgs e)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();
            try
            {
                db.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql_trongai, db.Connection.ConnectionString);
                adapter.Fill(ds, "DANHSACHTRONGAI");

                ReportDocument rp = new rpt_TongKetBaoThayDHN_to();
                rp.SetDataSource(ds);
                rp.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay.Value.Date));
                rp.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay.Value.Date));
                rp.SetParameterValue("TEN", DAL.SYS.C_USERS._toDocSo);

                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Report " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_NangDHN();
            rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReport(DateTime.Now.Date.ToShortDateString()));
            rp.SetParameterValue("loai", "");
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void dataGridLoi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridLoi, new Point(e.X, e.Y));
            }
        }

        public void Add(string sodanhbo)
        {
            TB_TLKDUTCHI dc = new TB_TLKDUTCHI();
            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);

            dc.TODS = DAL.SYS.C_USERS._toDocSo;
            dc.DANHBO = sodanhbo;
            dc.LOTRINH = kh.LOTRINH;
            dc.HOTEN = kh.HOTEN;
            dc.DIACHI = kh.SONHA + " " + kh.TENDUONG;
            dc.HOPDONG = kh.HOPDONG;
            dc.GB = kh.GIABIEU;
            dc.DM = kh.DINHMUC;
            dc.HIEU = kh.HIEUDH;
            dc.CO = kh.CODH;
            dc.SOTHAN = kh.SOTHANDH;
            dc.NGAYBAO = DateTime.Now.Date;
            dc.MODIFYDATE = DateTime.Now;
            dc.MODIFYBY = DAL.SYS.C_USERS._userName;
            DAL.QLDHN.C_DhnAmSau.Insert(dc);
        }

        private void menuChuyenKT_Click(object sender, EventArgs e)
        {
            string XL = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value + "";
            if ("True".Equals(XL))
            {
                if (MessageBox.Show(this, "Đã chuyển xử lý rồi, cập nhật chuyển xử lý !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                    DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='BANKTKS-DC',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                    this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                    Add((this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["GG_DANHBO"].Value + "").Replace(" ", ""));
                    MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {

                string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='BANKTKS-DC',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                Add((this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["GG_DANHBO"].Value + "").Replace(" ", ""));
                MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuChuyenTT_Click(object sender, EventArgs e)
        {
            string XL = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value + "";
            if ("True".Contains(XL))
            {
                if (MessageBox.Show(this, "Đã chuyển xử lý rồi, cập nhật chuyển xử lý !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                    DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='TOTRUONG',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                    this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                    MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='TOTRUONG',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void chuyenTCTB_Click(object sender, EventArgs e)
        {
            string XL = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value + "";
            if ("True".Contains(XL))
            {
                if (MessageBox.Show(this, "Đã chuyển xử lý rồi, cập nhật chuyển xử lý !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                    DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='TCTB',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                    this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                    MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='TCTB',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuCapNhatKetQua_Click(object sender, EventArgs e)
        {
            if (dataGridLoi.RowCount > 0)
            {
                string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                frm_CapNhatTroNgaiThay frm = new frm_CapNhatTroNgaiThay(ID_BAOTHAY);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                }
            }
        }

        private void dataGridLoi_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
            Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string XL = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value + "";
            if ("True".Contains(XL))
            {
                if (MessageBox.Show(this, "Đã chuyển xử lý rồi, cập nhật chuyển xử lý !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                    DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='BANKTKS-AS',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                    this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                    MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {

                string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                DAL.LinQConnection.ExecuteCommand("UPDATE TB_THAYDHN SET XLT_XULY ='True', XLT_CHUYENXL='BANKTKS-AS',XLT_NGAYCHUYEN=GETDATE() WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'");
                this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
                MessageBox.Show(this, "Chuyển Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // DUT CHU

        private void btInDanhSachChuyenKT_Click(object sender, EventArgs e)
        {
            //int lan = 1;
            //if (tabControl1.SelectedIndex == 1)
            //{
            //    lan = 2;
            //}
            rpt_TLKDutChiNew rp = new rpt_TLKDutChiNew();
            rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(dateInDSDutChi.Value.ToString("dd/MM/yyyy"), 1));
            //rp.SetParameterValue("type", "");
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        // AM SAU
        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void txtDanhB0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {



                sql_trongai = " SELECT ID_BAOTHAY,XLT_XULY,XLT_TRAKQ,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI',thay.XLT_KETQUA as 'TENBANGKE' ";
                sql_trongai += " , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , HCT_LYDOTRONGAI as 'TRONGAI' ";
                sql_trongai += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh ";
                sql_trongai += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' ";
                sql_chuyenkt = sql_trongai + " AND XLT_CHUYENXL='BANKTKS' ";
                sql_chuyentt = sql_trongai + " AND XLT_CHUYENXL='TOTRUONG' ";

                sql_trongai += " AND DHN_DANHBO='" + this.txtDanhB0.Text + "'";
                sql_chuyenkt += " AND DHN_DANHBO='" + this.txtDanhB0.Text + "'";
                sql_chuyentt += " AND DHN_DANHBO='" + this.txtDanhB0.Text + "'";

                sql_trongai += " ORDER BY DHN_NGAYBAOTHAY DESC, DHN_DANHBO DESC ";
                dataGridLoi.DataSource = DAL.LinQConnection.getDataTable(sql_trongai);


                Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
                Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
        public void TheoDoiTroNgaiThay()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY kh.LOTRINH  ASC) [STT],  dhn.TODS, dhn.DOT, dhn.LOTRINH, dhn.DANHBO, dhn.HD, dhn.HOTEN, dhn.SONHA, dhn.TENDUONG, dhn.HIEUDH, dhn.CODH, dhn.SOTHAN, dhn.NGAYTHAY, dhn.CODE, dhn.NGAYKD, dhn.GHICHU, dhn.QUIUOC  FROM DHNTRONGAITHAY dhn, TB_DULIEUKHACHHANG kh WHERE dhn.DANHBO = kh.DANHBO ";
            if (checkChuaThay.Checked)
                sql += " AND  CAST(RIGHT(dhn.NGAYTHAY,4) as int) <= year(kh.NGAYTHAY) ";
            if (checkDaThay.Checked)
                sql += " AND  CAST(RIGHT(dhn.NGAYTHAY,4) as int) > year(kh.NGAYTHAY) ";

            sql += " ORDER BY kh.LOTRINH ASC";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            dataTinhHinhThay.DataSource = tb;

            lbTongCong.Text = "Tổng số " + tb.Rows.Count + " địa chỉ !";
        }

        private void tabItem6_Click(object sender, EventArgs e)
        {
            TheoDoiTroNgaiThay();
        }

        private void checkChuaThay_CheckedChanged(object sender, EventArgs e)
        {
            TheoDoiTroNgaiThay();
        }

        private void dataTinhHinhThay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string DANHBO = dataTinhHinhThay.Rows[e.RowIndex].Cells["DANHBO"].Value + "";
                string HOTEN = dataTinhHinhThay.Rows[e.RowIndex].Cells["HOTEN"].Value + "";
                string SONHA = dataTinhHinhThay.Rows[e.RowIndex].Cells["SONHA"].Value + "";
                string TENDUONG = dataTinhHinhThay.Rows[e.RowIndex].Cells["TENDUONG"].Value + "";
                string NGAYGAN = dataTinhHinhThay.Rows[e.RowIndex].Cells["NGAYTHAY"].Value + "";
                string HIEUDH = dataTinhHinhThay.Rows[e.RowIndex].Cells["HIEUDH"].Value + "";
                string GHICHU = dataTinhHinhThay.Rows[e.RowIndex].Cells["GHICHU"].Value + "";

                //  txtSoBangKe.Text = DHN_SOBANGKE;
                txtSoDanhBo.Text = DANHBO.Replace(" ", "");
                // txtTenKH.Text = HOTEN;

                txtLyDo.Text = GHICHU;

                //   btThem.Enabled = true;
                //  btcapNhat.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btcapNhat_Click(object sender, EventArgs e)
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            DataTable tb = DAL.LinQConnection.getDataTable("SELECT * FROM DHNTRONGAITHAY WHERE DANHBO='" + sodanhbo + "' ");
            if (tb.Rows.Count > 0)
            {
                DAL.LinQConnection.ExecuteCommand("UPDATE DHNTRONGAITHAY SET GHICHU=N'" + this.txtLyDo.Text + "' WHERE  DANHBO='" + sodanhbo + "' ");
            }
            else
            {

                string sql = "INSERT INTO [CAPNUOCTANHOA].[dbo].[DHNTRONGAITHAY] ([TODS],[DOT],[LOTRINH],[DANHBO],[HD],[HOTEN],[SONHA],[TENDUONG],[HIEUDH],[CODH],[SOTHAN],[NGAYTHAY],[CODE],[NGAYKD],[GHICHU],[QUIUOC] ) ";
                sql += " SELECT  CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15')  ";
                sql += "         THEN 'TB01' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30')  ";
                sql += "         THEN 'TB02' ELSE CASE WHEN SUBSTRING(LOTRINH, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50')  ";
                sql += "        THEN 'TP01' ELSE 'TP02' END END END AS TODS, DOT, LOTRINH, DANHBO, HOPDONG AS HD, HOTEN, SONHA, TENDUONG, HIEUDH, CODH, SOTHANDH AS SOTHAN, ";
                sql += "        CONVERT(varchar(50), NGAYTHAY,103) AS  NGAYTHAY, CODE, CONVERT(varchar(50),NGAYKIEMDINH,103) AS NGAYKD, N'" + txtLyDo.Text + "' AS  GHICHU, '' AS QUIUOC ";
                sql += " FROM TB_DULIEUKHACHHANG WHERE DANHBO='" + sodanhbo + "'";//13222900540

                DAL.LinQConnection.ExecuteCommand(sql);
            }

            TheoDoiTroNgaiThay();
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            DAL.LinQConnection.ExecuteCommand("DELETE FROM DHNTRONGAITHAY   WHERE  DANHBO='" + sodanhbo + "' ");
            this.txtSoDanhBo.Text = "";
            txtLyDo.Text = "";

            TheoDoiTroNgaiThay();
        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                DataTable tb = DAL.LinQConnection.getDataTable("SELECT * FROM DHNTRONGAITHAY WHERE DANHBO='" + sodanhbo + "' ");
                if (tb.Rows.Count > 0)
                {
                    this.txtLyDo.Text = tb.Rows[0]["GHICHU"].ToString();
                    //DAL.LinQConnection.ExecuteCommand("UPDATE DHNTRONGAITHAY SET GHICHU=N'" + this.txtLyDo.Text + "' WHERE  DANHBO='" + sodanhbo + "' ");
                }
                else
                {
                    this.txtLyDo.Text = "";
                }
            }
        }

        private void tabTheoDoiCodeK_Click(object sender, EventArgs e)
        {

            DataTable tb = DAL.LinQConnection.getDataTable("SELECT DANHBO FROM z_THEODOICODEk WHERE BAOTHAY='False' ORDER BY  DANHBO ASC");
            dataGridCodeK.DataSource = tb;
        }

        private void dataGridCodeK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridCodeK.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btCodeK_Click(object sender, EventArgs e)
        {
            string sql = " SELECT CASE WHEN SUBSTRING(ds.MLT1, 3, 2) IN ('01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15')  ";
            sql += " THEN 'TB01' ELSE CASE WHEN SUBSTRING(ds.MLT1, 3, 2) IN ('16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30') ";
            sql += " THEN 'TB02' ELSE CASE WHEN SUBSTRING(ds.MLT1, 3, 2) IN ('31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50') ";
            sql += " THEN 'TP01' ELSE 'TP02' END END END AS TODS,t.DANHBO, [CSMoi],[CodeMoi],TieuThuMoi ";
            sql += " FROM [DocSoTH].[dbo].[DocSo] ds,z_THEODOICODEk  t  ";
            sql += " WHERE BAOTHAY='False' AND ds.DanhBa=t.DANHBO AND Ky='" + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "' AND Nam='" + txtNam.Text.Trim() + "'  ORDER BY t.DANHBO ASC";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            dataGridCodeK.DataSource = tb;
        }

        private void dataGridCodeK_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                string tt = this.dataGridCodeK.Rows[e.RowIndex].Cells["TieuThu"].Value.ToString();
                if (!tt.Equals("0"))
                    dataGridCodeK.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }
            catch (Exception)
            {


            }
        }

        private void dataGridCodeK_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dataGridCodeK, new Point(e.X, e.Y));

            }
        }

        private void dafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string listDanhBa = "";
                string tods = "";
                //try
                //{

                int flag = 0;
                for (int i = 0; i < dataGridCodeK.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGridCodeK.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                        listDanhBa += ("'" + (this.dataGridCodeK.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "',");

                        tods = this.dataGridCodeK.Rows[i].Cells["TODSS"].Value + "";
                    }
                }


                ReportDocument rp = new rpt_YeuCauThayDHN();
                rp.SetDataSource(DAL.QLDHN.C_BaoThay.YCbAOtHAY(listDanhBa.Remove(listDanhBa.Length - 1, 1)));
                rp.SetParameterValue("loai", tods);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();

                    string sql = "UPDATE z_THEODOICODEk SET BAOTHAY='True',NGUOICAPNHAT='" + DAL.SYS.C_USERS._userName + "',NGAYCN=GETDATE()  WHERE DANHBO IN (" + listDanhBa.Remove(listDanhBa.Length - 1, 1) + ") ";
                    DAL.LinQConnection.ExecuteCommand(sql);

                    btCodeK.PerformClick();
               

                //if (flag <= int.Parse(Utilities.Files.numberRecord))
                //{
                //    frm_Option_BT frm = new frm_Option_BT(listDanhBa.Remove(listDanhBa.Length - 1, 1));
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        btXemThongTin_Click(sender, e);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //  MessageBox.Show(this,listDanhBa.Remove(listDanhBa.Length-1,1)+ "--" +flag);


                //}
                //catch (Exception)
                //{


                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}