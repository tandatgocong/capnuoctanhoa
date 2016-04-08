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
            cbDotDS.SelectedIndex = 1;
        }

        public DataSet getTheoDoiBienDocChiSo(int dot, int ky, int nam, string code)
        {
            DataSet ds = new DataSet();
            try
            {
              
                CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
                db.Connection.Open();

                string query = "SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.HIEUDH, kh.CODH, convert(varchar(20),YEAR(kh.NGAYTHAY)) AS 'NAM', nv.NAME, ds.GhiChuDS as  GHICHUVANPHONG ";
                query += " FROM  DocSoTH.dbo.DocSo ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv ";
                query += " WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS ";
                query += " AND ds.CodeMoi LIKE '" + code + "%' AND ds.KY=" + ky;
                if (dot != 0)
                {
                    query += " AND ds.DOT=" + dot;
                }
                query += " ORDER BY  kh.LOTRINH ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
                adapter.Fill(ds, "TB_DSCODE");
            }
            catch (Exception ez)
            {
                log.Error(ez.Message);
            
            }
           
            return ds;
        }

        public DataSet getTheoDoiBienDocChiSo_LNCC(int dot, int ky, int nam, string code,string lncc)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            string query = "SELECT kh.LOTRINH, kh.DANHBO, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.HIEUDH, kh.CODH, convert(varchar(20),YEAR(kh.NGAYTHAY)) AS 'NAM', nv.NAME, ds.GhiChuDS as  GHICHUVANPHONG ";
            query += " FROM  DocSoTH.dbo.DocSo ds , TB_DULIEUKHACHHANG kh, TB_NHANVIENDOCSO nv ";
            query += " WHERE ds.DANHBA = kh.DANHBO AND CONVERT(int,SUBSTRING(kh.LOTRINH,3,2))= nv.MAYDS ";
            query += " AND ds.CodeMoi LIKE '" + code + "%' AND ds.TieuThuMoi='" + lncc + "' AND ds.KY=" + ky;
            if (dot != 0)
            {
                query += " AND ds.DOT=" + dot;
            }
            query += " ORDER BY kh.LOTRINH ASC";
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
            string lncc = this.txtTieuThu.Text.Replace(" ", "");
            ReportDocument rp = new rpt_DanhSachByCode();

            if ("".Equals(this.txtTieuThu.Text.Replace(" ", "")))
            {
                string title_ = "DANH SÁCH ĐỒNG HỒ CODE " + code + "   KỲ " + ky;
                if (dot != 0)
                {
                    title_ = "DANH SÁCH ĐỒNG HỒ CODE " + code + "   ĐỢT " + dot + "   KỲ " + ky;
                }
                rp.SetDataSource(getTheoDoiBienDocChiSo(dot, ky, nam, code));
                rp.SetParameterValue("title", title_);
                crystalReportViewer1.ReportSource = rp;
            }
            else {
                string title_ = "DANH SÁCH ĐỒNG HỒ CODE " + code + " TIÊU THỤ =" + this.txtTieuThu.Text + "M3  KỲ " + ky;
                if (dot != 0)
                {
                    title_ = "DANH SÁCH ĐỒNG HỒ CODE " + code + " TIÊU THỤ =" + this.txtTieuThu.Text + "M3 ĐỢT " + dot + "   KỲ " + ky;
                }
                rp.SetDataSource(getTheoDoiBienDocChiSo_LNCC(dot, ky, nam, code,lncc));
                rp.SetParameterValue("title", title_);
                crystalReportViewer1.ReportSource = rp;
            
            }
            
        }
    }
}