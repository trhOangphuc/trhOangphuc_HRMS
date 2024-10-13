using QuanLyNhanSu.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Hàm kiểm tra tính hợp lệ của mật khẩu
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false; // Kiểm tra độ dài
            if (!password.Any(char.IsUpper)) return false; // Kiểm tra chữ hoa
            if (!password.Any(char.IsLower)) return false; // Kiểm tra chữ thường
            if (!password.Any(char.IsDigit)) return false; // Kiểm tra số
            if (!password.Any(c => !char.IsLetterOrDigit(c))) return false; // Kiểm tra ký tự đặc biệt
            return true;
        }

        private void Login_login_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string comfirmpassword = txt_comfirm.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(comfirmpassword))
            {
                lb_thongbao.Text = "*Vui lòng điền đầy đủ thông tin !";
                lb_thongbao.ForeColor = Color.Red;
                if (string.IsNullOrEmpty(name))
                {
                    txt_name.Focus(); 
                }
                if (string.IsNullOrEmpty(username))
                {
                    txt_username.Focus(); 
                }
                else if (string.IsNullOrEmpty(password))
                {
                    txt_password.Focus();
                }
                else if (string.IsNullOrEmpty(comfirmpassword))
                {
                    txt_comfirm.Focus(); 
                }

                return;
            }
            if (password != comfirmpassword)
            {
                lb_thongbao.Text = "*Mật khẩu nhập lại chưa chính xác !";
                lb_thongbao.ForeColor = Color.Red;
                txt_password.Focus();
                return;
            }
            if (!IsValidPassword(password))
            {
                lb_thongbao.Text = "Mật khẩu không hợp lệ: \n*Phải có ít nhất 8 ký tự, \n*Bao gồm chữ hoa, \n*Chữ thường, \n*Số và ký tự đặc biệt!";
                lb_thongbao.ForeColor = Color.Red;
                txt_password.Focus();
                return;
            }
            if (IsValidPassword(password) && password == comfirmpassword)
                if (password == comfirmpassword)
            {
                using (SqlConnection connection = connectdatabase.Connect())
                {
                    if (connection == null)
                    {
                        Error error = new Error();
                        error.ErrorText = "Lỗi kết nối Database !";
                        error.OkButtonText = "OK";

                        if (error.ShowDialog() == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                        return;
                    }

                    try
                    {
                        connection.Open();
                        string checkUserQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan";
                        using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, connection))
                          {
                            checkUserCmd.Parameters.AddWithValue("@TaiKhoan", username);
                            int userCount = (int)checkUserCmd.ExecuteScalar();
                             if (userCount > 0) 
                             {
                                lb_thongbao.Text = "*Tên tài khoản đã tồn tại!";
                                lb_thongbao.ForeColor = Color.Red;
                                txt_username.Focus();
                                return;
                             }
                        }

                        string query = "INSERT INTO TaiKhoan (TenTK, TaiKhoan, MatKhau) VALUES (@TenTK, @TaiKhoan, @MatKhau)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", name);
                            command.Parameters.AddWithValue("@TenTK", name);
                            command.Parameters.AddWithValue("@TaiKhoan", username);
                            command.Parameters.AddWithValue("@MatKhau", password);

                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                Success sc = new Success();
                                sc.ShowDialog();
                                Login login = new Login();
                                login.Show();
                                this.Close();
                                return;
                            }
                            else
                            {
                                Error error = new Error();
                                error.ErrorText = "Lỗi không thêm được !";
                                error.OkButtonText = "OK";

                                if (error.ShowDialog() == DialogResult.OK)
                                {
                                    Application.Exit();
                                }
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void lb_thongbao_Click(object sender, EventArgs e)
        {

        }
    }
}
