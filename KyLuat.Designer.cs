namespace QuanLyNhanSu
{
    partial class KyLuat
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetb = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.reset1 = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.txt_makl = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search_kyluat = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_searchKl = new Guna.UI2.WinForms.Guna2CircleButton();
            this.add_kl = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_deleteKl = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_updateKL = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_giatri = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_kl = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.resetb.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MaKL,
            this.TenKL,
            this.GiaTri});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(622, 655);
            this.dataGridView1.TabIndex = 90;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 49.14294F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MaKL
            // 
            this.MaKL.DataPropertyName = "MaKL";
            this.MaKL.FillWeight = 60.91373F;
            this.MaKL.HeaderText = "Mã kỷ luật";
            this.MaKL.Name = "MaKL";
            // 
            // TenKL
            // 
            this.TenKL.DataPropertyName = "TenKL";
            this.TenKL.FillWeight = 144.9717F;
            this.TenKL.HeaderText = "Tên kỷ luật";
            this.TenKL.Name = "TenKL";
            // 
            // GiaTri
            // 
            this.GiaTri.DataPropertyName = "GiaTri";
            this.GiaTri.FillWeight = 144.9717F;
            this.GiaTri.HeaderText = "Giá trị";
            this.GiaTri.Name = "GiaTri";
            // 
            // resetb
            // 
            this.resetb.Controls.Add(this.reset1);
            this.resetb.Controls.Add(this.txt_makl);
            this.resetb.Controls.Add(this.label3);
            this.resetb.Controls.Add(this.search_kyluat);
            this.resetb.Controls.Add(this.btn_searchKl);
            this.resetb.Controls.Add(this.add_kl);
            this.resetb.Controls.Add(this.btn_deleteKl);
            this.resetb.Controls.Add(this.btn_updateKL);
            this.resetb.Controls.Add(this.label2);
            this.resetb.Controls.Add(this.txt_giatri);
            this.resetb.Controls.Add(this.label1);
            this.resetb.Controls.Add(this.txt_kl);
            this.resetb.Dock = System.Windows.Forms.DockStyle.Right;
            this.resetb.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.resetb.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.resetb.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.resetb.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.resetb.Location = new System.Drawing.Point(622, 0);
            this.resetb.Name = "resetb";
            this.resetb.Size = new System.Drawing.Size(451, 655);
            this.resetb.TabIndex = 89;
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
            this.reset1.Location = new System.Drawing.Point(326, 229);
            this.reset1.Name = "reset1";
            this.reset1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.reset1.Size = new System.Drawing.Size(46, 43);
            this.reset1.TabIndex = 91;
            this.reset1.Click += new System.EventHandler(this.reset1_Click_1);
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
            this.txt_makl.Location = new System.Drawing.Point(134, 13);
            this.txt_makl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_makl.Name = "txt_makl";
            this.txt_makl.PasswordChar = '\0';
            this.txt_makl.PlaceholderText = "";
            this.txt_makl.SelectedText = "";
            this.txt_makl.Size = new System.Drawing.Size(238, 36);
            this.txt_makl.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "Mã kỷ luật : ";
            // 
            // search_kyluat
            // 
            this.search_kyluat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_kyluat.BackColor = System.Drawing.Color.Transparent;
            this.search_kyluat.BorderColor = System.Drawing.Color.Gray;
            this.search_kyluat.BorderRadius = 8;
            this.search_kyluat.BorderThickness = 3;
            this.search_kyluat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_kyluat.DefaultText = "";
            this.search_kyluat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search_kyluat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search_kyluat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_kyluat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_kyluat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_kyluat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_kyluat.ForeColor = System.Drawing.Color.Black;
            this.search_kyluat.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(130)))), ((int)(((byte)(247)))));
            this.search_kyluat.Location = new System.Drawing.Point(13, 303);
            this.search_kyluat.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.search_kyluat.MaxLength = 40;
            this.search_kyluat.Name = "search_kyluat";
            this.search_kyluat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.search_kyluat.PasswordChar = '\0';
            this.search_kyluat.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.search_kyluat.PlaceholderText = "Search";
            this.search_kyluat.SelectedText = "";
            this.search_kyluat.Size = new System.Drawing.Size(366, 50);
            this.search_kyluat.TabIndex = 85;
            this.search_kyluat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_searchKl
            // 
            this.btn_searchKl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_searchKl.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchKl.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchKl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_searchKl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_searchKl.FillColor = System.Drawing.Color.Transparent;
            this.btn_searchKl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_searchKl.ForeColor = System.Drawing.Color.White;
            this.btn_searchKl.Image = global::QuanLyNhanSu.Properties.Resources.find;
            this.btn_searchKl.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_searchKl.Location = new System.Drawing.Point(394, 303);
            this.btn_searchKl.Name = "btn_searchKl";
            this.btn_searchKl.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_searchKl.Size = new System.Drawing.Size(52, 50);
            this.btn_searchKl.TabIndex = 84;
            this.btn_searchKl.Click += new System.EventHandler(this.btn_searchKl_Click);
            // 
            // add_kl
            // 
            this.add_kl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_kl.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_kl.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add_kl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_kl.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add_kl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add_kl.FillColor = System.Drawing.Color.Transparent;
            this.add_kl.FillColor2 = System.Drawing.Color.Transparent;
            this.add_kl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add_kl.ForeColor = System.Drawing.Color.White;
            this.add_kl.Image = global::QuanLyNhanSu.Properties.Resources.add;
            this.add_kl.ImageSize = new System.Drawing.Size(40, 40);
            this.add_kl.Location = new System.Drawing.Point(22, 229);
            this.add_kl.Name = "add_kl";
            this.add_kl.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.add_kl.Size = new System.Drawing.Size(46, 43);
            this.add_kl.TabIndex = 9;
            this.add_kl.Click += new System.EventHandler(this.add_kl_Click);
            // 
            // btn_deleteKl
            // 
            this.btn_deleteKl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteKl.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_deleteKl.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_deleteKl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deleteKl.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_deleteKl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_deleteKl.FillColor = System.Drawing.Color.Transparent;
            this.btn_deleteKl.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_deleteKl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_deleteKl.ForeColor = System.Drawing.Color.White;
            this.btn_deleteKl.Image = global::QuanLyNhanSu.Properties.Resources.bin;
            this.btn_deleteKl.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_deleteKl.Location = new System.Drawing.Point(233, 229);
            this.btn_deleteKl.Name = "btn_deleteKl";
            this.btn_deleteKl.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_deleteKl.Size = new System.Drawing.Size(46, 43);
            this.btn_deleteKl.TabIndex = 8;
            this.btn_deleteKl.Click += new System.EventHandler(this.btn_deleteKl_Click);
            // 
            // btn_updateKL
            // 
            this.btn_updateKL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateKL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_updateKL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_updateKL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updateKL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_updateKL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_updateKL.FillColor = System.Drawing.Color.Transparent;
            this.btn_updateKL.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_updateKL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_updateKL.ForeColor = System.Drawing.Color.White;
            this.btn_updateKL.Image = global::QuanLyNhanSu.Properties.Resources.updated;
            this.btn_updateKL.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_updateKL.Location = new System.Drawing.Point(119, 229);
            this.btn_updateKL.Name = "btn_updateKL";
            this.btn_updateKL.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_updateKL.Size = new System.Drawing.Size(46, 43);
            this.btn_updateKL.TabIndex = 7;
            this.btn_updateKL.Click += new System.EventHandler(this.btn_updateKL_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 156);
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
            this.txt_giatri.Location = new System.Drawing.Point(134, 146);
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
            this.label1.Location = new System.Drawing.Point(19, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên kỷ luật :";
            // 
            // txt_kl
            // 
            this.txt_kl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_kl.BorderRadius = 20;
            this.txt_kl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_kl.DefaultText = "";
            this.txt_kl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_kl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_kl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_kl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_kl.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_kl.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kl.ForeColor = System.Drawing.Color.Black;
            this.txt_kl.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_kl.Location = new System.Drawing.Point(134, 76);
            this.txt_kl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_kl.Name = "txt_kl";
            this.txt_kl.PasswordChar = '\0';
            this.txt_kl.PlaceholderText = "";
            this.txt_kl.SelectedText = "";
            this.txt_kl.Size = new System.Drawing.Size(238, 36);
            this.txt_kl.TabIndex = 0;
            // 
            // KyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1073, 655);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.resetb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KyLuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KyLuat";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.resetb.ResumeLayout(false);
            this.resetb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel resetb;
        private Guna.UI2.WinForms.Guna2TextBox txt_makl;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox search_kyluat;
        private Guna.UI2.WinForms.Guna2CircleButton btn_searchKl;
        private Guna.UI2.WinForms.Guna2GradientCircleButton add_kl;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_deleteKl;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_updateKL;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_giatri;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_kl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri;
        private Guna.UI2.WinForms.Guna2GradientCircleButton reset1;
    }
}