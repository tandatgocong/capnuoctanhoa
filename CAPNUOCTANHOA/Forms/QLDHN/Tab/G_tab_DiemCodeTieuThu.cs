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
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class G_tab_DiemCodeTieuThu : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(G_tab_DiemCodeTieuThu).Name);
        public G_tab_DiemCodeTieuThu()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

            this.txtNam_dot.Text = DateTime.Now.Year.ToString();
            cbKyDS_dot.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                int nam = int.Parse(txtNam.Text.Trim());

                // ky hien tai
                DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY(nam.ToString(), ky, checkHD0.Checked);
                DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL(nam.ToString(), ky);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC((nam - 1) + "", 12, checkHD0.Checked);
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL((nam - 1) + "", 12);
                }
                else
                {
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC(nam.ToString(), ky - 1, checkHD0.Checked);
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL(nam.ToString(), ky - 1);
                }

                // CAP NHAT SO LIEU 
                //     DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
                // so lieu
                sanluongToDS.DataSource = DAL.QLDHN.C_BaoCaoCODE.get_BAOCAO_CODE();
                format();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        void format()
        {
            double sum_KN_CODE4 = 0; double sum_KN_CODE5 = 0;
            double sum_KN_CODE6 = 0; double sum_KN_CODE8 = 0;
            double sum_KN_CODEM = 0; double sum_KN_CODEN = 0;
            double sum_KN_CODEQ = 0; double sum_KN_CODEF = 0;
            double sum_KN_CODEK = 0; double sum_KT_CODE4 = 0;
            double sum_KT_CODE5 = 0; double sum_KT_CODE6 = 0;
            double sum_KT_CODE8 = 0; double sum_KT_CODEM = 0;
            double sum_KT_CODEN = 0; double sum_KT_CODEQ = 0;
            double sum_KT_CODEF = 0; double sum_KT_CODEK = 0;
            for (int i = 0; i < sanluongToDS.Rows.Count - 1; i++)
            {
                double KN_CODE4 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODE4"].Value + "");
                double KN_CODE5 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODE5"].Value + "");
                double KN_CODE6 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODE6"].Value + "");
                double KN_CODE8 = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODE8"].Value + "");
                double KN_CODEM = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODEM"].Value + "");
                double KN_CODEN = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODEN"].Value + "");
                double KN_CODEQ = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODEQ"].Value + "");
                double KN_CODEF = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODEF"].Value + "");
                double KN_CODEK = double.Parse(sanluongToDS.Rows[i].Cells["KN_CODEK"].Value + "");
                double KT_CODE4 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODE4"].Value + "");
                double KT_CODE5 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODE5"].Value + "");
                double KT_CODE6 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODE6"].Value + "");
                double KT_CODE8 = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODE8"].Value + "");
                double KT_CODEM = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODEM"].Value + "");
                double KT_CODEN = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODEN"].Value + "");
                double KT_CODEQ = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODEQ"].Value + "");
                double KT_CODEF = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODEF"].Value + "");
                double KT_CODEK = double.Parse(sanluongToDS.Rows[i].Cells["KT_CODEK"].Value + "");
                line(KN_CODE4 - KT_CODE4, 2, i);
                line(KN_CODE5 - KT_CODEM, 3, i);
                line(KN_CODE6 - KT_CODE5, 4, i);
                line(KN_CODE8 - KT_CODEN, 5, i);
                line(KN_CODEM - KT_CODE6, 6, i);
                line(KN_CODEN - KT_CODEQ, 7, i);
                line(KN_CODEQ - KT_CODE8, 8, i);
                line(KN_CODEF - KT_CODEF, 9, i);
                line(KN_CODEK - KT_CODEK, 10, i);

                sum_KN_CODE4 += KN_CODE4; sum_KN_CODE5 += KN_CODE5;
                sum_KN_CODE6 += KN_CODE6; sum_KN_CODE8 += KN_CODE8;
                sum_KN_CODEM += KN_CODEM; sum_KN_CODEN += KN_CODEN;
                sum_KN_CODEQ += KN_CODEQ; sum_KN_CODEF += KN_CODEF;
                sum_KN_CODEK += KN_CODEK; sum_KT_CODE4 += KT_CODE4;
                sum_KT_CODE5 += KT_CODE5; sum_KT_CODE6 += KT_CODE6;
                sum_KT_CODE8 += KT_CODE8; sum_KT_CODEM += KT_CODEM;
                sum_KT_CODEN += KT_CODEN; sum_KT_CODEQ += KT_CODEQ;
                sum_KT_CODEF += KT_CODEF; sum_KT_CODEK += KT_CODEK;
            }

            int index = sanluongToDS.Rows.Count - 1;
            sanluongToDS.Rows[index].Cells["KN_CODE4"].Value = String.Format("{0:0,0}", sum_KN_CODE4);
            sanluongToDS.Rows[index].Cells["KN_CODE5"].Value = String.Format("{0:0,0}", sum_KN_CODE5);
            sanluongToDS.Rows[index].Cells["KN_CODE6"].Value = String.Format("{0:0,0}", sum_KN_CODE6);
            sanluongToDS.Rows[index].Cells["KN_CODE8"].Value = String.Format("{0:0,0}", sum_KN_CODE8);
            sanluongToDS.Rows[index].Cells["KN_CODEM"].Value = String.Format("{0:0,0}", sum_KN_CODEM);
            sanluongToDS.Rows[index].Cells["KN_CODEN"].Value = String.Format("{0:0,0}", sum_KN_CODEN);
            sanluongToDS.Rows[index].Cells["KN_CODEQ"].Value = String.Format("{0:0,0}", sum_KN_CODEQ);
            sanluongToDS.Rows[index].Cells["KN_CODEF"].Value = String.Format("{0:0,0}", sum_KN_CODEF);
            sanluongToDS.Rows[index].Cells["KN_CODEK"].Value = String.Format("{0:0,0}", sum_KN_CODEK);

            sanluongToDS.Rows[index].Cells["KT_CODE4"].Value = String.Format("{0:0,0}", sum_KT_CODE4);
            sanluongToDS.Rows[index].Cells["KT_CODE5"].Value = String.Format("{0:0,0}", sum_KT_CODE5);
            sanluongToDS.Rows[index].Cells["KT_CODE6"].Value = String.Format("{0:0,0}", sum_KT_CODE6);
            sanluongToDS.Rows[index].Cells["KT_CODE8"].Value = String.Format("{0:0,0}", sum_KT_CODE8);
            sanluongToDS.Rows[index].Cells["KT_CODEM"].Value = String.Format("{0:0,0}", sum_KT_CODEM);
            sanluongToDS.Rows[index].Cells["KT_CODEN"].Value = String.Format("{0:0,0}", sum_KT_CODEN);
            sanluongToDS.Rows[index].Cells["KT_CODEQ"].Value = String.Format("{0:0,0}", sum_KT_CODEQ);
            sanluongToDS.Rows[index].Cells["KT_CODEF"].Value = String.Format("{0:0,0}", sum_KT_CODEF);

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

        public void linedetail(double result, int i, int j)
        {
            if (result > 0)
            {
                detail[i, j].Style.BackColor = Color.Lime;
            }
            else if (result < 0)
            {
                detail[i, j].Style.BackColor = Color.Red;
            }
            else if (result == 0)
            {
                detail[i, j].Style.BackColor = Color.Yellow;
            }
        }

        string tods = "";
        string tento = "";
        private void sanluongToDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sanluongToDS.CurrentCell.OwningColumn.Name == "TENTO")
            {

                tento = sanluongToDS.Rows[e.RowIndex].Cells["TENTO"].Value + "";
                tods = sanluongToDS.Rows[e.RowIndex].Cells["TODS"].Value + "";
                try
                {
                    int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
                    int nam = int.Parse(txtNam.Text.Trim());

                    // ky hien tai
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYNAY(nam.ToString(), ky,checkHD0.Checked);
                    // ky truoc
                    if (ky == 1)
                    {
                        DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYTRUOC((nam - 1) + "", 12, checkHD0.Checked);
                    }
                    else
                    {
                        DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYTRUOC(nam.ToString(), ky - 1, checkHD0.Checked);
                    }


                    tabControl2.Visible = true;
                    detail.DataSource = DAL.QLDHN.C_BaoCaoCODE.get_BAOCAO_CODE_MAY(int.Parse(tods));
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
            double sum_KN_CODE4 = 0; double sum_KN_CODE5 = 0;
            double sum_KN_CODE6 = 0; double sum_KN_CODE8 = 0;
            double sum_KN_CODEM = 0; double sum_KN_CODEN = 0;
            double sum_KN_CODEQ = 0; double sum_KN_CODEF = 0;
            double sum_KN_CODEK = 0; double sum_KT_CODE4 = 0;
            double sum_KT_CODE5 = 0; double sum_KT_CODE6 = 0;
            double sum_KT_CODE8 = 0; double sum_KT_CODEM = 0;
            double sum_KT_CODEN = 0; double sum_KT_CODEQ = 0;
            double sum_KT_CODEF = 0; double sum_KT_CODEK = 0;
            for (int i = 0; i < detail.Rows.Count - 1; i++)
            {
                double KN_CODE4 = double.Parse(detail.Rows[i].Cells["M_KN_CODE4"].Value + "");
                double KN_CODE5 = double.Parse(detail.Rows[i].Cells["M_KN_CODE5"].Value + "");
                double KN_CODE6 = double.Parse(detail.Rows[i].Cells["M_KN_CODE6"].Value + "");
                double KN_CODE8 = double.Parse(detail.Rows[i].Cells["M_KN_CODE8"].Value + "");
                double KN_CODEM = double.Parse(detail.Rows[i].Cells["M_KN_CODEM"].Value + "");
                double KN_CODEN = double.Parse(detail.Rows[i].Cells["M_KN_CODEN"].Value + "");
                double KN_CODEQ = double.Parse(detail.Rows[i].Cells["M_KN_CODEQ"].Value + "");
                double KN_CODEF = double.Parse(detail.Rows[i].Cells["M_KN_CODEF"].Value + "");
                double KN_CODEK = double.Parse(detail.Rows[i].Cells["M_KN_CODEK"].Value + "");
                double KT_CODE4 = double.Parse(detail.Rows[i].Cells["M_KT_CODE4"].Value + "");
                double KT_CODE5 = double.Parse(detail.Rows[i].Cells["M_KT_CODE5"].Value + "");
                double KT_CODE6 = double.Parse(detail.Rows[i].Cells["M_KT_CODE6"].Value + "");
                double KT_CODE8 = double.Parse(detail.Rows[i].Cells["M_KT_CODE8"].Value + "");
                double KT_CODEM = double.Parse(detail.Rows[i].Cells["M_KT_CODEM"].Value + "");
                double KT_CODEN = double.Parse(detail.Rows[i].Cells["M_KT_CODEN"].Value + "");
                double KT_CODEQ = double.Parse(detail.Rows[i].Cells["M_KT_CODEQ"].Value + "");
                double KT_CODEF = double.Parse(detail.Rows[i].Cells["M_KT_CODEF"].Value + "");
                double KT_CODEK = double.Parse(detail.Rows[i].Cells["M_KT_CODEK"].Value + "");
                linedetail(KN_CODE4 - KT_CODE4, 2 +1, i);
                linedetail(KN_CODE5 - KT_CODEM, 3 + 1, i);
                linedetail(KN_CODE6 - KT_CODE5, 4 + 1, i);
                linedetail(KN_CODE8 - KT_CODEN, 5 + 1, i);
                linedetail(KN_CODEM - KT_CODE6, 6 + 1, i);
                linedetail(KN_CODEN - KT_CODEQ, 7 + 1, i);
                linedetail(KN_CODEQ - KT_CODE8, 8 + 1, i);
                linedetail(KN_CODEF - KT_CODEF, 9 + 1, i);
                linedetail(KN_CODEK - KT_CODEK, 10 + 1, i);

                sum_KN_CODE4 += KN_CODE4; sum_KN_CODE5 += KN_CODE5;
                sum_KN_CODE6 += KN_CODE6; sum_KN_CODE8 += KN_CODE8;
                sum_KN_CODEM += KN_CODEM; sum_KN_CODEN += KN_CODEN;
                sum_KN_CODEQ += KN_CODEQ; sum_KN_CODEF += KN_CODEF;
                sum_KN_CODEK += KN_CODEK; sum_KT_CODE4 += KT_CODE4;
                sum_KT_CODE5 += KT_CODE5; sum_KT_CODE6 += KT_CODE6;
                sum_KT_CODE8 += KT_CODE8; sum_KT_CODEM += KT_CODEM;
                sum_KT_CODEN += KT_CODEN; sum_KT_CODEQ += KT_CODEQ;
                sum_KT_CODEF += KT_CODEF; sum_KT_CODEK += KT_CODEK;
                try
                {
                    string mayds = detail.Rows[i].Cells["KY_MAYDS"].Value + "";
                    detail.Rows[i].Cells["maynv"].Value = mayds + "-" + DAL.QLDHN.C_QuanLyDongHoNuoc.getNhanVienDS(int.Parse(mayds));
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }

            int index = detail.Rows.Count - 1;
            detail.Rows[index].Cells["M_KN_CODE4"].Value = String.Format("{0:0,0}", sum_KN_CODE4);
            detail.Rows[index].Cells["M_KN_CODE5"].Value = String.Format("{0:0,0}", sum_KN_CODE5);
            detail.Rows[index].Cells["M_KN_CODE6"].Value = String.Format("{0:0,0}", sum_KN_CODE6);
            detail.Rows[index].Cells["M_KN_CODE8"].Value = String.Format("{0:0,0}", sum_KN_CODE8);
            detail.Rows[index].Cells["M_KN_CODEM"].Value = String.Format("{0:0,0}", sum_KN_CODEM);
            detail.Rows[index].Cells["M_KN_CODEN"].Value = String.Format("{0:0,0}", sum_KN_CODEN);
            detail.Rows[index].Cells["M_KN_CODEQ"].Value = String.Format("{0:0,0}", sum_KN_CODEQ);
            detail.Rows[index].Cells["M_KN_CODEF"].Value = String.Format("{0:0,0}", sum_KN_CODEF);
            detail.Rows[index].Cells["M_KN_CODEK"].Value = String.Format("{0:0,0}", sum_KN_CODEK);

            detail.Rows[index].Cells["M_KT_CODE4"].Value = String.Format("{0:0,0}", sum_KT_CODE4);
            detail.Rows[index].Cells["M_KT_CODE5"].Value = String.Format("{0:0,0}", sum_KT_CODE5);
            detail.Rows[index].Cells["M_KT_CODE6"].Value = String.Format("{0:0,0}", sum_KT_CODE6);
            detail.Rows[index].Cells["M_KT_CODE8"].Value = String.Format("{0:0,0}", sum_KT_CODE8);
            detail.Rows[index].Cells["M_KT_CODEM"].Value = String.Format("{0:0,0}", sum_KT_CODEM);
            detail.Rows[index].Cells["M_KT_CODEN"].Value = String.Format("{0:0,0}", sum_KT_CODEN);
            detail.Rows[index].Cells["M_KT_CODEQ"].Value = String.Format("{0:0,0}", sum_KT_CODEQ);
            detail.Rows[index].Cells["M_KT_CODEF"].Value = String.Format("{0:0,0}", sum_KT_CODEF);

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
            // format();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //formatdetail();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int ky = int.Parse(cbKyDS_dot.Items[cbKyDS_dot.SelectedIndex].ToString());
                int nam = int.Parse(txtNam_dot.Text.Trim());
                int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                // ky hien tai
                DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DOT(nam.ToString(), ky, dot, checkHD0.Checked);
                DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL_DOT(nam.ToString(), ky, dot);
                // ky truoc
                if (ky == 1)
                {
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT((nam - 1) + "", 12, dot, checkHD0.Checked);
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT((nam - 1) + "", 12, dot);
                }
                else
                {
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT(nam.ToString(), ky - 1, dot, checkHD0.Checked);
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT(nam.ToString(), ky - 1, dot);
                }

                // CAP NHAT SO LIEU 
                //     DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();
                // so lieu
                dotToDs.DataSource = DAL.QLDHN.C_BaoCaoCODE.get_BAOCAO_CODE();
                format_dot_TO();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        void format_dot_TO()
        {
            double sum_KN_CODE4 = 0; double sum_KN_CODE5 = 0;
            double sum_KN_CODE6 = 0; double sum_KN_CODE8 = 0;
            double sum_KN_CODEM = 0; double sum_KN_CODEN = 0;
            double sum_KN_CODEQ = 0; double sum_KN_CODEF = 0;
            double sum_KN_CODEK = 0; double sum_KT_CODE4 = 0;
            double sum_KT_CODE5 = 0; double sum_KT_CODE6 = 0;
            double sum_KT_CODE8 = 0; double sum_KT_CODEM = 0;
            double sum_KT_CODEN = 0; double sum_KT_CODEQ = 0;
            double sum_KT_CODEF = 0; double sum_KT_CODEK = 0;
            for (int i = 0; i < dotToDs.Rows.Count - 1; i++)
            {
                double KN_CODE4 = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODE4"].Value + "");
                double KN_CODE5 = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODE5"].Value + "");
                double KN_CODE6 = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODE6"].Value + "");
                double KN_CODE8 = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODE8"].Value + "");
                double KN_CODEM = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODEM"].Value + "");
                double KN_CODEN = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODEN"].Value + "");
                double KN_CODEQ = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODEQ"].Value + "");
                double KN_CODEF = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODEF"].Value + "");
                double KN_CODEK = double.Parse(dotToDs.Rows[i].Cells["DOT_KN_CODEK"].Value + "");
                double KT_CODE4 = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODE4"].Value + "");
                double KT_CODE5 = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODE5"].Value + "");
                double KT_CODE6 = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODE6"].Value + "");
                double KT_CODE8 = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODE8"].Value + "");
                double KT_CODEM = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODEM"].Value + "");
                double KT_CODEN = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODEN"].Value + "");
                double KT_CODEQ = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODEQ"].Value + "");
                double KT_CODEF = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODEF"].Value + "");
                double KT_CODEK = double.Parse(dotToDs.Rows[i].Cells["DOT_KT_CODEK"].Value + "");
                line_dot_to(KN_CODE4 - KT_CODE4, 2 , i);
                line_dot_to(KN_CODE5 - KT_CODEM, 3 , i);
                line_dot_to(KN_CODE6 - KT_CODE5, 4 , i);
                line_dot_to(KN_CODE8 - KT_CODEN, 5 , i);
                line_dot_to(KN_CODEM - KT_CODE6, 6 , i);
                line_dot_to(KN_CODEN - KT_CODEQ, 7 , i);
                line_dot_to(KN_CODEQ - KT_CODE8, 8 , i);
                line_dot_to(KN_CODEF - KT_CODEF, 9 , i);
                line_dot_to(KN_CODEK - KT_CODEK, 10 , i);

                sum_KN_CODE4 += KN_CODE4; sum_KN_CODE5 += KN_CODE5;
                sum_KN_CODE6 += KN_CODE6; sum_KN_CODE8 += KN_CODE8;
                sum_KN_CODEM += KN_CODEM; sum_KN_CODEN += KN_CODEN;
                sum_KN_CODEQ += KN_CODEQ; sum_KN_CODEF += KN_CODEF;
                sum_KN_CODEK += KN_CODEK; sum_KT_CODE4 += KT_CODE4;
                sum_KT_CODE5 += KT_CODE5; sum_KT_CODE6 += KT_CODE6;
                sum_KT_CODE8 += KT_CODE8; sum_KT_CODEM += KT_CODEM;
                sum_KT_CODEN += KT_CODEN; sum_KT_CODEQ += KT_CODEQ;
                sum_KT_CODEF += KT_CODEF; sum_KT_CODEK += KT_CODEK;
            }

            int index = dotToDs.Rows.Count - 1;
            dotToDs.Rows[index].Cells["DOT_KN_CODE4"].Value = String.Format("{0:0,0}", sum_KN_CODE4);
            dotToDs.Rows[index].Cells["DOT_KN_CODE5"].Value = String.Format("{0:0,0}", sum_KN_CODE5);
            dotToDs.Rows[index].Cells["DOT_KN_CODE6"].Value = String.Format("{0:0,0}", sum_KN_CODE6);
            dotToDs.Rows[index].Cells["DOT_KN_CODE8"].Value = String.Format("{0:0,0}", sum_KN_CODE8);
            dotToDs.Rows[index].Cells["DOT_KN_CODEM"].Value = String.Format("{0:0,0}", sum_KN_CODEM);
            dotToDs.Rows[index].Cells["DOT_KN_CODEN"].Value = String.Format("{0:0,0}", sum_KN_CODEN);
            dotToDs.Rows[index].Cells["DOT_KN_CODEQ"].Value = String.Format("{0:0,0}", sum_KN_CODEQ);
            dotToDs.Rows[index].Cells["DOT_KN_CODEF"].Value = String.Format("{0:0,0}", sum_KN_CODEF);
            dotToDs.Rows[index].Cells["DOT_KN_CODEK"].Value = String.Format("{0:0,0}", sum_KN_CODEK);

            dotToDs.Rows[index].Cells["DOT_KT_CODE4"].Value = String.Format("{0:0,0}", sum_KT_CODE4);
            dotToDs.Rows[index].Cells["DOT_KT_CODE5"].Value = String.Format("{0:0,0}", sum_KT_CODE5);
            dotToDs.Rows[index].Cells["DOT_KT_CODE6"].Value = String.Format("{0:0,0}", sum_KT_CODE6);
            dotToDs.Rows[index].Cells["DOT_KT_CODE8"].Value = String.Format("{0:0,0}", sum_KT_CODE8);
            dotToDs.Rows[index].Cells["DOT_KT_CODEM"].Value = String.Format("{0:0,0}", sum_KT_CODEM);
            dotToDs.Rows[index].Cells["DOT_KT_CODEN"].Value = String.Format("{0:0,0}", sum_KT_CODEN);
            dotToDs.Rows[index].Cells["DOT_KT_CODEQ"].Value = String.Format("{0:0,0}", sum_KT_CODEQ);
            dotToDs.Rows[index].Cells["DOT_KT_CODEF"].Value = String.Format("{0:0,0}", sum_KT_CODEF);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(dotToDs.Font, FontStyle.Bold);
            dotToDs.Rows[index].DefaultCellStyle = style;
            dotToDs.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        }

        public void line_dot_to(double result, int i, int j)
        {
            if (result > 0)
            {
                dotToDs[i, j].Style.BackColor = Color.Lime;
            }
            else if (result < 0)
            {
                dotToDs[i, j].Style.BackColor = Color.Red;
            }
            else if (result == 0)
            {
                dotToDs[i, j].Style.BackColor = Color.Yellow;
            }
        }

        private void detail_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dotMayTods_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dotToDs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dotToDs.CurrentCell.OwningColumn.Name == "gg_TENTO")
            {
                tods = dotToDs.Rows[e.RowIndex].Cells["GG_TODS"].Value + "";
                try
                {
                    int ky = int.Parse(cbKyDS_dot.Items[cbKyDS_dot.SelectedIndex].ToString());
                    int nam = int.Parse(txtNam_dot.Text.Trim());
                    int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());

                                      // ky hien tai
                    DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_MAY_DOT(nam.ToString(), ky, dot,checkHD0.Checked);
                    // ky truoc
                    if (ky == 1)
                    {
                        DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_MAY_DOT((nam - 1) + "", 12, dot, checkHD0.Checked);
                    }
                    else
                    {
                        DAL.QLDHN.C_BaoCaoCODE.CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_MAY_DOT(nam.ToString(), ky - 1, dot, checkHD0.Checked);
                    }

                    tabControl3.Visible = true;
                    dotMayTods.DataSource = DAL.QLDHN.C_BaoCaoCODE.get_BAOCAO_CODE_MAY(int.Parse(tods));
                    dot_mayformatdetail();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }

        void dot_mayformatdetail()
        {
            double sum_KN_CODE4 = 0; double sum_KN_CODE5 = 0;
            double sum_KN_CODE6 = 0; double sum_KN_CODE8 = 0;
            double sum_KN_CODEM = 0; double sum_KN_CODEN = 0;
            double sum_KN_CODEQ = 0; double sum_KN_CODEF = 0;
            double sum_KN_CODEK = 0; double sum_KT_CODE4 = 0;
            double sum_KT_CODE5 = 0; double sum_KT_CODE6 = 0;
            double sum_KT_CODE8 = 0; double sum_KT_CODEM = 0;
            double sum_KT_CODEN = 0; double sum_KT_CODEQ = 0;
            double sum_KT_CODEF = 0; double sum_KT_CODEK = 0;
            for (int i = 0; i < dotMayTods.Rows.Count - 1; i++)
            {
                double KN_CODE4 = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODE4"].Value + "");
                double KN_CODE5 = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODE5"].Value + "");
                double KN_CODE6 = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODE6"].Value + "");
                double KN_CODE8 = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODE8"].Value + "");
                double KN_CODEM = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODEM"].Value + "");
                double KN_CODEN = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODEN"].Value + "");
                double KN_CODEQ = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODEQ"].Value + "");
                double KN_CODEF = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODEF"].Value + "");
                double KN_CODEK = double.Parse(dotMayTods.Rows[i].Cells["DM_KN_CODEK"].Value + "");
                double KT_CODE4 = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODE4"].Value + "");
                double KT_CODE5 = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODE5"].Value + "");
                double KT_CODE6 = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODE6"].Value + "");
                double KT_CODE8 = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODE8"].Value + "");
                double KT_CODEM = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODEM"].Value + "");
                double KT_CODEN = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODEN"].Value + "");
                double KT_CODEQ = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODEQ"].Value + "");
                double KT_CODEF = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODEF"].Value + "");
                double KT_CODEK = double.Parse(dotMayTods.Rows[i].Cells["DM_KT_CODEK"].Value + "");
                linedetail_dotMayTods(KN_CODE4 - KT_CODE4, 2 + 1, i);
                linedetail_dotMayTods(KN_CODE5 - KT_CODEM, 3 + 1, i);
                linedetail_dotMayTods(KN_CODE6 - KT_CODE5, 4 + 1, i);
                linedetail_dotMayTods(KN_CODE8 - KT_CODEN, 5 + 1, i);
                linedetail_dotMayTods(KN_CODEM - KT_CODE6, 6 + 1, i);
                linedetail_dotMayTods(KN_CODEN - KT_CODEQ, 7 + 1, i);
                linedetail_dotMayTods(KN_CODEQ - KT_CODE8, 8 + 1, i);
                linedetail_dotMayTods(KN_CODEF - KT_CODEF, 9 + 1, i);
                linedetail_dotMayTods(KN_CODEK - KT_CODEK, 10 + 1, i);

                sum_KN_CODE4 += KN_CODE4; sum_KN_CODE5 += KN_CODE5;
                sum_KN_CODE6 += KN_CODE6; sum_KN_CODE8 += KN_CODE8;
                sum_KN_CODEM += KN_CODEM; sum_KN_CODEN += KN_CODEN;
                sum_KN_CODEQ += KN_CODEQ; sum_KN_CODEF += KN_CODEF;
                sum_KN_CODEK += KN_CODEK; sum_KT_CODE4 += KT_CODE4;
                sum_KT_CODE5 += KT_CODE5; sum_KT_CODE6 += KT_CODE6;
                sum_KT_CODE8 += KT_CODE8; sum_KT_CODEM += KT_CODEM;
                sum_KT_CODEN += KT_CODEN; sum_KT_CODEQ += KT_CODEQ;
                sum_KT_CODEF += KT_CODEF; sum_KT_CODEK += KT_CODEK;

                try
                {
                    string mayds = dotMayTods.Rows[i].Cells["DOT_MAYDS"].Value + "";
                    dotMayTods.Rows[i].Cells["dot_NHANVIEN"].Value = mayds + "-" + DAL.QLDHN.C_QuanLyDongHoNuoc.getNhanVienDS(int.Parse(mayds));
                }
                catch (Exception)
                {

                }
            }

            int index = dotMayTods.Rows.Count - 1;
            dotMayTods.Rows[index].Cells["DM_KN_CODE4"].Value = String.Format("{0:0,0}", sum_KN_CODE4);
            dotMayTods.Rows[index].Cells["DM_KN_CODE5"].Value = String.Format("{0:0,0}", sum_KN_CODE5);
            dotMayTods.Rows[index].Cells["DM_KN_CODE6"].Value = String.Format("{0:0,0}", sum_KN_CODE6);
            dotMayTods.Rows[index].Cells["DM_KN_CODE8"].Value = String.Format("{0:0,0}", sum_KN_CODE8);
            dotMayTods.Rows[index].Cells["DM_KN_CODEM"].Value = String.Format("{0:0,0}", sum_KN_CODEM);
            dotMayTods.Rows[index].Cells["DM_KN_CODEN"].Value = String.Format("{0:0,0}", sum_KN_CODEN);
            dotMayTods.Rows[index].Cells["DM_KN_CODEQ"].Value = String.Format("{0:0,0}", sum_KN_CODEQ);
            dotMayTods.Rows[index].Cells["DM_KN_CODEF"].Value = String.Format("{0:0,0}", sum_KN_CODEF);
            dotMayTods.Rows[index].Cells["DM_KN_CODEK"].Value = String.Format("{0:0,0}", sum_KN_CODEK);
            dotMayTods.Rows[index].Cells["DM_KT_CODE4"].Value = String.Format("{0:0,0}", sum_KT_CODE4);
            dotMayTods.Rows[index].Cells["DM_KT_CODE5"].Value = String.Format("{0:0,0}", sum_KT_CODE5);
            dotMayTods.Rows[index].Cells["DM_KT_CODE6"].Value = String.Format("{0:0,0}", sum_KT_CODE6);
            dotMayTods.Rows[index].Cells["DM_KT_CODE8"].Value = String.Format("{0:0,0}", sum_KT_CODE8);
            dotMayTods.Rows[index].Cells["DM_KT_CODEM"].Value = String.Format("{0:0,0}", sum_KT_CODEM);
            dotMayTods.Rows[index].Cells["DM_KT_CODEN"].Value = String.Format("{0:0,0}", sum_KT_CODEN);
            dotMayTods.Rows[index].Cells["DM_KT_CODEQ"].Value = String.Format("{0:0,0}", sum_KT_CODEQ);
            dotMayTods.Rows[index].Cells["DM_KT_CODEF"].Value = String.Format("{0:0,0}", sum_KT_CODEF);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(dotMayTods.Font, FontStyle.Bold);
            dotMayTods.Rows[index].DefaultCellStyle = style;
            dotMayTods.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        }

        public void linedetail_dotMayTods(double result, int i, int j)
        {
            if (result > 0)
            {
                dotMayTods[i, j].Style.BackColor = Color.Lime;
            }
            else if (result < 0)
            {
                dotMayTods[i, j].Style.BackColor = Color.Red;
            }
            else if (result == 0)
            {
                dotMayTods[i, j].Style.BackColor = Color.Yellow;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_CodeKy();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_CODE ", "W_BAOCAO_CODE", "SELECT * FROM W_BAOCAO_CODE_DETAIL ", "W_BAOCAO_CODE_DETAIL"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ MÃ CODE KỲ " + cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam_dot.Text.Trim());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_tab_CodeKy();
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_CODE ", "W_BAOCAO_CODE", "SELECT * FROM W_BAOCAO_CODE_DETAIL ", "W_BAOCAO_CODE_DETAIL"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ MÃ CODE ĐỢT " + cbDotDS.Items[cbDotDS.SelectedIndex].ToString() + " KỲ " + cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam_dot.Text.Trim());
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // KY MAY
            ReportDocument rp = new rpt_tab_CodeKy_may();

            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_CODE_MAY WHERE TODS=" + tods + " ORDER BY MAYDS ASC ", "W_BAOCAO_CODE_MAY"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ MÃ CODE TỪNG MÀY ĐỌC SỐ KỲ " + cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam_dot.Text.Trim() + " TỔ " + tento);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
        string config = ConfigurationManager.AppSettings["code"].ToString();
        private void btDSCode_Click(object sender, EventArgs e)
        {

            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            ReportDocument rp = new rpt_DanhSachCode();
            string sql = "SELECT DANHBO,LOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,(QUAN+PHUONG) AS MAQP,ds.CODE, ds.CSCU, ds.CSMOI ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND ds.KY=" + ky + " AND ds.CODE IN (" + config + ") ";
            sql += " ORDER BY DANHBO ASC";
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report(sql, "DANHSACHCODE"));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam_dot.Text.Trim());
            int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
            ReportDocument rp = new rpt_DanhSachCode();
            string sql = "SELECT DANHBO,LOTRINH,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,(QUAN+PHUONG) AS MAQP,ds.CODE, ds.CSCU, ds.CSMOI ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND ds.KY=" + ky + " AND ds.DOT =" + dot + " AND ds.CODE IN (" + config + ") ";
            sql += " ORDER BY DANHBO ASC";
            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report(sql, "DANHSACHCODE"));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //ReportDocument rp = new rpt_tab_CodeKy();
            //rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_CODE ", "W_BAOCAO_CODE", "SELECT * FROM W_BAOCAO_CODE_DETAIL ", "W_BAOCAO_CODE_DETAIL"));
            //rp.SetParameterValue("tenbk", "THỐNG KÊ MÃ CODE ĐỢT " + cbDotDS.Items[cbDotDS.SelectedIndex].ToString() + " KỲ " + cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam_dot.Text.Trim());
            //frm_Reports frm = new frm_Reports(rp);
            //frm.ShowDialog();

            ReportDocument rp = new rpt_tab_CodeKy_may();

            rp.SetDataSource(DAL.QLDHN.C_tab_BaoCao.tb_Report("SELECT * FROM W_BAOCAO_CODE_MAY WHERE TODS=" + tods + " ORDER BY MAYDS ASC ", "W_BAOCAO_CODE_MAY"));
            rp.SetParameterValue("tenbk", "THỐNG KÊ MÃ CODE TỪNG MÀY ĐỌC SỐ KỲ " + cbKyDS_dot.Items[cbKyDS.SelectedIndex].ToString() + "/" + txtNam_dot.Text.Trim() + " TỔ " + tento);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();

        }
    }
}