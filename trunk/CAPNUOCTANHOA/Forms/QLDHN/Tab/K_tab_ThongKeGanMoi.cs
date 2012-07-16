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
using CAPNUOCTANHOA.Forms.QLDHN.Tab.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class K_tab_ThongKeGanMoi : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(I_tab_BangChamCong).Name);
        public K_tab_ThongKeGanMoi()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month;

        }

        public DataSet getTheoDoiBienDocChiSo(string tongds)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT TODS,COUNT(*) AS TONGCONG, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='01')  then 1 else null end) AS DOT01, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='02')  then 1 else null end) AS DOT02, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='03')  then 1 else null end) AS DOT03, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='04')  then 1 else null end) AS DOT04, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='05')  then 1 else null end) AS DOT05, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='06')  then 1 else null end) AS DOT06, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='07')  then 1 else null end) AS DOT07, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='08')  then 1 else null end) AS DOT08, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='09')  then 1 else null end) AS DOT09, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='10')  then 1 else null end) AS DOT10, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='11')  then 1 else null end) AS DOT11, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='12')  then 1 else null end) AS DOT12, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='13')  then 1 else null end) AS DOT13, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='14')  then 1 else null end) AS DOT14, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='15')  then 1 else null end) AS DOT15, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='16')  then 1 else null end) AS DOT16, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='17')  then 1 else null end) AS DOT17, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='18')  then 1 else null end) AS DOT18, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='19')  then 1 else null end) AS DOT19, ";
            query += " COUNT(case when (SUBSTRING(PLT,1,2)='20')  then 1 else null end) AS DOT20 ";
            query += " FROM TB_GANMOI ";
            query += " WHERE HIEULUC='" + tongds + "' ";
            query += " GROUP BY TODS ";
            query += " ORDER BY TODS ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "THONGKEGM");
            return ds;
        }

        public DataSet getTheoDoiBienDocChiSo(int Ky, int nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "select LEFT(LOTRINH,4) as LT, COUNT(*) as SOLUONG from dbo.TB_DULIEUKHACHHANG ";
            query += " WHERE KY=" + Ky + " AND NAM=" + nam;
            query += " AND SUBSTRING(LOTRINH,3,2) IN ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15')";
            query += " GROUP BY LEFT(LOTRINH,4)";
            query += " ORDER BY LEFT(LOTRINH,4) ASC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TANBINH01");


            query = "select LEFT(LOTRINH,4) as LT, COUNT(*) as SOLUONG from dbo.TB_DULIEUKHACHHANG ";
            query += " WHERE KY=" + Ky + " AND NAM=" + nam;
            query += " AND SUBSTRING(LOTRINH,3,2) IN ('16','17','18','19','20','21','22','23','24','25','26','27','28','29','30')";
            query += " GROUP BY LEFT(LOTRINH,4)";
            query += " ORDER BY LEFT(LOTRINH,4) ASC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TANBINH02");


            query = "select LEFT(LOTRINH,4) as LT, COUNT(*) as SOLUONG from dbo.TB_DULIEUKHACHHANG ";
            query += " WHERE KY=" + Ky + " AND NAM=" + nam;
            query += " AND SUBSTRING(LOTRINH,3,2) IN ('31','32','33','34','35','36','37','38','39','40','41','42','43','44','45','46')";
            query += " GROUP BY LEFT(LOTRINH,4)";
            query += " ORDER BY LEFT(LOTRINH,4) ASC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TANPHU");

            return ds;
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            ReportDocument rp = new rpt_ThongKeGanMoi();

            string title_ = "THỐNG KÊ ĐHN GẮN MỚI KỲ " + ky + "/" + nam;

            rp.SetDataSource(getTheoDoiBienDocChiSo(ky + "/" + nam));
            rp.SetParameterValue("title_", title_);

            crystalReportViewer1.ReportSource = rp;

            //--------

            ReportDocument rp1 = new rpt_ChiTietLoTrinhGM();

            title_ = "MÃ SỔ IN GẮN MỚI KỲ " + ky + "/" + nam;

            rp1.SetDataSource(getTheoDoiBienDocChiSo(int.Parse(ky), int.Parse(nam)));
            rp1.SetParameterValue("TITLE", title_);

            crystalReportViewer2.ReportSource = rp1;
        }
    }
}