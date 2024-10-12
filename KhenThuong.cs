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
    public partial class KhenThuong : Form
    {
        public KhenThuong()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
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
                    string query = "SELECT ID, MaKT, TenKT, GiaTri FROM KhenThuong ORDER BY MaKT";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Kiểm tra từng cột để tránh lỗi null
                if (row.Cells["MaKT"].Value != null)
                {
                    txt_makt.Text = row.Cells["MaKT"].Value.ToString();
                    txt_makt.Enabled = false;
                }

                if (row.Cells["TenKT"].Value != null)
                {
                    txt_kt.Text = row.Cells["TenKT"].Value.ToString();
                }

                if (row.Cells["GiaTri"].Value != null)
                {
                    txt_giatri.Text = row.Cells["GiaTri"].Value.ToString();
                }
            }
        }

        private void Reset()
        {
            search_khenthuong.Text = "";
            txt_makt.Enabled = true;
            txt_makt.Text = "";
            txt_kt.Text = "";
            txt_giatri.Text = "";
            LoadData();
        }

        private void add_kt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_makt.Text) || string.IsNullOrWhiteSpace(txt_kt.Text)
               || string.IsNullOrWhiteSpace(txt_giatri.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng Nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO KhenThuong (MaKT, TenKT, GiaTri) VALUES (@MaKT, @TenKT, @GiaTri)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKT", txt_makt.Text);
                    command.Parameters.AddWithValue("@TenKT", txt_kt.Text);
                    command.Parameters.AddWithValue("@GiaTri", txt_giatri.Text);

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

        private void btn_updateKT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để sửa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE KhenThuong SET TenKT = @TenKT, GiaTri = @GiaTri WHERE MaKT = @MaKT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKT", txt_makt.Text);
                    command.Parameters.AddWithValue("@TenKT", txt_kt.Text);
                    command.Parameters.AddWithValue("@GiaTri", txt_giatri.Text);

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

        private void btn_deleteKT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn để xóa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "DELETE FROM KhenThuong WHERE MaKT = @MaKT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKT", txt_makt.Text);

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

        private void reset1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_searchKT_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM KhenThuong WHERE MaKT LIKE '%' + @SearchTerm + '%' OR TenKL LIKE '%' + @SearchTerm + '%' OR GiaTri LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenKT", search_khenthuong.Text);
                    command.Parameters.AddWithValue("@GiaTri", search_khenthuong.Text);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                            txt_makt.Text = dataTable.Rows[0]["MaKT"].ToString();
                            txt_kt.Text = dataTable.Rows[0]["TenKT"].ToString();
                            txt_giatri.Text = dataTable.Rows[0]["GiaTri"].ToString();
                            Reset();
                        }
                        else
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy phòng ban !";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }
    }
}
