namespace QuanLyNhanSu
{
    partial class Account
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.img_prf = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_prf)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thông tin tài khoản";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.Location = new System.Drawing.Point(327, 408);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên người dùng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_name
            // 
            this.txt_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(498, 408);
            this.txt_name.Name = "txt_name";
            this.txt_name.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.txt_name.Size = new System.Drawing.Size(219, 25);
            this.txt_name.TabIndex = 4;
            this.txt_name.Text = "Tên tài khoản";
            this.txt_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_name.Click += new System.EventHandler(this.label3_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Image = global::QuanLyNhanSu.Properties.Resources.camera;
            this.guna2CircleButton1.ImageOffset = new System.Drawing.Point(0, 20);
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2CircleButton1.Location = new System.Drawing.Point(630, 246);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(48, 48);
            this.guna2CircleButton1.TabIndex = 1;
            this.guna2CircleButton1.Text = "guna2CircleButton1";
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.img_prf);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_name);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2CircleButton1);
            this.guna2CustomGradientPanel1.Controls.Add(this.label2);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(50, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1025, 656);
            this.guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // img_prf
            // 
            this.img_prf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.img_prf.Image = global::QuanLyNhanSu.Properties.Resources.bussiness_man;
            this.img_prf.ImageRotate = 0F;
            this.img_prf.Location = new System.Drawing.Point(408, 93);
            this.img_prf.Name = "img_prf";
            this.img_prf.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.img_prf.Size = new System.Drawing.Size(216, 201);
            this.img_prf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_prf.TabIndex = 0;
            this.img_prf.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1075, 656);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Account";
            this.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_prf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_name;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox img_prf;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}