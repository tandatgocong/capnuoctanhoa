﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;

namespace CAPNUOCTANHOA.Forms.DoiTCTB.Tab
{
    public partial class h_tab_TinhHinhBaoThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(h_tab_TinhHinhBaoThay).Name);
        public h_tab_TinhHinhBaoThay()
        {
            InitializeComponent();
            cbLoaiBangKe.DataSource = DAL.QLDHN.C_BaoThay.getLoaiBangKe();
            cbLoaiBangKe.ValueMember = "LOAIBK";
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.SelectedValue = "DK";
            cbLoaiBangKe.Text = "";
            dateTuNgay.Value = DateTime.Now.Date.AddDays(-30);
        }
        string sql_dathay = "";
        string sql_chuathay = "";
        string sql_trongai = "";
        string sql = "";
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string gioihan = "";
                if (checkTanBinh1.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TB01") != null ? DAL.SYS.C_USERS.findByToDS("TB01").GIOIHAN : "";
                }
                else if (checkTanBinh2.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TB02") != null ? DAL.SYS.C_USERS.findByToDS("TB02").GIOIHAN : "";
                }
                else if (checkTanPhu.Checked)
                {
                    gioihan = DAL.SYS.C_USERS.findByToDS("TP") != null ? DAL.SYS.C_USERS.findByToDS("TP").GIOIHAN : "";
                }
                else
                {
                    gioihan = "";
                }
                gioihan = gioihan.Replace("DANHBO", "DHN_DANHBO");

                sql = "SELECT COUNT(DISTINCT (convert(varchar(20),DHN_SOBANGKE)+'-'+DHN_TODS)) AS 'TONG',COUNT(*) AS 'SOLUONGTHAY' ";
                sql += " ,COUNT(*) - (COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end) ) AS 'CHUAGAN' ";
                sql += " ,(COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end) - COUNT(case when HCT_TRONGAI ='True' then 1 else null end))  AS 'HOANTAT' ";
                sql += " ,count(case when HCT_TRONGAI ='True' then 1 else null end) AS 'TRONGAI' ";
                sql += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL " + gioihan;

                string sql_detail = "SELECT (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS 'TENBK',DHN_LOAIBANGKE,COUNT(*) AS 'SOLUONGTHAY' ";
                sql_detail += " ,COUNT(*) - (COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end) ) AS 'CHUAGAN' ";
                sql_detail += " ,(COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end) - COUNT(case when HCT_TRONGAI ='True' then 1 else null end))  AS 'HOANTAT' ";
                sql_detail += " ,count(case when HCT_TRONGAI ='True' then 1 else null end) AS 'TRONGAI' ";
                sql_detail += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL " + gioihan;


                sql_chuathay = "SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI',CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' ";
                sql_chuathay += "FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND (HCT_TRONGAI ='0' OR HCT_TRONGAI IS NULL) " + gioihan;

                sql_dathay = "SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI',CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO',CONVERT(VARCHAR(20),HCT_NGAYGAN,103) AS 'HCT_NGAYGAN' ,HCT_HIEUDHNGAN,HCT_CODHNGAN,HCT_SOTHANGAN,HCT_CHITHAN,HCT_CHIGOC ";
                sql_dathay += "FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK AND HCT_NGAYGAN IS NOT NULL  AND (HCT_TRONGAI ='0' OR HCT_TRONGAI IS NULL) " + gioihan;


                sql_trongai = " SELECT loai.TENBANGKE,(DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) as 'SOBANGKE',thay.DHN_DANHBO, kh.HOTEN,(kh.SONHA+' ' +kh.TENDUONG) AS 'DIACHI' ";
                sql_trongai += " , CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) AS 'NGAYBAO' , CONVERT(VARCHAR(20),HCT_NGAYGAN,103) AS 'HCT_NGAYGAN' ,HCT_LYDOTRONGAI as 'TRONGAI' ";
                sql_trongai += " FROM TB_THAYDHN thay, TB_LOAIBANGKE loai,TB_DULIEUKHACHHANG kh 	";
                sql_trongai += " WHERE thay.DHN_DANHBO=kh.DANHBO AND thay.DHN_LOAIBANGKE=loai.LOAIBK  AND HCT_TRONGAI ='1' " + gioihan;

                if (!"".Equals(cbLoaiBangKe.Text.Trim()))
                {
                    sql += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_chuathay += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_trongai += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_detail += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                    sql_dathay += " AND DHN_LOAIBANGKE='" + cbLoaiBangKe.SelectedValue + "'";
                }

                if (tabItem1.IsSelected == true)
                {
                }
                else if (tabItem2.IsSelected == true)
                {
                    sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_chuathay += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_trongai += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_detail += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql_dathay += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                }
                else if (tabItem3.IsSelected == true)
                {
                    sql += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_chuathay += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_trongai += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_detail += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                    sql_dathay += " AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "'";
                }
                sql_chuathay += " ORDER BY DHN_NGAYBAOTHAY  DESC ";
                sql_trongai += " ORDER BY HCT_CREATEDATE DESC ";
                sql_detail += " GROUP BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)),DHN_LOAIBANGKE ";
                sql_detail += " ORDER BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) ASC ";
                sql_dathay += " ORDER BY HCT_NGAYGAN  DESC ";

                dataTongKet.DataSource = DAL.LinQConnection.getDataTable(sql);
                dataGridView1.DataSource = DAL.LinQConnection.getDataTable(sql_detail);
                Utilities.DataGridV.formatRows(dataGridView1);

                dataGridLoi.DataSource = DAL.LinQConnection.getDataTable(sql_trongai);
                Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
                Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");


                dataGridChuaThay.DataSource = DAL.LinQConnection.getDataTable(sql_chuathay);
                Utilities.DataGridV.formatRows(dataGridChuaThay, "G_DANHBO");
                Utilities.DataGridV.setSTT(dataGridChuaThay, "STT");

                dataGridView2.DataSource = DAL.LinQConnection.getDataTable(sql_dathay);
                Utilities.DataGridV.formatRows(dataGridView2, "DTDANHBO");
                Utilities.DataGridV.setSTT(dataGridView2, "DTSTT");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            

        }

        private void tabDaThay_Click(object sender, EventArgs e)
        {

            Utilities.DataGridV.formatRows(dataGridView2, "DTDANHBO");
            Utilities.DataGridV.setSTT(dataGridView2, "DTSTT");
            
        }

        private void tabChuaThay_Click(object sender, EventArgs e)
        {

            Utilities.DataGridV.formatRows(dataGridChuaThay, "G_DANHBO");
            Utilities.DataGridV.setSTT(dataGridChuaThay, "STT");
            
        }

        private void tabTroNgai_Click(object sender, EventArgs e)
        {

            Utilities.DataGridV.formatRows(dataGridLoi, "GG_DANHBO");
            Utilities.DataGridV.setSTT(dataGridLoi, "G_STT");
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

                ReportDocument rp = new Rpt_TongKetBaoThayDHN_TOTHAY();
                rp.SetDataSource(ds);
                rp.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                rp.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));
                rp.SetParameterValue("TEN", " TỔ THAY ");
                rp.SetParameterValue("USER", DAL.SYS.C_USERS._fullName);
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