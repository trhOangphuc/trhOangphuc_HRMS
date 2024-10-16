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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyNhanSu
{
    public partial class HomPagePanel : Form
    {


        public HomPagePanel()
        {
            InitializeComponent();
            LoadTongNhanVien();
            LoadTongPhongBan();
            LoadQuyHienTai();
            LoadChartNhanVien();
            LoadChartPhongBan();
            LoadChamCong();
            dtp_date.Value = DateTime.Now;
            //dtp_date.Enabled = false;
            chart_nhanvien.ChartAreas[0].BackColor = Color.Transparent;
            chart_phongban.ChartAreas[0].BackColor = Color.Transparent;
        }

        private void LoadChamCong()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error
                    {
                        ErrorText = "Lỗi kết nối Database!",
                        OkButtonText = "OK"
                    };
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();

                    // Lấy ngày từ DateTimePicker
                    DateTime selectedDate = dtp_date.Value.Date; // Lấy giá trị ngày từ DateTimePicker

                    string query = @"
            SELECT COUNT(*) 
            FROM ChamCong 
            WHERE CONVERT(DATE, NgayLamViec) = @NgayLamViec AND LamViec = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số kiểu DateTime cho truy vấn
                        command.Parameters.AddWithValue("@NgayLamViec", selectedDate); // Đảm bảo chỉ truyền phần ngày

                        // Lấy số lượng nhân viên làm việc (LamViec = true)
                        int count = (int)command.ExecuteScalar();

                        // Hiển thị kết quả vào lb_chamcong
                        lb_chamcong.Text = count.ToString();
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


        private void LoadTongNhanVien()
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
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
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
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }
        private void LoadQuyHienTai()
        {
            int month = DateTime.Now.Month; 
            int quy = (month - 1) / 3 + 1;
            lb_quy.Text = $"{quy}"; 
        }

        private void LoadChartNhanVien()
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
                    Error er = new Error();
                    er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void LoadChartPhongBan()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error
                    {
                        ErrorText = "Lỗi kết nối Database !",
                        OkButtonText = "OK"
                    };
                    error.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();

                    // Đếm số lượng nhân viên theo phòng ban từ bảng NhanVien và PhongBan
                    string query = @"
                SELECT pb.MaPB, COUNT(nv.ID) AS SoLuong 
                FROM PhongBan pb
                LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
                GROUP BY pb.MaPB";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Kiểm tra xem có dữ liệu hay không
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu để hiển thị cho biểu đồ số nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Thiết lập biểu đồ
                        chart_phongban.Series.Clear();
                        chart_phongban.ChartAreas.Clear();
                        chart_phongban.ChartAreas.Add(new ChartArea("NhanVienChartArea"));

                        Series series = new Series("SoLuongNhanVien")
                        {
                            ChartType = SeriesChartType.Pie // Thiết lập loại biểu đồ là hình tròn
                        };

                        // Thêm dữ liệu vào biểu đồ
                        foreach (DataRow row in dataTable.Rows)
                        {
                            series.Points.AddXY(row["MaPB"].ToString(), row["SoLuong"]);
                        }

                        chart_phongban.Series.Add(series);

                        // Tắt hiển thị nhãn cho từng điểm
                        foreach (DataPoint point in series.Points)
                        {
                            point.Label = ""; // Tắt hiển thị nhãn cho từng điểm
                        }

                        // Ngăn hiển thị giá trị trên các phần của biểu đồ
                        series.IsValueShownAsLabel = false; // Ngăn hiển thị giá trị trên các phần của biểu đồ

                        // Tắt hiển thị nhãn bên trong (nếu có)
                        foreach (DataPoint point in series.Points)
                        {
                            point.IsValueShownAsLabel = false; // Ngăn hiển thị giá trị cho từng điểm
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


        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            LoadChamCong();
        }

        private void lb_chamcong_Click(object sender, EventArgs e)
        {

        }
    }
}
