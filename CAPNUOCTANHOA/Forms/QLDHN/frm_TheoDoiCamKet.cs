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
using CAPNUOCTANHOA.Forms.QLDHN.BC;
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
            try {
                string sql = "SELECT ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_DOT,ghd.DHN_TODS,ghd.DHN_CAMKET,ghd.DHN_GHICHU";
                    sql += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh";
                    sql += " WHERE ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) and ghd.DHN_CAMKET is not null and ghd.DHN_HUYCAMKET is null ";
                   
                    DataTable dt = DAL.LinQConnection.getDataTable(sql);
                    dataQLDHNB0.DataSource = dt;
                    Utilities.DataGridV.formatRows(dataQLDHNB0);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string danhbo = dt.Rows[i]["DHN_DANHBO"].ToString();

                    }
                    string sql1 = "SELECT ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_DOT,ghd.DHN_TODS,ghd.DHN_CAMKET,ghd.DHN_GHICHU";
                    sql1 += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh";
                    sql1 += " WHERE ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) and ghd.DHN_CAMKET is not null and ghd.DHN_HUYCAMKET is null ";

                    DataTable dt1 = DAL.LinQConnection.getDataTable(sql1);
                    dataQLDHNK0.DataSource = dt1;
                    Utilities.DataGridV.formatRows(dataQLDHNK0);

                    string sql2 = "SELECT ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.HOTEN,(kh.SONHA + kh.TENDUONG) as DIACHI,ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_DOT,ghd.DHN_TODS,ghd.KTKS_CAMKET,ghd.KTKS_GHICHU";
                    sql2 += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh";
                    sql2 += " WHERE ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) and ghd.KTKS_CAMKET is not null ";

                    DataTable dt2 = DAL.LinQConnection.getDataTable(sql2);
                    dataKTKSB0.DataSource = dt2;
                    Utilities.DataGridV.formatRows(dataKTKSB0);

                    string sql3 = "SELECT ghd.DHN_SOBANGKE, ghd.DHN_DANHBO,kh.HOTEN,(kh.SONHA+kh.TENDUONG) AS DIACHI, ghd.DHN_NGAYGHINHAN,ghd.DHN_KY,ghd.DHN_DOT,ghd.DHN_TODS,ghd.KTKS_CAMKET,ghd.KTKS_GHICHU";
                    sql3 += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG KH";
                    sql3 += " WHERE ghd.DHN_DANHBO = kh.DANHBO and CONVERT(DATETIME,ghd.DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) and ghd.KTKS_CAMKET is not null ";

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
    }
}
