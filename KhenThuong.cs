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
            dataGridView1.CellClick += dataGridView1_CellClick;
            ThemKhenThuongKhenThuong();
        }

        private void ThemKhenThuongKhenThuong()
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

                    // Dữ liệu cần thêm
                    string[] maKTArray = { "Đúng giờ", "Ngày công đủ" };
                    string[] hinhThucArray = { "Khen thưởng đi đúng giờ", "Khen thưởng chấm công đủ" };

                    for (int i = 0; i < maKTArray.Length; i++)
                    {
                        // Kiểm tra xem mã khen thưởng đã tồn tại chưa
                        string checkKhenThuong = "SELECT COUNT(*) FROM KhenThuong WHERE MaKT = @MaKT";
                        using (SqlCommand checkCommand = new SqlCommand(checkKhenThuong, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@MaKT", maKTArray[i]);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count == 0) // Nếu không tồn tại thì thêm mới
                            {
                                string insertKhenThuong = "INSERT INTO KhenThuong (MaKT, HinhThuc) VALUES (@MaKT, @HinhThuc)";
                                using (SqlCommand command = new SqlCommand(insertKhenThuong, connection))
                                {
                                    command.Parameters.AddWithValue("@MaKT", maKTArray[i]);
                                    command.Parameters.AddWithValue("@HinhThuc", hinhThucArray[i]);

                                    command.ExecuteNonQuery();
                                }
                            }
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
                    string query = "SELECT MaKT, HinhThuc, GiaTri FROM KhenThuong ORDER BY GiaTri";
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
                if (row.Cells["MaKT"].Value != null)
                {
                    txt_makt.Text = row.Cells["MaKT"].Value.ToString();
                    txt_makt.Enabled = false;
                }

                if (row.Cells["HinhThuc"].Value != null)
                {
                    txt_hinhthuc.Text = row.Cells["HinhThuc"].Value.ToString();
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
            txt_giatri.Text = "";
            txt_hinhthuc.Text = string.Empty;
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void add_kt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_makt.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập tên khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_makt.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(txt_hinhthuc.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập hình thức khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_hinhthuc.Focus();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO KhenThuong (MaKT, HinhThuc, GiaTri) VALUES (@MaKT, @HinhThuc, @GiaTri)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKT", txt_makt.Text);
                    command.Parameters.AddWithValue("@HinhThuc", txt_hinhthuc.Text);
                    command.Parameters.AddWithValue("@GiaTri", txt_giatri.Text);

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

        private void btn_updateKT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng để sửa !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE KhenThuong SET HinhThuc = @HinhThuc, GiaTri = @GiaTri WHERE MaKT = @MaKT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKT", txt_makt.Text);
                    command.Parameters.AddWithValue("@HinhThuc", txt_hinhthuc.Text);
                    command.Parameters.AddWithValue("@GiaTri", txt_giatri.Text);

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

        private void btn_deleteKT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_makt.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng để xóa !";
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

        private void reset1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_searchKT_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKT, HinhThuc, GiaTri FROM KhenThuong WHERE MaKT LIKE '%' + @SearchTerm + '%' OR HinhThuc LIKE '%' +@SearchTerm + '%' OR GiaTri LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", search_khenthuong.Text);

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
                            tb.NotificationText = "Không tìm thấy khen thưởng !";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                            LoadData();
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

        private void search_khenthuong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
