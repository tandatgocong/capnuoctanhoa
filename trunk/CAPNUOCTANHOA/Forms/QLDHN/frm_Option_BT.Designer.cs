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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbLoaiBangKe = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.title = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSoBangKe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataBangKe = new System.Windows.Forms.DataGridView();
            this.G_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DANHBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_TENKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYTHAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_HIEUDHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_CODHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_SOTHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHITHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHN_CHIGOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_CHISO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_LYDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btTaoBangKe = new DevComponents.DotNetBar.ButtonX();
            this.btThoat = new DevComponents.DotNetBar.ButtonX();
            this.btIn = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLoaiBangKe
            // 
            this.cbLoaiBangKe.BackColor = System.Drawing.SystemColors.Window;
            this.cbLoaiBangKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBangKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiBangKe.ForeColor = System.Drawing.Color.Blue;
            this.cbLoaiBangKe.FormattingEnabled = true;
            this.cbLoaiBangKe.Items.AddRange(new object[] {
            "GGF",
            "SGF",
            "SGFDSGF\'DS",
            "GFD",
            "SGF",
            "DSGF"});
            this.cbLoaiBangKe.Location = new System.Drawing.Point(159, 67);
            this.cbLoaiBangKe.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbLoaiBangKe.Name = "cbLoaiBangKe";
            this.cbLoaiBangKe.Size = new System.Drawing.Size(259, 27);
            this.cbLoaiBangKe.TabIndex = 5;
            this.cbLoaiBangKe.SelectedValueChanged += new System.EventHandler(this.cbLoaiBangKe_SelectedValueChanged);
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(20, 64);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(133, 33);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "LOẠI BẢNG KÊ";
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Wingdings 2", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelX4.Location = new System.Drawing.Point(211, 30);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(189, 24);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "";
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.Crimson;
            this.title.Location = new System.Drawing.Point(20, 4);
            this.title.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.title.Name = "title";
            this.title.ReflectionEnabled = false;
            this.title.Size = new System.Drawing.Size(732, 49);
            this.title.TabIndex = 4;
            this.title.Text = "BẢNG KÊ BÁO THAY ĐỒNG HỒ NƯỚC";
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(41, 105);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(190, 32);
            this.labelX2.TabIndex = 102;
            this.labelX2.Text = "SỐ BẢNG KÊ";
            // 
            // txtSoBangKe
            // 
            // 
            // 
            // 
            this.txtSoBangKe.Border.Class = "TextBoxBorder";
            this.txtSoBangKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoBangKe.Location = new System.Drawing.Point(157, 105);
            this.txtSoBangKe.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoBangKe.Name = "txtSoBangKe";
            this.txtSoBangKe.Size = new System.Drawing.Size(261, 26);
            this.txtSoBangKe.TabIndex = 103;
            // 
            // dataBangKe
            // 
            this.dataBangKe.AllowUserToAddRows = false;
            this.dataBangKe.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataBangKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBangKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataBangKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBangKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G_STT,
            this.G_DANHBO,
            this.G_TENKH,
            this.G_DIACHI,
            this.NGAYTHAY,
            this.G_HIEUDHN,
            this.G_CODHN,
            this.G_SOTHAN,
            this.CHITHAN,
            this.DHN_CHIGOC,
            this.G_CHISO,
            this.G_LYDO,
            this.DOT});
            this.dataBangKe.Location = new System.Drawing.Point(20, 149);
            this.dataBangKe.Margin = new System.Windows.Forms.Padding(4);
            this.dataBangKe.MultiSelect = false;
            this.dataBangKe.Name = "dataBangKe";
            this.dataBangKe.RowHeadersWidth = 20;
            this.dataBangKe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataBangKe.RowTemplate.Height = 28;
            this.dataBangKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBangKe.Size = new System.Drawing.Size(1162, 375);
            this.dataBangKe.TabIndex = 101;
            this.dataBangKe.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataBangKe_EditingControlShowing);
            // 
            // G_STT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.G_STT.Frozen = true;
            this.G_STT.HeaderText = "STT";
            this.G_STT.Name = "G_STT";
            this.G_STT.Width = 40;
            // 
            // G_DANHBO
            // 
            this.G_DANHBO.DataPropertyName = "DANHBO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_DANHBO.DefaultCellStyle = dataGridViewCellStyle3;
            this.G_DANHBO.Frozen = true;
            this.G_DANHBO.HeaderText = "DANH BỘ";
            this.G_DANHBO.Name = "G_DANHBO";
            this.G_DANHBO.Width = 130;
            // 
            // G_TENKH
            // 
            this.G_TENKH.DataPropertyName = "HOTEN";
            this.G_TENKH.Frozen = true;
            this.G_TENKH.HeaderText = "TÊN KHÁCH HÀNG";
            this.G_TENKH.Name = "G_TENKH";
            this.G_TENKH.Width = 220;
            // 
            // G_DIACHI
            // 
            this.G_DIACHI.DataPropertyName = "DIACHI";
            this.G_DIACHI.Frozen = true;
            this.G_DIACHI.HeaderText = "ĐỊA CHỈ";
            this.G_DIACHI.Name = "G_DIACHI";
            this.G_DIACHI.Width = 250;
            // 
            // NGAYTHAY
            // 
            this.NGAYTHAY.DataPropertyName = "NGAYTHAY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.NGAYTHAY.DefaultCellStyle = dataGridViewCellStyle4;
            this.NGAYTHAY.HeaderText = "NGÀY GẮN";
            this.NGAYTHAY.Name = "NGAYTHAY";
            this.NGAYTHAY.Width = 120;
            // 
            // G_HIEUDHN
            // 
            this.G_HIEUDHN.DataPropertyName = "HIEUDH";
            this.G_HIEUDHN.HeaderText = "HIỆU ĐH";
            this.G_HIEUDHN.Name = "G_HIEUDHN";
            this.G_HIEUDHN.Width = 130;
            // 
            // G_CODHN
            // 
            this.G_CODHN.DataPropertyName = "CODH";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_CODHN.DefaultCellStyle = dataGridViewCellStyle5;
            this.G_CODHN.HeaderText = "CỠ";
            this.G_CODHN.Name = "G_CODHN";
            this.G_CODHN.Width = 50;
            // 
            // G_SOTHAN
            // 
            this.G_SOTHAN.DataPropertyName = "SOTHANDH";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_SOTHAN.DefaultCellStyle = dataGridViewCellStyle6;
            this.G_SOTHAN.HeaderText = "SỐ THÂN";
            this.G_SOTHAN.Name = "G_SOTHAN";
            this.G_SOTHAN.Width = 130;
            // 
            // CHITHAN
            // 
            this.CHITHAN.DataPropertyName = "CHITHAN";
            this.CHITHAN.HeaderText = "CHÌ THÂN";
            this.CHITHAN.Name = "CHITHAN";
            this.CHITHAN.Width = 120;
            // 
            // DHN_CHIGOC
            // 
            this.DHN_CHIGOC.DataPropertyName = "CHIGOC";
            this.DHN_CHIGOC.HeaderText = "CHÌ GÓC";
            this.DHN_CHIGOC.Name = "DHN_CHIGOC";
            // 
            // G_CHISO
            // 
            this.G_CHISO.DataPropertyName = "CHISOKYTRUOC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_CHISO.DefaultCellStyle = dataGridViewCellStyle7;
            this.G_CHISO.HeaderText = "CHỈ SỐ";
            this.G_CHISO.Name = "G_CHISO";
            this.G_CHISO.Width = 90;
            // 
            // G_LYDO
            // 
            this.G_LYDO.DataPropertyName = "GHICHU";
            this.G_LYDO.HeaderText = "LÝ DO";
            this.G_LYDO.Name = "G_LYDO";
            this.G_LYDO.Width = 150;
            // 
            // DOT
            // 
            this.DOT.DataPropertyName = "DOT";
            this.DOT.HeaderText = "DOT";
            this.DOT.Name = "DOT";
            this.DOT.Visible = false;
            // 
            // btTaoBangKe
            // 
            this.btTaoBangKe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btTaoBangKe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btTaoBangKe.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTaoBangKe.ForeColor = System.Drawing.Color.Crimson;
            this.btTaoBangKe.Location = new System.Drawing.Point(20, 532);
            this.btTaoBangKe.Margin = new System.Windows.Forms.Padding(4);
            this.btTaoBangKe.Name = "btTaoBangKe";
            this.btTaoBangKe.Size = new System.Drawing.Size(133, 23);
            this.btTaoBangKe.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btTaoBangKe.TabIndex = 104;
            this.btTaoBangKe.Text = "TẠO BẢNG KÊ";
            this.btTaoBangKe.Click += new System.EventHandler(this.btTaoBangKe_Click);
            // 
            // btThoat
            // 
            this.btThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ForeColor = System.Drawing.Color.Crimson;
            this.btThoat.Location = new System.Drawing.Point(415, 532);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(118, 23);
            this.btThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btThoat.TabIndex = 105;
            this.btThoat.Text = "THOÁT";
            // 
            // btIn
            // 
            this.btIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btIn.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIn.ForeColor = System.Drawing.Color.Crimson;
            this.btIn.Location = new System.Drawing.Point(160, 532);
            this.btIn.Name = "btIn";
            this.btIn.Size = new System.Drawing.Size(121, 23);
            this.btIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btIn.TabIndex = 106;
            this.btIn.Text = "IN BẢNG KÊ";
            this.btIn.Click += new System.EventHandler(this.btIn_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.Color.Crimson;
            this.buttonX1.Location = new System.Drawing.Point(287, 532);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(121, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.buttonX1.TabIndex = 107;
            this.buttonX1.Text = "HOÀN TẤT";
            // 
            // frm_Option_BT
            // 
            this.AcceptButton = this.btTaoBangKe;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1181, 561);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btIn);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btTaoBangKe);
            this.Controls.Add(this.txtSoBangKe);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.dataBangKe);
            this.Controls.Add(this.cbLoaiBangKe);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.title);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Option_BT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Báo Thay";
            this.Load += new System.EventHandler(this.frm_Option_BT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBangKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLoaiBangKe;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ReflectionLabel title;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoBangKe;
        private System.Windows.Forms.DataGridView dataBangKe;
        private DevComponents.DotNetBar.ButtonX btTaoBangKe;
        private DevComponents.DotNetBar.ButtonX btThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DANHBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_TENKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYTHAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_HIEUDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CODHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_SOTHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHITHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHN_CHIGOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_CHISO;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_LYDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOT;
        private DevComponents.DotNetBar.ButtonX btIn;
        private DevComponents.DotNetBar.ButtonX buttonX1;

    }
}