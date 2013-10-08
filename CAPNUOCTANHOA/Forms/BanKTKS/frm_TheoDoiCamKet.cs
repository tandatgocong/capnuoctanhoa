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
using CAPNUOCTANHOA.Forms.BanKTKS.BC;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_TheoDoiCamKet : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_TheoDoiCamKet).Name);
        public frm_TheoDoiCamKet()
        {
            InitializeComponent();
            dateTuNgay.Value = DateTime.Now.Date.AddDays(-30);
        }

        private void frm_TheoDoiCamKet_Load(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try
            {

                string nam = this.dateDenNgay.Value.Year.ToString();
                string sql = "select ROW_NUMBER() Over (order by t.DHN_DANHBO) AS STT, t.DHN_SOBANGKE, t.DHN_DANHBO, t.HOPDONG,t.LOTRINH,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.DHN_NGAYGHINHAN,103) AS 'DHN_NGAYGHINHAN',t.DHN_KY,t.DHN_CAMKET,max (ds.KY) as 'KY',ds.TIEUTHU,t.DHN_GHICHU ";
                sql += "from DOCSO_PHT.dbo.DS" + nam + " ds inner join";
                sql += " (select ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.LOTRINH,kh.HOPDONG,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_CAMKET,ghd.DHN_GHICHU ";
                sql += " from CAPNUOCTANHOA.dbo.DK_GIAMHOADON ghd ,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh ";
                sql += " where  ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                sql += " and ghd.DHN_CAMKET is not null ";
                sql += " and ghd.DHN_HUYCAMKET is null) as t ";
                sql += " on ds.DANHBA = t.DHN_DANHBO ";
                sql += " where ds.TIEUTHU = 0 ";
                sql += " group by t.DHN_SOBANGKE ,t.DHN_DANHBO,t.LOTRINH,t.HOPDONG,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.DHN_NGAYGHINHAN,103),t.DHN_KY,t.DHN_CAMKET,ds.TIEUTHU,t.DHN_GHICHU";
                sql += " having  MAX (ds.KY) = t.DHN_KY ";

                DataTable dt = DAL.LinQConnection.getDataTable(sql);
                dataQLDHNB0.DataSource = dt;
                Utilities.DataGridV.formatRows(dataQLDHNB0);
                //string sql_docso ="Select TIEUTHU from DS2013 where TIEUTHU = 0 and KY = 4";

                //DataTable dtk = DAL.LinQConnectionDS.getDataTable(sql_docso);
                //dataQLDHNB0.DataSource = dtk;
                string sql1 = "select ROW_NUMBER() Over (order by t.DHN_DANHBO) AS STT, t.DHN_SOBANGKE, t.DHN_DANHBO, t.HOPDONG,t.LOTRINH,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.DHN_NGAYGHINHAN,103) AS 'DHN_NGAYGHINHAN',t.DHN_KY,t.DHN_CAMKET,max (ds.KY) as 'KY',ds.TIEUTHU,t.DHN_GHICHU ";
                sql1 += "from DOCSO_PHT.dbo.DS" + nam + " ds inner join";
                sql1 += " (select ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.LOTRINH,kh.HOPDONG,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_CAMKET,ghd.DHN_GHICHU ";
                sql1 += " from CAPNUOCTANHOA.dbo.DK_GIAMHOADON ghd ,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh ";
                sql1 += " where  ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                sql1 += " and ghd.DHN_CAMKET is not null ";
                sql1 += " and ghd.DHN_HUYCAMKET is null) as t ";
                sql1 += " on ds.DANHBA = t.DHN_DANHBO ";
                sql1 += " where ds.KY = (select MAX (ds1.KY) from DOCSO_PHT.dbo.DS" + nam + " ds1 ) ";
                sql1 += " group by t.DHN_SOBANGKE ,t.DHN_DANHBO,t.LOTRINH,t.HOPDONG,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.DHN_NGAYGHINHAN,103),t.DHN_KY,t.DHN_CAMKET,ds.TIEUTHU,t.DHN_GHICHU";
                sql1 += " having ds.TIEUTHU <> 0 ";

                DataTable dt1 = DAL.LinQConnection.getDataTable(sql1);
                dataQLDHNK0.DataSource = dt1;
                Utilities.DataGridV.formatRows(dataQLDHNK0);

                string sql2 = "select ROW_NUMBER() Over (order by t.DHN_DANHBO) AS STT, t.DHN_SOBANGKE, t.DHN_DANHBO, t.HOPDONG,t.LOTRINH,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.KTKS_NGAYTIEPXUC,103) AS 'KTKS_NGAYTIEPXUC',t.DHN_KY,t.KTKS_CAMKET,max (ds.KY) as 'KY',ds.TIEUTHU,t.KTKS_GHICHU ";
                sql2 += "from DOCSO_PHT.dbo.DS" + nam + " ds inner join";
                sql2 += " (select ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.LOTRINH,kh.HOPDONG,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.KTKS_NGAYTIEPXUC,ghd.DHN_KY,ghd.KTKS_CAMKET,ghd.KTKS_GHICHU ";
                sql2 += " from CAPNUOCTANHOA.dbo.DK_GIAMHOADON ghd ,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh ";
                sql2 += " where  ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.KTKS_NGAYTIEPXUC) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                sql2 += " and ghd.KTKS_CAMKET is not null ";
                sql2 += " ) as t ";
                sql2 += " on ds.DANHBA = t.DHN_DANHBO ";
                sql2 += " where ds.KY = (select MAX (ds1.KY) from DOCSO_PHT.dbo.DS" + nam + " ds1 ) ";
                sql2 += " group by t.DHN_SOBANGKE ,t.DHN_DANHBO,t.LOTRINH,t.HOPDONG,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.KTKS_NGAYTIEPXUC,103),t.DHN_KY,t.KTKS_CAMKET,ds.TIEUTHU,t.KTKS_GHICHU";
                sql2 += " having ds.TIEUTHU = 0 order by t.LOTRINH ASC";

                DataTable dt2 = DAL.LinQConnection.getDataTable(sql2);
                dataKTKSB0.DataSource = dt2;
                Utilities.DataGridV.formatRows(dataKTKSB0);

                string sql3 = "select ROW_NUMBER() Over (order by t.DHN_DANHBO) AS STT, t.DHN_SOBANGKE, t.DHN_DANHBO,t.HOPDONG,t.LOTRINH,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.KTKS_NGAYTIEPXUC,103) AS 'KTKS_NGAYTIEPXUC',t.DHN_KY,t.KTKS_CAMKET,max (ds.KY) as 'KY',ds.TIEUTHU,t.KTKS_GHICHU ";
                sql3 += "from DOCSO_PHT.dbo.DS" + nam + " ds inner join";
                sql3 += " (select ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.LOTRINH,kh.HOPDONG,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.KTKS_NGAYTIEPXUC,ghd.DHN_KY,ghd.KTKS_CAMKET,ghd.KTKS_GHICHU ";
                sql3 += " from CAPNUOCTANHOA.dbo.DK_GIAMHOADON ghd ,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh ";
                sql3 += " where  ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.KTKS_NGAYTIEPXUC) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                sql3 += " and ghd.KTKS_CAMKET is not null ";
                sql3 += " ) as t ";
                sql3 += " on ds.DANHBA = t.DHN_DANHBO ";
                sql3 += " where ds.KY = (select MAX (ds1.KY) from DOCSO_PHT.dbo.DS" + nam + " ds1 ) ";
                sql3 += " group by t.DHN_SOBANGKE ,t.DHN_DANHBO,t.LOTRINH,t.HOPDONG,t.HOTEN,t.DIACHI,CONVERT(VARCHAR(20),t.KTKS_NGAYTIEPXUC,103),t.DHN_KY,t.KTKS_CAMKET,ds.TIEUTHU,t.KTKS_GHICHU";
                sql3 += " having ds.TIEUTHU <> 0 order by t.LOTRINH ASC";

                DataTable dt3 = DAL.LinQConnection.getDataTable(sql3);
                dataKTKSK0.DataSource = dt3;
                Utilities.DataGridV.formatRows(dataKTKSK0);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataQLDHNB0_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabKTKSBANG0_Click(object sender, EventArgs e)
        {

        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            ReportDocument rptqldhnck = new rpt_QLDHNCamKetSD_0();
            ReportDocument rptqldhnck_k0 = new rpt_QLDHNCamKet_K0();
            ReportDocument rptktksck = new rpt_KTKSCamKet_0();
            ReportDocument rptktksck_k0 = new rpt_KTKSCamKet_K0();
            DataTable dt = new DataTable();

            TheoDoiCamKet ds = new TheoDoiCamKet();
            if (tabControl1.SelectedIndex == 0)
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    dt = (DataTable)dataQLDHNB0.DataSource;
                    string ss = dt.Rows[0]["DHN_SOBANGKE"].GetType().ToString();
                    dt.TableName = "QLDHNCAMKET0";

                    ds.Tables["QLDHNCAMKET0"].Merge(dt);
                    //set dataset to the report viewer.
                    rptqldhnck.SetDataSource(ds);
                    rptqldhnck.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                    rptqldhnck.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));

                    frm_Reports frm = new frm_Reports(rptqldhnck);
                    frm.Show();
                }
                else
                {
                    dt = (DataTable)dataQLDHNK0.DataSource;
                    string ss = dt.Rows[0]["DHN_SOBANGKE"].GetType().ToString();
                    dt.TableName = "QLDHNCAMKETK0";

                    ds.Tables["QLDHNCAMKETK0"].Merge(dt);
                    //set dataset to the report viewer.
                    rptqldhnck_k0.SetDataSource(ds);
                    rptqldhnck_k0.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                    rptqldhnck_k0.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));

                    frm_Reports frm = new frm_Reports(rptqldhnck_k0);
                    frm.Show();
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                if (tab.SelectedIndex == 0)
                {
                    dt = (DataTable)dataKTKSB0.DataSource;
                    string ss = dt.Rows[0]["DHN_SOBANGKE"].GetType().ToString();
                    dt.TableName = "KTKSCAMKET0";

                    ds.Tables["KTKSCAMKET0"].Merge(dt);
                    //set dataset to the report viewer.
                    rptktksck.SetDataSource(ds);
                    rptktksck.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                    rptktksck.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));

                    frm_Reports frm = new frm_Reports(rptktksck);
                    frm.Show();
                }
                else
                {
                    dt = (DataTable)dataKTKSK0.DataSource;
                    string ss = dt.Rows[0]["DHN_SOBANGKE"].GetType().ToString();
                    dt.TableName = "KTKSCAMKETK0";

                    ds.Tables["KTKSCAMKETK0"].Merge(dt);
                    //set dataset to the report viewer.
                    rptktksck_k0.SetDataSource(ds);
                    rptktksck_k0.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                    rptktksck_k0.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));

                    frm_Reports frm = new frm_Reports(rptktksck_k0);
                    frm.Show();
                }
            }
        }
    }
}
