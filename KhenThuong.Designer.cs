namespace QuanLyNhanSu
{
    partial class KhenThuong
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txt_makt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search_khenthuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_searchKT = new Guna.UI2.WinForms.Guna2CircleButton();
            this.add_kt = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_deleteKT = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_updateKT = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_giatri = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_kt = new Guna.UI2.WinForms.Guna2TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reset1 = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MaKT,
            this.TenKT,
            this.GiaTri});
            this.dataGridView1.Location = new System.Drawing.Point(4, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 908);
            this.dataGridView1.TabIndex = 92;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.reset1);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_makt);
            this.guna2CustomGradientPanel1.Controls.Add(this.label3);
            this.guna2CustomGradientPanel1.Controls.Add(this.search_khenthuong);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_searchKT);
            this.guna2CustomGradientPanel1.Controls.Add(this.add_kt);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_deleteKT);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_updateKT);
            this.guna2CustomGradientPanel1.Controls.Add(this.label2);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_giatri);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_kt);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(1031, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(603, 924);
            this.guna2CustomGradientPanel1.TabIndex = 91;
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
            this.txt_makt.Location = new System.Drawing.Point(202, 282);
            this.txt_makt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_makt.Name = "txt_makt";
            this.txt_makt.PasswordChar = '\0';
            this.txt_makt.PlaceholderText = "";
            this.txt_makt.SelectedText = "";
            this.txt_makt.Size = new System.Drawing.Size(238, 36);
            this.txt_makt.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "Mã khen thưởng : ";
            // 
            // search_khenthuong
            // 
            this.search_khenthuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_khenthuong.BackColor = System.Drawing.Color.Transparent;
            this.search_khenthuong.BorderColor = System.Drawing.Color.Gray;
            this.search_khenthuong.BorderRadius = 8;
            this.search_khenthuong.BorderThickness = 3;
            this.search_khenthuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_khenthuong.DefaultText = "";
            this.search_khenthuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search_khenthuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search_khenthuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_khenthuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_khenthuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_khenthuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_khenthuong.ForeColor = System.Drawing.Color.Black;
            this.search_khenthuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(130)))), ((int)(((byte)(247)))));
            this.search_khenthuong.Location = new System.Drawing.Point(23, 572);
            this.search_khenthuong.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.search_khenthuong.MaxLength = 40;
            this.search_khenthuong.Name = "search_khenthuong";
            this.search_khenthuong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.search_khenthuong.PasswordChar = '\0';
            this.search_khenthuong.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.search_khenthuong.PlaceholderText = "Search";
            this.search_khenthuong.SelectedText = "";
            this.search_khenthuong.Size = new System.Drawing.Size(488, 50);
            this.search_khenthuong.TabIndex = 85;
            this.search_khenthuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_searchKT
            // 
            this.btn_searchKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_searchKT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchKT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchKT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_searchKT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_searchKT.FillColor = System.Drawing.Color.Transparent;
            this.btn_searchKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_searchKT.ForeColor = System.Drawing.Color.White;
            this.btn_searchKT.Image = global::QuanLyNhanSu.Properties.Resources.find;
            this.btn_searchKT.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_searchKT.Location = new System.Drawing.Point(527, 572);
            this.btn_searchKT.Name = "btn_searchKT";
            this.btn_searchKT.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_searchKT.Size = new System.Drawing.Size(52, 50);
            this.btn_searchKT.TabIndex = 84;
            this.btn_searchKT.Click += new System.EventHandler(this.btn_searchKT_Click);
            // 
            // add_kt
            // 
            this.add_kt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_kt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_kt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_kt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_kt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_kt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_kt.FillColor = System.Drawing.Color.Transparent;
            this.add_kt.FillColor2 = System.Drawing.Color.Transparent;
            this.add_kt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_kt.ForeColor = System.Drawing.Color.White;
            this.add_kt.Image = global::QuanLyNhanSu.Properties.Resources.add;
            this.add_kt.ImageSize = new System.Drawing.Size(40, 40);
            this.add_kt.Location = new System.Drawing.Point(53, 498);
            this.add_kt.Name = "add_kt";
            this.add_kt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.add_kt.Size = new System.Drawing.Size(46, 43);
            this.add_kt.TabIndex = 9;
            this.add_kt.Click += new System.EventHandler(this.add_kt_Click);
            // 
            // btn_deleteKT
            // 
            this.btn_deleteKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteKT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_deleteKT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_deleteKT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deleteKT.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deleteKT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_deleteKT.FillColor = System.Drawing.Color.Transparent;
            this.btn_deleteKT.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_deleteKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_deleteKT.ForeColor = System.Drawing.Color.White;
            this.btn_deleteKT.Image = global::QuanLyNhanSu.Properties.Resources.bin;
            this.btn_deleteKT.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_deleteKT.Location = new System.Drawing.Point(322, 498);
            this.btn_deleteKT.Name = "btn_deleteKT";
            this.btn_deleteKT.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_deleteKT.Size = new System.Drawing.Size(46, 43);
            this.btn_deleteKT.TabIndex = 8;
            this.btn_deleteKT.Click += new System.EventHandler(this.btn_deleteKT_Click);
            // 
            // btn_updateKT
            // 
            this.btn_updateKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateKT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_updateKT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_updateKT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updateKT.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updateKT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_updateKT.FillColor = System.Drawing.Color.Transparent;
            this.btn_updateKT.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_updateKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_updateKT.ForeColor = System.Drawing.Color.White;
            this.btn_updateKT.Image = global::QuanLyNhanSu.Properties.Resources.updated;
            this.btn_updateKT.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_updateKT.Location = new System.Drawing.Point(181, 498);
            this.btn_updateKT.Name = "btn_updateKT";
            this.btn_updateKT.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_updateKT.Size = new System.Drawing.Size(46, 43);
            this.btn_updateKT.TabIndex = 7;
            this.btn_updateKT.Click += new System.EventHandler(this.btn_updateKT_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giá trị :";
            // 
            // txt_giatri
            // 
            this.txt_giatri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_giatri.BorderRadius = 20;
            this.txt_giatri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giatri.DefaultText = "";
            this.txt_giatri.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_giatri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_giatri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giatri.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giatri.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giatri.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_giatri.ForeColor = System.Drawing.Color.Black;
            this.txt_giatri.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giatri.Location = new System.Drawing.Point(202, 415);
            this.txt_giatri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_giatri.Name = "txt_giatri";
            this.txt_giatri.PasswordChar = '\0';
            this.txt_giatri.PlaceholderText = "";
            this.txt_giatri.SelectedText = "";
            this.txt_giatri.Size = new System.Drawing.Size(238, 36);
            this.txt_giatri.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khen thưởng :";
            // 
            // txt_kt
            // 
            this.txt_kt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_kt.BorderRadius = 20;
            this.txt_kt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_kt.DefaultText = "";
            this.txt_kt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_kt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_kt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_kt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_kt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_kt.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kt.ForeColor = System.Drawing.Color.Black;
            this.txt_kt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_kt.Location = new System.Drawing.Point(202, 345);
            this.txt_kt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_kt.Name = "txt_kt";
            this.txt_kt.PasswordChar = '\0';
            this.txt_kt.PlaceholderText = "";
            this.txt_kt.SelectedText = "";
            this.txt_kt.Size = new System.Drawing.Size(238, 36);
            this.txt_kt.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 49.14294F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MaKT
            // 
            this.MaKT.DataPropertyName = "MaKT";
            this.MaKT.FillWeight = 60.91373F;
            this.MaKT.HeaderText = "Mã kỷ luật";
            this.MaKT.Name = "MaKT";
            // 
            // TenKT
            // 
            this.TenKT.DataPropertyName = "TenKT";
            this.TenKT.FillWeight = 144.9717F;
            this.TenKT.HeaderText = "Tên kỷ luật";
            this.TenKT.Name = "TenKT";
            // 
            // GiaTri
            // 
            this.GiaTri.DataPropertyName = "GiaTri";
            this.GiaTri.FillWeight = 144.9717F;
            this.GiaTri.HeaderText = "Giá trị";
            this.GiaTri.Name = "GiaTri";
            // 
            // reset1
            // 
            this.reset1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reset1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reset1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reset1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reset1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reset1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reset1.FillColor = System.Drawing.Color.Transparent;
            this.reset1.FillColor2 = System.Drawing.Color.Transparent;
            this.reset1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.reset1.ForeColor = System.Drawing.Color.White;
            this.reset1.Image = global::QuanLyNhanSu.Properties.Resources.reset;
            this.reset1.ImageSize = new System.Drawing.Size(40, 40);
            this.reset1.Location = new System.Drawing.Point(465, 498);
            this.reset1.Name = "reset1";
            this.reset1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.reset1.Size = new System.Drawing.Size(46, 43);
            this.reset1.TabIndex = 92;
            this.reset1.Click += new System.EventHandler(this.reset1_Click);
            // 
            // KhenThuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1634, 924);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KhenThuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhenThuong";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_makt;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox search_khenthuong;
        private Guna.UI2.WinForms.Guna2CircleButton btn_searchKT;
        private Guna.UI2.WinForms.Guna2GradientCircleButton add_kt;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_deleteKT;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_updateKT;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_giatri;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_kt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri;
        private Guna.UI2.WinForms.Guna2GradientCircleButton reset1;
    }
}