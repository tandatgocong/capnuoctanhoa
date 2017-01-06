using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_Option_BT_TN : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_Option_BT_TN(DataTable listDanhBo)
        {
            InitializeComponent();
            dataGrid.DataSource = listDanhBo;           
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                string sql = " SELECT TOP(1) N' BÁO ĐỨT CHÌ BK ['+ TODS+'-' + CAST(SOBANGKE AS VARCHAR) +'] NGÀY  ' + CONVERT(VARCHAR(10),NGAYBAO,103)  +' : ' + GHICHU FROM TB_TLKDUTCHI  WHERE DANHBO='" + (dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "'   ORDER BY NGAYBAO DESC  ";
                DataTable table = DAL.LinQConnection.getDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value += ":|:" + table.Rows[0][0];

                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }

                sql = "  SELECT  TOP(1) N' PHIẾU CHUYỂN :'+ KINHGUI+' : ' + VEVIEC +' [BK '+  CAST(BANGKE AS VARCHAR) +'  NGÀY  ' + CONVERT(VARCHAR(10),NGAYLAP,103) + ' ] ' + CONGDUNG  FROM TB_PHIEUCHUYEN  WHERE DANHBO='" + (dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "'    ORDER BY NGAYLAP DESC   ";
                table = DAL.LinQConnection.getDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value += ":|:" + table.Rows[0][0];
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }

            }

            
        }
    }
}