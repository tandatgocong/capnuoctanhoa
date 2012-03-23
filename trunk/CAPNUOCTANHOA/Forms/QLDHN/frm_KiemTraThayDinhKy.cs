using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_KiemTraThayDinhKy : UserControl
    {
        public frm_KiemTraThayDinhKy()
        {
            InitializeComponent();
            LoadDataToGird();
        }

        private void LoadDataToGird()
        {
            //dataGrid.DataSource = DAL.QLDHN.C_BaoThay.getBaoThayDinhKy();
            //Utilities.DataGridV.formatRows(dataGrid);

            DataTable table = DAL.LinQConnection.getDataTable("SELECT HIEUDH,TENDONGHO FROM TB_HIEUDONGHO");
            cbHieuDongHo.DataSource = table;
            cbHieuDongHo.DisplayMember = "TENDONGHO";
            cbHieuDongHo.ValueMember = "HIEUDH";
        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            string sql="";
            if (this.ckNgayThay.Checked && this.checHieu.Checked) {

            }
            else if (this.ckNgayThay.Checked) {
                sql = "SELECT TOP(300) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH FROM  TB_DULIEUKHACHHANG WHERE NGAYTHAY < '" + dateTime.Value.ToShortDateString() + "' ";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.checHieu.Checked)
            {
                sql = "SELECT TOP(300) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH FROM  TB_DULIEUKHACHHANG WHERE HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text+ "' ";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
            }
        }
    }
}
