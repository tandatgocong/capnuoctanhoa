﻿namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    partial class frm_BaoCaoTongKet_KTKS
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
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.rtThongKeDHN = new System.Windows.Forms.RadioButton();
            this.radioThayDinhKy = new System.Windows.Forms.RadioButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.expandablePanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(1238, 657);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.Color.AliceBlue;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel1.Controls.Add(this.rtThongKeDHN);
            this.expandablePanel1.Controls.Add(this.radioThayDinhKy);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(205, 657);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.Sunken;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 4;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandablePanel1.TitleStyle.ForeColor.Color = System.Drawing.Color.Firebrick;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Danh Mục Báo Cáo";
            // 
            // rtThongKeDHN
            // 
            this.rtThongKeDHN.AutoSize = true;
            this.rtThongKeDHN.Checked = true;
            this.rtThongKeDHN.Location = new System.Drawing.Point(10, 33);
            this.rtThongKeDHN.Name = "rtThongKeDHN";
            this.rtThongKeDHN.Size = new System.Drawing.Size(154, 23);
            this.rtThongKeDHN.TabIndex = 1;
            this.rtThongKeDHN.TabStop = true;
            this.rtThongKeDHN.Text = "Kiểm Tra Cam Kết";
            this.rtThongKeDHN.UseVisualStyleBackColor = true;
            this.rtThongKeDHN.CheckedChanged += new System.EventHandler(this.rtThongKeDHN_CheckedChanged);
            // 
            // radioThayDinhKy
            // 
            this.radioThayDinhKy.AutoSize = true;
            this.radioThayDinhKy.Location = new System.Drawing.Point(10, 62);
            this.radioThayDinhKy.Name = "radioThayDinhKy";
            this.radioThayDinhKy.Size = new System.Drawing.Size(171, 23);
            this.radioThayDinhKy.TabIndex = 1;
            this.radioThayDinhKy.TabStop = true;
            this.radioThayDinhKy.Text = "Theo dõi HD=0 2 Kỳ";
            this.radioThayDinhKy.UseVisualStyleBackColor = true;
            this.radioThayDinhKy.CheckedChanged += new System.EventHandler(this.radioThayDinhKy_CheckedChanged);
            // 
            // frm_BaoCaoTongKet_KTKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_BaoCaoTongKet_KTKS";
            this.Size = new System.Drawing.Size(1238, 657);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.RadioButton radioThayDinhKy;
        private System.Windows.Forms.RadioButton rtThongKeDHN;
        //<<<<<<< .mine
        //=======
//>>>>>>> .r275

    }
}