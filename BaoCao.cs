using QuanLyNhanSu.Dialog;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
            LoadComboboxBaoCao();
        }

        private int TinhSoNgayLamViec()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int totalDaysInMonth = DateTime.DaysInMonth(year, month); // Tổng số ngày trong tháng hiện tại
            int workingDays = 0; // Số ngày làm việc

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

        private void LoadComboboxBaoCao()
        {
            comboBoxBaoCao.Items.Clear();
            comboBoxBaoCao.Items.Add("Báo cáo hồ sơ nhân viên");
            comboBoxBaoCao.Items.Add("Báo cáo chính sách khen thưởng");
            comboBoxBaoCao.Items.Add("Báo cáo chính sách khen thưởng dự án");
            comboBoxBaoCao.Items.Add("Báo cáo chính sách kỷ luật");
            comboBoxBaoCao.Items.Add("Báo cáo phân công");
            comboBoxBaoCao.Items.Add("Báo cáo chấm công");
            comboBoxBaoCao.Items.Add("Báo cáo tính lương");
            comboBoxBaoCao.SelectedIndex = 0;
        }


        private void BaoCaoHoSoNhanVien()
        {
            string query = @"
            SELECT 
                NV.ID, 
                NV.HoTen, 
                NV.GioiTinh, 
                NV.NgaySinh, 
                NV.Sdt, 
                NV.DiaChi, 
                PB.MaPB, 
                CV.MaCV 
            FROM 
                NhanVien NV
            LEFT JOIN 
                PhongBan PB ON NV.MaPB = PB.MaPB
            LEFT JOIN 
                ChucVu CV ON NV.MaCV = CV.MaCV ORDER BY ID";
            DataTable hoso = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(hoso);
                }
            }
            ExportToExcel(hoso, "HoSoNhanVien");
        }

        private void BaoCaoChinhSachKT()
        {
            string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien,NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KhenThuong KT ON CS.MaKT = KT.MaKT
                                     WHERE CS.MaKT IS NOT NULL
                                     ORDER BY IDnhanvien";
            DataTable khenthuong = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(khenthuong);
                }
            }
            ExportToExcel(khenthuong, "ChinhSachKhenThuong");
        }

        private void BaoCaoChinhSachKTDA()
        {
            string query = @"SELECT DISTINCT 
                        CS.MaChinhSach,
                        CS.IDnhanvien,
                        NV.HoTen,
                        CS.MaDuAn,
                        DA.PhuCapDuAn,
                        CS.KTDuAn
                        FROM 
                            ChinhSach CS
                        LEFT JOIN 
                            NhanVien NV ON CS.IDnhanvien = NV.ID
                        LEFT JOIN 
                            DuAn DA ON CS.MaDuAn = DA.MaDuAn
                        WHERE 
                            CS.MaDuAn IS NOT NULL 
                            AND EXISTS (
                            SELECT 1 
                            FROM PhanCong PC 
                            WHERE PC.IDnhanvien = CS.IDnhanvien 
                            AND PC.MaDuAn = CS.MaDuAn
                            )
                        ORDER BY CS.IDnhanvien";
            DataTable khenthuongDA = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(khenthuongDA);
                }
            }
            ExportToExcel(khenthuongDA, "ChinhSachKhenThuongDuAn");
        }

        private void BaoCaoChinhSachKL()
        {
            string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KyLuat KL ON CS.MaKL = KL.MaKL
                                     WHERE CS.MaKL IS NOT NULL
                                     ORDER BY IDnhanvien";
            DataTable KyLuat = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(KyLuat);
                }
            }
            ExportToExcel(KyLuat, "ChinhSachKyLuat");
        }

        private void BaoCaoPhanCong()
        {
            string query = @"
                SELECT 
                    PC.MaPhanCong, 
                    PC.IDnhanvien, 
                    NV.HoTen,
                    PC.MaDuAn, 
                    DA.TenDuAn,
                    PC.NgayBatDau, 
                    PC.NgayKetThuc, 
                    PC.ViTri 
                FROM 
                    PhanCong PC
                LEFT JOIN
                    NhanVien NV ON PC.IDnhanvien = NV.ID
                LEFT JOIN 
                    DuAn DA ON PC.MaDuAn = DA.MaDuAn ORDER BY MaPhanCong";
            DataTable PhanCong = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(PhanCong);
                }
            }
            ExportToExcel(PhanCong, "PhanCong");
        }

        private void BaoCaoChamCong()
        {
            string query = @"
                SELECT 
                    CC.MaChamCong,
                    CC.IDnhanvien, 
                    NV.HoTen, 
                    PB.MaPB, 
                    CC.NgayLamViec,
                    CC.LamViec,
                    CC.TrangThai
                FROM 
                    ChamCong CC
                LEFT JOIN 
                    NhanVien NV ON CC.IDnhanvien = NV.ID
                LEFT JOIN 
                    PhongBan PB ON NV.MaPB = PB.MaPB ORDER BY IDnhanvien, NgayLamViec";
            DataTable ChamCong = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ChamCong);
                }
            }
            ExportToExcel(ChamCong, "ChamCong");
        }

        private void BaoCaoTinhLuong()
        {
            // Kết nối tới cơ sở dữ liệu và truy vấn dữ liệu bảng lương
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
                NV.MaCV,  L.LuongCoBan;";
            DataTable bangLuong = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int soNgayLamViec = TinhSoNgayLamViec();
                    command.Parameters.AddWithValue("@SoNgayLamViec", soNgayLamViec);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(bangLuong);
                }
            }
            string currentMonth = DateTime.Now.ToString("MM");
            ExportToExcel(bangLuong, "BangLuongthang" + currentMonth);
        }

        public void ExportToExcel(DataTable dataTable, string sheetName)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                Error er = new Error();
                er.ErrorText = "Không có dữ liệu để xuất ra Excel. " ;  
                er.OkButtonText = "OK";
                er.ShowDialog();
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                Error er = new Error();
                er.ErrorText = "Excel is not installed on this system. " ; 
                er.OkButtonText = "OK";
                er.ShowDialog();

                return;
            }

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = sheetName;

            for (int i = 1; i < dataTable.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    var value = dataTable.Rows[i][j];
                    worksheet.Cells[i + 2, j + 1] = value.ToString();
                    if (dataTable.Columns[j].ColumnName == "NgaySinh")
                    {
                        worksheet.Cells[i + 2, j + 1].NumberFormat = "dd/MM/yyyy";
                    }
                }
            }
            worksheet.Columns.AutoFit();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu báo cáo";
                saveFileDialog.FileName = $"{sheetName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    Notification notification = new Notification();
                    notification.NotificationText = $"Đã lưu báo cáo tại: {saveFileDialog.FileName}";
                    notification.OkButtonText = "OK";
                    notification.ShowDialog();
                }
            }

            workbook.Close();
            excelApp.Quit();

            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);
        }



        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Error er = new Error();
                er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;  // Thông báo lỗi chung
                er.OkButtonText = "OK";
                er.ShowDialog();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBaoCao.SelectedItem == null)
            {
                Error er = new Error();
                er.ErrorText = "Vui lòng chọn báo cáo trước! ";  // Thông báo lỗi chung
                er.OkButtonText = "OK";
                er.ShowDialog();
                return;
            }

            string selected = comboBoxBaoCao.SelectedItem.ToString();
            switch (selected)
            {
                case "Báo cáo hồ sơ nhân viên":
                    BaoCaoHoSoNhanVien();
                    break;

                case "Báo cáo chính sách khen thưởng":
                    BaoCaoChinhSachKT();
                    break;
                case "Báo cáo chính sách khen thưởng dự án":
                    BaoCaoChinhSachKTDA();
                    break;
                case "Báo cáo chính sách kỷ luật":
                    BaoCaoChinhSachKL();
                    break;
                case "Báo cáo phân công":
                    BaoCaoPhanCong();
                    break;

                case "Báo cáo chấm công":
                    BaoCaoChamCong();
                    break;

                case "Báo cáo tính lương":
                    BaoCaoTinhLuong();
                    break;

                default:
                    Error error = new Error();
                    error.ErrorText = "Vui lòng chọn báo cáo hợp lệ!";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    break;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Notification notification = new Notification();
            notification.NotificationText = "Tính năng đang phát triển !";
            notification.OkButtonText = "OK";
            notification.ShowDialog();
        }
    }
}
