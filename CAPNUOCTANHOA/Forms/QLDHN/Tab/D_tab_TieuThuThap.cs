using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class tab_TieuThuThap : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TieuThuThap).Name);
        public tab_TieuThuThap()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int nam = int.Parse(txtNam.Text.Trim());

                // ky hien tai
                DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(nam.ToString(), ky);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC((nam - 1) + "", 12);
                }
                else
                {
                    DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(nam.ToString(), ky - 1);
                }

                // nam truoc
                DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC((nam - 1) + "", ky);

                // CAP NHAT SO LIEU 
                DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
                // so lieu
                sanluongToDS.DataSource = DAL.QLDHN.C_BaoCaoTieuThuThap.get_BAOCAO_SANLUONG();
                format();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        void format()
        {
            double sum_KN_DHN = 0;
            double sum_KN_SANLUONG = 0;
            double sum_KT_DHN = 0;
            double sum_KT_SANLUONG = 0;
            double sum_TANGIAM_DHN = 0;
            double sum_TANGIAM_SANLUONG = 0;
            double sum_NT_DHN = 0;
            double sum_NT_SANLUONG = 0;
            double sum_NT_TANGIAM_DHN = 0;
            double sum_NT_TANGIAM_SANLUONG = 0;
            for (int i = 0; i < sanluongToDS.Rows.Count - 1; i++)
            {
                double TANGIAM_DHN = double.Parse(sanluongToDS.Rows[i].Cells["TANGIAM_DHN"].Value + "");
                double TANGIAM_SANLUONG = double.Parse(sanluongToDS.Rows[i].Cells["TANGIAM_SANLUONG"].Value + "");
                double NT_TANGIAM_DHN = double.Parse(sanluongToDS.Rows[i].Cells["NT_TANGIAM_DHN"].Value + "");
                double NT_TANGIAM_SANLUONG = double.Parse(sanluongToDS.Rows[i].Cells["NT_TANGIAM_SANLUONG"].Value + "");

                sum_KN_DHN += double.Parse(sanluongToDS.Rows[i].Cells["KN_DHN"].Value + "");
                sum_KN_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["KN_SANLUONG"].Value + "");
                sum_KT_DHN += double.Parse(sanluongToDS.Rows[i].Cells["KT_DHN"].Value + "");
                sum_KT_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["KT_SANLUONG"].Value + "");
                sum_TANGIAM_DHN += TANGIAM_DHN;
                sum_TANGIAM_SANLUONG += TANGIAM_SANLUONG;
                sum_NT_DHN += double.Parse(sanluongToDS.Rows[i].Cells["NT_DHN"].Value + "");
                sum_NT_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["NT_SANLUONG"].Value + "");
                sum_NT_TANGIAM_DHN += NT_TANGIAM_DHN;
                sum_NT_TANGIAM_SANLUONG += NT_TANGIAM_SANLUONG;

                if (TANGIAM_DHN > 0)
                {
                    sanluongToDS[6, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_DHN < 0)
                {
                    sanluongToDS[6, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_DHN == 0)
                {
                    sanluongToDS[6, i].Style.BackColor = Color.Yellow;
                }
                /////
                if (TANGIAM_SANLUONG > 0)
                {
                    sanluongToDS[7, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_SANLUONG < 0)
                {
                    sanluongToDS[7, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_SANLUONG == 0)
                {
                    sanluongToDS[7, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_DHN
                if (NT_TANGIAM_DHN > 0)
                {
                    sanluongToDS[10, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_DHN < 0)
                {
                    sanluongToDS[10, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_DHN == 0)
                {
                    sanluongToDS[10, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_SANLUONG
                if (NT_TANGIAM_SANLUONG > 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_SANLUONG < 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_SANLUONG == 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Yellow;
                }
            }

            int index = sanluongToDS.Rows.Count - 1;

            sanluongToDS.Rows[index].Cells["KN_DHN"].Value = String.Format("{0:0,0}", sum_KN_DHN);
            sanluongToDS.Rows[index].Cells["KN_SANLUONG"].Value = String.Format("{0:0,0}", sum_KN_SANLUONG);
            sanluongToDS.Rows[index].Cells["KT_DHN"].Value = String.Format("{0:0,0}", sum_KT_DHN);
            sanluongToDS.Rows[index].Cells["KT_SANLUONG"].Value = String.Format("{0:0,0}", sum_KT_SANLUONG);
            sanluongToDS.Rows[index].Cells["TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_TANGIAM_DHN);
            sanluongToDS.Rows[index].Cells["TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_TANGIAM_SANLUONG);
            sanluongToDS.Rows[index].Cells["NT_DHN"].Value = String.Format("{0:0,0}", sum_NT_DHN);
            sanluongToDS.Rows[index].Cells["NT_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_SANLUONG);
            sanluongToDS.Rows[index].Cells["NT_TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_DHN);
            sanluongToDS.Rows[index].Cells["NT_TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_SANLUONG);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(sanluongToDS.Font, FontStyle.Bold);
            sanluongToDS.Rows[index].DefaultCellStyle = style;
            sanluongToDS.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        }

        string _tods = "";
        private void sanluongToDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sanluongToDS.CurrentCell.OwningColumn.Name == "TENTO")
            {
               
                string tods = sanluongToDS.Rows[e.RowIndex].Cells["TODS"].Value + "";
                _tods = tods;
                try
                {
                    int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                    int nam = int.Parse(txtNam.Text.Trim());

                    // ky hien tai
                    DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY(nam.ToString(), ky);
                    // ky truoc
                    if (ky == 1)
                    {
                        DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY((nam - 1) + "", 12);
                    }
                    else
                    {
                        DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY(nam.ToString(), ky - 1);
                    }

                    // nam truoc
                    DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY((nam - 1) + "", ky);

                    // CAP NHAT SO LIEU 
                    DAL.QLDHN.C_BaoCaoTieuThuThap.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY();

                    tabControl2.Visible = true;
                    detail.DataSource = DAL.QLDHN.C_BaoCaoTieuThuThap.get_BAOCAO_SANLUONG_MAY(int.Parse(tods));
                    formatdetail();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }

        }

        void formatdetail()
        {
            double sum_KN_DHN = 0;
            double sum_KN_SANLUONG = 0;
            double sum_KT_DHN = 0;
            double sum_KT_SANLUONG = 0;
            double sum_TANGIAM_DHN = 0;
            double sum_TANGIAM_SANLUONG = 0;
            double sum_NT_DHN = 0;
            double sum_NT_SANLUONG = 0;
            double sum_NT_TANGIAM_DHN = 0;
            double sum_NT_TANGIAM_SANLUONG = 0;
            for (int i = 0; i < detail.Rows.Count - 1; i++)
            {
                double TANGIAM_DHN = double.Parse(detail.Rows[i].Cells["MAY_TANGIAM_DHN"].Value + "");
                double TANGIAM_SANLUONG = double.Parse(detail.Rows[i].Cells["MAY_TANGIAM_SANLUONG"].Value + "");
                double NT_TANGIAM_DHN = double.Parse(detail.Rows[i].Cells["MAY_NT_TANGIAM_DHN"].Value + "");
                double NT_TANGIAM_SANLUONG = double.Parse(detail.Rows[i].Cells["MAY_NT_TANGIAM_SANLUONG"].Value + "");

                if (TANGIAM_DHN > 0)
                {
                    detail[6 + 1, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_DHN < 0)
                {
                    detail[6 + 1, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_DHN == 0)
                {
                    detail[6 + 1, i].Style.BackColor = Color.Yellow;
                }
                /////
                if (TANGIAM_SANLUONG > 0)
                {
                    detail[7 + 1, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_SANLUONG < 0)
                {
                    detail[7 + 1, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_SANLUONG == 0)
                {
                    detail[7 + 1, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_DHN
                if (NT_TANGIAM_DHN > 0)
                {
                    detail[10 + 1, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_DHN < 0)
                {
                    detail[10 + 1, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_DHN == 0)
                {
                    detail[10 + 1, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_SANLUONG
                if (NT_TANGIAM_SANLUONG > 0)
                {
                    detail[11 + 1, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_SANLUONG < 0)
                {
                    detail[11 + 1, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_SANLUONG == 0)
                {
                    detail[11 + 1, i].Style.BackColor = Color.Yellow;
                }

                sum_KN_DHN += double.Parse(detail.Rows[i].Cells["MAY_KN_DHN"].Value + "");
                sum_KN_SANLUONG += double.Parse(detail.Rows[i].Cells["MAY_KN_SANLUONG"].Value + "");
                sum_KT_DHN += double.Parse(detail.Rows[i].Cells["MAY_KT_DHN"].Value + "");
                sum_KT_SANLUONG += double.Parse(detail.Rows[i].Cells["MAY_KT_SANLUONG"].Value + "");
                sum_TANGIAM_DHN += TANGIAM_DHN;
                sum_TANGIAM_SANLUONG += TANGIAM_SANLUONG;
                sum_NT_DHN += double.Parse(detail.Rows[i].Cells["MAY_NT_DHN"].Value + "");
                sum_NT_SANLUONG += double.Parse(detail.Rows[i].Cells["MAY_NT_SANLUONG"].Value + "");
                sum_NT_TANGIAM_DHN += NT_TANGIAM_DHN;
                sum_NT_TANGIAM_SANLUONG += NT_TANGIAM_SANLUONG;
                ///
                try
                {
                    string mayds = detail.Rows[i].Cells["MAYDS"].Value + "";
                    detail.Rows[i].Cells["NHAVIEN"].Value = DAL.QLDHN.C_QuanLyDongHoNuoc.getNhanVienDS(int.Parse(mayds));
                }
                catch (Exception)
                {

                }
            }
            int index = detail.Rows.Count - 1;
            detail.Rows[index].Cells["MAY_KN_DHN"].Value = String.Format("{0:0,0}", sum_KN_DHN);
            detail.Rows[index].Cells["MAY_KN_SANLUONG"].Value = String.Format("{0:0,0}", sum_KN_SANLUONG);
            detail.Rows[index].Cells["MAY_KT_DHN"].Value = String.Format("{0:0,0}", sum_KT_DHN);
            detail.Rows[index].Cells["MAY_KT_SANLUONG"].Value = String.Format("{0:0,0}", sum_KT_SANLUONG);
            detail.Rows[index].Cells["MAY_TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_TANGIAM_DHN);
            detail.Rows[index].Cells["MAY_TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_TANGIAM_SANLUONG);
            detail.Rows[index].Cells["MAY_NT_DHN"].Value = String.Format("{0:0,0}", sum_NT_DHN);
            detail.Rows[index].Cells["MAY_NT_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_SANLUONG);
            detail.Rows[index].Cells["MAY_NT_TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_DHN);
            detail.Rows[index].Cells["MAY_NT_TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_SANLUONG);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(detail.Font, FontStyle.Bold);
            detail.Rows[index].DefaultCellStyle = style;
            detail.Rows[index].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void sanluongToDS_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void detail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void sanluongToDS_Click(object sender, EventArgs e)
        {
            format();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            // panel12.Controls.Clear();
            panel12.Controls.Add(new tab_TieuThuThap_dot());
        }

        private void detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formatdetail();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_SanLuong_Thap();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_SANLUONG ", "W_BAOCAO_SANLUONG"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ KHÁCH HÀNG TIÊU THỤ THẤP KỲ  " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim());
            rp.SetParameterValue("tiude", ""); 
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            string sql = "  SELECT nv.TODS, nv.NAME 'TENTO', KN_DHN, KN_SANLUONG, KT_DHN, KT_SANLUONG, TANGIAM_DHN, TANGIAM_SANLUONG, NT_DHN, NT_SANLUONG, NT_TANGIAM_DHN, NT_TANGIAM_SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY bc, TB_NHANVIENDOCSO nv ";
            sql += " WHERE bc.MAYDS = nv.MAYDS  AND bc.TODS='"+_tods+"' ";
            sql += " ORDER BY nv.MAYDS ASC ";

            string tods_ = sanluongToDS.Rows[sanluongToDS.CurrentRow.Index].Cells["TENTO"].Value + "";
            ReportDocument rp = new rpt_tab_SanLuong_Thap();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report(sql, "W_BAOCAO_SANLUONG"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ KHÁCH HÀNG TIÊU THỤ THẤP KỲ  " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim() + " " +tods_);
            rp.SetParameterValue("tiude", "NV"); 
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }
}