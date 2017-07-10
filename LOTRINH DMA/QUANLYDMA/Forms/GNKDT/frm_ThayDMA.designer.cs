namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class frm_ThayDMA
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btCapNhatThongTin = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dataBangKe = new System.Windows.Forms.DataGridView();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.lbTong = new DevComponents.DotNetBar.LabelX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MADMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).BeginInit();
            this.SuspendLayout();
            // 
            // btCapNhatThongTin
            // 
            this.btCapNhatThongTin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCapNhatThongTin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCapNhatThongTin.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhatThongTin.ForeColor = System.Drawing.Color.Crimson;
            this.btCapNhatThongTin.Location = new System.Drawing.Point(429, 18);
            this.btCapNhatThongTin.Name = "btCapNhatThongTin";
            this.btCapNhatThongTin.Size = new System.Drawing.Size(175, 26);
            this.btCapNhatThongTin.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btCapNhatThongTin.TabIndex = 23;
            this.btCapNhatThongTin.Text = "XEM THÔNG TIN";
            this.btCapNhatThongTin.Click += new System.EventHandler(this.btCapNhatThongTin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(362, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 105;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.ForeColor = System.Drawing.Color.Crimson;
            this.buttonX3.Location = new System.Drawing.Point(32, 52);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(1193, 5);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.buttonX3.TabIndex = 108;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(117, 19);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(100, 27);
            this.dateTuNgay.TabIndex = 111;
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(302, 18);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(100, 27);
            this.dateDenNgay.TabIndex = 112;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(223, 19);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 109;
            this.labelX4.Text = "Đến Ngày";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(58, 19);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 110;
            this.labelX3.Text = "Từ Ngày";
            // 
            // dataBangKe
            // 
            this.dataBangKe.AllowUserToAddRows = false;
            this.dataBangKe.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataBangKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBangKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataBangKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBangKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MADMA,
            this.SOLUONG});
            this.dataBangKe.Location = new System.Drawing.Point(58, 63);
            this.dataBangKe.MultiSelect = false;
            this.dataBangKe.Name = "dataBangKe";
            this.dataBangKe.ReadOnly = true;
            this.dataBangKe.RowHeadersWidth = 20;
            this.dataBangKe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataBangKe.RowTemplate.Height = 20;
            this.dataBangKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBangKe.Size = new System.Drawing.Size(356, 512);
            this.dataBangKe.TabIndex = 113;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.Color.Crimson;
            this.buttonX1.Location = new System.Drawing.Point(429, 72);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(175, 26);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.buttonX1.TabIndex = 114;
            this.buttonX1.Text = "XUẤT FILE";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // lbTong
            // 
            this.lbTong.Location = new System.Drawing.Point(429, 552);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(75, 23);
            this.lbTong.TabIndex = 110;
            this.lbTong.Text = "Từ Ngày";
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // MADMA
            // 
            this.MADMA.DataPropertyName = "MADMA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MADMA.DefaultCellStyle = dataGridViewCellStyle3;
            this.MADMA.HeaderText = "MÃ DMA";
            this.MADMA.Name = "MADMA";
            this.MADMA.ReadOnly = true;
            this.MADMA.Width = 120;
            // 
            // SOLUONG
            // 
            this.SOLUONG.DataPropertyName = "SOLUONG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SOLUONG.DefaultCellStyle = dataGridViewCellStyle4;
            this.SOLUONG.HeaderText = "SỐ LƯỢNG";
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.ReadOnly = true;
            this.SOLUONG.Width = 130;
            // 
            // frm_ThayDMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dataBangKe);
            this.Controls.Add(this.dateTuNgay);
            this.Controls.Add(this.dateDenNgay);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCapNhatThongTin);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_ThayDMA";
            this.Size = new System.Drawing.Size(1238, 629);
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btCapNhatThongTin;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridView dataBangKe;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX lbTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MADMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
    }
}
