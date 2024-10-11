using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Account : Form
    {
        public delegate void ProfilePictureChangedHandler(string filePath);
        public event ProfilePictureChangedHandler ProfilePictureChanged;

        private int userId; // Biến để lưu ID người dùng

        // Constructor nhận ID người dùng
        public Account(int userId)
        {
            InitializeComponent();
            this.userId = userId; // Lưu ID người dùng
            LoadUserInfo(); // Gọi hàm tải thông tin người dùng
        }

        private void LoadUserInfo()
        {
            using (SqlConnection connection = connectdatabase.Connect()) // Kết nối đến cơ sở dữ liệu
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "SELECT Picture, TenTK FROM TaiKhoan WHERE ID = @ID"; // Truy vấn dữ liệu
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", userId); // Sử dụng ID người dùng đã truyền vào
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Lấy thông tin người dùng
                            string name = dataTable.Rows[0]["TenTK"].ToString(); // Sử dụng TenTK
                            string imagePath = dataTable.Rows[0]["Picture"].ToString(); // Giả định rằng đường dẫn là chuỗi

                            // Cập nhật vào control
                            txt_name.Text = name; // txt_name là tên TextBox hiển thị tên
                            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath)) // Kiểm tra file có tồn tại không
                            {
                                img_prf.Image = Image.FromFile(imagePath); // img_prf là PictureBox
                                img_prf.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Cập nhật hình ảnh trong img_prf
                img_prf.Image = Image.FromFile(filePath);
                img_prf.SizeMode = PictureBoxSizeMode.StretchImage;

                // Kích hoạt sự kiện ProfilePictureChanged
                ProfilePictureChanged?.Invoke(filePath); // Gửi filePath đến HomPage

                // Cập nhật đường dẫn hình ảnh vào cơ sở dữ liệu
                UpdateProfilePictureInDatabase(filePath);
            }
        }

        private void UpdateProfilePictureInDatabase(string filePath)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "UPDATE TaiKhoan SET Picture = @filePath WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@filePath", filePath);
                        command.Parameters.AddWithValue("@ID", userId); // Sử dụng ID người dùng đã truyền vào
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật hình ảnh: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện nếu cần
        }
    }
}
