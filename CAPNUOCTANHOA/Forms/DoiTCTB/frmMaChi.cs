using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmMaChi : Form
    {
        public frmMaChi()
        {
            InitializeComponent();
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM TB_MACHI ORDER BY ID DESC");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DAL.LinQConnection.ExecuteCommand_("INSERT INTO TB_MACHI(MACHI) VALUES (N'"+textBox1.Text+"') ");
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM TB_MACHI ORDER BY ID DESC");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
            this.textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value + "";
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DAL.LinQConnection.ExecuteCommand_("DELETE FROM TB_MACHI WHERE ID='" + this.textBoxid.Text + "'");
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM TB_MACHI ORDER BY ID DESC");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DAL.LinQConnection.ExecuteCommand_("UPDATE TB_MACHI SET MACHI=N'" + textBox1.Text + "'  WHERE ID='" + this.textBoxid.Text + "'");
            dataGridView1.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM TB_MACHI ORDER BY ID DESC");
        }
    }
}
