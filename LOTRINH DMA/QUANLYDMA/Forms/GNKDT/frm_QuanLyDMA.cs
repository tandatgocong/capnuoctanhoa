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

using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.GNKDT;
using System.IO;
using System.Threading;
using System.Configuration;
using CAPNUOCTANHOA.Forms.GNKDT.BAOCAO;


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
        void Load_(string ky, string nam, string madma)
        {
            try
            {

                if (this.rptHanheld.Checked)
                {
                    dataBangKe.DataSource = DAL.GNKDT.C_GNKDT.getThongTinDMAByHandheld(madma, ky, nam);
                    tableThay = DAL.GNKDT.C_GNKDT.getThongTinDMAByHandheld_Thay(madma, ky, nam);

                }
                else if (this.rptHoaDon.Checked)
                {
                    rptHoaDon.Text = " Số Liệu Hóa Đơn ( Hiện có " + DAL.LinQConnection.ExecuteCommand("SELECT MAX(DOT)  FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] kh WHERE kh.NAM=" + nam + " AND kh.KY=" + ky) + " đợt )";

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
            //


            // Thonng Ke
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();

            // UPDATE 
            string sql1 = " UPDATE HOADON SET Quan=DLKH.QUAN ,Phuong=DLKH.PHUONG ,CoDH=DLKH.CODH  ,MaDMA=DLKH.MADMA FROM DLKH WHERE HOADON.DANHBA= DLKH.DANHBO AND HOADON.MaDMA<>DLKH.MADMA and HOADON.KY=" + ky + " and HOADON.NAM=" + nam;
            DAL.LinQConnectionHD.ExecuteCommand_(sql1);
            string sql2 = "UPDATE HOADON SET Quan=DLKH_HUY.QUAN  ,Phuong=DLKH_HUY.PHUONG ,CoDH=DLKH_HUY.CODH ,MaDMA=DLKH_HUY.MADMA FROM DLKH_HUY WHERE HOADON.DANHBA= DLKH_HUY.DANHBO AND HOADON.MaDMA<>DLKH_HUY.MADMA  and HOADON.KY=" + ky + " and HOADON.NAM=" + nam;
            DAL.LinQConnectionHD.ExecuteCommand_(sql2);

            Load_(ky, nam, madma);
            dataGridView3.DataSource = DAL.GNKDT.C_GNKDT.getDHN(madma, ky, nam);
            try
            {
                lbTongDHN.Text = dataBangKe.Rows.Count + "";
                lbTongGanMoi.Text = DAL.LinQConnection.ExecuteCommand("SELECT COUNT(*) FROM dbo.TB_DULIEUKHACHHANG kh WHERE kh.NAM=" + nam + " AND kh.KY_=" + ky + " AND MADMA='" + madma + "'  ") + "";
                lbTongHuy.Text = DAL.LinQConnection.ExecuteCommand("SELECT COUNT(*) FROM dbo.TB_DULIEUKHACHHANG_HUYDB kh WHERE HIEULUCHUY='" + ky + "/" + nam + "' AND  MADMA='" + madma + "'  ") + "";
                lbTongThay.Text = tableThay == null ? "0" : tableThay.Rows.Count + "";
                lbSanLuong.Text = (dataBangKe.DataSource as DataTable).Compute("Sum(LNCC)", "") + "";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            tabPage4.Text = "ĐHN Gắn Mới ĐMA " + madma;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
              string mep = ConfigurationManager.AppSettings["mep"].ToString();
              if ("2".Equals(mep))
              {
                  GNKDT.Export.export(dataBangKe, madma, ky, nam);
              }
              else {
                  // 
                  //oanh stt
                 
                  SaveFileDialog save = new SaveFileDialog();
                  save.Filter = "Excel file *.xls|*.xls";
                  save.FileName = "SAN LUONG DHN DMA " + madma;
                  if (save.ShowDialog() == DialogResult.OK)
                  {
                      DataTable view = (DataTable)dataBangKe.DataSource;
                      // view.Columns.Remove("KY");
                      //view.Columns.Remove("NAM");
                      //view.Columns.Remove("LOTRINH");
                      //view.Columns.Remove("MADMA");
                      view.Columns.Remove("LOTRINH");
                      view.Columns.Remove("HIEULUC");
                      Forms.GNKDT.xmlExcel ex = new Forms.GNKDT.xmlExcel();
                      ex.BuildWorkbook(save.FileName, view, nam, ky, madma);
                      MessageBox.Show("Xuất file thành công");

                  }
                  //oanh end  
              }
            
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
                Load_(ky, nam, madm);
            }
        }

        private void rptHoaDon_CheckedChanged(object sender, EventArgs e)
        {
                //string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
                //string nam = this.txtNam.Text;                
                //string sql = "SELECT 1  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_TYPE='BASE TABLE'  AND TABLE_NAME='HOADONTH" + ky + "_" + nam + "'";
                //if (DAL.LinQConnection.getDataTable(sql).Rows.Count > 0) {
                //    label1.Text = "";
                //} else {
                //    label1.Text = "Chưa có dữ liệu hóa đơn Tổng công ty !";
                //}
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
            this.btInDS.Visible = false;
        }

        void GanMoi()
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            string sql = "   SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT],LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS            ";
            sql += "  		FROM TB_DULIEUKHACHHANG kh   WHERE kh.NAM=" + nam + " AND kh.KY_=" + ky + " AND MADMA='" + madma + "' ";
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable(sql);
        }

        void GanMoiAll()
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            string sql = "   SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT],LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC, (CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) as 'HIEULUC',CHUKYDS,MADMA  ";
            sql += "  		FROM TB_DULIEUKHACHHANG kh   WHERE kh.NAM>=" + nam + " AND kh.KY_>=" + ky + " ";
            dataGridView2.DataSource = DAL.LinQConnection.getDataTable(sql);
        }
        void Huy() {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY LOTRINH  DESC) [STT],LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,CODH,GIABIEU,DINHMUC ,( N'Hủy ' + HIEULUCHUY) as 'HIEULUC',CHUKYDS   ";
            sql += "FROM TB_DULIEUKHACHHANG_HUYDB WHERE HIEULUCHUY='" + ky + "/" + nam + "' AND  MADMA='" + madma + "' ";
            dataHuy.DataSource = DAL.LinQConnection.getDataTable(sql);
        }
        void Thay() {
            dataThay.DataSource = tableThay;
          
        }
        private void tabItem3_Click(object sender, EventArgs e)
        {
            GanMoiAll();
            this.btInDS.Visible = true;
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0) {
                GanMoiAll();
                Utilities.DataGridV.formatRows(dataGridView2, "GM_STT");
            } else if (tabControl2.SelectedIndex == 1) {

                Thay();
                Utilities.DataGridV.formatRows(dataThay, "THAY_STT");
            }
            else if (tabControl2.SelectedIndex == 2)
            {
                Huy();
                Utilities.DataGridV.formatRows(dataHuy, "HUY_STT");
            }else{
                 GanMoi();
                 Utilities.DataGridV.formatRows(dataGridView1, "MOI_STT");
            }
            
        }

        private void dataThay_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataThay, "THAY_STT");
        }

        private void dataGanMoi_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridView2, "GM_STT");
        }

        private void dataHuy_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataHuy, "HUY_STT");
        }
        // lam choi
        public string title_ = "Vui lòng chờ";
        public int time = 30;
        ThreadStart t;
        Thread tt;
        Progress p;
        private void startWait()
        {
            p = new Progress();
            p.text = title_;
            p.itv = time;
            p.ShowDialog();
        }
        private void BeginWait(string til, int tim)
        {
            try
            {
                title_ = til;
                time = tim;
                t = new ThreadStart(startWait);
                tt = new Thread(t);
                tt.Start();
            }
            catch (ThreadStartException) { }
        }
        private void StopWait()
        {
            try
            {
                if (tt.IsAlive)
                {
                    tt.Join(20);
                    tt.Abort();
                }
            }
            catch (ThreadAbortException) { }
        }

       // oanh stt
        private void buttonX4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "xls files (*.xls)|*.xls|xlsx files(*.xlsx)|.xlsx";
            open.ShowDialog();

            string duongdan = open.FileName;

            if (duongdan != "")
            {
                FileInfo TheFile = new FileInfo(duongdan);
                string msg = "";
                if (TheFile.Exists)
                {
                    //this.BeginWait("Lưu chỉ số đã đọc số", 1000);
                    //this.StopWait();
                    this.BeginWait(title_, 120);
                    try
                    {

                        import importfileExcel = new import();
                        msg = importfileExcel.ImportFile(duongdan);
                      this.StopWait();
                        MessageBox.Show(this, msg, "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                //    this.StopWait();

                }
                else
                {

                    MessageBox.Show(this, "File không tồn tại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
              

            }
            // oanh end
          

        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            this.btInDS.Visible = false;
        }
        //OANH STT 
        public void XuatReportTab0()
        {
            ReportDocument rptDoc = new BC_GanMoi();
            DataTable dt = new DataTable();
            GNKDT.BAOCAO.dsDMA ds = new GNKDT.BAOCAO.dsDMA();
            dt.TableName = "GANMOI";
            dt = (DataTable)dataGridView2.DataSource;
            ds.Tables["GANMOI"].Merge(dt);
            ////set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            Reports.frm_Reports frm = new Reports.frm_Reports(rptDoc);
            frm.Show();

        }
        public void XuatReportTab1()
        {
            ReportDocument rptDoc = new BC_Thay();
            DataTable dt = new DataTable();
            GNKDT.BAOCAO.dsDMA ds = new GNKDT.BAOCAO.dsDMA();
            dt.TableName = "THAY";
            dt = (DataTable)dataThay.DataSource;
            ds.Tables["THAY"].Merge(dt);           
            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            rptDoc.SetParameterValue("KY", ky);
            rptDoc.SetParameterValue("NAM", nam);
            rptDoc.SetParameterValue("MADMA", madma);
            Reports.frm_Reports frm = new Reports.frm_Reports(rptDoc);
            frm.Show();
        }
        public void XuatReportTab2()
        {

            DataTable dt = new DataTable();
            GNKDT.BAOCAO.dsDMA ds = new GNKDT.BAOCAO.dsDMA();
            dt.TableName = "HUY";
            dt = (DataTable)dataHuy.DataSource;
            ReportDocument rptDoc = new BC_Huy();
            ds.Tables["HUY"].Merge(dt);
            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            rptDoc.SetParameterValue("KY", ky);
            rptDoc.SetParameterValue("NAM", nam);
            rptDoc.SetParameterValue("MADMA", madma);
            Reports.frm_Reports frm = new Reports.frm_Reports(rptDoc);
            frm.Show();
        }
        public void XuatReportTab3()
        {

            DataTable dt = new DataTable();
            GNKDT.BAOCAO.dsDMA ds = new GNKDT.BAOCAO.dsDMA();
            dt.TableName = "HUY";
            dt = (DataTable)dataGridView1.DataSource;
            ReportDocument rptDoc = new BC_GanMoiVungDMA();
            ds.Tables["HUY"].Merge(dt);
            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            string madma = cbMaDMA.SelectedValue.ToString();
            rptDoc.SetParameterValue("KY", ky);
            rptDoc.SetParameterValue("NAM", nam);
            rptDoc.SetParameterValue("MADMA", madma);
            Reports.frm_Reports frm = new Reports.frm_Reports(rptDoc);
            frm.Show();
        }
        private void btInDS_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTabIndex.ToString() == "2")
            {
                string mes = tabControl2.SelectedIndex.ToString();
                switch (mes)
                {
                    case "0": XuatReportTab0(); break;
                    case "1": XuatReportTab1(); break;
                    case "2": XuatReportTab2(); break;
                    case "3": XuatReportTab3(); break;
                }
            }
        }
    }
}