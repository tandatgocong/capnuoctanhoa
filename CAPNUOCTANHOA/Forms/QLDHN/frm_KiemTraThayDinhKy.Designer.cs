﻿namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class frm_KiemTraThayDinhKy
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btXemThongTin = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbHieuDongHo = new System.Windows.Forms.ComboBox();
            this.dateTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cbCoDH = new System.Windows.Forms.ComboBox();
            this.checHieu = new System.Windows.Forms.CheckBox();
            this.ckNgayThay = new System.Windows.Forms.CheckBox();
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.checkChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DANHBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hieudh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYGAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dafaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btXemThongTin);
            this.splitContainer1.Panel1.Controls.Add(this.labelX4);
            this.splitContainer1.Panel1.Controls.Add(this.cbHieuDongHo);
            this.splitContainer1.Panel1.Controls.Add(this.dateTime);
            this.splitContainer1.Panel1.Controls.Add(this.cbCoDH);
            this.splitContainer1.Panel1.Controls.Add(this.checHieu);
            this.splitContainer1.Panel1.Controls.Add(this.ckNgayThay);
            this.splitContainer1.Panel1.Controls.Add(this.title);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 657);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelX1.Location = new System.Drawing.Point(42, 65);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(61, 22);
            this.labelX1.TabIndex = 104;
            this.labelX1.Text = "CỠ ĐH";
            // 
            // btXemThongTin
            // 
            this.btXemThongTin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXemThongTin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXemThongTin.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemThongTin.ForeColor = System.Drawing.Color.Crimson;
            this.btXemThongTin.Location = new System.Drawing.Point(520, 90);
            this.btXemThongTin.Name = "btXemThongTin";
            this.btXemThongTin.Size = new System.Drawing.Size(157, 27);
            this.btXemThongTin.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXemThongTin.TabIndex = 103;
            this.btXemThongTin.Text = "XEM THÔNG TIN";
            this.btXemThongTin.Click += new System.EventHandler(this.btXemThongTin_Click);
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Wingdings 2", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelX4.Location = new System.Drawing.Point(211, 34);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(126, 26);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "";
            // 
            // cbHieuDongHo
            // 
            this.cbHieuDongHo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHieuDongHo.DropDownWidth = 130;
            this.cbHieuDongHo.FormattingEnabled = true;
            this.cbHieuDongHo.Location = new System.Drawing.Point(366, 90);
            this.cbHieuDongHo.Name = "cbHieuDongHo";
            this.cbHieuDongHo.Size = new System.Drawing.Size(118, 27);
            this.cbHieuDongHo.TabIndex = 8;
            // 
            // dateTime
            // 
            // 
            // 
            // 
            this.dateTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTime.ButtonDropDown.Visible = true;
            this.dateTime.CustomFormat = "dd/MM/yyyy";
            this.dateTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(176, 90);
            // 
            // 
            // 
            this.dateTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTime.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.dateTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTime.MonthCalendar.TodayButtonVisible = true;
            this.dateTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(126, 27);
            this.dateTime.TabIndex = 7;
            this.dateTime.Value = new System.DateTime(2012, 3, 1, 22, 34, 31, 0);
            // 
            // cbCoDH
            // 
            this.cbCoDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoDH.FormattingEnabled = true;
            this.cbCoDH.Items.AddRange(new object[] {
            "<= 25 Ly",
            ">= 25 Ly"});
            this.cbCoDH.Location = new System.Drawing.Point(35, 90);
            this.cbCoDH.Name = "cbCoDH";
            this.cbCoDH.Size = new System.Drawing.Size(117, 27);
            this.cbCoDH.TabIndex = 6;
            // 
            // checHieu
            // 
            this.checHieu.AutoSize = true;
            this.checHieu.Location = new System.Drawing.Point(366, 64);
            this.checHieu.Name = "checHieu";
            this.checHieu.Size = new System.Drawing.Size(127, 23);
            this.checHieu.TabIndex = 5;
            this.checHieu.Text = "Theo Hiệu ĐH";
            this.checHieu.UseVisualStyleBackColor = true;
            // 
            // ckNgayThay
            // 
            this.ckNgayThay.AutoSize = true;
            this.ckNgayThay.Location = new System.Drawing.Point(176, 64);
            this.ckNgayThay.Name = "ckNgayThay";
            this.ckNgayThay.Size = new System.Drawing.Size(160, 23);
            this.ckNgayThay.TabIndex = 5;
            this.ckNgayThay.Text = "Ngày Thay Định Kỳ";
            this.ckNgayThay.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(26, -3);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(1064, 70);
            this.title.TabIndex = 2;
            this.title.Text = "THỐNG KÊ ĐỒNG HỒ BÁO THAY";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkChon,
            this.MLT,
            this.G_DANHBO,
            this.HOTEN,
            this.DIACHI,
            this.hieudh,
            this.CODHN,
            this.NGAYGAN});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 30;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(1238, 530);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseClick);
            // 
            // checkChon
            // 
            this.checkChon.HeaderText = "CHỌN";
            this.checkChon.Name = "checkChon";
            this.checkChon.Width = 60;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MLT.DefaultCellStyle = dataGridViewCellStyle2;
            this.MLT.HeaderText = "MÃ LỘ TRÌNH";
            this.MLT.Name = "MLT";
            this.MLT.Width = 150;
            // 
            // G_DANHBO
            // 
            this.G_DANHBO.DataPropertyName = "DANHBO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_DANHBO.DefaultCellStyle = dataGridViewCellStyle3;
            this.G_DANHBO.HeaderText = "DANH BỘ";
            this.G_DANHBO.Name = "G_DANHBO";
            this.G_DANHBO.Width = 150;
            // 
            // HOTEN
            // 
            this.HOTEN.DataPropertyName = "HOTEN";
            this.HOTEN.HeaderText = "HỌ TÊN";
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Width = 230;
            // 
            // DIACHI
            // 
            this.DIACHI.DataPropertyName = "DIACHI";
            this.DIACHI.HeaderText = "ĐỊA CHỈ";
            this.DIACHI.Name = "DIACHI";
            this.DIACHI.Width = 270;
            // 
            // hieudh
            // 
            this.hieudh.DataPropertyName = "HIEUDH";
            this.hieudh.HeaderText = "HIỆU ĐH";
            this.hieudh.Name = "hieudh";
            this.hieudh.Width = 150;
            // 
            // CODHN
            // 
            this.CODHN.DataPropertyName = "CODH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODHN.DefaultCellStyle = dataGridViewCellStyle4;
            this.CODHN.HeaderText = "CỠ";
            this.CODHN.Name = "CODHN";
            this.CODHN.Width = 60;
            // 
            // NGAYGAN
            // 
            this.NGAYGAN.DataPropertyName = "NGAYTHAY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.NGAYGAN.DefaultCellStyle = dataGridViewCellStyle5;
            this.NGAYGAN.HeaderText = "NGÀY GẮN";
            this.NGAYGAN.Name = "NGAYGAN";
            this.NGAYGAN.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dafaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
            // 
            // dafaToolStripMenuItem
            // 
            this.dafaToolStripMenuItem.Name = "dafaToolStripMenuItem";
            this.dafaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.dafaToolStripMenuItem.Text = "Tạo Mới Bảng Kê";
            this.dafaToolStripMenuItem.Click += new System.EventHandler(this.dafaToolStripMenuItem_Click);
            // 
            // frm_KiemTraThayDinhKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_KiemTraThayDinhKy";
            this.Size = new System.Drawing.Size(1238, 657);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private System.Windows.Forms.CheckBox ckNgayThay;
        private System.Windows.Forms.ComboBox cbCoDH;
        private System.Windows.Forms.CheckBox checHieu;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTime;
        private System.Windows.Forms.ComboBox cbHieuDongHo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.DataGridView dataGrid;
        private DevComponents.DotNetBar.ButtonX btXemThongTin;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn hieudh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYGAN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dafaToolStripMenuItem;
    }
}
