namespace QuanLyNhanSu
{
    partial class ChamCong
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
            this.x = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dtp_date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_machamcong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_manv = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.resetHs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.search_hs = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_searchHs = new Guna.UI2.WinForms.Guna2CircleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LamViec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cb_chamcong = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_deletehs = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.btn_chamcong = new Guna.UI2.WinForms.Guna2Button();
            this.x.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Controls.Add(this.btn_chamcong);
            this.x.Controls.Add(this.btn_deletehs);
            this.x.Controls.Add(this.label1);
            this.x.Controls.Add(this.cb_chamcong);
            this.x.Controls.Add(this.dtp_date);
            this.x.Controls.Add(this.label8);
            this.x.Controls.Add(this.txt_machamcong);
            this.x.Controls.Add(this.label7);
            this.x.Controls.Add(this.txt_manv);
            this.x.Controls.Add(this.label5);
            this.x.Controls.Add(this.resetHs);
            this.x.Controls.Add(this.search_hs);
            this.x.Controls.Add(this.btn_searchHs);
            this.x.Dock = System.Windows.Forms.DockStyle.Right;
            this.x.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(215)))), ((int)(((byte)(153)))));
            this.x.Location = new System.Drawing.Point(670, 0);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(405, 656);
            this.x.TabIndex = 95;
            // 
            // dtp_date
            // 
            this.dtp_date.BackColor = System.Drawing.Color.Transparent;
            this.dtp_date.BorderRadius = 20;
            this.dtp_date.Checked = true;
            this.dtp_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_date.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dtp_date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(155, 140);
            this.dtp_date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(238, 36);
            this.dtp_date.TabIndex = 102;
            this.dtp_date.Value = new System.DateTime(2024, 10, 12, 6, 37, 26, 931);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 18);
            this.label8.TabIndex = 101;
            this.label8.Text = "Ngày làm việc :";
            // 
            // txt_machamcong
            // 
            this.txt_machamcong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_machamcong.BackColor = System.Drawing.Color.Transparent;
            this.txt_machamcong.BorderRadius = 20;
            this.txt_machamcong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_machamcong.DefaultText = "";
            this.txt_machamcong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_machamcong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_machamcong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_machamcong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_machamcong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_machamcong.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_machamcong.ForeColor = System.Drawing.Color.Black;
            this.txt_machamcong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_machamcong.Location = new System.Drawing.Point(155, 13);
            this.txt_machamcong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_machamcong.Name = "txt_machamcong";
            this.txt_machamcong.PasswordChar = '\0';
            this.txt_machamcong.PlaceholderText = "";
            this.txt_machamcong.SelectedText = "";
            this.txt_machamcong.Size = new System.Drawing.Size(238, 36);
            this.txt_machamcong.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 18);
            this.label7.TabIndex = 99;
            this.label7.Text = "Mã chấm công :";
            // 
            // txt_manv
            // 
            this.txt_manv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_manv.BackColor = System.Drawing.Color.Transparent;
            this.txt_manv.BorderRadius = 20;
            this.txt_manv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_manv.DefaultText = "";
            this.txt_manv.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_manv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_manv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_manv.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_manv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_manv.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_manv.ForeColor = System.Drawing.Color.Black;
            this.txt_manv.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_manv.Location = new System.Drawing.Point(155, 73);
            this.txt_manv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.PasswordChar = '\0';
            this.txt_manv.PlaceholderText = "";
            this.txt_manv.SelectedText = "";
            this.txt_manv.Size = new System.Drawing.Size(238, 36);
            this.txt_manv.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "Mã nhân viên : ";
            // 
            // resetHs
            // 
            this.resetHs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetHs.BackColor = System.Drawing.Color.Transparent;
            this.resetHs.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.resetHs.Location = new System.Drawing.Point(342, 278);
            this.resetHs.Name = "resetHs";
            this.resetHs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.resetHs.Size = new System.Drawing.Size(46, 43);
            this.resetHs.TabIndex = 92;
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
            this.search_hs.Location = new System.Drawing.Point(21, 348);
            this.search_hs.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.search_hs.MaxLength = 40;
            this.search_hs.Name = "search_hs";
            this.search_hs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.search_hs.PasswordChar = '\0';
            this.search_hs.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.search_hs.PlaceholderText = "Search";
            this.search_hs.SelectedText = "";
            this.search_hs.Size = new System.Drawing.Size(300, 50);
            this.search_hs.TabIndex = 85;
            this.search_hs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_searchHs
            // 
            this.btn_searchHs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_searchHs.BackColor = System.Drawing.Color.Transparent;
            this.btn_searchHs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_searchHs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchHs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_searchHs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_searchHs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_searchHs.FillColor = System.Drawing.Color.Transparent;
            this.btn_searchHs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_searchHs.ForeColor = System.Drawing.Color.White;
            this.btn_searchHs.Image = global::QuanLyNhanSu.Properties.Resources.find;
            this.btn_searchHs.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_searchHs.Location = new System.Drawing.Point(342, 348);
            this.btn_searchHs.Name = "btn_searchHs";
            this.btn_searchHs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_searchHs.Size = new System.Drawing.Size(52, 50);
            this.btn_searchHs.TabIndex = 84;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChamCong,
            this.ID,
            this.HoTen,
            this.MaPB,
            this.NgayLamViec,
            this.LamViec});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(670, 656);
            this.dataGridView1.TabIndex = 96;
            // 
            // MaChamCong
            // 
            this.MaChamCong.DataPropertyName = "MaChamCong";
            this.MaChamCong.FillWeight = 30.75518F;
            this.MaChamCong.HeaderText = "Mã";
            this.MaChamCong.MinimumWidth = 12;
            this.MaChamCong.Name = "MaChamCong";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 88.68404F;
            this.ID.HeaderText = "Mã nhân viên";
            this.ID.MinimumWidth = 30;
            this.ID.Name = "ID";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.FillWeight = 173.0227F;
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.MinimumWidth = 30;
            this.HoTen.Name = "HoTen";
            // 
            // MaPB
            // 
            this.MaPB.DataPropertyName = "MaPB";
            this.MaPB.FillWeight = 104.9409F;
            this.MaPB.HeaderText = "Phòng ban";
            this.MaPB.MinimumWidth = 35;
            this.MaPB.Name = "MaPB";
            // 
            // NgayLamViec
            // 
            this.NgayLamViec.DataPropertyName = "NgayLamViec";
            this.NgayLamViec.FillWeight = 96.63217F;
            this.NgayLamViec.HeaderText = "Ngày làm việc";
            this.NgayLamViec.MinimumWidth = 35;
            this.NgayLamViec.Name = "NgayLamViec";
            // 
            // LamViec
            // 
            this.LamViec.DataPropertyName = "LamViec";
            this.LamViec.FillWeight = 96.63217F;
            this.LamViec.HeaderText = "Chấm công";
            this.LamViec.Name = "LamViec";
            // 
            // cb_chamcong
            // 
            this.cb_chamcong.Animated = true;
            this.cb_chamcong.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.cb_chamcong.CheckedState.BorderRadius = 0;
            this.cb_chamcong.CheckedState.BorderThickness = 0;
            this.cb_chamcong.CheckedState.FillColor = System.Drawing.Color.Black;
            this.cb_chamcong.Location = new System.Drawing.Point(155, 216);
            this.cb_chamcong.Name = "cb_chamcong";
            this.cb_chamcong.Size = new System.Drawing.Size(20, 20);
            this.cb_chamcong.TabIndex = 103;
            this.cb_chamcong.Text = "guna2CustomCheckBox1";
            this.cb_chamcong.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.cb_chamcong.UncheckedState.BorderRadius = 0;
            this.cb_chamcong.UncheckedState.BorderThickness = 2;
            this.cb_chamcong.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 104;
            this.label1.Text = "Chấm công :";
            // 
            // btn_deletehs
            // 
            this.btn_deletehs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deletehs.BackColor = System.Drawing.Color.Transparent;
            this.btn_deletehs.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btn_deletehs.Location = new System.Drawing.Point(242, 278);
            this.btn_deletehs.Name = "btn_deletehs";
            this.btn_deletehs.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_deletehs.Size = new System.Drawing.Size(46, 43);
            this.btn_deletehs.TabIndex = 105;
            // 
            // btn_chamcong
            // 
            this.btn_chamcong.BackColor = System.Drawing.Color.Transparent;
            this.btn_chamcong.BorderRadius = 25;
            this.btn_chamcong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_chamcong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_chamcong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_chamcong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_chamcong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_chamcong.FillColor = System.Drawing.Color.Cyan;
            this.btn_chamcong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chamcong.ForeColor = System.Drawing.Color.Black;
            this.btn_chamcong.Image = global::QuanLyNhanSu.Properties.Resources.checklist;
            this.btn_chamcong.Location = new System.Drawing.Point(21, 276);
            this.btn_chamcong.Name = "btn_chamcong";
            this.btn_chamcong.ShadowDecoration.BorderRadius = 30;
            this.btn_chamcong.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btn_chamcong.Size = new System.Drawing.Size(167, 45);
            this.btn_chamcong.TabIndex = 114;
            this.btn_chamcong.Text = "Chấm công";
            // 
            // ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 656);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.x);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChamCong";
            this.x.ResumeLayout(false);
            this.x.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel x;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_date;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txt_machamcong;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txt_manv;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2GradientCircleButton resetHs;
        private Guna.UI2.WinForms.Guna2TextBox search_hs;
        private Guna.UI2.WinForms.Guna2CircleButton btn_searchHs;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLamViec;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LamViec;
        private Guna.UI2.WinForms.Guna2CustomCheckBox cb_chamcong;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientCircleButton btn_deletehs;
        private Guna.UI2.WinForms.Guna2Button btn_chamcong;
    }
}