namespace CAPNUOCTANHOA.Forms.DoiTCTB.Tab
{
    partial class tabThongKeVatTu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtSoBangKe = new System.Windows.Forms.RichTextBox();
            this.btXemVatTu = new DevComponents.DotNetBar.ButtonX();
            this.dataVATTU = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_MAVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_TENVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_TONGSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_GHICHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTongDHN = new System.Windows.Forms.Label();
            this.lbTongTroNgai = new System.Windows.Forms.Label();
            this.lbTongDHNThay = new System.Windows.Forms.Label();
            this.btInBCThay = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVATTU)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelX1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoBangKe);
            this.splitContainer1.Panel1.Controls.Add(this.btXemVatTu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btInBCThay);
            this.splitContainer1.Panel2.Controls.Add(this.lbTongDHNThay);
            this.splitContainer1.Panel2.Controls.Add(this.lbTongTroNgai);
            this.splitContainer1.Panel2.Controls.Add(this.lbTongDHN);
            this.splitContainer1.Panel2.Controls.Add(this.dataVATTU);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 614);
            this.splitContainer1.SplitterDistance = 67;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(88, 55);
            this.labelX1.TabIndex = 105;
            this.labelX1.Text = "SỐ \r\nBẢNG KÊ";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtSoBangKe
            // 
            this.txtSoBangKe.Location = new System.Drawing.Point(97, 3);
            this.txtSoBangKe.Name = "txtSoBangKe";
            this.txtSoBangKe.Size = new System.Drawing.Size(649, 55);
            this.txtSoBangKe.TabIndex = 104;
            this.txtSoBangKe.Text = "";
            // 
            // btXemVatTu
            // 
            this.btXemVatTu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXemVatTu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXemVatTu.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemVatTu.ForeColor = System.Drawing.Color.Crimson;
            this.btXemVatTu.Location = new System.Drawing.Point(752, 3);
            this.btXemVatTu.Name = "btXemVatTu";
            this.btXemVatTu.Size = new System.Drawing.Size(150, 23);
            this.btXemVatTu.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXemVatTu.TabIndex = 103;
            this.btXemVatTu.Text = "XEM THÔNG TIN";
            this.btXemVatTu.Click += new System.EventHandler(this.btXemVatTu_Click);
            // 
            // dataVATTU
            // 
            this.dataVATTU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVATTU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataVATTU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVATTU.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.G_MAVT,
            this.G_TENVT,
            this.G_DVT,
            this.G_TONGSL,
            this.G_GHICHU});
            this.dataVATTU.Location = new System.Drawing.Point(97, 74);
            this.dataVATTU.Name = "dataVATTU";
            this.dataVATTU.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVATTU.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataVATTU.RowHeadersWidth = 20;
            this.dataVATTU.Size = new System.Drawing.Size(805, 466);
            this.dataVATTU.TabIndex = 0;
            this.dataVATTU.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataVATTU_ColumnHeaderMouseClick);
            // 
            // STT
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle17;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 60;
            // 
            // G_MAVT
            // 
            this.G_MAVT.DataPropertyName = "MAVT";
            this.G_MAVT.HeaderText = "MÃ VẬT TƯ";
            this.G_MAVT.Name = "G_MAVT";
            this.G_MAVT.Width = 120;
            // 
            // G_TENVT
            // 
            this.G_TENVT.DataPropertyName = "TENVT";
            this.G_TENVT.HeaderText = "TÊN VẬT TƯ";
            this.G_TENVT.Name = "G_TENVT";
            this.G_TENVT.Width = 250;
            // 
            // G_DVT
            // 
            this.G_DVT.DataPropertyName = "DVT";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_DVT.DefaultCellStyle = dataGridViewCellStyle18;
            this.G_DVT.HeaderText = "ĐVT";
            this.G_DVT.Name = "G_DVT";
            this.G_DVT.Width = 90;
            // 
            // G_TONGSL
            // 
            this.G_TONGSL.DataPropertyName = "TONGSL";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.G_TONGSL.DefaultCellStyle = dataGridViewCellStyle19;
            this.G_TONGSL.HeaderText = "TỔNG SL";
            this.G_TONGSL.Name = "G_TONGSL";
            this.G_TONGSL.Width = 110;
            // 
            // G_GHICHU
            // 
            this.G_GHICHU.HeaderText = "GHI CHÚ";
            this.G_GHICHU.Name = "G_GHICHU";
            this.G_GHICHU.Width = 150;
            // 
            // lbTongDHN
            // 
            this.lbTongDHN.AutoSize = true;
            this.lbTongDHN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDHN.Location = new System.Drawing.Point(93, 0);
            this.lbTongDHN.Name = "lbTongDHN";
            this.lbTongDHN.Size = new System.Drawing.Size(384, 19);
            this.lbTongDHN.TabIndex = 1;
            this.lbTongDHN.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC YÊU CẦU THAY            0";
            // 
            // lbTongTroNgai
            // 
            this.lbTongTroNgai.AutoSize = true;
            this.lbTongTroNgai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTroNgai.Location = new System.Drawing.Point(93, 23);
            this.lbTongTroNgai.Name = "lbTongTroNgai";
            this.lbTongTroNgai.Size = new System.Drawing.Size(384, 19);
            this.lbTongTroNgai.TabIndex = 1;
            this.lbTongTroNgai.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC TRỞ NGẠI THAY         0";
            // 
            // lbTongDHNThay
            // 
            this.lbTongDHNThay.AutoSize = true;
            this.lbTongDHNThay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDHNThay.Location = new System.Drawing.Point(93, 48);
            this.lbTongDHNThay.Name = "lbTongDHNThay";
            this.lbTongDHNThay.Size = new System.Drawing.Size(384, 19);
            this.lbTongDHNThay.TabIndex = 2;
            this.lbTongDHNThay.Text = "TỔNG SỐ ĐỒNG HỒ NƯỚC ĐÃ THAY                       0";
            // 
            // btInBCThay
            // 
            this.btInBCThay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btInBCThay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btInBCThay.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInBCThay.ForeColor = System.Drawing.Color.Blue;
            this.btInBCThay.Location = new System.Drawing.Point(752, 44);
            this.btInBCThay.Name = "btInBCThay";
            this.btInBCThay.Size = new System.Drawing.Size(150, 23);
            this.btInBCThay.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btInBCThay.TabIndex = 104;
            this.btInBCThay.Text = "IN BÁO CÁO";
            this.btInBCThay.Click += new System.EventHandler(this.btInBCThay_Click);
            // 
            // tabThongKeVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tabThongKeVatTu";
            this.Size = new System.Drawing.Size(1030, 614);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataVATTU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.ButtonX btXemVatTu;
        private System.Windows.Forms.RichTextBox txtSoBangKe;
        private System.Windows.Forms.DataGridView dataVATTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_MAVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_TENVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_TONGSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_GHICHU;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label lbTongDHN;
        private System.Windows.Forms.Label lbTongTroNgai;
        private System.Windows.Forms.Label lbTongDHNThay;
        private DevComponents.DotNetBar.ButtonX btInBCThay;
    }
}
