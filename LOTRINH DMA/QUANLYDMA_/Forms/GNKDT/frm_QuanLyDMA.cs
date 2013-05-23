﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.GNKDT;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoThayDHN : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_BaoThayDHN()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbMaDMA.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM GNKDT_THONGTINDMA ORDER BY MADMA ASC ");
            cbMaDMA.ValueMember = "MADMA";
            cbMaDMA.DisplayMember = "MADMA";
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataTable tableThay = new DataTable();
        public void Load(string ky, string nam, string madma) {
            try
            {
               
                if (this.rptHanheld.Checked)
                {
                    dataBangKe.DataSource = DAL.GNKDT.C_GNKDT.getThongTinDMAByHandheld(madma, ky, nam);
                    tableThay = DAL.GNKDT.C_GNKDT.getThongTinDMAByHandheld_Thay(madma, ky, nam);
                  
                }
                else if (this.rptHoaDon.Checked)
                {
                    string sql = "SELECT 1  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_TYPE='BASE TABLE'  AND TABLE_NAME='HOADONTH" + ky + "_" + nam + "'";
                    if (DAL.LinQConnection.getDataTable(sql).Rows.Count > 0)
                    {
                        label1.Text = "";
                    }
                    else
                    {
                        label1.Text = "Chưa có dữ liệu hóa đơn Tổng công ty !";
                    }

                    dataBangKe.DataSource = DAL.GNKDT.C_GNKDT.getThongTinDMAByHoaDon(madma, ky, nam);
                    tableThay = DAL.GNKDT.C_GNKDT.getThongTinDMAByHoaDon_Thay(madma, ky, nam);                    
                    Utilities.DataGridV.formatRows(dataBangKe, "STT");
                }

            }
            catch (Exception)
            {

            }
}
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
           
            // Thonng Ke
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            Load(ky, nam, madma);
            lbTongDHN.Text = dataBangKe.Rows.Count + "";
            lbTongGanMoi.Text = DAL.LinQConnection.ExecuteCommand("SELECT COUNT(*) FROM dbo.TB_DULIEUKHACHHANG kh   WHERE kh.NAM>=" + nam + " AND kh.KY_>=" + ky + " AND MADMA='" + madma + "'  ") + "";
            lbTongHuy.Text = DAL.LinQConnection.ExecuteCommand("SELECT COUNT(*) FROM dbo.TB_DULIEUKHACHHANG_HUYDB kh   WHERE  MADMA='" + madma + "'  ") + "";
            lbTongThay.Text = tableThay == null ? "0" : tableThay.Rows.Count + "";

            lbSanLuong.Text = (dataBangKe.DataSource as DataTable).Compute("Sum(LNCC)", "") + "";

          
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            GNKDT.Export.export(dataBangKe, cbMaDMA.SelectedValue.ToString());
        }

        private void dataBangKe_MouseClick(object sender, MouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        private void dataBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmDieuChinhDMA of = new frmDieuChinhDMA();
            if (of.ShowDialog() == DialogResult.OK) {
                string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
                string nam = this.txtNam.Text;
                string madm = cbMaDMA.SelectedValue.ToString();
                Load(ky, nam, madm);
            }
        }

        private void rptHoaDon_CheckedChanged(object sender, EventArgs e)
        {
                string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
                string nam = this.txtNam.Text;                
                string sql = "SELECT 1  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_TYPE='BASE TABLE'  AND TABLE_NAME='HOADONTH" + ky + "_" + nam + "'";
                if (DAL.LinQConnection.getDataTable(sql).Rows.Count > 0) {
                    label1.Text = "";
                } else {
                    label1.Text = "Chưa có dữ liệu hóa đơn Tổng công ty !";
                }
        }

        private void rptHanheld_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void dataBangKe_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe, "STT");
        }

        void GanMoi()
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            string sql = "   SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS            ";
            sql += "  		FROM TB_DULIEUKHACHHANG kh   WHERE kh.NAM>=" + nam + " AND kh.KY_>=" + ky + " AND MADMA='" + madma + "' ";
            dataGanMoi.DataSource = DAL.LinQConnection.getDataTable(sql);
         

        }
        void Huy() {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            string sql = "SELECT LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC',CHUKYDS   ";
            sql += "FROM TB_DULIEUKHACHHANG_HUYDB WHERE  MADMA='" + madma + "' ";
            dataHuy.DataSource = DAL.LinQConnection.getDataTable(sql);
           
        }
        void Thay() {
            dataThay.DataSource = tableThay;
          
        }
        private void tabItem3_Click(object sender, EventArgs e)
        {
            GanMoi();
            
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0) {

                GanMoi();
                Utilities.DataGridV.formatRows(dataGanMoi, "GM_STT");
            } else if (tabControl2.SelectedIndex == 1) {

                Thay();
                Utilities.DataGridV.formatRows(dataThay, "THAY_STT");

            } else {

                Huy();
                Utilities.DataGridV.formatRows(dataHuy, "HUY_STT");
            }
            
        }

        private void dataThay_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataThay, "THAY_STT");
        }

        private void dataGanMoi_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGanMoi, "GM_STT");
        }

        private void dataHuy_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataHuy, "HUY_STT");
        }
    }
}