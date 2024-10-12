namespace QuanLyNhanSu
{
    partial class ChinhSach
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
            this.dtg_congtac = new System.Windows.Forms.DataGridView();
            this.dtg_phongban = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.x = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txt_makl = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtp_date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ht = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_gt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_sdt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resetHs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.txt_dc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search_hs = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_searchHs = new Guna.UI2.WinForms.Guna2CircleButton();
            this.add_hs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_deletehs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_updatehs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_makt = new Guna.UI2.WinForms.Guna2TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTriKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTriKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKL1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_congtac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_phongban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.x.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_congtac
            // 
            this.dtg_congtac.AllowUserToAddRows = false;
            this.dtg_congtac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_congtac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_congtac.BackgroundColor = System.Drawing.Color.White;
            this.dtg_congtac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_congtac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.MaKL,
            this.TenKL1,
            this.GiaTri2});
            this.dtg_congtac.Location = new System.Drawing.Point(481, 718);
            this.dtg_congtac.Name = "dtg_congtac";
            this.dtg_congtac.RowHeadersVisible = false;
            this.dtg_congtac.Size = new System.Drawing.Size(553, 206);
            this.dtg_congtac.TabIndex = 99;
            // 
            // dtg_phongban
            // 
            this.dtg_phongban.AllowUserToAddRows = false;
            this.dtg_phongban.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_phongban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_phongban.BackgroundColor = System.Drawing.Color.White;
            this.dtg_phongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_phongban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaKT,
            this.TenKT1,
            this.GiaTri1});
            this.dtg_phongban.Location = new System.Drawing.Point(2, 717);
            this.dtg_phongban.Name = "dtg_phongban";
            this.dtg_phongban.RowHeadersVisible = false;
            this.dtg_phongban.Size = new System.Drawing.Size(473, 207);
            this.dtg_phongban.TabIndex = 98;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.HoTen,
            this.GioiTinh,
            this.NgaySinh,
            this.Sdt,
            this.DiaChi,
            this.TenKT,
            this.GiaTriKT,
            this.TenKL,
            this.GiaTriKL});
            this.dataGridView1.Location = new System.Drawing.Point(2, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 682);
            this.dataGridView1.TabIndex = 97;
            // 
            // x
            // 
            this.x.Controls.Add(this.txt_makl);
            this.x.Controls.Add(this.dtp_date);
            this.x.Controls.Add(this.label8);
            this.x.Controls.Add(this.txt_ht);
            this.x.Controls.Add(this.label7);
            this.x.Controls.Add(this.label6);
            this.x.Controls.Add(this.txt_gt);
            this.x.Controls.Add(this.label5);
            this.x.Controls.Add(this.txt_sdt);
            this.x.Controls.Add(this.label4);
            this.x.Controls.Add(this.resetHs);
            this.x.Controls.Add(this.txt_dc);
            this.x.Controls.Add(this.label3);
            this.x.Controls.Add(this.search_hs);
            this.x.Controls.Add(this.btn_searchHs);
            this.x.Controls.Add(this.add_hs);
            this.x.Controls.Add(this.btn_deletehs);
            this.x.Controls.Add(this.btn_updatehs);
            this.x.Controls.Add(this.label1);
            this.x.Controls.Add(this.txt_makt);
            this.x.Dock = System.Windows.Forms.DockStyle.Right;
            this.x.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.Location = new System.Drawing.Point(1040, 0);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(594, 924);
            this.x.TabIndex = 96;
            // 
            // txt_makl
            // 
            this.txt_makl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_makl.BorderRadius = 20;
            this.txt_makl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_makl.DefaultText = "";
            this.txt_makl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_makl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_makl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_makl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_makl.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_makl.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_makl.ForeColor = System.Drawing.Color.Black;
            this.txt_makl.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_makl.Location = new System.Drawing.Point(241, 483);
            this.txt_makl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_makl.Name = "txt_makl";
            this.txt_makl.PasswordChar = '\0';
            this.txt_makl.PlaceholderText = "";
            this.txt_makl.SelectedText = "";
            this.txt_makl.Size = new System.Drawing.Size(238, 36);
            this.txt_makl.TabIndex = 103;
            // 
            // dtp_date
            // 
            this.dtp_date.BorderRadius = 20;
            this.dtp_date.Checked = true;
            this.dtp_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_date.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dtp_date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(241, 226);
            this.dtp_date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(247, 36);
            this.dtp_date.TabIndex = 102;
            this.dtp_date.Value = new System.DateTime(2024, 10, 12, 6, 37, 26, 931);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 101;
            this.label8.Text = "Ngày sinh :";
            // 
            // txt_ht
            // 
            this.txt_ht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ht.BorderRadius = 20;
            this.txt_ht.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ht.DefaultText = "";
            this.txt_ht.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_ht.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_ht.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_ht.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_ht.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_ht.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ht.ForeColor = System.Drawing.Color.Black;
            this.txt_ht.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_ht.Location = new System.Drawing.Point(241, 108);
            this.txt_ht.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_ht.Name = "txt_ht";
            this.txt_ht.PasswordChar = '\0';
            this.txt_ht.PlaceholderText = "";
            this.txt_ht.SelectedText = "";
            this.txt_ht.Size = new System.Drawing.Size(238, 36);
            this.txt_ht.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 99;
            this.label7.Text = "Họ và tên";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 493);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 97;
            this.label6.Text = "Mã kỷ luật :";
            // 
            // txt_gt
            // 
            this.txt_gt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_gt.BorderRadius = 20;
            this.txt_gt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_gt.DefaultText = "";
            this.txt_gt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_gt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_gt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gt.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gt.ForeColor = System.Drawing.Color.Black;
            this.txt_gt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gt.Location = new System.Drawing.Point(241, 168);
            this.txt_gt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_gt.Name = "txt_gt";
            this.txt_gt.PasswordChar = '\0';
            this.txt_gt.PlaceholderText = "";
            this.txt_gt.SelectedText = "";
            this.txt_gt.Size = new System.Drawing.Size(238, 36);
            this.txt_gt.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "Giới tính : ";
            // 
            // txt_sdt
            // 
            this.txt_sdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sdt.BorderRadius = 20;
            this.txt_sdt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sdt.DefaultText = "";
            this.txt_sdt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_sdt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_sdt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_sdt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_sdt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_sdt.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sdt.ForeColor = System.Drawing.Color.Black;
            this.txt_sdt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_sdt.Location = new System.Drawing.Point(241, 286);
            this.txt_sdt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.PasswordChar = '\0';
            this.txt_sdt.PlaceholderText = "";
            this.txt_sdt.SelectedText = "";
            this.txt_sdt.Size = new System.Drawing.Size(238, 36);
            this.txt_sdt.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 93;
            this.label4.Text = "SĐT : ";
            // 
            // resetHs
            // 
            this.resetHs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetHs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.resetHs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.resetHs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.resetHs.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.resetHs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.resetHs.FillColor = System.Drawing.Color.Transparent;
            this.resetHs.FillColor2 = System.Drawing.Color.Transparent;
            this.resetHs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.resetHs.ForeColor = System.Drawing.Color.White;
            this.resetHs.Image = global::QuanLyNhanSu.Properties.Resources.reset;
            this.resetHs.ImageSize = new System.Drawing.Size(40, 40);
            this.resetHs.Location = new System.Drawing.Point(465, 634);
            this.resetHs.Name = "resetHs";
            this.resetHs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.resetHs.Size = new System.Drawing.Size(46, 43);
            this.resetHs.TabIndex = 92;
            // 
            // txt_dc
            // 
            this.txt_dc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dc.BorderRadius = 20;
            this.txt_dc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dc.DefaultText = "";
            this.txt_dc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_dc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_dc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_dc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_dc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_dc.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dc.ForeColor = System.Drawing.Color.Black;
            this.txt_dc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_dc.Location = new System.Drawing.Point(241, 351);
            this.txt_dc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_dc.Name = "txt_dc";
            this.txt_dc.PasswordChar = '\0';
            this.txt_dc.PlaceholderText = "";
            this.txt_dc.SelectedText = "";
            this.txt_dc.Size = new System.Drawing.Size(238, 36);
            this.txt_dc.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "Địa chỉ : ";
            // 
            // search_hs
            // 
            this.search_hs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_hs.BackColor = System.Drawing.Color.Transparent;
            this.search_hs.BorderColor = System.Drawing.Color.Gray;
            this.search_hs.BorderRadius = 8;
            this.search_hs.BorderThickness = 3;
            this.search_hs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_hs.DefaultText = "";
            this.search_hs.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search_hs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search_hs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_hs.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_hs.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_hs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_hs.ForeColor = System.Drawing.Color.Black;
            this.search_hs.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(130)))), ((int)(((byte)(247)))));
            this.search_hs.Location = new System.Drawing.Point(23, 708);
            this.search_hs.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.search_hs.MaxLength = 40;
            this.search_hs.Name = "search_hs";
            this.search_hs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.search_hs.PasswordChar = '\0';
            this.search_hs.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.search_hs.PlaceholderText = "Search";
            this.search_hs.SelectedText = "";
            this.search_hs.Size = new System.Drawing.Size(488, 50);
            this.search_hs.TabIndex = 85;
            this.search_hs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_searchHs
            // 
            this.btn_searchHs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_searchHs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchHs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchHs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_searchHs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_searchHs.FillColor = System.Drawing.Color.Transparent;
            this.btn_searchHs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_searchHs.ForeColor = System.Drawing.Color.White;
            this.btn_searchHs.Image = global::QuanLyNhanSu.Properties.Resources.find;
            this.btn_searchHs.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_searchHs.Location = new System.Drawing.Point(527, 708);
            this.btn_searchHs.Name = "btn_searchHs";
            this.btn_searchHs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_searchHs.Size = new System.Drawing.Size(52, 50);
            this.btn_searchHs.TabIndex = 84;
            // 
            // add_hs
            // 
            this.add_hs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_hs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_hs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_hs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_hs.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_hs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_hs.FillColor = System.Drawing.Color.Transparent;
            this.add_hs.FillColor2 = System.Drawing.Color.Transparent;
            this.add_hs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_hs.ForeColor = System.Drawing.Color.White;
            this.add_hs.Image = global::QuanLyNhanSu.Properties.Resources.add;
            this.add_hs.ImageSize = new System.Drawing.Size(40, 40);
            this.add_hs.Location = new System.Drawing.Point(53, 634);
            this.add_hs.Name = "add_hs";
            this.add_hs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.add_hs.Size = new System.Drawing.Size(46, 43);
            this.add_hs.TabIndex = 9;
            // 
            // btn_deletehs
            // 
            this.btn_deletehs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deletehs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_deletehs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_deletehs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deletehs.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deletehs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_deletehs.FillColor = System.Drawing.Color.Transparent;
            this.btn_deletehs.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_deletehs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_deletehs.ForeColor = System.Drawing.Color.White;
            this.btn_deletehs.Image = global::QuanLyNhanSu.Properties.Resources.bin;
            this.btn_deletehs.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_deletehs.Location = new System.Drawing.Point(322, 634);
            this.btn_deletehs.Name = "btn_deletehs";
            this.btn_deletehs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_deletehs.Size = new System.Drawing.Size(46, 43);
            this.btn_deletehs.TabIndex = 8;
            // 
            // btn_updatehs
            // 
            this.btn_updatehs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updatehs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_updatehs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_updatehs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updatehs.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updatehs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_updatehs.FillColor = System.Drawing.Color.Transparent;
            this.btn_updatehs.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_updatehs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_updatehs.ForeColor = System.Drawing.Color.White;
            this.btn_updatehs.Image = global::QuanLyNhanSu.Properties.Resources.updated;
            this.btn_updatehs.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_updatehs.Location = new System.Drawing.Point(181, 634);
            this.btn_updatehs.Name = "btn_updatehs";
            this.btn_updatehs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_updatehs.Size = new System.Drawing.Size(46, 43);
            this.btn_updatehs.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã khen thưởng :";
            // 
            // txt_makt
            // 
            this.txt_makt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_makt.BorderRadius = 20;
            this.txt_makt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_makt.DefaultText = "";
            this.txt_makt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_makt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_makt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_makt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_makt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_makt.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_makt.ForeColor = System.Drawing.Color.Black;
            this.txt_makt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_makt.Location = new System.Drawing.Point(241, 414);
            this.txt_makt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_makt.Name = "txt_makt";
            this.txt_makt.PasswordChar = '\0';
            this.txt_makt.PlaceholderText = "";
            this.txt_makt.SelectedText = "";
            this.txt_makt.Size = new System.Drawing.Size(238, 36);
            this.txt_makt.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 23.45242F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.FillWeight = 136.4214F;
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.FillWeight = 91.37056F;
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.Name = "GioiTinh";
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.FillWeight = 101.8089F;
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.Name = "NgaySinh";
            // 
            // Sdt
            // 
            this.Sdt.DataPropertyName = "Sdt";
            this.Sdt.FillWeight = 118.104F;
            this.Sdt.HeaderText = "Số điện thoại";
            this.Sdt.Name = "Sdt";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.FillWeight = 105.5335F;
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // TenKT
            // 
            this.TenKT.DataPropertyName = "TenKT";
            this.TenKT.FillWeight = 103.7582F;
            this.TenKT.HeaderText = "Khen thưởng";
            this.TenKT.Name = "TenKT";
            // 
            // GiaTriKT
            // 
            this.GiaTriKT.DataPropertyName = "GiaTri";
            this.GiaTriKT.FillWeight = 106.0003F;
            this.GiaTriKT.HeaderText = "Tiền Thưởng";
            this.GiaTriKT.Name = "GiaTriKT";
            // 
            // TenKL
            // 
            this.TenKL.DataPropertyName = "TenKL";
            this.TenKL.FillWeight = 106.5326F;
            this.TenKL.HeaderText = "Kỷ luật";
            this.TenKL.Name = "TenKL";
            // 
            // GiaTriKL
            // 
            this.GiaTriKL.DataPropertyName = "GiaTri";
            this.GiaTriKL.FillWeight = 107.0182F;
            this.GiaTriKL.HeaderText = "Tiền phạt";
            this.GiaTriKL.Name = "GiaTriKL";
            // 
            // STT
            // 
            this.STT.DataPropertyName = "ID";
            this.STT.FillWeight = 30.45685F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // MaKT
            // 
            this.MaKT.DataPropertyName = "MaKT";
            this.MaKT.FillWeight = 134.7716F;
            this.MaKT.HeaderText = "Mã khen thưởng";
            this.MaKT.Name = "MaKT";
            // 
            // TenKT1
            // 
            this.TenKT1.DataPropertyName = "TenKT";
            this.TenKT1.FillWeight = 134.7716F;
            this.TenKT1.HeaderText = "Tên khen thưởng";
            this.TenKT1.Name = "TenKT1";
            // 
            // GiaTri1
            // 
            this.GiaTri1.DataPropertyName = "GiaTri";
            this.GiaTri1.HeaderText = "Giá trị";
            this.GiaTri1.Name = "GiaTri1";
            // 
            // Number
            // 
            this.Number.DataPropertyName = "ID";
            this.Number.FillWeight = 30.45685F;
            this.Number.HeaderText = "STT";
            this.Number.Name = "Number";
            // 
            // MaKL
            // 
            this.MaKL.DataPropertyName = "MaKL";
            this.MaKL.FillWeight = 151.1957F;
            this.MaKL.HeaderText = "Mã kỷ luật";
            this.MaKL.Name = "MaKL";
            // 
            // TenKL1
            // 
            this.TenKL1.DataPropertyName = "TenKL";
            this.TenKL1.FillWeight = 128.7925F;
            this.TenKL1.HeaderText = "Tên kỷ luật";
            this.TenKL1.Name = "TenKL1";
            // 
            // GiaTri2
            // 
            this.GiaTri2.FillWeight = 89.55494F;
            this.GiaTri2.HeaderText = "Giá trị ";
            this.GiaTri2.Name = "GiaTri2";
            // 
            // ChinhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1634, 924);
            this.Controls.Add(this.dtg_congtac);
            this.Controls.Add(this.dtg_phongban);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.x);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChinhSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChinhSach";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_congtac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_phongban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.x.ResumeLayout(false);
            this.x.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_congtac;
        private System.Windows.Forms.DataGridView dtg_phongban;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel x;
        private Guna.UI2.WinForms.Guna2TextBox txt_makl;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_date;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txt_ht;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txt_gt;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txt_sdt;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientCircleButton resetHs;
        private Guna.UI2.WinForms.Guna2TextBox txt_dc;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox search_hs;
        private Guna.UI2.WinForms.Guna2CircleButton btn_searchHs;
        private Guna.UI2.WinForms.Guna2GradientCircleButton add_hs;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_deletehs;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_updatehs;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_makt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTriKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTriKL;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKL1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri2;
    }
}