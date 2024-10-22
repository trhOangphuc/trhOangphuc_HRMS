using QuanLyNhanSu.Dialog;
using System;
using System.Collections;
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
            cmb_trangthai.Items.Add("Đúng giờ");
            cmb_trangthai.Items.Add("Đi muộn");
            cmb_trangthai.StartIndex = -1;
            cb_nghi.Enabled = false;
            cb_dilam.Enabled = false;
            if (cb_dilam.Checked == false)
            {
                cb_chamcong.Enabled = false;
            }
            dtp_date.ValueChanged += dtp_date_ValueChanged;
            KiemTraNgayNghi();
        }

        private void KiemTraNgayNghi()
        {
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

                    // Lấy ngày được chọn từ DateTimePicker (dtp_date)
                    DateTime ngayDuocChon = dtp_date.Value.Date;

                    // Truy vấn kiểm tra xem ngày được chọn có tồn tại trong bảng NgayNghiLe
                    string query = "SELECT COUNT(*) FROM NgayNghiLe WHERE Ngay = @Ngay";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Gán tham số Ngay cho câu truy vấn
                        command.Parameters.AddWithValue("@Ngay", ngayDuocChon);

                        // Thực hiện truy vấn và lấy kết quả
                        int count = (int)command.ExecuteScalar();

                        // Nếu có kết quả (ngày được chọn là ngày nghỉ)
                        if (count > 0)
                        {
                            // Ngày nghỉ, đánh dấu checkbox tương ứng
                            cb_nghi.Checked = true;
                            cb_dilam.Checked = false;
                        }
                        else
                        {
                            // Ngày làm việc, đánh dấu checkbox tương ứng
                            cb_nghi.Checked = false;
                            cb_dilam.Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bắt và hiển thị lỗi nếu có
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
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
                    CC.LamViec,
                    CC.TrangThai
                FROM 
                    ChamCong CC
                LEFT JOIN 
                    NhanVien NV ON CC.IDnhanvien = NV.ID
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB ORDER BY IDnhanvien, NgayLamViec";
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
            if (cb_nghi.Checked == true)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Ngày nghỉ không thể chấm công !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_manv.Text) || string.IsNullOrWhiteSpace(dtp_date.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_manv.Focus();
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

            if (cmb_trangthai.SelectedItem == null || string.IsNullOrWhiteSpace(cmb_trangthai.SelectedItem.ToString()))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn trạng thái ngày công!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                cmb_trangthai.Focus();
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

            if (dtp_date.Value.Date != DateTime.Now.Date)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chấm công cho ngày hôm nay!";
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

                    string checkHolidayQuery = @"
                       SELECT COUNT(*) 
                       FROM NgayNghiLe 
                       WHERE Ngay = @NgayLamViec";
                    using (SqlCommand checkHolidayCommand = new SqlCommand(checkHolidayQuery, connection))
                    {
                        checkHolidayCommand.Parameters.AddWithValue("@NgayLamViec", dtp_date.Value);
                        int isHoliday = (int)checkHolidayCommand.ExecuteScalar();

                        if (isHoliday > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Ngày nghỉ không thể chấm công!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    
                    string checkDuplicateQuery = @"
                        SELECT COUNT(*) 
                        FROM ChamCong 
                        WHERE IDnhanvien = @IDnhanvien AND CAST(NgayLamViec AS DATE) = @NgayLamViec";
                    using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateQuery, connection))
                    {
                        checkDuplicateCommand.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        checkDuplicateCommand.Parameters.AddWithValue("@NgayLamViec", dtp_date.Value.Date);
                        int duplicateCount = (int)checkDuplicateCommand.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Nhân viên đã chấm công cho ngày hôm nay!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }


                    string query = @"
                        INSERT INTO ChamCong (IDnhanvien, NgayLamViec, LamViec, TrangThai)
                        VALUES (@IDnhanvien, @NgayLamViec, @LamViec, @TrangThai)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        command.Parameters.AddWithValue("@NgayLamViec", dtp_date.Value);
                        command.Parameters.AddWithValue("@LamViec", cb_chamcong.Checked);
                        command.Parameters.AddWithValue("@TrangThai", cmb_trangthai.Text);
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
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  
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
            cb_chamcong.Checked = true;
            dtp_date.Enabled = true;
            dataGridView1.ClearSelection();
            cmb_trangthai.SelectedIndex = -1;
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
            Question questionForm = new Question();
            questionForm.QuestionText = "Xóa chấm công này không?";
            questionForm.OkButtonText = "Có";
            if (questionForm.ShowDialog() == DialogResult.OK)
            {
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
                            command.Parameters.AddWithValue("@NgayLamViec", dataGridView1.CurrentRow.Cells["NgayLamViec"].Value);
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
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message; 
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
                        dtp_date.Enabled = false;
                    }
                }
                if (row.Cells["LamViec"].Value != null)
                {
                    string lamViecStatus = row.Cells["LamViec"].Value.ToString();
                    cb_chamcong.Checked = lamViecStatus.Equals("True", StringComparison.OrdinalIgnoreCase);
                    cb_chamcong.Enabled = false;
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
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            search(search_hs.Text);
        }
        private int TinhSoNgayLamViec()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int totalDaysInMonth = DateTime.DaysInMonth(year, month); // Tổng số ngày trong tháng hiện tại
            int workingDays = 0; // Số ngày làm việc

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    throw new Exception("Lỗi kết nối Database!");
                }

                connection.Open();

                // Lấy danh sách ngày nghỉ lễ từ cơ sở dữ liệu
                HashSet<DateTime> holidays = new HashSet<DateTime>();
                string holidayQuery = "SELECT Ngay FROM NgayNghiLe"; // Giả định bạn có bảng NgayNghiLe
                using (SqlCommand holidayCommand = new SqlCommand(holidayQuery, connection))
                {
                    using (SqlDataReader reader = holidayCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            holidays.Add(reader.GetDateTime(0).Date); // Thêm ngày nghỉ vào HashSet
                        }
                    }
                }

                // Tính số ngày làm việc
                for (int day = 1; day <= totalDaysInMonth; day++)
                {
                    DateTime currentDate = new DateTime(year, month, day);
                    // Kiểm tra xem ngày hiện tại có phải là thứ Bảy, Chủ Nhật hoặc ngày nghỉ không
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                        currentDate.DayOfWeek != DayOfWeek.Sunday &&
                        !holidays.Contains(currentDate.Date))
                    {
                        workingDays++; // Tăng số ngày làm việc nếu không phải thứ Bảy, Chủ Nhật hoặc ngày nghỉ
                    }
                }
            }

            return workingDays;
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
                    COUNT(CASE WHEN CC.TrangThai = N'Đúng giờ' THEN 1 END) AS SoNgayDungGio,
                    COUNT(CASE WHEN CC.TrangThai = N'Đi muộn' THEN 1 END) AS SoNgayDiMuon,
                    COUNT(CC.LamViec) AS TongNgayCong
                FROM 
                    ChamCong CC
                LEFT JOIN 
                    NhanVien NV ON CC.IDnhanvien = NV.ID
                WHERE 
                    CC.IDnhanvien = @IDnhanvien 
                    AND MONTH(CC.NgayLamViec) = MONTH(@ThangNam) 
                    AND YEAR(CC.NgayLamViec) = YEAR(@ThangNam)
                GROUP BY 
                    NV.HoTen;
";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        command.Parameters.AddWithValue("@ThangNam", thangNam);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            richTextBox1.Clear();
                            richTextBox1.ForeColor = Color.Black;
                            if (reader.Read())
                            {
                                // Lấy thông tin từ reader
                                string hoTen = reader["HoTen"].ToString();
                                int tongNgayChamCong = TinhSoNgayLamViec(); // Lưu ý: phương thức này cần được kiểm tra để đảm bảo trả về giá trị chính xác
                                int tongNgayCong = Convert.ToInt32(reader["TongNgayCong"]);
                                int soNgayDungGio = Convert.ToInt32(reader["SoNgayDungGio"]);
                                int soNgayDiMuon = Convert.ToInt32(reader["SoNgayDiMuon"]);

                                // Hiển thị thông tin trong RichTextBox
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText($"Tổng ngày công {thangNam.ToString("MM/yyyy")} của nhân viên:\n");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText($"\tID Nhân viên: {idNhanVien}\n");
                                richTextBox1.AppendText($"\tHọ tên: {hoTen}\n");
                                richTextBox1.AppendText($"\tTổng ngày công: {tongNgayCong}/{tongNgayChamCong}\n");

                                // Thống kê điều kiện
                                richTextBox1.AppendText($"\tTổng ngày công: {tongNgayCong}\n\tTổng ngày làm việc: {tongNgayChamCong}\n\tNgày đúng giờ: {soNgayDungGio}\n\tNgày đi muộn: {soNgayDiMuon}\n");

                                if (tongNgayCong == tongNgayChamCong)
                                {
                                    if (soNgayDungGio == tongNgayChamCong) // Số ngày đi làm đúng giờ
                                    {
                                        richTextBox1.AppendText("\tKhen thưởng: Đạt điều kiện đi làm đúng giờ và đủ ngày công.\n");
                                    }
                                    else
                                    {
                                        richTextBox1.AppendText("\tKhen thưởng: Chưa đạt điều kiện đi làm đúng giờ.\n");
                                    }
                                }
                                else if (tongNgayCong < tongNgayChamCong / 2)
                                {
                                    richTextBox1.AppendText("\tKỷ luật: Thiếu ngày công.\n");
                                }

                                // Kiểm tra điều kiện "Đi muộn" nhiều
                                if (soNgayDiMuon >= tongNgayCong / 2)
                                {
                                    richTextBox1.AppendText("\tKỷ luật: Đi muộn nhiều.\n");
                                }
                                else
                                {
                                    richTextBox1.AppendText("\tChấm công bình thường.\n");
                                }

                                // Kiểm tra nếu số ngày "Đúng giờ" bằng tổng số ngày công
                                if (soNgayDungGio == tongNgayCong)
                                {
                                    richTextBox1.AppendText("\tChấm công đủ: Nhân viên đi làm đúng giờ đủ ngày.\n");
                                }

                                richTextBox1.AppendText("=====================================");
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
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;
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

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để sửa !";
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

            if (cmb_trangthai.SelectedItem == null || string.IsNullOrWhiteSpace(cmb_trangthai.SelectedItem.ToString()))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn trạng thái ngày công!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                cmb_trangthai.Focus();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database!";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    txt_manv.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    string checkDuplicateQuery = @"
                        SELECT COUNT(*) 
                        FROM ChamCong 
                        WHERE MaChamCong = @MaChamCong AND IDnhanvien = @IDnhanvien AND NgayLamViec = @NgayLamViec";
                    using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateQuery, connection))
                    {
                        checkDuplicateCommand.Parameters.AddWithValue("@MaChamCong", dataGridView1.CurrentRow.Cells["MaChamCong"].Value);
                        checkDuplicateCommand.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
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

                    string updateQuery = @"
                UPDATE ChamCong
                SET TrangThai = @TrangThai
                Where MaChamCong = @MaChamCong AND
                IDnhanvien = @IDnhanvien AND NgayLamViec = @NgayLamViec ";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaChamCong", dataGridView1.CurrentRow.Cells["MaChamCong"].Value);
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        command.Parameters.AddWithValue("@TrangThai", cmb_trangthai.Text);
                        command.Parameters.AddWithValue("@NgayLamViec", dataGridView1.CurrentRow.Cells["NgayLamViec"].Value);
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
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void cmb_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            KiemTraNgayNghi();
        }
    }
}
