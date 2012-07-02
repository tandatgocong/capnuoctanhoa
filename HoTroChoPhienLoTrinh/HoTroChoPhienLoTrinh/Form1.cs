using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HoTroChoPhienLoTrinh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 50; i++)
            {
                string flag = i+"";
                if (i < 10) {
                    flag = "0" + i;
                }
                cbMay.Items.Add(flag);
            }
        }

        public static string sohoso(string _sohoso)
        {
            _sohoso = _sohoso.Insert(4, ".");
            _sohoso = _sohoso.Insert(9, ".");
            return _sohoso;
        }
        public static string sodanhbo(string _danhbo)
        {
            if (_danhbo.Length == 11)
            {
                _danhbo = _danhbo.Insert(4, "  ");
                _danhbo = _danhbo.Insert(9, "  ");

            }
            return _danhbo;
        }
        public static string sodanhbo(string _danhbo, string kytu)
        {
            _danhbo = _danhbo.Trim();
            if (_danhbo.Length > 8)
            {
                _danhbo = _danhbo.Insert(4, kytu);
                _danhbo = _danhbo.Insert(8, kytu);

            }
            return _danhbo;
        }

        public static string phienlotrinh(string _lotrinh, string kytu)
        {
            _lotrinh = _lotrinh.Replace(" ", "");
            _lotrinh = _lotrinh.Replace(kytu, "");
            if (_lotrinh.Length > 6)
            {
                _lotrinh = _lotrinh.Insert(2, kytu);
                _lotrinh = _lotrinh.Insert(5, kytu);

            }
            return _lotrinh;
        }
        public static void formatRows(DataGridView dview, string rows, string lotrinh)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells[rows].Value = dview.Rows[i].Cells[rows].Value != null ? sodanhbo(dview.Rows[i].Cells[rows].Value + "") : dview.Rows[i].Cells[rows].Value;
                }
                catch (Exception)
                {

                }
                try
                {
                    dview.Rows[i].Cells[lotrinh].Value = dview.Rows[i].Cells[lotrinh].Value != null ? phienlotrinh(dview.Rows[i].Cells[lotrinh].Value + "", ".") : dview.Rows[i].Cells[lotrinh].Value;
                }
                catch (Exception)
                {

                }

            }
        }

        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }
        public static DataTable getPhienLoTrinh(string lotrinh)
        {
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN FROM TB_DULIEUKHACHHANG WHERE LEFT(LOTRINH,4)='" + lotrinh + "' ORDER BY LOTRINH ASC ";
            return getDataTable(sql);
        }
        public static DataTable DIACHI(string diachi)
        {
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN FROM TB_DULIEUKHACHHANG WHERE (SONHA+' '+ TENDUONG) LIKE '" + diachi.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
            return getDataTable(sql);
        }

        public static DataTable DANHBO(string danhbo)
        {
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN FROM TB_DULIEUKHACHHANG WHERE DANHBO = '" + danhbo + "' ORDER BY LOTRINH ASC ";
            return getDataTable(sql);
        }

        public static DataTable LOTRINH(string LT)
        {
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN FROM TB_DULIEUKHACHHANG WHERE LOTRINH = '" + LT + "' ORDER BY LOTRINH ASC ";
            return getDataTable(sql);
        }
        private void cbMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource= getPhienLoTrinh(cbDot.Text+""+cbMay.Text);
            formatRows(dataGridView2, "M_DANHBA", "M_LOTRINH");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DIACHI(textBox1.Text);
            formatRows(dataGridView1, "DC_DANHBA", "DC_LOTRINH");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.DataSource = DIACHI(textBox1.Text);
                formatRows(dataGridView1, "DC_DANHBA", "DC_LOTRINH");
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            formatRows(dataGridView1, "DC_DANHBA", "DC_LOTRINH");
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            formatRows(dataGridView2, "M_DANHBA", "M_LOTRINH");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                dataGridView3.DataSource = DANHBO(txtDanhBo.Text);
                formatRows(dataGridView3, "db_DANHBA", "db_LOTRINH");
           
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView3.DataSource = DANHBO(txtDanhBo.Text);
                formatRows(dataGridView3, "db_DANHBA", "db_LOTRINH");
            }
        }

        private void dataGridView3_Sorted(object sender, EventArgs e)
        {
            formatRows(dataGridView3, "db_DANHBA", "db_LOTRINH");
        }

        private void txtLoTrinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView4.DataSource = LOTRINH(txtLoTrinh.Text);
                formatRows(dataGridView4, "db_DANHBA", "db_LOTRINH");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView4.DataSource = LOTRINH(txtLoTrinh.Text);
            formatRows(dataGridView4, "lt_DANHBA", "lt_LOTRINH");
            
        }

        private void dataGridView4_Sorted(object sender, EventArgs e)
        {
            formatRows(dataGridView4, "lt_DANHBA", "lt_LOTRINH");
        }
    }
}
