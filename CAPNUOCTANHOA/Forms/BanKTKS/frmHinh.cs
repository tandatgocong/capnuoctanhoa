using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using System.IO;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frmHinh : Form
    {
        public frmHinh(string danhbo)
        {
            InitializeComponent();
            Load(danhbo);

        }
        DocSoTHDataContext db = new DocSoTHDataContext();
        ImageList lisIm = new ImageList();
        public void Load(string danhbo)
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Hình Chụp ĐHN", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

         
            List<HinhDHN> entity = db.HinhDHNs.Where(item => item.DanhBo == danhbo).OrderByDescending(item => item.CreateDate).ToList();

            int i = 0;
            foreach (var item in entity)
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = item.Image.ToArray();
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                //pictureBox1.Image = bm;
             //   pictureBox1.Image = bm;
                lisIm.ImageSize = new Size(100, 100);
                lisIm.Images.Add(i.ToString(),bm);

                listView1.Items.Add(item.ID.ToString(),Utilities.DateToString.NgayVNVN(item.CreateDate.Value), i);
                i++;
            }
            listView1.SmallImageList = lisIm;

            //listView1.Items.Add("asafda", 1);
            //listView1.Items.Add("asafda", 2);
            //listView1.Items.Add("asafda", 3);
            //db.CTChungTus.Where(itemCTChungTu => itemCTChungTu.MaCT == MaCT && itemCTChungTu.MaLCT == MaLCT).ToList();


            //MemoryStream mStream = new MemoryStream();
            //byte[] pData = entity.Image.ToArray();
            //mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            //Bitmap bm = new Bitmap(mStream, false);
            //mStream.Dispose();
            //pictureBox1.Image = bm;

        }

        

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string se = listView1.SelectedItems[0].Name;
                //MessageBox.Show(se); 

                HinhDHN entity = db.HinhDHNs.SingleOrDefault(item => item.ID == int.Parse(se));

                MemoryStream mStream = new MemoryStream();
                byte[] pData = entity.Image.ToArray();
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                pictureBox1.Image = bm;
            }
            catch (Exception)
            {


            }
            
        }
    }
}