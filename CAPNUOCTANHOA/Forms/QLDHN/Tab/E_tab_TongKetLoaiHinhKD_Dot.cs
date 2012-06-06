using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class tab_tab_TongKetLoaiHinhKD : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_tab_TongKetLoaiHinhKD).Name);
        public tab_tab_TongKetLoaiHinhKD()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;
        }
        public void update(int ky, int nam, int dot)
        {
            try
            {

                // ky hien tai
                DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_DOT(nam.ToString(), ky, dot);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_DOT((nam - 1) + "", 12, dot);
                }
                else
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_DOT(nam.ToString(), ky - 1, dot);
                }

                // nam truoc

                // CAP NHAT SO LIEU 
                // so lieu
                sanluongToDS.DataSource = DAL.QLDHN.C_BC_LoaiHinhKD.get_BAOCAO_SANLUONG();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        void format()
        {
            double sum_KN_SH_DH = 0; double sum_KN_SH_SL = 0;
            double sum_KN_SX_DH = 0; double sum_KN_SX_SL = 0;
            double sum_KN_KD_DH = 0; double sum_KN_KD_SL = 0;
            double sum_KN_CC_DH = 0; double sum_KN_CC_SL = 0;
            double sum_KN_HCSN_DH = 0; double sum_KN_HCSN_SL = 0;
            double sum_KT_SH_DH = 0; double sum_KT_SH_SL = 0;
            double sum_KT_SX_DH = 0; double sum_KT_SX_SL = 0;
            double sum_KT_KD_DH = 0; double sum_KT_KD_SL = 0;
            double sum_KT_CC_DH = 0; double sum_KT_CC_SL = 0;
            double sum_KT_HCSN_DH = 0; double sum_KT_HCSN_SL = 0;
            for (int i = 0; i < sanluongToDS.Rows.Count - 1; i++)
            {
                double KN_SH_DH = double.Parse(sanluongToDS.Rows[i].Cells["KN_SH_DH"].Value + "");
                double KN_SH_SL = double.Parse(sanluongToDS.Rows[i].Cells["KN_SH_SL"].Value + "");
                double KN_SX_DH = double.Parse(sanluongToDS.Rows[i].Cells["KN_SX_DH"].Value + "");
                double KN_SX_SL = double.Parse(sanluongToDS.Rows[i].Cells["KN_SX_SL"].Value + "");
                double KN_KD_DH = double.Parse(sanluongToDS.Rows[i].Cells["KN_KD_DH"].Value + "");
                double KN_KD_SL = double.Parse(sanluongToDS.Rows[i].Cells["KN_KD_SL"].Value + "");
                double KN_CC_DH = double.Parse(sanluongToDS.Rows[i].Cells["KN_CC_DH"].Value + "");
                double KN_CC_SL = double.Parse(sanluongToDS.Rows[i].Cells["KN_CC_SL"].Value + "");
                double KN_HCSN_DH = double.Parse(sanluongToDS.Rows[i].Cells["KN_HCSN_DH"].Value + "");
                double KN_HCSN_SL = double.Parse(sanluongToDS.Rows[i].Cells["KN_HCSN_SL"].Value + "");
                double KT_SH_DH = double.Parse(sanluongToDS.Rows[i].Cells["KT_SH_DH"].Value + "");
                double KT_SH_SL = double.Parse(sanluongToDS.Rows[i].Cells["KT_SH_SL"].Value + "");
                double KT_SX_DH = double.Parse(sanluongToDS.Rows[i].Cells["KT_SX_DH"].Value + "");
                double KT_SX_SL = double.Parse(sanluongToDS.Rows[i].Cells["KT_SX_SL"].Value + "");
                double KT_KD_DH = double.Parse(sanluongToDS.Rows[i].Cells["KT_KD_DH"].Value + "");
                double KT_KD_SL = double.Parse(sanluongToDS.Rows[i].Cells["KT_KD_SL"].Value + "");
                double KT_CC_DH = double.Parse(sanluongToDS.Rows[i].Cells["KT_CC_DH"].Value + "");
                double KT_CC_SL = double.Parse(sanluongToDS.Rows[i].Cells["KT_CC_SL"].Value + "");
                double KT_HCSN_DH = double.Parse(sanluongToDS.Rows[i].Cells["KT_HCSN_DH"].Value + "");
                double KT_HCSN_SL = double.Parse(sanluongToDS.Rows[i].Cells["KT_HCSN_SL"].Value + "");
                line(KN_SH_DH - KT_SH_DH, 2, i); line(KN_SH_SL - KT_SH_SL, 3, i);
                line(KN_SX_DH - KT_SX_DH, 4, i); line(KN_SX_SL - KT_SX_SL, 5, i);
                line(KN_KD_DH - KT_KD_DH, 6, i); line(KN_KD_SL - KT_KD_SL, 7, i);
                line(KN_CC_DH - KT_CC_DH, 8, i); line(KN_CC_SL - KT_CC_SL, 9, i);
                line(KN_HCSN_DH - KT_HCSN_DH, 10, i); line(KN_HCSN_SL - KT_HCSN_SL, 11, i);

                sum_KN_SH_DH += KN_SH_DH; sum_KN_SH_SL += KN_SH_SL;
                sum_KN_SX_DH += KN_SX_DH; sum_KN_SX_SL += KN_SX_SL;
                sum_KN_KD_DH += KN_KD_DH; sum_KN_KD_SL += KN_KD_SL;
                sum_KN_CC_DH += KN_CC_DH; sum_KN_CC_SL += KN_CC_SL;
                sum_KN_HCSN_DH += KN_HCSN_DH; sum_KN_HCSN_SL += KN_HCSN_SL;
                sum_KT_SH_DH += KT_SH_DH; sum_KT_SH_SL += KT_SH_SL;
                sum_KT_SX_DH += KT_SX_DH; sum_KT_SX_SL += KT_SX_SL;
                sum_KT_KD_DH += KT_KD_DH; sum_KT_KD_SL += KT_KD_SL;
                sum_KT_CC_DH += KT_CC_DH; sum_KT_CC_SL += KT_CC_SL;
                sum_KT_HCSN_DH += KT_HCSN_DH; sum_KT_HCSN_SL += KT_HCSN_SL;
            }

            int index = sanluongToDS.Rows.Count - 1;
            sanluongToDS.Rows[index].Cells["KN_SH_DH"].Value = String.Format("{0:0,0}", sum_KN_SH_DH);
            sanluongToDS.Rows[index].Cells["KN_SH_SL"].Value = String.Format("{0:0,0}", sum_KN_SH_SL);
            sanluongToDS.Rows[index].Cells["KN_SX_DH"].Value = String.Format("{0:0,0}", sum_KN_SX_DH);
            sanluongToDS.Rows[index].Cells["KN_SX_SL"].Value = String.Format("{0:0,0}", sum_KN_SX_SL);
            sanluongToDS.Rows[index].Cells["KN_KD_DH"].Value = String.Format("{0:0,0}", sum_KN_KD_DH);
            sanluongToDS.Rows[index].Cells["KN_KD_SL"].Value = String.Format("{0:0,0}", sum_KN_KD_SL);
            sanluongToDS.Rows[index].Cells["KN_CC_DH"].Value = String.Format("{0:0,0}", sum_KN_CC_DH);
            sanluongToDS.Rows[index].Cells["KN_CC_SL"].Value = String.Format("{0:0,0}", sum_KN_CC_SL);
            sanluongToDS.Rows[index].Cells["KN_HCSN_DH"].Value = String.Format("{0:0,0}", sum_KN_HCSN_DH);
            sanluongToDS.Rows[index].Cells["KN_HCSN_SL"].Value = String.Format("{0:0,0}", sum_KN_HCSN_SL);
            sanluongToDS.Rows[index].Cells["KT_SH_DH"].Value = String.Format("{0:0,0}", sum_KT_SH_DH);
            sanluongToDS.Rows[index].Cells["KT_SH_SL"].Value = String.Format("{0:0,0}", sum_KT_SH_SL);
            sanluongToDS.Rows[index].Cells["KT_SX_DH"].Value = String.Format("{0:0,0}", sum_KT_SX_DH);
            sanluongToDS.Rows[index].Cells["KT_SX_SL"].Value = String.Format("{0:0,0}", sum_KT_SX_SL);
            sanluongToDS.Rows[index].Cells["KT_KD_DH"].Value = String.Format("{0:0,0}", sum_KT_KD_DH);
            sanluongToDS.Rows[index].Cells["KT_KD_SL"].Value = String.Format("{0:0,0}", sum_KT_KD_SL);
            sanluongToDS.Rows[index].Cells["KT_CC_DH"].Value = String.Format("{0:0,0}", sum_KT_CC_DH);
            sanluongToDS.Rows[index].Cells["KT_CC_SL"].Value = String.Format("{0:0,0}", sum_KT_CC_SL);
            sanluongToDS.Rows[index].Cells["KT_HCSN_DH"].Value = String.Format("{0:0,0}", sum_KT_HCSN_DH);
            sanluongToDS.Rows[index].Cells["KT_HCSN_SL"].Value = String.Format("{0:0,0}", sum_KT_HCSN_SL);

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

        private void btThem_Click(object sender, EventArgs e)
        {
            int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            update(ky, nam, dot);
            format();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_SanLuong_LH();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_LOAIKD ", "W_BAOCAO_LOAIKD"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ SẢN LƯỢNG TỪNG LOẠI KHÁCH HÀNG ĐỢT " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + " KỲ " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void sanluongToDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sanluongToDS.CurrentCell.OwningColumn.Name == "TENTO")
            {
                string tods = sanluongToDS.Rows[e.RowIndex].Cells["TODS"].Value + "";
                try
                {
                    int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                    int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                    int nam = int.Parse(txtNam.Text.Trim());

                    // ky hien tai
                    DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_MAY_DOT(nam.ToString(), ky,dot);
                    // ky truoc
                    if (ky == 1)
                    {
                        DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_MAY_DOT((nam - 1) + "", 12,dot);
                    }
                    else
                    {
                        DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_MAY_DOT(nam.ToString(), ky - 1,dot);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
                tabControl2.Visible = true;
                dataGridView1.DataSource = DAL.QLDHN.C_BC_LoaiHinhKD.get_BAOCAO_BAOCAO_LOAIKD_MAY(int.Parse(tods));
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                    try
                    {
                        string mayds = dataGridView1.Rows[i].Cells["MAYDS"].Value + "";
                        dataGridView1.Rows[i].Cells["NHANVIEN"].Value = DAL.QLDHN.C_QuanLyDongHoNuoc.getNhanVienDS(int.Parse(mayds));
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                }
            }
        }
    }
}