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
        string listDanhBa = "";
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

        }

        string sql_trongai = "";
        string sql_chuyentt = "";
        string sql_chuyenkt = "";
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string gioihan = DAL.SYS.C_USERS._gioihan;
                gioihan = gioihan.Replace("DANHBO", "DHN_DANHBO");

                sql_trongai = " SELECT ID_BAOTHAY,XLT_XULY,XLT_TRAKQ,loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI' ";
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
                dc.HOPDONG =kh.HOPDONG;
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
            string ID_BAOTHAY = this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
            frm_CapNhatTroNgaiThay frm = new frm_CapNhatTroNgaiThay(ID_BAOTHAY);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.dataGridLoi.Rows[dataGridLoi.CurrentRow.Index].Cells["XL"].Value = "True";
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
            ReportDocument rp = new rpt_TLKDutChi();
            rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(DateTime.Now.Date.ToShortDateString(),0));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        // AM SAU
        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
    }
}