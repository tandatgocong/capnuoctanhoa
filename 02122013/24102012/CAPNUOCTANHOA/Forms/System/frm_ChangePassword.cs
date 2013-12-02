using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.View.Users
{
    public partial class frm_ChangePassword : Form
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
            this.txtUserName.Text = DAL.SYS.C_USERS._userName;
            this.txtMatKhauHienTai.Focus();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            if (this.txtMatKhauMoi.Text.Equals(this.txtNhapLaiMKMOi.Text)) {

                if (DAL.SYS.C_USERS.ChangePass(this.txtUserName.Text.Trim(), this.txtMatKhauHienTai.Text.Trim(), this.txtMatKhauMoi.Text.Trim()) == 1)
                {
                    MessageBox.Show(this, "Mật Khẩu Đã Được Thay Đổi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show(this, "Thay Đổi Mật Khẩu Không Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show(this, "Nhập Lại Mật Khẩu Không Đúng.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
