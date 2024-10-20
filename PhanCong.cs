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
    public partial class PhanCong : Form
    {
        private int selectedRowIndex;

        public PhanCong()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxDuAn();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dtp_dateStart.Value = DateTime.Now;
            cmb_mada.SelectedIndex = 0;
        }

        private void LoadComboBoxDuAn()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaDuAn FROM DuAn WHERE LOWER(GhiChu) NOT LIKE '%Hoàn thành%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_mada.Items.Clear();
                        cmb_mada.Items.Add("--Chọn dự án--");
                        while (reader.Read())
                        {

                            cmb_mada.Items.Add(new { Value = reader["MaDuAn"], Text = reader["MaDuAn"] });
                        }

                        cmb_mada.DisplayMember = "Text";
                        cmb_mada.ValueMember = "Value";
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
                    PC.MaPhanCong, 
                    PC.IDnhanvien, 
                    NV.HoTen,
                    PC.MaDuAn, 
                    DA.TenDuAn,
                    PC.NgayBatDau, 
                    PC.NgayKetThuc, 
                    PC.ViTri 
                FROM 
                    PhanCong PC
                LEFT JOIN
                    NhanVien NV ON PC.IDnhanvien = NV.ID
                LEFT JOIN 
                    DuAn DA ON PC.MaDuAn = DA.MaDuAn ORDER BY MaPhanCong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["IDnhanvien"].Value != null)
                {
                    txt_Manv.Text = row.Cells["Idnhanvien"].Value.ToString();
                    txt_Manv.Enabled = false;
                }

                if (row.Cells["MaDuAn"].Value != null)
                {
                    string maPB = row.Cells["MaDuAn"].Value.ToString();
                    cmb_mada.SelectedIndex = cmb_mada.FindStringExact(maPB);
                }

                if (row.Cells["NgayBatDau"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayBatDau"].Value.ToString(), out selectedDate))
                    {
                        dtp_dateStart.Value = selectedDate;
                        //dtp_dateStart.Enabled = false;
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

                if (row.Cells["Vitri"].Value != null)
                {
                    txt_vitriPC.Text = row.Cells["ViTri"].Value.ToString();
                }
            }
        }

        private void Reset()
        {
            txt_Manv.Text = string.Empty;
            txt_Manv.Enabled = true;
            txt_vitriPC.Text = string.Empty;
            cmb_mada.SelectedIndex = -1;
            txt_dateEnd.Text = string.Empty;
            dtp_dateStart.Value = DateTime.Now;
            dtp_dateStart.Enabled = true;
            txt_vitriPC.Text = "";
            search_phancong.Text = string.Empty;
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void add_hs_Click(object sender, EventArgs e)
        {
            if (txt_vitriPC.Text.Trim().Length > 50)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ký tự vị trí nhỏ hơn 100 !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_vitriPC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập mã nhân viên!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_Manv.Focus();
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
                    txt_Manv.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    //string checkQuery = "SELECT COUNT(*) FROM PhanCong WHERE IDnhanvien = @IDnhanvien";
                    //using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    //{
                    //    checkCommand.Parameters.AddWithValue("@MaPhanCong", txt_mada.Text);
                    //    int count = (int)checkCommand.ExecuteScalar();

                    //    if (count > 0)
                    //    {
                    //        // Nếu đã tồn tại, hiển thị thông báo
                    //        Notification notification = new Notification();
                    //        notification.NotificationText = "Mã dự án đã tồn tại!";
                    //        notification.OkButtonText = "OK";
                    //        notification.ShowDialog();
                    //        return; // Dừng lại nếu đã tồn tại
                    //    }
                    //}

                    // Kiểm tra nếu dự án đã có Ngày Kết Thúc (không rỗng)
                    string checkQuery = "SELECT NgayKetThuc FROM DuAn WHERE MaDuAn = @MaDuAn";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaDuAn", cmb_mada.Text);
                        object result = checkCommand.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            DateTime ngayKetThucDuAn = (DateTime)result;
                            Notification notification = new Notification();
                            notification.NotificationText = "Dự án đã kết thúc vào ngày: " + ngayKetThucDuAn.ToString("dd/MM/yyyy");
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return; // Dừng quá trình update nếu dự án đã kết thúc
                        }
                    }

                    string checkParticipationQuery = "SELECT COUNT(*) FROM PhanCong WHERE IDnhanvien = @IDnhanvien AND MaDuAn = @MaDuAn";
                    using (SqlCommand checkParticipationCommand = new SqlCommand(checkParticipationQuery, connection))
                    {
                        checkParticipationCommand.Parameters.AddWithValue("@IDnhanvien", txt_Manv.Text);
                        checkParticipationCommand.Parameters.AddWithValue("@MaDuAn", cmb_mada.Text);
                        int participationCount = (int)checkParticipationCommand.ExecuteScalar();

                        if (participationCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Nhân viên đã tham gia dự án này!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }

                        string query = "INSERT INTO PhanCong (IDnhanvien, MaDuAn, NgayBatDau, NgayKetThuc, ViTri) VALUES (@IDnhanvien, @MaDuAn, @NgayBatDau, @NgayKetThuc, @ViTri)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDnhanvien", txt_Manv.Text);
                            command.Parameters.AddWithValue("@MaDuAn", cmb_mada.Text);
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
                            command.Parameters.AddWithValue("@ViTri", txt_vitriPC.Text);

                            command.ExecuteNonQuery();
                            Success sc = new Success();
                            sc.ShowDialog();
                            LoadData();
                            Reset();
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

        private void resetHs_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (txt_vitriPC.Text.Trim().Length > 50)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập vị trí nhỏ hơn 50!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn phân công để sửa!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            // Lấy mã phân công từ hàng đã chọn trong DataGridView
            int maPhanCong = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaPhanCong"].Value);

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE PhanCong SET MaDuAn = @MaDuAn, NgayKetThuc = @NgayKetThuc, ViTri = @ViTri WHERE MaPhanCong = @MaPhanCong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDuAn", cmb_mada.Text); // Đặt giá trị cho MaDuAn
                    command.Parameters.AddWithValue("@ViTri", txt_vitriPC.Text); // Đặt giá trị cho ViTri

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
                    command.Parameters.AddWithValue("@MaPhanCong", maPhanCong); // Thêm mã phân công vào tham số

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
            if (string.IsNullOrEmpty(txt_Manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn phân công nhân viên để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            int maPhanCong = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaPhanCong"].Value); //dòng được chọn trên dtgv

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "DELETE FROM PhanCong WHERE MaPhanCong = @MaPhanCong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhanCong", maPhanCong); // Thêm mã phân công vào tham số

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData(); // Cập nhật lại dữ liệu sau khi xóa
                        Success sc = new Success();
                        sc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message; // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
                }
            }
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
                    string query = @"SELECT MaPhanCong, IDnhanvien, MaDuAn, NgayBatDau, NgayKetThuc, ViTri
                         FROM PhanCong 
                         WHERE MaPhanCong LIKE @SearchTerm 
                            OR IDnhanvien LIKE @SearchTerm
                            OR MaDuAn LIKE @SearchTerm 
                            OR CONVERT(VARCHAR, NgayBatDau, 103) LIKE @SearchTerm 
                            OR CONVERT(VARCHAR, NgayKetThuc, 103) LIKE @SearchTerm
                            OR ViTri LIKE @SearchTerm 
                         ORDER BY MaPhanCong";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + search_phancong.Text + "%");

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

        private void search_phancong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
