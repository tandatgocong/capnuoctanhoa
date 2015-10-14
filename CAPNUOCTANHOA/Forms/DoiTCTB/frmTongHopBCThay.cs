using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiTCTB.BC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmTongHopBCThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmTongHopBCThay).Name);
        public frmTongHopBCThay()
        {
            InitializeComponent();

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string sqlIN = "";
            sqlIN += "'TB01-" + txtTB01.Text.Replace(",", "','TB01-") + "',";
            sqlIN += "'TB02-" + txtTB02.Text.Replace(",", "','TB02-") + "',";
            sqlIN += "'TP01-" + txtTP01.Text.Replace(",", "','TP01-") + "',";
            sqlIN += "'TP02-" + txtTP02.Text.Replace(",", "','TP02-") + "'";
            string sql = " SELECT  vt.MAVT,dg.TENVT,vt.DVT,dg.DGVATLIEU,dg.DGNHANCONG,SUM(SOLUONG) AS SOLUONG, ";
            sql += " CASE WHEN vt.MAVT ='CVIEN' THEN (SUM(SOLUONG)/200)* dg.DGVATLIEU  WHEN vt.MAVT ='DDONG' THEN (SUM(SOLUONG)/340)*dg.DGVATLIEU ELSE  SUM(SOLUONG)*dg.DGVATLIEU END AS VATLIEU, ";
            sql += " SUM(SOLUONG)*dg.DGNHANCONG AS NHANCONG ";
            sql += " FROM TB_VATUTHAY_DHN vt , TB_VATUTHAY_DONGIA dg ";
            sql += " WHERE vt.MAVT=dg.MAVT and DOTTHAY IN (" + sqlIN + ")";
            sql += " GROUP BY  vt.MAVT,dg.TENVT,vt.DVT,dg.DGVATLIEU,dg.DGNHANCONG ";

            dataVatTuThay.DataSource = DAL.LinQConnection.getDataTable(sql);
            Utilities.DataGridV.setSTT(dataVatTuThay, "STT");

            //MessageBox.Show(this, sqlIN);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlIN = "";
            sqlIN += "'TB01-" + txtTB01.Text.Replace(",", "','TB01-") + "',";
            sqlIN += "'TB02-" + txtTB02.Text.Replace(",", "','TB02-") + "',";
            sqlIN += "'TP01-" + txtTP01.Text.Replace(",", "','TP01-") + "',";
            sqlIN += "'TP02-" + txtTP02.Text.Replace(",", "','TP02-") + "'";

            string sql = "  SELECT thay.TENKH,thay.DIACHI,thay.DHN_DANHBO,(thay.HCT_HIEUDHNGAN + ' - ' + thay.HCT_CODHNGAN+' Ly') as DHN, ";
            sql += " ROUND(dg.VATLIEU,2) AS VL,ROUND(dg.NHANCONG,2) AS NC,(ROUND(dg.VATLIEU,2) + ROUND(dg.NHANCONG,2)) AS TC,CONVERT(VARCHAR(20),thay.HCT_NGAYGAN,103) AS NGAYGAN ";
            sql += " FROM TB_THAYDHN thay, ";
            sql += " ( ";
            sql += " 	SELECT t.ID_BAOTHAY,SUM(VATLIEU) AS VATLIEU,SUM(NHANCONG)AS NHANCONG ";
            sql += " 	FROM  ";
            sql += " 	   ( SELECT vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG,SUM(SOLUONG) AS SOLUONG, ";
            sql += " 		CASE WHEN vt.MAVT ='CVIEN' THEN (SUM(SOLUONG)/200)* dg.DGVATLIEU  WHEN vt.MAVT ='DDONG' THEN (SUM(SOLUONG)/340)*dg.DGVATLIEU ELSE  SUM(SOLUONG)*dg.DGVATLIEU END AS VATLIEU, ";
            sql += " 		SUM(SOLUONG)*dg.DGNHANCONG  AS NHANCONG ";
            sql += " 		FROM TB_VATUTHAY_DHN vt , TB_VATUTHAY_DONGIA dg ";
            sql += " 		WHERE vt.MAVT=dg.MAVT and DOTTHAY IN (" + sqlIN + ")";
            sql += " 		GROUP BY vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG ";
            sql += " 		) AS t ";
            sql += " 	GROUP BY t.ID_BAOTHAY ";
            sql += " ) as dg ";
            sql += " WHERE thay.ID_BAOTHAY=dg.ID_BAOTHAY ";
            sql += " ORDER BY thay.ID_BAOTHAY ASC ";

            dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
            Utilities.DataGridV.setSTT(dataBangKe, "G_STT");
        }
    }
}