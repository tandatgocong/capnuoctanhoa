using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using System.Configuration;
using log4net;
using CAPNUOCTANHOA.Forms.QLDHN;
using CAPNUOCTANHOA.Forms.TimKiem;

namespace CAPNUOCTANHOA
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1).Name);
        public Form1()
        {
            InitializeComponent();

            //// MessageBox.Show(this, );
            // //panel1.Controls.Add(new frm_LayDuLieuGanMoi_Ky());


            
            // CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            // db.Connection.Open();
            // string query = "SELECT * FROM TB_THONGKEDHN WHERE HIEUCU='False'";

            // SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            // adapter.Fill(ds, "TB_THONGKEDHN");


            // query = "SELECT * FROM TB_THONGKEDHN  WHERE HIEUCU='True'";
            // adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            // adapter.Fill(ds, "TB_THONGKEDHN_CU");

            // query = "SELECT SUM(CO15) AS SUM_CO15, SUM(CO20) AS SUM_CO20, SUM(CO25) AS SUM_CO25, SUM(CO40) AS SUM_CO40, SUM(CO50) AS SUM_CO50, SUM(CO80) AS SUM_CO80, SUM(CO100) AS SUM_CO100, SUM(CO150) AS SUM_CO150, SUM(CO200) AS SUM_CO200, SUM(NHOCO15) AS SUM_NHOCO15, SUM(NHOCO20) AS SUM_NHOCO20, SUM(NHOCO25) AS SUM_NHOCO25, SUM(NHOCO40) AS SUM_NHOCO40, SUM(NHOCO50) AS SUM_NHOCO50, SUM(NHOCO80) AS SUM_NHOCO80, SUM(NHOCO100) AS SUM_NHOCO100, SUM(NHOCO150) AS SUM_NHOCO150, SUM(NHOCO200) AS SUM_NHOCO200, SUM(LONCO15) AS SUM_LONCO15, SUM(LONCO20) AS SUM_LONCO20, SUM(LONCO25) AS SUM_LONCO25, SUM(LONCO40) AS SUM_LONCO40, SUM(LONCO50) AS SUM_LONCO50, SUM(LONCO80) AS SUM_LONCO80, SUM(LONCO100) AS SUM_LONCO100, SUM(LONCO150) AS SUM_LONCO150, SUM(LONCO200) AS SUM_LONCO200 FROM TB_THONGKEDHN";
            // adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            // adapter.Fill(ds, "TB_THONGKEDHN_SUM");



            ////string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoiduyet + "'";
            ////SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ////ct.Fill(ds, "USERS");

            ////string bc = "SELECT * FROM KH_TC_BAOCAO ";
            ////ct = new SqlDataAdapter(bc, db.Connection.ConnectionString);
            ////ct.Fill(ds, "KH_TC_BAOCAO");

            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable("TIEUTHU");
            //dt = showCustomInformationDetail("13132164598", 2012);
            //ds.Tables.Add(dt);            
            ReportDocument rp = new rpt_INTHUMOI();            
            //DataTable tabl = ds.Tables.Add("TIEUTHU");
            //tabl = showCustomInformationDetail("13132164598", 2012);
            rp.SetDataSource(getData());
        
            //rp.SetParameterValue("KY",4);
            //rp.SetParameterValue("NAM",2012);
           // rp.PrintToPrinter(1, false, 0, 0);
            crystalReportViewer1.ReportSource = rp;
            //  dataGridView1.DataSource = showCustomInformationDetail("13132164598",2012);

        }
        private DataSet getData()
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();

           string query = "select * FROM W_THUMOI_";
           SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
       
            adapter.Fill(ds, "W_THUMOI_");
            return ds;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile2"].ConnectionString;

            //List<TB_DULIEUKHACHHANG> list = DAL.DULIEUKH.C_DuLieuKhachHang.getAllKHACHHANG();
            //foreach (var item in list)
            //{
            //   // string insert = "UPDATE HANDHELD SET HODONG='" + item.HOPDONG + "', TENKH='" + item.HOTEN + "', SONHA='" + item.SONHA + "',TENDUONG='" + item.TENDUONG + "',PHUONG='" + item.PHUONG + "',QUAN='" + item.QUAN + "' WHERE DANHBO='" + item.DANHBO + "' ";
            //    log.Info(item.DANHBO + "");
            //    DAL.OledbConnection.ExecuteCommand(connectionString, item.HOPDONG, item.HOTEN, item.SONHA, item.TENDUONG, item.PHUONG, item.QUAN, item.DANHBO);
            //  }
        }
    }
}