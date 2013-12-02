using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Billding
{
    public partial class getDataBillding : Form
    {
        public getDataBillding()
        {
            InitializeComponent();
        }

        //private void bt_browsers_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog fd = new OpenFileDialog();
        //    fd.Filter = "*.dat|*.dat";
        //    fd.ShowDialog();
        //    textBoxX1.Text = fd.FileName;

        //}
        //bool readFile(string filePath)
        //{
        //    string line;


        //    if (File.Exists(filePath))
        //    {
        //        StreamReader file = null;
        //        try
        //        {
        //            BILLINGDataContext dataContext = new BILLINGDataContext();
        //            file = new StreamReader(filePath);
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                string[] words = Regex.Split(line, ",");
        //                if (words.Length == 55)
        //                {
        //                    BILLING bill = new BILLING();
        //                    bill = bill.set55field(words);
        //                    dataContext.BILLINGs.InsertOnSubmit(bill);
        //                }
        //                else if (words.Length == 56)
        //                {
        //                    BILLING bill = new BILLING();
        //                    bill.set56field(words);
        //                    dataContext.BILLINGs.InsertOnSubmit(bill);
        //                }
        //            }
        //            dataContext.SubmitChanges();
        //        }
        //        catch (Exception)
        //        {
        //            return true;

        //        }
        //        finally
        //        {
        //            if (file != null)
        //                file.Close();
        //        }
        //    }
        //    return true;
        //}

        //private void importDB_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.textBoxX1.Text == null || "".Equals(this.textBoxX1.Text) == true)
        //            this.errorProvider1.SetError(textBoxX1, "Không được trống !");
        //        else
        //        {
        //            this.errorProvider1.Clear();
        //            if (MessageBox.Show("Thực thi chương trình ? ", "..: Thông báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //            {
        //                if (readFile(textBoxX1.Text) == true)
        //                    MessageBox.Show("Thành công !!", "..: Thông báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                else
        //                    MessageBox.Show("Thất bại !!", "..: Thông báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Có lỗi xãy ra !!", "..: Thông báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
