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
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class tab_TongKetLoaiHinhKD : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TongKetHandHeld).Name);
        public tab_TongKetLoaiHinhKD()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
     
            panel12.Controls.Add(new tab_tab_TongKetLoaiHinhKD());
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            update(ky, nam);
            format();
        }
        public void update(int ky, int nam)
        {
            try
            {

                // ky hien tai
                DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY(nam.ToString(), ky);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC((nam - 1) + "", 12);
                }
                else
                {
                    DAL.QLDHN.C_BC_LoaiHinhKD.CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC(nam.ToString(), ky - 1);
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

        private void sanluongToDS_Click(object sender, EventArgs e)
        {
            format();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_SanLuong_LH();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_LOAIKD ", "W_BAOCAO_LOAIKD"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ SẢN LƯỢNG TỪNG LOẠI KHÁCH HÀNG  KỲ  " + cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam.Text.Trim());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
        //private void btThem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
        //        int nam = int.Parse(txtNam.Text.Trim());

        //        // ky hien tai
        //        DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(nam.ToString(), ky);
        //        // ky truoc
        //        if (ky == 1)
        //        {
        //            DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC((nam - 1) + "", 12);
        //        }
        //        else
        //        {
        //            DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(nam.ToString(), ky - 1);
        //        }

        //        // nam truoc
        //        DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC((nam - 1) + "", ky);

        //        // CAP NHAT SO LIEU 
        //        DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
        //        // so lieu
        //        sanluongToDS.DataSource = DAL.QLDHN.C_BaoCaoTK.get_BAOCAO_SANLUONG();
        //        format();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //}

        //void format()
        //{
        //    double sum_KN_DHN = 0;
        //    double sum_KN_SANLUONG = 0;
        //    double sum_KT_DHN = 0;
        //    double sum_KT_SANLUONG = 0;
        //    double sum_TANGIAM_DHN = 0;
        //    double sum_TANGIAM_SANLUONG = 0;
        //    double sum_NT_DHN = 0;
        //    double sum_NT_SANLUONG = 0;
        //    double sum_NT_TANGIAM_DHN = 0;
        //    double sum_NT_TANGIAM_SANLUONG = 0;
        //    for (int i = 0; i < sanluongToDS.Rows.Count-1; i++)
        //    {
        //        double TANGIAM_DHN = double.Parse(sanluongToDS.Rows[i].Cells["TANGIAM_DHN"].Value + "");
        //        double TANGIAM_SANLUONG = double.Parse(sanluongToDS.Rows[i].Cells["TANGIAM_SANLUONG"].Value + "");
        //        double NT_TANGIAM_DHN = double.Parse(sanluongToDS.Rows[i].Cells["NT_TANGIAM_DHN"].Value + "");
        //        double NT_TANGIAM_SANLUONG = double.Parse(sanluongToDS.Rows[i].Cells["NT_TANGIAM_SANLUONG"].Value + "");

        //        sum_KN_DHN += double.Parse(sanluongToDS.Rows[i].Cells["KN_DHN"].Value + "");
        //        sum_KN_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["KN_SANLUONG"].Value + "");
        //        sum_KT_DHN += double.Parse(sanluongToDS.Rows[i].Cells["KT_DHN"].Value + "");
        //        sum_KT_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["KT_SANLUONG"].Value + "");
        //        sum_TANGIAM_DHN += TANGIAM_DHN;
        //        sum_TANGIAM_SANLUONG += TANGIAM_SANLUONG;
        //        sum_NT_DHN += double.Parse(sanluongToDS.Rows[i].Cells["NT_DHN"].Value + "");
        //        sum_NT_SANLUONG += double.Parse(sanluongToDS.Rows[i].Cells["NT_SANLUONG"].Value + "");
        //        sum_NT_TANGIAM_DHN += NT_TANGIAM_DHN;
        //        sum_NT_TANGIAM_SANLUONG += NT_TANGIAM_SANLUONG;
                
        //        if (TANGIAM_DHN > 0) {
        //            sanluongToDS[6, i].Style.BackColor = Color.Lime;
        //        }
        //        else if (TANGIAM_DHN < 0) {
        //            sanluongToDS[6,i].Style.BackColor = Color.Red;
        //        }
        //        else if (TANGIAM_DHN == 0) {
        //            sanluongToDS[6,i].Style.BackColor = Color.Yellow;
        //        }
        //        /////
        //        if (TANGIAM_SANLUONG > 0)
        //        {
        //            sanluongToDS[7, i].Style.BackColor = Color.Lime;
        //        }
        //        else if (TANGIAM_SANLUONG < 0)
        //        {
        //            sanluongToDS[7, i].Style.BackColor = Color.Red;
        //        }
        //        else if (TANGIAM_SANLUONG == 0)
        //        {
        //            sanluongToDS[7, i].Style.BackColor = Color.Yellow;
        //        }
        //        ////NT_TANGIAM_DHN
        //        if (NT_TANGIAM_DHN > 0)
        //        {
        //            sanluongToDS[10, i].Style.BackColor = Color.Lime;
        //        }
        //        else if (NT_TANGIAM_DHN < 0)
        //        {
        //            sanluongToDS[10, i].Style.BackColor = Color.Red;
        //        }
        //        else if (NT_TANGIAM_DHN == 0)
        //        {
        //            sanluongToDS[10, i].Style.BackColor = Color.Yellow;
        //        }
        //        ////NT_TANGIAM_SANLUONG
        //        if (NT_TANGIAM_SANLUONG > 0)
        //        {
        //            sanluongToDS[11, i].Style.BackColor = Color.Lime;
        //        }
        //        else if (NT_TANGIAM_SANLUONG < 0)
        //        {
        //            sanluongToDS[11, i].Style.BackColor = Color.Red;
        //        }
        //        else if (NT_TANGIAM_SANLUONG == 0)
        //        {
        //            sanluongToDS[11, i].Style.BackColor = Color.Yellow;
        //        }
        //    }
            
        //    int index = sanluongToDS.Rows.Count-1;
            
        //    sanluongToDS.Rows[index].Cells["KN_DHN"].Value = String.Format("{0:0,0}", sum_KN_DHN);
        //    sanluongToDS.Rows[index].Cells["KN_SANLUONG"].Value = String.Format("{0:0,0}", sum_KN_SANLUONG);
        //    sanluongToDS.Rows[index].Cells["KT_DHN"].Value = String.Format("{0:0,0}", sum_KT_DHN);
        //    sanluongToDS.Rows[index].Cells["KT_SANLUONG"].Value = String.Format("{0:0,0}", sum_KT_SANLUONG);
        //    sanluongToDS.Rows[index].Cells["TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_TANGIAM_DHN);
        //    sanluongToDS.Rows[index].Cells["TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_TANGIAM_SANLUONG);
        //    sanluongToDS.Rows[index].Cells["NT_DHN"].Value = String.Format("{0:0,0}", sum_NT_DHN);
        //    sanluongToDS.Rows[index].Cells["NT_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_SANLUONG);
        //    sanluongToDS.Rows[index].Cells["NT_TANGIAM_DHN"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_DHN);
        //    sanluongToDS.Rows[index].Cells["NT_TANGIAM_SANLUONG"].Value = String.Format("{0:0,0}", sum_NT_TANGIAM_SANLUONG);
            
        //    DataGridViewCellStyle style = new DataGridViewCellStyle();
        //    style.Font = new System.Drawing.Font(sanluongToDS.Font, FontStyle.Bold);
        //    sanluongToDS.Rows[index].DefaultCellStyle = style;
        //    sanluongToDS.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        //}

        
        //private void sanluongToDS_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (sanluongToDS.CurrentCell.OwningColumn.Name == "TENTO")
        //    {
        //        string tods = sanluongToDS.Rows[e.RowIndex].Cells["TODS"].Value + "";
        //        try
        //        {
        //            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
        //            int nam = int.Parse(txtNam.Text.Trim());

        //            // ky hien tai
        //            DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY(nam.ToString(), ky);
        //            // ky truoc
        //            if (ky == 1)
        //            {
        //                DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY((nam - 1) + "", 12);
        //            }
        //            else
        //            {
        //                DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY(nam.ToString(), ky - 1);
        //            }

        //            // nam truoc
        //            DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY((nam - 1) + "", ky);

        //            // CAP NHAT SO LIEU 
        //            DAL.QLDHN.C_BaoCaoTK.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY();

        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error(ex.Message);
        //        }
        //    }
           
        //}

       

        //private void sanluongToDS_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{

        //}

        //private void detail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{

        //}

        //private void sanluongToDS_Click(object sender, EventArgs e)
        //{
        //    format();
        //}

        //private void tabControl1_Click(object sender, EventArgs e)
        //{
        //   // panel12.Controls.Clear();
        //    panel12.Controls.Add(new tabtab_TongKetHandHeld_dot());
        //}

        //private void detail_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
         
        //}

        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}
    }
}