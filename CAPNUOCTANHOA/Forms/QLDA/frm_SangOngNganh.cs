using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.DAL;
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.QLDA
{
    public partial class frm_SangOngNganh : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_SangOngNganh).Name);
        public frm_SangOngNganh()
        {
            InitializeComponent();
            //this.cbLoaiBangKe.Focus(); 
            formLoad();
            txtCapGan.SelectedIndex = 0;
            cbLoaiDHN.SelectedIndex = 0;

        }

        void formLoad() {

            //cbLoaiBangKe.DataSource = LinQConnection.getDataTable("SELECT * FROM TB_LOAIBANGKE WHERE LOAIBK='MA'");
            //cbLoaiBangKe.ValueMember="LOAIBK";
            //cbLoaiBangKe.DisplayMember = "TENBANGKE";
            //cbLoaiBangKe.SelectedValue = "MA";


            DataTable table2 = DAL.LinQConnection.getDataTable("SELECT MACHI FROM TB_MACHI");
            comboBox1.DataSource = table2;
            comboBox1.DisplayMember = "MACHI";
            comboBox1.ValueMember = "MACHI";


            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            txtHieu.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieu.AutoCompleteCustomSource = namesCollection;
            try
            {
                string balap =  DateTime.Now.Year.ToString().Substring(2)+"001";
                if (DAL.QLDHN.C_BaoThay.getMaxBangKe() >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
                }
                else {
                    txtSoBangKe.Text = balap;
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public void setSTT() {
            for (int i = 0; i < dataBangKe.Rows.Count; i++) {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        private void btIn_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else {
                ReportDocument rp = new rpt_BCHoanCong_A4_DA();
                DataSet ds = DAL.QLDHN.C_BaoThay.ReportBaoThay(txtSoBangKe.Text);
                rp.SetDataSource(ds);
               // rp.SetParameterValue("lapbk", DAL.SYS.C_USERS._fullName);
               //// rp.SetParameterValue("tc", ds.Tables["V_DHN_BANGKE"].Rows.Count);
               // rp.SetParameterValue("TT", txtCongTrinh.Text);                
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void cbLoaiBangKe_SelectedValueChanged(object sender, EventArgs e)
        {
            //if ("HC".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //{
            //    title.Text = "BẢNG KÊ BÁO THAY HẠ CỞ ĐỒNG HỒ NƯỚC ";
            //    txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            //}
            //else if ("TH".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //{
            //    title.Text = "BẢNG KÊ BÁO THAY THỬ ĐỒNG HỒ NƯỚC";
            //    txtLyDo.Text = this.cbLoaiBangKe.Text.Replace("THEO", "");
            //}
            //else if ("BB".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            //{
            //    title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC THEO BIÊN BẢN KIỂM TRA";
            //    txtLyDo.Text = "BBKT NGÀY ";
            //}
            //else
            //{
            //    title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC " + this.cbLoaiBangKe.Text;
            //    txtLyDo.Text = "DMA";
            //}
          //  txtSoBangKe.Focus();
         
        }

        public void LoadData() {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay_ON(int.Parse(txtSoBangKe.Text.Trim()));
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                  log.Error("Loi Load Du Lieu Thay "+ ex.Message);
            }
          
        }

        public void LoadData_DT()
        {
            try
            {
                dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay(txtSoBangKe.Text.Trim());
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                {
                    LoadData_DT();
                }
                else {
                    LoadData();
                }
                
                //btIn.Enabled = true;
            }
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string DHN_LOAIBANGKE = dataBangKe.Rows[e.RowIndex].Cells["DHN_LOAIBANGKE"].Value + "";
                string DHN_SOBANGKE = dataBangKe.Rows[e.RowIndex].Cells["DHN_SOBANGKE"].Value + "";
                string ID_BAOTHAY = dataBangKe.Rows[e.RowIndex].Cells["ID_BAOTHAY"].Value + "";
                string DHN_STT = dataBangKe.Rows[e.RowIndex].Cells["DHN_STT"].Value + "";
                string DHN_DANHBO = dataBangKe.Rows[e.RowIndex].Cells["G_DANHBO"].Value + "";
                string HOTEN = dataBangKe.Rows[e.RowIndex].Cells["G_TENKH"].Value + "";
                string DIACHI = dataBangKe.Rows[e.RowIndex].Cells["G_DIACHI"].Value + "";
                string DHN_NGAYBAOTHAY = dataBangKe.Rows[e.RowIndex].Cells["DHN_NGAYBAOTHAY"].Value + "";
                string DHN_NGAYGAN = dataBangKe.Rows[e.RowIndex].Cells["DHN_NGAYGAN"].Value + "";
                string DHN_CHITHAN = dataBangKe.Rows[e.RowIndex].Cells["DHN_CHITHAN"].Value + "";
                string DHN_CHIGOC = dataBangKe.Rows[e.RowIndex].Cells["DHN_CHIGOC"].Value + "";
                string DHN_HIEUDHN = dataBangKe.Rows[e.RowIndex].Cells["G_HIEUDHN"].Value + "";
                string DHN_CODH = dataBangKe.Rows[e.RowIndex].Cells["G_CODHN"].Value + "";
                string DHN_SOTHAN = dataBangKe.Rows[e.RowIndex].Cells["G_SOTHAN"].Value + "";
                string DHN_CHISO = dataBangKe.Rows[e.RowIndex].Cells["G_CHISO"].Value + "";
                string DHN_LYDOTHAY = dataBangKe.Rows[e.RowIndex].Cells["G_LYDO"].Value + "";
                string DHN_GHICHU = dataBangKe.Rows[e.RowIndex].Cells["DHN_GHICHU"].Value + "";


                string HCT_CHISOGO = dataBangKe.Rows[e.RowIndex].Cells["HCT_CHISOGO"].Value + "";
                txtChiSoGo.Text = HCT_CHISOGO;

                string HCT_HIEUDHNGAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_HIEUDHNGAN"].Value + "";
                txtHieuDHGan.Text = !HCT_HIEUDHNGAN.Equals("") ? HCT_HIEUDHNGAN : ConfigurationManager.AppSettings["defautHieu"].ToString();

                string HCT_CODHNGAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_CODHNGAN"].Value + "";
                txtGoGan.Text = !HCT_CODHNGAN.Equals("") ? HCT_CODHNGAN : "15";

                string HCT_SOTHANGAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_SOTHANGAN"].Value + "";
                txtSoThanGan.Text = HCT_SOTHANGAN;

                string HCT_CAP = dataBangKe.Rows[e.RowIndex].Cells["HCT_CAP"].Value + "";
                txtCapGan.Text = !HCT_CAP.Equals("") ? HCT_CAP : ConfigurationManager.AppSettings["defautCap"].ToString();

                string HCT_CHISOGAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_CHISOGAN"].Value + "";
                txtChiSoGan.Text = !HCT_CHISOGAN.Equals("") ? HCT_CHISOGAN : "0"; ;


                string HCT_NGAYGAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_NGAYGAN"].Value + "";
                txtngayGanDh.Value = !"".Equals(HCT_NGAYGAN) ? DateTime.Parse(HCT_NGAYGAN) : DateTime.Now.AddDays(-1);

                string HCT_NGAYKIEMDINH = dataBangKe.Rows[e.RowIndex].Cells["HCT_NGAYKIEMDINH"].Value + "";
                txtngayKiemDinh.Value = !"".Equals(HCT_NGAYKIEMDINH) ? DateTime.Parse(HCT_NGAYKIEMDINH) : DateTime.Now;


                string HCT_CHITHAN = dataBangKe.Rows[e.RowIndex].Cells["HCT_CHITHAN"].Value + "";
                txtChiThan.Text = !HCT_CHITHAN.Equals("") ? HCT_CHITHAN : "CON";

                string HCT_CHIGOC = dataBangKe.Rows[e.RowIndex].Cells["HCT_CHIGOC"].Value + "";
                txtChiGoc.Text = !HCT_CHITHAN.Equals("") ? HCT_CHITHAN : "CON";


                txtSoDanhBo.Text = DHN_DANHBO.Replace(" ", "");
                txtTenKH.Text = HOTEN;
                txtDiaChi.Text = DIACHI;
                txtNgayGan.ValueObject = DHN_NGAYGAN;
                txtHieu.Text = DHN_HIEUDHN;
                txtCo.Text = DHN_CODH;
                txtSoThan.Text = DHN_SOTHAN;
                txtChiThan.Text = DHN_CHITHAN;
                txtChiGoc.Text = DHN_CHIGOC;
                txtChiSoThay.Text = DHN_CHISO;
                txtLyDo.Text = DHN_LYDOTHAY;
                txtGhiChu.Text = DHN_GHICHU;
                try
                {
                    txtMaLoTrinh.Text = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(DHN_DANHBO.Replace(" ","").Replace("-","")).LOTRINH;
                }
                catch (Exception)
                {
                }

                btcapNhat.Enabled = true;
                btXoa.Enabled = true;
            }
            catch (Exception)
            {
                 
            }
            
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            
        }

        void LoadThongTinDB() {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
                if (table.Rows.Count > 0)
                {
                    histotyThay.DataSource = table;
                    histotyThay.Visible = true;
                    //resultBT.Visible = true;
                    //resultBT.Text = "CÓ " + table.Rows.Count + " LẦN THAY >>";
                }
                else
                {
                    histotyThay.Visible = false;
                    //resultBT.Visible = false;
                }
                TB_DULIEUKHACHHANG khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    txtTenKH.Text = khachhang.HOTEN;
                    txtDiaChi.Text = khachhang.SONHA + " " + khachhang.TENDUONG;
                    txtNgayGan.ValueObject = khachhang.NGAYTHAY;
                    TB_HIEUDONGHO hieudh=null;
                    try
                    {
                        hieudh = DAL.QLDHN.C_BaoThay.finByHieuDH(khachhang.HIEUDH.Substring(0, 3));
                    }
                    catch (Exception)
                    {
                    }
                    txtHieu.Text = hieudh != null ? hieudh.TENDONGHO : khachhang.HIEUDH;
                    txtCo.Text = khachhang.CODH;
                    txtSoThan.Text = khachhang.SOTHANDH;
                    txtChiThan.Text = "CON";
                    txtChiGoc.Text = "CON";
                    txtChiSoThay.Text = khachhang.CHISOKYTRUOC;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    txtDot.Text = khachhang.DOT;
                    txtMaLoTrinh.Text = khachhang.LOTRINH;
                }
            }
        }
        private void txtSoDanhBo_Leave(object sender, EventArgs e)
        {
            LoadThongTinDB();
        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            histotyThay.Visible = false;
            histotyThay.Visible = false;
           //resultBT.Visible = false;
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
                txtChiSoGo.Focus();
               
            }
        }

        public void Add()
        {

            List<TB_DULIEUKHACHHANG> cothantrung = DAL.DULIEUKH.C_DuLieuKhachHang.getSoThanDHN(this.txtSoThanGan.Text.Replace(" ", ""), this.txtHieuDHGan.Text.Substring(0, 3));
            if (cothantrung.Count > 0)
            {
                if (this.txtSoDanhBo.Text.Replace("-", "").Equals(cothantrung[0].DANHBO))
                {
                    string danhbo = "";
                    foreach (var item in cothantrung)
                    {
                        danhbo += item.DANHBO + ",";
                    }
                    MessageBox.Show(this, "Số Thân Hiện Gắn Mới Trùng Danh Bộ " + danhbo + " Không Cho Cập Nhật.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ////////////////
                if (int.Parse(txtChiSoThay.Text) <= int.Parse(txtChiSoGo.Text))
                {

                    TB_THAYDHN thaydh = new TB_THAYDHN();
                    thaydh.DHN_CHIGOC = this.txtChiGoc.Text.ToUpper();
                    thaydh.DHN_CHISO = int.Parse(this.txtChiSoThay.Text.Trim());
                    thaydh.DHN_CHITHAN = this.txtChiThan.Text.ToUpper();
                    thaydh.DHN_CODH = this.txtCo.Text;
                    thaydh.DHN_DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
                    thaydh.DHN_DOT = this.txtDot.Text;
                    thaydh.DHN_HIEUDHN = this.txtHieu.Text.ToUpper();
                    thaydh.DHN_LANTHAY = 1;
                    thaydh.DHN_LOAIBANGKE = "MA";
                    thaydh.DHN_LYDOTHAY = this.txtLyDo.Text.ToUpper();
                    thaydh.DHN_NGAYBAOTHAY = DateTime.Now.Date;
                    thaydh.DHN_NGAYGAN = txtNgayGan.Value;
                    thaydh.DHN_SOBANGKE = int.Parse(this.txtSoBangKe.Text.Trim());
                    thaydh.DHN_SOTHAN = this.txtSoThan.Text.ToUpper();
                    thaydh.DHN_STT = dataBangKe.Rows.Count + 1;
                    thaydh.DHN_LYDOTHAY = this.txtLyDo.Text;
                    thaydh.DHN_GHICHU = this.txtGhiChu.Text;
                    thaydh.DHN_TODS = DAL.SYS.C_USERS._toDocSo;
                    thaydh.DHN_CREATEBY = DAL.SYS.C_USERS._userName;
                    thaydh.DHN_CREATEDATE = DateTime.Now.Date;

                    //////////////
                    thaydh.HCT_CHISOGO = txtChiSoGo.Text != null ? int.Parse(txtChiSoGo.Text.Trim()) : 0;
                    thaydh.HCT_SOTHANGO = txtSoThan.Text;
                    thaydh.HCT_HIEUDHNGAN = txtHieuDHGan.Text;
                    thaydh.HCT_SOTHANGAN = txtSoThanGan.Text;
                    thaydh.HCT_CODHNGAN = txtGoGan.Text;
                    thaydh.HCT_CAP = txtCapGan.Text.ToUpper();
                    thaydh.HCT_CHISOGAN = txtChiSoGan.Text != null ? int.Parse(txtChiSoGan.Text.Trim()) : 0;
                    if (cbLoaiDHN.SelectedIndex == 0)
                    {
                        thaydh.HCT_LOAIDHGAN = true;
                    }
                    else
                    {
                        thaydh.HCT_LOAIDHGAN = false;
                    }
                    thaydh.HCT_NGAYGAN = txtngayGanDh.Value.Date;
                    thaydh.HCT_NGAYKIEMDINH = txtngayKiemDinh.Value.Date;
                    thaydh.HCT_CHITHAN = txtChiThan.Text.ToUpper();
                    thaydh.HCT_CHIGOC = txtChiGoc.Text.ToUpper();
                    thaydh.HCT_TRONGAI = false;
                    thaydh.HCT_LYDOTRONGAI = "";
                    thaydh.HCT_CREATEBY = DAL.SYS.C_USERS._userName;
                    thaydh.HCT_CREATEDATE = DateTime.Now.Date;
                   
                    if (DAL.QLDHN.C_BaoThay.InsertDA(thaydh))
                    {
                        try
                        {
                            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtSoDanhBo.Text.Replace("-", ""));
                            if (kh != null )
                            {
                                kh.NGAYTHAY = txtngayGanDh.Value.Date;
                                kh.SOTHANDH = txtSoThanGan.Text;
                                kh.HIEUDH = txtHieuDHGan.Text;
                                kh.CODH = txtGoGan.Text;
                                kh.CAP = txtCapGan.Text.ToUpper();
                                kh.CHITHAN = txtChiThan.Text.ToUpper();
                                kh.CHIGOC = txtChiGoc.Text.ToUpper();
                                kh.NGAYKIEMDINH = txtngayKiemDinh.Value.Date;
                                kh.BAOTHAY = false;
                                DAL.DULIEUKH.C_DuLieuKhachHang.Update();

                                //Cap Nhat Du Lieu Cho HandHeld
                                try
                                {
                                    DAL.DULIEUKH.C_PhienLoTrinh.CapNhatThongTinHandHeld(this.txtSoDanhBo.Text.Replace("-", ""), txtHieuDHGan.Text.Substring(0, 3), txtSoThanGan.Text, txtChiThan.Text.ToUpper(), txtChiGoc.Text.ToUpper());
                                    string loai = "1";

                                    string sql = "INSERT INTO BAOTHAYDHN (DANHBA, TENKH, SO, DUONG, HIEUMOI, COMOI, NGAYTHAY, CSGO, CSGAN, SOTHANMOI, VITRIMOI, MACHITHAN, MACHIGOC, LOAI) " +
                                    " VALUES     ('" + this.txtSoDanhBo.Text.Replace("-", "") + "', " +
                                    " '" + kh.HOTEN.TrimEnd() + "', " +
                                    " '" + kh.SONHA.TrimEnd() + "' ," +
                                    " '" + kh.TENDUONG.TrimEnd() + "' , " +
                                    " '" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                    " " + kh.CODH + ", " +
                                    " '" + txtngayGanDh.Value + "', " +
                                    " " + txtChiSoGo.Text + "," +
                                    " " + txtChiSoGan.Text + ", " +
                                    " '" + txtSoThanGan.Text + "'," +
                                    " N'" + kh.VITRIDHN + "', " +
                                    " '" + txtChiThan.Text.ToUpper() + "'," +
                                    " '" + txtChiGoc.Text.ToUpper() + "', " +
                                    "  " + loai + ")";
                                    if (DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeld(sql) == 0)
                                    {

                                        sql = "UPDATE  BAOTHAYDHN  " +
                                        " SET  " +
                                        " TENKH='" + kh.HOTEN.TrimEnd() + "', " +
                                        " SO='" + kh.SONHA.TrimEnd() + "' ," +
                                        " DUONG='" + kh.TENDUONG.TrimEnd() + "' , " +
                                        " HIEUMOI='" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                        " COMOI=" + kh.CODH + ", " +
                                        " NGAYTHAY='" + txtngayGanDh.Value + "', " +
                                        " CSGO=" + txtChiSoGo.Text + "," +
                                        " CSGAN=" + txtChiSoGan.Text + ", " +
                                        " SOTHANMOI='" + txtSoThanGan.Text + "'," +
                                        " VITRIMOI=N'" + kh.VITRIDHN + "', " +
                                        " MACHITHAN='" + txtChiThan.Text.ToUpper() + "'," +
                                        " MACHIGOC='" + txtChiGoc.Text.ToUpper() + "', " +
                                        " LOAI=" + loai + " " +
                                        " WHERE DANHBA='" + kh.DANHBO + "' AND CONVERT(DATETIME,NGAYTHAY,103)='" + txtNgayGan.Value.ToShortDateString() + "'";
                                        DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeld(sql);
                                    }
                                    ///////////////////////////////////////////////////////////////////////////////////////////////

                                    if (DAL.LinQConnectionDSTH.getDataTable("SELECT * FROM BaoThay WHERE DanhBa='" + this.txtSoDanhBo.Text.Replace("-", "") + "' AND SoThanMoi='" + txtSoThanGan.Text + "' ").Rows.Count < 1)
                                    {
                                        sql = " INSERT INTO BaoThay(DanhBa,LoaiBT,NgayThay,HieuMoi,CoMoi,SoThanMoi,ViTriMoi,ChiThanMoi,ChiCoMoi,CSGo,CSGan,NgayCapNhat,NVCapNhat) ";
                                        //string sql = "INSERT INTO BAOTHAYDHN (DANHBA, TENKH, SO, DUONG, HIEUMOI, COMOI, NGAYTHAY, CSGO, CSGAN, SOTHANMOI, VITRIMOI, MACHITHAN, MACHIGOC, LOAI) " +
                                        sql += " VALUES ('" + this.txtSoDanhBo.Text.Replace("-", "") + "', " + loai + ",'" + txtNgayGan.Value.Date + "', " + " '" + txtHieuDHGan.Text.Substring(0, 3) + "', " + kh.CODH + ", " + " '" + txtSoThanGan.Text + "'," + " N'" + kh.VITRIDHN + "', ";
                                        sql += " '" + txtChiThan.Text.ToUpper() + "'," + " '" + txtChiGoc.Text.ToUpper() + "'," + txtChiSoGo.Text + "," + txtChiSoGan.Text + ", '" + DateTime.Now + "','" + DAL.SYS.C_USERS._userName + "' )";

                                        if (DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeldTH(sql) == 0)
                                        {

                                            sql = "UPDATE BaoThay " +
                                            " SET  " +
                                            " HieuMoi='" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                            " CoMoi=" + kh.CODH + ", " +
                                            " NgayThay='" + txtNgayGan.Value + "', " +
                                            " CSGo=" + txtChiSoGo.Text + "," +
                                            " CSGan=" + txtChiSoGan.Text + ", " +
                                            " SoThanMoi='" + txtSoThanGan.Text + "'," +
                                            " ViTriMoi=N'" + kh.VITRIDHN + "', " +
                                            " ChiThanMoi='" + txtChiThan.Text.ToUpper() + "'," +
                                            " ChiCoMoi='" + txtChiGoc.Text.ToUpper() + "', " +
                                            " LoaiBT=" + loai + ", " +
                                            " NgayCapNhat='" + DateTime.Now + " ', " +
                                            " NVCapNhat='" + DAL.SYS.C_USERS._userName + " ' " +
                                            " WHERE DanhBa='" + kh.DANHBO + "' AND CONVERT(DATETIME,NgayThay,103)='" + txtNgayGan.Value.ToShortDateString() + "'";
                                            DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeldTH(sql);
                                        }
                                    }



                                }
                                catch (Exception ex)
                                {
                                    log.Error("Cap Nhat Du Lieu Cho HandHeld : " + ex.Message);
                                    MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //// END

                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("Cap Nhat Ho So Khach Hang : " + ex.Message);
                            MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    refeshInser();
                    LoadData();
                }
                else
                {
                    MessageBox.Show(this, "Chỉ Số Gở >= Chỉ Số Thay", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }
    

        public void refeshInser() {

            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGan.ValueObject = null;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiThan.Text = "";
            txtChiGoc.Text = "";
            txtChiSoThay.Text = "";
            txtMaLoTrinh.Text = "";
           // btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            txtSoDanhBo.Focus();
           
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                    string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                    if ("".Equals(this.txtSoBangKe.Text))
                    {
                        MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtSoBangKe.Focus();
                    }
                    else if (sodanhbo.Length != 11)
                    {
                        MessageBox.Show(this, "Cần nhập số danh bộ .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtSoDanhBo.Focus();

                    }
                    else
                    {
                        Add();
                        
                       
                    }
            }
            catch (Exception ex)
            {
                log.Error("Them Bao Thay Ko Thanh Cong" + ex.Message);
            }
           
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_BAOTHAY = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                TB_THAYDHN thay = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY.Replace(" ","")));
                string mess = "Xóa Báo Thay Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thay.DHN_DANHBO, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.QLDHN.C_BaoThay.deleteBAOTHAY(thay);
                    if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        LoadData_DT();
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(  ex.Message);
            }
           
        }

        private void btcapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_BAOTHAY = dataBangKe.Rows[dataBangKe.CurrentRow.Index].Cells["ID_BAOTHAY"].Value + "";
                TB_THAYDHN thaydh = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY));
                string mess = "Cập Nhật Báo Thay Cho Danh Bộ  " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thaydh.DHN_DANHBO, "-") + " ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && thaydh!=null)
                {
                    thaydh.DHN_CHIGOC = this.txtChiGoc.Text;
                    thaydh.DHN_CHISO = int.Parse(this.txtChiSoThay.Text.Trim());
                    thaydh.DHN_CHITHAN = this.txtChiThan.Text;
                    thaydh.DHN_CODH = this.txtCo.Text;
                    thaydh.DHN_DANHBO = this.txtSoDanhBo.Text.Replace("-", "");
                    thaydh.DHN_HIEUDHN = this.txtHieu.Text;
                 //   thaydh.DHN_LOAIBANGKE = this.cbLoaiBangKe.SelectedValue + "";
                    thaydh.DHN_GHICHU = this.txtGhiChu.Text;
                    thaydh.DHN_LYDOTHAY = this.txtLyDo.Text;
                    thaydh.DHN_NGAYBAOTHAY = DateTime.Now.Date;
                    thaydh.DHN_NGAYGAN = txtNgayGan.Value;
                    thaydh.DHN_SOTHAN = this.txtSoThan.Text;
                    thaydh.DHN_MODIFYBY = DAL.SYS.C_USERS._userName;
                    thaydh.DHN_MODIFYDATE = DateTime.Now;
                    thaydh.DHN_GHICHU = this.txtGhiChu.Text;

                    thaydh.HCT_CHISOGO = txtChiSoGo.Text != null ? int.Parse(txtChiSoGo.Text.Trim()) : 0;
                    thaydh.HCT_SOTHANGO = txtSoThan.Text;
                    thaydh.HCT_HIEUDHNGAN = txtHieuDHGan.Text;
                    thaydh.HCT_SOTHANGAN = txtSoThanGan.Text;
                    thaydh.HCT_CODHNGAN = txtGoGan.Text;
                    thaydh.HCT_CAP = txtCapGan.Text.ToUpper();
                    thaydh.HCT_CHISOGAN = txtChiSoGan.Text != null ? int.Parse(txtChiSoGan.Text.Trim()) : 0;
                    if (cbLoaiDHN.SelectedIndex == 0)
                    {
                        thaydh.HCT_LOAIDHGAN = true;
                    }
                    else
                    {
                        thaydh.HCT_LOAIDHGAN = false;
                    }
                    thaydh.HCT_NGAYGAN = txtngayGanDh.Value.Date;
                    thaydh.HCT_NGAYKIEMDINH = txtngayKiemDinh.Value.Date;
                    thaydh.HCT_CHITHAN = txtChiThan.Text.ToUpper();
                    thaydh.HCT_CHIGOC = txtChiGoc.Text.ToUpper();
                    thaydh.HCT_TRONGAI = false;
                    thaydh.HCT_LYDOTRONGAI = "";
                    thaydh.HCT_MODIFYBY = DAL.SYS.C_USERS._userName;
                    thaydh.HCT_MODIFYDATE = DateTime.Now.Date;


                    if (DAL.QLDHN.C_BaoThay.Update())
                    {
                        try
                        {
                            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtSoDanhBo.Text.Replace("-", ""));
                            if (kh != null)
                            {
                                kh.NGAYTHAY = txtngayGanDh.Value.Date;
                                kh.SOTHANDH = txtSoThanGan.Text;
                                kh.HIEUDH = txtHieuDHGan.Text;
                                kh.CODH = txtGoGan.Text;
                                kh.CAP = txtCapGan.Text.ToUpper();
                                kh.CHITHAN = txtChiThan.Text.ToUpper();
                                kh.CHIGOC = txtChiGoc.Text.ToUpper();
                                kh.NGAYKIEMDINH = txtngayKiemDinh.Value.Date;
                                kh.BAOTHAY = false;
                                DAL.DULIEUKH.C_DuLieuKhachHang.Update();

                                //Cap Nhat Du Lieu Cho HandHeld
                                try
                                {
                                    DAL.DULIEUKH.C_PhienLoTrinh.CapNhatThongTinHandHeld(this.txtSoDanhBo.Text.Replace("-", ""), txtHieuDHGan.Text.Substring(0, 3), txtSoThanGan.Text, txtChiThan.Text.ToUpper(), txtChiGoc.Text.ToUpper());
                                    string loai = "1";

                                    string sql = "INSERT INTO BAOTHAYDHN (DANHBA, TENKH, SO, DUONG, HIEUMOI, COMOI, NGAYTHAY, CSGO, CSGAN, SOTHANMOI, VITRIMOI, MACHITHAN, MACHIGOC, LOAI) " +
                                    " VALUES     ('" + this.txtSoDanhBo.Text.Replace("-", "") + "', " +
                                    " '" + kh.HOTEN.TrimEnd() + "', " +
                                    " '" + kh.SONHA.TrimEnd() + "' ," +
                                    " '" + kh.TENDUONG.TrimEnd() + "' , " +
                                    " '" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                    " " + kh.CODH + ", " +
                                    " '" + txtngayGanDh.Value + "', " +
                                    " " + txtChiSoGo.Text + "," +
                                    " " + txtChiSoGan.Text + ", " +
                                    " '" + txtSoThanGan.Text + "'," +
                                    " N'" + kh.VITRIDHN + "', " +
                                    " '" + txtChiThan.Text.ToUpper() + "'," +
                                    " '" + txtChiGoc.Text.ToUpper() + "', " +
                                    "  " + loai + ")";
                                    if (DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeld(sql) == 0)
                                    {

                                        sql = "UPDATE  BAOTHAYDHN  " +
                                        " SET  " +
                                        " TENKH='" + kh.HOTEN.TrimEnd() + "', " +
                                        " SO='" + kh.SONHA.TrimEnd() + "' ," +
                                        " DUONG='" + kh.TENDUONG.TrimEnd() + "' , " +
                                        " HIEUMOI='" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                        " COMOI=" + kh.CODH + ", " +
                                        " NGAYTHAY='" + txtngayGanDh.Value + "', " +
                                        " CSGO=" + txtChiSoGo.Text + "," +
                                        " CSGAN=" + txtChiSoGan.Text + ", " +
                                        " SOTHANMOI='" + txtSoThanGan.Text + "'," +
                                        " VITRIMOI=N'" + kh.VITRIDHN + "', " +
                                        " MACHITHAN='" + txtChiThan.Text.ToUpper() + "'," +
                                        " MACHIGOC='" + txtChiGoc.Text.ToUpper() + "', " +
                                        " LOAI=" + loai + " " +
                                        " WHERE DANHBA='" + kh.DANHBO + "' AND CONVERT(DATETIME,NGAYTHAY,103)='" + txtNgayGan.Value.ToShortDateString() + "'";
                                        DAL.DULIEUKH.C_PhienLoTrinh.InsertBaoThayHandHeld(sql);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Cap Nhat Du Lieu Cho HandHeld : " + ex.Message);
                                    MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //// END

                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("Cap Nhat Ho So Khach Hang : " + ex.Message);
                            MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    

                    if ("DT,DP,AD".Contains(DAL.SYS.C_USERS._roles.Trim()))
                    {
                        LoadData_DT();
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
        }

        private void txtChiSoThay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoDanhBo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
                DataTable table = DAL.QLDHN.C_BaoThay.HistoryThay(sodanhbo);
                //if (table.Rows.Count > 0)
                //{
                //    histotyThay.DataSource = table;
                //    histotyThay.Visible = true;
                //    resultBT.Visible = true;
                //    resultBT.Text = "CÓ " + table.Rows.Count + " LẦN THAY >>";
                //}
                //else
                //{
                //    histotyThay.Visible = false;
                //    resultBT.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            
        }

        private void btTaoMoi_Click_1(object sender, EventArgs e)
        {
            //this.cbLoaiBangKe.SelectedValue = "DK";
            txtSoBangKe.Text = "";
            txtSoDanhBo.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtNgayGan.ValueObject = null;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiThan.Text = "";
            txtChiGoc.Text = "";
            txtChiSoThay.Text = "";
            txtMaLoTrinh.Text = "";
           // btcapNhat.Enabled = false;
            btXoa.Enabled = false;
            // btIn.Enabled = false;
            //this.histotyThay.Visible = false;
            txtSoBangKe.Focus();
            this.dataBangKe.DataSource = DAL.QLDHN.C_BaoThay.getBangKeBaoThay(999999);
            try
            {
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                if (DAL.QLDHN.C_BaoThay.getMaxBangKe() >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
                }
                else
                {
                    txtSoBangKe.Text = balap;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
