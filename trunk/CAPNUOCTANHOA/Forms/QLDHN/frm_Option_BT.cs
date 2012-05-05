using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_Option_BT : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BaoThayDHN).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_Option_BT(string listDanhBo)
        {
            InitializeComponent();
            try
            {
                string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
                if (DAL.QLDHN.C_BaoThay.getMaxBangKe() >= int.Parse(balap))
                {
                    txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
                }
                else
                {
                    txtSoBangKe.Text = balap;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            string sql = "SELECT DANHBO,HOTEN,(SONHA+' '+TENDUONG) as 'DIACHI',NGAYTHAY,TB_HIEUDONGHO.TENDONGHO as 'HIEUDH',CODH,SOTHANDH,CHITHAN,CHIGOC,CHISOKYTRUOC,DOT,N'ĐỊNH KỲ' as 'GHICHU'";
            sql += "FROM  TB_DULIEUKHACHHANG, TB_HIEUDONGHO WHERE TB_HIEUDONGHO.HIEUDH=TB_DULIEUKHACHHANG.HIEUDH AND DANHBO IN (" + listDanhBo + ") ORDER BY DANHBO ASC ";

            dataBangKe.DataSource = DAL.LinQConnection.getDataTable(sql);
         
           

            cbLoaiBangKe.DataSource = DAL.QLDHN.C_BaoThay.getLoaiBangKe();
            cbLoaiBangKe.ValueMember = "LOAIBK";
            cbLoaiBangKe.DisplayMember = "TENBANGKE";
            cbLoaiBangKe.SelectedValue = "DK";

            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            //G_HIEUDHN.AutoCompleteMode = AutoCompleteMode.Suggest;
            //G_HIEUDHN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //G_HIEUDHN.AutoCompleteCustomSource = namesCollection;
        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["G_STT"].Value = i + 1;
            }
        }
        private void dataBangKe_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataBangKe.CurrentCell.OwningColumn.Name == "G_HIEUDHN")
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl te =
                    (DataGridViewTextBoxEditingControl)e.Control;
                    te.AutoCompleteMode = AutoCompleteMode.Suggest;
                    te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    te.AutoCompleteCustomSource = namesCollection;
                }
            }
        }

        private void frm_Option_BT_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string balap = DateTime.Now.Year.ToString().Substring(2) + "001";
            //    if (DAL.QLDHN.C_BaoThay.getMaxBangKe() > int.Parse(balap))
            //    {
            //        txtSoBangKe.Text = (DAL.QLDHN.C_BaoThay.getMaxBangKe() + 1) + "";
            //    }
            //    else
            //    {
            //        txtSoBangKe.Text = balap;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}
            Utilities.DataGridV.formatRows(dataBangKe);
            setSTT();
        }

        private void cbLoaiBangKe_SelectedValueChanged(object sender, EventArgs e)
        {
            if ("HC".Equals(this.cbLoaiBangKe.SelectedValue + ""))
            {
                title.Text = "BẢNG KÊ BÁO THAY HẠ CỞ ĐỒNG HỒ NƯỚC ";
            }
            else
            {
                title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC " + this.cbLoaiBangKe.Text;
            }
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["G_LYDO"].Value = this.cbLoaiBangKe.Text.Replace("THEO", "");
            }
            Utilities.DataGridV.formatRows(dataBangKe);
        }

        public void Add()
        {
            for (int i = 0; i < dataBangKe.Rows.Count;i++ )
            {
                TB_THAYDHN thaydh = new TB_THAYDHN();
                string sodanhbo = (dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "");
                thaydh.DHN_STT = int.Parse(dataBangKe.Rows[i].Cells["G_STT"].Value + "");
                thaydh.DHN_DANHBO = sodanhbo;
                thaydh.DHN_CHIGOC = dataBangKe.Rows[i].Cells["DHN_CHIGOC"].Value + "";
                thaydh.DHN_CHISO = int.Parse(dataBangKe.Rows[i].Cells["G_CHISO"].Value + "");
                thaydh.DHN_CHITHAN = dataBangKe.Rows[i].Cells["CHITHAN"].Value + "";
                thaydh.DHN_CODH = dataBangKe.Rows[i].Cells["G_CODHN"].Value + "";
                thaydh.DHN_DOT = dataBangKe.Rows[i].Cells["DOT"].Value + "";
                thaydh.DHN_HIEUDHN =  (dataBangKe.Rows[i].Cells["G_HIEUDHN"].Value + "").ToUpper();
                thaydh.DHN_LANTHAY = DAL.QLDHN.C_BaoThay.getMaxLanThay(sodanhbo) + 1;
                thaydh.DHN_LOAIBANGKE = this.cbLoaiBangKe.SelectedValue + "";
                thaydh.DHN_LYDOTHAY = dataBangKe.Rows[i].Cells["G_LYDO"].Value + "";
                thaydh.DHN_NGAYBAOTHAY = DateTime.Now.Date;
                thaydh.DHN_NGAYGAN = DateTime.Parse(dataBangKe.Rows[i].Cells["NGAYTHAY"].Value + "");
                thaydh.DHN_SOBANGKE = int.Parse(this.txtSoBangKe.Text);
                thaydh.DHN_CAP = "";
                thaydh.DHN_SOTHAN = dataBangKe.Rows[i].Cells["G_SOTHAN"].Value + "";                
                thaydh.DHN_TODS = DAL.SYS.C_USERS._toDocSo;
                thaydh.DHN_CREATEBY = DAL.SYS.C_USERS._userName;
                thaydh.DHN_CREATEDATE = DateTime.Now;
                DAL.QLDHN.C_BaoThay.Insert(thaydh);
                DAL.DULIEUKH.C_DuLieuKhachHang.UpdateBaoThay(sodanhbo, "True");
               // LoadData();
            }
            
            
        }
        private void btTaoBangKe_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                MessageBox.Show(this, "Thêm Mới Bảng Kê Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(this, "Thêm Mới Bảng Kê Thất Bại", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
           
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            if ("".Equals(this.txtSoBangKe.Text))
            {
                MessageBox.Show(this, "Cần nhập số bảng kê .", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSoBangKe.Focus();
            }
            else
            {
                ReportDocument rp = new rpt_BCBangKe_A3();
                if ("A4".Equals(Utilities.Files.pageSize.Trim()))
                {
                    rp = new rpt_BCBangKe_A4();
                }    
                rp.SetDataSource(DAL.QLDHN.C_BaoThay.ReportBaoThay(txtSoBangKe.Text));
                rp.SetParameterValue("lapbk", DAL.SYS.C_USERS._fullName);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }
    }
}
