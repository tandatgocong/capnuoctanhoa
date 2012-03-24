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
            DateTime date= dateTime.Value;
            string codh = "<=25";
            if (cbCoDH.SelectedIndex == 1)
            {
                codh = ">25";
                date=date.AddYears(-3);
            }
            else {
                codh = "<=25";
               date= date.AddYears(-5);
            }
            string sql="";

            string quan = " != 31";
            if (DAL.SYS.C_USERS._toDocSo.Equals("TP")) {
                quan = " = 31";
            }
            if (this.ckNgayThay.Checked && this.checHieu.Checked) {
                sql = "SELECT TOP(500) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) AND QUAN" + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "'  ";
                sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ORDER BY NGAYTHAY ASC ";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.ckNgayThay.Checked) {
                sql = "SELECT TOP(500) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) AND QUAN" + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "' ORDER BY NGAYTHAY ASC";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
            }
            else if (this.checHieu.Checked)
            {
                sql = "SELECT TOP(500) DANHBO, HOTEN, (SONHA +''+ TENDUONG) AS 'DIACHI',NGAYTHAY,HIEUDH,CODH FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) AND QUAN" + quan + " AND CODH" + codh + " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "') ORDER BY NGAYTHAY ASC";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
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
           string listDanhBa="";
            //try
            //{
                 
                int flag = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                        listDanhBa += ("'" + (this.dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace("-", "") + "',");
                    }
                }
                frm_Option_BT frm = new frm_Option_BT();
                frm.ShowDialog();
              //  MessageBox.Show(this,listDanhBa.Remove(listDanhBa.Length-1,1)+ "--" +flag);
                

            //}
            //catch (Exception)
            //{


            //}
        }

           
    }
}
