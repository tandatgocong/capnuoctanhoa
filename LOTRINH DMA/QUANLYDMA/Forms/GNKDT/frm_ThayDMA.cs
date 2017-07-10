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
    public partial class frm_ThayDMA : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        public frm_ThayDMA()
        {
            InitializeComponent();
            dateTuNgay.Value = DateTime.Now.Date.AddDays(-30);
        }

        private void dataBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataBangKe_Click(object sender, EventArgs e)
        {

        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            string sql = "       select ROW_NUMBER() OVER (ORDER BY kh.MADMA  DESC) [STT], kh.MADMA,COUNT(*) AS SOLUONG ";
            sql += "  from TB_THAYDHN thay, TB_DULIEUKHACHHANG kh ";
            sql += "  where thay.DHN_DANHBO=kh.DANHBO ";
            sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateTuNgay) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(dateDenNgay) + "',103) ";
            sql += "  group by kh.MADMA  ";
            dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
            lbTong.Text = (dataBangKe.DataSource as DataTable).Compute("Sum(SOLUONG)", "") + "";

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            GNKDT.Export.exportThay(dataBangKe, Utilities.DateToString.NgayVN(dateTuNgay), Utilities.DateToString.NgayVN(dateDenNgay));
        }
    }
}