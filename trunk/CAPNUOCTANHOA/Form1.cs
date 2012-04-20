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

namespace CAPNUOCTANHOA
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1).Name);
        public Form1()
        {
            InitializeComponent();

            
           

            //DataSet ds = new DataSet();
            //CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            //db.Connection.Open();
            //string query = "select *,'" + "TB01" + "' as 'TENTODS',N'" + "Nguyễn Văn Tài" + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where DHN_SOBANGKE='44'";

            //SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "V_DHN_BANGKE");

            //query = "select * FROM TB_DHN_BAOCAO";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_DHN_BAOCAO");

            ////string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoiduyet + "'";
            ////SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            ////ct.Fill(ds, "USERS");

            ////string bc = "SELECT * FROM KH_TC_BAOCAO ";
            ////ct = new SqlDataAdapter(bc, db.Connection.ConnectionString);
            ////ct.Fill(ds, "KH_TC_BAOCAO");

            //rp.SetDataSource(ds);
           // crystalReportViewer1.ReportSource = rp;
            //DateTime date = DateTime.Now.Date;
            //label1.Text = date.AddYears(-5).ToShortDateString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile2"].ConnectionString;

            List<TB_DULIEUKHACHHANG> list = DAL.DULIEUKH.C_DuLieuKhachHang.getAllKHACHHANG();
            foreach (var item in list)
            {
               // string insert = "UPDATE HANDHELD SET HODONG='" + item.HOPDONG + "', TENKH='" + item.HOTEN + "', SONHA='" + item.SONHA + "',TENDUONG='" + item.TENDUONG + "',PHUONG='" + item.PHUONG + "',QUAN='" + item.QUAN + "' WHERE DANHBO='" + item.DANHBO + "' ";
                log.Info(item.DANHBO + "");
                DAL.OledbConnection.ExecuteCommand(connectionString, item.HOPDONG, item.HOTEN, item.SONHA, item.TENDUONG, item.PHUONG, item.QUAN, item.DANHBO);
              }
        }
    }
}
