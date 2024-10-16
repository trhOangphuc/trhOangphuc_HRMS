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
    public partial class ChinhSach : Form
    {
        public ChinhSach()
        {
            InitializeComponent();
            LoadComboBoxKhenThuong();
            LoadComboBoxKyLuat();
            LoadDataKT();
            LoadDataKL();
            cmb_KT.SelectedIndex = 0; 
            cmb_KL.SelectedIndex = 0;
            dtp_date.Value = DateTime.Now;
            dtg_phat.CellClick += dtg_phat_CellClick;
            dtg_thuong.CellClick += dtg_thuong_CellClick;
            dtg_phat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_phat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_phat.CellClick += new DataGridViewCellEventHandler(dtg_phat_CellClick);
            dtg_thuong.CellClick += new DataGridViewCellEventHandler(dtg_thuong_CellClick);
        }

        private void LoadDataKT()
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien,NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KhenThuong KT ON CS.MaKT = KT.MaKT
                                     WHERE CS.MaKT IS NOT NULL
                                     ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_thuong.DataSource = dataTable;
                        dtg_thuong.AllowUserToAddRows = false;
                        dtg_thuong.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataKL()
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KyLuat KL ON CS.MaKL = KL.MaKL
                                     WHERE CS.MaKL IS NOT NULL
                                     ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_phat.DataSource = dataTable;
                        dtg_phat.AllowUserToAddRows = false;
                        dtg_phat.Columns["NgayKL"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadComboBoxKhenThuong()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKT FROM KhenThuong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_KT.Items.Clear();
                        cmb_KT.Items.Add("--Chọn khen thưởng--");
                        while (reader.Read())
                        {

                            cmb_KT.Items.Add(new { Value = reader["MaKT"], Text = reader["MaKT"] });
                        }

                        cmb_KT.DisplayMember = "Text";
                        cmb_KT.ValueMember = "Value";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }
        private void LoadComboBoxKyLuat()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKL FROM KyLuat";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_KL.Items.Clear();
                        cmb_KL.Items.Add("--Chọn kỷ luật--");
                        while (reader.Read())
                        {

                            cmb_KL.Items.Add(new { Value = reader["MaKL"], Text = reader["MaKL"] });
                        }

                        cmb_KL.DisplayMember = "Text";
                        cmb_KL.ValueMember = "Value";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void add_hs_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_manv.Text)
                || string.IsNullOrWhiteSpace(cmb_KT.Text) || string.IsNullOrWhiteSpace(dtp_date.Text))
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

                    //string checkMaChinhSachQuery = "SELECT COUNT(*) FROM ChinhSach WHERE IDnhanvien = @IDnhanvien";
                    //using (SqlCommand checkMaChinhSachCommand = new SqlCommand(checkMaChinhSachQuery, connection))
                    //{
                    //    checkMaChinhSachCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                    //    int countMaChinhSach = (int)checkMaChinhSachCommand.ExecuteScalar();

                    //    if (countMaChinhSach > 0)
                    //    {
                    //        Notification notification = new Notification();
                    //        notification.NotificationText = "Mã chính sách đã tồn tại nhập mã khác!";
                    //        notification.OkButtonText = "OK";
                    //        notification.ShowDialog();
                    //        return;
                    //    }
                    //}

                    string query = @"
                      INSERT INTO ChinhSach (IDnhanvien, NgayKT, MaKT)
                      VALUES (@IDnhanvien, @NgayKT, @MaKT)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        command.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
                        command.Parameters.AddWithValue("@MaKT", cmb_KT.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadDataKT();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    Notification notification = new Notification();
                    notification.NotificationText = "Vui lòng chọn thông tin khen thưởng !";
                    notification.OkButtonText = "OK";
                    notification.ShowDialog();
                }
            }
        }

        private void reset()
        {
            richTextBox1.Text = string.Empty;
            txt_manv.Enabled = true;
            txt_manv.Text = string.Empty;
            dtp_date.Value = DateTime.Now;
            cmb_KT.SelectedIndex = -1;
            cmb_KL.SelectedIndex = -1;
            search_hs.Text = string.Empty;
            dtg_thuong.ClearSelection();
            dtg_phat.ClearSelection();
            LoadDataKT();
            LoadDataKL();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void add_KL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text)
                || string.IsNullOrWhiteSpace(cmb_KL.Text) || string.IsNullOrWhiteSpace(dtp_date.Text))
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
                    return;
                }

                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE ID = @IDnhanvien";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);

                        // Thực hiện truy vấn kiểm tra
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0) // Nếu không tìm thấy IDnhanvien
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "ID nhân viên không tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    //string checkMaChinhSachQuery = "SELECT COUNT(*) FROM ChinhSach WHERE IDnhanvien = @IDnhanvien";
                    //using (SqlCommand checkMaChinhSachCommand = new SqlCommand(checkMaChinhSachQuery, connection))
                    //{
                    //    checkMaChinhSachCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                    //    int countMaChinhSach = (int)checkMaChinhSachCommand.ExecuteScalar();

                    //    if (countMaChinhSach > 0)
                    //    {
                    //        Notification notification = new Notification();
                    //        notification.NotificationText = "Mã chính sách đã tồn tại nhập mã khác!";
                    //        notification.OkButtonText = "OK";
                    //        notification.ShowDialog();
                    //        return;
                    //    }
                    //}

                    string query = @"
                      INSERT INTO ChinhSach (IDnhanvien, NgayKL, MaKL)
                      VALUES (@IDnhanvien, @NgayKL, @MaKL)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        command.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
                        command.Parameters.AddWithValue("@MaKL", cmb_KL.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadDataKL();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    Notification notification = new Notification();
                    notification.NotificationText = "Vui lòng chọn thông tin kỷ luật !";
                    notification.OkButtonText = "OK";
                    notification.ShowDialog();
                }
            }
        }

        private void dtg_thuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_thuong.Rows.Count)
            {
                DataGridViewRow row = dtg_thuong.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["NgayKT"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayKT"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["MaKT"].Value != null)
                {
                    string maKT = row.Cells["MaKT"].Value.ToString();
                    cmb_KT.SelectedIndex = cmb_KT.FindStringExact(maKT);
                }
            }
        }

        private void dtg_phat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_phat.Rows.Count)
            {
                DataGridViewRow row = dtg_phat.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien2"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien2"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["NgayKL"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayKL"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["MaKL"].Value != null)
                {
                    string maKL = row.Cells["MaKL"].Value.ToString();
                    cmb_KL.SelectedIndex = cmb_KL.FindStringExact(maKL);
                }
            }
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
            if (dtg_phat.CurrentRow == null)
            {
                Question questionForm = new Question();
                questionForm.QuestionText = "xóa chinh sách thưởng này không?";
                questionForm.OkButtonText = "Có";
                if (questionForm.ShowDialog() == DialogResult.OK)
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
                            string query = "DELETE FROM ChinhSach WHERE MaKT = @MaKT";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaKT", dtg_thuong.CurrentRow.Cells["MaKT"].Value);
                                command.ExecuteNonQuery();
                                Success sc = new Success();
                                sc.ShowDialog();
                                LoadDataKT();
                                reset();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            if (dtg_phat.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (cmb_KL.SelectedItem != null)
            {
                Question questionForm2 = new Question();
                questionForm2.QuestionText = "xóa chinh sách phạt này không?";
                questionForm2.OkButtonText = "Có";
                if (questionForm2.ShowDialog() == DialogResult.OK)
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
                            string query = "DELETE FROM ChinhSach WHERE MaKL = @MaKL";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaKL", dtg_phat.CurrentRow.Cells["MaKL"].Value);
                                command.ExecuteNonQuery();
                                Success sc = new Success();
                                sc.ShowDialog();
                                LoadDataKL();
                                reset();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn chính sách để cập nhật !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
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
                    return;
                }

                try
                {
                    connection.Open();
                    if (cmb_KT.SelectedItem != null)
                    {
                        string queryKT = @"UPDATE ChinhSach 
                               SET NgayKT = @NgayKT, MaKT = @MaKT 
                               WHERE IDnhanvien = @IDnhanvien";

                        using (SqlCommand commandKT = new SqlCommand(queryKT, connection))
                        {
                            commandKT.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text); // Sửa giá trị từ CurrentRow
                            commandKT.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
                            commandKT.Parameters.AddWithValue("@MaKT", ((dynamic)cmb_KT.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

                            commandKT.ExecuteNonQuery();
                            LoadDataKT();
                            Success sc = new Success();
                            sc.ShowDialog();
                            reset();
                        }
                        return;
                    }

                    if (cmb_KL.SelectedItem != null)
                    {
                        string queryKL = @"UPDATE ChinhSach 
                               SET NgayKL = @NgayKL, MaKL = @MaKL 
                               WHERE IDnhanvien = @IDnhanvien"; // Sửa tên cột cho đúng

                        using (SqlCommand commandKL = new SqlCommand(queryKL, connection))
                        {
                            commandKL.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text); // Sửa giá trị từ CurrentRow
                            commandKL.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
                            commandKL.Parameters.AddWithValue("@MaKL", ((dynamic)cmb_KL.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

                            commandKL.ExecuteNonQuery();
                            LoadDataKL();
                            Success sc = new Success();
                            sc.ShowDialog();
                            reset();
                        }
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchData(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadDataKT();
                LoadDataKL();
                return;
            }
            SearchKhenthuong(searchValue);
            SearchKyLuat(searchValue);
        }
        private void SearchKhenthuong(string searchValue)
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien, NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                             FROM ChinhSach CS
                             LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                             LEFT JOIN KhenThuong KT ON CS.MaKT = KT.MaKT
                             WHERE CS.MaKT IS NOT NULL AND (CS.IDnhanvien LIKE @searchValue OR NV.HoTen LIKE @searchValue)
                             ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dtg_thuong.DataSource = dataTable;
                            dtg_thuong.AllowUserToAddRows = false;
                            dtg_thuong.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy kết quả Khen thưởng.",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm trong bảng Khen thưởng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SearchKyLuat(string searchValue)
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                             FROM ChinhSach CS
                             LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                             LEFT JOIN KyLuat KL ON CS.MaKL = KL.MaKL
                             WHERE CS.MaKL IS NOT NULL AND (CS.IDnhanvien LIKE @searchValue OR NV.HoTen LIKE @searchValue)
                             ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dtg_phat.DataSource = dataTable;
                            dtg_phat.AllowUserToAddRows = false;
                            dtg_phat.Columns["NgayKL"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy kết quả Kỷ luật.",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm trong bảng Kỷ luật: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            SearchData(search_hs.Text);
        }

        private void SearchSummary()
        {
            // Lấy giá trị ID nhân viên từ textbox
            string idNhanVienInput = search_hs.Text.Trim();
            if (string.IsNullOrEmpty(idNhanVienInput))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ID của nhân viên để thực hiện !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                search_hs.Focus();
                return;
            }

            // Kiểm tra nếu giá trị nhập vào là số
            if (!int.TryParse(idNhanVienInput, out int idNhanVien))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập vào ID của nhân viên để thống kê !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                search_hs.Focus();
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
        CS.IDnhanvien, 
        NV.HoTen,
        SUM(CASE WHEN KT.MaKT IS NOT NULL THEN KT.GiaTri ELSE 0 END) AS TongGiaTriKhenThuong,
        SUM(CASE WHEN KL.MaKL IS NOT NULL THEN KL.GiaTri ELSE 0 END) AS TongGiaTriKyLuat
      FROM 
        ChinhSach CS
      LEFT JOIN 
        NhanVien NV ON CS.IDnhanvien = NV.ID
      LEFT JOIN 
        KhenThuong KT ON CS.MaKT = KT.MaKT
      LEFT JOIN 
        KyLuat KL ON CS.MaKL = KL.MaKL
      WHERE 
        CS.IDnhanvien = @IDnhanvien
      GROUP BY 
        CS.IDnhanvien, NV.HoTen
      HAVING 
        SUM(CASE WHEN KT.MaKT IS NOT NULL THEN KT.GiaTri ELSE 0 END) > 0 OR 
        SUM(CASE WHEN KL.MaKL IS NOT NULL THEN KL.GiaTri ELSE 0 END) > 0
      ORDER BY 
        CS.IDnhanvien;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            richTextBox1.Clear(); // Xóa nội dung cũ
                            if (reader.Read()) // Chỉ đọc một dòng
                            {
                                // Lấy thông tin từ reader
                                string hoTen = reader["HoTen"].ToString();

                                // Kiểm tra và lấy giá trị tổng khen thưởng
                                object khenThuongValue = reader["TongGiaTriKhenThuong"];
                                float tongKhenThuong = khenThuongValue is DBNull ? 0 : Convert.ToSingle(khenThuongValue);

                                // Kiểm tra và lấy giá trị tổng kỷ luật
                                object kyLuatValue = reader["TongGiaTriKyLuat"];
                                float tongKyLuat = kyLuatValue is DBNull ? 0 : Convert.ToSingle(kyLuatValue);

                                // Chuyển đổi float sang string với định dạng
                                string tongKhenThuongString = tongKhenThuong.ToString();
                                string tongKyLuatString = tongKyLuat.ToString();

                                // Hiển thị thông tin trong RichTextBox
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText($"\tTổng chính sách của nhân viên:\n\n");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText($"\tID Nhân viên: {idNhanVien}\n");
                                richTextBox1.AppendText($"\tHọ tên: {hoTen}\n");
                                richTextBox1.AppendText($"\tTổng giá trị khen thưởng: {tongKhenThuongString} VNĐ\n");
                                richTextBox1.AppendText($"\tTổng giá trị kỷ luật: {tongKyLuatString} VNĐ\n\n");
                                richTextBox1.AppendText("=======================================");
                            }
                            else
                            {
                                richTextBox1.Text = "*Không có kết quả chính sách cho nhân viên này !";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchSummary();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_macs_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
