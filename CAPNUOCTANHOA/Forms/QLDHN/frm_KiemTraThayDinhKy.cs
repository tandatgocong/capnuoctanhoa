using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_KiemTraThayDinhKy : UserControl
    {
        public frm_KiemTraThayDinhKy()
        {
            InitializeComponent();
            LoadDataToGird();
            cbCoDH.SelectedIndex = 0;
            cbDot.SelectedIndex = 0;
            dateTime.Value = DateTime.Now;
            dateKd.Value = DateTime.Now;
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
        int pageSize = 200;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        public string Search()
        {

            DateTime date = dateTime.Value;
            
            string codh = "=" + cbCoDH.Text;

            //date = date.AddMonths(1);
           
            if (cbCoDH.SelectedIndex == 1 || cbCoDH.SelectedIndex == 2)
            {
                date = date.AddYears(-4);
            }
            else
            {
                date = date.AddYears(-5);
            }


            //
            //codh = "=25";
            //
            string sql = "";

            string quan = DAL.SYS.C_USERS._gioihan;
            //if (DAL.SYS.C_USERS._toDocSo.Equals("TP"))
            //{
            //    quan = " = 31";
            //}
            string dot = "";
            if (!"00".Equals(cbDot.Text))
            {
                dot = " AND DOT='" + cbDot.Text + "'";
            }

            if (this.ckNgayThay.Checked && this.checHieu.Checked)
            {
                sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,NGAYKIEMDINH,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "'  ";
                sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "')  " + dot;
                //DataTable table = DAL.LinQConnection.getDataTable(sql);
                //dataGrid.DataSource = table;
                //Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.ckNgayThay.Checked)
            {
                sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,NGAYKIEMDINH,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL)  " + quan + " AND CODH" + codh + "  AND NGAYTHAY <= '" + date.ToShortDateString() + "'  " + dot;
                //DataTable table = DAL.LinQConnection.getDataTable(sql);
                //dataGrid.DataSource = table;
                //Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.ngayKD.Checked)
            {
                date = dateKd.Value;
                //date = date.AddMonths(1);

                if (cbCoDH.SelectedIndex == 1 || cbCoDH.SelectedIndex == 2)
                {
                    date = date.AddYears(-4);
                }
                else
                {
                    date = date.AddYears(-5);
                }



                sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,NGAYKIEMDINH,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL)  " + quan + " AND CODH" + codh + "  AND ISNULL(NGAYKIEMDINH,NGAYTHAY) <= '" + date.ToShortDateString() + "'  " + dot;
                //DataTable table = DAL.LinQConnection.getDataTable(sql);
                //dataGrid.DataSource = table;
                //Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.checHieu.Checked)
            {
                sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,NGAYKIEMDINH,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "')  " + dot;

            }
            if (!"".Equals(txtLoaiBo.Text.Replace(" ", ""))) {

                string bo = "AND CODE NOT IN ('" + txtLoaiBo.Text.Replace(",", "','").ToUpper() + "')  ";
                sql += " " + bo;
            }
            sql += " ORDER BY  LOTRINH ASC ";
            return sql;

        }
        DataTable lisDB = null;
        public void setBaoThay()
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                string sql = " SELECT TOP(1)  N'TRỞ NGẠI (' + CONVERT(varchar(10),HCT_NGAYGAN,103) + '): '  + HCT_LYDOTRONGAI  + ' - ['  + ISNULL(XLT_KETQUA,'') + ']'  ";
                sql += " FROM TB_THAYDHN  WHERE XLT_XULY='True' AND DHN_DANHBO='" + (dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "' ORDER BY DHN_NGAYBAOTHAY DESC ";
                DataTable table = DAL.LinQConnection.getDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value = "" + table.Rows[0][0];

                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }
                
                string sql2 = "  SELECT N'BK SỐ ' +  CAST(SOBANGKE AS VARCHAR) + ' NGÀY '  +CONVERT(VARCHAR(20),NGAYBAO,103) FROM  TB_TLKDUTCHI  WHERE  DANHBO='" + (dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "' AND [TYPE]='0' AND YEAR(NGAYBAO) BETWEEN ( YEAR(GETDATE())-1) AND YEAR(GETDATE())  ORDER BY NGAYBAO DESC";
                table = DAL.LinQConnection.getDataTable(sql2);

                if (table.Rows.Count > 0)
                {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value += "" + table.Rows[0][0];

                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }

                //else {
                //    tb.Rows.RemoveAt(i);
                //}
            }

            DataTable t1 = (DataTable)dataGrid.DataSource;
            lisDB = t1.AsEnumerable()
          .Where(row => row.Field<String>("GBAOTHAY") != " ")
          .OrderByDescending(row => row.Field<String>("LOTRINH"))
          .CopyToDataTable();

        }
        
        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            pageSize = 200;
            pageNumber = 0;
            FirstRow = 0;
            LastRow = 0;

            string sqlCount = Search().Replace("CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,NGAYKIEMDINH,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY", " COUNT(*) ").Replace("ORDER BY  LOTRINH ASC", " ");
            rows = DAL.LinQConnection.ExecuteCommand(sqlCount);
            lbTongDHN.Text = "Tổng Số " + rows + " ĐHN.";
            try
            {
                PageTotal();
                DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                dataGrid.DataSource = table;
              
                //Utilities.DataGridV.formatRows(dataGrid);
                setBaoThay();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(this, ex.Message);
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
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_KiemTraThayDinhKy).Name);
       
        private void dafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                if (flag <= int.Parse(Utilities.Files.numberRecord))
                {
                    frm_Option_BT frm = new frm_Option_BT(listDanhBa.Remove(listDanhBa.Length - 1, 1));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btXemThongTin_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //  MessageBox.Show(this,listDanhBa.Remove(listDanhBa.Length-1,1)+ "--" +flag);


                //}
                //catch (Exception)
                //{


                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }


        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = (currentPageIndex < 10 ? ("0" + currentPageIndex) : currentPageIndex + "") + "/" + (pageNumber < 10 ? ("0" + pageNumber) : pageNumber + "");
            }
            catch (Exception)
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

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //int flag = 0;
            //for (int i = 0; i < dataGrid.Rows.Count; i++)
            //{
            //    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
            //    {
            //        flag++;
            //    }
            //}
            //if (flag >= int.Parse(Utilities.Files.numberRecord))
            //{
            //    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.CurrentCell.OwningColumn.Name == "checkChon")
            {
                int flag = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                    }
                }
                if (flag >= int.Parse(Utilities.Files.numberRecord))
                {
                    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frm_Option_BT_TN f = new frm_Option_BT_TN(lisDB);
            f.ShowDialog();
        }

       
    }
}