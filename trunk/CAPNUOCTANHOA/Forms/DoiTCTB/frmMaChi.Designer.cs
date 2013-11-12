namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    partial class frmMaChi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_MACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btThem = new DevComponents.DotNetBar.ButtonX();
            this.btXoa = new DevComponents.DotNetBar.ButtonX();
            this.textBoxid = new System.Windows.Forms.TextBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.G_MACHI});
            this.dataGridView1.Location = new System.Drawing.Point(11, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(392, 327);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "ID";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle5;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // G_MACHI
            // 
            this.G_MACHI.DataPropertyName = "MACHI";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.G_MACHI.DefaultCellStyle = dataGridViewCellStyle6;
            this.G_MACHI.HeaderText = "Mã Chì";
            this.G_MACHI.Name = "G_MACHI";
            this.G_MACHI.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÃ CHÌ :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 27);
            this.textBox1.TabIndex = 2;
            // 
            // btThem
            // 
            this.btThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.Crimson;
            this.btThem.Location = new System.Drawing.Point(204, 17);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(61, 23);
            this.btThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btThem.TabIndex = 16;
            this.btThem.Text = "THÊM";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.Crimson;
            this.btXoa.Location = new System.Drawing.Point(271, 18);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(63, 23);
            this.btXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.btXoa.TabIndex = 102;
            this.btXoa.Text = "XÓA";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // textBoxid
            // 
            this.textBoxid.Location = new System.Drawing.Point(119, 183);
            this.textBoxid.Name = "textBoxid";
            this.textBoxid.Size = new System.Drawing.Size(62, 27);
            this.textBoxid.TabIndex = 103;
            this.textBoxid.Visible = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.Color.Crimson;
            this.buttonX1.Location = new System.Drawing.Point(340, 18);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(63, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.buttonX1.TabIndex = 104;
            this.buttonX1.Text = "SỬA";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmMaChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(414, 392);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxid);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMaChi";
            this.Text = "MÃ CHÌ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_MACHI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private DevComponents.DotNetBar.ButtonX btThem;
        private DevComponents.DotNetBar.ButtonX btXoa;
        private System.Windows.Forms.TextBox textBoxid;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}