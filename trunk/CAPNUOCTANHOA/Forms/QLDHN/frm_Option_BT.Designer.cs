namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class frm_Option_BT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbLoaiBangKe = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.dataBangKe = new System.Windows.Forms.DataGridView();
            this.ID_BAOTHAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_LOAIBANGKE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_SOBANGKE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DANHBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_TENKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_HIEUDHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_CODHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_SOTHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_CHISO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_LYDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_NGAYBAOTHAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_NGAYGAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_CHITHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_CHIGOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLoaiBangKe
            // 
            this.cbLoaiBangKe.BackColor = System.Drawing.SystemColors.Window;
            this.cbLoaiBangKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBangKe.ForeColor = System.Drawing.Color.Blue;
            this.cbLoaiBangKe.FormattingEnabled = true;
            this.cbLoaiBangKe.Items.AddRange(new object[] {
            "GGF",
            "SGF",
            "SGFDSGF\'DS",
            "GFD",
            "SGF",
            "DSGF"});
            this.cbLoaiBangKe.Location = new System.Drawing.Point(150, 65);
            this.cbLoaiBangKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLoaiBangKe.Name = "cbLoaiBangKe";
            this.cbLoaiBangKe.Size = new System.Drawing.Size(235, 21);
            this.cbLoaiBangKe.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(13, 65);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(139, 22);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "LOẠI BẢNG KÊ";
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Wingdings 2", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelX4.Location = new System.Drawing.Point(210, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(126, 26);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "";
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(13, 3);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(488, 58);
            this.title.TabIndex = 4;
            this.title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC";
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
            this.ID_BAOTHAY,
            this.DHN_LOAIBANGKE,
            this.DHN_SOBANGKE,
            this.DHN_STT,
            this.G_DANHBO,
            this.G_TENKH,
            this.G_DIACHI,
            this.G_HIEUDHN,
            this.G_CODHN,
            this.G_SOTHAN,
            this.G_CHISO,
            this.G_LYDO,
            this.DHN_NGAYBAOTHAY,
            this.DHN_NGAYGAN,
            this.DHN_CHITHAN,
            this.DHN_CHIGOC});
            this.dataBangKe.Location = new System.Drawing.Point(12, 98);
            this.dataBangKe.MultiSelect = false;
            this.dataBangKe.Name = "dataBangKe";
            this.dataBangKe.ReadOnly = true;
            this.dataBangKe.RowHeadersWidth = 20;
            this.dataBangKe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataBangKe.RowTemplate.Height = 28;
            this.dataBangKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBangKe.Size = new System.Drawing.Size(1214, 340);
            this.dataBangKe.TabIndex = 101;
            // 
            // ID_BAOTHAY
            // 
            this.ID_BAOTHAY.DataPropertyName = "ID_BAOTHAY";
            this.ID_BAOTHAY.HeaderText = "ID_BAOTHAY";
            this.ID_BAOTHAY.Name = "ID_BAOTHAY";
            this.ID_BAOTHAY.ReadOnly = true;
            this.ID_BAOTHAY.Visible = false;
            // 
            // DHN_LOAIBANGKE
            // 
            this.DHN_LOAIBANGKE.DataPropertyName = "DHN_LOAIBANGKE";
            this.DHN_LOAIBANGKE.HeaderText = "DHN_LOAIBANGKE";
            this.DHN_LOAIBANGKE.Name = "DHN_LOAIBANGKE";
            this.DHN_LOAIBANGKE.ReadOnly = true;
            this.DHN_LOAIBANGKE.Visible = false;
            // 
            // DHN_SOBANGKE
            // 
            this.DHN_SOBANGKE.DataPropertyName = "DHN_SOBANGKE";
            this.DHN_SOBANGKE.HeaderText = "DHN_SOBANGKE";
            this.DHN_SOBANGKE.Name = "DHN_SOBANGKE";
            this.DHN_SOBANGKE.ReadOnly = true;
            this.DHN_SOBANGKE.Visible = false;
            // 
            // DHN_STT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DHN_STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.DHN_STT.HeaderText = "STT";
            this.DHN_STT.Name = "DHN_STT";
            this.DHN_STT.ReadOnly = true;
            this.DHN_STT.Width = 40;
            // 
            // G_DANHBO
            // 
            this.G_DANHBO.DataPropertyName = "DHN_DANHBO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_DANHBO.DefaultCellStyle = dataGridViewCellStyle3;
            this.G_DANHBO.HeaderText = "DANH BỘ";
            this.G_DANHBO.Name = "G_DANHBO";
            this.G_DANHBO.ReadOnly = true;
            this.G_DANHBO.Width = 130;
            // 
            // G_TENKH
            // 
            this.G_TENKH.DataPropertyName = "HOTEN";
            this.G_TENKH.HeaderText = "TÊN KHÁCH HÀNG";
            this.G_TENKH.Name = "G_TENKH";
            this.G_TENKH.ReadOnly = true;
            this.G_TENKH.Width = 200;
            // 
            // G_DIACHI
            // 
            this.G_DIACHI.DataPropertyName = "DIACHI";
            this.G_DIACHI.HeaderText = "ĐỊA CHỈ";
            this.G_DIACHI.Name = "G_DIACHI";
            this.G_DIACHI.ReadOnly = true;
            this.G_DIACHI.Width = 270;
            // 
            // G_HIEUDHN
            // 
            this.G_HIEUDHN.DataPropertyName = "DHN_HIEUDHN";
            this.G_HIEUDHN.HeaderText = "HIỆU ĐH";
            this.G_HIEUDHN.Name = "G_HIEUDHN";
            this.G_HIEUDHN.ReadOnly = true;
            this.G_HIEUDHN.Width = 130;
            // 
            // G_CODHN
            // 
            this.G_CODHN.DataPropertyName = "DHN_CODH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_CODHN.DefaultCellStyle = dataGridViewCellStyle4;
            this.G_CODHN.HeaderText = "CỠ";
            this.G_CODHN.Name = "G_CODHN";
            this.G_CODHN.ReadOnly = true;
            this.G_CODHN.Width = 50;
            // 
            // G_SOTHAN
            // 
            this.G_SOTHAN.DataPropertyName = "DHN_SOTHAN";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_SOTHAN.DefaultCellStyle = dataGridViewCellStyle5;
            this.G_SOTHAN.HeaderText = "SỐ THÂN";
            this.G_SOTHAN.Name = "G_SOTHAN";
            this.G_SOTHAN.ReadOnly = true;
            this.G_SOTHAN.Width = 130;
            // 
            // G_CHISO
            // 
            this.G_CHISO.DataPropertyName = "DHN_CHISO";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_CHISO.DefaultCellStyle = dataGridViewCellStyle6;
            this.G_CHISO.HeaderText = "CHỈ SỐ";
            this.G_CHISO.Name = "G_CHISO";
            this.G_CHISO.ReadOnly = true;
            this.G_CHISO.Width = 90;
            // 
            // G_LYDO
            // 
            this.G_LYDO.DataPropertyName = "DHN_LYDOTHAY";
            this.G_LYDO.HeaderText = "LÝ DO";
            this.G_LYDO.Name = "G_LYDO";
            this.G_LYDO.ReadOnly = true;
            this.G_LYDO.Width = 150;
            // 
            // DHN_NGAYBAOTHAY
            // 
            this.DHN_NGAYBAOTHAY.DataPropertyName = "DHN_NGAYBAOTHAY";
            this.DHN_NGAYBAOTHAY.HeaderText = "DHN_NGAYBAOTHAY";
            this.DHN_NGAYBAOTHAY.Name = "DHN_NGAYBAOTHAY";
            this.DHN_NGAYBAOTHAY.ReadOnly = true;
            this.DHN_NGAYBAOTHAY.Visible = false;
            // 
            // DHN_NGAYGAN
            // 
            this.DHN_NGAYGAN.DataPropertyName = "DHN_NGAYGAN";
            this.DHN_NGAYGAN.HeaderText = "DHN_NGAYGAN";
            this.DHN_NGAYGAN.Name = "DHN_NGAYGAN";
            this.DHN_NGAYGAN.ReadOnly = true;
            this.DHN_NGAYGAN.Visible = false;
            // 
            // DHN_CHITHAN
            // 
            this.DHN_CHITHAN.DataPropertyName = "DHN_CHITHAN";
            this.DHN_CHITHAN.HeaderText = "DHN_CHITHAN";
            this.DHN_CHITHAN.Name = "DHN_CHITHAN";
            this.DHN_CHITHAN.ReadOnly = true;
            this.DHN_CHITHAN.Visible = false;
            // 
            // DHN_CHIGOC
            // 
            this.DHN_CHIGOC.DataPropertyName = "DHN_CHIGOC";
            this.DHN_CHIGOC.HeaderText = "DHN_CHIGOC";
            this.DHN_CHIGOC.Name = "DHN_CHIGOC";
            this.DHN_CHIGOC.ReadOnly = true;
            this.DHN_CHIGOC.Visible = false;
            // 
            // frm_Option_BT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 500);
            this.Controls.Add(this.dataBangKe);
            this.Controls.Add(this.cbLoaiBangKe);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.title);
            this.Name = "frm_Option_BT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Báo Thay";
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLoaiBangKe;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private System.Windows.Forms.DataGridView dataBangKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_BAOTHAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_LOAIBANGKE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_SOBANGKE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_TENKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_HIEUDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CODHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_SOTHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CHISO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_LYDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_NGAYBAOTHAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_NGAYGAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_CHITHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_CHIGOC;

    }
}