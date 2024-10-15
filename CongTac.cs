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
    public partial class CongTac : Form
    {
        public CongTac()
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
                    string query = "SELECT ID, MaCongTac, GhiChu FROM CongTac ORDER BY ID";
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
            
            txt_congtac.Text = "";
            txt_ghichu.Text = "";
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void add_hs_Click(object sender, EventArgs e)
        {
            if(txt_ghichu.Text.Length > 50)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ký tự nhỏ hơn 50 !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_congtac.Text)
              || string.IsNullOrWhiteSpace(txt_ghichu.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập đầy đủ thông tin !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO CongTac (MaCongTac, GhiChu) VALUES (@MaCongTac, @Ghichu)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaCongTac", txt_congtac.Text);
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
                        Notification notification = new Notification();
                        notification.NotificationText = "Đã tồn tại !";
                        notification.OkButtonText = "OK";
                        notification.ShowDialog();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["MaCongTac"].Value != null)
                {
                    txt_congtac.Text = row.Cells["MaCongTac"].Value.ToString();
                    txt_congtac.Enabled = false;
                }

                if (row.Cells["GhiChu"].Value != null)
                {
                    txt_ghichu.Text = row.Cells["GhiChu"].Value.ToString();
                }
            }
        }

        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (txt_ghichu.Text.Length > 50)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ký tự nhỏ hơn 50 !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
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
                string query = "UPDATE CongTac SET GhiChu = @GhiChu WHERE MaCongTac = @MaCongTac";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaCongTac", txt_congtac.Text);
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
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void btn_deletehs_Click(object sender, EventArgs e)
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
                string query = "DELETE FROM CongTac WHERE MaCongTac = @MaCongTac";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaCongTac", txt_congtac.Text);

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
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void search_hs_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM CongTac WHERE MaCongTac LIKE '%' + @SearchTerm + '%' OR GhiChu LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", search_congtac.Text);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy công tác!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                            LoadData();
                            Reset();
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
