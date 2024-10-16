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
    public partial class ChamCong : Form
    {
        public ChamCong()
        {
            InitializeComponent();
            LoadData();
            dtp_date.Value = DateTime.Now;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void LoadData()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    CC.MaChamCong,
                    CC.IDnhanvien, 
                    NV.HoTen, 
                    PB.MaPB, 
                    CC.NgayLamViec,
                    CC.LamViec
                FROM 
                    ChamCong CC
                LEFT JOIN 
                    NhanVien NV ON CC.IDnhanvien = NV.ID
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB ORDER BY NgayLamViec";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Columns["NgayLamViec"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text) || string.IsNullOrWhiteSpace(dtp_date.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if (!int.TryParse(txt_manv.Text, out int idNhanVien))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Sai ID nhân viên!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_manv.Focus();
                return;
            }

            if (!cb_chamcong.Checked)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn trạng thái làm việc!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    txt_manv.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    // Kiểm tra xem ID nhân viên có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE ID = @IDnhanvien";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "ID nhân viên không tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            txt_manv.Focus();
                            return;
                        }
                    }

                    // Kiểm tra xem đã có bản ghi ChamCong với IDnhanvien và NgayLamViec chưa
                    string checkDuplicateQuery = @"
            SELECT COUNT(*) 
            FROM ChamCong 
            WHERE IDnhanvien = @IDnhanvien AND NgayLamViec = @NgayLamViec";
                    using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateQuery, connection))
                    {
                        checkDuplicateCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        checkDuplicateCommand.Parameters.AddWithValue("@NgayLamViec", dtp_date.Value);
                        int duplicateCount = (int)checkDuplicateCommand.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Đã tồn tại bản ghi cho nhân viên này vào ngày đã chọn!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    // Chèn bản ghi mới vào ChamCong
                    string query = @"
            INSERT INTO ChamCong (IDnhanvien, NgayLamViec, LamViec)
            VALUES (@IDnhanvien, @NgayLamViec, @LamViec)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        command.Parameters.AddWithValue("@NgayLamViec", dtp_date.Value);
                        command.Parameters.AddWithValue("@LamViec", cb_chamcong.Checked);
                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadData();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }


        private void reset()
        {
            txt_manv.Text = string.Empty;
            txt_manv.Enabled = true;
            dtp_date.Value = DateTime.Now;
            cb_chamcong.Checked = false;
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_deletehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            // Mở hộp hỏi có chắc chắn muốn xóa
            Question questionForm = new Question();
            questionForm.QuestionText = "Xóa chấm công này không?";
            questionForm.OkButtonText = "Có";
            if (questionForm.ShowDialog() == DialogResult.OK)
            {
                // Tiến hành xóa
                using (SqlConnection connection = connectdatabase.Connect())
                {
                    if (connection == null)
                    {
                        Error error = new Error();
                        error.ErrorText = "Lỗi kết nối Database!";
                        error.OkButtonText = "OK";
                        error.ShowDialog();
                        return;
                    }

                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM ChamCong WHERE IDnhanvien = @IDnhanvien AND NgayLamViec = @NgayLamViec";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDnhanvien", dataGridView1.CurrentRow.Cells["IDnhanvien"].Value);
                            command.Parameters.AddWithValue("@NgayLamViec", dataGridView1.CurrentRow.Cells["NgayLamViec"].Value); // Thêm điều kiện NgàyLamViec
                            command.ExecuteNonQuery();
                            Success sc = new Success();
                            sc.ShowDialog();
                            LoadData();
                            reset();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["NgayLamViec"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayLamViec"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["LamViec"].Value != null)
                {
                    string lamViecStatus = row.Cells["LamViec"].Value.ToString();
                    cb_chamcong.Checked = lamViecStatus.Equals("True", StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        private void search(string searchValue)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error
                    {
                        ErrorText = "Lỗi kết nối Database!",
                        OkButtonText = "OK"
                    };
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();
                    string query = @"SELECT DISTINCT CC.IDnhanvien, NV.HoTen, PB.MaPB, CC.NgayLamViec, CC.LamViec
                             FROM ChamCong CC
                             LEFT JOIN NhanVien NV ON CC.IDnhanvien = NV.ID
                             LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB
                             WHERE 
                                CC.IDnhanvien LIKE @searchValue OR 
                                NV.HoTen LIKE @searchValue OR 
                                PB.MaPB LIKE @searchValue OR 
                                CC.NgayLamViec LIKE @searchValue 
                             ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.Columns["NgayLamViec"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy kết quả .",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            search(search_hs.Text);
        }

        private void thongke()
        {
            // Lấy giá trị tháng năm từ textbox
            string date = txt_thongke.Text.Trim();
            if (string.IsNullOrEmpty(date))
            {
                Notification notification = new Notification
                {
                    NotificationText = "Vui lòng nhập tháng năm để thực hiện !",
                    OkButtonText = "OK"
                };
                notification.ShowDialog();
                txt_thongke.Focus();
                return;
            }

            // Kiểm tra định dạng tháng năm
            if (!DateTime.TryParse(date, out DateTime thangNam))
            {
                Notification notification = new Notification
                {
                    NotificationText = "Vui lòng nhập tháng năm hợp lệ !",
                    OkButtonText = "OK"
                };
                notification.ShowDialog();
                txt_thongke.Focus();
                txt_thongke.HoverState.BorderColor = Color.Red;
                return;
            }

            // Lấy ID nhân viên
            if (!int.TryParse(search_hs.Text.Trim(), out int idNhanVien))
            {
                Notification notification = new Notification
                {
                    NotificationText = "Vui lòng nhập ID nhân viên hợp lệ !",
                    OkButtonText = "OK"
                };
                notification.ShowDialog();
                search_hs.Focus();
                search_hs.HoverState.BorderColor = Color.Red;
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error
                    {
                        ErrorText = "Lỗi kết nối Database!",
                        OkButtonText = "OK"
                    };
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    NV.HoTen,
                    COUNT(CC.LamViec) AS TongNgayCong
                FROM 
                    ChamCong CC
                LEFT JOIN 
                    NhanVien NV ON CC.IDnhanvien = NV.ID
                WHERE 
                    CC.IDnhanvien = @IDnhanvien 
                    AND MONTH(CC.NgayLamViec) = MONTH(@ThangNam) 
                    AND YEAR(CC.NgayLamViec) = YEAR(@ThangNam)
                    AND CC.LamViec = 1
                GROUP BY 
                    NV.HoTen";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        command.Parameters.AddWithValue("@ThangNam", thangNam);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            richTextBox1.Clear(); // Xóa nội dung cũ
                            if (reader.Read()) // Chỉ đọc một dòng
                            {
                                // Lấy thông tin từ reader
                                string hoTen = reader["HoTen"].ToString();

                                // Kiểm tra và lấy giá trị tổng ngày công
                                object ngaycongvalue = reader["TongNgayCong"];
                                float tongngaycong = ngaycongvalue is DBNull ? 0 : Convert.ToSingle(ngaycongvalue);

                                // Chuyển đổi float sang string với định dạng
                                string tongngaycongString = tongngaycong.ToString();

                                // Hiển thị thông tin trong RichTextBox
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText($"Tổng ngày công tháng {thangNam.ToString("MM/yyyy")} của nhân viên:\n\n");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText($"\tID Nhân viên: {idNhanVien}\n");
                                richTextBox1.AppendText($"\tHọ tên: {hoTen}\n");
                                richTextBox1.AppendText($"\tTổng ngày công: {tongngaycongString}\n");
                                richTextBox1.AppendText("=======================================");
                            }
                            else
                            {
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.ForeColor = Color.Red;
                                richTextBox1.Text = $"*Không có kết quả thống kê chấm công {thangNam.ToString("MM/yyyy")} cho nhân viên này !";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            thongke();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
