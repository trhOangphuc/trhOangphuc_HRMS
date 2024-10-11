﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyNhanSu
{
    public partial class HomPagePanel : Form
    {

        public HomPagePanel()
        {
            InitializeComponent();
            LoadDataNhanVien();
            LoadDataPhongban();
            LoadDataCongTac();
            LoadTongNhanVien();
            LoadTongPhongBan();
            LoadQuyHienTai();
            LoadChartNhanVien();
            LoadChartPhongBan();

        }

        private void LoadDataCongTac()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadDataNhanVien()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "SELECT ID, HoTen, GioiTinh, NgaySinh, Sdt, DiaChi FROM NhanVien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        Dtg_nhanvien.DataSource = dataTable;
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
            using(SqlConnection connection = connectdatabase.Connect())
            {
                if(connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    connection.Open();
                    string query = "SELECT ID, MaPB, TenPB FROM PhongBan";
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
        private void LoadTongNhanVien()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM NhanVien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar(); 
                        lb_tongnv.Text = count.ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTongPhongBan()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM PhongBan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        lb_tongpb.Text = count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadQuyHienTai()
        {
            int month = DateTime.Now.Month; 
            int quy = (month - 1) / 3 + 1;
            lb_quy.Text = $"{quy}"; 
        }

        // Hàm tải dữ liệu nhân viên lên biểu đồ tròn (hiển thị số lượng nhân viên theo giới tính và đếm ID)
        private void LoadChartNhanVien()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    // Đếm số lượng nhân viên dựa trên giới tính và ID
                    string query = "SELECT GioiTinh, COUNT(ID) AS SoLuong FROM NhanVien GROUP BY GioiTinh";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        chart_nhanvien.Series.Clear();
                        chart_nhanvien.ChartAreas.Clear();
                        chart_nhanvien.ChartAreas.Add(new ChartArea("NhanVienChartArea"));

                        Series series = new Series("NhanVien");
                        series.ChartType = SeriesChartType.Pie;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            series.Points.AddXY(row["GioiTinh"].ToString(), row["SoLuong"]);
                        }

                        chart_nhanvien.Series.Add(series); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadChartPhongBan()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    // Đếm số lượng phòng ban dựa trên ID từ bảng PhongBan
                    string query = "SELECT TenPB, COUNT(ID) AS SoLuong FROM PhongBan GROUP BY TenPB";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Kiểm tra xem có dữ liệu hay không
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu để hiển thị cho biểu đồ phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Thiết lập biểu đồ
                        chart_phongban.Series.Clear();
                        chart_phongban.ChartAreas.Clear();
                        chart_phongban.ChartAreas.Add(new ChartArea("PhongBanChartArea"));

                        Series series = new Series("PhongBan");
                        series.ChartType = SeriesChartType.Pie;

                        // Thêm dữ liệu vào biểu đồ
                        foreach (DataRow row in dataTable.Rows)
                        {
                            series.Points.AddXY(row["TenPB"].ToString(), row["SoLuong"]);
                        }

                        chart_phongban.Series.Add(series);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm tìm kiếm dữ liệu từ cả bảng NhanVien và PhongBan
        private void SearchData(string searchValue)
        {
            // Kiểm tra nếu ô tìm kiếm trống thì load lại toàn bộ dữ liệu
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadDataNhanVien();  // Tải lại dữ liệu nhân viên
                LoadDataPhongban();  // Tải lại dữ liệu phòng ban
                return;
            }

            // Tìm kiếm trong bảng NhanVien
            SearchNhanVien(searchValue);

            // Tìm kiếm trong bảng PhongBan
            SearchPhongBan(searchValue);
        }

        // Hàm tìm kiếm trong bảng NhanVien
        private void SearchNhanVien(string searchValue)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    // Tìm kiếm trong bảng NhanVien
                    string query = "SELECT ID, HoTen, GioiTinh, NgaySinh, Sdt, DiaChi FROM NhanVien WHERE HoTen LIKE @searchValue OR Sdt LIKE @searchValue";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        Dtg_nhanvien.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm tìm kiếm trong bảng PhongBan
        private void SearchPhongBan(string searchValue)
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();
                    // Tìm kiếm trong bảng PhongBan
                    string query = "SELECT ID, MaPB, TenPB FROM PhongBan WHERE TenPB LIKE @searchValue";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_phongban.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm phòng ban: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện khi text trong ô tìm kiếm thay đổi
        private void search_home_TextChanged(object sender, EventArgs e)
        {
            SearchData(search_home.Text); // Gọi hàm tìm kiếm khi thay đổi nội dung trong hộp tìm kiếm
        }

        // Sự kiện khi nhấn nút tìm kiếm
        private void btn_searchHome_Click(object sender, EventArgs e)
        {
            SearchData(search_home.Text); // Gọi hàm tìm kiếm khi nhấn nút tìm kiếm
        }

    }
}
