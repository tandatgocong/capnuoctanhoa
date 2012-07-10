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
    public partial class J_tab_DanhSachCodeK : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(J_tab_DanhSachCodeK).Name);
        public J_tab_DanhSachCodeK()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbCode.DataSource = DAL.LinQConnection.getDataTable("SELECT CODE FROM TB_CODE");
            cbCode.DisplayMember = "CODE";
            cbCode.ValueMember = "CODE";

        }

        public DataSet getTheoDoiBienDocChiSo(int dot, int ky, int nam, string code)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.HIEUDH, kh.CODH, YEAR(kh.NGAYTHAY) AS NAM, nv.NAME ";
            query += " FROM  DocSo_PHT.dbo.DS"+nam+" ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv ";
            query += " WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS ";
            query += " AND ds.CODE LIKE '"+code+"%' AND ds.KY="+ky;
            if (dot != 0) {
                query += " AND ds.DOT=" + dot;
            }
            query += " ORDER BY  nv.NAME ASC,kh.LOTRINH ASC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DSCODE");
            return ds;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            string code = cbCode.SelectedValue.ToString();
            
            ReportDocument rp = new rpt_KetQuaBienChiSo();
           

            rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getTheoDoiBienDocChiSo());
            rp.SetParameterValue("title", title);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}