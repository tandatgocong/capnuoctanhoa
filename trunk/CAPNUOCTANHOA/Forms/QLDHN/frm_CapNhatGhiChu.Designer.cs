namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class frm_CapNhatGhiChu
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
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.txtSoDanhBo = new System.Windows.Forms.MaskedTextBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btCapNhat = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(17, 5);
            this.title.Margin = new System.Windows.Forms.Padding(7);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(1004, 52);
            this.title.TabIndex = 3;
            this.title.Text = "CẬP NHẬT KẾT QUẢ XỬ LÝ TRỞ NGẠI THAY";
            // 
            // txtSoDanhBo
            // 
            this.txtSoDanhBo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoDanhBo.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDanhBo.ForeColor = System.Drawing.Color.Red;
            this.txtSoDanhBo.Location = new System.Drawing.Point(153, 68);
            this.txtSoDanhBo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoDanhBo.Mask = "0000-000-0000";
            this.txtSoDanhBo.Name = "txtSoDanhBo";
            this.txtSoDanhBo.Size = new System.Drawing.Size(157, 27);
            this.txtSoDanhBo.TabIndex = 107;
            this.txtSoDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.labelX5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX5.Location = new System.Drawing.Point(33, 68);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(137, 32);
            this.labelX5.TabIndex = 104;
            this.labelX5.Text = "SỐ DANH BỘ";
            // 
            // btCapNhat
            // 
            this.btCapNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCapNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCapNhat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btCapNhat.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.ForeColor = System.Drawing.Color.Crimson;
            this.btCapNhat.Location = new System.Drawing.Point(153, 280);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(135, 27);
            this.btCapNhat.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btCapNhat.TabIndex = 123;
            this.btCapNhat.Text = "CẬP NHẬT";
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(33, 108);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(137, 32);
            this.labelX1.TabIndex = 124;
            this.labelX1.Text = "NỘI DUNG";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(153, 113);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(417, 147);
            this.txtGhiChu.TabIndex = 127;
            this.txtGhiChu.Text = "";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.Color.Crimson;
            this.buttonX1.Location = new System.Drawing.Point(306, 280);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(135, 27);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.buttonX1.TabIndex = 128;
            this.buttonX1.Text = "THOÁT";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frm_CapNhatGhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(607, 346);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.txtSoDanhBo);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.title);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_CapNhatGhiChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập Nhật Kết Quả Xử Lý Trở Ngại Thay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private System.Windows.Forms.MaskedTextBox txtSoDanhBo;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX btCapNhat;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}