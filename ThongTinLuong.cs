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
    public partial class ThongTinLuong : Form
    {
        public ThongTinLuong()
        {
            InitializeComponent();
            LoadComboBoxChucVu();
            LoadComboBoxPhongBan();
            LoadData();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            cmb_phongban.SelectedIndex = 0; 
            cmb_chucvu.SelectedIndex = 0;
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
                    L.MaLuong,
                    PB.MaPB, 
                    CV.MaCV ,
                    L.PhuCap,
                    L.LuongCoBan
                FROM 
                    Luong L
                LEFT JOIN 
                    PhongBan PB ON L.MaPB = PB.MaPB
                LEFT JOIN 
                    ChucVu CV ON L.MaCV = CV.MaCV ORDER BY PB.MaPB";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reset()
        {
            txt_maluong.Enabled = true;
            txt_lcb.Text = string.Empty;
            txt_maluong.Text = string.Empty;
            txt_phucap.Text = string.Empty;
            cmb_phongban.SelectedIndex = -1;
            cmb_phongban.SelectedIndex = -1;
            search_hs.Text = string.Empty;
            LoadData();
            dataGridView1.ClearSelection();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["MaLuong"].Value != null)
                {
                    txt_maluong.Text = row.Cells["MaLuong"].Value.ToString();
                    txt_maluong.Enabled = false;
                }

                if (row.Cells["PhuCap"].Value != null)
                {
                    txt_phucap.Text = row.Cells["PhuCap"].Value.ToString();
                }

                if (row.Cells["LuongCoBan"].Value != null)
                {
                    txt_lcb.Text = row.Cells["LuongCoBan"].Value.ToString();
                }
                if (row.Cells["MaPB"].Value != null)
                {
                    string maPB = row.Cells["MaPB"].Value.ToString();
                    cmb_phongban.SelectedIndex = cmb_phongban.FindStringExact(maPB);
                }
                if (row.Cells["MaCV"].Value != null)
                {
                    string maCV = row.Cells["MaCV"].Value.ToString();
                    cmb_chucvu.SelectedIndex = cmb_chucvu.FindStringExact(maCV);
                }
            }
        }

        private void LoadComboBoxChucVu()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaCV FROM ChucVu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_chucvu.Items.Clear();
                        cmb_chucvu.Items.Add("--Chọn chức vụ--");
                        while (reader.Read())
                        {
                            cmb_chucvu.Items.Add(new { Value = reader["MaCV"], Text = reader["MaCV"] });
                        }

                        cmb_chucvu.DisplayMember = "Text";
                        cmb_chucvu.ValueMember = "Value";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void LoadComboBoxPhongBan()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaPB FROM PhongBan";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_phongban.Items.Clear();
                        cmb_phongban.Items.Add("--Chọn phòng ban--");
                        while (reader.Read())
                        {

                            cmb_phongban.Items.Add(new { Value = reader["MaPB"], Text = reader["MaPB"] });
                        }

                        cmb_phongban.DisplayMember = "Text";
                        cmb_phongban.ValueMember = "Value";
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

            if (string.IsNullOrWhiteSpace(txt_lcb.Text) || string.IsNullOrWhiteSpace(txt_maluong.Text)
                || string.IsNullOrWhiteSpace(txt_phucap.Text) )
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if(!float.TryParse(txt_lcb.Text, out float lcb))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập lương cơ bản kiểu số !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if(!float.TryParse(txt_phucap.Text, out float phucap))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập phụ cấp kiểu số !";
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

                    string query = @"
                      INSERT INTO Luong (MaLuong, MaPB, MaCV, PhuCap, LuongCoBan)
                      VALUES (@MaLuong, @MaPB, @MaCV, @PhuCap, @LuongCoBan)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLuong", txt_maluong.Text);
                        command.Parameters.AddWithValue("@MaPB", cmb_phongban.Text);
                        command.Parameters.AddWithValue("@MaCV", cmb_chucvu.Text);
                        command.Parameters.AddWithValue("@PhuCap", lcb);
                        command.Parameters.AddWithValue("@LuongCoBan", phucap);
 

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

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_maluong.Text) || string.IsNullOrWhiteSpace(txt_lcb.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để cập nhật !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (!float.TryParse(txt_lcb.Text, out float lcb))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập lương cơ bản kiểu số !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (!float.TryParse(txt_phucap.Text, out float phucap))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập phụ cấp kiểu số !";
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
                    string query = @"
                            UPDATE Luong 
                            SET PhuCap = @PhuCap, LuongCoBan = @LuongCoBan";
                    if (cmb_phongban.SelectedItem != null)
                    {
                        query += ", MaPB = @MaPB";
                    }
                    if (cmb_chucvu.SelectedItem != null)
                    {
                        query += ", MaCV = @MaCV";
                    }

                    query += " WHERE MaLuong = @MaLuong";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLuong", dataGridView1.CurrentRow.Cells["MaLuong"].Value);
                        command.Parameters.AddWithValue("@PhuCap", phucap);
                        command.Parameters.AddWithValue("@LuongCoBan", lcb);
                        if (cmb_phongban.SelectedItem != null)
                        {
                            command.Parameters.AddWithValue("@MaPB", ((dynamic)cmb_phongban.SelectedItem).Value);
                        }
                        if (cmb_chucvu.SelectedItem != null)
                        {
                            command.Parameters.AddWithValue("@MaCV", ((dynamic)cmb_chucvu.SelectedItem).Value);
                        }

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

        private void btn_deletehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maluong.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            Question questionForm = new Question();
            questionForm.QuestionText = "xóa mã lương này không?";
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
                        string query = "DELETE FROM Luong WHERE MaLuong = @MaLuong";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaLuong", dataGridView1.CurrentRow.Cells["MaLuong"].Value);
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

        private void search()
        {
            string searchQuery = search_hs.Text.ToLower();
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                string filter = $"MaLuong LIKE '%{searchQuery}%' OR MaPB LIKE '%{searchQuery}%'" +
                    $" OR MaCV LIKE '%{searchQuery}%'";
                if (double.TryParse(searchQuery, out double searchNumber))
                {
                    // Thêm điều kiện tìm kiếm cho các cột kiểu số
                    filter += $" OR PhuCap = {searchNumber} OR LuongCoBan = {searchNumber}";
                }
                dataView.RowFilter = filter;
                if (dataView.Count == 0)
                {
                    Notification tb = new Notification
                    {
                        NotificationText = "Không tìm thấy dữ liệu!",
                        OkButtonText = "OK"
                    };
                    tb.ShowDialog();

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    dataGridView1.DataSource = dataView;
                }
            }
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
