using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_LayDuLieuGanMoi_Ky : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString;
        string connectionString2 = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile2"].ConnectionString;
        public frm_LayDuLieuGanMoi_Ky()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
        }
        void formatRows()
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                dataGanMoiBK.Rows[i].Cells["STT"].Value = i + 1;
                if (i % 2 == 0)
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dataGanMoiBK.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                string shs = dataGanMoiBK.Rows[i].Cells["SHS"].Value + "";
                string sql = "SELECT SoHo,SoNha,Duong FROM [T02 DANH SACH HO SO KHACH HANG] WHERE  SHS='" + shs + "' ";
                DataTable table = DAL.OledbConnection.getDataTable(connectionString2, sql);
                if (table.Rows.Count >= 1)
                {
                    dataGanMoiBK.Rows[i].Cells["SoHo"].Value = table.Rows[0]["SoHo"];
                    //MessageBox.Show(this, table.Rows[0]["SoHo"].ToString());
                    dataGanMoiBK.Rows[i].Cells["SONHA"].Value = table.Rows[0]["SoNha"];
                    dataGanMoiBK.Rows[i].Cells["DUONG"].Value = table.Rows[0]["Duong"];
                    dataGanMoiBK.Rows[i].Cells["HOTEN"].Value = (dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "").Replace(" (ÑD " + table.Rows[0]["SoHo"] + " hoä)", "");
                }
                //try
                //{
                //    dataGanMoiBK.Rows[i].Cells["DANHBO"].Value = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "") : dataGanMoiBK.Rows[i].Cells["DANHBO"].Value;
                //}
                //catch (Exception)
                //{

                //}

            }
            //MessageBox.Show(this, "fdsafdsa");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string hieuluc = cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + this.txtNam.Text;

            string sql = "SELECT SHS,danhbo, PLT,giabieu,dinhmuc,hieuluc,hopdong,HoTen, NGAYGANTLK, Hieu,coTLK,SOTLK,CHISOTLK ,maPQ FROM [T07 DANH SACH HO SO HOAN CONG] WHERE  danhbo <> '' AND hieuluc='" + hieuluc + "' ORDER BY hopdong ASC ";
            DataTable table = DAL.OledbConnection.getDataTable(connectionString, sql);
            dataGanMoiBK.DataSource = table;
            formatRows();
        }
       
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_LayDuLieuGanMoi_Ky).Name);
       
        private void next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGanMoiBK.Rows.Count; i++)
            {
                string DANHBO = dataGanMoiBK.Rows[i].Cells["DANHBO"].Value + "";
                string HOPDONG = dataGanMoiBK.Rows[i].Cells["HOPDONG"].Value + "";
                string HOTEN = dataGanMoiBK.Rows[i].Cells["HOTEN"].Value + "";
                string SONHA = dataGanMoiBK.Rows[i].Cells["SONHA"].Value + "";
                string DUONG = dataGanMoiBK.Rows[i].Cells["DUONG"].Value + "";
                string MAQP = dataGanMoiBK.Rows[i].Cells["MAQP"].Value + "";
                string PLT = dataGanMoiBK.Rows[i].Cells["PLT"].Value + "";
                string GIABIEU = dataGanMoiBK.Rows[i].Cells["GIABIEU"].Value + "";
                string DINHMUC = dataGanMoiBK.Rows[i].Cells["DINHMUC"].Value + "";
                string hieuluc = dataGanMoiBK.Rows[i].Cells["hieuluc"].Value + "";
                string NGAYGANTLK = dataGanMoiBK.Rows[i].Cells["NGAYGANTLK"].Value + "";
                string HIEU = (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "").Equals("") ? "KEN" : (dataGanMoiBK.Rows[i].Cells["HIEU"].Value + "");
                string COTLK = dataGanMoiBK.Rows[i].Cells["COTLK"].Value + "";
                string SOTLK = dataGanMoiBK.Rows[i].Cells["SOTLK"].Value + "";
                string CHISOTLK = dataGanMoiBK.Rows[i].Cells["CHISOTLK"].Value + "";
                string SoHo = dataGanMoiBK.Rows[i].Cells["SoHo"].Value + "";             
                VniToUnicode.ClassViToUnicode vn = new VniToUnicode.ClassViToUnicode();
                
                string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC) VALUES ";
                insert += "('" + DANHBO + "','" + HOPDONG + "','" + vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "") + "','" + vn.VniToKD(SONHA).ToUpper() + "','" + vn.VniToKD(DUONG).ToUpper() + "','" + MAQP.Substring(0, 2) + "','" + MAQP.Substring(2) + "','" + GIABIEU + "','" + DINHMUC + "','" + NGAYGANTLK + "','" + DateTime.Parse(NGAYGANTLK) + "','" + HIEU + "','" + COTLK + "','" + SOTLK.ToUpper() + "','0')";

                log.Info(DANHBO + "-----" + vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", ""));
                DAL.LinQConnection.ExecuteCommand(insert);


                //TB_DULIEUKHACHHANG tb = new TB_DULIEUKHACHHANG();
                //tb.DANHBO = DANHBO; 
                //tb.HOPDONG = HOPDONG; 
                //tb.HOTEN =  vn.VniToKD(HOTEN).ToUpper().Replace("(DD " + SoHo + " HO)", "")
                //tb.SONHA = SONHA;
                //tb.TENDUONG = vn.VniToKD(DUONG).ToUpper(); 
                //tb.QUAN = MAQP.Substring(0, 2); 
                //tb.PHUONG = MAQP.Substring(2);
                //tb.GIABIEU = GIABIEU; 
                //tb.DINHMUC = DINHMUC;
                //tb.NGAYGANDH = NGAYGANTLK;
                //tb.NGAYTHAY = DateTime.Parse(NGAYGANTLK);
                //tb.HIEUDH = "".Equals(HIEU) ? "KEN" : HIEU;
                //tb.CODH = COTLK;
                //tb.SOTHANDH = SOTLK.ToUpper(); 
                //tb.CHISOKYTRUOC = "0";
                //log.Info(tb.DANHBO + "----" + tb.HOTEN);
                //DAL.DULIEUKH.C_DuLieuKhachHang.Insert(tb);
                
              
            }

            MessageBox.Show(this, "Thanh Cong");
        }

    }
}