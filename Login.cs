using QuanLyNhanSu.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            Question questionForm = new Question();
            questionForm.QuestionText = "thoát không?";
            questionForm.OkButtonText = "Có"; 

            if (questionForm.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        bool loginSuccess = false;

        private void Login_login_Click(object sender, EventArgs e)
        {
            loginSuccess = CheckLogin(Login_user.Text, Login_passwd.Text);


            if (loginSuccess)
            {
                pictureBox1.Image = QuanLyNhanSu.Properties.Resources.icons8_jake;
            }
            else
            {
                pictureBox1.Image = QuanLyNhanSu.Properties.Resources.loginfalse;
                thongbao.Text = "Sai tài khoản hoặc mật khẩu !";
                thongbao.ForeColor = Color.Red;
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng kiểm tra lại thông tin đăng nhập !";
                notification.OkButtonText = "OK";
                if(notification.ShowDialog() == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private bool CheckLogin(string username, string password)
        {
            return username == "admin" && password == "123456"; 
        }

        private bool isPasswordVisible = false;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; // Đảo trạng thái

            if (isPasswordVisible)
            {
                // Hiển thị mật khẩu
                Login_passwd.PasswordChar = '\0'; // Hiển thị văn bản
            }
            else
            {
                // Ẩn mật khẩu
                Login_passwd.PasswordChar = '*'; // Ẩn văn bản
            }
        }
    }
}
