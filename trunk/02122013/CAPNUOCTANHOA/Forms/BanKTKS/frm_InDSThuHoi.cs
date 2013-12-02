using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.BanKTKS.BC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_InDSThuHoi : Form
    {
        public frm_InDSThuHoi()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dateTu.Value > dateDen.Value)
            {
                MessageBox.Show("Nhập ngày sai\nTừ Ngày <= Đến Ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = DAL.BANKTKS.C_GiamHoaDon.getDSThuHoi(dateTu.Value.ToString("yyyy-MM-dd"), dateDen.Value.ToString("yyyy-MM-dd"));
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
                this.Close();
            }
            else
                MessageBox.Show("Không có Hộ bị thu hồi trong khoảng thời gian trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
