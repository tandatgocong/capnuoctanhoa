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
using CAPNUOCTANHOA.Forms.BanKTKS.BC;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_GiamHoaDon : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_GiamHoaDon).Name);
        int selectedindex = -1;
        DK_GIAMHOADON hd;
        string flag;

        public frm_GiamHoaDon()
        {
            InitializeComponent();
        }

        #region Method

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
                switch (flag)
                {
                    case "bangke":                     
                        dataBangKe.DataSource = DAL.BANKTKS.C_GiamHoaDon.getBangKeBySoBangKe(txtSoBangKe.Text.ToUpper());
                        break;
                    case "danhbo":
                        if (!DAL.BANKTKS.C_GiamHoaDon.findByDanhBo(txtSoDanhBo.Text.ToUpper().Replace("-", "")))
                        {
                            DK_GIAMHOADON item = new DK_GIAMHOADON();
                            DataTable table = DAL.BANKTKS.C_GiamHoaDon.getThongTinKhachHang(txtSoDanhBo.Text.ToUpper().Replace("-", ""));
                            item.DHN_DANHBO = txtSoDanhBo.Text.ToUpper().Replace("-", "");
                            item.DHN_KY = DateTime.Now.Month.ToString();
                            item.DHN_NAM = DateTime.Now.Year;
                            item.DHN_DOT = table.Rows[0]["LOTRINH"].ToString().Substring(0, 2);
                            item.DHN_CREATEDATE = DateTime.Now.Date;
                            item.DHN_CREATEBY = DAL.SYS.C_USERS._userName;
                            DAL.BANKTKS.C_GiamHoaDon.Insert(item);
                        }
                        dataBangKe.DataSource = DAL.BANKTKS.C_GiamHoaDon.getBangKeBySoDanhBo(txtSoDanhBo.Text.ToUpper().Replace("-", ""));
                        break;
                    case "yeucau":
                        dataBangKe.DataSource = DAL.BANKTKS.C_GiamHoaDon.getBangKeByNgayYeuCau(dateYeuCau.Value);
                        break;
                }
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
                Clear();
            }

            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }
        }

        public void Clear()
        {
            txtSoDanhBo.Text = "";
            txtLoTrinh.Text = "";
            txtDot.Text = "";
            txtSoThan.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            dateTiepXuc.Value = new DateTime();
            txtCamKet.Text = "";
            txtGhiChu.Text = "";
            txtMaKiemKhoaNuoc.Text = "";
            dateKhoaNuoc.Value = new DateTime();
            txtMaKiemThuHoi.Text = "";
            txtHieu.Text = "";
            txtCo.Text = "";
            txtKTKSSoThan.Text = "";
            txtChiSo.Text = "";
            txtNhanVien.Text = "";
            dateThuHoi.Value = new DateTime();
            selectedindex = -1;
            btncapNhat.Enabled = false;
        }

        public void LoadLichSuHoaDon0(string sodanhbo)
        {
            DataTable dt = DAL.BANKTKS.C_GiamHoaDon.getLichSuHoaDon0(sodanhbo);
            DataSetktks ds = new DataSetktks();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = ds.Tables["LichSuHoaDon0"].NewRow();
                dr["STT"] = i + 1;
                dr["SOBANGKE"] = dt.Rows[i]["DHN_SOBANGKE"].ToString();
                dr["DHN_NGAYGHINHAN"] = dt.Rows[i]["DHN_NGAYGHINHAN"].ToString();
                if (dt.Rows[i]["DHN_HUYCAMKET"].ToString() != "")
                    dr["HCK"] = "X";
                else
                    if (dt.Rows[i]["DHN_CAMKET"].ToString() != "")
                        dr["DHN_CK"] = "X";
                    else
                        if (dt.Rows[i]["DHN_BAMHI"].ToString() != "")
                            dr["BC"] = "X";
                dr["KTKS_NGAYTIEPXUC"] = dt.Rows[i]["KTKS_NGAYTIEPXUC"].ToString();
                if (dt.Rows[i]["KTKS_CAMKET"].ToString() != "")
                    dr["KTKS_CK"] = "X";
                else
                    if (dt.Rows[i]["KTKS_BAMHI"].ToString() == "khoanuoc")
                        dr["BCKN"] = "X";
                    else
                        if (dt.Rows[i]["KTKS_BAMHI"].ToString() == "thuhoi")
                            dr["BCTH"] = "X";
                ds.Tables["LichSuHoaDon0"].Rows.Add(dr);
            }
            if (ds.Tables["LichSuHoaDon0"].Rows.Count > 0)
            {
                dataLichSuHoaDon0.DataSource = ds.Tables["LichSuHoaDon0"];
                panelLichSuHoaDon0.Visible = true;
            }
        }

        #endregion

        private void frm_GiamHoaDon_Load(object sender, EventArgs e)
        {
            txtSoBangKe.Focus();
            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            txtHieu.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtHieu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHieu.AutoCompleteCustomSource = namesCollection;
        }

        #region Method Static Control

        private void radCamKet_CheckedChanged(object sender, EventArgs e)
        {
            panelCamKet.Visible = true;
            panelBamChiKhoaNuoc.Visible = false;
            panelBamChiThuHoi.Visible = false;
            txtCamKet.Focus();
        }

        private void radKTKSBamChiKhoaNuoc_CheckedChanged(object sender, EventArgs e)
        {
            panelCamKet.Visible = false;
            panelBamChiKhoaNuoc.Visible = true;
            panelBamChiThuHoi.Visible = false;
            txtMaKiemKhoaNuoc.Focus();
        }

        private void radKTKSBamChiThuHoi_CheckedChanged(object sender, EventArgs e)
        {
            panelCamKet.Visible = false;
            panelBamChiKhoaNuoc.Visible = false;
            panelBamChiThuHoi.Visible = true;
            txtMaKiemThuHoi.Focus();
        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                flag = "bangke";
                LoadData();
                //dateYeuCau.Value = new DateTime();
                txtSoDanhBo.Text = "";
                panelLichSuHoaDon0.Visible = false;
            }
        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                flag = "danhbo";
                LoadData();
                //dateYeuCau.Value = new DateTime();
                txtSoBangKe.Text = "";
                panelLichSuHoaDon0.Visible = false;
                if (dataBangKe.RowCount > 0)
                    dataBangKe_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void dateYeuCau_TextChanged(object sender, EventArgs e)
        {
            flag = "yeucau";
            LoadData();
            txtSoDanhBo.Text = "";
            txtSoBangKe.Text = "";
            panelLichSuHoaDon0.Visible = false;
        }

        private void dateTiepXuc_TextChanged(object sender, EventArgs e)
        {
            dateKhoaNuoc.Value = dateThuHoi.Value = dateTiepXuc.Value;
        }

        #endregion

        #region Method Action Control

        private void dataBangKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSoDanhBo.Text = dataBangKe["G_DANHBO", e.RowIndex].Value.ToString().Replace(" ", "");
                txtLoTrinh.Text = dataBangKe["LOTRINH", e.RowIndex].Value.ToString();
                txtDot.Text = dataBangKe["DHN_DOT", e.RowIndex].Value.ToString();
                txtSoThan.Text = dataBangKe["SOTHANDH", e.RowIndex].Value.ToString();
                txtTenKH.Text = dataBangKe["HOTEN", e.RowIndex].Value.ToString();
                txtDiaChi.Text = dataBangKe["DIACHI", e.RowIndex].Value.ToString();
                txtCamKet.Text = dataBangKe["KTKS_CAMKET", e.RowIndex].Value.ToString();
                txtGhiChu.Text = dataBangKe["KTKS_GHICHU", e.RowIndex].Value.ToString();
                //Ngày tiếp xúc
                if (dataBangKe["KTKS_NGAYTIEPXUC", e.RowIndex].Value.ToString() != "")
                    dateTiepXuc.Value = (DateTime)dataBangKe["KTKS_NGAYTIEPXUC", e.RowIndex].Value;
                else
                    dateTiepXuc.Value = new DateTime();
                //Bấm chì
                if (dataBangKe["KTKS_CAMKET", e.RowIndex].Value.ToString() != "")
                    radCamKet.Checked = true;
                else
                    if (dataBangKe["KTKS_BAMHI", e.RowIndex].Value.ToString() == "khoanuoc")
                        radKTKSBamChiKhoaNuoc.Checked = true;
                    else
                        if (dataBangKe["KTKS_BAMHI", e.RowIndex].Value.ToString() == "thuhoi")
                            radKTKSBamChiThuHoi.Checked = true;
                        else
                        {
                            radCamKet.Checked = false;
                            radKTKSBamChiKhoaNuoc.Checked = false;
                            radKTKSBamChiThuHoi.Checked = false;
                            panelCamKet.Visible = false;
                            panelBamChiKhoaNuoc.Visible = false;
                            panelBamChiThuHoi.Visible = false;
                        }
                //panel Bấm chì khóa nước
                txtMaKiemKhoaNuoc.Text = dataBangKe["KTKS_MAKIEMBC", e.RowIndex].Value.ToString();
                if (dataBangKe["KTKS_NGAYBAMCHI", e.RowIndex].Value.ToString() != "")
                    dateKhoaNuoc.Value = (DateTime)dataBangKe["KTKS_NGAYBAMCHI", e.RowIndex].Value;
                else
                    dateKhoaNuoc.Value = new DateTime();
                //panel Bấm chì thu hồi
                txtMaKiemThuHoi.Text = dataBangKe["KTKS_TH_MAKIEM", e.RowIndex].Value.ToString();
                if (dataBangKe["KTKS_TH_HIEU", e.RowIndex].Value.ToString() == "")
                    txtHieu.Text = dataBangKe["HIEUDH", e.RowIndex].Value.ToString();
                else
                    txtHieu.Text = dataBangKe["KTKS_TH_HIEU", e.RowIndex].Value.ToString();
                if (dataBangKe["KTKS_TH_CO", e.RowIndex].Value.ToString() == "")
                    txtCo.Text = dataBangKe["CODH", e.RowIndex].Value.ToString();
                else
                    txtCo.Text = dataBangKe["KTKS_TH_CO", e.RowIndex].Value.ToString();
                if(dataBangKe["KTKS_TH_SOTHAN", e.RowIndex].Value.ToString()=="")
                    txtKTKSSoThan.Text = dataBangKe["SOTHANDH", e.RowIndex].Value.ToString();
                else
                txtKTKSSoThan.Text = dataBangKe["KTKS_TH_SOTHAN", e.RowIndex].Value.ToString();
                txtChiSo.Text = dataBangKe["KTKS_TH_CHISO", e.RowIndex].Value.ToString();
                txtNhanVien.Text = dataBangKe["KTKS_NHANVIEN", e.RowIndex].Value.ToString();
                if (dataBangKe["KTKS_TH_NGAY", e.RowIndex].Value.ToString() != "")
                    dateThuHoi.Value = (DateTime)dataBangKe["KTKS_TH_NGAY", e.RowIndex].Value;
                else
                    dateThuHoi.Value = new DateTime();
                //Set
                selectedindex = e.RowIndex;
                btncapNhat.Enabled = true;
                LoadLichSuHoaDon0(dataBangKe["G_DANHBO", e.RowIndex].Value.ToString().Replace(" ", ""));
                txtSoDanhBo.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void btncapNhat_Click(object sender, EventArgs e)
        {
            hd = DAL.BANKTKS.C_GiamHoaDon.findByID(int.Parse(dataBangKe["ID", selectedindex].Value.ToString()));
            hd.KTKS_GHICHU = txtGhiChu.Text.Trim().ToUpper();
            if (!"".Equals(dateTiepXuc.ValueObject + ""))
                hd.KTKS_NGAYTIEPXUC = dateTiepXuc.Value;
            if (radCamKet.Checked)
                hd.KTKS_CAMKET = txtCamKet.Text.Trim().ToUpper();
            else
                if (radKTKSBamChiKhoaNuoc.Checked)
                {
                    hd.KTKS_BAMHI = "khoanuoc";
                    //panel Bấm chì khóa nước
                    hd.KTKS_MAKIEMBC = txtMaKiemKhoaNuoc.Text.Trim().ToUpper();
                    if (!"".Equals(dateKhoaNuoc.ValueObject + ""))
                        hd.KTKS_NGAYBAMCHI = dateKhoaNuoc.Value;
                }
                else
                    if (radKTKSBamChiThuHoi.Checked)
                    {
                        hd.KTKS_BAMHI = "thuhoi";
                        //panel Bấm chì thu hồi
                        hd.KTKS_TH_MAKIEM = txtMaKiemThuHoi.Text.Trim().ToUpper();
                        hd.KTKS_TH_HIEU = txtHieu.Text.Trim().ToUpper();
                        hd.KTKS_TH_CO = txtCo.Text.Trim();
                        hd.KTKS_TH_SOTHAN = txtKTKSSoThan.Text.Trim().ToUpper();
                        hd.KTKS_TH_CHISO = txtChiSo.Text.Trim();
                        if (!"".Equals(dateThuHoi.ValueObject + ""))
                            hd.KTKS_TH_NGAY = dateThuHoi.Value;
                    }
                    else
                    {
                        hd.KTKS_CAMKET = "";
                        hd.KTKS_BAMHI = "";
                    }
            hd.KTKS_NHANVIEN = txtNhanVien.Text.Trim().ToUpper();
            hd.KTKS_MODIFYDATE = DateTime.Now.Date;
            hd.KTKS_MODIFYBY = DAL.SYS.C_USERS._userName;
            if (DAL.BANKTKS.C_GiamHoaDon.Update())
            {
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                LoadData();
            }
            else
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dataBangKe.RowCount > 0)
            {
                DataSetktks ds = new DataSetktks();
                for (int i = 0; i < dataBangKe.RowCount; i++)
                {
                    DataRow dr = ds.Tables["GiamHoaDon"].NewRow();
                    dr["DHN_STT"] = dataBangKe["DHN_STT", i].Value.ToString();
                    dr["DHN_NGAYGHINHAN"] = dataBangKe["DHN_NGAYGHINHAN", i].Value.ToString();
                    dr["DHN_TODS"] = dataBangKe["DHN_TODS", i].Value.ToString();
                    dr["G_DANHBO"] = dataBangKe["G_DANHBO", i].Value.ToString().Replace(" ", "");
                    dr["LOTRINH"] = dataBangKe["LOTRINH", i].Value.ToString();
                    dr["SOTHANDH"] = dataBangKe["SOTHANDH", i].Value.ToString();
                    dr["HOTEN"] = dataBangKe["HOTEN", i].Value.ToString();
                    dr["DIACHI"] = dataBangKe["DIACHI", i].Value.ToString();
                    dr["DHN_CAMKET"] = dataBangKe["DHN_CAMKET", i].Value.ToString();
                    dr["DHN_BAMHI"] = dataBangKe["DHN_BAMHI", i].Value.ToString();
                    dr["KTKS_CAMKET"] = dataBangKe["KTKS_CAMKET", i].Value.ToString();
                    if (dataBangKe["KTKS_BAMHI", i].Value.ToString() == "khoanuoc" || dataBangKe["KTKS_BAMHI", i].Value.ToString() == "thuhoi")
                        dr["KTKS_KHOANUOC"] = "X";
                    dr["KTKS_GHICHU"] = dataBangKe["KTKS_GHICHU", i].Value.ToString();
                    dr["DHN_DOT"] = dataBangKe["DHN_DOT", i].Value.ToString();
                    dr["DHN_SOBANGKE"] = dataBangKe["DHN_SOBANGKE", i].Value.ToString();
                    dr["DHN_KY"] = dataBangKe["DHN_KY", i].Value.ToString();
                    ds.Tables["GiamHoaDon"].Rows.Add(dr);
                }
                rpt_GiamHoaDon rp = new rpt_GiamHoaDon();
                rp.SetDataSource(ds);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void btnInDSThuHoi_Click(object sender, EventArgs e)
        {
            DataTable dt = DAL.BANKTKS.C_GiamHoaDon.getDSThuHoi();
            if (dt.Rows.Count > 0)
            {
                DataSetktks ds = new DataSetktks();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["DSThuHoi"].NewRow();
                    dr["DHN_STT"] = i + 1;
                    dr["DHN_DANHBO"] = dt.Rows[i]["DHN_DANHBO"].ToString();
                    dr["HOTEN"] = dt.Rows[i]["HOTEN"].ToString();
                    dr["DIACHI"] = dt.Rows[i]["DIACHI"].ToString();
                    dr["HOPDONG"] = dt.Rows[i]["HOPDONG"].ToString();
                    dr["KTKS_TH_HIEU"] = dt.Rows[i]["KTKS_TH_HIEU"].ToString();
                    dr["KTKS_TH_CO"] = dt.Rows[i]["KTKS_TH_CO"].ToString();
                    dr["KTKS_TH_SOTHAN"] = dt.Rows[i]["KTKS_TH_SOTHAN"].ToString();
                    dr["KTKS_TH_CHISO"] = dt.Rows[i]["KTKS_TH_CHISO"].ToString();
                    dr["KTKS_TH_MAKIEM"] = dt.Rows[i]["KTKS_TH_MAKIEM"].ToString();
                    dr["KTKS_TH_NGAY"] = dt.Rows[i]["KTKS_TH_NGAY"].ToString();
                    ds.Tables["DSThuHoi"].Rows.Add(dr);
                }
                rpt_DSThuHoi rp = new rpt_DSThuHoi();
                rp.SetDataSource(ds);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void btnXoaBamChi_Click(object sender, EventArgs e)
        {
            radCamKet.Checked = false;
            radKTKSBamChiKhoaNuoc.Checked = false;
            radKTKSBamChiThuHoi.Checked = false;
            panelBamChiKhoaNuoc.Visible = false;
            panelBamChiThuHoi.Visible = false;
            panelCamKet.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        #endregion
        
    }
}