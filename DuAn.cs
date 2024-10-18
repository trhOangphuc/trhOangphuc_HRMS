using QuanLyNhanSu.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class DuAn : Form
    {
        public DuAn()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dtp_dateStart.Value = DateTime.Now;
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
                    string query = "SELECT MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, PhuCapDuAn, GhiChu FROM DuAn ORDER BY MaDuAn";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridView1.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private void Reset()
        {
            txt_mada.Enabled = true;
            txt_mada.Text = "";
            txt_phucapDA.Text = string.Empty;
            txt_tenda.Text = string.Empty;
            txt_dateEnd.Text = string.Empty;   
            dtp_dateStart.Value = DateTime.Now;
            dtp_dateStart.Enabled = true;
            txt_ghichu.Text = "";
            search_duan.Text = string.Empty;
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void add_hs_Click(object sender, EventArgs e)
        {
            if(txt_ghichu.Text.Trim().Length > 100)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ký tự ghi chú nhỏ hơn 100 !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_ghichu.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_phucapDA.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập phụ cấp!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_phucapDA.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_tenda.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập tên dự án!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_tenda.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ghichu.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ghi chú tiến độ!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_ghichu.Focus();
                return;
            }

            // Kiểm tra kiểu dữ liệu của txt_phucapDA
            int phucap;
            string phucapInput = txt_phucapDA.Text.Trim(); // Loại bỏ khoảng trắng
            if (!int.TryParse(phucapInput, out phucap))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập phụ cấp là kiểu số nguyên hợp lệ!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_phucapDA.Focus();
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
                    txt_mada.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM DuAn WHERE MaDuAn = @MaDuAn";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaDuAn", txt_mada.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            // Nếu đã tồn tại, hiển thị thông báo
                            Notification notification = new Notification();
                            notification.NotificationText = "Mã dự án đã tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return; // Dừng lại nếu đã tồn tại
                        }
                    }

                    string query = "INSERT INTO DuAn (MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, PhuCapDuAn, GhiChu) VALUES (@MaDuAn, @TenDuAn, @NgayBatDau, @NgayKetThuc, @PhuCapDuAn, @Ghichu)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDuAn", txt_mada.Text);
                        command.Parameters.AddWithValue("@TenDuAn", txt_tenda.Text);
                        command.Parameters.AddWithValue("@NgayBatDau", dtp_dateStart.Value);
                        // Kiểm tra xem txt_dateEnd có giá trị hay không
                        if (string.IsNullOrWhiteSpace(txt_dateEnd.Text))
                        {
                            command.Parameters.AddWithValue("@NgayKetThuc", DBNull.Value); // Đặt giá trị là NULL
                        }
                        else
                        {
                            DateTime dateEnd;
                            // Sử dụng TryParseExact để phân tích theo định dạng dd/MM/yyyy
                            if (DateTime.TryParseExact(txt_dateEnd.Text, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out dateEnd))
                            {
                                command.Parameters.AddWithValue("@NgayKetThuc", dateEnd); // Chuyển đổi sang DateTime
                            }
                            else
                            {
                                Notification notification = new Notification();
                                notification.NotificationText = "Ngày kết thúc không đúng định dạng (dd/MM/yyyy)!";
                                notification.OkButtonText = "OK";
                                notification.ShowDialog();
                                txt_dateEnd.Focus();
                                return;
                            }
                        }
                        command.Parameters.AddWithValue("@PhuCapDuAn", txt_phucapDA.Text);
                        command.Parameters.AddWithValue("@GhiChu", txt_ghichu.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadData();
                        Reset();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["MaDuAn"].Value != null)
                {
                    txt_mada.Text = row.Cells["MaDuAn"].Value.ToString();
                    txt_mada.Enabled = false;
                }

                if (row.Cells["TenDuAn"].Value != null)
                {
                    txt_tenda.Text = row.Cells["TenDuan"].Value.ToString();
                }

                if (row.Cells["NgayBatDau"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayBatDau"].Value.ToString(), out selectedDate))
                    {
                        dtp_dateStart.Value = selectedDate;
                        dtp_dateStart.Enabled = false;
                    }
                }

                if (row.Cells["NgayKetThuc"].Value != null && DateTime.TryParse(row.Cells["NgayKetThuc"].Value.ToString(), out DateTime ngayKetThuc))
                {
                    // Định dạng ngày theo dd/MM/yyyy và gán vào textbox
                    txt_dateEnd.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                }
                else
                {
                    txt_dateEnd.Text = string.Empty; // Nếu không có ngày, đặt giá trị rỗng
                }

                if (row.Cells["PhuCapDuAn"].Value != null)
                {
                    txt_phucapDA.Text = row.Cells["PhuCapDuAn"].Value.ToString();
                }

                if (row.Cells["GhiChu"].Value != null)
                {
                    txt_ghichu.Text = row.Cells["GhiChu"].Value.ToString();
                }
            }
        }

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (txt_ghichu.Text.Trim().Length > 100)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ký tự ghi chú nhỏ hơn  100!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn dự án để sửa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            int phucap;
            string phucapInput = txt_phucapDA.Text.Trim(); // Loại bỏ khoảng trắng
            if (!int.TryParse(phucapInput, out phucap))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập phụ cấp là kiểu số nguyên hợp lệ!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_phucapDA.Focus();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE DuAn SET TenDuAn = @TenDuAn, NgayKetThuc = @NgayKetThuc, PhuCapDuAn = @PhuCapDuAn, GhiChu = @GhiChu WHERE MaDuAn = @MaDuAn";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDuAn", txt_mada.Text);
                    command.Parameters.AddWithValue("@TenDuAn", txt_tenda.Text);
                    command.Parameters.AddWithValue("@NgayBatDau", dtp_dateStart.Value);
                    // Kiểm tra xem txt_dateEnd có giá trị hay không
                    if (string.IsNullOrWhiteSpace(txt_dateEnd.Text))
                    {
                        command.Parameters.AddWithValue("@NgayKetThuc", DBNull.Value); // Đặt giá trị là NULL
                    }
                    else
                    {
                        DateTime dateEnd;
                        // Sử dụng TryParseExact để phân tích theo định dạng dd/MM/yyyy
                        if (DateTime.TryParseExact(txt_dateEnd.Text, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out dateEnd))
                        {
                            command.Parameters.AddWithValue("@NgayKetThuc", dateEnd); // Chuyển đổi sang DateTime
                        }
                        else
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Ngày kết thúc không đúng định dạng (dd/MM/yyyy)!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            txt_dateEnd.Focus();
                            return;
                        }
                    }
                    command.Parameters.AddWithValue("@PhuCapDuAn", txt_phucapDA.Text);
                    command.Parameters.AddWithValue("@GhiChu", txt_ghichu.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData();
                        Reset();
                        Success sc = new Success();
                        sc.ShowDialog();
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

        private void btn_deletehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mada.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn dự án để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "DELETE FROM DuAn WHERE MaDuAn = @MaDuAn";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDuAn", txt_mada.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData();
                        Reset();
                        Success sc = new Success();
                        sc.BringToFront();
                        sc.ShowDialog();
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

        private void resetHs_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void search()
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
                    string query = @"SELECT MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, PhuCapDuAn, GhiChu 
                         FROM DuAn 
                         WHERE TenDuAn LIKE @SearchTerm 
                            OR MaDuAn LIKE @SearchTerm 
                            OR PhuCapDuAn LIKE @SearchTerm 
                            OR GhiChu LIKE @SearchTerm 
                            OR CONVERT(VARCHAR, NgayBatDau, 103) LIKE @SearchTerm 
                            OR CONVERT(VARCHAR, NgayKetThuc, 103) LIKE @SearchTerm
                         ORDER BY MaDuAn";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + search_duan.Text + "%"); 

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0) 
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy dữ liệu phù hợp!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                            dataGridView1.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private void search_hs_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
