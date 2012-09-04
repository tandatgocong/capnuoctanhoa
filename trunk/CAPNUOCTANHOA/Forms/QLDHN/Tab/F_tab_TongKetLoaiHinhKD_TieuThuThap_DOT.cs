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
    public partial class F_tab_TongKetLoaiHinhKD_TieuThuThap_DOT : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_tab_TongKetLoaiHinhKD).Name);
        public F_tab_TongKetLoaiHinhKD_TieuThuThap_DOT()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            update(ky, nam,dot);
             format();
        }
        public void update(int ky, int nam, int dot)
        {
            try
            {

                 //ky hien tai
                DAL.QLDHN.C_BC_LoaiHinhKD_Thap.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_DOT(nam.ToString(), ky,dot);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD_Thap.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_DOT((nam - 1) + "", 12, dot);
                }
                else
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD_Thap.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_DOT(nam.ToString(), ky - 1, dot);
                }

                // nam truoc

                // CAP NHAT SO LIEU 
                // so lieu
                sanluongToDS.DataSource = DAL.QLDHN.C_BC_LoaiHinhKD_Thap.get_BAOCAO_SANLUONG();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        void format()
        {
            double sum_KN_SH0 = 0; double sum_KN_SH4 = 0;
            double sum_KN_SX0 = 0; double sum_KN_SX4 = 0;
            double sum_KN_KD0 = 0; double sum_KN_KD4 = 0;
            double sum_KN_CC0 = 0; double sum_KN_CC4 = 0;
            double sum_KN_HCSN0 = 0; double sum_KN_HCSN4 = 0;
            double sum_KT_SH0 = 0; double sum_KT_SH4 = 0;
            double sum_KT_SX0 = 0; double sum_KT_SX4 = 0;
            double sum_KT_KD0 = 0; double sum_KT_KD4 = 0;
            double sum_KT_CC0 = 0; double sum_KT_CC4 = 0;
            double sum_KT_HCSN0 = 0; double sum_KT_HCSN4 = 0;
            for (int i = 0; i < sanluongToDS.Rows.Count - 1; i++)
            {
                double KN_SH0 = double.Parse(sanluongToDS.Rows[i].Cells["KN_SH0"].Value + "");
                double KN_SH4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_SH4"].Value + "");
                double KN_SX0 = double.Parse(sanluongToDS.Rows[i].Cells["KN_SX0"].Value + "");
                double KN_SX4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_SX4"].Value + "");
                double KN_KD0 = double.Parse(sanluongToDS.Rows[i].Cells["KN_KD0"].Value + "");
                double KN_KD4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_KD4"].Value + "");
                double KN_CC0 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CC0"].Value + "");
                double KN_CC4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CC4"].Value + "");
                double KN_HCSN0 = double.Parse(sanluongToDS.Rows[i].Cells["KN_HCSN0"].Value + "");
                double KN_HCSN4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_HCSN4"].Value + "");
                double KT_SH0 = double.Parse(sanluongToDS.Rows[i].Cells["KT_SH0"].Value + "");
                double KT_SH4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_SH4"].Value + "");
                double KT_SX0 = double.Parse(sanluongToDS.Rows[i].Cells["KT_SX0"].Value + "");
                double KT_SX4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_SX4"].Value + "");
                double KT_KD0 = double.Parse(sanluongToDS.Rows[i].Cells["KT_KD0"].Value + "");
                double KT_KD4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_KD4"].Value + "");
                double KT_CC0 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CC0"].Value + "");
                double KT_CC4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CC4"].Value + "");
                double KT_HCSN0 = double.Parse(sanluongToDS.Rows[i].Cells["KT_HCSN0"].Value + "");
                double KT_HCSN4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_HCSN4"].Value + "");
                line(KN_SH0 - KT_SH0, 2, i);
                line(KN_SX0 - KT_SX0, 4, i);
                line(KN_KD0 - KT_KD0, 6, i);
                line(KN_CC0 - KT_CC0, 8, i);
                line(KN_HCSN0 - KT_HCSN0, 10, i);
                line(KN_SH4 - KT_SH4, 3, i);
                line(KN_SX4 - KT_SX4, 5, i);
                line(KN_KD4 - KT_KD4, 7, i);
                line(KN_CC4 - KT_CC4, 9, i);
                line(KN_HCSN4 - KT_HCSN4, 11, i);

                sum_KN_SH0 += KN_SH0; sum_KN_SH4 += KN_SH4;
                sum_KN_SX0 += KN_SX0; sum_KN_SX4 += KN_SX4;
                sum_KN_KD0 += KN_KD0; sum_KN_KD4 += KN_KD4;
                sum_KN_CC0 += KN_CC0; sum_KN_CC4 += KN_CC4;
                sum_KN_HCSN0 += KN_HCSN0; sum_KN_HCSN4 += KN_HCSN4;
                sum_KT_SH0 += KT_SH0; sum_KT_SH4 += KT_SH4;
                sum_KT_SX0 += KT_SX0; sum_KT_SX4 += KT_SX4;
                sum_KT_KD0 += KT_KD0; sum_KT_KD4 += KT_KD4;
                sum_KT_CC0 += KT_CC0; sum_KT_CC4 += KT_CC4;
                sum_KT_HCSN0 += KT_HCSN0; sum_KT_HCSN4 += KT_HCSN4;
            }

            int index = sanluongToDS.Rows.Count - 1;
            sanluongToDS.Rows[index].Cells["KN_SH0"].Value = String.Format("{0:0,0}", sum_KN_SH0);
            sanluongToDS.Rows[index].Cells["KN_SH4"].Value = String.Format("{0:0,0}", sum_KN_SH4);
            sanluongToDS.Rows[index].Cells["KN_SX0"].Value = String.Format("{0:0,0}", sum_KN_SX0);
            sanluongToDS.Rows[index].Cells["KN_SX4"].Value = String.Format("{0:0,0}", sum_KN_SX4);
            sanluongToDS.Rows[index].Cells["KN_KD0"].Value = String.Format("{0:0,0}", sum_KN_KD0);
            sanluongToDS.Rows[index].Cells["KN_KD4"].Value = String.Format("{0:0,0}", sum_KN_KD4);
            sanluongToDS.Rows[index].Cells["KN_CC0"].Value = String.Format("{0:0,0}", sum_KN_CC0);
            sanluongToDS.Rows[index].Cells["KN_CC4"].Value = String.Format("{0:0,0}", sum_KN_CC4);
            sanluongToDS.Rows[index].Cells["KN_HCSN0"].Value = String.Format("{0:0,0}", sum_KN_HCSN0);
            sanluongToDS.Rows[index].Cells["KN_HCSN4"].Value = String.Format("{0:0,0}", sum_KN_HCSN4);
            sanluongToDS.Rows[index].Cells["KT_SH0"].Value = String.Format("{0:0,0}", sum_KT_SH0);
            sanluongToDS.Rows[index].Cells["KT_SH4"].Value = String.Format("{0:0,0}", sum_KT_SH4);
            sanluongToDS.Rows[index].Cells["KT_SX0"].Value = String.Format("{0:0,0}", sum_KT_SX0);
            sanluongToDS.Rows[index].Cells["KT_SX4"].Value = String.Format("{0:0,0}", sum_KT_SX4);
            sanluongToDS.Rows[index].Cells["KT_KD0"].Value = String.Format("{0:0,0}", sum_KT_KD0);
            sanluongToDS.Rows[index].Cells["KT_KD4"].Value = String.Format("{0:0,0}", sum_KT_KD4);
            sanluongToDS.Rows[index].Cells["KT_CC0"].Value = String.Format("{0:0,0}", sum_KT_CC0);
            sanluongToDS.Rows[index].Cells["KT_CC4"].Value = String.Format("{0:0,0}", sum_KT_CC4);
            sanluongToDS.Rows[index].Cells["KT_HCSN0"].Value = String.Format("{0:0,0}", sum_KT_HCSN0);
            sanluongToDS.Rows[index].Cells["KT_HCSN4"].Value = String.Format("{0:0,0}", sum_KT_HCSN4);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(sanluongToDS.Font, FontStyle.Bold);
            sanluongToDS.Rows[index].DefaultCellStyle = style;
            sanluongToDS.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        }
        public void line(double result, int i, int j)
        {
            if (result > 0)
            {
                sanluongToDS[i, j].Style.BackColor = Color.Lime;
            }
            else if (result < 0)
            {
                sanluongToDS[i, j].Style.BackColor = Color.Red;
            }
            else if (result == 0)
            {
                sanluongToDS[i, j].Style.BackColor = Color.Yellow;
            }
        }

        private void sanluongToDS_Click(object sender, EventArgs e)
        {
            format();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_LoaiKHTieuThuThap();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_LOAIKD_THAP ", "W_BAOCAO_LOAIKD_THAP"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ TIÊU THỤ THẤP THEO ĐỐI TƯỢNG SỮ DỤNG NƯỚC ĐỢT " + cbDotDS.Items[cbDotDS.SelectedIndex].ToString() + " KỲ  " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }
}
