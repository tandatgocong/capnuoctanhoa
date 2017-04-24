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
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Data.SqlClient;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class AA_tab_ThongKeDHN : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AA_tab_ThongKeDHN).Name);
        public AA_tab_ThongKeDHN()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            DataTable tb = DAL.LinQConnection.getDataTable("select  DANHBO,HIEUDH,CODH from TB_DULIEUKHACHHANG where LEFT(replace(HIEUDH,' ',''),3) not in (select HIEUDH from TB_HIEUDONGHO) ");

            tb.Merge(DAL.LinQConnection.getDataTable("select  DANHBO,HIEUDH,CODH from TB_DULIEUKHACHHANG  where CODH is null or CODH ='' or CODH<15"));

            dataGridView1.DataSource = tb;
            if (tb.Rows.Count <= 0)
                dataGridView1.Visible = false;



        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            if (rdHoaDon.Checked == false)
            {

                ReportDocument rp = new rpt_ThongKeDongHoNuoc_();
                rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getThongKeDHN(ky, nam, DAL.SYS.C_USERS._toDocSo));
                rp.SetParameterValue("KY", ky);
                rp.SetParameterValue("NAM", nam);
                crystalReportViewer1.ReportSource = rp;
            }
            if (rdHoaDon.Checked == true)
            {
                ReportDocument rp = new rpt_ThongKeDongHoNuoc_();
                rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getThongKeDHN_HD(ky, nam, DAL.SYS.C_USERS._toDocSo));
                rp.SetParameterValue("KY", ky);
                rp.SetParameterValue("NAM", nam);
                crystalReportViewer1.ReportSource = rp;
            }
        }

        private void rdHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            string sql="SELECT MAX(DOT)  FROM HOADON_TH kh WHERE kh.NAM=" + txtNam.Text.Trim() + " AND kh.KY=" + ky;
            rdHoaDon.Text = "Theo Hóa Đơn ( Hiện có " + DAL.LinQConnection.ExecuteCommand(sql) + " đợt )";
        }

    }
}
