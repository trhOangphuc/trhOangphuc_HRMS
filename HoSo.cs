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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu
{
    public partial class HoSo : Form
    {
        public HoSo()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxPhongBan();
            LoadComboBoxChucVu();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            cmb_phongban.SelectedIndex = 0; // Đặt mục này làm mặc định
            cmb_chucvu.SelectedIndex = 0; // Đặt mục này làm mặc định
            dtp_date.Value = DateTime.Now;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        public DataTable GetHoSo()
        {
            DataTable DataTable = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                }

                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    NV.ID, 
                    NV.HoTen, 
                    NV.GioiTinh, 
                    NV.NgaySinh, 
                    NV.Sdt, 
                    NV.DiaChi, 
                    PB.MaPB, 
                    CV.MaCV 
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB
                LEFT JOIN 
                    ChucVu CV ON NV.MaCV = CV.MaCV ORDER BY ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            return DataTable;
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
                    NV.ID, 
                    NV.HoTen, 
                    NV.GioiTinh, 
                    NV.NgaySinh, 
                    NV.Sdt, 
                    NV.DiaChi, 
                    PB.MaPB, 
                    CV.MaCV 
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB
                LEFT JOIN 
                    ChucVu CV ON NV.MaCV = CV.MaCV ORDER BY ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
                if (row.Cells["HoTen"].Value != null)
                {
                    txt_ht.Text = row.Cells["HoTen"].Value.ToString();
                }

                if (row.Cells["GioiTinh"].Value != null)
                {
                    txt_gt.Text = row.Cells["GioiTinh"].Value.ToString();
                }

                if (row.Cells["NgaySinh"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["Sdt"].Value != null)
                {
                    txt_sdt.Text = row.Cells["Sdt"].Value.ToString();
                }
                if (row.Cells["DiaChi"].Value != null)
                {
                    txt_dc.Text = row.Cells["DiaChi"].Value.ToString();
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

        private void add_hs_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txt_ht.Text) || string.IsNullOrWhiteSpace(txt_gt.Text)
                || string.IsNullOrWhiteSpace(txt_dc.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập đầy đủ thông tin !";
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
                      INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, Sdt, DiaChi, MaPB, MaCV)
                      VALUES (@HoTen, @GioiTinh, @NgaySinh, @Sdt, @DiaChi, @MaPB, @MaCV)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HoTen", txt_ht.Text);
                        command.Parameters.AddWithValue("@GioiTinh", txt_gt.Text);
                        command.Parameters.AddWithValue("@NgaySinh", dtp_date.Value);
                        command.Parameters.AddWithValue("@Sdt", txt_sdt.Text);
                        command.Parameters.AddWithValue("@DiaChi", txt_dc.Text);
                        command.Parameters.AddWithValue("@MaPB", cmb_phongban.Text); 
                        command.Parameters.AddWithValue("@MaCV", cmb_chucvu.Text); 

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
            if (string.IsNullOrWhiteSpace(txt_ht.Text) || string.IsNullOrWhiteSpace(txt_gt.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn nhân viên để cập nhật !";
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
                            UPDATE NhanVien 
                            SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, Sdt = @Sdt, DiaChi = @DiaChi";
                    if (cmb_phongban.SelectedItem != null)
                    {
                        query += ", MaPB = @MaPB";
                    }
                    if (cmb_chucvu.SelectedItem != null)
                    {
                        query += ", MaCV = @MaCV";
                    }

                    query += " WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                        command.Parameters.AddWithValue("@HoTen", txt_ht.Text);
                        command.Parameters.AddWithValue("@GioiTinh", txt_gt.Text);
                        command.Parameters.AddWithValue("@NgaySinh", dtp_date.Value);
                        command.Parameters.AddWithValue("@Sdt", txt_sdt.Text);
                        command.Parameters.AddWithValue("@DiaChi", txt_dc.Text);
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
            if (string.IsNullOrEmpty(txt_ht.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn nhân viên để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            Question questionForm = new Question();
            questionForm.QuestionText = "Bạn có chắc chắn muốn xóa nhân viên này không?";
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

                        // Kiểm tra xem nhân viên có được tham chiếu trong bảng ChamCong hay không
                        string checkQuery = "SELECT COUNT(*) FROM ChamCong WHERE IDnhanvien = @ID";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                // Nếu có bản ghi tham chiếu, hiển thị thông báo và dừng quá trình xóa
                                Notification notification = new Notification();
                                notification.NotificationText = "Không thể xóa nhân viên này vì có dữ liệu liên quan trong bảng Chấm Công!";
                                notification.OkButtonText = "OK";
                                notification.ShowDialog();
                                return;
                            }
                        }

                        // Nếu không có bản ghi tham chiếu, thực hiện xóa nhân viên
                        string deleteQuery = "DELETE FROM NhanVien WHERE ID = @ID";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                            deleteCommand.ExecuteNonQuery();
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

        private void reset()
        {

            txt_ht.Text = string.Empty;
            txt_gt.Text = string.Empty;
            dtp_date.Value = DateTime.Now;
            txt_sdt.Text = string.Empty;
            txt_dc.Text = string.Empty;
            cmb_phongban.SelectedIndex = -1;
            cmb_chucvu.SelectedIndex = -1;
            search_hs.Text = string.Empty;
            dataGridView1.ClearSelection();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            string searchQuery = search_hs.Text.ToLower();
            string query = @"
        SELECT * FROM NhanVien 
        WHERE 
            LOWER(HoTen) LIKE @searchQuery 
            OR ID = @id";

            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                    if (int.TryParse(searchQuery, out int idResult))
                    {
                        command.Parameters.AddWithValue("@id", idResult);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@id", DBNull.Value); //xử lý trường hợp ID không phải số
                    }

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy nhân viên nào!",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable; 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
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
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
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
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
                }
            }
        }

       


        private void cmb_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_hs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
