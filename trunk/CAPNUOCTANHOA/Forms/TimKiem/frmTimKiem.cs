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

namespace CAPNUOCTANHOA.Forms.TimKiem
{
    public partial class frmTimKiem : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmTimKiem).Name);
        public frmTimKiem()
        {
            InitializeComponent();
            this.searchNgayGan.ValueObject = null;

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
                string searchBangKe = this.searchBangKe.Text;
                string searchDanhBo = this.searchDanhBo.Text.Replace("-", "").Replace(" ", "");
                string searchTenKH = this.searchTenKH.Text.Replace("*", "%");
                string searchDiaChi = this.searchDiaChi.Text.Replace("*", "%");
                string searchLoTrinh = this.searchLoTrinh.Text;
                string searchNgayGan = "".Equals(this.searchNgayGan.Value.ToString()) ? "" : this.searchNgayGan.Value.Date.ToShortDateString();
                dataBangKe.DataSource = DAL.TimKiem.C_TimKiem.search(searchBangKe, searchDanhBo, searchTenKH, searchDiaChi, searchLoTrinh, searchNgayGan);
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
                string ID_BAOTHAY = dataBangKe.Rows[i].Cells["ID_BAOTHAY"].Value + "";

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
                txtHieuDHGan.Text = !HCT_HIEUDHNGAN.Equals("") ? HCT_HIEUDHNGAN : "KENT";

                string HCT_CODHNGAN = dataBangKe.Rows[i].Cells["HCT_CODHNGAN"].Value + "";
                txtGoGan.Text = !HCT_CODHNGAN.Equals("") ? HCT_CODHNGAN : "15";

                string HCT_SOTHANGAN = dataBangKe.Rows[i].Cells["HCT_SOTHANGAN"].Value + "";
                txtSoThanGan.Text = HCT_SOTHANGAN;

                string HCT_CAP = dataBangKe.Rows[i].Cells["HCT_CAP"].Value + "";
                txtCapGan.Text = !HCT_CAP.Equals("") ? HCT_CAP : "C";

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
                txtChiThan.Text = !HCT_CHITHAN.Equals("") ? HCT_CHITHAN : "VN/217";

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


        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            this.searchBangKe.Text = "";
            this.searchDanhBo.Text = "";
            this.searchTenKH.Text = "";
            this.searchDiaChi.Text = "";
            this.searchLoTrinh.Text = "";
            this.searchNgayGan.ValueObject = "";
            searchBangKe.Focus();

        }

        private void searchBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadData();
            }

        }
        
        private void dataBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception)
            {

            }
        }

        private void dataBangKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setData(e.RowIndex);
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}