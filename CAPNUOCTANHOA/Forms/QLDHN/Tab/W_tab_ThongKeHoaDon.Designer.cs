namespace CAPNUOCTANHOA.Forms.QLDHN.Tab
{
    partial class W_tab_ThongKeHoaDon
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btXoa = new DevComponents.DotNetBar.ButtonX();
            this.btNhap = new DevComponents.DotNetBar.ButtonX();
            this.txtNgayGan = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbKyDS = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.comboItem16 = new DevComponents.Editors.ComboItem();
            this.comboItem17 = new DevComponents.Editors.ComboItem();
            this.comboItem18 = new DevComponents.Editors.ComboItem();
            this.comboItem19 = new DevComponents.Editors.ComboItem();
            this.comboItem20 = new DevComponents.Editors.ComboItem();
            this.comboItem21 = new DevComponents.Editors.ComboItem();
            this.comboItem22 = new DevComponents.Editors.ComboItem();
            this.comboItem23 = new DevComponents.Editors.ComboItem();
            this.comboItem24 = new DevComponents.Editors.ComboItem();
            this.txtNam = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSoKy = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DANHBA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayGan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btXoa);
            this.splitContainer1.Panel1.Controls.Add(this.btNhap);
            this.splitContainer1.Panel1.Controls.Add(this.txtNgayGan);
            this.splitContainer1.Panel1.Controls.Add(this.labelX7);
            this.splitContainer1.Panel1.Controls.Add(this.cbKyDS);
            this.splitContainer1.Panel1.Controls.Add(this.txtNam);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoKy);
            this.splitContainer1.Panel1.Controls.Add(this.labelX3);
            this.splitContainer1.Panel1.Controls.Add(this.labelX2);
            this.splitContainer1.Panel1.Controls.Add(this.labelX1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 630);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 1;
            // 
            // btXoa
            // 
            this.btXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.Crimson;
            this.btXoa.Location = new System.Drawing.Point(1020, 11);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(76, 27);
            this.btXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXoa.TabIndex = 610;
            this.btXoa.Text = "XÓA";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btNhap
            // 
            this.btNhap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btNhap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btNhap.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNhap.ForeColor = System.Drawing.Color.Crimson;
            this.btNhap.Location = new System.Drawing.Point(428, 12);
            this.btNhap.Name = "btNhap";
            this.btNhap.Size = new System.Drawing.Size(111, 27);
            this.btNhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btNhap.TabIndex = 609;
            this.btNhap.Text = "NHẬP";
            this.btNhap.Click += new System.EventHandler(this.btNhap_Click);
            // 
            // txtNgayGan
            // 
            this.txtNgayGan.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNgayGan.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNgayGan.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtNgayGan.ButtonDropDown.Visible = true;
            this.txtNgayGan.CustomFormat = "dd/MM/yyyy";
            this.txtNgayGan.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.txtNgayGan.ForeColor = System.Drawing.Color.Red;
            this.txtNgayGan.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtNgayGan.Location = new System.Drawing.Point(899, 11);
            // 
            // 
            // 
            this.txtNgayGan.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtNgayGan.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtNgayGan.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtNgayGan.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtNgayGan.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.txtNgayGan.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtNgayGan.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtNgayGan.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtNgayGan.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtNgayGan.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtNgayGan.MonthCalendar.TodayButtonVisible = true;
            this.txtNgayGan.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtNgayGan.Name = "txtNgayGan";
            this.txtNgayGan.Size = new System.Drawing.Size(112, 27);
            this.txtNgayGan.TabIndex = 608;
            this.txtNgayGan.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.txtNgayGan.WatermarkColor = System.Drawing.Color.Transparent;
            this.txtNgayGan.ValueChanged += new System.EventHandler(this.txtNgayGan_ValueChanged);
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(769, 13);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(140, 22);
            this.labelX7.TabIndex = 607;
            this.labelX7.Text = "NGÀY YÊU CẦU";
            // 
            // cbKyDS
            // 
            this.cbKyDS.DisplayMember = "Text";
            this.cbKyDS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKyDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKyDS.FormattingEnabled = true;
            this.cbKyDS.ItemHeight = 21;
            this.cbKyDS.Items.AddRange(new object[] {
            this.comboItem13,
            this.comboItem14,
            this.comboItem15,
            this.comboItem16,
            this.comboItem17,
            this.comboItem18,
            this.comboItem19,
            this.comboItem20,
            this.comboItem21,
            this.comboItem22,
            this.comboItem23,
            this.comboItem24});
            this.cbKyDS.Location = new System.Drawing.Point(45, 12);
            this.cbKyDS.Name = "cbKyDS";
            this.cbKyDS.Size = new System.Drawing.Size(86, 27);
            this.cbKyDS.TabIndex = 182;
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "1";
            this.comboItem13.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem13.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "2";
            this.comboItem14.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem14.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "3";
            this.comboItem15.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem15.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem16
            // 
            this.comboItem16.Text = "4";
            this.comboItem16.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem16.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem17
            // 
            this.comboItem17.Text = "5";
            this.comboItem17.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem17.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem18
            // 
            this.comboItem18.Text = "6";
            this.comboItem18.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem18.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem19
            // 
            this.comboItem19.Text = "7";
            this.comboItem19.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem19.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem20
            // 
            this.comboItem20.Text = "8";
            this.comboItem20.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem20.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem21
            // 
            this.comboItem21.Text = "9";
            this.comboItem21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem21.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem22
            // 
            this.comboItem22.Text = "10";
            this.comboItem22.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem22.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem23
            // 
            this.comboItem23.Text = "11";
            this.comboItem23.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem23.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem24
            // 
            this.comboItem24.Text = "12";
            this.comboItem24.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem24.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtNam
            // 
            // 
            // 
            // 
            this.txtNam.Border.Class = "TextBoxBorder";
            this.txtNam.Location = new System.Drawing.Point(184, 10);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(100, 27);
            this.txtNam.TabIndex = 181;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoKy
            // 
            this.txtSoKy.Location = new System.Drawing.Point(346, 11);
            this.txtSoKy.Name = "txtSoKy";
            this.txtSoKy.Size = new System.Drawing.Size(76, 27);
            this.txtSoKy.TabIndex = 180;
            this.txtSoKy.Text = "10";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(291, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 23);
            this.labelX3.TabIndex = 179;
            this.labelX3.Text = "SỐ KỲ";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(14, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 23);
            this.labelX2.TabIndex = 177;
            this.labelX2.Text = "KỲ";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(134, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(84, 23);
            this.labelX1.TabIndex = 40;
            this.labelX1.Text = "NĂM";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkChon,
            this.DANHBA});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1108, 572);
            this.dataGridView1.TabIndex = 0;
            // 
            // checkChon
            // 
            this.checkChon.HeaderText = "";
            this.checkChon.Name = "checkChon";
            this.checkChon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkChon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkChon.Width = 50;
            // 
            // DANHBA
            // 
            this.DANHBA.DataPropertyName = "DANHBA";
            this.DANHBA.HeaderText = "DANH BỘ";
            this.DANHBA.Name = "DANHBA";
            this.DANHBA.Width = 120;
            // 
            // W_tab_ThongKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "W_tab_ThongKeHoaDon";
            this.Size = new System.Drawing.Size(1108, 630);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayGan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox txtSoKy;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbKyDS;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        private DevComponents.Editors.ComboItem comboItem16;
        private DevComponents.Editors.ComboItem comboItem17;
        private DevComponents.Editors.ComboItem comboItem18;
        private DevComponents.Editors.ComboItem comboItem19;
        private DevComponents.Editors.ComboItem comboItem20;
        private DevComponents.Editors.ComboItem comboItem21;
        private DevComponents.Editors.ComboItem comboItem22;
        private DevComponents.Editors.ComboItem comboItem23;
        private DevComponents.Editors.ComboItem comboItem24;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNam;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtNgayGan;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.ButtonX btXoa;
        private DevComponents.DotNetBar.ButtonX btNhap;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DANHBA;

    }
}
