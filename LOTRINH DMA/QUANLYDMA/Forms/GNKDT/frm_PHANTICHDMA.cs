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

using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.GNKDT;
using System.IO;
using System.Threading;
using System.Configuration;
using CAPNUOCTANHOA.Forms.GNKDT.BAOCAO;


namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_PHANTICHDMA : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_PHANTICHDMA()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        void format()
        {
            double sum_TONGDHN = 0;
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


                sum_TONGDHN += double.Parse(sanluongToDS.Rows[i].Cells["SOLUONG"].Value + "");

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
                    sanluongToDS[7, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_DHN < 0)
                {
                    sanluongToDS[7, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_DHN == 0)
                {
                    sanluongToDS[7, i].Style.BackColor = Color.Yellow;
                }
                /////
                if (TANGIAM_SANLUONG > 0)
                {
                    sanluongToDS[8, i].Style.BackColor = Color.Lime;
                }
                else if (TANGIAM_SANLUONG < 0)
                {
                    sanluongToDS[8, i].Style.BackColor = Color.Red;
                }
                else if (TANGIAM_SANLUONG == 0)
                {
                    sanluongToDS[8, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_DHN
                if (NT_TANGIAM_DHN > 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_DHN < 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_DHN == 0)
                {
                    sanluongToDS[11, i].Style.BackColor = Color.Yellow;
                }
                ////NT_TANGIAM_SANLUONG
                if (NT_TANGIAM_SANLUONG > 0)
                {
                    sanluongToDS[12, i].Style.BackColor = Color.Lime;
                }
                else if (NT_TANGIAM_SANLUONG < 0)
                {
                    sanluongToDS[12, i].Style.BackColor = Color.Red;
                }
                else if (NT_TANGIAM_SANLUONG == 0)
                {
                    sanluongToDS[12, i].Style.BackColor = Color.Yellow;
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
            sanluongToDS.Rows[index].Cells["SOLUONG"].Value = String.Format("{0:0,0}", sum_TONGDHN);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(sanluongToDS.Font, FontStyle.Bold);
            sanluongToDS.Rows[index].DefaultCellStyle = style;
            sanluongToDS.Rows[index].DefaultCellStyle.BackColor = Color.Silver;

        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {

            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            

            DAL.GNKDT.C_TONGHOP.CAPNHAT_DHN_HH();
            DAL.GNKDT.C_TONGHOP.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(nam.ToString(), ky);
            DAL.GNKDT.C_TONGHOP.CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(nam, ky);
            DAL.GNKDT.C_TONGHOP.CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC(nam, ky);
            DAL.GNKDT.C_TONGHOP.CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM();

            sanluongToDS.DataSource = DAL.GNKDT.C_TONGHOP.get_BAOCAO_SANLUONG();
           format();
           lb8x.Text = (sanluongToDS.RowCount - 1).ToString() + " DMA ( Số Liệu Hóa Đơn hiện có " + DAL.LinQConnection.ExecuteCommand("SELECT MAX(DOT)  FROM [SERVER9].[HOADON_TA].[dbo].[HOADON] kh WHERE kh.NAM=" + nam + " AND kh.KY=" + ky) + " đợt )";
           
        }
    }
}