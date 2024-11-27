﻿using QuanLyNhanSu.Dialog;
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
            LoadDataCV();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void LoadDataCV()
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
                    string query = "SELECT ID, MaCV FROM ChucVu ORDER BY ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_chucvu.DataSource = dataTable;
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
                    string query = "SELECT ID, MaPB FROM PhongBan ORDER BY ID";
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

        private void Reset()
        {
            search_phongban.Text = "";
            txt_chucvu.Enabled = true;
            txt_mapb.Enabled = true;
            txt_mapb.Text = "";
            txt_chucvu.Text = "";
            LoadData();
            LoadDataCV();
        }

        private void resetb_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void add_pb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_mapb.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập tên phòng ban!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_mapb.Focus();
                return;
            }
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO PhongBan (MaPB) VALUES (@MaPB)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", txt_mapb.Text);

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
                        Notification notification = new Notification();
                        notification.NotificationText = "Phòng ban đã tồn tại !";
                        notification.OkButtonText = "OK";
                        notification.ShowDialog();
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
                string query = "UPDATE PhongBan SET MaPB = @MaPB WHERE MaPB = @MaPB";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
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
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
                }
            }


            if (dtg_chucvu.CurrentRow == null)
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn chức vụ để sửa!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "UPDATE ChucVu SET MaCV = @NewMaCV WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewMaCV", txt_chucvu.Text);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadDataCV(); 
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

        private void btn_deletePb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mapb.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn phòng ban để xóa!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem phòng ban có nhân viên nào không
                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE MaPB = @MaPB";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Phòng ban này có nhân viên. Vui lòng xóa hoặc chuyển nhân viên trước!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    string checkQuery2 = "SELECT COUNT(*) FROM Luong WHERE MaPB = @MaPB";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery2, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Phòng ban này có thông tin lương. Vui lòng xóa thông tin lương trước để xóa phòng ban!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    // Nếu không có nhân viên trong phòng ban, thực hiện xóa
                    string deleteQuery = "DELETE FROM PhongBan WHERE MaPB = @MaPB";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@MaPB", txt_mapb.Text);
                        deleteCommand.ExecuteNonQuery();
                        LoadData();

                        Success sc = new Success();
                        sc.BringToFront();
                        sc.ShowDialog();
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


        private void btn_searchPb_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM PhongBan WHERE MaPB LIKE '%' + @SearchTerm + '%'";
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
                        Error er = new Error();
                        er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                        er.OkButtonText = "OK";
                        er.ShowDialog();
                    }
                }
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM ChucVu WHERE MaCV LIKE '%' + @SearchTerm + '%'";
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
                            dtg_chucvu.DataSource = dataTable; 
                            txt_chucvu.Text = dataTable.Rows[0]["MaCV"].ToString(); 
                        }
                        else
                        {
                            Notification tb = new Notification();
                            tb.NotificationText = "Không tìm thấy chức vụ!";
                            tb.OkButtonText = "OK";
                            tb.ShowDialog();
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["MaPB"].Value != null)
                {
                    txt_mapb.Text = row.Cells["MaPB"].Value.ToString();
                    txt_mapb.Enabled = false;
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

        private void dtg_chucvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_chucvu.Rows.Count)
            {
                DataGridViewRow row = dtg_chucvu.Rows[e.RowIndex];

                if (row.Cells["MaCV"].Value != null)
                {
                    txt_chucvu.Text = row.Cells["MaCV"].Value.ToString();
                    txt_chucvu.Enabled = false;
                }
            }
        }

        private void SearchData(string searchValue)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM PhongBan WHERE MaPB LIKE '%' + @SearchTerm + '%' ";
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
                        }
                        //else
                        //{
                        //    Notification tb = new Notification();
                        //    tb.NotificationText = "Không tìm thấy phòng ban!";
                        //    tb.OkButtonText = "OK";
                        //    tb.ShowDialog();
                        //}
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

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT * FROM ChucVu WHERE MaCV LIKE '%' + @SearchTerm + '%'";
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
                            dtg_chucvu.DataSource = dataTable;
                        }
                        //else
                        //{
                        //    Notification tb = new Notification();
                        //    tb.NotificationText = "Không tìm thấy chức vụ!";
                        //    tb.OkButtonText = "OK";
                        //    tb.ShowDialog();
                        //}
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

        private void search_phongban_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_chucvu.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập tên chức vụ!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_chucvu.Focus();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "INSERT INTO ChucVu (MaCV) VALUES (@MaCV)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaCV", txt_chucvu.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LoadDataCV();
                        Success sc = new Success();
                        sc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Notification notification = new Notification();
                        notification.NotificationText = "Chức vụ đã tồn tại !";
                        notification.OkButtonText = "OK";
                        notification.ShowDialog();
                    }
                }
            }
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_chucvu.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn chức vụ để xóa!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            using (SqlConnection connection = connectdatabase.Connect())
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem chức vụ có nhân viên nào không
                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE MaCV = @MaCV";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaCV", txt_chucvu.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Chức vụ này có nhân viên. Vui lòng xóa hoặc chuyển nhân viên trước!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    string checkQuery2 = "SELECT COUNT(*) FROM Luong WHERE MaCV = @MaCV";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery2, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaCV", txt_chucvu.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Chức vụ này có nhân viên. Vui lòng xóa thông tin lương trước để xóa !";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    // Nếu không có nhân viên trong chức vụ, thực hiện xóa
                    string deleteQuery = "DELETE FROM ChucVu WHERE MaCV = @MaCV";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@MaCV", txt_chucvu.Text);
                        deleteCommand.ExecuteNonQuery();
                        LoadDataCV();

                        Success sc = new Success();
                        sc.ShowDialog();
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
}
