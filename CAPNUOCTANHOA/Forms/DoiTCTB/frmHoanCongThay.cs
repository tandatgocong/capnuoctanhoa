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
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmHoanCongThay : UserControl
    {
        static string mep = ConfigurationManager.AppSettings["mep"].ToString();
        private static readonly ILog log = LogManager.GetLogger(typeof(frmHoanCongThay).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection1 = new AutoCompleteStringCollection();
        public frmHoanCongThay()
        {
            InitializeComponent();
           
            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            txtHieuDHGan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieuDHGan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieuDHGan.AutoCompleteCustomSource = namesCollection;
            ///
            DataTable table2 = DAL.LinQConnection.getDataTable("SELECT MACHI FROM TB_MACHI");
            txtChiThan.DataSource = table2;
            txtChiThan.DisplayMember = "MACHI";
            txtChiThan.ValueMember = "MACHI";
            //
            txtSoBangKe.Text = "TB01-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000";
            this.txtSoBangKe.Focus();
            cbLoaiDHN.SelectedIndex = 0;
            txtCapGan.SelectedIndex = 0;
            dateNgayHCNhanh.Value = DateTime.Now.Date.AddDays(-1);
            if ("ngan".Equals(mep))
            {
                checkMepNgan.Checked = true;
            }
            else
            {
                checkMepNgan.Checked = false;
            }
            
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


        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadData();
            }
        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
        public void LoadData()
        {
            try
            {
                dataBangKe.DataSource = DAL.DoiTCTB.C_HoanCongThay.getBangKeBaoThay(this.txtSoBangKe.Text.ToUpper());
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }
        public void setData(int i)
        {
            try
            {
                rbCoNho.Checked = false;
                rpCoLon.Checked = false;

                string ID_BAOTHAY = dataBangKe.Rows[i].Cells["ID_BAOTHAY"].Value + "";
                string HCT_CODHNGAN_ = dataBangKe.Rows[i].Cells["HCT_CODHNGAN"].Value + "";
                int flg=0;
                try
                {
                    flg = int.Parse(HCT_CODHNGAN_);
                }
                catch (Exception)
                {
                }
                lbResult.Text = "ID:" + ID_BAOTHAY;

                try
                {
                    DataTable table = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay_DATHAY(int.Parse(ID_BAOTHAY));
                    if (table.Rows.Count > 0)
                    {
                        
                        dataVatTuThay.DataSource = table;

                    }

                    else
                    {
                        if (rbCoNho.Checked)
                            dataVatTuThay.DataSource = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay("25");
                        else
                            dataVatTuThay.DataSource = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay("50");
                    }
                        
                }
                catch (Exception ex)
                {
                    log.Error("Load Vat Tu Thay Loi " + ex.Message);
                }
                string DHN_LOAIBANGKE = dataBangKe.Rows[i].Cells["DHN_LOAIBANGKE"].Value + "";
                string DHN_SOBANGKE = dataBangKe.Rows[i].Cells["DHN_SOBANGKE"].Value + "";
                string DHN_STT = dataBangKe.Rows[i].Cells["DHN_STT"].Value + "";
                string DHN_DANHBO = dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "";
                string HOTEN = dataBangKe.Rows[i].Cells["G_TENKH"].Value + "";
                string DIACHI = dataBangKe.Rows[i].Cells["G_DIACHI"].Value + "";
                string DHN_NGAYBAOTHAY = dataBangKe.Rows[i].Cells["DHN_NGAYBAOTHAY"].Value + "";
                string DHN_NGAYGAN = dataBangKe.Rows[i].Cells["DHN_NGAYGAN"].Value + "";
                string DHN_CHITHAN = dataBangKe.Rows[i].Cells["DHN_CHITHAN"].Value + "";
                string DHN_CHIGOC = dataBangKe.Rows[i].Cells["DHN_CHIGOC"].Value + "";
                string DHN_HIEUDHN = dataBangKe.Rows[i].Cells["G_HIEUDHN"].Value + "";
                string DHN_CODH = dataBangKe.Rows[i].Cells["G_CODHN"].Value + "";
                string DHN_SOTHAN = dataBangKe.Rows[i].Cells["G_SOTHAN"].Value + "";
                string DHN_CHISO = dataBangKe.Rows[i].Cells["G_CHISO"].Value + "";
                string DHN_LYDOTHAY = dataBangKe.Rows[i].Cells["G_LYDO"].Value + "";
                string HCT_CHISOGO = dataBangKe.Rows[i].Cells["HCT_CHISOGO"].Value + "";
                txtChiSoGo.Text = HCT_CHISOGO;

                string HCT_SOTHANGO = dataBangKe.Rows[i].Cells["HCT_SOTHANGO"].Value + "";
                txtSoThanGo.Text = HCT_SOTHANGO;

                string HCT_HIEUDHNGAN = dataBangKe.Rows[i].Cells["HCT_HIEUDHNGAN"].Value + "";
                txtHieuDHGan.Text = !HCT_HIEUDHNGAN.Equals("") ? HCT_HIEUDHNGAN : ConfigurationManager.AppSettings["defautHieu"].ToString();

                string HCT_CODHNGAN = dataBangKe.Rows[i].Cells["HCT_CODHNGAN"].Value + "";
                txtGoGan.Text = !HCT_CODHNGAN.Equals("") ? HCT_CODHNGAN : "15";

                string HCT_SOTHANGAN = dataBangKe.Rows[i].Cells["HCT_SOTHANGAN"].Value + "";
                txtSoThanGan.Text = HCT_SOTHANGAN;

                string HCT_CAP = dataBangKe.Rows[i].Cells["HCT_CAP"].Value + "";
                txtCapGan.Text = !HCT_CAP.Equals("") ? HCT_CAP : ConfigurationManager.AppSettings["defautCap"].ToString();

                string HCT_CHISOGAN = dataBangKe.Rows[i].Cells["HCT_CHISOGAN"].Value + "";
                txtChiSoGan.Text = !HCT_CHISOGAN.Equals("") ? HCT_CHISOGAN : "0"; ;

                string HCT_LOAIDHGAN = dataBangKe.Rows[i].Cells["HCT_LOAIDHGAN"].Value + "";
                if ("False".Equals(HCT_LOAIDHGAN))
                    cbLoaiDHN.SelectedIndex = 1;
                else
                    cbLoaiDHN.SelectedIndex = 0;

                string HCT_NGAYGAN = dataBangKe.Rows[i].Cells["HCT_NGAYGAN"].Value + "";
                txtNgayGan.Value = !"".Equals(HCT_NGAYGAN) ? DateTime.Parse(HCT_NGAYGAN) : DateTime.Now.AddDays(-1);

                string HCT_NGAYKIEMDINH = dataBangKe.Rows[i].Cells["HCT_NGAYKIEMDINH"].Value + "";
                txtngayKiemDinh.Value = !"".Equals(HCT_NGAYKIEMDINH) ? DateTime.Parse(HCT_NGAYKIEMDINH) : DateTime.Now;


                string HCT_CHITHAN = dataBangKe.Rows[i].Cells["GCHITHAN"].Value + "";
                txtChiThan.Text = !HCT_CHITHAN.Equals("") ? HCT_CHITHAN : ConfigurationManager.AppSettings["defautChi"].ToString();

                string HCT_CHIGOC = dataBangKe.Rows[i].Cells["GCHIGOC"].Value + "";
                txtChiGoc.Text = dataBangKe.Rows[i].Cells["GCHIGOC"].Value + "";

                string HCT_TRONGAI = dataBangKe.Rows[i].Cells["HCT_TRONGAI"].Value + "";
                if ("True".Equals(HCT_TRONGAI))
                {
                    //  MessageBox.Show(this,HCT_TRONGAI);
                    this.ckTroNgai.Checked = true;
                    string HCT_LYDOTRONGAI = dataBangKe.Rows[i].Cells["HCT_LYDOTRONGAI"].Value + "";
                    txtLyDoTroNgai.Text = HCT_LYDOTRONGAI;
                }
                else
                {
                    this.ckTroNgai.Checked = false;
                    txtLyDoTroNgai.Text = "";
                }
                lbLoaiBK.Text = DHN_LOAIBANGKE;
                //  MessageBox.Show(this, HCT_CHITHAN + "-" + HCT_CHIGOC + "==" + HCT_NGAYGAN);
                txtSoDanhBo.Text = DHN_DANHBO.Replace(" ", "");
                txtTenKH.Text = HOTEN;
                txtDiaChi.Text = DIACHI;
                txtHieuDH.Text = DHN_HIEUDHN;
                txtCo.Text = DHN_CODH;
                txtSoThan.Text = DHN_SOTHAN;
                txtChiSoThay.Text = DHN_CHISO;
                txtLyDoThay.Text = DHN_LYDOTHAY;
                txtChiSoGo.Focus();
                /////

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setData(e.RowIndex);
                currentRow = e.RowIndex;
            }
            catch (Exception)
            {
            }
        }

        private void txtChiSoGo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtGoGan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChiSoGan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void CapNhatCS(TB_THAYDHN thaydh)
        {
            string ID_BAOTHAY = lbResult.Text.Replace("ID:", "");
            if (thaydh != null)
            {
                if (ckTroNgai.Checked)
                {
                    thaydh.HCT_TRONGAI = true;
                    thaydh.HCT_NGAYGAN = txtNgayGan.Value.Date;
                    thaydh.HCT_LYDOTRONGAI = this.txtLyDoTroNgai.Text;
                    if ("".Equals(thaydh.HCT_CREATEBY + ""))
                    {
                        thaydh.HCT_CREATEBY = DAL.SYS.C_USERS._userName;
                        thaydh.HCT_CREATEDATE = DateTime.Now.Date;
                    }
                    else
                    {
                        thaydh.HCT_MODIFYBY = DAL.SYS.C_USERS._userName;
                        thaydh.HCT_MODIFYDATE = DateTime.Now;
                    }


                }
                else
                {
                    if (int.Parse(txtChiSoThay.Text) <= int.Parse(txtChiSoGo.Text))
                    {
                        thaydh.HCT_CHISOGO = txtChiSoGo.Text != null ? int.Parse(txtChiSoGo.Text.Trim()) : 0;
                        thaydh.HCT_SOTHANGO = txtSoThanGo.Text;
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
                        thaydh.HCT_NGAYGAN = txtNgayGan.Value.Date;
                        thaydh.HCT_NGAYKIEMDINH = txtngayKiemDinh.Value.Date;
                        thaydh.HCT_CHITHAN = txtChiThan.Text.ToUpper();
                        thaydh.HCT_CHIGOC = txtChiGoc.Text.ToUpper();
                        thaydh.HCT_TRONGAI = false;
                        thaydh.HCT_LYDOTRONGAI = "";
                        if ("".Equals(thaydh.HCT_CREATEBY + ""))
                        {
                            thaydh.HCT_CREATEBY = DAL.SYS.C_USERS._userName;
                            thaydh.HCT_CREATEDATE = DateTime.Now.Date;
                        }
                        else
                        {
                            thaydh.HCT_MODIFYBY = DAL.SYS.C_USERS._userName;
                            thaydh.HCT_MODIFYDATE = DateTime.Now;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Chỉ Số Gở >= Chỉ Số Thay", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                if (DAL.QLDHN.C_BaoThay.Update())
                {
                    if (ckTroNgai.Checked == false)
                    {
                        try
                        {
                            int id_bt = int.Parse(ID_BAOTHAY);
                            // xoa du lieu cu
                            DAL.LinQConnection.ExecuteCommand("DELETE FROM TB_VATUTHAY_DHN WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'  ");
                            // Luu Vat Tu Thay
                            for (int i = 0; i < dataVatTuThay.Rows.Count - 1; i++)
                            {
                                string STT = dataVatTuThay.Rows[i].Cells["STT"].Value + "";
                                string MAVT = dataVatTuThay.Rows[i].Cells["MAVT"].Value + ""; ;
                                string TENVT = dataVatTuThay.Rows[i].Cells["TENVT"].Value + ""; ;
                                string DVT = dataVatTuThay.Rows[i].Cells["DVT"].Value + ""; ;
                                string SOLUONG = dataVatTuThay.Rows[i].Cells["SL"].Value + ""; ;
                                string GHICHU = dataVatTuThay.Rows[i].Cells["GHICHU"].Value + ""; ;

                                double sl = 0;
                                try
                                {
                                    sl = double.Parse(SOLUONG.Trim());
                                }
                                catch (Exception)
                                {
                                }
                                if (sl != 0)
                                {
                                    TB_VATUTHAY_DHN vtthay = new TB_VATUTHAY_DHN();
                                    vtthay.ID_BAOTHAY = id_bt;
                                    vtthay.DOTTHAY = txtSoBangKe.Text;
                                    vtthay.STT = int.Parse(STT);
                                    vtthay.MAVT = MAVT;
                                    vtthay.TENVT = TENVT;
                                    vtthay.DVT = DVT;
                                    vtthay.SOLUONG = sl;
                                    vtthay.GHICHU = GHICHU;
                                    vtthay.CREATEBY = DAL.SYS.C_USERS._userName;
                                    vtthay.CREATEDATE = DateTime.Now;
                                    DAL.DoiTCTB.C_HoanCongThay.InsertVatTuThay(vtthay);
                                }
                            }
                            //
                        }
                        catch (Exception ex)
                        {
                            log.Error("Loi Luu Vat Tu THay : " + ex.Message);
                        }

                        //Cap Nhat Ho So Khach Hang
                        try
                        {
                            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtSoDanhBo.Text.Replace("-", ""));
                            if (kh != null && ckTroNgai.Checked == false)
                            {
                                kh.NGAYTHAY = txtNgayGan.Value.Date;
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
                                    if (!"DK".Equals(this.lbLoaiBK.Text))
                                    {
                                        loai = "2";
                                    }

                                    string sql = "INSERT INTO BAOTHAYDHN (DANHBA, TENKH, SO, DUONG, HIEUMOI, COMOI, NGAYTHAY, CSGO, CSGAN, SOTHANMOI, VITRIMOI, MACHITHAN, MACHIGOC, LOAI) " +
                                    " VALUES     ('" + this.txtSoDanhBo.Text.Replace("-", "") + "', " +
                                    " '" + kh.HOTEN.TrimEnd() + "', " +
                                    " '" + kh.SONHA.TrimEnd() + "' ," +
                                    " '" + kh.TENDUONG.TrimEnd() +"' , " +
                                    " '" + txtHieuDHGan.Text.Substring(0, 3) + "', " +
                                    " " + kh.CODH + ", " +
                                    " '" + txtNgayGan.Value + "', " +
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
                                        " NGAYTHAY='" + txtNgayGan.Value + "', " +
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
                    //else {
                    //     TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(this.txtSoDanhBo.Text.Replace("-", ""));
                    //     if (kh != null )
                    //     {
                    //         kh.BAOTHAY = false;
                    //         DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                    //     }
                    //}

                    LoadData();
                    MessageBox.Show(this, "Cập Nhật Hoàn Công Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //try
                    //{
                    //    dataBangKe.CurrentCell = dataBangKe.Rows[currentRow].Cells[0];
                    //}
                    //catch (Exception)
                    //{
                    //}
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        int currentRow = 0;
        static string kiemtra = ConfigurationManager.AppSettings["ktSoThan"].ToString();

        public void ChoCapNhat(List<TB_DULIEUKHACHHANG> cothantrung, TB_THAYDHN thaydh)
        {
            string danhbo = "";
            foreach (var item in cothantrung)
            {
                danhbo += item.DANHBO + ",";
            }

            if ("1".Equals(kiemtra))
            {
                if (MessageBox.Show(this, "Số Thân Hiện Tại Trùng Danh Bộ " + danhbo + " Có Muốn Cập Nhật Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CapNhatCS(thaydh);
                }
            }
            else if ("2".Equals(kiemtra))
            {
                MessageBox.Show(this, "Số Thân Hiện Tại Trùng Danh Bộ " + danhbo + " Không Cho Cập Nhật.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CapNhatCS(thaydh);
            }

        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {

            try
            {
                currentRow = dataBangKe.CurrentRow.Index + 1;
                string ID_BAOTHAY = lbResult.Text.Replace("ID:", "");
                TB_THAYDHN thaydh = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY));
                if (ckTroNgai.Checked)
                {
                    CapNhatCS(thaydh);
                }
                else
                {
                    if (!rbCoNho.Checked && !rpCoLon.Checked)
                    {
                        MessageBox.Show(this, "Chưa Chọn Vật Tư Thay ĐHN !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        List<TB_DULIEUKHACHHANG> cothantrung = DAL.DULIEUKH.C_DuLieuKhachHang.getSoThanDHN(this.txtSoThanGan.Text.Replace(" ", ""), this.txtHieuDHGan.Text.Substring(0, 3));
                        if (cothantrung.Count > 0)
                        {
                            if (cothantrung.Count == 1)
                            {
                                if (this.txtSoDanhBo.Text.Replace("-", "").Equals(cothantrung[0].DANHBO))
                                {
                                    CapNhatCS(thaydh);
                                }
                                else
                                {
                                    ChoCapNhat(cothantrung, thaydh);
                                }
                            }
                            else
                            {
                                ChoCapNhat(cothantrung, thaydh);
                            }
                        }
                        else
                        {
                            CapNhatCS(thaydh);
                        }

                    }

                }
                //string mess = "Cập Nhật Báo Thay Cho Danh Bộ  " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thaydh.DHN_DANHBO, "-") + " ?";

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void dataBangKe_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string ID_BAOTHAY = dataBangKe.Rows[currentRow].Cells["ID_BAOTHAY"].Value + "";
                lbResult.Text = "ID:" + ID_BAOTHAY;
                string DHN_LOAIBANGKE = dataBangKe.Rows[currentRow].Cells["DHN_LOAIBANGKE"].Value + "";
                string DHN_SOBANGKE = dataBangKe.Rows[currentRow].Cells["DHN_SOBANGKE"].Value + "";
                string DHN_STT = dataBangKe.Rows[currentRow].Cells["DHN_STT"].Value + "";
                string DHN_DANHBO = dataBangKe.Rows[currentRow].Cells["G_DANHBO"].Value + "";
                string HOTEN = dataBangKe.Rows[currentRow].Cells["G_TENKH"].Value + "";
                string DIACHI = dataBangKe.Rows[currentRow].Cells["G_DIACHI"].Value + "";
                string DHN_NGAYBAOTHAY = dataBangKe.Rows[currentRow].Cells["DHN_NGAYBAOTHAY"].Value + "";
                string DHN_NGAYGAN = dataBangKe.Rows[currentRow].Cells["DHN_NGAYGAN"].Value + "";
                string DHN_CHITHAN = dataBangKe.Rows[currentRow].Cells["DHN_CHITHAN"].Value + "";
                string DHN_CHIGOC = dataBangKe.Rows[currentRow].Cells["DHN_CHIGOC"].Value + "";
                string DHN_HIEUDHN = dataBangKe.Rows[currentRow].Cells["G_HIEUDHN"].Value + "";
                string DHN_CODH = dataBangKe.Rows[currentRow].Cells["G_CODHN"].Value + "";
                string DHN_SOTHAN = dataBangKe.Rows[currentRow].Cells["G_SOTHAN"].Value + "";
                string DHN_CHISO = dataBangKe.Rows[currentRow].Cells["G_CHISO"].Value + "";
                string DHN_LYDOTHAY = dataBangKe.Rows[currentRow].Cells["G_LYDO"].Value + "";
                //  setData(currentRow);
                txtChiSoGo.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void btInHoanCong_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_BCHoanCong_A4();
                rp.SetDataSource(DAL.DoiTCTB.C_HoanCongThay.ReportHoanCongThay(txtSoBangKe.Text));
                rp.SetParameterValue("hoantat", DAL.LinQConnection.ExecuteCommand("select  COUNT(*) FROM V_DHN_BANGKE where (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "' AND HCT_TRONGAI='False'"));
                rp.SetParameterValue("TRONGAI", DAL.LinQConnection.ExecuteCommand("select  COUNT(*) FROM V_DHN_BANGKE where (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + txtSoBangKe.Text + "' AND HCT_TRONGAI='True'"));
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void dataVatTuThay_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (dataVatTuThay.CurrentCell.OwningColumn.Name == "SL")
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btPhieuThiCong_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_BCBangKe_A4();
                rp.SetDataSource(DAL.DoiTCTB.C_HoanCongThay.ReportBaoThay(txtSoBangKe.Text));
                rp.SetParameterValue("lapbk", DAL.SYS.C_USERS._fullName);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }

        }

        private void phieutc(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else
            {
                if (checkMepNgan.Checked)
                {
                    ReportDocument rp = new rpt_PhieuThiCongThay();
                    rp.SetDataSource(DAL.DoiTCTB.C_HoanCongThay.ReportBaoThay(txtSoBangKe.Text));
                    frm_Reports frm = new frm_Reports(rp);
                    frm.ShowDialog();
                }
                else
                {
                    ReportDocument rp = new rpt_PhieuThiCongThay_mepdai();
                    rp.SetDataSource(DAL.DoiTCTB.C_HoanCongThay.ReportBaoThay(txtSoBangKe.Text));
                    frm_Reports frm = new frm_Reports(rp);
                    frm.ShowDialog();
                }

            }

        }

        private void dataBangKe_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_HoanCongNhanh();
            rp.SetDataSource(DAL.DoiTCTB.C_HoanCongThay.HoanCongNhanh(Utilities.DateToString.NgayVN(dateNgayHCNhanh.Value)));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void btHuyThay_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Có Thật Sự Muốn Hủy Hoàn Công ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string ID_BAOTHAY = lbResult.Text.Replace("ID:", "");
                    string update = "UPDATE TB_THAYDHN SET HCT_CHISOGO=NULL,HCT_SOTHANGO=NULL,HCT_HIEUDHNGAN=NULL,HCT_CODHNGAN=NULL,HCT_SOTHANGAN=NULL,HCT_CAP=NULL,HCT_CHISOGAN=NULL,";
                    update += " HCT_LOAIDHGAN=NULL,HCT_NGAYGAN=NULL,HCT_CHITHAN=NULL,HCT_CHIGOC=NULL,HCT_TRONGAI=NULL,HCT_LYDOTRONGAI=NULL,HCT_CREATEDATE=NULL,";
                    update += " HCT_CREATEBY=NULL,HCT_MODIFYDATE=NULL,HCT_MODIFYBY=NULL WHERE ID_BAOTHAY=" + ID_BAOTHAY;
                    DAL.LinQConnection.ExecuteCommand_(update);
                    DAL.LinQConnection.ExecuteCommand("DELETE FROM TB_VATUTHAY_DHN WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'  ");
                    MessageBox.Show(this, "Hủy Hoàn Công Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btMachi_Click(object sender, EventArgs e)
        {
            frmMaChi opt = new frmMaChi();
            opt.ShowDialog();
        }

        void getVatTu()
        {
            DataTable table = new DataTable("VATTUTHAY");
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("MAVT", typeof(string));
            table.Columns.Add("TENVT", typeof(string));
            table.Columns.Add("DVT", typeof(string));
            table.Columns.Add("SL", typeof(double));
            table.Columns.Add("GHICHU", typeof(string));
         
            DataTable t1 = null;
            if (rbCoNho.Checked)
                t1 = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay("25");
            else
                t1 = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay("50");


            DataRow myDataRow = table.NewRow();
            myDataRow["STT"] ="1";
            myDataRow["MAVT"] = "TLK" + txtGoGan.Text.Replace(" ", "") + txtHieuDHGan.Text.Replace(" ", "").Substring(0,3);
            myDataRow["TENVT"] = "TLK " + txtHieuDHGan.Text.Replace(" ", "") + " " + txtGoGan.Text.Replace(" ", "") + " LY";
            myDataRow["DVT"] = "Cái";
            myDataRow["SL"] = "1";
            myDataRow["GHICHU"] = "";  
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = "2";
            myDataRow["MAVT"] = "DDONG";
            myDataRow["TENVT"] = "DÂY ĐỒNG  ";
            myDataRow["DVT"] = "m";
            myDataRow["SL"] = "0.6";
            myDataRow["GHICHU"] = "";
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = "3";
            myDataRow["MAVT"] = "CVIEN";
            myDataRow["TENVT"] = "CHÌ VIÊN  ";
            myDataRow["DVT"] = "Viên";
            myDataRow["SL"] = "1";
            myDataRow["GHICHU"] = "";
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = "4";
            myDataRow["MAVT"] = "BKLUA";
            myDataRow["TENVT"] = "BĂNG KEO LỤA ";
            myDataRow["DVT"] = "Cuồn";
            myDataRow["SL"] = "0.34";
            myDataRow["GHICHU"] = "";
            table.Rows.Add(myDataRow);

            for (int i = 0; i < t1.Rows.Count; i++)
            {
                myDataRow = table.NewRow();
                myDataRow["STT"] = i+5;
                myDataRow["MAVT"] = t1.Rows[i]["MAVT"].ToString();
                myDataRow["TENVT"] = t1.Rows[i]["TENVT"].ToString();
                myDataRow["DVT"] = t1.Rows[i]["DVT"].ToString();
                myDataRow["SL"] = t1.Rows[i]["SL"].ToString();
                myDataRow["GHICHU"] = "";
                table.Rows.Add(myDataRow);
            }

            dataVatTuThay.DataSource = table;
        }
        private void rbCoNho_CheckedChanged(object sender, EventArgs e)
        {
            getVatTu();
        }

        private void rpCoLon_CheckedChanged(object sender, EventArgs e)
        {
            getVatTu();
        }
    }
}