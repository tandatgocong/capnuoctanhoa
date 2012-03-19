using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.LayDuLieu
{
    public partial class frm_baothay_lay : Form
    {
        public frm_baothay_lay()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            dataGridView1.DataSource = DAL.OledbConnection.getDataTable(ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString, "SELECT * FROM BAOTHAY  ORDER BY SOBANGKE ASC");
            sodh.Text = "So Record " +(dataGridView1.Rows.Count - 1);

        }

        public void getData() {
            int tmp_sobangke = 0;
            int stt = 1;
            int lanthay = int.Parse(this.txtLanThay.Text);
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++) {
                string sobangke = dataGridView1.Rows[i].Cells["SOBANGKE"].Value + "";
                string danhbo = dataGridView1.Rows[i].Cells["DANHBO"].Value + "";
                //string ngay = dataGridView1.Rows[i].Cells["NGAY"].Value + "";
               // string dot = dataGridView1.Rows[i].Cells["DOT"].Value + "";
                string chithan = dataGridView1.Rows[i].Cells["CHITHAN"].Value + "";
                string chigoc = dataGridView1.Rows[i].Cells["CHIGOC"].Value + "";
                string hieu = dataGridView1.Rows[i].Cells["HIEU"].Value + "";
                string sothan = dataGridView1.Rows[i].Cells["SOTHAN"].Value + "";
                string chiso = dataGridView1.Rows[i].Cells["CHISO"].Value + "";
                string lydo = dataGridView1.Rows[i].Cells["LYDO"].Value + "";
                string codh = dataGridView1.Rows[i].Cells["CODH"].Value + "";
                string ghichu = dataGridView1.Rows[i].Cells["GHICHU"].Value + "";
               
                /////////////

                TB_THAYDHN thaydhn = new TB_THAYDHN();
                thaydhn.DHN_LANTHAY = lanthay;
                if ("DINH KY".Contains(lydo.ToUpper()) || "DINHKY".Contains(lydo.ToUpper())) {
                    thaydhn.DHN_LOAIBANGKE = "DK";
                }
                else if ("NGUNG".Contains(lydo.ToUpper()) )
                {
                    thaydhn.DHN_LOAIBANGKE = "NG";
                }
                else if ("KINH MO".Contains(lydo.ToUpper()) || "KINHMO".Contains(lydo.ToUpper()))
                {
                    thaydhn.DHN_LOAIBANGKE = "KM";
                }
                else if ("BAT HUONG".Contains(lydo.ToUpper()) || "BATHUONG".Contains(lydo.ToUpper()))
                {
                    thaydhn.DHN_LOAIBANGKE = "BT";
                }
                else if ("DUT CHI".Contains(lydo.ToUpper()) || "DUTCHI".Contains(lydo.ToUpper()))
                {
                    thaydhn.DHN_LOAIBANGKE = "DC";
                }
                else {
                    thaydhn.DHN_LOAIBANGKE = lydo.ToUpper();
                }
                int db_sobangke = 0;
                try
                {
                    db_sobangke = int.Parse(sobangke);
                }
                catch (Exception)
                {

                  
                }
                
                thaydhn.DHN_SOBANGKE = db_sobangke;
                if (tmp_sobangke == db_sobangke)
                {
                    stt++;
                    thaydhn.DHN_STT = stt;
                }
                else {
                    stt = 1;
                    thaydhn.DHN_STT = stt;
                    tmp_sobangke = db_sobangke;
                }
                thaydhn.DHN_DANHBO = danhbo;
                if(dataGridView1.Rows[i].Cells["NGAY"].Value != null)
                    thaydhn.DHN_NGAYBAOTHAY = DateTime.Parse(dataGridView1.Rows[i].Cells["NGAY"].Value + "");
                thaydhn.DHN_DOT = dataGridView1.Rows[i].Cells["DOT"].Value + "";
                thaydhn.DHN_TODS = tods.Text;
                thaydhn.DHN_CHITHAN = chithan.ToUpper(); ;
                thaydhn.DHN_CHIGOC = chigoc.ToUpper(); ;
                thaydhn.DHN_HIEUDHN = hieu.ToUpper();
                thaydhn.DHN_CODH = codh.ToUpper(); ;
                thaydhn.DHN_SOTHAN = sothan.ToUpper(); ;
                try
                {
                    thaydhn.DHN_CHISO = int.Parse(chiso);
                }
                catch (Exception)
                {

                    thaydhn.DHN_CHISO = 0;
                }

                thaydhn.DHN_LYDOTHAY = lydo.ToUpper();
                thaydhn.DHN_GHICHU = ghichu.ToUpper(); ;
                thaydhn.DHN_CREATEDATE = DateTime.Now;
                thaydhn.DHN_CREATEBY = "system";
                db.TB_THAYDHNs.InsertOnSubmit(thaydhn);
            }
           db.SubmitChanges();
            MessageBox.Show(this,"thanhcong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
