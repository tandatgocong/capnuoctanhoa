namespace CAPNUOCTANHOA.View.Users
{
    partial class frm_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.bt_Login = new DevComponents.DotNetBar.ButtonX();
            this.bt_huy = new DevComponents.DotNetBar.ButtonX();
            this.ckSavePass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbFail = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Login
            // 
            this.bt_Login.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Login.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Login.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.bt_Login.Location = new System.Drawing.Point(120, 179);
            this.bt_Login.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(91, 25);
            this.bt_Login.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bt_Login.TabIndex = 0;
            this.bt_Login.Text = "Đăng Nhập";
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_huy
            // 
            this.bt_huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_huy.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.bt_huy.Location = new System.Drawing.Point(229, 179);
            this.bt_huy.Margin = new System.Windows.Forms.Padding(4);
            this.bt_huy.Name = "bt_huy";
            this.bt_huy.Size = new System.Drawing.Size(91, 25);
            this.bt_huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bt_huy.TabIndex = 1;
            this.bt_huy.Text = "Hủy";
            this.bt_huy.Click += new System.EventHandler(this.bt_huy_Click);
            // 
            // ckSavePass
            // 
            this.ckSavePass.Location = new System.Drawing.Point(120, 145);
            this.ckSavePass.Margin = new System.Windows.Forms.Padding(4);
            this.ckSavePass.Name = "ckSavePass";
            this.ckSavePass.Size = new System.Drawing.Size(267, 30);
            this.ckSavePass.TabIndex = 2;
            this.ckSavePass.Text = "Nhớ mật khẩu của tôi trên máy này";
            // 
            // txtuserName
            // 
            this.txtuserName.Location = new System.Drawing.Point(120, 74);
            this.txtuserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(239, 25);
            this.txtuserName.TabIndex = 3;
            this.txtuserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuserName_KeyPress);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(120, 113);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(239, 25);
            this.txtPass.TabIndex = 4;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.ForeColor = System.Drawing.Color.Red;
            this.lbFail.Location = new System.Drawing.Point(8, 227);
            this.lbFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(224, 17);
            this.lbFail.TabIndex = 7;
            this.lbFail.Text = "(*) Sai tên đăng nhập hoặc mật khẩu";
            this.lbFail.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(17, 74);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "Tên Đăng Nhập";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(17, 113);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(83, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(405, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbFail);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.ckSavePass);
            this.Controls.Add(this.bt_huy);
            this.Controls.Add(this.bt_Login);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bt_Login;
        private DevComponents.DotNetBar.ButtonX bt_huy;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckSavePass;
        private System.Windows.Forms.TextBox txtuserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbFail;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label label1;


    }
}