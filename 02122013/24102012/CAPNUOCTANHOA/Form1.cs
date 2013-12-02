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
using CAPNUOCTANHOA.LinhTinh;

namespace CAPNUOCTANHOA
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1).Name);
        public Form1()
        {
            InitializeComponent();
            cbNhanVien.DataSource = DAL.QLDHN.C_QuanLyDongHoNuoc.getTable_CHAMCONG();
            cbNhanVien.DisplayMember = "FULLNAME";
            cbNhanVien.ValueMember = "MAYDS";
            cbSoLuong.SelectedIndex = 3;
     
           
            //  dataGridView1.DataSource = showCustomInformationDetail("13132164598",2012);

        }
        public void ViewReport() {
            ReportDocument rp = new rpt_ThiDuaGiamHoaDon();
            rp.SetDataSource(getData());
            rp.SetParameterValue("TEN", cbNhanVien.Text.ToUpper());
            if (DAL.QLDHN.C_QuanLyDongHoNuoc.findbyMayDS(int.Parse(cbNhanVien.SelectedValue.ToString())).TODS == 1) {
                rp.SetParameterValue("TO", "TÂN BINH 01");
            }
            else if (DAL.QLDHN.C_QuanLyDongHoNuoc.findbyMayDS(int.Parse(cbNhanVien.SelectedValue.ToString())).TODS == 2)
            {
                rp.SetParameterValue("TO", "TÂN BINH 02");
            }
            else {
                rp.SetParameterValue("TO", "TÂN PHÚ");
            }
            
            crystalReportViewer1.ReportSource = rp;
        }
        private DataSet getData()
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();
            string query = "SELECT TOP(" + cbSoLuong.Text + ") * FROM THIDUA_GIAMHOADON WHERE ";
            query += " TTKY7=0 and (TTKY8<>0  and TTKY9<>0 and TTKY10<>0 ) ";
            query+="   AND CONVERT(int,SUBSTRING(LOTRINH,3,2))= "+cbNhanVien.SelectedValue;
             query += " ORDER BY TTKY8 desc ,TTKY9 desc,TTKY10 desc ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);

           adapter.Fill(ds, "THIDUA_GIAMHOADON");
            return ds;
        }

        public void ViewReport2()
        {
            ReportDocument rp = new rpt_ThiDuaGiamHoaDon();
            rp.SetDataSource(getData2());
            rp.SetParameterValue("TEN", cbNhanVien.Text.ToUpper());
            rp.SetParameterValue("TO", "TÂN PHÚ");
            crystalReportViewer1.ReportSource = rp;
        }
        private DataSet getData2()
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            DataSet ds = new DataSet();
            string query = "SELECT td.* FROM THIDUA_GIAMHOADON td, W_GIAMHOADON gm WHERE td.DANHBO=gm.DANHBO ";
            query += "   AND gm.NHANVIEN= " + cbNhanVien.SelectedValue;
            query += " ORDER BY TTKY8 desc ,TTKY9 desc,TTKY10 desc ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);

            adapter.Fill(ds, "THIDUA_GIAMHOADON");
            return ds;
        }
        CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        public bool Insert(W_GIAMHOADON th_dhn)
        {
            try
            {
                db.W_GIAMHOADONs.InsertOnSubmit(th_dhn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public int DeleteByDANHBO(string ID)
        {

            string sql = "DELETE FROM W_GIAMHOADON WHERE DANHBO='" + ID + "'";
            return DAL.LinQConnection.ExecuteCommand_(ID);
        }
        // TTKY1=0 and TTKY2=0 and TTKY3=0 and TTKY4=0 and TTKY5=0 and TTKY6=0 and
        void LoadBC() {

            if (this.checkTuDong.Checked)
            {
                ViewReport();
            }
            else
            {
                try
                {
                    ViewReport2();
                }
                catch (Exception)
                {
                }

            }
        }
        private void cbNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadBC();
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            W_GIAMHOADON gh = new W_GIAMHOADON();
            gh.TODS = "TP";
            gh.DANHBO = this.txtDanhBo.Text;
            int gt =0;
            int.TryParse(this.cbNhanVien.SelectedValue.ToString(), out gt);
            gh.NHANVIEN = gt;
            if (Insert(gh))
            {
                MessageBox.Show(this, "Thêm Thành Công !");
                LoadBC();
            }
            else {
                MessageBox.Show(this, "Thêm Thất Bại !");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            if (DeleteByDANHBO(this.txtDanhBo.Text)==1)
            {
                MessageBox.Show(this, "Xóa Thành Công !");
            }
            else {
                MessageBox.Show(this, "Xóa Thất Bại !");
            }
        }

        private void checkTuDong_CheckedChanged(object sender, EventArgs e)
        {
            LoadBC();
        }

    }
}