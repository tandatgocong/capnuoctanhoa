namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class frm_GetDataGanMoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbDotBangKe = new System.Windows.Forms.ComboBox();
            this.btThem = new DevComponents.DotNetBar.ButtonX();
            this.dataGanMoiBK = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DANHBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOPDONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANPHONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTH = new System.Windows.Forms.DataGridView();
            this.TH_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TH_DANHBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TH_HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.next = new System.Windows.Forms.PictureBox();
            this.tungdot = new System.Windows.Forms.PictureBox();
            this.tatCa = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGanMoiBK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungdot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tatCa)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(4, -4);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(704, 62);
            this.title.TabIndex = 2;
            this.title.Text = "LẤY DỮ LIỆU GẮN MỚI";
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(4, 51);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(126, 25);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "ĐỢT BẢNG KÊ";
            // 
            // cbDotBangKe
            // 
            this.cbDotBangKe.DropDownHeight = 150;
            this.cbDotBangKe.Font = new System.Drawing.Font("VNI-Times", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDotBangKe.FormattingEnabled = true;
            this.cbDotBangKe.IntegralHeight = false;
            this.cbDotBangKe.Location = new System.Drawing.Point(127, 51);
            this.cbDotBangKe.Name = "cbDotBangKe";
            this.cbDotBangKe.Size = new System.Drawing.Size(217, 30);
            this.cbDotBangKe.TabIndex = 5;
            // 
            // btThem
            // 
            this.btThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.Crimson;
            this.btThem.Location = new System.Drawing.Point(350, 51);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(136, 27);
            this.btThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btThem.TabIndex = 16;
            this.btThem.Text = "LẤY DỮ LIỆU";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // dataGanMoiBK
            // 
            this.dataGanMoiBK.AllowUserToAddRows = false;
            this.dataGanMoiBK.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGanMoiBK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGanMoiBK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGanMoiBK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.DANHBO,
            this.HOPDONG,
            this.HOTEN,
            this.DIACHI,
            this.QUANPHONG});
            this.dataGanMoiBK.Location = new System.Drawing.Point(13, 84);
            this.dataGanMoiBK.Name = "dataGanMoiBK";
            this.dataGanMoiBK.RowHeadersWidth = 30;
            this.dataGanMoiBK.Size = new System.Drawing.Size(812, 527);
            this.dataGanMoiBK.TabIndex = 17;
            // 
            // STT
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle1;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // DANHBO
            // 
            this.DANHBO.DataPropertyName = "danhbo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DANHBO.DefaultCellStyle = dataGridViewCellStyle2;
            this.DANHBO.HeaderText = "DANH BỘ";
            this.DANHBO.Name = "DANHBO";
            this.DANHBO.Width = 125;
            // 
            // HOPDONG
            // 
            this.HOPDONG.DataPropertyName = "hopdong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HOPDONG.DefaultCellStyle = dataGridViewCellStyle3;
            this.HOPDONG.HeaderText = "HỢP ĐỒNG";
            this.HOPDONG.Name = "HOPDONG";
            this.HOPDONG.Width = 120;
            // 
            // HOTEN
            // 
            this.HOTEN.DataPropertyName = "HoTen";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("VNI-Times", 12F);
            this.HOTEN.DefaultCellStyle = dataGridViewCellStyle4;
            this.HOTEN.HeaderText = "HỌ TÊN";
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Width = 200;
            // 
            // DIACHI
            // 
            this.DIACHI.DataPropertyName = "DiaChi";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("VNI-Times", 12F);
            this.DIACHI.DefaultCellStyle = dataGridViewCellStyle5;
            this.DIACHI.HeaderText = "ĐỊA CHỈ";
            this.DIACHI.Name = "DIACHI";
            this.DIACHI.Width = 200;
            // 
            // QUANPHONG
            // 
            this.QUANPHONG.DataPropertyName = "maPQ";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("VNI-Times", 12F);
            this.QUANPHONG.DefaultCellStyle = dataGridViewCellStyle6;
            this.QUANPHONG.HeaderText = "MÃ QP";
            this.QUANPHONG.Name = "QUANPHONG";
            this.QUANPHONG.Width = 85;
            // 
            // dataGridViewTH
            // 
            this.dataGridViewTH.AllowUserToAddRows = false;
            this.dataGridViewTH.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewTH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TH_STT,
            this.TH_DANHBO,
            this.TH_HOTEN});
            this.dataGridViewTH.Location = new System.Drawing.Point(885, 84);
            this.dataGridViewTH.Name = "dataGridViewTH";
            this.dataGridViewTH.RowHeadersWidth = 20;
            this.dataGridViewTH.Size = new System.Drawing.Size(350, 527);
            this.dataGridViewTH.TabIndex = 18;
            // 
            // TH_STT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TH_STT.DefaultCellStyle = dataGridViewCellStyle7;
            this.TH_STT.HeaderText = "STT";
            this.TH_STT.Name = "TH_STT";
            this.TH_STT.Width = 50;
            // 
            // TH_DANHBO
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TH_DANHBO.DefaultCellStyle = dataGridViewCellStyle8;
            this.TH_DANHBO.HeaderText = "DANH BỘ";
            this.TH_DANHBO.Name = "TH_DANHBO";
            this.TH_DANHBO.Width = 125;
            // 
            // TH_HOTEN
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("VNI-Times", 12F);
            this.TH_HOTEN.DefaultCellStyle = dataGridViewCellStyle9;
            this.TH_HOTEN.HeaderText = "HỌ TÊN";
            this.TH_HOTEN.Name = "TH_HOTEN";
            this.TH_HOTEN.Width = 200;
            // 
            // next
            // 
            this.next.Image = global::CAPNUOCTANHOA.Properties.Resources.Arrow2_Right;
            this.next.Location = new System.Drawing.Point(830, 266);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(49, 50);
            this.next.TabIndex = 19;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // tungdot
            // 
            this.tungdot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tungdot.Image = global::CAPNUOCTANHOA.Properties.Resources.Excel;
            this.tungdot.Location = new System.Drawing.Point(794, 48);
            this.tungdot.Name = "tungdot";
            this.tungdot.Size = new System.Drawing.Size(31, 30);
            this.tungdot.TabIndex = 20;
            this.tungdot.TabStop = false;
            this.tungdot.Click += new System.EventHandler(this.tungdot_Click);
            // 
            // tatCa
            // 
            this.tatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tatCa.Image = global::CAPNUOCTANHOA.Properties.Resources.Excel;
            this.tatCa.Location = new System.Drawing.Point(1204, 48);
            this.tatCa.Name = "tatCa";
            this.tatCa.Size = new System.Drawing.Size(31, 30);
            this.tatCa.TabIndex = 21;
            this.tatCa.TabStop = false;
            this.tatCa.Click += new System.EventHandler(this.tatCa_Click);
            // 
            // frm_GetDataGanMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.tungdot);
            this.Controls.Add(this.next);
            this.Controls.Add(this.dataGridViewTH);
            this.Controls.Add(this.dataGanMoiBK);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cbDotBangKe);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tatCa);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_GetDataGanMoi";
            this.Size = new System.Drawing.Size(1238, 624);
            ((System.ComponentModel.ISupportInitialize)(this.dataGanMoiBK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungdot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tatCa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cbDotBangKe;
        private DevComponents.DotNetBar.ButtonX btThem;
        private System.Windows.Forms.DataGridView dataGanMoiBK;
        private System.Windows.Forms.DataGridView dataGridViewTH;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.PictureBox tungdot;
        private System.Windows.Forms.PictureBox tatCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOPDONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANPHONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TH_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TH_DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TH_HOTEN;
    }
}
