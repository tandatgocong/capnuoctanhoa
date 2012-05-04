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
                string sql = "SELECT SHS,danhbo, PLT,giabieu,dinhmuc,hieuluc,hopdong,HoTen, NGAYGANTLK, Hieu,coTLK,SOTLK,CHISOTLK ,maPQ FROM [T07 DANH SACH HO SO HOAN CONG] WHERE DotThiCong='" + cbDotBangKe.Text + "' AND danhbo <> '' ORDER BY hopdong ASC ";
                DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
                dataGanMoiBK.DataSource = table;
                formatRows();
            }
            catch (Exception)
            {
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

                string DOT = dataGanMoiBK.Rows[i].Cells["DOT"].Value + "";
                string TODS = dataGanMoiBK.Rows[i].Cells["TODS"].Value + "";
                string MAYDS = dataGanMoiBK.Rows[i].Cells["MAYDS"].Value + "";

                VniToUnicode.ClassViToUnicode vn = new VniToUnicode.ClassViToUnicode();
                HOTEN = vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "");
                SONHA = vn.VniToKD(SONHA).ToUpper();
                DUONG = vn.VniToKD(DUONG).ToUpper();
                string MAQUAN = MAQP.Substring(0, 2);
                string MAPHUONG = MAQP.Substring(2, 2);
                DateTime ngayg = DateTime.Parse(NGAYGANTLK);

                ///
                this.txtDanhBo.Text = DANHBO.Replace(" ", "");
                this.txtHopDong.Text = HOPDONG;
                this.txtNgayGan.ValueObject = ngayg;
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

                if (!"".Equals(MAYDS))
                {
                    this.cbMayDocSo.SelectedIndex = int.Parse(MAYDS);
                }
                else
                {
                    this.cbMayDocSo.SelectedIndex = 0;
                }

                if (!"".Equals(DOT))
                {
                    this.cbDotDS.SelectedIndex = int.Parse(DOT) - 1;
                }
                else
                {
                    this.cbDotDS.SelectedIndex = 0;
                }


                if ("TB02".Equals(TODS))
                {
                    this.cbToDocSo.SelectedIndex = 1;
                }
                else if ("TP".Equals(TODS))
                {
                    this.cbToDocSo.SelectedIndex = 2;
                }
                else
                {
                    this.cbToDocSo.SelectedIndex = 0;
                }




            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

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
                string MAYDS = cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString();
                string DOTDS = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
                string TODS = "TB01";
                if (this.cbToDocSo.SelectedIndex == 1)
                {
                    TODS = "TB02";
                }
                else if (this.cbToDocSo.SelectedIndex == 2)
                {
                    TODS = "TP";
                }
                else
                {
                    TODS = "TB01";
                }
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
                    tb.MAYDS = MAYDS;
                    tb.CREATEDATE = DateTime.Now;
                    tb.CREATEBY = DAL.SYS.C_USERS._userName;
                    if (DAL.DULIEUKH.C_GanMoi.Insert(tb))
                    {
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
                catch (Exception)
                {

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


    }
}
