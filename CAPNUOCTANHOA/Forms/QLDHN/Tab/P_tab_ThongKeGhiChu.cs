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
    public partial class P_tab_ThongKeGhiChu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(P_tab_ThongKeGhiChu).Name);
        public P_tab_ThongKeGhiChu()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex =0;
          

        }
        
        public DataSet getTheoDoiBienDocChiSo(string ky, string nam)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT  (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else case when (TODS=3)  then 'TB01' else 'TP02' end end end) AS TODS , COUNT(*) AS TONGCONG, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='01')  then 1 else null end) AS DOT01, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='02')  then 1 else null end) AS DOT02, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='03')  then 1 else null end) AS DOT03, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='04')  then 1 else null end) AS DOT04, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='05')  then 1 else null end) AS DOT05, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='06')  then 1 else null end) AS DOT06, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='07')  then 1 else null end) AS DOT07, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='08')  then 1 else null end) AS DOT08, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='09')  then 1 else null end) AS DOT09, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='10')  then 1 else null end) AS DOT10, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='11')  then 1 else null end) AS DOT11, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='12')  then 1 else null end) AS DOT12, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='13')  then 1 else null end) AS DOT13, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='14')  then 1 else null end) AS DOT14, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='15')  then 1 else null end) AS DOT15, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='16')  then 1 else null end) AS DOT16, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='17')  then 1 else null end) AS DOT17, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='18')  then 1 else null end) AS DOT18, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='19')  then 1 else null end) AS DOT19, ";
            query += " COUNT(case when (SUBSTRING(MLT1,1,2)='20')  then 1 else null end) AS DOT20 ";
            query += " FROM [DocSoTH].[dbo].[DocSo] ";
            query += " WHERE NAM=" + nam + " AND KY=" + ky + " AND GhiChuDS LIKE N'%GIẾ%'";
            query += " GROUP BY (case when (TODS=1)  then 'TB01' else case when (TODS=2)  then 'TB02' else case when (TODS=3)  then 'TB01' else 'TP02' end end end)";
        
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "THONGKEGM");
            db.Connection.Close();
            return ds;
        }
        string title__ = "";
        public DataSet getDanhSach(string dot,string ky, string nam)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            title__ = "DANH SÁCH KHÁCH HÀNG SỬ DỤNG 2 NGUỒN NƯỚC KỲ " + ky + "/" + nam;
            DataSet ds = new DataSet();
            db.Connection.Open();
            string query = "SELECT  dh.* ";
            query += " FROM W_DH_HIEUCU dh, [DocSoTH].[dbo].[DocSo] ds";
            query += " WHERE ds.NAM="+nam+" AND ds.KY=" + ky + " AND GhiChuDS LIKE N'%GIẾ%' AND dh.DANHBO=ds.DANHBA ";
            if (!"0".Equals(dot)) {
                query += " AND ds.DOT=" + dot;
                title__ = "DANH SÁCH KHÁCH HÀNG SỬ DỤNG 2 NGUỒN NƯỚC ĐỢT "+dot+" KỲ " + ky + "/" + nam;
            }
            query += " ORDER BY LOTRINH ASC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "W_DH_HIEUCU");
            return ds;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string dot = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
            string nam = this.txtNam.Text;
            ReportDocument rp = new rpt_ThongKeKH2NguonNuoc();

            string title_ = "THỐNG KÊ KHÁCH HÀNG SỬ DỤNG 2 NGUỒN NƯỚC KỲ " + ky + "/" + nam;

            rp.SetDataSource(getTheoDoiBienDocChiSo(ky,nam));
            rp.SetParameterValue("title_", title_);
            crystalReportViewer1.ReportSource = rp;

            rp = new rpt_DongHoHieuCu();
            
            rp.SetDataSource(getDanhSach(dot,ky, nam));
            rp.SetParameterValue("NAM", nam);
            rp.SetParameterValue("title", title__);
            crystalReportViewer2.ReportSource = rp;



        }

    }
}
