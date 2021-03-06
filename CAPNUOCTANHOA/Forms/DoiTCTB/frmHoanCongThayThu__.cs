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

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmHoanCongThayThu__ : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmHoanCongThay).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frmHoanCongThayThu__()
        {
            InitializeComponent();
            //dataVatTuThay.DataSource = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay();
            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
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
        public void setData(int i) {
            try
            {
                string ID_BAOTHAY = dataBangKe.Rows[i].Cells["ID_BAOTHAY"].Value + "";
                lbResult.Text = "ID:" + ID_BAOTHAY;

                try
                {
                    DataTable table = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay_DATHAY(int.Parse(ID_BAOTHAY));
                    if (table.Rows.Count > 0)
                        dataVatTuThay.DataSource = table;
                   // else
                       // dataVatTuThay.DataSource = DAL.DoiTCTB.C_HoanCongThay.getVatTuThay();
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
                txtHieuDHGan.Text = HCT_HIEUDHNGAN;

                string HCT_CODHNGAN = dataBangKe.Rows[i].Cells["HCT_CODHNGAN"].Value + "";
                txtGoGan.Text = HCT_CODHNGAN;

                string HCT_SOTHANGAN = dataBangKe.Rows[i].Cells["HCT_SOTHANGAN"].Value + "";
                txtSoThanGan.Text = HCT_SOTHANGAN;

                string HCT_CAP = dataBangKe.Rows[i].Cells["HCT_CAP"].Value + "";
                txtCapGan.Text = HCT_CAP;

                string HCT_CHISOGAN = dataBangKe.Rows[i].Cells["HCT_CHISOGAN"].Value + "";
                txtChiSoGan.Text = HCT_CHISOGAN;
               
                string HCT_LOAIDHGAN = dataBangKe.Rows[i].Cells["HCT_LOAIDHGAN"].Value + "";
                if ("False".Equals(HCT_LOAIDHGAN))
                    cbLoaiDHN.SelectedIndex = 1;
                else
                    cbLoaiDHN.SelectedIndex = 0;
                
                string HCT_NGAYGAN = dataBangKe.Rows[i].Cells["HCT_NGAYGAN"].Value + "";
                txtNgayGan.Value = !"".Equals(HCT_NGAYGAN) ? DateTime.Parse(HCT_NGAYGAN) : DateTime.Now;
                string HCT_CHITHAN = dataBangKe.Rows[i].Cells["GCHITHAN"].Value + "";
                txtChiThan.Text = dataBangKe.Rows[i].Cells["GCHITHAN"].Value + ""; 

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
                else {
                    this.ckTroNgai.Checked = false;
                    txtLyDoTroNgai.Text = "";
                }

              //  MessageBox.Show(this, HCT_CHITHAN + "-" + HCT_CHIGOC + "==" + HCT_NGAYGAN);
                txtSoDanhBo.Text = DHN_DANHBO.Replace("-", "");
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
        
        int currentRow = 0;
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                currentRow = dataBangKe.CurrentRow.Index + 1;
                string ID_BAOTHAY = lbResult.Text.Replace("ID:", "");
                TB_THAYDHN thaydh = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(ID_BAOTHAY));
                string mess = "Cập Nhật Báo Thay Cho Danh Bộ  " + Utilities.FormatSoHoSoDanhBo.sodanhbo(thaydh.DHN_DANHBO, "-") + " ?";
                if (thaydh != null)
                {
                    if (ckTroNgai.Checked)
                    {
                        thaydh.HCT_TRONGAI = true;
                        thaydh.HCT_LYDOTRONGAI = this.txtLyDoTroNgai.Text;
                    }
                    else
                    {
                        thaydh.HCT_CHISOGO = txtChiSoGo.Text != null ? int.Parse(txtChiSoGo.Text) : 0;
                        thaydh.HCT_SOTHANGO = txtSoThanGo.Text;
                        thaydh.HCT_HIEUDHNGAN = txtHieuDHGan.Text;
                        thaydh.HCT_SOTHANGAN = txtSoThanGan.Text;
                        thaydh.HCT_CODHNGAN = txtGoGan.Text;
                        thaydh.HCT_CAP = txtCapGan.Text.ToUpper();
                        thaydh.HCT_CHISOGAN = txtChiSoGan.Text != null ? int.Parse(txtChiSoGan.Text) : 0;
                        if (cbLoaiDHN.SelectedIndex == 0)
                        {
                            thaydh.HCT_LOAIDHGAN = true;
                        }
                        else
                        {
                            thaydh.HCT_LOAIDHGAN = false;
                        }
                        thaydh.HCT_NGAYGAN = txtNgayGan.Value;
                        thaydh.HCT_CHITHAN = txtChiThan.Text.ToUpper();
                        thaydh.HCT_CHIGOC = txtChiGoc.Text.ToUpper();
                        thaydh.HCT_TRONGAI = false;
                        thaydh.HCT_LYDOTRONGAI = "";
                    }
                    if (DAL.QLDHN.C_BaoThay.Update())
                    {
                        try
                        {
                            int id_bt = int.Parse(ID_BAOTHAY);
                            // xoa du lieu cu
                            DAL.LinQConnection.ExecuteCommand("DELETE FROM TB_VATUTHAY_DHN WHERE ID_BAOTHAY='" + ID_BAOTHAY + "'  ");
                            // Luu Vat Tu Thay
                            for (int i = 0; i < dataVatTuThay.Rows.Count-1; i++)
                            {
                                string STT = dataVatTuThay.Rows[i].Cells["STT"].Value + "";
                                string MAVT = dataVatTuThay.Rows[i].Cells["MAVT"].Value + ""; ;
                                string TENVT = dataVatTuThay.Rows[i].Cells["TENVT"].Value + ""; ;
                                string DVT = dataVatTuThay.Rows[i].Cells["DVT"].Value + ""; ;
                                string SOLUONG = dataVatTuThay.Rows[i].Cells["SL"].Value + ""; ;
                                string GHICHU = dataVatTuThay.Rows[i].Cells["GHICHU"].Value + ""; ;
                                TB_VATUTHAY_DHN vtthay = new TB_VATUTHAY_DHN();
                                vtthay.ID_BAOTHAY = id_bt;
                                vtthay.DOTTHAY = txtSoBangKe.Text;
                                vtthay.STT = int.Parse(STT);
                                vtthay.MAVT = MAVT;
                                vtthay.TENVT = TENVT;
                                vtthay.DVT = DVT;
                                vtthay.SOLUONG = int.Parse(SOLUONG); ;
                                vtthay.GHICHU = GHICHU;
                                vtthay.CREATEBY = DAL.SYS.C_USERS._userName;
                                vtthay.CREATEDATE = DateTime.Now;
                                DAL.DoiTCTB.C_HoanCongThay.InsertVatTuThay(vtthay);
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
                            if (kh != null && ckTroNgai.Checked==false)
                            {
                                kh.NGAYTHAY = txtNgayGan.Value;
                                kh.SOTHANDH = txtSoThanGan.Text;
                                kh.HIEUDH = txtHieuDH.Text;
                                kh.CODH = txtCo.Text;
                                kh.CAP = txtCapGan.Text.ToUpper();
                                kh.CHITHAN = txtChiThan.Text.ToUpper();
                                kh.CHIGOC = txtChiGoc.Text.ToUpper();
                                kh.BAOTHAY = false;
                                DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("Cap Nhat Ho So Khach Hang : " + ex.Message);
                        }
                       
                        //Cap Nhat Du Lieu Cho HandHeld
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            log.Error("Cap Nhat Du Lieu Cho HandHeld : " + ex.Message);
                        }
                        //// END
                        LoadData();


                        MessageBox.Show(this, "Cập Nhật Hoàn Công Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            dataBangKe.CurrentCell = dataBangKe.Rows[currentRow].Cells[0];
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập Nhật Hoàn Công Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }

        }

        private void btCapNhat_Click_1(object sender, EventArgs e)
        {

        }
    }
}
