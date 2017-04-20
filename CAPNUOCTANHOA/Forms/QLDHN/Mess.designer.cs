namespace CAPNUOCTANHOA.Forms.QLDHN
{
    partial class Mess
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.checkChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sohoso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttiepnhan = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
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
            this.dataGrid.ColumnHeadersHeight = 30;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkChon,
            this.sohoso,
            this.DanhBo,
            this.DienThoai,
            this.TenLoai,
            this.GhiChu,
            this.NgayNhan,
            this.CreateBy,
            this.tiep});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 10;
            this.dataGrid.RowTemplate.Height = 30;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(857, 244);
            this.dataGrid.TabIndex = 787;
            // 
            // checkChon
            // 
            this.checkChon.FillWeight = 130F;
            this.checkChon.Frozen = true;
            this.checkChon.HeaderText = "";
            this.checkChon.Name = "checkChon";
            this.checkChon.Visible = false;
            this.checkChon.Width = 40;
            // 
            // sohoso
            // 
            this.sohoso.DataPropertyName = "SoHoSo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sohoso.DefaultCellStyle = dataGridViewCellStyle2;
            this.sohoso.HeaderText = "Số Hồ Sơ";
            this.sohoso.Name = "sohoso";
            this.sohoso.Width = 95;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DanhBo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 110;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.DienThoai.DefaultCellStyle = dataGridViewCellStyle4;
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Width = 120;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Loại Tiếp Nhận";
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.Width = 180;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 220;
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.NgayNhan.DefaultCellStyle = dataGridViewCellStyle5;
            this.NgayNhan.HeaderText = "Ngày Nhận";
            this.NgayNhan.Name = "NgayNhan";
            this.NgayNhan.Width = 110;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreateBy.DefaultCellStyle = dataGridViewCellStyle6;
            this.CreateBy.HeaderText = "NV Nhận";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Width = 120;
            // 
            // tiep
            // 
            this.tiep.HeaderText = "Tiếp Nhận";
            this.tiep.Name = "tiep";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bttiepnhan
            // 
            this.bttiepnhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bttiepnhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bttiepnhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bttiepnhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttiepnhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bttiepnhan.Location = new System.Drawing.Point(691, 197);
            this.bttiepnhan.Name = "bttiepnhan";
            this.bttiepnhan.Size = new System.Drawing.Size(161, 29);
            this.bttiepnhan.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bttiepnhan.TabIndex = 788;
            this.bttiepnhan.Text = "Tiếp Nhận";
            this.bttiepnhan.Click += new System.EventHandler(this.bttiepnhan_Click);
            // 
            // Mess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(857, 244);
            this.Controls.Add(this.bttiepnhan);
            this.Controls.Add(this.dataGrid);
            this.Name = "Mess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mess";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mess_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn sohoso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiep;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX bttiepnhan;
    }
}