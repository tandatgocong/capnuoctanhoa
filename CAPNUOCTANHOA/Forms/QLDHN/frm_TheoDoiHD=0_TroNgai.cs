using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.DAL.QLDHN;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.Forms.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using CAPNUOCTANHOA.Forms.QLDHN;
using CAPNUOCTANHOA.Forms.BanKTKS.BC;
using CAPNUOCTANHOA.Forms.QLDHN.HoaDon0M3;
using CAPNUOCTANHOA.Utilities;


namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_TheoDoiHD_0_TroNgai : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        bool flagDanhBo = false;//Flag xoa tu danh bo hay bang ke


        public frm_TheoDoiHD_0_TroNgai()
        {
            InitializeComponent();
        }



        private void frm_TheoDoiHD_0_Load(object sender, EventArgs e)
        {
          
            txtNamHuy.Text = DateTime.Now.Year.ToString();
            panelLichSuHoaDon0.Visible = false;
            dataGridView2.Visible = false;
            cbChiSoKy.SelectedIndex = DateTime.Now.Month - 1;
            cbDot.SelectedIndex = 0;
            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            txtToDS.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtToDS.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtToDS.AutoCompleteCustomSource = namesCollection;

            try
            {
                txtNgayGhiNhan.Value = DateTime.Now;
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                int id=DAL.QLDHN.C_HoaDon_0.getMaxBangKe_2();
                if (id >= int.Parse(balap))
                {
                    txtSoBangKe_Thongtin.Text = (id + 1) + "";

                }
                else
                {
                    txtSoBangKe_Thongtin.Text = balap;

                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }


        }


        //public void setSTT()
        //{
        //    for (int i = 0; i < dgvThongTinHD_0.Rows.Count - 1; i++)
        //    {
        //        dgvThongTinHD_0.Rows[i].Cells["DHN_STT"].Value = i + 1;

        //    }

        //}
        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            txtSoBangKe_Thongtin.Focus();

            txtSoBangKe_Thongtin.Text = "";
            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGhiNhan.ValueObject = DateTime.Now;
            txtToDS.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtMaLoTrinh.Text = "";
            //txtID.Text = "";

            txtLyDo.Text = "";
            this.dgvThongTinHD_0.DataSource = DAL.QLDHN.C_HoaDon_0.getBangKeBaoThay(999999);

            try
            {
                string bk = DateTime.Now.Year.ToString().Substring(2) + 001;
                if (DAL.QLDHN.C_HoaDon_0.getMaxBangKe() >= int.Parse(bk))
                {
                    txtSoBangKe_Thongtin.Text = (DAL.QLDHN.C_HoaDon_0.getMaxBangKe() + 1) + "";
                }
                else
                {
                    txtSoBangKe_Thongtin.Text = bk;
                }
            }

            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        public void refresh()
        {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGhiNhan.ValueObject = DateTime.Now;
            txtToDS.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtMaLoTrinh.Text = "";
            //txtGhiChu = " ";
            //btcapNhat.Enabled = false;
            //checkChuaDanhDau.Checked = false;
            //btXoa.Enabled = false;
            //txtID.Text = "";


        }


        void LoadThongTinDB()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            string sobangke = this.txtSoBangKe_Thongtin.Text;
            if (sodanhbo.Length == 11)
            {
                DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
                TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (kh != null)
                {
                    txtTenKH.Text = kh.HOTEN;
                    txtDiaChi.Text = kh.SONHA + " " + kh.TENDUONG;
                    txtCo.Text = kh.CODH;
                    txtSoThan.Text = kh.SOTHANDH;

                    txtMaLoTrinh.Text = kh.LOTRINH;
                    // start lấy dot theo ma lo trinh
                    int dotTheoLoTrinh = int.Parse(kh.LOTRINH.ToString().Substring(0, 2)) - 1;
                    cbDot.SelectedIndex = dotTheoLoTrinh;
                    //end
                    txtToDS.Text = GetTOds(txtMaLoTrinh.Text);
                    txtNam.Text = DateTime.Now.Year.ToString();
                    btnXoa.Enabled = true;
                  //  btcapNhat.Enabled = true;


                }

            }


        }


        private void txtSoBangKe_TextChanged(object sender, EventArgs e)
        {
            //     if ("HC".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //     {
            //          title.Text = "BẢNG KÊ BÁO THAY HẠ CỞ ĐỒNG HỒ NƯỚC";
            //         txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO","");
            //     }
            //     else if ("TH".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //     {
            //         title.Text = "BẢNG KÊ BÁO THAY THỬ ĐỒNG HỒ NƯỚC";
            //         txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO","");
            //     }
            //     else if ("BB".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //     {
            //         title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC THEO BIÊN BẢN KIỂM TRA";
            //         txtLyDo.Text = "BBKT NGÀY";
            //     }
            //     else
            //     {
            //         title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC " + this.cbLoaiBangKe.Text;
            //         txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            //     }
        }
        public DataTable SoSanhKyTruoc(DataTable dt)
        {

            DataTable kq = new DataTable();
            kq = dt.Clone();

            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            string KyTruoc = d.Month.ToString();
            string namtruoc = d.Year.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable temp = new DataTable();
                temp = DAL.QLDHN.C_HoaDon_0.DataSoSanhKyTruoc(dt.Rows[i]["DHN_SOBANGKE"].ToString(), dt.Rows[i]["DHN_DANHBO"].ToString(), KyTruoc, namtruoc);
                foreach (DataRow r in temp.Rows)
                {
                    kq.ImportRow(r);

                }

            }
            return kq;
        }
        public void LoadData_ThongTin()
        {
            try
            {

                DataTable dt = new DataTable();
                dt = DAL.QLDHN.C_HoaDon_0.getBangKeBaoThay_TN( txtSoBangKe_Thongtin.Text.Trim());
                dgvThongTinHD_0.DataSource = dt;
                Utilities.DataGridV.formatRowsSTT(dgvThongTinHD_0, "DHN_DANHBO", "DHN_STT");
                btnXoa.Visible = true;
               //// btcapNhat.Visible = true;
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }
        private void txtSoBangKe_Thongtin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                flagDanhBo = false;
                LoadData_ThongTin();
                refresh();


            }
        }

        private string GetTOds(string malotrinh)
        {
            string kq = "";
            string todsKytu3 = malotrinh.Substring(2, 1);
            string todsKytu4 = malotrinh.Substring(3, 1);
            int tods = (int.Parse(todsKytu3) * 10) + int.Parse(todsKytu4);
            if (tods >= 1 && tods <= 15)
            {
                kq = "TB1";
            }
            else if (tods > 15 && tods <= 30)
            {
                kq = "TB2";
            }
            else
            {
                kq = "TP";
            }
            return kq;
        }



        //private void chk_CamKet_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_CamKet.Checked == true)
        //    {
        //        cbKy.SelectedIndex = 0;
        //        cbKy.Visible = true;
        //        checkBoxBamChi.Checked = false;
        //        checkGanMoi.Checked = false;
        //    }
        //    else
        //    {
        //        cbKy.Visible = false;
        //    }
        //}

       
        private void dgvThongTinHD_0_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string DHN_DANHBO = dgvThongTinHD_0.Rows[e.RowIndex].Cells["DHN_DANHBO"].Value + "";
                string HOTEN = dgvThongTinHD_0.Rows[e.RowIndex].Cells["HOTEN"].Value + "";
                string DIACHI = dgvThongTinHD_0.Rows[e.RowIndex].Cells["DIACHI"].Value + "";
                string DHN_GHICHU = dgvThongTinHD_0.Rows[e.RowIndex].Cells["DHN_GHICHU"].Value + "";
                string DHN_lydo = dgvThongTinHD_0.Rows[e.RowIndex].Cells["DHN_LYDO"].Value + "";
                txtSoDanhBo.Text = DHN_DANHBO.Replace(" ", "");
                txtTenKH.Text = HOTEN;
                txtDiaChi.Text = DIACHI;
                txtNam.Text = DateTime.Now.Year + "";
                txtLyDo.Text = DHN_lydo;
                txtGhiCHu.Text = DHN_GHICHU;
                btnXoa.Enabled = true;
                LoadPhieuTieuTHU(txtSoDanhBo.Text.Replace("-", ""), int.Parse(txtNam.Text), DateTime.Now.Month);
                LoadLichSuHoaDon0(txtSoDanhBo.Text.Replace("-", ""));
            }
            catch (Exception)
            {

            }
        }
        public void Add()
        {

            DK_GIAMHOADON_TRONGAI DHN_Giam = new DK_GIAMHOADON_TRONGAI();
            DHN_Giam.DHN_SOBANGKE = txtSoBangKe_Thongtin.Text;
            DHN_Giam.DHN_DANHBO = txtSoDanhBo.Text.Replace("-", "");
            DHN_Giam.DHN_NGAYGHINHAN = txtNgayGhiNhan.Value.Date;
            DHN_Giam.DHN_GHICHU = txtLyDo.Text;
            DHN_Giam.DHN_NAM = int.Parse(DateTime.Now.Year.ToString());
            DHN_Giam.DHN_TODS = txtToDS.Text;
            DHN_Giam.DHN_KY = cbChiSoKy.Text;
            DHN_Giam.DHN_DOT = cbDot.Text;
            DHN_Giam.DHN_TRONGAI = "X";
            DHN_Giam.DHN_LYDO = this.txtLyDo.Text;
            DHN_Giam.DHN_GHICHU = this.txtGhiCHu.Text;
            DHN_Giam.DHN_CREATEBY = DAL.SYS.C_USERS._userName;
            DHN_Giam.DHN_CREATEDATE = DateTime.Now;

            DAL.QLDHN.C_HoaDon_0.Insert_TR(DHN_Giam);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {

                string danhbo = txtSoDanhBo.Text.Replace("-", "");
                //string mess = "Thêm Cho Danh Bộ  " + danhbo;

               


                //if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                Add();
               // MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
                LoadData_ThongTin();
                //try
                //{
                //    string bk = DateTime.Now.Year.ToString().Substring(2) + 001;
                //    if (DAL.QLDHN.C_HoaDon_0.getMaxBangKe() >= int.Parse(bk))
                //    {
                //        txtSoBangKe_Thongtin.Text = (DAL.QLDHN.C_HoaDon_0.getMaxBangKe() + 1) + "";
                //    }
                //    else
                //    {
                //        txtSoBangKe_Thongtin.Text = bk;
                //    }
                //}
                //catch (Exception ex)
                //{
                //}            //}
            }
            catch (Exception ex)
            {
                log.Error("Them Ko Thanh Cong" + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

        }


        public DataTable tbFilter(DataTable dataTable, string selectFilter)
        {
            var filteredTable = dataTable.Clone();
            var rows = dataTable.Select(selectFilter).ToList();
            rows.ForEach(filteredTable.ImportRow);
            return filteredTable;
        }

        public void XuatReportTab0()
        {
            ReportDocument rptDoc = new rpt_TheoDoiHD_0();
            DataTable dt = new DataTable();
            DATASET_DK_GIAMHOADON_ ds = new DATASET_DK_GIAMHOADON_();

            dt = (DataTable)dgvThongTinHD_0.DataSource;
            DataTable dtfilter = new DataTable();
            string where = "DHN_KY='" + cbChiSoKy.Text + "'";
            dtfilter = tbFilter(dt, where);
            dtfilter.TableName = "TABLEHD";
         
            ds.Tables["TABLEHD"].Merge(dtfilter);
            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            rptDoc.SetParameterValue("Ky", cbChiSoKy.Text);

            frm_Reports frm = new frm_Reports(rptDoc);
            frm.Show();

        }


        private void btIn_Click(object sender, EventArgs e)
        {

            ReportDocument rptDoc = new rpt_TheoDoiHD_0();
            ReportDocument rptck = new rpt_TheoDoiHD_0_CK();
            DataTable dt = new DataTable();
            DATASET_DK_GIAMHOADON_ ds = new DATASET_DK_GIAMHOADON_();

            dt = (DataTable)dgvThongTinHD_0.DataSource;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            DataTable dtfilter = new DataTable();
            string where = "DHN_SOBANGKE='" + txtSoBangKe_Thongtin.Text + "'";
            //if (checkBoxBamChi.Checked == true)
            //{
            //    where = where + " AND DHN_BAMHI='X'";
            //}
            //if (chk_CamKet.Checked == true)
            //{
            //    where = where + " AND DHN_CAMKET<>''";
            //}
            dtfilter = tbFilter(dt, where);
            dtfilter.TableName = "TABLEHD";
            //format danh bo
            for (int i = 0; i < dtfilter.Rows.Count; i++)
            {
                dtfilter.Rows[0]["DHN_DANHBO"] = FormatSoHoSoDanhBo.sodanhbo(dtfilter.Rows[0]["DHN_DANHBO"].ToString());
            }
            ds.Tables["TABLEHD"].Merge(dtfilter);
            //set dataset to the report viewer.
            //if (chk_CamKet.Checked == true)
            //{

            //    rptck.SetDataSource(ds);
            //    rptck.SetParameterValue("bangke", txtSoBangKe_Thongtin.Text);
            //    frm_Reports frm = new frm_Reports(rptck);
            //    frm.Show();
            //}
            //else
            //{
               
                rptDoc.SetDataSource(ds);
                rptDoc.SetParameterValue("bangke", txtSoBangKe_Thongtin.Text);
                frm_Reports frm = new frm_Reports(rptDoc);
                frm.Show();
            //}
            //rptDoc.SetParameterValue("Ky", cbChiSoKy.Text);
           

           
            
        }

        public void LoadPhieuTieuTHU(string danhba, int nam, int ky)
        {
            dataGridView2.Visible = true;
            dataGridView2.DataSource = getListHoaDonReport(danhba, nam, ky).Tables["TIEUTHU"];
            Utilities.DataGridV.formatRows(dataGridView2);
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
            int slTiep = (5 - 1);
            query = "SELECT   TOP(" + slTiep + ")    ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+'/' + CONVERT(VARCHAR(20),H.NAM)) NAM, H.CODE,cast(H.CSCU as int) as CSCU, cast(H.CSMOI as int) as CSMOI,cast(H.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON ";
            query += " FROM HOADON H ";
            query += " WHERE H.DANHBA ='" + danhba + "'  ";
            query += " ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionTT.getDataTable(query);

            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = 5 - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                query = "SELECT   TOP(" + scl + ")    ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+'/' + CONVERT(VARCHAR(20),H.NAM)) NAM, H.CODE,cast(H.CSCU as int) as CSCU, cast(H.CSMOI as int) as CSMOI,cast(H.TIEUTHU as int) AS LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON ";
                query += " FROM TT_HoaDonCu H ";
                query += " WHERE H.DANHBA ='" + danhba + "'  ";
                query += " ORDER BY H.DENNGAY DESC ";
                DataTable b_Old = DAL.LinQConnectionTT.getDataTable(query);

                ds.Tables["TIEUTHU"].Merge(b_Old);
            }


            return ds;
        }


        #region Lịch Sử Hóa Đơn Bằng 0

        public void LoadLichSuHoaDon0(string sodanhbo)
        {
            DataTable dt = DAL.BANKTKS.C_GiamHoaDon.getLichSuHoaDon0_TronGai(sodanhbo);

            dataLichSuHoaDon0.DataSource = dt;
            panelLichSuHoaDon0.Visible = true;

            Utilities.DataGridV.formatRows(dataLichSuHoaDon0);

        }

        #endregion


        private void buttonX2_Click(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new rpt_KhongCamKetSD_T();
            DataTable dt = new DataTable();
            DATASET_DK_GIAMHOADON_ ds = new DATASET_DK_GIAMHOADON_();
            dt = (DataTable)dgvThongTinHD_0.DataSource;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            

            DataTable dtfilter = new DataTable();
            // string where = "DHN_KY='" + cbChiSoKy.Text + "' AND ((DHN_CAMKET is null AND DHN_BAMHI is null) OR DHN_HUYCAMKET='X')";
            string where = "DHN_SOBANGKE='" + txtSoBangKe_Thongtin.Text + "' AND  DHN_HUYCAMKET='X'";
            dtfilter = tbFilter(dt, where);
            dtfilter.TableName = "TABLEHD";
           //format danh bo
            for (int i = 0; i < dtfilter.Rows.Count; i++)
            {
                dtfilter.Rows[0]["DHN_DANHBO"] = FormatSoHoSoDanhBo.sodanhbo(dtfilter.Rows[0]["DHN_DANHBO"].ToString());
            }
            ds.Tables["TABLEHD"].Merge(dtfilter);
            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            //rptDoc.SetParameterValue("Ky", cbChiSoKy.Text);
            rptDoc.SetParameterValue("bangke", txtSoBangKe_Thongtin.Text);


            frm_Reports frm = new frm_Reports(rptDoc);
            frm.Show();

        }

      
        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string text = txtSoDanhBo.Text;
                string check = "    -   -";
                if (text != check)
                {
                    //panelLichSuHoaDon0.Visible = true;
                    dataGridView2.Visible = true;

                }
                else
                {
                    //panelLichSuHoaDon0.Visible = false;
                    dataGridView2.Visible = false;
                }

                LoadThongTinDB();
                LoadPhieuTieuTHU(txtSoDanhBo.Text.Replace("-", ""), int.Parse(txtNam.Text), DateTime.Now.Month);
                LoadLichSuHoaDon0(txtSoDanhBo.Text.Replace("-", ""));
                txtSoDanhBo.Focus();


            }

        }

        private void txtNgayGhiNhan_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string danhbo = txtSoDanhBo.Text.Replace("-", "");
            string sobangke = txtSoBangKe_Thongtin.Text;
            string chisoky = cbChiSoKy.Text;
            string dot = cbDot.Text;
            //DK_GIAMHOADON ghd = new DK_GIAMHOADON();
            //ghd.DHN_DANHBO = danhbo;
            //ghd.DHN_SOBANGKE = sobangke;
            string id = dgvThongTinHD_0.CurrentRow.Cells["ID"].Value.ToString();

            //string mess = "Xóa Danh Bộ  " + danhbo;
            //if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            int kq = DAL.QLDHN.C_HoaDon_0.DeleteThongTinTN(id);
            if (kq > 0)
            {
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh(); LoadData_ThongTin();
            }

            //}


        }
    

       


        DataSet ReportBaoThay(string sobangke)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();

            string query = "  SELECT [DHN_NGAYGHINHAN],[DHN_TODS], DHN_DANHBO,LOTRINH,SOTHANDH,HOTEN, SONHA + ' '+ TENDUONG AS DIACHI ";
            query += "  ,[DHN_LYDO] AS DHN_CAMKET,' ' AS DHN_BAMCHI,[DHN_GHICHU],DHN_DOT, DHN_KY,DHN_SOBANGKE,QUAN,CODH,NAM,'' AS DHN_HUYCAMKET ";
            query += "  FROM  DK_GIAMHOADON_TRONGAI TN, TB_DULIEUKHACHHANG KH ";
            query += "  WHERE TN.DHN_DANHBO=KH.DANHBO   AND DHN_SOBANGKE='" + txtSoBangKe_Thongtin.Text + "' ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TABLEHD");

            return ds;
        }



        private void btHuyCK_Click(object sender, EventArgs e)
        {


            ReportDocument rp = new rpt_TroNgai_HD_0();
            rp.SetDataSource(ReportBaoThay(this.txtSoBangKe_Thongtin.Text));
            rp.SetParameterValue("bangke", this.txtSoBangKe_Thongtin.Text);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextdanhbo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}