namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    partial class frm_InDSThuHoi
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
            this.btnIn = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dateDen = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dateTu = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dateDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Crimson;
            this.btnIn.Location = new System.Drawing.Point(158, 114);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(118, 23);
            this.btnIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "IN";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(221, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(93, 22);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "ĐẾN NGÀY";
            // 
            // dateDen
            // 
            this.dateDen.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dateDen.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateDen.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateDen.ButtonDropDown.Visible = true;
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.dateDen.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDen.ForeColor = System.Drawing.Color.Red;
            this.dateDen.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(320, 72);
            // 
            // 
            // 
            this.dateDen.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateDen.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateDen.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateDen.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateDen.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.dateDen.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateDen.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateDen.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateDen.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateDen.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateDen.MonthCalendar.TodayButtonVisible = true;
            this.dateDen.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 27);
            this.dateDen.TabIndex = 7;
            this.dateDen.Value = new System.DateTime(2013, 6, 27, 16, 11, 50, 0);
            this.dateDen.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(9, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(83, 22);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "TỪ NGÀY";
            // 
            // dateTu
            // 
            this.dateTu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dateTu.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTu.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTu.ButtonDropDown.Visible = true;
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.FocusHighlightColor = System.Drawing.Color.Transparent;
            this.dateTu.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTu.ForeColor = System.Drawing.Color.Red;
            this.dateTu.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(98, 72);
            // 
            // 
            // 
            this.dateTu.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTu.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTu.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTu.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTu.MonthCalendar.DisplayMonth = new System.DateTime(2012, 3, 1, 0, 0, 0, 0);
            this.dateTu.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTu.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTu.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTu.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTu.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTu.MonthCalendar.TodayButtonVisible = true;
            this.dateTu.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 27);
            this.dateTu.TabIndex = 5;
            this.dateTu.WatermarkColor = System.Drawing.Color.Transparent;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Crimson;
            this.labelX1.Location = new System.Drawing.Point(86, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(269, 36);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "In Danh Sách Thu Hồi";
            // 
            // frm_InDSThuHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 146);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_InDSThuHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN DANH SÁCH THU HỒI";
            ((System.ComponentModel.ISupportInitialize)(this.dateDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnIn;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateDen;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTu;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}