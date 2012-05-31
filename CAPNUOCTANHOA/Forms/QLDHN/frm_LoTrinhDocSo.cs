using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CAPNUOCTANHOA.LinQ;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.SODOCSO;
using CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh;
using CAPNUOCTANHOA.Forms.Reports;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_LoTrinhDocSo : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
        string connectionString2 = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile2"].ConnectionString;
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_LayDuLieuGanMoi_Ky).Name);

        public frm_LoTrinhDocSo()
        {
            InitializeComponent();
            //this.txtNam.Text = DateTime.Now.Year.ToString();
            //cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            tabItemPhienLoTrinh.Visible = false;
            tabSoDocSo.Visible = false;
            tabItem1.Visible = false;
            ItemGanMoi.Visible = false;
            tabItem2.Visible = false;
            if ("DT,DP".Contains(DAL.SYS.C_USERS._roles.Trim()))
            {
                tabItem1.Visible = true;
            }

            if ("TT".Contains(DAL.SYS.C_USERS._roles.Trim()))
            {
                tabItemPhienLoTrinh.Visible = true;
                tabSoDocSo.Visible = true;
                this.panel3.Controls.Clear();
                this.panel3.Controls.Add(new tab_ChiaLoTrinh());
                tabItem2.Visible = true;
                int ky = DateTime.Now.Month + 2;
                int nam = DateTime.Now.Year;
                if (ky >= 13)
                {
                    ky = 1;
                    nam = nam + 1;
                }
                SO_KY.Text = ky + "";
                SO_NAM.Text = nam + "";

            }
            if ("GM".Contains(DAL.SYS.C_USERS._roles.Trim()))
            {
                ItemGanMoi.Visible = true;
               
                try
                {
                    loadCombox();

                }
                catch (Exception ex)
                {
                    log.Error("Loi Ket Noi " + ex.Message);
                }
                
            }
             

            this.txtNam.Text = DateTime.Now.Year.ToString();
            try
            {
                cbKyDS.SelectedIndex = DateTime.Now.Month + 1;
            }
            catch (Exception)
            {

            }


        }
        /// <summary>
        /// SO DOC SO
        /// </summary>

        private void btXemSoDocSo_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.sods_LoTrinh.Text))
            {
                MessageBox.Show(this, "Nhập Lộ Trình Đọc Số.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.sods_LoTrinh.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_SoDocSo();
                rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.SoDocSo(sods_LoTrinh.Text));
                crystalReportViewer1.ReportSource = rp;
                this.crystalReportViewer1.Visible = true;

            }
        }
        private void sods_LoTrinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if ("".Equals(this.sods_LoTrinh.Text))
                {
                    MessageBox.Show(this, "Nhập Lộ Trình Đọc Số.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.sods_LoTrinh.Focus();
                }
                else
                {
                    ReportDocument rp = new rpt_SoDocSo();
                    rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.SoDocSo(sods_LoTrinh.Text));
                    crystalReportViewer1.ReportSource = rp;
                    this.crystalReportViewer1.Visible = true;

                }
            }
        }
        /// <summary>
        /// LAY THONG TIN GAN MOI
        /// </summary>
        #region Lấy Thông Tin Gắn Mới
        void formatRows()
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                dataGanMoiBK.Rows[i].Cells["STT"].Value = i + 1;
                if (i % 2 == 0)
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                string shs = dataGanMoiBK.Rows[i].Cells["SHS"].Value + "";
                string sql = "SELECT SoHo,SoNha,Duong FROM [T02 DANH SACH HO SO KHACH HANG] WHERE  SHS='" + shs + "' ";
                DataTable table = DAL.OledbConnection.getDataTable(connectionString2, sql);
                if (table.Rows.Count >= 1)
                {
                    dataGanMoiBK.Rows[i].Cells["SoHo"].Value = table.Rows[0]["SoHo"];
                    //MessageBox.Show(this, table.Rows[0]["SoHo"].ToString());
                    dataGanMoiBK.Rows[i].Cells["SONHA"].Value = table.Rows[0]["SoNha"];
                    dataGanMoiBK.Rows[i].Cells["DUONG"].Value = table.Rows[0]["Duong"];
                    dataGanMoiBK.Rows[i].Cells["HOTEN"].Value = (dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "").Replace(" (ÑD " + table.Rows[0]["SoHo"] + " hoä)", "");
                }
                try
                {
                    dataGanMoiBK.Rows[i].Cells["DANHBO"].Value = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "") : dataGanMoiBK.Rows[i].Cells["DANHBO"].Value;
                }
                catch (Exception)
                {

                }

                TB_GANMOI tb = DAL.DULIEUKH.C_GanMoi.finByDanhBo((dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "").Replace(" ", ""));
                if (tb != null)
                {
                    dataGanMoiBK.Rows[i].Cells["DOT"].Value = tb.DOT;
                    dataGanMoiBK.Rows[i].Cells["TODS"].Value = tb.TODS;
                    dataGanMoiBK.Rows[i].Cells["MAYDS"].Value = tb.MAYDS;
                }

            }
            //MessageBox.Show(this, "fdsafdsa");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string hieuluc = "";// cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + this.txtNam.Text;

            string sql = "SELECT SHS,danhbo, PLT,giabieu,dinhmuc,hieuluc,hopdong,HoTen, NGAYGANTLK, Hieu,coTLK,SOTLK,CHISOTLK ,maPQ FROM [T07 DANH SACH HO SO HOAN CONG] WHERE  danhbo <> '' AND hieuluc='" + hieuluc + "' ORDER BY hopdong ASC ";
            DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
            dataGanMoiBK.DataSource = table;
            formatRows();
        }

        private void next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                string DANHBO = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "";
                string HOPDONG = dataGanMoiBK.Rows[i].Cells["HOPDONG"].Value + "";
                string HOTEN = dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "";
                string SONHA = dataGanMoiBK.Rows[i].Cells["SONHA"].Value + "";
                string DUONG = dataGanMoiBK.Rows[i].Cells["DUONG"].Value + "";
                string MAQP = dataGanMoiBK.Rows[i].Cells["MAQP"].Value + "";
                string PLT = dataGanMoiBK.Rows[i].Cells["PLT"].Value + "";
                string GIABIEU = dataGanMoiBK.Rows[i].Cells["GIABIEU"].Value + "";
                string DINHMUC = dataGanMoiBK.Rows[i].Cells["DINHMUC"].Value + "";
                string hieuluc = dataGanMoiBK.Rows[i].Cells["hieuluc"].Value + "";
                string NGAYGANTLK = dataGanMoiBK.Rows[i].Cells["NGAYGANTLK"].Value + "";
                string HIEU = (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "").Equals("") ? "KEN" : (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "");
                string COTLK = dataGanMoiBK.Rows[i].Cells["COTLK"].Value + "";
                string SOTLK = dataGanMoiBK.Rows[i].Cells["SOTLK"].Value + "";
                string CHISOTLK = dataGanMoiBK.Rows[i].Cells["CHISOTLK"].Value + "";
                string SoHo = dataGanMoiBK.Rows[i].Cells["SoHo"].Value + "";
                VniToUnicode.ClassViToUnicode vn = new VniToUnicode.ClassViToUnicode();

                string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC) VALUES ";
                insert += "('" + DANHBO + "','" + HOPDONG + "','" + vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "") + "','" + vn.VniToKD(SONHA).ToUpper() + "','" + vn.VniToKD(DUONG).ToUpper() + "','" + MAQP.Substring(0, 2) + "','" + MAQP.Substring(2) + "','" + GIABIEU + "','" + DINHMUC + "','" + NGAYGANTLK + "','" + DateTime.Parse(NGAYGANTLK) + "','" + HIEU + "','" + COTLK + "','" + SOTLK.ToUpper() + "','0')";

                log.Info(DANHBO + "-----" + vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", ""));
                DAL.LinQConnection.ExecuteCommand(insert);


                //TB_DULIEUKHACHHANG tb = new TB_DULIEUKHACHHANG();
                //tb.DANHBO = DANHBO; 
                //tb.HOPDONG = HOPDONG; 
                //tb.HOTEN =  vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "")
                //tb.SONHA = SONHA;
                //tb.TENDUONG = vn.VniToKD(DUONG).ToUpper(); 
                //tb.QUAN = MAQP.Substring(0, 2); 
                //tb.PHUONG = MAQP.Substring(2);
                //tb.GIABIEU = GIABIEU; 
                //tb.DINHMUC = DINHMUC;
                //tb.NGAYGANDH = NGAYGANTLK;
                //tb.NGAYTHAY = DateTime.Parse(NGAYGANTLK);
                //tb.HIEUDH = "".Equals(HIEU) ? "KEN" : HIEU;
                //tb.CODH = COTLK;
                //tb.SOTHANDH = SOTLK.ToUpper(); 
                //tb.CHISOKYTRUOC = "0";
                //log.Info(tb.DANHBO + "----" + tb.HOTEN);
                //DAL.DULIEUKH.C_DuLieuKhachHang.Insert(tb);


            }

            MessageBox.Show(this, "Thanh Cong");
        }

        void loadCombox()
        {
            string sql = "SELECT DotThiCong FROM [T07 DANH SACH HO SO HOAN CONG] WHERE RIGHT (DotThiCong,2)>='12' AND LEFT (DotThiCong,1)='Q' AND Instr (DotThiCong, 'D')<>5 GROUP BY  DotThiCong";
            DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
            cbDotBangKe.DataSource = table;
            cbDotBangKe.DisplayMember = "DotThiCong";
            cbDotBangKe.ValueMember = "DotThiCong";
            //foreach (var item in table.Rows)
            //{
            //    DataRow r = (DataRow)item;
            //    namesCollection.Add(r["DotThiCong"].ToString());
            //}
            //cbDotBangKe.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cbDotBangKe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbDotBangKe.AutoCompleteCustomSource = namesCollection;
        }

        private void ItemGanMoi_Click(object sender, EventArgs e)
        {
            try
            {
                loadCombox();

            }
            catch (Exception ex)
            {
                log.Error("Loi Ket Noi " + ex.Message);
            }
        }

        int rowIndex = 0;

        private void btLoadThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT SHS,danhbo, PLT,giabieu,dinhmuc,hieuluc,hopdong,HoTen, NGAYGANTLK, Hieu,coTLK,SOTLK,CHISOTLK ,maPQ FROM [T07 DANH SACH HO SO HOAN CONG] WHERE DotThiCong='" + cbDotBangKe.Text + "' AND danhbo <> '' ORDER BY danhbo ASC ";
                DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
                dataGanMoiBK.DataSource = table;
                formatRows();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void dataGanMoiBK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                rowIndex = i;
                string DANHBO = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "";
                txtSHS.Text = dataGanMoiBK.Rows[i].Cells["SHS"].Value + "";
                string HOPDONG = dataGanMoiBK.Rows[i].Cells["HOPDONG"].Value + "";
                string HOTEN = dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "";
                string SONHA = dataGanMoiBK.Rows[i].Cells["SONHA"].Value + "";
                string DUONG = dataGanMoiBK.Rows[i].Cells["DUONG"].Value + "";
                string MAQP = dataGanMoiBK.Rows[i].Cells["MAQP"].Value + "";
                string PLT = dataGanMoiBK.Rows[i].Cells["PLT"].Value + "";
                string GIABIEU = dataGanMoiBK.Rows[i].Cells["GIABIEU"].Value + "";
                string DINHMUC = dataGanMoiBK.Rows[i].Cells["DINHMUC"].Value + "";
                string hieuluc = dataGanMoiBK.Rows[i].Cells["hieuluc"].Value + "";
                string NGAYGANTLK = dataGanMoiBK.Rows[i].Cells["NGAYGANTLK"].Value + "";
                string HIEU = (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "").Equals("") ? "KEN" : (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "");
                string COTLK = dataGanMoiBK.Rows[i].Cells["COTLK"].Value + "";
                string SOTLK = dataGanMoiBK.Rows[i].Cells["SOTLK"].Value + "";
                string CHISOTLK = dataGanMoiBK.Rows[i].Cells["CHISOTLK"].Value + "";
                string SoHo = dataGanMoiBK.Rows[i].Cells["SoHo"].Value + "";

                //string DOT = dataGanMoiBK.Rows[i].Cells["DOT"].Value + "";
                //string TODS = dataGanMoiBK.Rows[i].Cells["TODS"].Value + "";
                //string MAYDS = dataGanMoiBK.Rows[i].Cells["MAYDS"].Value + "";
                DateTime ngayg = DateTime.Parse(NGAYGANTLK);
                if (DateTime.Now.Year - ngayg.Year < 3)
                {
                    this.txtNgayGan.Value = ngayg;

                    VniToUnicode.ClassViToUnicode vn = new VniToUnicode.ClassViToUnicode();
                    HOTEN = vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "");
                    SONHA = vn.VniToKD(SONHA).ToUpper();
                    DUONG = vn.VniToKD(DUONG).ToUpper();
                    string MAQUAN = MAQP.Substring(0, 2);
                    string MAPHUONG = MAQP.Substring(2, 2);

                    ///
                    this.txtDanhBo.Text = DANHBO.Replace(" ", "");
                    this.txtHopDong.Text = HOPDONG;

                    this.txtHieuLuc.Text = hieuluc;
                    this.txtGiaBieu.Text = GIABIEU;
                    this.txtDinhMuc.Text = DINHMUC;
                    this.txtSoHo.Text = SoHo;
                    this.txtHoTen.Text = HOTEN;
                    this.txtSoNha.Text = SONHA;
                    this.txtTenDuong.Text = DUONG;
                    this.txtPhuong.Text = MAPHUONG;
                    this.txtQuan.Text = MAQUAN;
                    this.txtHieuDH.Text = "".Equals(HIEU) ? "KENT" : HIEU;
                    this.txtCoTLK.Text = COTLK;
                    this.txtSoThan.Text = SOTLK;
                    this.txtCHISOTLK.Text = CHISOTLK;
                    this.txtLoTrinhTam.Text = "";

                }
                else {
                    this.txtDanhBo.Text = "";
                    this.txtHopDong.Text = "";

                    this.txtHieuLuc.Text = "";
                    this.txtGiaBieu.Text = "";
                    this.txtDinhMuc.Text = "";
                    this.txtSoHo.Text = "";
                    this.txtHoTen.Text = "";
                    this.txtSoNha.Text = "";
                    this.txtTenDuong.Text = "";
                    this.txtPhuong.Text = "";
                    this.txtQuan.Text = "";
                    this.txtHieuDH.Text = "";
                    this.txtCoTLK.Text = "";
                    this.txtSoThan.Text = "";
                    this.txtCHISOTLK.Text = "";
                    this.txtLoTrinhTam.Text = "";
                    MessageBox.Show(this, "Lỗi Load Dữ Liệu !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(this, "Lỗi Load Dữ Liệu !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string SHS = this.txtSHS.Text;
                string DANHBO = this.txtDanhBo.Text.Replace("-", "");
                string HOPDONG = this.txtHopDong.Text;
                DateTime NGAYGAN = this.txtNgayGan.Value;
                string HIEULUC = this.txtHieuLuc.Text;
                string GIABIEU = this.txtGiaBieu.Text;
                string DINHMUC = this.txtDinhMuc.Text;
                string SOHO = this.txtSoHo.Text;
                string HOTEN = this.txtHoTen.Text;
                string SONHA = this.txtSoNha.Text;
                string DUONG = this.txtTenDuong.Text;
                string PHUONG = this.txtPhuong.Text;
                string QUAN = this.txtQuan.Text;
                string HIEU = this.txtHieuDH.Text;
                string COTLK = this.txtCoTLK.Text;
                string SOTLK = this.txtSoThan.Text;
                string CHISOTLK = this.txtCHISOTLK.Text;
                string MAYDS = "0";
                string DOTDS = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
                string TODS = "TB01";
                string LOTRINH = this.txtLoTrinhTam.Text;
                int tods = 1;
                if (this.cbToDocSo.SelectedIndex == 1)
                {
                    TODS = "TB02";
                    tods = 2;
                }
                else if (this.cbToDocSo.SelectedIndex == 2)
                {
                    tods = 3;
                    TODS = "TP";
                }
                else
                {
                    tods = 1;
                    TODS = "TB01";
                }
                if (DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(DANHBO) == null && "".Equals(LOTRINH.Replace(" ", "")) == false)
                {

                    TB_GANMOI tb = DAL.DULIEUKH.C_GanMoi.finByDanhBo(DANHBO);
                    if (tb == null)
                    {
                        tb = new TB_GANMOI();
                        tb.SHS = SHS;
                        tb.DANHBO = DANHBO;
                        tb.HOPDONG = HOPDONG;
                        tb.HOTEN = HOTEN;
                        tb.SONHA = SONHA;
                        tb.DUONG = DUONG;
                        tb.MAPHUONG = PHUONG;
                        tb.MAQUAN = QUAN;
                        tb.GIABIEU = GIABIEU;
                        tb.DINHMUC = DINHMUC;
                        tb.HIEULUC = HIEULUC;
                        tb.NGAYGANTLK = NGAYGAN;
                        tb.HIEU = HIEU;
                        tb.COTLK = COTLK;
                        tb.SOTLK = SOTLK;
                        tb.CHISOTLK = CHISOTLK;
                        tb.SOHO = SOHO;
                        tb.TODS = TODS;
                        tb.DOT = DOTDS;
                        tb.PLT = LOTRINH;
                        tb.MAYDS = MAYDS;
                        VniToUnicode.ClassViToUnicode vn = new VniToUnicode.ClassViToUnicode();
                  
                        tb.BANGKE = vn.VniToKD(cbDotBangKe.Text).ToUpper();  
                        tb.CREATEDATE = DateTime.Now;
                        tb.CREATEBY = DAL.SYS.C_USERS._userName;
                        if (DAL.DULIEUKH.C_GanMoi.Insert(tb))
                        {
                            int ky = DateTime.Now.Month + 1;
                            int nam = DateTime.Now.Year;
                            try
                            {
                                ky = int.Parse(tb.HIEULUC.Substring(0, 2));
                                nam = int.Parse(tb.HIEULUC.Substring(3, 4));
                            }
                            catch (Exception)
                            {

                            }
                            /////
                            DAL.OledbConnection.ExecuteCommand_UpdatLoTrinh(connectionString, DANHBO, LOTRINH);

                            ////
                            string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC,CODE, KY,NAM,LOTRINH) VALUES ";
                            insert += "('" + DANHBO + "','" + HOPDONG + "','" + HOTEN + "','" + SONHA + "','" + DUONG + "','" + QUAN + "','" + PHUONG + "','" + GIABIEU + "','" + DINHMUC + "','" + NGAYGAN + "','" + NGAYGAN + "','" + HIEU + "','" + COTLK + "','" + tb.SOTLK + "','" + CHISOTLK + "','M','" + ky + "','" + nam + "','" + LOTRINH + "')";
                            if (DAL.LinQConnection.ExecuteCommand_(insert) > 0)
                            {
                                log.Info("GM - " + DANHBO+"");
                              //int may = int.Parse(cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString());
                              //int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                              // inset Table Doc So
                              //  string insertGM = "INSERT INTO KHACHHANG (MAQUAN,MAPHUONG,TODS, MAY, DOT, DANHBA, HOPDONG, TENKH, SO, DUONG, GB, DM, TILESH, TILEHCSN, TILESX, TILEKD, MALOTRINH,MALOTRINH2, HIEULUCKY, NAM, NGAYGAN, CHISO, TIEUTHU, CODE,HIEU,SOTHAN)";
                              //  insertGM += " VALUES ('" + QUAN + "','" + PHUONG + "','" + tods + "','" + may + "','" + dot + "','" + DANHBO + "','" + HOPDONG + "','" + HOTEN + "','" + SONHA + "','" + DUONG + "'," + GIABIEU + "," + DINHMUC + ",0,0,0,0,'" + LOTRINH + "','" + LOTRINH + "','" + HIEULUC + "','" + NGAYGAN.Year + "','" + NGAYGAN + "'," + CHISOTLK + ",0,'M','" + HIEU + "','" + SOTLK + "')";
                              // log.Error(insertGM);
                              //  DAL.DULIEUKH.C_GanMoi.InsertDocSo_(insertGM);
                                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(this, "Kiểm Tra Sai Dữ Liệu ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tb.HOPDONG = HOPDONG;
                        tb.HOTEN = HOTEN;
                        tb.SONHA = SONHA;
                        tb.DUONG = DUONG;
                        tb.MAPHUONG = PHUONG;
                        tb.MAQUAN = QUAN;
                        tb.GIABIEU = GIABIEU;
                        tb.DINHMUC = DINHMUC;
                        tb.HIEULUC = HIEULUC;
                        tb.NGAYGANTLK = NGAYGAN;
                        tb.HIEU = HIEU;
                        tb.COTLK = COTLK;
                        tb.SOTLK = SOTLK;
                        tb.CHISOTLK = CHISOTLK;
                        tb.SOHO = SOHO;
                        tb.TODS = TODS;
                        tb.PLT = LOTRINH;
                        tb.DOT = DOTDS;
                        tb.MAYDS = MAYDS;
                        tb.MODIFYDATE = DateTime.Now;
                        tb.MODIFYBY = DAL.SYS.C_USERS._userName;
                        if (DAL.DULIEUKH.C_GanMoi.Update())
                        {
                            MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    try
                    {
                        dataGanMoiBK.Rows[rowIndex].Cells["DOT"].Value = DOTDS;
                        dataGanMoiBK.Rows[rowIndex].Cells["TODS"].Value = TODS;
                        dataGanMoiBK.Rows[rowIndex].Cells["MAYDS"].Value = MAYDS;
                        dataGanMoiBK.Rows[rowIndex].Cells["PLT"].Value = LOTRINH;
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show(this, "Danh Bộ Đã Tồn Tại Hoặc Lộ Trình Không Được Trống !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        #endregion





        #region Chia Lộ Trình Động

        private void tabItem6_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(new tab_ChiaLoTrinh());

        }
        #endregion

        private void cbMayDocSo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtLoTrinhTam.Text = "";
                int t1 = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                int t2 = int.Parse(cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString());

                if (t2 < 15)
                {
                    this.cbToDocSo.SelectedIndex = 0;
                }
                else if (t2 > 15 && t2 < 30)
                {
                    this.cbToDocSo.SelectedIndex = 1;
                }
                else if (t2 > 30)
                {
                    this.cbToDocSo.SelectedIndex = 2;

                }
                string dot = t1 + "";
                if (t1 < 10)
                {
                    dot = "0" + t1;
                }
                string may = t2 + "";
                if (t2 < 10)
                {
                    may = "0" + t2;
                }
                DataTable table = DAL.DULIEUKH.C_GanMoi.getMaxLoTrinh(dot + may);
                string lotrinh = (int.Parse(table.Rows[0][0] + "") + 1) + "";
                if (lotrinh.Length < 9)
                {
                    lotrinh = "0" + lotrinh;
                }
                this.txtLoTrinhTam.Text = lotrinh;
            }
            catch (Exception)
            {
                this.txtLoTrinhTam.Text = "";
            }

        }

        private void cbDotDS_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtLoTrinhTam.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btCapNhatLoTrinhMoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Cảnh Báo Chuyển Đi !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int KY = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int NAM = int.Parse(this.txtNam.Text);
                try
                {
                    ReportDocument rp = new rpt_DieuChinhLoTrinh();
                    rp.SetDataSource(DAL.DULIEUKH.C_PhienLoTrinh.getReportDieuChinh(KY, NAM));
                    frm_Reports frm = new frm_Reports(rp);
                    frm.ShowDialog();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string danhbo = dataGridView1.Rows[i].Cells["DC_DANHBO"].Value + "";
                        DAL.LinQConnection.ExecuteCommand("UPDATE TB_YEUCAUDC SET DACHUYEN='True', NGAYCHUYEN=GETDATE() ,CREATEBY='Chuyen " + DAL.SYS.C_USERS._userName + " ' WHERE DANHBO='" + danhbo.Replace(" ", "") + "' AND KY='" + KY + "' AND NAM='" + NAM + "'");
                    }
                    dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT DANHBO,LTCU  ,LTMOI  FROM TB_YEUCAUDC WHERE KY ='" + KY + "' AND NAM='" + NAM + "' AND DACHUYEN ='False'  ORDER BY LTCU ASC");
                    setSTT();
                    Utilities.DataGridV.formatRows(dataGridView1, "DC_DANHBO");
                }
                catch (Exception)
                {

                }

            }


        }
        public void setSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["DC_STT"].Value = i + 1;
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            int KY = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int NAM = int.Parse(this.txtNam.Text);
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT DANHBO,LTCU  ,LTMOI  FROM TB_YEUCAUDC WHERE KY ='" + KY + "' AND NAM='" + NAM + "' AND DACHUYEN ='False'  ORDER BY LTCU ASC");
            setSTT();
            Utilities.DataGridV.formatRows(dataGridView1, "DC_DANHBO");
        }

        private void dataGanMoiBK_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                dataGanMoiBK.Rows[i].Cells["STT"].Value = i + 1;
                if (i % 2 == 0)
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }

                try
                {
                    dataGanMoiBK.Rows[i].Cells["DANHBO"].Value = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "") : dataGanMoiBK.Rows[i].Cells["DANHBO"].Value;
                }
                catch (Exception)
                {
                }
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Cảnh Báo Chuyển Đi !", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int KY = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int NAM = int.Parse(this.txtNam.Text);
                try
                {
                    result.Text = "Đường dẫn lưu file : " + Export.export(dataGridView1);

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string danhbo = dataGridView1.Rows[i].Cells["DC_DANHBO"].Value + "";
                        DAL.LinQConnection.ExecuteCommand("UPDATE TB_YEUCAUDC SET DACHUYEN='True', NGAYCHUYEN=GETDATE() ,CREATEBY='Chuyen " + DAL.SYS.C_USERS._userName + " ' WHERE DANHBO='" + danhbo.Replace(" ", "") + "' AND KY='" + KY + "' AND NAM='" + NAM + "'");
                    }
                    dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT DANHBO,LTCU  ,LTMOI  FROM TB_YEUCAUDC WHERE KY ='" + KY + "' AND NAM='" + NAM + "' AND DACHUYEN ='False'  ORDER BY LTCU ASC");
                    setSTT();
                    Utilities.DataGridV.formatRows(dataGridView1, "DC_DANHBO");
                }
                catch (Exception)
                {

                }

            }        

            
        }

        private void dataGanMoiBK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            string quan = DAL.SYS.C_USERS._gioihan;
            string sql = "SELECT LOTRINH ";
            sql += "FROM  TB_DULIEUKHACHHANG WHERE LOTRINH IS NOT NULL " + quan + "  GROUP BY LOTRINH HAVING COUNT(LOTRINH)>=2 ORDER BY LOTRINH ASC ";
                  dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT_2();
        }

        private void dataBangKe_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT_2();
        }
        public void setSTT_2()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["G_STT"].Value = i + 1;
                try
                {
                    dataBangKe.Rows[i].Cells["LOTRINH"].Value = dataBangKe.Rows[i].Cells["LOTRINH"].Value != null ? Utilities.FormatSoHoSoDanhBo.phienlotrinh(dataBangKe.Rows[i].Cells["LOTRINH"].Value + "", ".") : dataBangKe.Rows[i].Cells["LOTRINH"].Value;
                }
                catch (Exception)
                {

                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string quan = DAL.SYS.C_USERS._gioihan;
            string sql = "SELECT LOTRINH ";
            sql += "FROM  TB_DULIEUKHACHHANG WHERE LOTRINH IS NOT NULL " + quan + "  GROUP BY LOTRINH HAVING COUNT(LOTRINH)>=2 ORDER BY LOTRINH ASC ";
            dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT_2();
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            int ky = DateTime.Now.Month + 2;
            int nam = DateTime.Now.Year;
            if (ky >= 13)
            {
                ky = 1;
                nam = nam + 1;
            }
            SO_KY.Text = ky+"";
            SO_NAM.Text = nam+"";
        }

        private void btSoGanMoi_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.SO_LT.Text))
            {
                MessageBox.Show(this, "Nhập Lộ Trình Đọc Số.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.SO_LT.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_SoDocSo_GANMOI();
                rp.SetDataSource(DAL.DULIEUKH.C_DuLieuKhachHang.SoDocSo_GM(SO_LT.Text, SO_KY.Text, SO_NAM.Text));
                rp.SetParameterValue("HIEULUC",String.Format("{0:00}",int.Parse(SO_KY.Text)) + "/" + SO_NAM.Text);
                crystalReportViewer2.ReportSource = rp;
                this.crystalReportViewer2.Visible = true;

            }
        }
    }
}