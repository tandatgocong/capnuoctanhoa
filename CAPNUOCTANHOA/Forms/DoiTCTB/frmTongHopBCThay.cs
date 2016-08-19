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
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmTongHopBCThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmTongHopBCThay).Name);
        int flag = 0;
        public frmTongHopBCThay()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }
        string sql_VATTU = "";
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            flag = 1;
            string sqlIN = "";
            sqlIN += "'TB01-" + txtTB01.Text.Replace(",", "','TB01-") + "',";
            sqlIN += "'TB02-" + txtTB02.Text.Replace(",", "','TB02-") + "',";
            sqlIN += "'TP01-" + txtTP01.Text.Replace(",", "','TP01-") + "',";
            sqlIN += "'TP02-" + txtTP02.Text.Replace(",", "','TP02-") + "',";
            sqlIN += "'" + txtThayThu.Text.Replace(",", "','") + "'";

            string sql = " SELECT  vt.MAVT,dg.TENVT,dg.DGVATLIEU,dg.DGNHANCONG,";
            sql += " CASE WHEN vt.MAVT ='CVIEN' THEN 'Kg'  WHEN vt.MAVT ='DDONG' THEN 'Kg' ELSE vt.DVT END AS DVT, ";
            sql += " CASE WHEN vt.MAVT ='CVIEN' THEN ROUND((SUM(SOLUONG)/200),2)  WHEN vt.MAVT ='DDONG' THEN ROUND((SUM(SOLUONG)/340),2) ELSE ROUND(SUM(SOLUONG),0) END AS SOLUONG, ";
            sql += " CASE WHEN vt.MAVT ='CVIEN' THEN ROUND((SUM(SOLUONG)/200)* dg.DGVATLIEU,2)  WHEN vt.MAVT ='DDONG' THEN ROUND((SUM(SOLUONG)/340)*dg.DGVATLIEU,2) ELSE  ROUND(SUM(SOLUONG)*dg.DGVATLIEU,2) END AS VATLIEU, ";
            sql += " SUM(SOLUONG)*dg.DGNHANCONG AS NHANCONG ";
            sql += " FROM TB_VATUTHAY_DHN vt , TB_VATUTHAY_DONGIA dg ";
            sql += " WHERE vt.MAVT=dg.MAVT AND vt.MAVT <> 'NHANCONG' and DOTTHAY IN (" + sqlIN + ")";
            sql += " GROUP BY  vt.MAVT,dg.TENVT,vt.DVT,dg.DGVATLIEU,dg.DGNHANCONG ";
            sql_VATTU = sql;
            dataVatTuThay.DataSource = DAL.LinQConnection.getDataTable(sql);
            Utilities.DataGridV.setSTT(dataVatTuThay, "STT");

            //MessageBox.Show(this, sqlIN);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_ht = " UPDATE TB_THAYDHN SET  TENKH =KH.HOTEN, DIACHI=KH.SONHA + ' ' + KH.TENDUONG,T_LOTRINH=KH.LOTRINH FROM TB_DULIEUKHACHHANG KH ";
            sql_ht += " WHERE KH.DANHBO= TB_THAYDHN.DHN_DANHBO AND TENKH IS NULL ";
            DAL.LinQConnection.ExecuteCommand_(sql_ht);

            if (flag == 1)
            {
                string sqlIN = "";
                sqlIN += "'TB01-" + txtTB01.Text.Replace(",", "','TB01-") + "',";
                sqlIN += "'TB02-" + txtTB02.Text.Replace(",", "','TB02-") + "',";
                sqlIN += "'TP01-" + txtTP01.Text.Replace(",", "','TP01-") + "',";
                sqlIN += "'TP02-" + txtTP02.Text.Replace(",", "','TP02-") + "',";
                sqlIN += "'" + txtThayThu.Text.Replace(",", "','") + "'";

                string sql = "  SELECT (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS DOTBG , thay.TENKH,thay.DIACHI,thay.DHN_DANHBO,(thay.HCT_HIEUDHNGAN + ' - ' + thay.HCT_CODHNGAN+' Ly') as DHN, CASE WHEN HCT_LOAIDHGAN=1 THEN N'Mới' else N'Tân trang' end as LoaiDH,";
                sql += " ROUND(dg.VATLIEU,2) AS VL,ROUND(dg.NHANCONG,2) AS NC,(ROUND(dg.VATLIEU,2) + ROUND(dg.NHANCONG,2)) AS TC,CONVERT(VARCHAR(20),thay.HCT_NGAYGAN,103) AS NGAYGAN,dg.GHICHU ";
                sql += " FROM TB_THAYDHN thay, ";
                sql += " ( ";
                sql += " 	SELECT t.ID_BAOTHAY,SUM(VATLIEU) AS VATLIEU,SUM(NHANCONG)AS NHANCONG,t.GHICHU ";
                sql += " 	FROM  ";
                sql += " 	   ( SELECT vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG,vt.GHICHU,SUM(SOLUONG) AS SOLUONG, ";
                sql += " 		CASE WHEN vt.MAVT ='CVIEN' THEN (SUM(SOLUONG)/200)* dg.DGVATLIEU  WHEN vt.MAVT ='DDONG' THEN (SUM(SOLUONG)/340)*dg.DGVATLIEU ELSE  SUM(SOLUONG)*dg.DGVATLIEU END AS VATLIEU, ";
                sql += " 		SUM(SOLUONG)*dg.DGNHANCONG  AS NHANCONG ";
                sql += " 		FROM TB_VATUTHAY_DHN vt , TB_VATUTHAY_DONGIA dg ";
                sql += " 		WHERE vt.MAVT=dg.MAVT and DOTTHAY IN (" + sqlIN + ")";
                sql += " 		GROUP BY vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG,vt.GHICHU ";
                sql += " 		) AS t ";
                sql += " 	GROUP BY t.ID_BAOTHAY,t.GHICHU  ";
                sql += " ) as dg ";
                sql += " WHERE thay.ID_BAOTHAY=dg.ID_BAOTHAY ";
                sql += " ORDER BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) ASC,thay.T_LOTRINH ASC ";

                dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
                Utilities.DataGridV.setSTT(dataBangKe, "G_STT");
            }
            else if (flag == 2)
            {

                string tngay = Utilities.DateToString.NgayVN(dateTuNgay);
                string dngay = Utilities.DateToString.NgayVN(dateDenNgay);

                string sql = "  SELECT (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) AS DOTBG , thay.TENKH,thay.DIACHI,thay.DHN_DANHBO,(thay.HCT_HIEUDHNGAN + ' - ' + thay.HCT_CODHNGAN+' Ly') as DHN, CASE WHEN HCT_LOAIDHGAN=1 THEN N'Mới' else N'Tân trang' end as LoaiDH,";
                sql += " ROUND(dg.VATLIEU,2) AS VL,ROUND(dg.NHANCONG,2) AS NC,(ROUND(dg.VATLIEU,2) + ROUND(dg.NHANCONG,2)) AS TC,CONVERT(VARCHAR(20),thay.HCT_NGAYGAN,103) AS NGAYGAN,dg.GHICHU ";
                sql += " FROM TB_THAYDHN thay, ";
                sql += " ( ";
                sql += " 	SELECT t.ID_BAOTHAY,SUM(VATLIEU) AS VATLIEU,SUM(NHANCONG)AS NHANCONG,t.GHICHU ";
                sql += " 	FROM  ";
                sql += " 	   ( SELECT vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG,vt.GHICHU,SUM(SOLUONG) AS SOLUONG, ";
                sql += " 		CASE WHEN vt.MAVT ='CVIEN' THEN (SUM(SOLUONG)/200)* dg.DGVATLIEU  WHEN vt.MAVT ='DDONG' THEN (SUM(SOLUONG)/340)*dg.DGVATLIEU ELSE  SUM(SOLUONG)*dg.DGVATLIEU END AS VATLIEU, ";
                sql += " 		SUM(SOLUONG)*dg.DGNHANCONG  AS NHANCONG ";
                sql += " 		FROM TB_VATUTHAY_DHN vt , TB_VATUTHAY_DONGIA dg ";
                sql += " 		WHERE vt.MAVT=dg.MAVT ";
                sql += " 		GROUP BY vt.ID_BAOTHAY,vt.MAVT,dg.DGVATLIEU,dg.DGNHANCONG,vt.GHICHU ";
                sql += " 		) AS t ";
                sql += " 	GROUP BY t.ID_BAOTHAY,t.GHICHU  ";
                sql += " ) as dg ";
                sql += " WHERE thay.ID_BAOTHAY=dg.ID_BAOTHAY  AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tngay + "',103) AND CONVERT(DATETIME,'" + dngay + "',103) "; ;
                sql += " ORDER BY (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) ASC,thay.T_LOTRINH ASC ";

                dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
                Utilities.DataGridV.setSTT(dataBangKe, "G_STT");


            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.DoiTCTB.Export.export(dataBangKe, this.comboBox1.Text);
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Lỗi Xuất File !");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            flag = 2;
            string tngay = Utilities.DateToString.NgayVN(dateTuNgay);
            string dngay = Utilities.DateToString.NgayVN(dateDenNgay);
            string sql = "SELECT COUNT(DISTINCT (convert(varchar(20),DHN_SOBANGKE)+'-'+DHN_TODS)) AS 'TONG',COUNT(*) AS 'SOLUONGTHAY' ";
            sql += " ,COUNT(*) - (COUNT(case when HCT_NGAYGAN IS NOT NULL then 1 else null end)+COUNT(case when HCT_TRONGAI ='True' then 1 else null end)) AS 'CHUAGAN'";
            sql += " ,count(case when HCT_TRONGAI <> 1	OR HCT_TRONGAI IS NULL   then 1 else null end) AS 'HOANTAT' ";
            sql += " ,count(case when HCT_TRONGAI = 1  then 1 else null end) AS 'TRONGAI' ";
            sql += " FROM TB_THAYDHN WHERE DHN_DANHBO IS NOT NULL ";
            sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tngay + "',103) AND CONVERT(DATETIME,'" + dngay + "',103) ";

            dataTongKet.DataSource = DAL.LinQConnection.getDataTable(sql);

            string sqlTkVT = " SELECT vt.MAVT,vt.TENVT,vt.DVT,ROUND(SUM(SOLUONG),0) AS SOLUONG ";
            sqlTkVT += " FROM TB_THAYDHN th, TB_VATUTHAY_DHN vt ";
            sqlTkVT += " WHERE th.ID_BAOTHAY=vt.ID_BAOTHAY AND (HCT_TRONGAI <> 1	OR HCT_TRONGAI IS NULL)";
            sqlTkVT += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) BETWEEN CONVERT(DATETIME,'" + tngay + "',103) AND CONVERT(DATETIME,'" + dngay + "',103) ";
            sqlTkVT += " GROUP BY vt.MAVT,vt.TENVT,vt.DVT";

            dataVTNgay.DataSource = DAL.LinQConnection.getDataTable(sqlTkVT);
            Utilities.DataGridV.setSTT(dataVTNgay, "vt_STT");

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ReportDocument rp = new rpt_ThongKeVTThay();
          
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql_VATTU, db.Connection.ConnectionString);
            adapter.Fill(ds, "W_THONGKEVATTUTHAY");

           string query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            rp.SetDataSource(ds);
            rp.SetParameterValue("TB01", txtTB01.Text);
            rp.SetParameterValue("TB02", txtTB02.Text);
            rp.SetParameterValue("TP01", txtTP01.Text);
            rp.SetParameterValue("TP02", txtTP02.Text);
            rp.SetParameterValue("TT", txtThayThu.Text);


            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }
    }


}