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
    public partial class KyLuat : Form
    {
        public KyLuat()
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
                    string query = "SELECT ID, MaKL, TenKL, GiaTri FROM KyLuat ORDER BY MaKL";
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
                if (row.Cells["MaKL"].Value != null)
                {
                    txt_makl.Text = row.Cells["MaKL"].Value.ToString();
                    txt_makl.Enabled = false;
                }

                if (row.Cells["TenKL"].Value != null)
                {
                    txt_kl.Text = row.Cells["TenKL"].Value.ToString();
                }

                if (row.Cells["GiaTri"].Value != null)
                {
                    txt_giatri.Text = row.Cells["GiaTri"].Value.ToString();
                }
            }
        }

        private void Reset()
        {
            search_kyluat.Text = "";
            txt_makl.Enabled = true;
            txt_makl.Text = "";
            txt_kl.Text = "";
            txt_giatri.Text = "";
            LoadData();
        }

        private void add_kl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_makl.Text) || string.IsNullOrWhiteSpace(txt_kl.Text)
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
                string query = "INSERT INTO KyLuat (MaKL, TenKL, GiaTri) VALUES (@MaKL, @TenKL, @GiaTri)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKL", txt_makl.Text);
                    command.Parameters.AddWithValue("@TenKL", txt_kl.Text);
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

        private void btn_updateKL_Click(object sender, EventArgs e)
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
                string query = "UPDATE KyLuat SET TenKL = @TenKL, GiaTri = @GiaTri WHERE MaKL = @MaKL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKL", txt_makl.Text);
                    command.Parameters.AddWithValue("@TenKL", txt_kl.Text);
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

        private void btn_deleteKl_Click(object sender, EventArgs e)
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
                string query = "DELETE FROM KyLuat WHERE MaKL = @MaKL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKL", txt_makl.Text);

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

        private void btn_searchKl_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM KyLuat WHERE MaKL LIKE '%' + @SearchTerm + '%' OR TenKL LIKE '%' + @SearchTerm + '%' OR GiaTri LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string searchTerm = search_kyluat.Text;
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

                            txt_makl.Text = dataTable.Rows[0]["MaKL"].ToString();
                            txt_kl.Text = dataTable.Rows[0]["TenKL"].ToString();
                            txt_giatri.Text = dataTable.Rows[0]["GiaTri"].ToString();
                        }
                        else
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy kỷ luật!";
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

        private void reset1_Click_1(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
