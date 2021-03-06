﻿using System;
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
using System.IO;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frmPhieuChepTieuThu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmPhieuChepTieuThu).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frmPhieuChepTieuThu()
        {
            InitializeComponent();

            int ky = DateTime.Now.Month + 1;

            int nam = DateTime.Now.Year;
            txtKy.Text = ky + "";
            txtNam.Text = nam + "";
            cbSoLuong.Text = "10";
           // this.btHSGoc.Visible = false;
        }

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
        public void loadghichu(string danhbo)
        {
            lichsuGhiCHu.DataSource = DAL.DULIEUKH.C_DuLieuKhachHang.lisGhiChu(danhbo);
            for (int i = 0; i < lichsuGhiCHu.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }

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
                loadghichu(khachhang.DANHBO);
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
            if (e.KeyChar == 13)
            {
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

        public void LoadPhieuTieuTHU(string danhba, int nam, int ky)
        {
            dataGridView1.DataSource = getListHoaDonReport(danhba, nam, ky).Tables["TIEUTHU"];
            Utilities.DataGridV.formatRows(dataGridView1);
        }
        public DataSet getListHoaDonReport(string danhba, int nam, int ky)
        {
       
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();

            string query = " SELECT  TOP(1)(H.KY+ '/'+CONVERT(VARCHAR(20),H.Nam)) as NAM, ";
            query += " H.CodeMoi as CODE, H.CSCU, H.CSMOI, H.TieuThuMoi AS 'LNCC' , ";
            query += " CONVERT(NCHAR(10), H.DenNgay, 103) AS DENNGAY ";
            query += " FROM DocSo AS H 	    ";
            query += " WHERE H.DANHBA ='" + danhba + "' ";
            query += "  ORDER BY H.Nam desc,CAST(H.KY as int) DESC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");
            int slTiep=(int.Parse(cbSoLuong.Text) - 1);
            query = "SELECT   TOP(" + slTiep + ")    ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+'/' + CONVERT(VARCHAR(20),H.NAM)) NAM, H.CODE,cast(H.CSCU as int) as CSCU, cast(H.CSMOI as int) as CSMOI,cast(H.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON ";
            query += " FROM HOADON H ";
            query += " WHERE H.DANHBA ='" + danhba + "'  ";
            query += " ORDER BY H.Nam desc,CAST(H.KY as int) DESC  ";
            DataTable TB_HD = DAL.LinQConnectionTT.getDataTable(query);

            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;           
            if (scl > 0)
            {
                query = "SELECT   TOP(" + scl + ")    ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+'/' + CONVERT(VARCHAR(20),H.NAM)) NAM, H.CODE,cast(H.CSCU as int) as CSCU, cast(H.CSMOI as int) as CSMOI,cast(H.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON ";
                query += " FROM TT_HoaDonCu H ";
                query += " WHERE H.DANHBA ='" + danhba + "'  ";
                query += " ORDER BY H.Nam desc,CAST(H.KY as int) DESC ";
                DataTable b_Old = DAL.LinQConnectionTT.getDataTable(query);

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
            if (!txtDanhBo.Text.Replace("-", "").Replace(" ","").Equals(""))
            {
                int ky = int.Parse(txtKy.Text);
                int nam = int.Parse(txtNam.Text);
                LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            }
        }

        public DataSet getListHoaDonReport_BC(string danhba, int nam, int ky)
        {
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
            string query2 = "";

            string query = " SELECT  TOP(1)   H.TODS, KH.DOT, KH.MLT1 AS MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEU, ";
            query += " KH.CO, cast( H.KY as int) as KY, cast( H.Nam as int) AS NAM, H.CodeMoi AS CODE, H.CSCU, H.CSMOI, H.TieuThuMoi AS 'LNCC' , CONVERT(NCHAR(10), H.DenNgay, 103) AS DENNGAY ";
            query += " FROM DocSo AS H LEFT OUTER JOIN ";
            query += " KHACHHANG AS KH ";
            query += " ON H.DANHBA = KH.DANHBA ";
            query += " WHERE KH.DANHBA ='" + danhba + "' ORDER BY  NAM DESC,H.KY DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            int slTiep = (int.Parse(cbSoLuong.Text) - 1);
            query = "  SELECT  TOP(" + slTiep + ")  1 AS TODS, cast(KH.DOT as varchar(5)) as DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI,'' AS SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEUDH AS HIEU, ";
            query += "  KH.CoDH AS CO, cast( KH.KY as int) as KY, cast( KH.Nam as int) AS NAM , KH.CODE,cast(KH.CSCU as int) as CSCU, cast(KH.CSMOI as int) as CSMOI,cast(KH.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), KH.DENNGAY, 103) AS DENNGAY  ";
            query += "  FROM HoaDon AS KH  ";
            query += "  WHERE KH.DANHBA ='" + danhba + "' ORDER BY KH.NAM DESC,KH.KY DESC ";

            DataTable TB_HD = DAL.LinQConnectionTT.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                query = "  SELECT  TOP(" + scl + ")  1 AS TODS, cast(KH.DOT as varchar(5)) as DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI,'' AS SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEUDH AS HIEU, ";
                query += "  KH.CoDH AS CO, cast( KH.KY as int) as KY, cast( KH.Nam as int) AS NAM , KH.CODE,cast(KH.CSCU as int) as CSCU, cast(KH.CSMOI as int) as CSMOI,cast(KH.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), KH.DENNGAY, 103) AS DENNGAY  ";
                query += "  FROM TT_HoaDonCu AS KH  ";
                query += "  WHERE KH.DANHBA ='" + danhba + "' ORDER BY KH.NAM DESC,KH.KY DESC ";

                DataTable b_Old = DAL.LinQConnectionTT.getDataTable(query);

                ds.Tables["TIEUTHU"].Merge(b_Old);
            }

            string _ky = ky + "";
            try
            {
                _ky = ds.Tables["TIEUTHU"].Rows[0]["KY"].ToString();
            }
            catch (Exception) { }

            query2 = " SELECT TOP(1)  kh.ID, kh.KHU, kh.DOT, kh.CUON_GCS, kh.CUON_STT, kh.LOTRINH, kh.DANHBO, kh.NGAYGANDH, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.PHUONG, kh.QUAN, kh.CHUKY, kh.CODE, kh.CODEFU, kh.GIABIEU, kh.DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, kh.NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, kh.CHISOKYTRUOC, kh.BAOTHAY, kh.CREATEDATE, kh.DIENTHOAI AS 'MODIFYBY', kh.MODIFYDATE,  kh.KY, kh.NAM ";
            
            if (ckTTHoadon.Checked)
            {
                HOADON hd = DAL.LinQConnectionTT.findHoaDon(danhba);
                if (hd != null)
                {
                    query2 = " SELECT TOP(1)  kh.ID, kh.KHU, kh.DOT, kh.CUON_GCS, kh.CUON_STT, kh.LOTRINH, kh.DANHBO, kh.NGAYGANDH, kh.HOPDONG, '" + hd.TENKH + "' as 'HOTEN', '" + hd.SO + "' as 'SONHA', '" + hd.DUONG + "' as 'TENDUONG', kh.PHUONG, kh.QUAN, kh.CHUKY, kh.CODE, kh.CODEFU, kh.GIABIEU, kh.DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, kh.NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, kh.CHISOKYTRUOC, kh.BAOTHAY, kh.CREATEDATE, kh.DIENTHOAI AS 'MODIFYBY', kh.MODIFYDATE,  kh.KY, kh.NAM ";
                }
            }

          //  danhba= hd.DANHBA;

            
            query2 += " , ds.DOT as 'DOTDS',ds.TODS,ds.May,nv.NhanVienID as TENNHANVIEN  ";
            query2 += " FROM DocSo AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSoTH.dbo.MayDS nv ";
            query2 += " WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.DANHBA='" + danhba + "' ";
            query2 += " ORDER BY ds.NAM DESC,ds.KY DESC ";

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");

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
            // LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            rp.SetDataSource(getListHoaDonReport_BC(txtDanhBo.Text.Replace("-", ""), nam, ky));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }


        public DataSet getListHoaDonReport_BC_KT(string danhba, int nam, int ky)
        {
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();
            string query2 = "";

            string query = " SELECT  TOP(1)   H.TODS, KH.DOT, KH.MLT1 AS MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEU, ";
            query += " KH.CO, cast( H.KY as int) as KY, cast( H.Nam as int) AS NAM, H.CodeMoi AS CODE, H.CSCU, H.CSMOI, H.TieuThuMoi AS 'LNCC' , CONVERT(NCHAR(10), H.DenNgay, 103) AS DENNGAY ";
            query += " FROM DocSo AS H LEFT OUTER JOIN ";
            query += " KHACHHANG AS KH ";
            query += " ON H.DANHBA = KH.DANHBA ";
            query += " WHERE KH.DANHBA ='" + danhba + "' ORDER BY  NAM DESC,H.KY DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            int slTiep = (int.Parse(cbSoLuong.Text) - 1);
            query = "  SELECT  TOP(" + slTiep + ")  1 AS TODS, cast(KH.DOT as varchar(5)) as DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI,'' AS SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEUDH AS HIEU, ";
            query += "  KH.CoDH AS CO, cast( KH.KY as int) as KY, cast( KH.Nam as int) AS NAM , KH.CODE,cast(KH.CSCU as int) as CSCU, cast(KH.CSMOI as int) as CSMOI,cast(KH.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), KH.DENNGAY, 103) AS DENNGAY  ";
            query += "  FROM HoaDon AS KH  ";
            query += "  WHERE KH.DANHBA ='" + danhba + "' ORDER BY KH.NAM DESC,KH.KY DESC ";
            DataTable TB_HD = DAL.LinQConnectionTT.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = int.Parse(cbSoLuong.Text) - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                query = "  SELECT  TOP(" + scl + ")  1 AS TODS, cast(KH.DOT as varchar(5)) as DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI,'' AS SOMOI, CAST(KH.GB as varchar(10)) as GB,CAST(KH.DM as varchar(10)) as DM, KH.HOPDONG, KH.HIEUDH AS HIEU, ";
                query += "  KH.CoDH AS CO, cast( KH.KY as int) as KY, cast( KH.Nam as int) AS NAM , KH.CODE,cast(KH.CSCU as int) as CSCU, cast(KH.CSMOI as int) as CSMOI,cast(KH.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), KH.DENNGAY, 103) AS DENNGAY  ";
                query += "  FROM TT_HoaDonCu AS KH  ";
                query += "  WHERE KH.DANHBA ='" + danhba + "' ORDER BY KH.NAM DESC,KH.KY DESC ";

                DataTable b_Old = DAL.LinQConnectionTT.getDataTable(query);

                ds.Tables["TIEUTHU"].Merge(b_Old);
            }


            string _ky = ky + "";
            try
            {
                _ky = ds.Tables["TIEUTHU"].Rows[0]["KY"].ToString();
            }
            catch (Exception)
            {
            }

            query2 = " SELECT TOP(1)  kh.ID, kh.KHU, kh.DOT, kh.CUON_GCS, kh.CUON_STT, kh.LOTRINH, kh.DANHBO, kh.NGAYGANDH, kh.HOPDONG, kh.HOTEN, kh.SONHA, kh.TENDUONG, kh.PHUONG, kh.QUAN, kh.CHUKY, kh.CODE, kh.CODEFU, kh.GIABIEU, kh.DINHMUC, SH, HCSN, SX, DV, CODH, HIEUDH, SOTHANDH, CAP, CHITHAN, CHIGOC, VITRIDHN, SODHN, kh.NGAYTHAY, NGAYKIEMDINH, MSTHUE, SOHO, kh.CHISOKYTRUOC, kh.BAOTHAY, kh.CREATEDATE, kh.DIENTHOAI AS 'MODIFYBY', kh.MODIFYDATE,  kh.KY, kh.NAM ";
            query2 += " , ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.NhanVienID as TENNHANVIEN ";
            query2 += " FROM DocSo AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSoTH.dbo.MayDS nv ";
            query2 += " WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.DANHBA='" + danhba + "' ";
            query2 += " ORDER BY ds.NAM DESC,ds.KY DESC  ";

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");
            
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


        private void btHSGoc_Click(object sender, EventArgs e)
        {
            if (DAL.KTCN.C_GIS.findByDanhBo(txtDanhBo.Text.Replace("-", "")) != null)
            {
                frmPdf F = new frmPdf(txtDanhBo.Text.Replace("-", ""));
                F.ShowDialog();
            }
            else {
                MessageBox.Show(this, "Hồ sơ gốc chưa được cập nhật !","..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btHinhChup_Click(object sender, EventArgs e)
        {
            frmHinh F = new frmHinh(txtDanhBo.Text.Replace("-", ""));
            F.ShowDialog();
        }
    }
}