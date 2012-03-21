using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Utilities;
using System.Security.Cryptography;

namespace CAPNUOCTANHOA.View.Users
{
    public partial class frm_Login : Form
    {
        static public string username = "";
        static public int result = 0;
        static public string fullName = "";
        public frm_Login()
        {
            InitializeComponent();
            loadpass();
        }
        public void loadpass()
        {
            try
            {
                string[] id = LogIn.readpass();
                this.txtuserName.Text = id[0];
                this.txtPass.Text = LogIn.Decrypt(id[1]);
                if (id[0] == null || "".Equals(id[0]) == true)
                {
                    this.ckSavePass.Checked = false;
                }
                else
                {
                    this.ckSavePass.Checked = true;
                }
            }
            catch (Exception)
            {

            }
        }
        public void DangNhap()
         {
             string udi = this.txtuserName.Text;
             string pass = this.txtPass.Text;

             if (this.ckSavePass.Checked == true)
             {
                  
                 LogIn.savepass(udi, LogIn.Encrypt(pass));
             }
             else
             {
                 LogIn.savepass("", "");
             }
             if (udi == "")
             {
                 errorProvider1.SetError(txtuserName, "Nhập Tên Đăng Nhập !");
                 return;
             }else{
                 errorProvider1.Clear();
             }
             string password = LogIn.Encrypt(pass);
            CAPNUOCTANHOA.DAL.SYS.C_USERS users = new CAPNUOCTANHOA.DAL.SYS.C_USERS();
            if (users.UserLogin(udi, password))    {
                this.lbFail.Visible = false;
                this.Close();
            }
            else {
                this.lbFail.ForeColor = Color.Red;
                this.lbFail.Visible = true;
            }
            
         }
        private void bt_Login_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
       

        private void bt_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { DangNhap(); }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { DangNhap(); }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
      
        }     
      
    }
}
