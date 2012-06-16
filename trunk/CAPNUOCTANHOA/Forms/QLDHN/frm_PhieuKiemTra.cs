using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CAPNUOCTANHOA.Forms.Reports;
using System.Configuration;
using CAPNUOCTANHOA.Forms.BanKTKS.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_PhieuKiemTra : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_PhieuKiemTra).Name);
        public frm_PhieuKiemTra()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;
            cbCode.SelectedIndex = 5;
            frmLoad();

        }
        public void frmLoad()
        {
            Rectangle rect = DG_ChuaGiao.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(17, 17);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            DG_ChuaGiao.Controls.Add(checkboxHeader);
        }
        public void LoadData()
        {
            int DOT = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            int KY = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int NAM = int.Parse(txtNam.Text.Trim());
            string code = cbCode.Items[cbCode.SelectedIndex].ToString();
            
            int TODS = 1;
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                TODS = 2;
            }
            else if ("TP".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                TODS = 3;
            }
            DG_ChuaGiao.DataSource = DAL.QLDHN.C_PhieuKiemTra.getListByCode(TODS, DOT, KY, NAM, "'60','61','62','63','64','65','66'");
            Utilities.DataGridV.formatRows(DG_ChuaGiao, "DANHBO", "LOTRINH");
            if (DG_ChuaGiao.Rows.Count > 0) {

                btInKT.Visible = true;
                btDanhSach.Visible = true;
            }
        }
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
            {
                DG_ChuaGiao[0, i].Value = ((CheckBox)DG_ChuaGiao.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
        }

        private void btKiemTra_Click(object sender, EventArgs e)
        {
            btInKT.Visible = false;
            LoadData();
          
        }
        // them


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

            query = "SELECT  TOP(10)   KH.TODS, KH.DOT, KH.MALOTRINH, KH.DANHBA, KH.TENKH, RTRIM(KH.SO) + ' ' + KH.DUONG AS DIACHI, KH.SOMOI, KH.GB, KH.DM, KH.HOPDONG, KH.HIEU, " +
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


            query2 = "SELECT  kh.*, ds.DOT as 'DOTDS',ds.TODS,ds.MAY,nv.TENNHANVIEN  ";
            query2 += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as kh,DocSo_PHT.dbo.NHANVIEN nv ";
            query2 += "WHERE nv.MAY=ds.MAY AND ds.DANHBA=kh.DANHBO AND ds.KY=" + _ky + " AND ds.DANHBA='" + danhba + "' ";

            adapter = new SqlDataAdapter(query2, db.Connection.ConnectionString);
            adapter.Fill(ds, "VIEW_YEUCAUKIEMTRA");

            int scl = 10 - ds.Tables["TIEUTHU"].Rows.Count;
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
            //ReportDocument rp = new rpt_PhieuGhiChepTieuThu();
            //int ky = int.Parse(txtKy.Text);
            //int nam = int.Parse(txtNam.Text);
            //LoadPhieuTieuTHU(txtDanhBo.Text.Replace("-", ""), nam, ky);
            //rp.SetDataSource(getListHoaDonReport_BC(txtDanhBo.Text.Replace("-", ""), nam, ky));
            //frm_Reports frm = new frm_Reports(rp);
            //frm.ShowDialog();
        }
        //end
        int stt = 1;
        string listDanhBo = "";
        private void btInKT_Click(object sender, EventArgs e)
        {
            try
            {
                bool chek = false;
                for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
                {
                    if (DG_ChuaGiao[0, i].Value != null && "True".Equals(DG_ChuaGiao[0, i].Value.ToString()))
                    {
                        chek = true;
                        int DOT = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                        int KY = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                        int NAM = int.Parse(txtNam.Text.Trim());
                        int MAYDS = int.Parse((DG_ChuaGiao.Rows[i].Cells["MAYDS"].Value + ""));
                        string DANHBO = (DG_ChuaGiao.Rows[i].Cells["DANHBO"].Value+"").Replace(" ","");
                        string LOTRINH = (DG_ChuaGiao.Rows[i].Cells["LOTRINH"].Value + "").Replace(".", "");
                        string HOTEN = (DG_ChuaGiao.Rows[i].Cells["HOTEN"].Value + "");
                        string DIACHI = (DG_ChuaGiao.Rows[i].Cells["DIACHI"].Value + "");
                        string CODEKYTRUOC = (DG_ChuaGiao.Rows[i].Cells["CODEKYTRUOC"].Value + "");
                        string CSCU = (DG_ChuaGiao.Rows[i].Cells["CSCU"].Value + "");
                        listDanhBo += "'" + DANHBO + "',";
                        try
                        {
                            ReportDocument rp = new rpt_PhieuGhiChepTieuThu();

                            rp.SetDataSource(getListHoaDonReport_BC(DANHBO, NAM, KY));                

                            rp.PrintToPrinter(1, false, 0, 0);
                            stt++;
                            TB_CHUYENKIEMTRA chuyenkt = new TB_CHUYENKIEMTRA();
                            chuyenkt.KY = KY;
                            chuyenkt.DOT = DOT;
                            chuyenkt.NAM = NAM;
                            chuyenkt.MAYDS = MAYDS;
                            chuyenkt.DANHBO = DANHBO;
                            chuyenkt.LOTRINH = LOTRINH;
                            chuyenkt.HOTEN = HOTEN;
                            chuyenkt.DIACHI = DIACHI;
                            chuyenkt.CODEKYTRUOC = CODEKYTRUOC;
                            chuyenkt.CSCU = CSCU;
                            chuyenkt.NGAYCHUYEN = DateTime.Now.Date;
                            chuyenkt.GIOCHUYEN = DateTime.Now.TimeOfDay;
                            chuyenkt.CREATEBY = DAL.SYS.C_USERS._userName;
                            chuyenkt.CREATEDATE = DateTime.Now;
                            DAL.QLDHN.C_PhieuKiemTra.Insert(chuyenkt);
                            
                        }
                        catch (Exception ex)
                        {
                            log.Error("Loi In " + ex.Message);
                            MessageBox.Show(this, "Lỗi Khi Chuyển Hồ Sơ Yêu Cầu Kiểm Tra. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            break;
                        }
                        // dataT  NGAYCHUYEN DATETIME,
                        //string   GIOCHUYEN TIME,	 
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Yêu Cẩu Kiểm Tra.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show(this, "Chuyển Hồ Sơ Thảnh Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
                //{
                //    if (DG_ChuaGiao[0, i].Value != null && "True".Equals(DG_ChuaGiao[0, i].Value.ToString()))
                //    {
                //        DG_ChuaGiao.Rows.RemoveAt(i);
                //    }
                //}
            }
            catch (Exception ex)
            {
                log.Error("--" + ex.Message);
            }
        }

        private void btDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
                {
                    if (DG_ChuaGiao[0, i].Value != null && "True".Equals(DG_ChuaGiao[0, i].Value.ToString()))
                    {                         
                        string DANHBO = (DG_ChuaGiao.Rows[i].Cells["DANHBO"].Value + "").Replace(" ", "");                   
                        listDanhBo += "'" + DANHBO + "',";
                    }
                }
                ///////
                string listDanhBa = (listDanhBo.Remove(listDanhBo.Length - 1, 1));
                string title = "";
                if ("TB01".Equals(DAL.SYS.C_USERS._toDocSo))
                {
                    title = "TỔ :  TÂN BÌNH 1 ";
                }
                else if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
                {
                    title = "TỔ : TÂN BÌNH 2 ";
                }
                else
                {
                    title = "TỔ :  TÂN PHÚ ";
                }
                title += " -  KỲ: " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + " - ĐỢT : " + cbDotDS.Items[cbDotDS.SelectedIndex].ToString() + " - CODE : 60,61,62,63,64,65,66" ;

                ReportDocument rp = new rpt_DanhSachYeuCauDieuChinh();

                rp.SetDataSource(DAL.QLDHN.C_PhieuKiemTra.getListDanhBoReport(listDanhBa));
                rp.SetParameterValue("title", title);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
            catch (Exception)
            {
                
            }
           
        }
        /* ---------------------- */
       
    }
}