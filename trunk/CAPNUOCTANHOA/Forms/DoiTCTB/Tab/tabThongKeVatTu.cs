using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiTCTB.BC;
using CAPNUOCTANHOA.Forms.Reports;

namespace CAPNUOCTANHOA.Forms.DoiTCTB.Tab
{
    public partial class tabThongKeVatTu : UserControl
    {
        public tabThongKeVatTu()
        {
            InitializeComponent();
        }
        public void setSTT()
        {
            for (int i = 0; i < dataVATTU.Rows.Count; i++)
            {
                dataVATTU.Rows[i].Cells["STT"].Value = i + 1;
            }
        }
        private void btXemVatTu_Click(object sender, EventArgs e)
        {
            string dotBienNhan = "'" + txtSoBangKe.Text.Replace(",", "','").Replace(" ","");
            dotBienNhan = dotBienNhan + "'";
            //MessageBox.Show(this, dotBienNhan);
            string sql = "SELECT MAVT,TENVT,DVT,SUM(SOLUONG) AS 'TONGSL' ";
            sql += "FROM TB_VATUTHAY_DHN WHERE DOTTHAY IN(" + dotBienNhan + ") ";
            sql += "GROUP BY  STT,MAVT,TENVT,DVT ";
            DataTable table = DAL.LinQConnection.getDataTable(sql);
            dataVATTU.DataSource = table;
            setSTT();
            Utilities.DataGridV.formatRows(dataVATTU);

            string sql_TroNgai = "SELECT COUNT(HCT_TRONGAI) FROM TB_THAYDHN WHERE (DHN_TODS+'-'+CONVERT(VARCHAR(50),DHN_SOBANGKE)) IN(" + dotBienNhan + ") AND HCT_TRONGAI='True'";
            string sql_TongDHN = "SELECT COUNT(*) FROM TB_THAYDHN WHERE (DHN_TODS+'-'+CONVERT(VARCHAR(50),DHN_SOBANGKE)) IN(" + dotBienNhan + ") ";
            int tongTroNgai = DAL.LinQConnection.ExecuteCommand(sql_TroNgai);
            int tongDHYeuCau = DAL.LinQConnection.ExecuteCommand(sql_TongDHN);
            lbTongDHN.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC YÊU CẦU THAY           " + tongDHYeuCau;
            lbTongTroNgai.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC TRỞ NGẠI THAY         " + tongTroNgai;
            lbTongDHNThay.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC ĐÃ THAY                       " + (tongDHYeuCau - tongTroNgai);
        }

        private void dataVATTU_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setSTT();
            Utilities.DataGridV.formatRows(dataVATTU);
        }

        private void btInBCThay_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable("THONGKEVTTHAY");
            table.Columns.Add("DOTTC", typeof(string));
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("MAVT", typeof(string));
            table.Columns.Add("TENVT", typeof(string));
            table.Columns.Add("DVT", typeof(string));
            table.Columns.Add("SOLUONG", typeof(string));
            table.Columns.Add("GHICHU", typeof(string));
            table.Columns.Add("TENDANGNHAP", typeof(string));

            for (int i = 0; i < dataVATTU.Rows.Count-1; i++)
            {
                DataRow myDataRow = table.NewRow();
                myDataRow["DOTTC"] = txtSoBangKe.Text;
                myDataRow["STT"] = dataVATTU.Rows[i].Cells["STT"].Value + "";
                myDataRow["MAVT"] = dataVATTU.Rows[i].Cells["G_MAVT"].Value + "";
                myDataRow["TENVT"] = dataVATTU.Rows[i].Cells["G_TENVT"].Value + "";
                myDataRow["DVT"] = dataVATTU.Rows[i].Cells["G_DVT"].Value + "";
                myDataRow["SOLUONG"] = dataVATTU.Rows[i].Cells["G_TONGSL"].Value + "";
                myDataRow["GHICHU"] = dataVATTU.Rows[i].Cells["G_GHICHU"].Value + "";
                myDataRow["TENDANGNHAP"] = DAL.SYS.C_USERS._fullName;
                table.Rows.Add(myDataRow);
            }
            ds.Tables.Add(table);
            ReportDocument rp = new rpt_ThongKeVTThay();
            rp.SetDataSource(ds);
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();
        }

    }
}
