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
            DG_ChuaGiao.DataSource = DAL.QLDHN.C_PhieuKiemTra.getListByCode(TODS, DOT, KY, NAM, "60");
            Utilities.DataGridV.formatRows(DG_ChuaGiao, "DANHBO", "LOTRINH");
            if (DG_ChuaGiao.Rows.Count > 0) {

                btInKT.Visible = true;
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
            LoadData();
            btInKT.Visible = false;
        }

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
                        try
                        {
                            ReportDocument rp = new rpt_PhieuDeNghiKT();
                            rp.SetDataSource(DAL.QLDHN.C_PhieuKiemTra.getListHoaDonReport(DANHBO, NAM, KY, DOT));
                            rp.SetParameterValue("ky", KY);
                            rp.PrintToPrinter(1, false, 0, 0);
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
                            MessageBox.Show(this, "Lỗi Khi Chuyển Kiểm Tra", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            break;
                        }
                        // dataT  NGAYCHUYEN DATETIME,
                        //string   GIOCHUYEN TIME,	 
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                log.Error("--" + ex.Message);
            }
        }
        /* ---------------------- */
       
    }
}