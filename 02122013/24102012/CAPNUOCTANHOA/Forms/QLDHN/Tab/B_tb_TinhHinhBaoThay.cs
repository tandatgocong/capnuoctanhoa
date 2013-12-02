using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class tb_TinhHinhBaoThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tb_TinhHinhBaoThay).Name);
        string user = "";
        public tb_TinhHinhBaoThay()
        {
            InitializeComponent();
            cbLoaiBangKe.DataSource = DAL.QLDHN.C_BaoThay.getLoaiBangKe();
            cbLoaiBangKe.ValueMember = "LOAIBK";
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.SelectedValue = "DK";
            cbLoaiBangKe.Text = "";
            dateTuNgay.Value = DateTime.Now.Date.AddDays(-30);
            user = DAL.SYS.C_USERS._fullName;
        }
        string sql = "";
        string sql_trongai = "";
        string tenbangke = "";
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string gioihan = "";
                if (checkTanBinh1.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TB01") != null ? DAL.SYS.C_USERS.findByToDS("TB01").GIOIHAN : "";
                    tenbangke = "TỔ TÂN BÌNH 01";
                }
                else if (checkTanBinh2.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TB02") != null ? DAL.SYS.C_USERS.findByToDS("TB02").GIOIHAN : "";
                    tenbangke = "TỔ TÂN BÌNH 02";
                }
                else if (checkTanPhu.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TP") != null ? DAL.SYS.C_USERS.findByToDS("TP").GIOIHAN : "";
                    tenbangke = "TỔ TÂN PHÚ";
                }
                else
                {
                    gioihan = "";
                    tenbangke = "ĐỘI QUẢN LÝ ĐỒNG HỒ NƯỚC ";
                    user = "";
                }
                gioihan = gioihan.Replace("DANHBO", "DHN_DANHBO");


                sql = "SELECT COUNT(DISTINCT (convert(varchar(20),DHN_SOBANGKE)+'-'+DHN_TODS)) AS 'TONG',COUNT(*) AS 'SOLUONGTHAY' ";
                sql += " ,COUNT(case when HCT_NGAYGAN IS NULL then 1 else null end) AS 'CHUAGAN'";
                sql += " ,count(case when HCT_TRONGAI ='False' then 1 else null end) AS 'HOANTAT' ";
                sql += " ,count(case when HCT_TRONGAI ='True' then 1 else null end) AS 'TRONGAI' ";
                sql += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL " + gioihan;

                string sql_detail = "SELECT DHN_NGAYBAOTHAY,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS 'TENBK',DHN_LOAIBANGKE,COUNT(*) AS 'SOLUONGTHAY' ";
                sql_detail += " ,COUNT(*) - (COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end)+COUNT(case when HCT_TRONGAI IS NULL then 1 else null end)) AS 'CHUAGAN'";
                sql_detail += " ,count(case when HCT_TRONGAI ='False' then 1 else null end) AS 'HOANTAT' ";
                sql_detail += " ,count(case when HCT_TRONGAI ='True' then 1 else null end) AS 'TRONGAI' ";
                sql_detail += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL " + gioihan;


                string sql_chuathay = "SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI',CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' ";
                sql_chuathay += "FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND ( HCT_TRONGAI IS NULL) " + gioihan;

                sql_trongai = " SELECT XLT_CHUYENXL,XLT_KETQUA,loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI' ";
                sql_trongai += " , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , CONVERT(VARCHAR(20),HCT_NGAYGAN,103) AS 'HCT_NGAYGAN' , HCT_LYDOTRONGAI as 'TRONGAI' ";
                sql_trongai += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh 	";
                sql_trongai += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' " + gioihan;

                if (!"".Equals(cbLoaiBangKe.Text.Trim()))
                {
                    sql += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_chuathay += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_trongai += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_detail += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                }

                if (tabItem1.IsSelected == true)
                {
                }
                else if (tabItem2.IsSelected == true)
                {
                    sql += " AND CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_chuathay += " AND CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_trongai += " AND CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_detail += " AND CONVERT(DATETIME,DHN_NGAYBAOTHAY,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                }
                else if (tabItem3.IsSelected == true)
                {
                    sql += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_chuathay += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_trongai += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_detail += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                }
                sql_chuathay += "ORDER BY DHN_NGAYBAOTHAY  ASC ";
                sql_trongai += " ORDER BY DHN_NGAYBAOTHAY ASC ";
                sql_detail += " GROUP BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)),DHN_LOAIBANGKE,DHN_NGAYBAOTHAY ";
                sql_detail += " ORDER BY DHN_NGAYBAOTHAY  DESC ";

                dataTongKet.DataSource = DAL.LinQConnection.getDataTable(sql);
                dataGridChuaThay.DataSource = DAL.LinQConnection.getDataTable(sql_chuathay);
                dataGridLoi.DataSource = DAL.LinQConnection.getDataTable(sql_trongai);
                dataGridView1.DataSource = DAL.LinQConnection.getDataTable(sql_detail);

                Utilities.DataGridV.formatRows(dataGridChuaThay, "G_DANHBO");
                Utilities.DataGridV.setSTT(dataGridChuaThay, "STT");

                Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
                Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");

                Utilities.DataGridV.formatRows(dataGridView1);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }


        }

        private void tabItem5_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridChuaThay, "G_DANHBO");
            Utilities.DataGridV.setSTT(dataGridChuaThay, "STT");
        }

        private void tabItem7_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
            Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();
            try
            {
                db.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(ds, "TONGKET");

                adapter = new SqlDataAdapter(sql_trongai, db.Connection.ConnectionString);
                adapter.Fill(ds, "DANHSACHTRONGAI");

                ReportDocument rp = new rpt_TongKetBaoThayDHN();
                rp.SetDataSource(ds);
                rp.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                rp.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));
                rp.SetParameterValue("TEN",tenbangke);
                rp.SetParameterValue("USER", user);
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
    }
}