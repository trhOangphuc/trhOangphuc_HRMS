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
                SUM(DISTINCT L.PhuCap) + SUM(DISTINCT COALESCE(DU.PhuCapDuAn, 0))  AS TongPhuCap,
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
                er.ErrorText = "Không có dữ liệu để xuất ra Excel.";
                er.OkButtonText = "OK";
                er.ShowDialog();
                return;
            }

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.Sheets[1];
                worksheet.Name = sheetName;

                // Thêm tiêu đề cột
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                    worksheet.Cells[1, i].Font.Bold = true; // Đậm tiêu đề
                }

                // Thêm dữ liệu
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        var value = dataTable.Rows[i][j];
                        worksheet.Cells[i + 2, j + 1] = value.ToString();

                        // Định dạng ngày tháng nếu cần
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
            }
            catch (Exception ex)
            {
                Error er = new Error();
                er.ErrorText = "Đã xảy ra lỗi: " + ex.Message; // Thông báo lỗi cụ thể
                er.OkButtonText = "OK";
                er.ShowDialog();
            }
            finally
            {
                // Giải phóng tài nguyên
                if (workbook != null)
                {
                    workbook.Close();
                    releaseObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    releaseObject(excelApp);
                }
                releaseObject(worksheet);
            }
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
                    BaoCaoHoSoNhanVienWord();
                    break;

                case "Báo cáo chính sách khen thưởng":
                    BaoCaoChinhSachKTWord();
                    break;
                case "Báo cáo chính sách khen thưởng dự án":
                    BaoCaoChinhSachKTDAWord();
                    break;
                case "Báo cáo chính sách kỷ luật":
                    BaoCaoChinhSachKLWord();
                    break;
                case "Báo cáo phân công":
                    BaoCaoPhanCongWord();
                    break;

                case "Báo cáo chấm công":
                    BaoCaoChamCongWord();
                    break;

                case "Báo cáo tính lương":
                    BaoCaoTinhLuongWord();
                    break;

                default:
                    Error error = new Error();
                    error.ErrorText = "Vui lòng chọn báo cáo hợp lệ!";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    break;
            }
            ExportToWord(dataGridViewReports, "Báo cáo " + selected);
        }

        public void ExportToWord(DataGridView dataGridView, string fileName)
        {
            if (dataGridView.Rows.Count == 0)
            {
                Error er = new Error();
                er.ErrorText = "Không có dữ liệu để xuất ra Word.";
                er.OkButtonText = "OK";
                er.ShowDialog();
                return;
            }

            Microsoft.Office.Interop.Word.Application wordApp = null;
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;

                var document = wordApp.Documents.Add();

                // Thêm tiêu đề
                var range = document.Range();
                range.Text = "Báo cáo: " + fileName;
                range.Font.Name = "Arial";
                range.Font.Size = 8;
                range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.InsertParagraphAfter();

                // Thêm bảng
                var table = document.Tables.Add(range, dataGridView.Rows.Count + 1, dataGridView.Columns.Count);
                table.Borders.Enable = 1;

                // Đặt chiều rộng bảng
                table.PreferredWidthType = Microsoft.Office.Interop.Word.WdPreferredWidthType.wdPreferredWidthPercent;
                table.PreferredWidth = 100; // 100% chiều rộng

                // Thêm tiêu đề cột từ DataGridView
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    var cell = table.Cell(1, i + 1);
                    cell.Range.Text = dataGridView.Columns[i].HeaderText;
                    cell.Range.Bold = 1;
                    cell.Range.Font.Size = 8;
                    cell.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray25;
                    cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; // Căn giữa dọc
                }

                // Thêm dữ liệu từ DataGridView
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        var cell = table.Cell(i + 2, j + 1);
                        cell.Range.Text = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                        cell.Range.Font.Size = 8;

                        // Căn giữa cho ô dữ liệu
                        cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; // Căn giữa ngang
                        cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; // Căn giữa dọc
                    }
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Word Files (*.docx)|*.docx";
                    saveFileDialog.Title = "Lưu báo cáo";
                    saveFileDialog.FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.docx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        document.SaveAs2(saveFileDialog.FileName);
                        Notification notification = new Notification();
                        notification.NotificationText = $"Đã lưu báo cáo tại: {saveFileDialog.FileName}";
                        notification.OkButtonText = "OK";
                        notification.ShowDialog();
                    }
                }

                document.Close();
            }
            catch (Exception ex)
            {
                Error er = new Error();
                er.ErrorText = "Đã xảy ra lỗi: " + ex.Message;
                er.OkButtonText = "OK";
                er.ShowDialog();
            }
            finally
            {
                if (wordApp != null)
                {
                    wordApp.Quit();
                    releaseObject(wordApp);
                }
            }
        }



        private void BaoCaoHoSoNhanVienWord()
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
        ChucVu CV ON NV.MaCV = CV.MaCV 
    ORDER BY ID";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo hồ sơ nhân viên");
        }

        private void BaoCaoChinhSachKTWord()
        {
            string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien,NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                     From ChinhSach CS
                     LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                     LEFT JOIN KhenThuong KT ON CS.MaKT = KT.MaKT
                     WHERE CS.MaKT IS NOT NULL
                     ORDER BY IDnhanvien";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo chính sách khen thưởng");
        }

        private void BaoCaoChinhSachKTDAWord()
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

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo chính sách khen thưởng dự án");
        }

        private void BaoCaoChinhSachKLWord()
        {
            string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                     From ChinhSach CS
                     LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                     LEFT JOIN KyLuat KL ON CS.MaKL = KL.MaKL
                     WHERE CS.MaKL IS NOT NULL
                     ORDER BY IDnhanvien";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo chính sách kỷ luật");
        }

        private void BaoCaoPhanCongWord()
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
        DuAn DA ON PC.MaDuAn = DA.MaDuAn 
    ORDER BY MaPhanCong";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo phân công");
        }

        private void BaoCaoChamCongWord()
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
        PhongBan PB ON NV.MaPB = PB.MaPB 
    ORDER BY IDnhanvien, NgayLamViec";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo chấm công");
        }

        private void BaoCaoTinhLuongWord()
        {
            string query = @"
    SELECT 
        NV.ID, 
        NV.HoTen,
        NV.NgaySinh,
        NV.MaPB,
        NV.MaCV,
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
    WHERE MONTH(CC.NgayLamViec) = MONTH(GETDATE()) 
        AND YEAR(CC.NgayLamViec) = YEAR(GETDATE()) 
    GROUP BY 
        NV.ID, NV.HoTen, NV.NgaySinh, NV.MaPB, NV.MaCV, L.LuongCoBan;";

            LoadDataToDataGridView(ExecuteQuery(query), "Báo cáo tính lương");
        }


        private void comboBoxBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBaoCao.SelectedItem == null)
                return;

            string selected = comboBoxBaoCao.SelectedItem.ToString();
            DataTable dataTable = null;

            switch (selected)
            {
                case "Báo cáo hồ sơ nhân viên":
                    dataTable = GetHoSoNhanVien();
                    break;

                case "Báo cáo chính sách khen thưởng":
                    dataTable = GetChinhSachKT();
                    break;

                case "Báo cáo chính sách khen thưởng dự án":
                    dataTable = GetChinhSachKTDA();
                    break;

                case "Báo cáo chính sách kỷ luật":
                    dataTable = GetChinhSachKL();
                    break;

                case "Báo cáo phân công":
                    dataTable = GetPhanCong();
                    break;

                case "Báo cáo chấm công":
                    dataTable = GetChamCong();
                    break;

                case "Báo cáo tính lương":
                    dataTable = GetTinhLuong();
                    break;

                default:
                    break;
            }

            if (dataTable != null)
            {
                LoadDataToDataGridView(dataTable, selected); 
            }
        }

        private void LoadDataToDataGridView(DataTable dataTable, string reportType)
        {
            dataGridViewReports.Rows.Clear();
            dataGridViewReports.Columns.Clear();

            switch (reportType)
            {
                case "Báo cáo hồ sơ nhân viên":
                    dataGridViewReports.Columns.Add("ID", "ID");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("GioiTinh", "Giới tính");
                    dataGridViewReports.Columns.Add("NgaySinh", "Ngày sinh");
                    dataGridViewReports.Columns.Add("Sdt", "Số điện thoại");
                    dataGridViewReports.Columns.Add("DiaChi", "Địa chỉ");
                    dataGridViewReports.Columns.Add("MaPB", "Mã phòng ban");
                    dataGridViewReports.Columns.Add("MaCV", "Mã chức vụ");
                    break;

                case "Báo cáo chính sách khen thưởng":
                    dataGridViewReports.Columns.Add("MaChinhSach", "Mã chính sách");
                    dataGridViewReports.Columns.Add("IDnhanvien", "ID nhân viên");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("NgayKT", "Ngày khen thưởng");
                    dataGridViewReports.Columns.Add("MaKT", "Mã khen thưởng");
                    dataGridViewReports.Columns.Add("GiaTri", "Giá trị");
                    break;

                case "Báo cáo chính sách khen thưởng dự án":
                    dataGridViewReports.Columns.Add("MaChinhSach", "Mã chính sách");
                    dataGridViewReports.Columns.Add("IDnhanvien", "ID nhân viên");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("MaDuAn", "Mã dự án");
                    dataGridViewReports.Columns.Add("PhuCapDuAn", "Phụ cấp dự án");
                    dataGridViewReports.Columns.Add("KTDuAn", "Khen thưởng dự án");
                    break;

                case "Báo cáo chính sách kỷ luật":
                    dataGridViewReports.Columns.Add("MaChinhSach", "Mã chính sách");
                    dataGridViewReports.Columns.Add("IDnhanvien", "ID nhân viên");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("NgayKL", "Ngày kỷ luật");
                    dataGridViewReports.Columns.Add("MaKL", "Mã kỷ luật");
                    dataGridViewReports.Columns.Add("GiaTri", "Giá trị");
                    break;

                case "Báo cáo phân công":
                    dataGridViewReports.Columns.Add("MaPhanCong", "Mã phân công");
                    dataGridViewReports.Columns.Add("IDnhanvien", "ID nhân viên");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("MaDuAn", "Mã dự án");
                    dataGridViewReports.Columns.Add("TenDuAn", "Tên dự án");
                    dataGridViewReports.Columns.Add("NgayBatDau", "Ngày bắt đầu");
                    dataGridViewReports.Columns.Add("NgayKetThuc", "Ngày kết thúc");
                    dataGridViewReports.Columns.Add("ViTri", "Vị trí");
                    break;

                case "Báo cáo chấm công":
                    dataGridViewReports.Columns.Add("MaChamCong", "Mã chấm công");
                    dataGridViewReports.Columns.Add("IDnhanvien", "ID nhân viên");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("MaPB", "Mã phòng ban");
                    dataGridViewReports.Columns.Add("NgayLamViec", "Ngày làm việc");
                    dataGridViewReports.Columns.Add("LamViec", "Làm việc");
                    dataGridViewReports.Columns.Add("TrangThai", "Trạng thái");
                    break;

                case "Báo cáo tính lương":
                    dataGridViewReports.Columns.Add("ID", "ID");
                    dataGridViewReports.Columns.Add("HoTen", "Họ tên");
                    dataGridViewReports.Columns.Add("NgaySinh", "Ngày sinh");
                    dataGridViewReports.Columns.Add("MaPB", "Mã phòng ban");
                    dataGridViewReports.Columns.Add("MaCV", "Mã chức vụ");
                    dataGridViewReports.Columns.Add("LuongCoBan", "Lương cơ bản");
                    dataGridViewReports.Columns.Add("TongPhuCap", "Tổng phụ cấp");
                    dataGridViewReports.Columns.Add("TongNgayCong", "Tổng ngày công");
                    dataGridViewReports.Columns.Add("TongThuong", "Tổng thưởng");
                    dataGridViewReports.Columns.Add("TongKyLuat", "Tổng kỷ luật");
                    dataGridViewReports.Columns.Add("TongLuong", "Tổng lương");
                    break;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = dataGridViewReports.Rows.Add(row.ItemArray);
                dataGridViewReports.Rows[rowIndex].HeaderCell.Value = (rowIndex + 1).ToString();
            }
        }

        private DataTable GetHoSoNhanVien()
        {
            string query = @"
        SELECT NV.ID, NV.HoTen, NV.GioiTinh, NV.NgaySinh, NV.Sdt, NV.DiaChi, PB.MaPB, CV.MaCV 
        FROM NhanVien NV
        LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB
        LEFT JOIN ChucVu CV ON NV.MaCV = CV.MaCV 
        ORDER BY NV.ID";

            return ExecuteQuery(query);
        }

        private DataTable GetChinhSachKT()
        {
            string query = @"
        SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
        FROM ChinhSach CS
        LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
        LEFT JOIN KhenThuong KT ON CS.MaKT = KT.MaKT
        WHERE CS.MaKT IS NOT NULL
        ORDER BY CS.IDnhanvien";

            return ExecuteQuery(query);
        }

        private DataTable GetChinhSachKTDA()
        {
            string query = @"
        SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.MaDuAn, DA.PhuCapDuAn, CS.KTDuAn
        FROM ChinhSach CS
        LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
        LEFT JOIN DuAn DA ON CS.MaDuAn = DA.MaDuAn
        WHERE CS.MaDuAn IS NOT NULL 
            AND EXISTS (
                SELECT 1 
                FROM PhanCong PC 
                WHERE PC.IDnhanvien = CS.IDnhanvien 
                AND PC.MaDuAn = CS.MaDuAn
            )
        ORDER BY CS.IDnhanvien";

            return ExecuteQuery(query);
        }

        private DataTable GetChinhSachKL()
        {
            string query = @"
        SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
        FROM ChinhSach CS
        LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
        LEFT JOIN KyLuat KL ON CS.MaKL = KL.MaKL
        WHERE CS.MaKL IS NOT NULL
        ORDER BY CS.IDnhanvien";

            return ExecuteQuery(query);
        }

        private DataTable GetPhanCong()
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
        LEFT JOIN NhanVien NV ON PC.IDnhanvien = NV.ID
        LEFT JOIN DuAn DA ON PC.MaDuAn = DA.MaDuAn 
        ORDER BY PC.MaPhanCong";

            return ExecuteQuery(query);
        }

        private DataTable GetChamCong()
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
            PhongBan PB ON NV.MaPB = PB.MaPB 
        ORDER BY CC.IDnhanvien, CC.NgayLamViec";

            return ExecuteQuery(query);
        }

        private DataTable GetTinhLuong()
        {
            string query = @"
        SELECT 
            NV.ID, 
            NV.HoTen,
            NV.NgaySinh,
            NV.MaPB,
            NV.MaCV,
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
                    (SUM(DISTINCT CASE WHEN CC.LamViec = 1 THEN 1 ELSE 0 END) * (L.LuongCoBan / @SoNgayLamViec))
                ), 2
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
        WHERE MONTH(CC.NgayLamViec) = MONTH(GETDATE()) 
            AND YEAR(CC.NgayLamViec) = YEAR(GETDATE()) 
        GROUP BY 
            NV.ID, NV.HoTen, NV.NgaySinh, NV.MaPB, NV.MaCV, L.LuongCoBan;";

            return ExecuteQuery(query);
        }


        private DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = connectdatabase.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int soNgayLamViec = TinhSoNgayLamViec();
                    command.Parameters.AddWithValue("@SoNgayLamViec", soNgayLamViec);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }



    }
}
