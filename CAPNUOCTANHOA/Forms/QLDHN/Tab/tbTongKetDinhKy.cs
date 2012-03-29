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
    public partial class tbTongKetDinhKy : UserControl
    {
        public tbTongKetDinhKy()
        {
            InitializeComponent();
            LoadDataToGird();
            cbCoDH.SelectedIndex = 0;
            dateTime.Value = DateTime.Now;
            if ("TP".Equals(DAL.SYS.C_USERS._toDocSo)) {
                this.checkTanPhu.Checked = true;
            }else if ("TB01".Equals(DAL.SYS.C_USERS._toDocSo)){
                this.checkTanBinh1.Checked = true;
            }
            else if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                this.checkTanBinh2.Checked = true;
            }

        }

        private void LoadDataToGird()
        {
           
            DataTable table = DAL.LinQConnection.getDataTable("SELECT HIEUDH,TENDONGHO FROM TB_HIEUDONGHO");
            cbHieuDongHo.DataSource = table;
            cbHieuDongHo.DisplayMember = "TENDONGHO";
            cbHieuDongHo.ValueMember = "HIEUDH";
        }
        public void Search() {
            DateTime date = dateTime.Value;
            string codh = "<=25";
            if (cbCoDH.SelectedIndex == 1)
            {
                codh = ">25";
                date = date.AddYears(-4);
            }
            else
            {
                codh = "<=25";
                date = date.AddYears(-5);
            }

            string gioihan = "";
            if (checkTanBinh1.Checked) {
                gioihan = DAL.SYS.C_USERS.findByToDS("TB01")!=null? DAL.SYS.C_USERS.findByToDS("TB01").GIOIHAN: "" ;
            }
            else if (checkTanBinh2.Checked) {
                gioihan = DAL.SYS.C_USERS.findByToDS("TB02") != null ? DAL.SYS.C_USERS.findByToDS("TB02").GIOIHAN : "";
            }
            else if (checkTanPhu.Checked)
            {
                gioihan = DAL.SYS.C_USERS.findByToDS("TP") != null ? DAL.SYS.C_USERS.findByToDS("TP").GIOIHAN : "";
            }
            else {
                gioihan = "";
            }

            string sql = "SELECT HIEUDH,CODH,COUNT(CODH) AS 'SOLUONG', YEAR(NGAYTHAY) AS 'NAM' FROM  TB_DULIEUKHACHHANG  WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + gioihan + " AND CODH" + codh + "   ";
            string tksql = "";
            if (this.ckNgayThay.Checked && this.checHieu.Checked)
            {

                sql += " AND NGAYTHAY <= '" + date.ToShortDateString() + "' AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ";


                tksql = "SELECT CODH,COUNT(CODH) AS 'SOLUONG' FROM  TB_DULIEUKHACHHANG  WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL)" + gioihan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "'  ";
                tksql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') GROUP BY CODH  ORDER BY SOLUONG DESC ";
              
            }
            else if (this.ckNgayThay.Checked)
            {
                sql += " AND NGAYTHAY <= '" + date.ToShortDateString() + "' ";
                tksql = "SELECT CODH,COUNT(CODH) AS 'SOLUONG' FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + gioihan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "' GROUP BY CODH ORDER BY SOLUONG DESC";
            }
            else if (this.checHieu.Checked)
            {
                sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ";
                tksql = "SELECT CODH,COUNT(CODH) AS 'SOLUONG' FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + gioihan + " AND CODH" + codh + " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') GROUP BY CODH  ORDER BY SOLUONG DESC";
            }
            sql += " GROUP BY HIEUDH,CODH,YEAR(NGAYTHAY) ORDER BY YEAR(NGAYTHAY),SOLUONG DESC ";

            DataTable table = DAL.LinQConnection.getDataTable(sql);
            dataGrid.DataSource = table;

            table = DAL.LinQConnection.getDataTable(tksql);
            dataGridView1.DataSource = table;

            Utilities.DataGridV.formatRows(dataGrid);
            Utilities.DataGridV.formatRows(dataGridView1);
            setSTT();
        }
        public void setSTT()
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                dataGrid.Rows[i].Cells["STT"].Value = i + 1;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["GG_STT"].Value = i + 1;
            }

            
        }
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            Search();
            tongket();         

        }

        public void tongket() {
            try
            {
                int SODHN = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    SODHN += int.Parse(dataGrid.Rows[i].Cells["G_SOLUONG"].Value != null ? dataGrid.Rows[i].Cells["G_SOLUONG"].Value + "" : "0");
                }

                int index = dataGrid.Rows.Count - 1;
                dataGrid.Rows[index].Cells["G_SOLUONG"].Value = String.Format("{0:0,0}", SODHN); ;

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font(dataGrid.Font, FontStyle.Bold);
                dataGrid.Rows[index].DefaultCellStyle = style;
                dataGrid.Rows[index].DefaultCellStyle.BackColor = Color.YellowGreen;


                SODHN = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SODHN += int.Parse(dataGridView1.Rows[i].Cells["GG_SOLUONG"].Value != null ? dataGridView1.Rows[i].Cells["GG_SOLUONG"].Value + "" : "0");
                }

                index = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[index].Cells["GG_SOLUONG"].Value = String.Format("{0:0,0}", SODHN);

                style = new DataGridViewCellStyle();
                style.Font = new System.Drawing.Font(dataGrid.Font, FontStyle.Bold);
                dataGridView1.Rows[index].DefaultCellStyle = style;

                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.YellowGreen;
            }
            catch (Exception)
            {
                
            }
            
        }
        private void dataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGrid);
            Utilities.DataGridV.formatRows(dataGridView1);
            setSTT();
            tongket();   
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGrid);
            Utilities.DataGridV.formatRows(dataGridView1);
            setSTT();
            tongket();  
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            Search();
            tongket();   
        }

        private void checkTanBinh1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
            tongket();   
        }

        private void checkTanBinh2_CheckedChanged(object sender, EventArgs e)
        {
            Search();
            tongket();   
        }

        private void checkTanPhu_CheckedChanged(object sender, EventArgs e)
        {
            Search();
            tongket();   
        }

    }
}
