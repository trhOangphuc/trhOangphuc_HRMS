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
    public partial class HoSo : Form
    {
        public HoSo()
        {
            InitializeComponent();
            LoadData();
            LoadDataPhongban();
            LoadDataCongTac();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_phongban.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_congtac.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
                    PB.TenPB, 
                    PB.ChucVu, 
                    CT.GhiChu 
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB
                LEFT JOIN 
                    CongTac CT ON NV.MaCT = CT.MaCongTac";

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

        private void LoadDataPhongban()
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
                    string query = "SELECT ID, MaPB, TenPB, ChucVu FROM PhongBan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_phongban.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataCongTac()
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
                    string query = "SELECT ID, MaCongTac, GhiChu FROM CongTac";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_congtac.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (row.Cells["Sdt"].Value != null)
                {
                    txt_sdt.Text = row.Cells["Sdt"].Value.ToString(); 
                }

                if (row.Cells["DiaChi"].Value != null)
                {
                    txt_dc.Text = row.Cells["DiaChi"].Value.ToString(); 
                }
            }
        }

        private void add_hs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ht.Text) || string.IsNullOrWhiteSpace(txt_gt.Text) 
                || string.IsNullOrWhiteSpace(txt_dc.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text) || string.IsNullOrWhiteSpace(txt_pb.Text)
                || string.IsNullOrWhiteSpace(txt_ct.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng Nhập đầy đủ thông tin !";
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
                                  INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, Sdt, DiaChi, MaPB, MaCT)
                                  VALUES (@HoTen, @GioiTinh, @NgaySinh, @Sdt, @DiaChi, @MaPB, @MaCT)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HoTen", txt_ht.Text);
                        command.Parameters.AddWithValue("@GioiTinh", txt_gt.Text);
                        command.Parameters.AddWithValue("@NgaySinh", dtp_date.Value);
                        command.Parameters.AddWithValue("@Sdt", txt_sdt.Text);
                        command.Parameters.AddWithValue("@DiaChi", txt_dc.Text);
                        command.Parameters.AddWithValue("@MaPB", txt_pb.Text); 
                        command.Parameters.AddWithValue("@MaCT", txt_ct.Text); 

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadData(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();
                    string query = @"
                                    UPDATE NhanVien 
                                    SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, Sdt = @Sdt, DiaChi = @DiaChi, MaPB = @MaPB, MaCT = @MaCt
                                    WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                        command.Parameters.AddWithValue("@HoTen", txt_ht.Text);
                        command.Parameters.AddWithValue("@GioiTinh", txt_gt.Text);
                        command.Parameters.AddWithValue("@NgaySinh", dtp_date.Value);
                        command.Parameters.AddWithValue("@Sdt", txt_sdt.Text);
                        command.Parameters.AddWithValue("@DiaChi", txt_dc.Text);
                        command.Parameters.AddWithValue("@MaPB", txt_pb.Text);
                        command.Parameters.AddWithValue("@MaCT", txt_ct.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadData(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_deletehs_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn nhân viên để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            Question questionForm = new Question();
            questionForm.QuestionText = "xóa nhân viên này không?";
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
                        string query = "DELETE FROM NhanVien WHERE ID = @ID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value);
                            command.ExecuteNonQuery();
                            Success sc = new Success();
                            sc.ShowDialog();
                            LoadData(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            txt_ht.Text = string.Empty;
            txt_gt.Text = string.Empty;
            dtp_date.Value = DateTime.Now;
            txt_sdt.Text = string.Empty;
            txt_dc.Text = string.Empty;
            txt_pb.Text = string.Empty;
            txt_ct.Text = string.Empty;
            search_hs.Text = string.Empty;
            dataGridView1.ClearSelection();
        }

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            string searchQuery = search_hs.Text.ToLower();
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            // Tìm kiếm trong dataGridView1
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = $"HoTen LIKE '%{searchQuery}%'";

                // Kiểm tra nếu không có kết quả tìm kiếm
                if (dataView.Count == 0)
                {
                    Notification tb = new Notification
                    {
                        NotificationText = "Không tìm thấy nhân viên nào!",
                        OkButtonText = "OK"
                    };
                    tb.ShowDialog();
                }

                dataGridView1.DataSource = dataView;
            }

            // Tìm kiếm trong dtg_phongban
            DataTable dtPhongBan = (DataTable)dtg_phongban.DataSource;
            if (dtPhongBan != null)
            {
                DataView dataViewPhongBan = new DataView(dtPhongBan);
                dataViewPhongBan.RowFilter = $"MaPB LIKE '%{searchQuery}%' OR TenPB LIKE '%{searchQuery}%' OR ChucVu LIKE '%{searchQuery}%'";

                // Kiểm tra nếu không có kết quả tìm kiếm
                if (dataViewPhongBan.Count == 0)
                {
                    Notification tb = new Notification
                    {
                        NotificationText = "Không tìm thấy phòng ban nào!",
                        OkButtonText = "OK"
                    };
                    tb.ShowDialog();
                }

                dtg_phongban.DataSource = dataViewPhongBan;
            }

            // Tìm kiếm trong dtg_congtac
            DataTable dtCongTac = (DataTable)dtg_congtac.DataSource;
            if (dtCongTac != null)
            {
                DataView dataViewCongTac = new DataView(dtCongTac);
                dataViewCongTac.RowFilter = $"MaCongTac LIKE '%{searchQuery}%' OR GhiChu LIKE '%{searchQuery}%'";

                // Kiểm tra nếu không có kết quả tìm kiếm
                if (dataViewCongTac.Count == 0)
                {
                    Notification tb = new Notification
                    {
                        NotificationText = "Không tìm thấy công tác nào!",
                        OkButtonText = "OK"
                    };
                    tb.ShowDialog();
                }

                dtg_congtac.DataSource = dataViewCongTac;
            }
        }

        private void dtg_phongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_phongban.Rows.Count)
            {
                DataGridViewRow row = dtg_phongban.Rows[e.RowIndex];
                if (row.Cells["MaPB"].Value != null)
                {
                    txt_pb.Text = row.Cells["MaPB"].Value.ToString();
                }

            }
        }

        private void dtg_congtac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_congtac.Rows.Count)
            {
                DataGridViewRow row = dtg_congtac.Rows[e.RowIndex];
                if (row.Cells["MaCT"].Value != null)
                {
                    txt_ct.Text = row.Cells["MaCT"].Value.ToString();
                }

            }
        }
    }
}
