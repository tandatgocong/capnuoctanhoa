namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    partial class frm_CatNuoc
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
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.NGAYMO = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.NGAYDONG = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.HOTEN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.QUAN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PHUONGT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.txtDanhBo = new System.Windows.Forms.MaskedTextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.TENDUONG = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SONHA = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.HOPDONG = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LOTRINH = new System.Windows.Forms.MaskedTextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NGAYMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NGAYDONG)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(47, 5);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(571, 58);
            this.title.TabIndex = 2;
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(50, 173);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(101, 22);
            this.labelX7.TabIndex = 154;
            this.labelX7.Text = "PHƯỜNG";
            // 
            // NGAYMO
            // 
            this.NGAYMO.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.NGAYMO.BackgroundStyle.Class = "DateTimeInputBackground";
            this.NGAYMO.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.NGAYMO.ButtonDropDown.Visible = true;
            this.NGAYMO.CustomFormat = "dd/MM/yyyy";
            this.NGAYMO.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.NGAYMO.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NGAYMO.ForeColor = System.Drawing.Color.Red;
            this.NGAYMO.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.NGAYMO.Location = new System.Drawing.Point(371, 205);
            // 
            // 
            // 
            this.NGAYMO.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NGAYMO.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.NGAYMO.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.NGAYMO.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.NGAYMO.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.NGAYMO.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NGAYMO.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NGAYMO.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.NGAYMO.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.NGAYMO.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.NGAYMO.MonthCalendar.TodayButtonVisible = true;
            this.NGAYMO.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NGAYMO.Name = "NGAYMO";
            this.NGAYMO.Size = new System.Drawing.Size(131, 27);
            this.NGAYMO.TabIndex = 140;
            this.NGAYMO.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // NGAYDONG
            // 
            this.NGAYDONG.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.NGAYDONG.BackgroundStyle.Class = "DateTimeInputBackground";
            this.NGAYDONG.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.NGAYDONG.ButtonDropDown.Visible = true;
            this.NGAYDONG.CustomFormat = "dd/MM/yyyy";
            this.NGAYDONG.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.NGAYDONG.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NGAYDONG.ForeColor = System.Drawing.Color.Red;
            this.NGAYDONG.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.NGAYDONG.Location = new System.Drawing.Point(164, 205);
            // 
            // 
            // 
            this.NGAYDONG.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NGAYDONG.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.NGAYDONG.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.NGAYDONG.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.NGAYDONG.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.NGAYDONG.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NGAYDONG.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NGAYDONG.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.NGAYDONG.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.NGAYDONG.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.NGAYDONG.MonthCalendar.TodayButtonVisible = true;
            this.NGAYDONG.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NGAYDONG.Name = "NGAYDONG";
            this.NGAYDONG.Size = new System.Drawing.Size(114, 27);
            this.NGAYDONG.TabIndex = 139;
            this.NGAYDONG.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // HOTEN
            // 
            this.HOTEN.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.HOTEN.Border.Class = "TextBoxBorder";
            this.HOTEN.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.HOTEN.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HOTEN.ForeColor = System.Drawing.Color.Red;
            this.HOTEN.Location = new System.Drawing.Point(134, 106);
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(368, 27);
            this.HOTEN.TabIndex = 131;
            this.HOTEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HOTEN.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // QUAN
            // 
            // 
            // 
            // 
            this.QUAN.Border.Class = "TextBoxBorder";
            this.QUAN.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QUAN.ForeColor = System.Drawing.Color.Red;
            this.QUAN.Location = new System.Drawing.Point(339, 172);
            this.QUAN.Name = "QUAN";
            this.QUAN.Size = new System.Drawing.Size(163, 27);
            this.QUAN.TabIndex = 135;
            this.QUAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PHUONGT
            // 
            // 
            // 
            // 
            this.PHUONGT.Border.Class = "TextBoxBorder";
            this.PHUONGT.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PHUONGT.ForeColor = System.Drawing.Color.Red;
            this.PHUONGT.Location = new System.Drawing.Point(134, 172);
            this.PHUONGT.Name = "PHUONGT";
            this.PHUONGT.Size = new System.Drawing.Size(144, 27);
            this.PHUONGT.TabIndex = 134;
            this.PHUONGT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX20
            // 
            this.labelX20.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX20.Location = new System.Drawing.Point(281, 73);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(90, 22);
            this.labelX20.TabIndex = 150;
            this.labelX20.Text = "LỘ TRÌNH";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhBo.ForeColor = System.Drawing.Color.Red;
            this.txtDanhBo.Location = new System.Drawing.Point(134, 71);
            this.txtDanhBo.Mask = "0000-000-0000";
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(141, 29);
            this.txtDanhBo.TabIndex = 126;
            this.txtDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(50, 72);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(125, 22);
            this.labelX4.TabIndex = 143;
            this.labelX4.Text = "DANH BỘ";
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(50, 107);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(76, 22);
            this.labelX5.TabIndex = 152;
            this.labelX5.Text = "HỌ TÊN";
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(286, 207);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 22);
            this.labelX3.TabIndex = 144;
            this.labelX3.Text = "NGÀY MỞ";
            // 
            // TENDUONG
            // 
            this.TENDUONG.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TENDUONG.Border.Class = "TextBoxBorder";
            this.TENDUONG.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.TENDUONG.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENDUONG.ForeColor = System.Drawing.Color.Red;
            this.TENDUONG.Location = new System.Drawing.Point(284, 139);
            this.TENDUONG.Name = "TENDUONG";
            this.TENDUONG.Size = new System.Drawing.Size(218, 27);
            this.TENDUONG.TabIndex = 133;
            this.TENDUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TENDUONG.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // SONHA
            // 
            // 
            // 
            // 
            this.SONHA.Border.Class = "TextBoxBorder";
            this.SONHA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SONHA.ForeColor = System.Drawing.Color.Red;
            this.SONHA.Location = new System.Drawing.Point(134, 139);
            this.SONHA.Name = "SONHA";
            this.SONHA.Size = new System.Drawing.Size(144, 27);
            this.SONHA.TabIndex = 132;
            this.SONHA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(50, 139);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 22);
            this.labelX2.TabIndex = 142;
            this.labelX2.Text = "SỐ NHÀ";
            // 
            // labelX12
            // 
            this.labelX12.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Location = new System.Drawing.Point(50, 207);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(111, 22);
            this.labelX12.TabIndex = 145;
            this.labelX12.Text = "NGÀY ĐÓNG";
            // 
            // labelX13
            // 
            this.labelX13.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.Location = new System.Drawing.Point(286, 173);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(60, 22);
            this.labelX13.TabIndex = 153;
            this.labelX13.Text = "QUẬN";
            // 
            // labelX16
            // 
            this.labelX16.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX16.Location = new System.Drawing.Point(572, 73);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(102, 22);
            this.labelX16.TabIndex = 141;
            this.labelX16.Text = "HỢP ĐỒNG";
            this.labelX16.Visible = false;
            // 
            // HOPDONG
            // 
            // 
            // 
            // 
            this.HOPDONG.Border.Class = "TextBoxBorder";
            this.HOPDONG.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HOPDONG.ForeColor = System.Drawing.Color.Red;
            this.HOPDONG.Location = new System.Drawing.Point(666, 71);
            this.HOPDONG.Name = "HOPDONG";
            this.HOPDONG.Size = new System.Drawing.Size(128, 27);
            this.HOPDONG.TabIndex = 130;
            this.HOPDONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HOPDONG.Visible = false;
            // 
            // LOTRINH
            // 
            this.LOTRINH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOTRINH.ForeColor = System.Drawing.Color.Red;
            this.LOTRINH.Location = new System.Drawing.Point(371, 70);
            this.LOTRINH.Mask = "00.00.00000";
            this.LOTRINH.Name = "LOTRINH";
            this.LOTRINH.Size = new System.Drawing.Size(131, 29);
            this.LOTRINH.TabIndex = 142;
            this.LOTRINH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(50, 235);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(111, 22);
            this.labelX1.TabIndex = 156;
            this.labelX1.Text = "NỘI DUNG";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(142, 238);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(360, 68);
            this.txtGhiChu.TabIndex = 141;
            this.txtGhiChu.Text = "";
            // 
            // frm_CatNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.LOTRINH);
            this.Controls.Add(this.NGAYMO);
            this.Controls.Add(this.NGAYDONG);
            this.Controls.Add(this.HOTEN);
            this.Controls.Add(this.QUAN);
            this.Controls.Add(this.PHUONGT);
            this.Controls.Add(this.labelX20);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.TENDUONG);
            this.Controls.Add(this.HOPDONG);
            this.Controls.Add(this.labelX16);
            this.Controls.Add(this.SONHA);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.labelX13);
            this.Controls.Add(this.title);
            this.Controls.Add(this.labelX7);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_CatNuoc";
            this.Size = new System.Drawing.Size(1238, 657);
            ((System.ComponentModel.ISupportInitialize)(this.NGAYMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NGAYDONG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput NGAYMO;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput NGAYDONG;
        private DevComponents.DotNetBar.Controls.TextBoxX HOTEN;
        private DevComponents.DotNetBar.Controls.TextBoxX QUAN;
        private DevComponents.DotNetBar.Controls.TextBoxX PHUONGT;
        private DevComponents.DotNetBar.LabelX labelX20;
        private System.Windows.Forms.MaskedTextBox txtDanhBo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX TENDUONG;
        private DevComponents.DotNetBar.Controls.TextBoxX SONHA;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.Controls.TextBoxX HOPDONG;
        private System.Windows.Forms.MaskedTextBox LOTRINH;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RichTextBox txtGhiChu;


    }
}
