using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.TabBC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Data.SqlClient;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.Forms.QLDHN.Tab.BC;
using System.IO;
using System.Data.OleDb;

namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    public partial class W_tab_ThongKeHoaDon : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(L_tab_LoTrinhThayDoi).Name);
        public W_tab_ThongKeHoaDon()
        {
            InitializeComponent();
            txtNgayGan.Value = DateTime.Now.Date;
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
        }

        // static OleDbConnection _con;
        ////OleDbCommand _cmd;
        //OleDbDataAdapter _da;
        //DataTable _table;
        //String _cn;
        //String pathFile;

        class CExcel
        {
            static OleDbConnection _con;
            //OleDbCommand _cmd;
            OleDbDataAdapter _da;
            DataTable _table;
            String _cn;
            String pathFile;

            public CExcel(String pathFile)
            {
                this.pathFile = pathFile;
            }

            #region Hàm connect file Excel 2010 trở về trước

            public OleDbConnection Connect()
            {
                if (pathFile.Contains("xlsx")) _cn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathFile + ";" + "Extended Properties=Excel 12.0;";
                else
                    _cn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + pathFile + ";" + "Extended Properties=Excel 8.0;";
                _con = new OleDbConnection(_cn);
                _con.Open();
                return _con;
            }

            #endregion

            #region hàm thực thi 1 câu lệnh truy vấn như sql

            public DataTable GetDataTable(String sql)
            {
                _table = new DataTable();
                try
                {
                    _con = Connect();
                    _da = new OleDbDataAdapter(sql, _con);
                    _da.Fill(_table);
                    _con.Close();
                    return _table;
                }
                catch (OleDbException ex)
                {
                    _con.Close();
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return _table;
                }

            }

            #endregion
        }

        string ky_(string id)
        {
            if (int.Parse(id) < 10)
                id = "0" + id;

            return id;

        }

        public void LoadHoaDon(DataTable dtExcel)
        {
            DataTable workTable = new DataTable("TABLE");

            DataColumn workCol = workTable.Columns.Add("DANHBA", typeof(String));

            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int soky = int.Parse(txtSoKy.Text);
            int nam = int.Parse(txtNam.Text.Trim());
            int flag = 1;

            while (flag <= soky)
            {
                workTable.Columns.Add((ky_(ky + "") + "/" + nam), typeof(String));

                ky = ky - 1;
                if (ky < 1)
                {
                    ky = 12;
                    nam = nam - 1;
                }
                flag++;

            }
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow row = workTable.NewRow();
                string db = dtExcel.Rows[i][0].ToString();
                row["DANHBA"] = db;


                for (int j = 1; j < workTable.Columns.Count; j++)
                {
                    string sql = " SELECT  ( cast( CodeMoi as varchar) + ' - ' + cast( CSMoi as varchar)  + ' - ' +cast( TieuThuMoi as varchar)  ) AS TTT FROM DocSo WHERE DANHBA='" + db + "'  AND Ky= SUBSTRING('" + workTable.Columns[j].ColumnName + "',1,2) AND Nam= SUBSTRING('" + workTable.Columns[j].ColumnName + "',4,4)  ";
                    try
                    {
                        row[workTable.Columns[j].ColumnName] = DAL.LinQConnectionDS.getDataTable(sql).Rows[0]["TTT"];
                    }
                    catch (Exception)
                    {
                        row[workTable.Columns[j].ColumnName] = "";
                    }


                }

                workTable.Rows.Add(row);


            }

            dataGridView1.DataSource = workTable;

        }

        private void btNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CExcel fileExcel = new CExcel(dialog.FileName);
                DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                // dataGridView1.DataSource = dtExcel;
                //////////////////////////
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    string db = dtExcel.Rows[i][0].ToString();

                    DAL.LinQConnection.ExecuteCommand("INSERT INTO  PT_HOADON(CREATEBY,CREATEDATE,DANHBO)  VALUES('" + DAL.SYS.C_USERS._userName + "','" + this.txtNgayGan.Value.Date + "','" + db + "')");
                }

                LoadHoaDon(dtExcel);


            }
        }

        void pppppLoad()
        {
            try
            {
                string sql = "SELECT DANHBO  FROM  PT_HOADON WHERE CREATEBY='" + DAL.SYS.C_USERS._userName + "' AND CREATEDATE='" + this.txtNgayGan.Value.Date + "'";
                DataTable dtExcel = DAL.LinQConnection.getDataTable(sql);
                LoadHoaDon(dtExcel);
            }
            catch (Exception)
            {

            }
        }
        private void txtNgayGan_ValueChanged(object sender, EventArgs e)
        {

            pppppLoad();


        }

        string getListDB()
        {
            string listDanhBa = "";
            try
            {

                int flag = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGridView1.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                        listDanhBa += ("'" + (this.dataGridView1.Rows[i].Cells["DANHBA"].Value + "").Replace(" ", "") + "',");
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return listDanhBa.Remove(listDanhBa.Length - 1, 1);

        }

        private void btXoa_Click(object sender, EventArgs e)
        {


            string sql = "DELETE  FROM  PT_HOADON WHERE DANHBO IN (" + getListDB() + ") AND  CREATEBY='" + DAL.SYS.C_USERS._userName + "' AND CREATEDATE='" + this.txtNgayGan.Value.Date + "'";
            DAL.LinQConnection.ExecuteCommand(sql);
            pppppLoad();


        }
    }
}