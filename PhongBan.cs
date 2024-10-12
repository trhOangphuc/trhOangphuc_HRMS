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
    public partial class PhongBan : Form
    {
        public PhongBan()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            LoadData();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
                    string query = "SELECT ID, MaPB, TenPB, ChucVu FROM PhongBan ORDER BY MaPB";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Reset()
        {
            search_phongban.Text = "";
            txt_mapb.Enabled = true;
            txt_mapb.Text = "";
            txt_phongban.Text = "";
            txt_chucvu.Text = "";
            LoadData();
        }

        private void resetb_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void add_pb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_mapb.Text) || string.IsNullOrWhiteSpace(txt_phongban.Text)
               || string.IsNullOrWhiteSpace(txt_chucvu.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng Nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO PhongBan (MaPB, TenPB, ChucVu) VALUES (@MaPB, @TenPB, @ChucVu)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
                    command.Parameters.AddWithValue("@TenPB", txt_phongban.Text);
                    command.Parameters.AddWithValue("@ChucVu", txt_chucvu.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData();
                        Success sc = new Success();
                        sc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btn_updatePB_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn phòng ban để sửa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE PhongBan SET TenPB = @TenPB, ChucVu = @ChucVu WHERE MaPB = @MaPB";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
                    command.Parameters.AddWithValue("@TenPB", txt_phongban.Text);
                    command.Parameters.AddWithValue("@ChucVu", txt_chucvu.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData();
                        Success sc = new Success();
                        sc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btn_deletePb_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn phòng ban để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "DELETE FROM PhongBan WHERE MaPB = @MaPB";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", txt_mapb.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadData();
                        Success sc = new Success();
                        sc.BringToFront();
                        sc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }


        private void btn_searchPb_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM PhongBan WHERE MaPB LIKE '%' + @SearchTerm + '%' OR TenPB LIKE '%' + @SearchTerm + '%' OR ChucVu LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string searchTerm = search_phongban.Text; 
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                            txt_mapb.Text = dataTable.Rows[0]["MaPB"].ToString();
                            txt_phongban.Text = dataTable.Rows[0]["TenPB"].ToString();
                            txt_chucvu.Text = dataTable.Rows[0]["ChucVu"].ToString();
                        }
                        else
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy phòng ban!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Kiểm tra từng cột để tránh lỗi null
                if (row.Cells["MaPB"].Value != null)
                {
                    txt_mapb.Text = row.Cells["MaPB"].Value.ToString();
                    txt_mapb.Enabled = false;
                }

                if (row.Cells["TenPB"].Value != null)
                {
                    txt_phongban.Text = row.Cells["TenPB"].Value.ToString();
                }

                if (row.Cells["ChucVu"].Value != null)
                {
                    txt_chucvu.Text = row.Cells["ChucVu"].Value.ToString();
                }
            }
        }

        private void txt_mapb_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetb_Click_1(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
