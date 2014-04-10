namespace CAPNUOCTANHOA.Forms.BanKTKS.tab
{
    partial class tbKiemTraCamket
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
            this.btXemThongTin = new DevComponents.DotNetBar.ButtonX();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dateDenNgay);
            this.splitContainer1.Panel1.Controls.Add(this.dateTuNgay);
            this.splitContainer1.Panel1.Controls.Add(this.labelX1);
            this.splitContainer1.Panel1.Controls.Add(this.labelX12);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1117, 613);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 0;
            // 
            // btXemThongTin
            // 
            this.btXemThongTin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXemThongTin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXemThongTin.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemThongTin.ForeColor = System.Drawing.Color.Crimson;
            this.btXemThongTin.Location = new System.Drawing.Point(453, 8);
            this.btXemThongTin.Name = "btXemThongTin";
            this.btXemThongTin.Size = new System.Drawing.Size(157, 27);
            this.btXemThongTin.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXemThongTin.TabIndex = 624;
            this.btXemThongTin.Text = "XEM THÔNG TIN";
            this.btXemThongTin.Click += new System.EventHandler(this.btXemThongTin_Click);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(338, 8);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(100, 26);
            this.dateDenNgay.TabIndex = 623;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(105, 8);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(105, 26);
            this.dateTuNgay.TabIndex = 622;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(241, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(91, 22);
            this.labelX1.TabIndex = 621;
            this.labelX1.Text = "ĐẾN NGÀY";
            // 
            // labelX12
            // 
            this.labelX12.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Location = new System.Drawing.Point(17, 8);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(82, 22);
            this.labelX12.TabIndex = 620;
            this.labelX12.Text = "TỪ NGÀY";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1117, 564);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tbKiemTraCamket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tbKiemTraCamket";
            this.Size = new System.Drawing.Size(1117, 613);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btXemThongTin;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
