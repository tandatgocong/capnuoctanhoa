using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiTCTB.BC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Data.SqlClient;
using CAPNUOCTANHOA.Forms.BanKTKS.BC;
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frmPhieuChepTieuThu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmPhieuChepTieuThu).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frmPhieuChepTieuThu()
        {
            InitializeComponent();
            int ky = DateTime.Now.Month +1;
            int nam = DateTime.Now.Year;
            txtKy.Text = ky+"";
            txtNam.Text = nam+"";
            cbSoLuong.SelectedIndex = 9;
           
        }

        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }
        TB_DULIEUKHACHHANG khachhang = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            string lotrinh = this.LOTRINH.Text.Replace(".", "");
            if (sodanhbo.Length == 11)
            {
                khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
            }
            else if (!"".Equals(lotrinh))
            {
                khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByLoTrinh(lotrinh);
            }

            if (khachhang != null)
            {
                txtDanhBo.Text = khachhang.DANHBO;
                LOTRINH.Text = khachhang.LOTRINH;
                HOPDONG.Text = khachhang.HOPDONG;
                HOTEN.Text = khachhang.HOTEN;
                SONHA.Text = khachhang.SONHA;
                TENDUONG.Text = khachhang.TENDUONG;
                txtDienThoai.Text = khachhang.DIENTHOAI;
                try
                {
                    LinQ.QUAN q = DAL.SYS.C_Quan.finByMaQuan(int.Parse(khachhang.QUAN));
                    if (q != null)
                    {
                        LinQ.PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, khachhang.PHUONG.Trim());
                        PHUONGT.Text = ph.TENPHUONG;
                    }
                }
                catch (Exception)
                {
                }
                GIABIEU.Text = khachhang.GIABIEU;
                DINHMUC.Text = khachhang.DINHMUC;
                NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                HIEUDH.Text = khachhang.HIEUDH;
                CO.Text = khachhang.CODH;
                CAP.Text = khachhang.CAP;
                SOTHAN.Text = khachhang.SOTHANDH;
                VITRI.Text = khachhang.VITRIDHN;
                int ky = int.Parse(txtKy.Text);
                int nam = int.Parse(txtNam.Text);
                LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            }
            else
            {
                MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refesh();
            }
        }

        public void Refesh()
        {
            LOTRINH.Text = "";
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            TENDUONG.Text = "";            
            PHUONGT.Text = "";
            GIABIEU.Text = "";
            DINHMUC.Text = "";
            NGAYGAN.ValueObject = DateTime.Now.Date;
            KIEMDINH.ValueObject = DateTime.Now.Date;
            HIEUDH.Text = "";
            CO.Text = "";
            CAP.Text = "";
            SOTHAN.Text = "";
            VITRI.Text = "";

            txtDanhBo.Focus();

        }

        private void LOTRINH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                LoadThongTinDB();
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }
    
        public void LoadPhieuTieuTHU(string danhba, int nam, int ky) {
            dataGridView1.DataSource = getListHoaDonReport(danhba,nam,ky).Tables["TIEUTHU"];
            Utilities.DataGridV.formatRows(dataGridView1);
        }
        public DataSet getListHoaDonReport(string danhba, int nam, int ky)
        {
           
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
      

            string query = "SELECT  TOP(1)  " +
                  " ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.DENNGAYDOCSO, 103) AS DENNGAY  FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = "SELECT  TOP(" + (int.Parse(cbSoLuong.Text)-1) + ") " +
                "( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON FROM HD" + nam + " AS H LEFT OUTER JOIN" +
              " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionDS.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;
            while (scl > 0)
            {
                nam = nam - 1;
                query = "SELECT  TOP(" + scl + ")   " +
          " ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON FROM HD" + nam + " AS H LEFT OUTER JOIN" +
        " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";

                DataTable b_Old = DAL.LinQConnectionDS.getDataTable(query);
                ds.Tables["TIEUTHU"].Merge(b_Old);
            }
            return ds;

        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridView1);
        }

        private void cbSoLuong_SelectedValueChanged(object sender, EventArgs e)
        {
            int ky = int.Parse(txtKy.Text);
            int nam = int.Parse(txtNam.Text);
            LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
        }

        public DataSet getListHoaDonReport_BC(string danhba, int nam, int ky)
        {
            
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
            string query2 = "";

            string query = "SELECT  TOP(1)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                  " KH.CO,  H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.DENNGAYDOCSO, 103) AS DENNGAY, H.TIEUTHU AS 'LNCC' FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = "SELECT  TOP(" + (int.Parse(cbSoLuong.Text) -1)+ ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                " KH.CO, H.SOHOADON AS 'SOTHAN', H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
              " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionDS.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            string _ky = ky+"";
            try
            {
                _ky = ds.Tables["TIEUTHU"].Rows[0]["KY"].ToString();
            }
            catch (Exception)
            {
                
            }


            query2 = "SELECT  kh.ID, kh.KHU, kh.DOT, kh.CUON_GCS, kh.CUON_STT, kh.LOTRINH, kh.DANHBO, kh.NGAYGANDH, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.PHUONG, kh.QUAN, kh.CHUKY, kh.CODE, kh.CODEFU, kh.GIABIEU, kh.DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, kh.NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, kh.CHISOKYTRUOC, kh.BAOTHAY, kh.CREATEDATE, kh.DIENTHOAI AS 'MODIFYBY', kh.MODIFYDATE,  kh.KY, kh.NAM"; 
            query2+=" , ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.TENNHANVIEN  ";
            query2 += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSo_PHT.dbo.NHANVIEN nv ";
            query2 += "WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.KY=" + _ky + " AND ds.DANHBA='" + danhba + "' ";

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                nam = nam - 1;
                query = "SELECT  TOP(" + scl + ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
             " KH.CO, H.SOHOADON AS 'SOTHAN', H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
           " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
 
                DataTable b_Old = DAL.LinQConnectionDS.getDataTable(query);
                ds.Tables["TIEUTHU"].Merge(b_Old);
            }

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            string record = ConfigurationManager.AppSettings["record"].ToString();
            query = "SELECT TOP(" + record + ") * FROM CAPNUOCTANHOA.dbo.TB_GHICHU WHERE DANHBO='" + danhba + "' ORDER BY CREATEDATE DESC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_GHICHU");

            return ds;

        }




        private void btInDS_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_PhieuGhiChepTieuThu();
            int ky = int.Parse(txtKy.Text);
            int nam = int.Parse(txtNam.Text);
            LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            rp.SetDataSource(getListHoaDonReport_BC(txtDanhBo.Text.Replace("-", ""), nam, ky));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }


        public DataSet getListHoaDonReport_BC_KT(string danhba, int nam, int ky)
        {

            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
            string query2 = "";

            string query = "SELECT  TOP(1)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                  " KH.CO,  H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.DENNGAYDOCSO, 103) AS DENNGAY, H.TIEUTHU AS 'LNCC' FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = "SELECT  TOP(" + (int.Parse(cbSoLuong.Text)-1) + ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
                " KH.CO, H.SOHOADON AS 'SOTHAN', H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
              " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionDS.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            string _ky = ky + "";
            try
            {
                _ky = ds.Tables["TIEUTHU"].Rows[0]["KY"].ToString();
            }
            catch (Exception)
            {

            }


            query2 = "SELECT  kh.ID, kh.KHU, kh.DOT, kh.CUON_GCS, kh.CUON_STT, kh.LOTRINH, kh.DANHBO, kh.NGAYGANDH, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.PHUONG, kh.QUAN, kh.CHUKY, kh.CODE, kh.CODEFU, kh.GIABIEU, kh.DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, kh.NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, kh.CHISOKYTRUOC, kh.BAOTHAY, kh.CREATEDATE, kh.DIENTHOAI AS 'MODIFYBY', kh.MODIFYDATE,  kh.KY, kh.NAM";
            query2 += " , ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.TENNHANVIEN  ";
            query2 += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSo_PHT.dbo.NHANVIEN nv ";
            query2 += "WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.KY=" + _ky + " AND ds.DANHBA='" + danhba + "' ";

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                nam = nam - 1;
                query = "SELECT  TOP(" + scl + ")   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
             " KH.CO, H.SOHOADON AS 'SOTHAN', H.KY, " + nam + " AS NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.LNCC FROM HD" + nam + " AS H LEFT OUTER JOIN" +
           " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";

                DataTable b_Old = DAL.LinQConnectionDS.getDataTable(query);
                ds.Tables["TIEUTHU"].Merge(b_Old);
            }

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            string recordKT = ConfigurationManager.AppSettings["recordKT"].ToString();
            query = "SELECT TOP(" + recordKT + ") * FROM CAPNUOCTANHOA.dbo.TB_GHICHU WHERE DANHBO='" + danhba + "' ORDER BY CREATEDATE DESC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_GHICHU");

            return ds;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_PhieuKiemTra();
            int ky = int.Parse(txtKy.Text);
            int nam = int.Parse(txtNam.Text);
            LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            rp.SetDataSource(getListHoaDonReport_BC_KT(txtDanhBo.Text.Replace("-", ""), nam, ky));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

       
   
    }
}