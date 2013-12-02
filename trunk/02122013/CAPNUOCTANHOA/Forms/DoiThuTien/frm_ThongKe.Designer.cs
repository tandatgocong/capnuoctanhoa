namespace CAPNUOCTANHOA.Forms.DoiThuTien
{
    partial class frm_ThongKe
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btXemThongTin = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tuNgay = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbKyDS = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.theoThangNam = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.dateTimePickernay = new System.Windows.Forms.DateTimePicker();
            this.theoNgay = new DevComponents.DotNetBar.TabItem(this.components);
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btXemThongTin);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.title);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 657);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 4;
            // 
            // btXemThongTin
            // 
            this.btXemThongTin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXemThongTin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXemThongTin.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemThongTin.ForeColor = System.Drawing.Color.Crimson;
            this.btXemThongTin.Location = new System.Drawing.Point(440, 36);
            this.btXemThongTin.Name = "btXemThongTin";
            this.btXemThongTin.Size = new System.Drawing.Size(157, 27);
            this.btXemThongTin.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXemThongTin.TabIndex = 105;
            this.btXemThongTin.Text = "XEM THÔNG TIN";
            this.btXemThongTin.Click += new System.EventHandler(this.btXemThongTin_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(41, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(393, 67);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Flat;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.theoNgay);
            this.tabControl1.Tabs.Add(this.theoThangNam);
            this.tabControl1.Tabs.Add(this.tuNgay);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dateTuNgay);
            this.tabControlPanel2.Controls.Add(this.dateDenNgay);
            this.tabControlPanel2.Controls.Add(this.labelX4);
            this.tabControlPanel2.Controls.Add(this.labelX3);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(393, 39);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tuNgay;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(63, 9);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(100, 24);
            this.dateTuNgay.TabIndex = 1;
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(235, 9);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(100, 24);
            this.dateDenNgay.TabIndex = 1;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(169, 9);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Đến Ngày";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(4, 9);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Từ Ngày";
            // 
            // tuNgay
            // 
            this.tuNgay.AttachedControl = this.tabControlPanel2;
            this.tuNgay.Name = "tuNgay";
            this.tuNgay.Text = "Từ  Ngày";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.labelX1);
            this.tabControlPanel3.Controls.Add(this.cbKyDS);
            this.tabControlPanel3.Controls.Add(this.txtNam);
            this.tabControlPanel3.Controls.Add(this.labelX2);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(393, 39);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.theoThangNam;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(66, 23);
            this.labelX1.TabIndex = 28;
            this.labelX1.Text = "THÁNG";
            // 
            // cbKyDS
            // 
            this.cbKyDS.DisplayMember = "Text";
            this.cbKyDS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKyDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKyDS.FormattingEnabled = true;
            this.cbKyDS.ItemHeight = 20;
            this.cbKyDS.Items.AddRange(new object[] {
            this.comboItem1,
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
            this.cbKyDS.Location = new System.Drawing.Point(77, 4);
            this.cbKyDS.Name = "cbKyDS";
            this.cbKyDS.Size = new System.Drawing.Size(59, 26);
            this.cbKyDS.TabIndex = 27;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "0";
            this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem1.TextLineAlignment = System.Drawing.StringAlignment.Center;
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
            this.txtNam.Location = new System.Drawing.Point(190, 4);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(71, 26);
            this.txtNam.TabIndex = 26;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(142, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(53, 23);
            this.labelX2.TabIndex = 25;
            this.labelX2.Text = "NĂM ";
            // 
            // theoThangNam
            // 
            this.theoThangNam.AttachedControl = this.tabControlPanel3;
            this.theoThangNam.Name = "theoThangNam";
            this.theoThangNam.Text = "Theo Tháng Năm";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.dateTimePickernay);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(393, 39);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 5;
            this.tabControlPanel4.TabItem = this.theoNgay;
            // 
            // dateTimePickernay
            // 
            this.dateTimePickernay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickernay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickernay.Location = new System.Drawing.Point(82, 4);
            this.dateTimePickernay.Name = "dateTimePickernay";
            this.dateTimePickernay.Size = new System.Drawing.Size(100, 26);
            this.dateTimePickernay.TabIndex = 5;
            // 
            // theoNgay
            // 
            this.theoNgay.AttachedControl = this.tabControlPanel4;
            this.theoNgay.Name = "theoNgay";
            this.theoNgay.Text = "Theo Ngày";
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(18, 0);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(571, 58);
            this.title.TabIndex = 4;
            this.title.Text = "BÁO CÁO THỐNG KÊ ĐÓNG NƯỚC";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1264, 547);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frm_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ThongKe";
            this.Size = new System.Drawing.Size(1264, 657);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem theoThangNam;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.TabItem tuNgay;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem theoNgay;
        private DevComponents.DotNetBar.ButtonX btXemThongTin;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePickernay;
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
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.LabelX labelX1;




    }
}
