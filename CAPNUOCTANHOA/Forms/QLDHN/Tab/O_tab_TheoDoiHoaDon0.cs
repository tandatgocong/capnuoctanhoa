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
namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class O_tab_TheoDoiHoaDon0 : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(O_tab_TheoDoiHoaDon0).Name);
        public O_tab_TheoDoiHoaDon0()
        {
            InitializeComponent();
            dateTuNgay.Value = DateTime.Now.Date.AddDays(-30);
        }

        private void O_tab_TheoDoiHoaDon0_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataTongKet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridLoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridChuaThay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataTongKet_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        string sql = "";
        string sql1 = "";
        public static void formatRowsSTT(DataGridView dview, string STT)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {

            }
        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            try { 
                
                if (tabItem2.IsSelected == true)
                {
                  
                    sql1 = "SELECT ghd.DHN_SOBANGKE AS 'TENBK',ghd.DHN_NGAYGHINHAN,ghd.KTKS_NGAYTIEPXUC, COUNT (ghd.DHN_DANHBO) AS 'SOLUONG' ";
                    sql1 += ",COUNT (case when ghd.DHN_CAMKET = 'X' or ghd.DHN_CAMKET='x' then 1 end) AS 'DHN_CAMKET'";
                    sql1 += ",COUNT(case when ghd.DHN_BAMHI='X' or ghd.DHN_BAMHI='x' then 1 end) AS 'DHN_BAMHI'";
                    sql1 += ",COUNT(case when ghd.DHN_HUYCAMKET='X' or ghd.DHN_HUYCAMKET='x' then 1 end) AS 'DHN_HUYCAMKET'";
                    sql1 += ",COUNT (ghd.KTKS_CAMKET) AS 'KTKS_CAMKET'";
                    sql1 += ",COUNT (ghd.KTKS_BAMHI) AS 'KTKS_BAMHI'";
                    sql1 += ",COUNT (case when ghd.KTKS_BAMHI = 'thuhoi' then 1 end) as 'KTKS_BAMHITH'";
                    sql1 += ",COUNT (case when ghd.KTKS_BAMHI = 'khoanuoc' then 1 end) as 'KTKS_BAMHIKN'";
                    sql1 += ",COUNT (ghd.DHN_CHUADANHDAU) AS 'DHN_CHUADANHDAU'";
                    sql1 += ",(COUNT (ghd.KTKS_CAMKET) + COUNT (ghd.KTKS_BAMHI)) AS 'KTKS_SOLUONGDHNDI' ";
                    sql1 += "FROM DK_GIAMHOADON ghd";
                    sql1 += " WHERE  CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
                    sql1 += "GROUP BY ghd.DHN_SOBANGKE,ghd.KTKS_BAMHI,ghd.DHN_NGAYGHINHAN,ghd.KTKS_NGAYTIEPXUC";


                    string sql_camket = "SELECT ghd.DHN_SOBANGKE,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_CAMKET,ghd.DHN_GHICHU";
                    sql_camket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_camket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_CAMKET <>'' or ghd.DHN_CAMKET is not null )  AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103)ORDER BY DHN_DANHBO ASC";

                    string sql_bamchi = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_BAMHI,ghd.DHN_GHICHU";
                    sql_bamchi += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_bamchi += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_BAMHI <>'' or ghd.DHN_BAMHI is not null )  AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103)ORDER BY DHN_DANHBO ASC";

                    string sql_huycamket = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_HUYCAMKET,ghd.DHN_GHICHU";
                    sql_huycamket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_huycamket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_HUYCAMKET <>'' or ghd.DHN_HUYCAMKET is not null )  AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103)ORDER BY DHN_DANHBO ASC";

                    string sql_ktkscamket = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.KTKS_NGAYTIEPXUC,ghd.KTKS_CAMKET,ghd.DHN_GHICHU";
                    sql_ktkscamket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_ktkscamket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.KTKS_CAMKET <>'' or ghd.KTKS_CAMKET is not null )  AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103)ORDER BY DHN_DANHBO ASC";


                    string sql_ktksbamchi = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.KTKS_BAMHI,ghd.KTKS_NGAYTIEPXUC,ghd.KTKS_NGAYBAMCHI,ghd.KTKS_MAKIEMBC,ghd.KTKS_TH_MAKIEM,ghd.DHN_GHICHU";
                    sql_ktksbamchi += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_ktksbamchi += "WHERE ghd.DHN_DANHBO = kh.DANHBO AND (ghd.KTKS_BAMHI <>'' or ghd.KTKS_BAMHI is not null )   AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103)ORDER BY DHN_DANHBO ASC";

                    string sql_chuadanhdau = "SELECT ghd.DHN_SOBANGKE ,kh.HOTEN,ghd.DHN_DANHBO,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_CHUADANHDAU,ghd.DHN_GHICHU";
                    sql_chuadanhdau += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_chuadanhdau += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_CHUADANHDAU <>'' or ghd.DHN_CHUADANHDAU is not null )  AND CONVERT(DATETIME,DHN_NGAYGHINHAN) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ORDER BY DHN_DANHBO ASC";

                    DataTable dt = DAL.LinQConnection.getDataTable(sql1);
                    dataGridView1.DataSource = dt;
                    Utilities.DataGridV.formatRows(dataGridView1);
                    DataTable dt1 = DAL.LinQConnection.getDataTable(sql_camket);
                    dgv_CamKet.DataSource = dt1;
                    Utilities.DataGridV.formatRows(dgv_CamKet, "");
                    Utilities.DataGridV.setSTT(dgv_CamKet, "STT");
                  // Utilities.DataGridV.formatRowsSTT(dgv_CamKet, "", "STT");
       
                    DataTable dt2 = DAL.LinQConnection.getDataTable(sql_bamchi);
                    dgv_BamChi.DataSource = dt2;
                    Utilities.DataGridV.formatRowsSTT(dgv_BamChi, "", "G_STT");
                    DataTable dt3 = DAL.LinQConnection.getDataTable(sql_huycamket);
                    dgv_HuyCamKet.DataSource = dt3;
                    Utilities.DataGridV.formatRowsSTT(dgv_HuyCamKet, "", "STTH");
                    DataTable dt4 = DAL.LinQConnection.getDataTable(sql_ktkscamket);
                    dgv_KTKSCamKet.DataSource = dt4;
                    Utilities.DataGridV.formatRowsSTT(dgv_KTKSCamKet, "", "STTKTC");
                    DataTable dt5 = DAL.LinQConnection.getDataTable(sql_ktksbamchi);
                    dgvKTKSBamChi.DataSource = dt5;
                    Utilities.DataGridV.formatRowsSTT(dgvKTKSBamChi, "", "STTKTB");
                    DataTable dt6 = DAL.LinQConnection.getDataTable(sql_chuadanhdau);
                    dgv_DHNVangChuNha.DataSource = dt6;
                    Utilities.DataGridV.formatRowsSTT(dgv_DHNVangChuNha, "", "STTV");

                    var result = from row in dt.AsEnumerable() group row by row.Field<string>("TENBK") into grp select grp.Count();
                    int count = result.Count();
                    var sum = dt.AsEnumerable().Sum(x => x.Field<int>("SOLUONG"));
                    var sum_dhncamket = dt.AsEnumerable().Where(y=>y.Field<int>("DHN_HUYCAMKET")==0).Sum(x => x.Field<int>("DHN_CAMKET"));
                    var sum_dhnbamchi = dt.AsEnumerable().Where(y => y.Field <int>("DHN_HUYCAMKET")==0).Sum(x => x.Field<int>("DHN_BAMHI"));
                    var sum_dhnhuycamket = dt.AsEnumerable().Sum(x=> x.Field <int>("DHN_HUYCAMKET"));
                    var sum_chuadanhdau = dt.AsEnumerable().Sum(x => x.Field<int>("DHN_CHUADANHDAU"));
                    var sum_bamchi = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHI"));
                    var sum_bamchithuhoi = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHITH"));
                    var sum_bamchikhoanuoc = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHIKN"));
                    var sum_camket = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_CAMKET"));
                    int sum_DI = int.Parse(sum_bamchi.ToString()) + int.Parse(sum_camket.ToString());
                    dataTongKet.Rows.Insert(0);
                    dataTongKet.Rows[0].Cells["TONG"].Value = count.ToString();
                    dataTongKet.Rows[0].Cells["SOLUONGDHN"].Value = sum.ToString();
                    dataTongKet.Rows[0].Cells["DHN_CAMKET"].Value = sum_dhncamket.ToString();
                    dataTongKet.Rows[0].Cells["DHN_BAMHI"].Value = sum_dhnbamchi.ToString();
                    dataTongKet.Rows[0].Cells["DHN_HUYCAMKET"].Value = sum_dhnhuycamket.ToString();
                    dataTongKet.Rows[0].Cells["DHN_CHUADANHDAUCT"].Value = sum_chuadanhdau.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_CAMKET"].Value = sum_camket.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHI"].Value = sum_bamchi.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHIT"].Value = sum_bamchithuhoi.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHIK"].Value = sum_bamchikhoanuoc.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_DI"].Value = sum_DI.ToString();
                 
                }
                else if (tabItem3.IsSelected == true)
                {
                    sql1 = "SELECT ghd.DHN_SOBANGKE AS 'TENBK',ghd.DHN_NGAYGHINHAN,ghd.KTKS_NGAYTIEPXUC, COUNT (ghd.DHN_DANHBO) AS 'SOLUONG' ";
                    sql1 += ",COUNT (case when ghd.DHN_CAMKET = 'X' or ghd.DHN_CAMKET='x' then 1 end) AS 'DHN_CAMKET'";
                    sql1 += ",COUNT(case when ghd.DHN_BAMHI='X' or ghd.DHN_BAMHI='x' then 1 end) AS 'DHN_BAMHI'";
                    sql1 += ",COUNT(case when ghd.DHN_HUYCAMKET='X' or ghd.DHN_HUYCAMKET='x' then 1 end) AS 'DHN_HUYCAMKET'";
                    sql1 += ",COUNT (ghd.DHN_CHUADANHDAU) AS 'DHN_CHUADANHDAU'";
                    sql1 += ",COUNT (ghd.KTKS_CAMKET) AS 'KTKS_CAMKET'";
                    sql1 += ",COUNT (ghd.KTKS_BAMHI) AS 'KTKS_BAMHI'";
                    sql1 += ",COUNT (case when ghd.KTKS_BAMHI = 'thuhoi' then 1 end) as 'KTKS_BAMHITH'";
                    sql1 += ",COUNT (case when ghd.KTKS_BAMHI = 'khoanuoc' then 1 end) as 'KTKS_BAMHIKN'";
                    sql1 += ",(COUNT (ghd.KTKS_CAMKET) + COUNT (ghd.KTKS_BAMHI)) AS 'KTKS_SOLUONGDHNDI' ";
                    sql1 += "FROM DK_GIAMHOADON ghd";
                    sql1 += " WHERE  ghd.DHN_SOBANGKE='" + txtSoBangKe.Text  + "'";
                    sql1 += "GROUP BY ghd.DHN_SOBANGKE,ghd.KTKS_BAMHI,ghd.DHN_NGAYGHINHAN,ghd.KTKS_NGAYTIEPXUC";

                    string sql_camket = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_CAMKET,ghd.DHN_GHICHU";
                    sql_camket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_camket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_CAMKET <>'' or ghd.DHN_CAMKET is not null )  AND ghd.DHN_SOBANGKE='" +txtSoBangKe.Text + "'ORDER BY DHN_DANHBO ASC";

                    string sql_bamchi = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_BAMHI,ghd.DHN_GHICHU";
                    sql_bamchi += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_bamchi += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_BAMHI <>'' or ghd.DHN_BAMHI is not null )  AND ghd.DHN_SOBANGKE='" + txtSoBangKe.Text  + "'ORDER BY DHN_DANHBO ASC";

                    string sql_huycamket = "SELECT ghd.DHN_SOBANGKE ,kh.HOTEN,ghd.DHN_DANHBO,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_HUYCAMKET,ghd.DHN_GHICHU";
                    sql_huycamket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_huycamket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_HUYCAMKET <>'' or ghd.DHN_HUYCAMKET is not null )  AND ghd.DHN_SOBANGKE='" + txtSoBangKe.Text  + "'ORDER BY DHN_DANHBO ASC";

                    string sql_ktkscamket = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.KTKS_NGAYTIEPXUC,ghd.KTKS_CAMKET,ghd.DHN_GHICHU";
                    sql_ktkscamket += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_ktkscamket += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.KTKS_CAMKET <>'' or ghd.KTKS_CAMKET is not null )  AND ghd.DHN_SOBANGKE='" + txtSoBangKe.Text  + "'ORDER BY DHN_DANHBO ASC";

                    string sql_ktksbamchi = "SELECT ghd.DHN_SOBANGKE ,ghd.DHN_DANHBO,kh.HOTEN,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.KTKS_BAMHI,ghd.KTKS_NGAYTIEPXUC,ghd.KTKS_NGAYBAMCHI,ghd.KTKS_MAKIEMBC,ghd.KTKS_TH_MAKIEM,ghd.DHN_GHICHU";
                    sql_ktksbamchi += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_ktksbamchi += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_CAMKET <>'' or ghd.DHN_CAMKET is not null )  AND ghd.DHN_SOBANGKE='" + txtSoBangKe.Text  + "'ORDER BY DHN_DANHBO ASC";

                    string sql_chuadanhdau = "SELECT ghd.DHN_SOBANGKE ,kh.HOTEN,ghd.DHN_DANHBO,kh.SONHA + '' +kh.TENDUONG AS 'DIACHI',ghd.DHN_NGAYGHINHAN,ghd.DHN_CHUADANHDAU,ghd.DHN_GHICHU";
                    sql_chuadanhdau += " FROM DK_GIAMHOADON ghd, TB_DULIEUKHACHHANG kh ";
                    sql_chuadanhdau += "WHERE ghd.DHN_DANHBO = kh.DANHBO and (ghd.DHN_CHUADANHDAU <>'' or ghd.DHN_CHUADANHDAU is not null )  AND ghd.DHN_SOBANGKE='" + txtSoBangKe.Text + "'ORDER BY DHN_DANHBO ASC";


                    DataTable dt = DAL.LinQConnection.getDataTable(sql1);
                    dataGridView1.DataSource = dt;
                    Utilities.DataGridV.formatRows(dataGridView1);
                    DataTable dt1 = DAL.LinQConnection.getDataTable(sql_camket);
                    dgv_CamKet.DataSource = dt1;
                    Utilities.DataGridV.formatRowsSTT(dgv_CamKet, "", "STT");
                    DataTable dt2 = DAL.LinQConnection.getDataTable(sql_bamchi);
                    dgv_BamChi.DataSource = dt2;
                    Utilities.DataGridV.formatRowsSTT(dgv_BamChi, "", "G_STT");
                    DataTable dt3 = DAL.LinQConnection.getDataTable(sql_huycamket);
                    dgv_HuyCamKet.DataSource = dt3;
                    Utilities.DataGridV.formatRowsSTT(dgv_HuyCamKet, "", "STTH");
                    DataTable dt4 = DAL.LinQConnection.getDataTable(sql_ktkscamket);
                    dgv_KTKSCamKet.DataSource = dt4;
                    Utilities.DataGridV.formatRowsSTT(dgv_KTKSCamKet, "", "STTKTC");
                    DataTable dt5 = DAL.LinQConnection.getDataTable(sql_ktksbamchi);
                    dgvKTKSBamChi.DataSource = dt5;
                    Utilities.DataGridV.formatRowsSTT(dgvKTKSBamChi, "", "STTKTB");
                    DataTable dt6 = DAL.LinQConnection.getDataTable(sql_chuadanhdau);
                    dgv_DHNVangChuNha.DataSource = dt6;
                    Utilities.DataGridV.formatRowsSTT(dgv_DHNVangChuNha, "", "STTV");

                    var result = from row in dt.AsEnumerable() group row by row.Field<string>("TENBK") into grp select grp.Count();
                    int count = result.Count();
                    var sum = dt.AsEnumerable().Sum(x => x.Field<int>("SOLUONG"));
                    var sum_dhncamket = dt.AsEnumerable().Where(y => y.Field<int>("DHN_HUYCAMKET") == 0).Sum(x => x.Field<int>("DHN_CAMKET"));
                    var sum_dhnbamchi = dt.AsEnumerable().Where(y => y.Field<int>("DHN_HUYCAMKET") == 0).Sum(x => x.Field<int>("DHN_BAMHI"));
                    var sum_dhnhuycamket = dt.AsEnumerable().Sum(x=>x.Field<int>("DHN_HUYCAMKET"));
                    var sum_chuadanhdau = dt.AsEnumerable().Sum(x => x.Field<int>("DHN_CHUADANHDAU"));
                    var sum_bamchi = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHI"));
                    var sum_bamchithuhoi = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHITH"));
                    var sum_bamchikhoanuoc = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_BAMHIKN"));
                    var sum_camket = dt.AsEnumerable().Sum(x => x.Field<int>("KTKS_CAMKET"));
                    int sum_DI = int.Parse(sum_bamchi.ToString()) + int.Parse(sum_camket.ToString());
                    dataTongKet.Rows.Insert(0);
                    dataTongKet.Rows[0].Cells["TONG"].Value = count.ToString();
                    dataTongKet.Rows[0].Cells["SOLUONGDHN"].Value = sum.ToString();
                    dataTongKet.Rows[0].Cells["DHN_CAMKET"].Value = sum_dhncamket.ToString();
                    dataTongKet.Rows[0].Cells["DHN_BAMHI"].Value = sum_dhnbamchi.ToString();
                    dataTongKet.Rows[0].Cells["DHN_HUYCAMKET"].Value = sum_dhnhuycamket.ToString();
                    dataTongKet.Rows[0].Cells["DHN_CHUADANHDAUCT"].Value = sum_chuadanhdau.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_CAMKET"].Value = sum_camket.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHI"].Value = sum_bamchi.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHIT"].Value = sum_bamchithuhoi.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_BAMHIK"].Value = sum_bamchikhoanuoc.ToString();
                    dataTongKet.Rows[0].Cells["KTKS_DI"].Value = sum_DI.ToString();
                }

               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
          
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_BamChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new  rpt_BCTheoDoiHD_0();
            ReportDocument rptDoc_bangke = new rpt_BCTheoDoiHD_0_SoBangKe();
            DataTable dt = new DataTable();
            BaoCaoHD0 ds = new BaoCaoHD0();

            dt = (DataTable)dataGridView1.DataSource;
            string type = dt.Rows[0]["DHN_CAMKET"].GetType().ToString();
            dt.TableName = "BAOCAOHD0";
            ds.Tables["BAOCAOHD0"].Merge(dt);
            //set dataset to the report viewer.
            //int i=0;
            if (tabControl1.SelectedTabIndex ==0){
rptDoc.SetDataSource(ds);
                rptDoc.SetParameterValue("TUNGAY", Utilities.DateToString.NgayVN(dateTuNgay));
                rptDoc.SetParameterValue("DENNGAY", Utilities.DateToString.NgayVN(dateDenNgay));

                frm_Reports frm = new frm_Reports(rptDoc);
                frm.Show();

            }
            else
            {
                rptDoc_bangke.SetDataSource(ds);
                rptDoc_bangke.SetParameterValue("bangke", txtSoBangKe.Text);

                frm_Reports frm = new frm_Reports(rptDoc_bangke);
                frm.Show();

            }
          
        }

        private void tabCamKet_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.setSTT(dgv_CamKet, "STT");
        
        }

        private void tabBamChi_Click(object sender, EventArgs e)
        {
         
        }
    }
}
