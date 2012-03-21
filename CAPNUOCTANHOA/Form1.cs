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

namespace CAPNUOCTANHOA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReportDocument rp = new rpt_BCBangKe_A4();
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select *,'" + "TB01" + "' as 'TENTODS',N'" + "Nguyễn Văn Tài" + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where DHN_SOBANGKE='44'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_DHN_BANGKE");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            //string user = "SELECT USERNAME, UPPER(FULLNAME) AS 'FULLNAME' FROM USERS WHERE USERNAME='" + nguoiduyet + "'";
            //SqlDataAdapter ct = new SqlDataAdapter(user, db.Connection.ConnectionString);
            //ct.Fill(ds, "USERS");

            //string bc = "SELECT * FROM KH_TC_BAOCAO ";
            //ct = new SqlDataAdapter(bc, db.Connection.ConnectionString);
            //ct.Fill(ds, "KH_TC_BAOCAO");

            rp.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
