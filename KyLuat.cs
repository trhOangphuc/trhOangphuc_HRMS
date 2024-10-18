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
            dataGridView1.CellClick += dataGridView1_CellClick;
            ThemKyLuatChamCong();
        }

        private void ThemKyLuatChamCong()
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
                    string[] maKLArray = { "Đi muộn", "Ngày công thiếu" };
                    string[] hinhThucArray = { "Kỷ luật đi muộn", "Kỷ luật ngày công thiếu" };

                    for (int i = 0; i < maKLArray.Length; i++)
                    {
                        // Kiểm tra xem mã khen thưởng đã tồn tại chưa
                        string checkKhenThuong = "SELECT COUNT(*) FROM KyLuat WHERE MaKL = @MaKL";
                        using (SqlCommand checkCommand = new SqlCommand(checkKhenThuong, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@MaKL", maKLArray[i]);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count == 0) // Nếu không tồn tại thì thêm mới
                            {
                                string insertKhenThuong = "INSERT INTO KyLuat (MaKL, HinhThuc) VALUES (@MaKL, @HinhThuc)";
                                using (SqlCommand command = new SqlCommand(insertKhenThuong, connection))
                                {
                                    command.Parameters.AddWithValue("@MaKL", maKLArray[i]);
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
                    string query = "SELECT MaKL, HinhThuc, GiaTri FROM KyLuat ORDER BY GiaTri";
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

                if (row.Cells["MaKL"].Value != null)
                {
                    txt_makl.Text = row.Cells["MaKL"].Value.ToString();
                    txt_makl.Enabled = false;
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
            search_kyluat.Text = "";
            txt_makl.Enabled = true;
            txt_makl.Text = "";
            txt_giatri.Text = "";
            txt_hinhthuc.Text = string.Empty;
            dataGridView1.ClearSelection();
            LoadData();
        }

        private void add_kl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_makl.Text) )
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập tên kỷ luật !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_makl.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(txt_hinhthuc.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập hình thức kỷ luật !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_hinhthuc.Focus();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO KyLuat (MaKL,HinhThuc,GiaTri) VALUES (@MaKL, @HinhThuc, @GiaTri)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKL", txt_makl.Text);
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
                string query = "UPDATE KyLuat SET HinhThuc = @HinhThuc, GiaTri = @GiaTri WHERE MaKL = @MaKL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKL", txt_makl.Text);
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

        private void btn_deleteKl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_makl.Text))
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

        private void btn_searchKl_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKL, HinhThuc, GiaTri FROM KyLuat WHERE MaKL LIKE '%' + @SearchTerm + '%' OR HinhThuc LIKE '%' + @SearchTerm +'%' OR GiaTri LIKE '%' + @SearchTerm + '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", search_kyluat.Text);

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
                            tb.NotificationText = "Không tìm thấy kỷ luật!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
                            LoadData();
                            Reset();
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

        private void reset1_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void search_kyluat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
