namespace CAPNUOCTANHOA.View.Users
{
    partial class frm_ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btThoat = new DevComponents.DotNetBar.ButtonX();
            this.btChange = new DevComponents.DotNetBar.ButtonX();
            this.txtNhapLaiMKMOi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMatKhauMoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMatKhauHienTai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.btChange);
            this.panel1.Controls.Add(this.txtNhapLaiMKMOi);
            this.panel1.Controls.Add(this.txtMatKhauMoi);
            this.panel1.Controls.Add(this.txtMatKhauHienTai);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 193);
            this.panel1.TabIndex = 0;
            // 
            // btThoat
            // 
            this.btThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ForeColor = System.Drawing.Color.DarkRed;
            this.btThoat.Location = new System.Drawing.Point(253, 150);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(96, 31);
            this.btThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btThoat.TabIndex = 6;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btChange
            // 
            this.btChange.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btChange.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btChange.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChange.ForeColor = System.Drawing.Color.DarkRed;
            this.btChange.Location = new System.Drawing.Point(151, 150);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(96, 31);
            this.btChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btChange.TabIndex = 5;
            this.btChange.Text = "Thay Đổi";
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // txtNhapLaiMKMOi
            // 
            // 
            // 
            // 
            this.txtNhapLaiMKMOi.Border.Class = "TextBoxBorder";
            this.txtNhapLaiMKMOi.Location = new System.Drawing.Point(151, 115);
            this.txtNhapLaiMKMOi.Name = "txtNhapLaiMKMOi";
            this.txtNhapLaiMKMOi.PasswordChar = '*';
            this.txtNhapLaiMKMOi.Size = new System.Drawing.Size(225, 26);
            this.txtNhapLaiMKMOi.TabIndex = 4;
            // 
            // txtMatKhauMoi
            // 
            // 
            // 
            // 
            this.txtMatKhauMoi.Border.Class = "TextBoxBorder";
            this.txtMatKhauMoi.Location = new System.Drawing.Point(151, 79);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(225, 26);
            this.txtMatKhauMoi.TabIndex = 3;
            // 
            // txtMatKhauHienTai
            // 
            // 
            // 
            // 
            this.txtMatKhauHienTai.Border.Class = "TextBoxBorder";
            this.txtMatKhauHienTai.Location = new System.Drawing.Point(151, 47);
            this.txtMatKhauHienTai.Name = "txtMatKhauHienTai";
            this.txtMatKhauHienTai.PasswordChar = '*';
            this.txtMatKhauHienTai.Size = new System.Drawing.Size(225, 26);
            this.txtMatKhauHienTai.TabIndex = 2;
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Location = new System.Drawing.Point(151, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(225, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(21, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(132, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Nhập Lại Mật Khẩu";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(21, 79);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(132, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Mật Khẩu Mới";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(21, 50);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(132, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Mật Khẩu Hiên Tại";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(21, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(113, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên Đăng Nhập";
            // 
            // frm_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(435, 193);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNhapLaiMKMOi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMatKhauMoi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMatKhauHienTai;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btThoat;
        private DevComponents.DotNetBar.ButtonX btChange;
    }
}