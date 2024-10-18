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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyNhanSu
{
    public partial class HomPagePanel : Form
    {

        private bool isUpdatingCheckboxes = false; // Biến cờ để theo dõi trạng thái cập nhật
        public HomPagePanel()
        {
            InitializeComponent();
            LoadTongNhanVien();
            LoadTongPhongBan();
            LoadQuyHienTai();
            LoadChartNhanVien();
            LoadChartPhongBan();
            LoadChamCong();
            dtp_date.Value = DateTime.Now;
            dtp_date2.Value = DateTime.Now;
            chart_nhanvien.ChartAreas[0].BackColor = Color.Transparent;
            chart_phongban.ChartAreas[0].BackColor = Color.Transparent;
            KiemTraNgayNghi();
        }

        private void KiemTraNgayNghi()
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
                    DateTime ngayHienTai = DateTime.Now.Date;

                    string query = "SELECT COUNT(*) FROM NgayNghiLe WHERE Ngay = @NgayHienTai";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);
                        int count = (int)command.ExecuteScalar();

                        // Thiết lập trạng thái checkbox dựa trên kết quả
                        isUpdatingCheckboxes = true; // Đánh dấu đang trong quá trình cập nhật checkbox

                        // Nếu có kết quả (ngày hiện tại là ngày nghỉ)
                        cb_nghi.Checked = count > 0; // Đánh dấu là ngày nghỉ
                        cb_dilam.Checked = count == 0; // Đánh dấu là ngày đi làm

                        isUpdatingCheckboxes = false; // Kết thúc quá trình cập nhật checkbox
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


        private void LoadChamCong()
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

                    // Lấy ngày từ DateTimePicker
                    DateTime selectedDate = dtp_date.Value.Date; // Lấy giá trị ngày từ DateTimePicker

                    string query = @"
            SELECT COUNT(*) 
            FROM ChamCong 
            WHERE CONVERT(DATE, NgayLamViec) = @NgayLamViec AND LamViec = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số kiểu DateTime cho truy vấn
                        command.Parameters.AddWithValue("@NgayLamViec", selectedDate); // Đảm bảo chỉ truyền phần ngày

                        // Lấy số lượng nhân viên làm việc (LamViec = true)
                        int count = (int)command.ExecuteScalar();

                        // Hiển thị kết quả vào lb_chamcong
                        lb_chamcong.Text = count.ToString();
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


        private void LoadTongNhanVien()
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
                    string query = "SELECT COUNT(*) FROM NhanVien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar(); 
                        lb_tongnv.Text = count.ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTongPhongBan()
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
                    string query = "SELECT COUNT(*) FROM PhongBan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        lb_tongpb.Text = count.ToString();
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
        private void LoadQuyHienTai()
        {
            int month = DateTime.Now.Month; 
            int quy = (month - 1) / 3 + 1;
            lb_quy.Text = $"{quy}"; 
        }

        private void LoadChartNhanVien()
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
                    // Đếm số lượng nhân viên dựa trên giới tính và ID
                    string query = "SELECT GioiTinh, COUNT(ID) AS SoLuong FROM NhanVien GROUP BY GioiTinh";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        chart_nhanvien.Series.Clear();
                        chart_nhanvien.ChartAreas.Clear();
                        chart_nhanvien.ChartAreas.Add(new ChartArea("NhanVienChartArea"));

                        Series series = new Series("NhanVien");
                        series.ChartType = SeriesChartType.Pie;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            series.Points.AddXY(row["GioiTinh"].ToString(), row["SoLuong"]);
                        }

                        chart_nhanvien.Series.Add(series); 
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

        private void LoadChartPhongBan()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error
                    {
                        ErrorText = "Lỗi kết nối Database !",
                        OkButtonText = "OK"
                    };
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();

                    // Đếm số lượng nhân viên theo phòng ban từ bảng NhanVien và PhongBan
                    string query = @"
                SELECT pb.MaPB, COUNT(nv.ID) AS SoLuong 
                FROM PhongBan pb
                LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
                GROUP BY pb.MaPB";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Kiểm tra xem có dữ liệu hay không
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu để hiển thị cho biểu đồ số nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Thiết lập biểu đồ
                        chart_phongban.Series.Clear();
                        chart_phongban.ChartAreas.Clear();
                        chart_phongban.ChartAreas.Add(new ChartArea("NhanVienChartArea"));

                        Series series = new Series("SoLuongNhanVien")
                        {
                            ChartType = SeriesChartType.Pie // Thiết lập loại biểu đồ là hình tròn
                        };

                        // Thêm dữ liệu vào biểu đồ
                        foreach (DataRow row in dataTable.Rows)
                        {
                            series.Points.AddXY(row["MaPB"].ToString(), row["SoLuong"]);
                        }

                        chart_phongban.Series.Add(series);

                        // Tắt hiển thị nhãn cho từng điểm
                        foreach (DataPoint point in series.Points)
                        {
                            point.Label = ""; // Tắt hiển thị nhãn cho từng điểm
                        }

                        // Ngăn hiển thị giá trị trên các phần của biểu đồ
                        series.IsValueShownAsLabel = false; // Ngăn hiển thị giá trị trên các phần của biểu đồ

                        // Tắt hiển thị nhãn bên trong (nếu có)
                        foreach (DataPoint point in series.Points)
                        {
                            point.IsValueShownAsLabel = false; // Ngăn hiển thị giá trị cho từng điểm
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


        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            LoadChamCong();
        }

        private void lb_chamcong_Click(object sender, EventArgs e)
        {

        }



        private void dtp_date2_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckboxes) return; // Thoát nếu đang trong quá trình cập nhật checkbox

            try
            {
                isUpdatingCheckboxes = true; // Bắt đầu cập nhật checkbox

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

                    connection.Open();
                    DateTime selectedDate = dtp_date2.Value.Date;

                    string query = "SELECT COUNT(*) FROM NgayNghiLe WHERE Ngay = @SelectedDate";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedDate", selectedDate);
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            cb_nghi.Checked = true;
                            cb_dilam.Checked = false;
                        }
                        else
                        {
                            cb_nghi.Checked = false;
                            cb_dilam.Checked = true;
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
            finally
            {
                isUpdatingCheckboxes = false; // Kết thúc cập nhật checkbox
            }
        }

        private void cb_dilam_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckboxes) return; // Thoát nếu đang trong quá trình cập nhật checkbox

            // Tiếp tục nếu cần thay đổi
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
                    DateTime ngayHienTai = DateTime.Now.Date;

                    if (cb_nghi.Checked)
                    {
                        string deleteQuery = "DELETE FROM NgayNghiLe WHERE Ngay = @NgayHienTai";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);
                            deleteCommand.ExecuteNonQuery();
                            Notification notification = new Notification();
                            notification.NotificationText = "Đã thay đổi trạng thái công ty đi làm!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
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

        private void cb_nghi_CheckedChanged(object sender, EventArgs e)
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

                    // Lấy ngày hiện tại
                    DateTime ngayHienTai = DateTime.Now.Date;

                    if (cb_nghi.Checked)
                    {
                        // Kiểm tra xem ngày đã tồn tại trong NgayNghiLe chưa
                        string checkQuery = "SELECT COUNT(*) FROM NgayNghiLe WHERE Ngay = @NgayHienTai";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count == 0)
                            {
                                // Nếu chưa tồn tại, thêm ngày vào bảng NgayNghiLe
                                string insertQuery = "INSERT INTO NgayNghiLe (Ngay) VALUES (@NgayHienTai)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);
                                    insertCommand.ExecuteNonQuery();

                                    Notification notification = new Notification();
                                    notification.NotificationText = "Đã thay đổi trạng thái công ty nghỉ!";
                                    notification.OkButtonText = "OK";
                                    notification.ShowDialog();
                                }
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


        private int TinhSoNgayLamViec()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int totalDaysInMonth = DateTime.DaysInMonth(year, month); // Tổng số ngày trong tháng hiện tại
            int workingDays = 0; // Số ngày làm việc

            for (int day = 1; day <= totalDaysInMonth; day++)
            {
                DateTime currentDate = new DateTime(year, month, day);
                // Kiểm tra xem ngày hiện tại có phải là thứ Bảy (6) hoặc Chủ Nhật (0) không
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++; // Tăng số ngày làm việc nếu không phải thứ Bảy hoặc Chủ Nhật
                }
            }

            return workingDays;
        }

        private int LaySoNgayNghi()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    // Xử lý lỗi kết nối
                    return 0;
                }

                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM NgayNghiLe WHERE MONTH(Ngay) = @Month AND YEAR(Ngay) = @Year";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                        command.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    // Xử lý lỗi
                    return 0;
                }
            }
        }

        public int TinhSoNgayLamViecThucTe()
        {
            int workingDays = TinhSoNgayLamViec(); // Tính số ngày làm việc
            int daysOff = LaySoNgayNghi(); // Lấy số ngày nghỉ từ cơ sở dữ liệu
            return workingDays - daysOff; // Trừ số ngày nghỉ
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void HomPagePanel_Load(object sender, EventArgs e)
        {
            lb_thang.Text = DateTime.Now.Month.ToString();

            // Cập nhật số ngày làm việc thực tế vào label lb_ngaychamcong
            lb_ngaychamcong.Text = TinhSoNgayLamViec().ToString();

            // Cập nhật tổng số ngày làm việc (không tính thứ Bảy và Chủ Nhật)
            lb_tongngay.Text = TinhSoNgayLamViec().ToString();
        }

        private void add_hs_Click(object sender, EventArgs e)
        {
            string lyDo = txt_lydo.Text;

            if (string.IsNullOrWhiteSpace(lyDo))
            {
                Notification tb = new Notification();
                tb.NotificationText = "Vui lòng nhập lý do!";
                tb.OkButtonText = "OK";
                tb.ShowDialog();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if(cb_nghi.Checked == false)
                {
                    Notification tb = new Notification();
                    tb.NotificationText = "Ngày này công ty đang đi làm!";
                    tb.OkButtonText = "OK";
                    tb.ShowDialog();
                }
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

                    string insertQuery = "INSERT INTO NgayNghiLe (Ngay, LyDo) VALUES (@Ngay, @LyDo)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Ngay", dtp_date2.Value);
                        insertCommand.Parameters.AddWithValue("@LyDo", lyDo);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Lưu thành công!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm lý do vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
