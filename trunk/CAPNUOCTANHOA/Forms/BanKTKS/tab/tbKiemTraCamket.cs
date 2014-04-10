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
    public partial class tbKiemTraCamket : UserControl
    {
        public tbKiemTraCamket()
        {
            InitializeComponent();
        }

        string getKyDS0(string sodanhbo,string month)
        {
            string result = "";
            string sql = "SELECT KY FROM [DocSo_PHT].[dbo].[DS" + DateTime.Now.Year + "] WHERE KY>='" + month + "' AND TIEUTHU=0 AND DANHBA='" + sodanhbo + "' ORDER BY KY ASC";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                result += tb.Rows[i]["KY"] + "-";
            }
            return result;

        }
       

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT DHN_DANHBO,LOTRINH,HOTEN,SONHA, TENDUONG,CODE,CHISOKYTRUOC,ISNULL(DHN_CAMKET,KTKS_CAMKET) as 'CK'  ";
            sql += " FROM DK_GIAMHOADON T1, TB_DULIEUKHACHHANG  T2";
            sql += " WHERE (DHN_CAMKET<>'' OR DHN_CAMKET IS NOT NULL) AND CONVERT(DATETIME,ISNULL(DHN_NGAYGHINHAN,KTKS_NGAYTIEPXUC)) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
            sql += " AND T1.DHN_DANHBO= T2.DANHBO";
            sql += " GROUP BY DHN_DANHBO,LOTRINH,HOTEN,SONHA, TENDUONG,CODE,CHISOKYTRUOC,ISNULL(DHN_CAMKET,KTKS_CAMKET)";
            sql += " ORDER BY LOTRINH ASC  ";
            DataTable tb = DAL.LinQConnection.getDataTable(sql);
            tb.Columns.Add("HD0", typeof(String));
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string rs=getKyDS0(tb.Rows[i]["DHN_DANHBO"] + "", tb.Rows[i]["CK"] + "");
                if (rs.Equals(""))
                    tb.Rows[i].Delete();
                else
                    tb.Rows[i]["HD0"] = rs;
            }
            tb.AcceptChanges();
            ReportDocument rp = new rpt_hd0camket();            
            rp.SetDataSource(tb);
            crystalReportViewer1.ReportSource = rp;
          
        }
    }
}
