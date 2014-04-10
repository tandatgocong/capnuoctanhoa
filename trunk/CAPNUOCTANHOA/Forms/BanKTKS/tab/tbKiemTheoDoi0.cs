using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CAPNUOCTANHOA.Forms.BanKTKS.tab
{
    public partial class tbKiemTheoDoi0 : UserControl
    {
        public tbKiemTheoDoi0()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
        }

        string getKyDS0(string sodanhbo)
        {
            string result = "";
            string sql = "SELECT KY FROM [DocSo_PHT].[dbo].[DS" + DateTime.Now.Year + "] WHERE TIEUTHU=0 AND DANHBA='" + sodanhbo + "' ORDER BY KY ASC";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                result += tb.Rows[i]["KY"] + "-";
            }
            return result;

        }


        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());

            string sql = " SELECT kh.LOTRINH,kh.DANHBO,kh.HOTEN,(kh.SONHA + ' ' + kh.TENDUONG) as dc,YEAR(kh.NGAYTHAY) as NAMLD, ds.CODE,ds.CSMOI ";
            sql += " FROM [DocSo_PHT].[dbo].[DS" + nam + "] ds, TB_DULIEUKHACHHANG kh  ";
            sql += " WHERE  kh.DANHBO=ds.DANHBA AND ds.TIEUTHU=0 AND ds.KY=" + ky;
            sql += " AND kh.DANHBO IN (SELECT DANHBA FROM [DocSo_PHT].[dbo].[DS" + nam + "] ds WHERE kh.DANHBO=ds.DANHBA AND ds.KY=" + (ky - 1) + ")   ";
            sql += " AND kh.DANHBO NOT IN (SELECT DHN_DANHBO FROM DK_GIAMHOADON) ORDER BY kh.LOTRINH ASC";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            ReportDocument rp = new rpt_theodoihd0();
            rp.SetDataSource(tb);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}