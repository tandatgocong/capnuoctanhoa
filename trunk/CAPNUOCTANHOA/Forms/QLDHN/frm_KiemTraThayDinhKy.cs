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
            cbCoDH.SelectedIndex = 0;
            dateTime.Value = DateTime.Now;
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
        int currentPageIndex = 1;
        int pageSize = 20;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        public string Search()
        {

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
            string sql = "";

            string quan = DAL.SYS.C_USERS._gioihan;
            //if (DAL.SYS.C_USERS._toDocSo.Equals("TP"))
            //{
            //    quan = " = 31";
            //}
            if (this.ckNgayThay.Checked && this.checHieu.Checked)
            {
                sql = "SELECT  DANHBO,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "'  ";
                sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ORDER BY DOT,NGAYTHAY ASC ";
                //DataTable table = DAL.LinQConnection.getDataTable(sql);
                //dataGrid.DataSource = table;
                //Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.ckNgayThay.Checked)
            {
                sql = "SELECT  DANHBO,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL)  " + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "' ORDER BY DOT,NGAYTHAY ASC";
                //DataTable table = DAL.LinQConnection.getDataTable(sql);
                //dataGrid.DataSource = table;
                //Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.checHieu.Checked)
            {
                sql = "SELECT  DANHBO,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ORDER BY DOT,NGAYTHAY ASC";

            }
            return sql;

        }
        public void setBaoThay() { 
        
           for (int i = 0; i < dataGrid.Rows.Count; i++) {
               string sql = "SELECT N'LẦN ' + CONVERT(VARCHAR(10),DHN_LANTHAY) + N' BẢNG KÊ ' + CONVERT(VARCHAR(10),DHN_SOBANGKE) + N' NGÀY '+ CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) ";
                sql+=" FROM TB_THAYDHN  WHERE DHN_DANHBO='"+(dataGrid.Rows[i].Cells["G_DANHBO"].Value+"").Replace(" ","") +"' GROUP BY DHN_LANTHAY,DHN_SOBANGKE,DHN_NGAYBAOTHAY HAVING DHN_LANTHAY=MAX(DHN_LANTHAY)";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                if (table.Rows.Count>0) {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value = "" + table.Rows[0][0];
                }
                
            }
            
        
        }
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
             currentPageIndex = 1;
             pageSize = 20;
             pageNumber = 0;
             FirstRow = 0;
             LastRow = 0;
             rows = DAL.LinQConnection.ExecuteCommand(Search().Replace("DANHBO,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH,' ' as GBAOTHAY", " COUNT(*) ").Replace("ORDER BY DOT,NGAYTHAY ASC", " "));
            lbTongDHN.Text = "Tổng Số " + rows + " ĐHN.";
            try
            {
                PageTotal();
                DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
                setBaoThay();
            }
            catch (Exception ex)
            {

            }
           
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                //int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                contextMenuStrip1.Show(dataGrid, new Point(e.X, e.Y));

            }
        }

        private void dafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string listDanhBa = "";
            //try
            //{

            int flag = 0;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                {
                    flag++;
                    listDanhBa += ("'" + (this.dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "',");
                }
            }
            if (flag <= 10)
            {
                frm_Option_BT frm = new frm_Option_BT(listDanhBa.Remove(listDanhBa.Length - 1, 1));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btXemThongTin_Click(sender,e);
                }
            }
            else
            {
                MessageBox.Show(this, "Bảng Kê Báo Thay <= 10 Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //  MessageBox.Show(this,listDanhBa.Remove(listDanhBa.Length-1,1)+ "--" +flag);


            //}
            //catch (Exception)
            //{


            //}
        }


        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                if (currentPageIndex < 10)
                {
                    lbPaing.Text = "0"+currentPageIndex + "/" + pageNumber;
                }
                else
                {
                    lbPaing.Text = currentPageIndex + "/" + pageNumber;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
                setBaoThay();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                    dataGrid.DataSource = table;
                    Utilities.DataGridV.formatRows(dataGrid);
                    setBaoThay();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGrid);
        }
    }
}