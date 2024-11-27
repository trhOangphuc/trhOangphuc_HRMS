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
    public partial class TinhLuong : Form
    {
        public TinhLuong()
        {
            InitializeComponent();
            //LoadComboBoxData();
            dataGridView1.Columns["TongLuong"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView1.ReadOnly = true;
            BangLuong();
            label3.Text = $"Bảng lương tháng {DateTime.Now.Month}";
        }

        public DataTable GetBangLuong()
        {
            DataTable DataTable = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database!";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                }

                try
                {
                    connection.Open();
                    string query = @"
                          SELECT 
                                NV.ID, 
                                NV.HoTen,
                                NV.NgaySinh,
                                NV.MaPB,
                                NV.MaCV,
                                L.LuongCoBan,
                                SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0))  AS TongPhuCap2,
                                COUNT(DISTINCT CASE WHEN CC.LamViec = 1 THEN CC.NgayLamViec END) AS TongNgayCong2, 
                                SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) + SUM(DISTINCT COALESCE(KT.GiaTri, 0)) AS TongThuong2,
                                SUM(DISTINCT COALESCE(KL.GiaTri, 0)) AS TongKyLuat2,     
                                ROUND (
                                (
                                 SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0)) +
                                 SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) - 
                                 SUM(DISTINCT COALESCE(KL.GiaTri, 0)) + 
                                 (SUM(DISTINCT CASE WHEN CC.LamViec = 1 THEN 1 ELSE 0 END) * (L.LuongCoBan / @SoNgayLamViec))), 2
                                ) AS TongLuong2
                            FROM 
                                NhanVien NV
                            LEFT JOIN 
                                ChinhSach CS ON NV.ID = CS.IDnhanvien
                            LEFT JOIN 
                                KhenThuong KT ON CS.MaKT = KT.MaKT
                            LEFT JOIN 
                                DuAn DU ON CS.MaDuAn = DU.MaDuAn
                            LEFT JOIN 
                                PhanCong PC ON NV.ID = PC.IDnhanvien
                            LEFT JOIN 
                                KyLuat KL ON CS.MaKL = KL.MaKL
                            LEFT JOIN 
                                Luong L ON NV.MaPB = L.MaPB AND NV.MaCV = L.MaCV
                            LEFT JOIN 
                                ChamCong CC ON NV.ID = CC.IDnhanvien 
                            WHERE MONTH(CC.NgayLamViec) = MONTH(GETDATE()) 
                                AND YEAR(CC.NgayLamViec) = YEAR(GETDATE()) 
                            GROUP BY 
                                NV.ID,
                                NV.HoTen,
                                NV.NgaySinh,
                                NV.MaPB,
                                NV.MaCV,  L.LuongCoBan;
                ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int soNgayLamViec = TinhSoNgayLamViec();
                        command.Parameters.AddWithValue("@SoNgayLamViec", soNgayLamViec);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                        dataGridView2.AllowUserToAddRows = false;
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
            return DataTable;
        }
        private void BangLuong()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database!";
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
                                NV.NgaySinh,
                                NV.MaPB,
                                NV.MaCV,
                                L.LuongCoBan,
                                SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0))  AS TongPhuCap2,
                                COUNT(DISTINCT CASE WHEN CC.LamViec = 1 THEN CC.NgayLamViec END) AS TongNgayCong2, 
                                SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) + SUM(DISTINCT COALESCE(KT.GiaTri, 0)) AS TongThuong2,
                                SUM(DISTINCT COALESCE(KL.GiaTri, 0)) AS TongKyLuat2,     
                                ROUND (
                                (
                                 SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0)) +
                                 SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) - 
                                 SUM(DISTINCT COALESCE(KL.GiaTri, 0)) + 
                                 (SUM(DISTINCT CASE WHEN CC.LamViec = 1 THEN 1 ELSE 0 END) * (L.LuongCoBan / @SoNgayLamViec))), 2
                                ) AS TongLuong2
                            FROM 
                                NhanVien NV
                            LEFT JOIN 
                                ChinhSach CS ON NV.ID = CS.IDnhanvien
                            LEFT JOIN 
                                KhenThuong KT ON CS.MaKT = KT.MaKT
                            LEFT JOIN 
                                DuAn DU ON CS.MaDuAn = DU.MaDuAn
                            LEFT JOIN 
                                PhanCong PC ON NV.ID = PC.IDnhanvien
                            LEFT JOIN 
                                KyLuat KL ON CS.MaKL = KL.MaKL
                            LEFT JOIN 
                                Luong L ON NV.MaPB = L.MaPB AND NV.MaCV = L.MaCV
                            LEFT JOIN 
                                ChamCong CC ON NV.ID = CC.IDnhanvien 
                            WHERE MONTH(CC.NgayLamViec) = MONTH(GETDATE()) 
                                AND YEAR(CC.NgayLamViec) = YEAR(GETDATE()) 
                            GROUP BY 
                                NV.ID,
                                NV.HoTen,
                                NV.NgaySinh,
                                NV.MaPB,
                                NV.MaCV,  L.LuongCoBan;
                ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int soNgayLamViec = TinhSoNgayLamViec();
                        command.Parameters.AddWithValue("@SoNgayLamViec", soNgayLamViec);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                        dataGridView2.AllowUserToAddRows = false;
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

        //private void LoadComboBoxData()
        //{
        //    using (SqlConnection connection = connectdatabase.Connect())
        //    {
        //        if (connection == null)
        //        {
        //            Error error = new Error();
        //            error.ErrorText = "Lỗi kết nối Database!";
        //            error.OkButtonText = "OK";
        //            error.ShowDialog();
        //            return;
        //        }

        //        try
        //        {
        //            connection.Open();
        //            string query = "SELECT MaPB, MaCV, MaLuong FROM Luong ORDER by MaPB";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                SqlDataReader reader = command.ExecuteReader();
        //                DataTable dt = new DataTable();
        //                dt.Load(reader);
        //                dt.Columns.Add("DisplayMember", typeof(string), "TRIM(MaPB) + ' - ' + TRIM(MaCV)");


        //                cmb_maluong.DataSource = dt;
        //                cmb_maluong.DisplayMember = "DisplayMember";
        //                cmb_maluong.ValueMember = "MaLuong";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Error er = new Error();
        //            er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;
        //            er.OkButtonText = "OK";
        //            er.ShowDialog();
        //        }
        //    }
        //}

        private void Reset()
        {
            txt_manv.Text = string.Empty;
            txt_thang.Text = string.Empty;
            dataGridView1.ClearSelection();
        }
        private void LoadData()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database!";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    return;
                }

                if (!int.TryParse(txt_manv.Text, out int idNhanVien))
                {
                    Notification notification = new Notification();
                    notification.NotificationText = "Sai ID nhân viên!";
                    notification.OkButtonText = "OK";
                    notification.ShowDialog();
                    txt_manv.Focus();
                    return;
                }

                int thang;
                if (!int.TryParse(txt_thang.Text, out thang) || thang < 1 || thang > 12)
                {
                    Notification notification = new Notification();
                    notification.NotificationText = "Tháng phải là số nguyên từ 1 đến 12!";
                    notification.OkButtonText = "OK";
                    notification.ShowDialog();
                    return;
                }

                try
                {
                    connection.Open();

                    // Kiểm tra xem có chấm công cho nhân viên trong tháng nhập vào không
                    string checkChamCongQuery = @"
                SELECT COUNT(*) 
                FROM ChamCong 
                WHERE IDnhanvien = @IDnhanvien 
                    AND MONTH(NgayLamViec) = @Thang 
                    AND YEAR(NgayLamViec) = YEAR(GETDATE())";

                    using (SqlCommand checkChamCongCommand = new SqlCommand(checkChamCongQuery, connection))
                    {
                        checkChamCongCommand.Parameters.AddWithValue("@IDnhanvien", idNhanVien);
                        checkChamCongCommand.Parameters.AddWithValue("@Thang", thang);

                        int chamCongCount = (int)checkChamCongCommand.ExecuteScalar();

                        if (chamCongCount == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Không có dữ liệu chấm công cho nhân viên trong tháng đã chọn!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    // Nếu có dữ liệu chấm công, tiến hành tải dữ liệu bảng lương
                    string query = @"
                SELECT 
                    NV.ID, 
                    NV.HoTen,
                    L.LuongCoBan,
                    SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0)) AS TongPhuCap,
                    COUNT(DISTINCT CASE WHEN CC.LamViec = 1 THEN CC.NgayLamViec END) AS TongNgayCong, 
                    SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) + SUM(DISTINCT COALESCE(KT.GiaTri, 0)) AS TongThuong,
                    SUM(DISTINCT COALESCE(KL.GiaTri, 0)) AS TongKyLuat,     
                    ROUND (
                    (
                        SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0)) +
                        SUM(DISTINCT COALESCE(CS.KTDuAn, 0)) - 
                        SUM(DISTINCT COALESCE(KL.GiaTri, 0)) + 
                        (SUM(DISTINCT CASE WHEN CC.LamViec = 1 THEN 1 ELSE 0 END) * (L.LuongCoBan / @SoNgayLamViec))), 2
                    ) AS TongLuong 
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    ChinhSach CS ON NV.ID = CS.IDnhanvien
                LEFT JOIN 
                    KhenThuong KT ON CS.MaKT = KT.MaKT
                LEFT JOIN 
                    DuAn DU ON CS.MaDuAn = DU.MaDuAn
                LEFT JOIN 
                    PhanCong PC ON NV.ID = PC.IDnhanvien
                LEFT JOIN 
                    KyLuat KL ON CS.MaKL = KL.MaKL
                LEFT JOIN 
                    Luong L ON NV.MaPB = L.MaPB AND NV.MaCV = L.MaCV
                LEFT JOIN 
                    ChamCong CC ON NV.ID = CC.IDnhanvien 
                WHERE 
                    CC.LamViec = 1 
                    AND MONTH(CC.NgayLamViec) = @Thang 
                    AND YEAR(CC.NgayLamViec) = YEAR(GETDATE()) 
                    AND NV.ID = @MaNV
                GROUP BY 
                    NV.ID, NV.HoTen, L.LuongCoBan;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", idNhanVien);
                        command.Parameters.AddWithValue("@Thang", thang);
                        int soNgayLamViec = TinhSoNgayLamViec();
                        command.Parameters.AddWithValue("@SoNgayLamViec", soNgayLamViec);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Không có dữ liệu lương cho nhân viên này!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AllowUserToAddRows = false;

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


        private int TinhSoNgayLamViec()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int totalDaysInMonth = DateTime.DaysInMonth(year, month); 
            int workingDays = 0; 

            for (int day = 1; day <= totalDaysInMonth; day++)
            {
                DateTime currentDate = new DateTime(year, month, day);
                // Kiểm tra xem ngày hiện tại có phải là thứ Bảy (6) hoặc Chủ Nhật (0) không
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++; // Tăng số ngày làm việc nếu không phải thứ Bảy hoặc Chủ Nhật
                }
            }

            return workingDays;
        }


        private void btn_chamcong_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
