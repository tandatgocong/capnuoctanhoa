using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmHoanCongThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmHoanCongThay).Name);
        public frmHoanCongThay()
        {
            InitializeComponent();
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

                txtSoDanhBo.Text = DHN_DANHBO.Replace("-", "");
                txtTenKH.Text = HOTEN;
                txtDiaChi.Text = DIACHI;
                txtNgayGan.ValueObject = DHN_NGAYGAN;
                txtHieuDH.Text = DHN_HIEUDHN;
                txtCo.Text = DHN_CODH;
                txtSoThan.Text = DHN_SOTHAN;
                txtChiSoThay.Text = DHN_CHISO;
                txtLyDoThay.Text = DHN_LYDOTHAY;
            }
            catch (Exception)
            {

            }
        }
    }
}
