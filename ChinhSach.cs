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
    public partial class ChinhSach : Form
    {
        public ChinhSach()
        {
            InitializeComponent();
            LoadComboBoxKhenThuong();
            LoadComboBoxKyLuat();
            LoadComboBoxDuAn();
            LoadDataKT();
            LoadDataKL();
            LoadDataDA();
            cmb_KT.SelectedIndex = 0;
            cmb_KL.SelectedIndex = 0;
            cmb_duan.SelectedIndex = 0;
            dtp_date.Value = DateTime.Now;
            dtg_phat.CellClick += dtg_phat_CellClick;
            dtg_thuong.CellClick += dtg_thuong_CellClick;
            dtg_phat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_phat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_phat.CellClick += new DataGridViewCellEventHandler(dtg_phat_CellClick);
            dtg_thuong.CellClick += new DataGridViewCellEventHandler(dtg_thuong_CellClick);
            dtg_phat.CurrentCell = null;
            dtg_tgDuan.CurrentCell = null;
            dtg_thuong.CurrentCell = null;
        }

        private void LoadDataDA()
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
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_tgDuan.DataSource = dataTable;
                        dtg_tgDuan.AllowUserToAddRows = false;
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

        private void LoadDataKT()
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
                    string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien,NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KhenThuong KT ON CS.MaKT = KT.MaKT
                                     WHERE CS.MaKT IS NOT NULL
                                     ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_thuong.DataSource = dataTable;
                        dtg_thuong.AllowUserToAddRows = false;
                        dtg_thuong.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private void LoadDataKL()
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
                    string query = @"SELECT DISTINCT CS.MaChinhSach, CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                                     From ChinhSach CS
                                     LEFT JOIN
                                      NhanVien NV ON CS.IDnhanvien = NV.ID
                                     LEFT JOIN
                                      KyLuat KL ON CS.MaKL = KL.MaKL
                                     WHERE CS.MaKL IS NOT NULL
                                     ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtg_phat.DataSource = dataTable;
                        dtg_phat.AllowUserToAddRows = false;
                        dtg_phat.Columns["NgayKL"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private void LoadComboBoxDuAn()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaDuAn FROM DuAn";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_duan.Items.Clear();
                        cmb_duan.Items.Add("--Chọn dự án--");
                        while (reader.Read())
                        {

                            cmb_duan.Items.Add(new { Value = reader["MaDuAn"], Text = reader["MaDuAn"] });
                        }

                        cmb_duan.DisplayMember = "Text";
                        cmb_duan.ValueMember = "Value";
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

        private void LoadComboBoxKhenThuong()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKT FROM KhenThuong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_KT.Items.Clear();
                        cmb_KT.Items.Add("--Chọn khen thưởng--");
                        while (reader.Read())
                        {

                            cmb_KT.Items.Add(new { Value = reader["MaKT"], Text = reader["MaKT"] });
                        }

                        cmb_KT.DisplayMember = "Text";
                        cmb_KT.ValueMember = "Value";
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
        private void LoadComboBoxKyLuat()
        {
            using (SqlConnection connection = connectdatabase.Connect())
            {
                string query = "SELECT MaKL FROM KyLuat";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        cmb_KL.Items.Clear();
                        cmb_KL.Items.Add("--Chọn kỷ luật--");
                        while (reader.Read())
                        {

                            cmb_KL.Items.Add(new { Value = reader["MaKL"], Text = reader["MaKL"] });
                        }

                        cmb_KL.DisplayMember = "Text";
                        cmb_KL.ValueMember = "Value";
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

        private void add_hs_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập nhập ID nhân viên !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_manv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmb_KT.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(dtp_date.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn ngày thêm khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
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

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    txt_manv.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE ID = @IDnhanvien";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);

                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "ID nhân viên không tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            txt_manv.Focus();
                            return;
                        }
                    }

                    string checkExistQuery = @"SELECT COUNT(*) FROM ChinhSach 
                                        WHERE IDnhanvien = @IDnhanvien 
                                        AND NgayKT = @NgayKT 
                                        AND MaKT = @MaKT";
                    using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
                    {
                        checkExistCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        checkExistCommand.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
                        checkExistCommand.Parameters.AddWithValue("@MaKT", cmb_KT.SelectedValue ?? cmb_KT.Text);

                        int existCount = (int)checkExistCommand.ExecuteScalar();

                        if (existCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Khen thưởng và ngày đã tồn tại trong cơ sở dữ liệu!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    //string checkMaChinhSachQuery = "SELECT COUNT(*) FROM ChinhSach WHERE IDnhanvien = @IDnhanvien";
                    //using (SqlCommand checkMaChinhSachCommand = new SqlCommand(checkMaChinhSachQuery, connection))
                    //{
                    //    checkMaChinhSachCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                    //    int countMaChinhSach = (int)checkMaChinhSachCommand.ExecuteScalar();

                    //    if (countMaChinhSach > 0)
                    //    {
                    //        Notification notification = new Notification();
                    //        notification.NotificationText = "Mã chính sách đã tồn tại nhập mã khác!";
                    //        notification.OkButtonText = "OK";
                    //        notification.ShowDialog();
                    //        return;
                    //    }
                    //}

                    string query = @"
                      INSERT INTO ChinhSach (IDnhanvien, NgayKT, MaKT)
                      VALUES (@IDnhanvien, @NgayKT, @MaKT)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        command.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
                        command.Parameters.AddWithValue("@MaKT", cmb_KT.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadDataKT();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Vui lòng chọn mã khen thưởng";
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void reset()
        {
            cmb_duan.Enabled = true;
            cmb_KL.Enabled = true;
            cmb_KT.Enabled = true;
            richTextBox1.Text = string.Empty;
            txt_manv.Enabled = true;
            txt_manv.Text = string.Empty;
            dtp_date.Value = DateTime.Now;
            cmb_KT.SelectedIndex = 0;
            cmb_KL.SelectedIndex = 0;
            cmb_duan.SelectedIndex = 0;
            txt_ktduan.Text = string.Empty;
            search_hs.Text = string.Empty;
            dtg_thuong.ClearSelection();
            dtg_phat.ClearSelection();
            LoadDataKT();
            LoadDataKL();
        }

        private void resetHs_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void add_KL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập nhập ID nhân viên !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_manv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmb_KT.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(dtp_date.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn ngày thêm khen thưởng !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

            if (!int.TryParse(txt_manv.Text, out int idNhanVien))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Sai ID nhân viên!";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

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

                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE ID = @IDnhanvien";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);

                        // Thực hiện truy vấn kiểm tra
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0) // Nếu không tìm thấy IDnhanvien
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "ID nhân viên không tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    string checkExistQuery = @"SELECT COUNT(*) FROM ChinhSach 
                                        WHERE IDnhanvien = @IDnhanvien 
                                        AND NgayKL = @NgayKL
                                        AND MaKL = @MaKL";
                    using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
                    {
                        checkExistCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        checkExistCommand.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
                        checkExistCommand.Parameters.AddWithValue("@MaKL", ((dynamic)cmb_KL.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

                        int existCount = (int)checkExistCommand.ExecuteScalar();

                        if (existCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Kỷ luật và ngày đã tồn tại trong cơ sở dữ liệu!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }

                    //string checkMaChinhSachQuery = "SELECT COUNT(*) FROM ChinhSach WHERE IDnhanvien = @IDnhanvien";
                    //using (SqlCommand checkMaChinhSachCommand = new SqlCommand(checkMaChinhSachQuery, connection))
                    //{
                    //    checkMaChinhSachCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                    //    int countMaChinhSach = (int)checkMaChinhSachCommand.ExecuteScalar();

                    //    if (countMaChinhSach > 0)
                    //    {
                    //        Notification notification = new Notification();
                    //        notification.NotificationText = "Mã chính sách đã tồn tại nhập mã khác!";
                    //        notification.OkButtonText = "OK";
                    //        notification.ShowDialog();
                    //        return;
                    //    }
                    //}

                    string query = @"
                      INSERT INTO ChinhSach (IDnhanvien, NgayKL, MaKL)
                      VALUES (@IDnhanvien, @NgayKL, @MaKL)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        command.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
                        command.Parameters.AddWithValue("@MaKL", cmb_KL.Text);

                        command.ExecuteNonQuery();
                        Success sc = new Success();
                        sc.ShowDialog();
                        LoadDataKL();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Vui lòng chọn mã kỷ luật";
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        private void dtg_thuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_thuong.Rows.Count)
            {
                DataGridViewRow row = dtg_thuong.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["NgayKT"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayKT"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["MaKT"].Value != null)
                {
                    string maKT = row.Cells["MaKT"].Value.ToString();
                    cmb_KT.SelectedIndex = cmb_KT.FindStringExact(maKT);
                    cmb_KT.Enabled = false ;
                }
            }
        }

        private void dtg_phat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_phat.Rows.Count)
            {
                DataGridViewRow row = dtg_phat.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien2"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien2"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["NgayKL"].Value != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(row.Cells["NgayKL"].Value.ToString(), out selectedDate))
                    {
                        dtp_date.Value = selectedDate;
                    }
                }
                if (row.Cells["MaKL"].Value != null)
                {
                    string maKL = row.Cells["MaKL"].Value.ToString();
                    cmb_KL.SelectedIndex = cmb_KL.FindStringExact(maKL);
                    cmb_KL.Enabled = false;
                }
            }
        }

        private void btn_deletehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                Notification notification1 = new Notification();
                notification1.NotificationText = "Vui lòng chọn khen thưởng dự án để xóa !";
                notification1.OkButtonText = "OK";
                notification1.ShowDialog();
                return;
            }

            if (dtg_tgDuan.CurrentRow != null)
            {
                Question questionForm = new Question();
                questionForm.QuestionText = "xóa chính sách thưởng dự án này?";
                questionForm.OkButtonText = "Có";
                if (questionForm.ShowDialog() == DialogResult.OK)
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
                            string query = "DELETE FROM ChinhSach WHERE MaDuAn = @MaDuAn";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaDuAn", dtg_tgDuan.CurrentRow.Cells["MaDuAn"].Value);
                                command.ExecuteNonQuery();
                                Success sc = new Success();
                                sc.ShowDialog();
                                LoadDataDA();
                                reset();
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
                return; 
            }
        }


        private void btn_updatehs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng dự án để cập nhật !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                return;
            }

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
                    string checkExistQuery = @"SELECT COUNT(*) FROM ChinhSach 
                                        WHERE IDnhanvien = @IDnhanvien 
                                        AND MaDuAn = @MaDuAn 
                                        AND KTDuAn = @KTDuAn";
                    using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
                    {
                        checkExistCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        checkExistCommand.Parameters.AddWithValue("@KTDuAn", txt_ktduan.Text);
                        checkExistCommand.Parameters.AddWithValue("@MaDuAn", ((dynamic)cmb_duan.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

                        int existCount = (int)checkExistCommand.ExecuteScalar();

                        if (existCount > 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Nguyên nhân và ngày đã tồn tại trong cơ sở dữ liệu!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }
                    }
                    if (cmb_duan.SelectedItem != null)
                    {
                        string queryDA = @"UPDATE ChinhSach 
                               SET KTDuAn = @KTDuAn
                               WHERE IDnhanvien = @IDnhanvien AND MaDuAn = @MaDuAn";

                        using (SqlCommand commandDA = new SqlCommand(queryDA, connection))
                        {
                            commandDA.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                            commandDA.Parameters.AddWithValue("@KTDuAn", txt_ktduan.Text);
                            commandDA.Parameters.AddWithValue("@MaDuAn", ((dynamic)cmb_duan.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

                            commandDA.ExecuteNonQuery();
                            LoadDataDA();
                            Success sc = new Success();
                            sc.ShowDialog();
                            reset();
                        }
                        return;
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

        private void SearchData(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadDataKT();
                LoadDataKL();
                return;
            }
            SearchKhenthuong(searchValue);
            SearchKyLuat(searchValue);
        }
        private void SearchKhenthuong(string searchValue)
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien, NV.HoTen, CS.NgayKT, CS.MaKT, KT.GiaTri
                             FROM ChinhSach CS
                             LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                             LEFT JOIN KhenThuong KT ON CS.MaKT = KT.MaKT
                             WHERE CS.MaKT IS NOT NULL AND (CS.IDnhanvien LIKE @searchValue OR NV.HoTen LIKE @searchValue)
                             ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dtg_thuong.DataSource = dataTable;
                            dtg_thuong.AllowUserToAddRows = false;
                            dtg_thuong.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy kết quả Khen thưởng.",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
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
        private void SearchKyLuat(string searchValue)
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
                    string query = @"SELECT DISTINCT CS.IDnhanvien, NV.HoTen, CS.NgayKL, CS.MaKL, KL.GiaTri
                             FROM ChinhSach CS
                             LEFT JOIN NhanVien NV ON CS.IDnhanvien = NV.ID
                             LEFT JOIN KyLuat KL ON CS.MaKL = KL.MaKL
                             WHERE CS.MaKL IS NOT NULL AND (CS.IDnhanvien LIKE @searchValue OR NV.HoTen LIKE @searchValue)
                             ORDER BY IDnhanvien";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dtg_phat.DataSource = dataTable;
                            dtg_phat.AllowUserToAddRows = false;
                            dtg_phat.Columns["NgayKL"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            Notification tb = new Notification
                            {
                                NotificationText = "Không tìm thấy kết quả Kỷ luật.",
                                OkButtonText = "OK"
                            };
                            tb.ShowDialog();
                        }
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

        private void btn_searchHs_Click(object sender, EventArgs e)
        {
            SearchData(search_hs.Text);
        }

        private void SearchSummary()
        {
            // Lấy giá trị ID nhân viên từ textbox
            string idNhanVienInput = search_hs.Text.Trim();
            if (string.IsNullOrEmpty(idNhanVienInput))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập ID của nhân viên để thực hiện !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                search_hs.Focus();
                return;
            }

            // Kiểm tra nếu giá trị nhập vào là số
            if (!int.TryParse(idNhanVienInput, out int idNhanVien))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập vào ID của nhân viên vào để thống kê !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                search_hs.Focus();
                return;
            }

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
                    string query = @"
      SELECT 
        CS.IDnhanvien, 
        NV.HoTen,
        SUM(CASE WHEN KT.MaKT IS NOT NULL THEN KT.GiaTri ELSE 0 END) AS TongGiaTriKhenThuong,
        SUM(CASE WHEN KL.MaKL IS NOT NULL THEN KL.GiaTri ELSE 0 END) AS TongGiaTriKyLuat
      FROM 
        ChinhSach CS
      LEFT JOIN 
        NhanVien NV ON CS.IDnhanvien = NV.ID
      LEFT JOIN 
        KhenThuong KT ON CS.MaKT = KT.MaKT
      LEFT JOIN 
        KyLuat KL ON CS.MaKL = KL.MaKL
      WHERE 
        CS.IDnhanvien = @IDnhanvien
      GROUP BY 
        CS.IDnhanvien, NV.HoTen
      HAVING 
        SUM(CASE WHEN KT.MaKT IS NOT NULL THEN KT.GiaTri ELSE 0 END) > 0 OR 
        SUM(CASE WHEN KL.MaKL IS NOT NULL THEN KL.GiaTri ELSE 0 END) > 0
      ORDER BY 
        CS.IDnhanvien;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDnhanvien", idNhanVien);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            richTextBox1.Clear(); // Xóa nội dung cũ
                            if (reader.Read()) // Chỉ đọc một dòng
                            {
                                // Lấy thông tin từ reader
                                string hoTen = reader["HoTen"].ToString();

                                // Kiểm tra và lấy giá trị tổng khen thưởng
                                object khenThuongValue = reader["TongGiaTriKhenThuong"];
                                float tongKhenThuong = khenThuongValue is DBNull ? 0 : Convert.ToSingle(khenThuongValue);

                                // Kiểm tra và lấy giá trị tổng kỷ luật
                                object kyLuatValue = reader["TongGiaTriKyLuat"];
                                float tongKyLuat = kyLuatValue is DBNull ? 0 : Convert.ToSingle(kyLuatValue);

                                // Chuyển đổi float sang string với định dạng
                                string tongKhenThuongString = tongKhenThuong.ToString();
                                string tongKyLuatString = tongKyLuat.ToString();

                                // Hiển thị thông tin trong RichTextBox
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText($"\tTổng chính sách của nhân viên:\n\n");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText($"\tID Nhân viên: {idNhanVien}\n");
                                richTextBox1.AppendText($"\tHọ tên: {hoTen}\n");
                                richTextBox1.AppendText($"\tTổng giá trị khen thưởng: {tongKhenThuongString} VNĐ\n");
                                richTextBox1.AppendText($"\tTổng giá trị kỷ luật: {tongKyLuatString} VNĐ\n\n");
                                richTextBox1.AppendText("=================================");
                            }
                            else
                            {
                                richTextBox1.Text = "*Không có kết quả chính sách cho nhân viên này !";
                            }
                        }
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



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchSummary();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_macs_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_hs_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtg_tgDuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtg_tgDuan.Rows.Count)
            {
                DataGridViewRow row = dtg_tgDuan.Rows[e.RowIndex];
                if (row.Cells["IDnhanvien3"].Value != null)
                {
                    txt_manv.Text = row.Cells["IDnhanvien3"].Value.ToString();
                    txt_manv.Enabled = false;
                }

                if (row.Cells["MaDuAn"].Value != null)
                {
                    string maDA = row.Cells["MaDuAn"].Value.ToString();
                    cmb_duan.SelectedIndex = cmb_duan.FindStringExact(maDA);
                    cmb_duan.Enabled = false ;
                }

                if (row.Cells["KTDuAn"].Value != null)
                {
                    txt_ktduan.Text = row.Cells["KTDuAn"].Value.ToString();
                }
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manv.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng nhập nhập ID nhân viên !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
                txt_manv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmb_duan.Text))
            {
                Notification notification = new Notification();
                notification.NotificationText = "Vui lòng chọn khen thưởng dự án !";
                notification.OkButtonText = "OK";
                notification.ShowDialog();
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

            using (SqlConnection connection = connectdatabase.Connect())
            {
                if (connection == null)
                {
                    Error error = new Error();
                    error.ErrorText = "Lỗi kết nối Database !";
                    error.OkButtonText = "OK";
                    error.ShowDialog();
                    txt_manv.Focus();
                    return;
                }

                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE ID = @IDnhanvien";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);

                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "ID nhân viên không tồn tại!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            txt_manv.Focus();
                            return;
                        }
                    }
                    

                    string checkParticipationQuery = "SELECT COUNT(*) FROM PhanCong WHERE IDnhanvien = @IDnhanvien AND MaDuAn = @MaDuAn";
                    using (SqlCommand checkParticipationCommand = new SqlCommand(checkParticipationQuery, connection))
                    {
                        checkParticipationCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                        checkParticipationCommand.Parameters.AddWithValue("@MaDuAn", cmb_duan.Text);

                        int participationCount = (int)checkParticipationCommand.ExecuteScalar();

                        if (participationCount == 0)
                        {
                            Notification notification = new Notification();
                            notification.NotificationText = "Nhân viên chưa tham gia dự án này!";
                            notification.OkButtonText = "OK";
                            notification.ShowDialog();
                            return;
                        }

                        string checkExistingQuery = "SELECT COUNT(*) FROM ChinhSach WHERE IDnhanvien = @IDnhanvien AND MaDuAn = @MaDuAn";
                        using (SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, connection))
                        {
                            checkExistingCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                            checkExistingCommand.Parameters.AddWithValue("@MaDuAn", cmb_duan.Text);

                            int existingCount = (int)checkExistingCommand.ExecuteScalar();

                            if (existingCount > 0)
                            {
                                Notification notification = new Notification();
                                notification.NotificationText = "Nhân viên đã có trong bảng chính sách với dự án này!";
                                notification.OkButtonText = "OK";
                                notification.ShowDialog();
                                return;
                            }
                        }

                        string query = @"
                      INSERT INTO ChinhSach (IDnhanvien, MaDuAn, KTDuAn)
                      VALUES (@IDnhanvien, @MaDuAn, @KTDuAn)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
                            command.Parameters.AddWithValue("@MaDuAn", cmb_duan.Text);
                            command.Parameters.AddWithValue("@KTDuAn", txt_ktduan.Text);

                            command.ExecuteNonQuery();
                            Success sc = new Success();
                            sc.ShowDialog();
                            LoadDataDA();
                            reset();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error er = new Error();
                    er.ErrorText = "Vui lòng chọn mã khen thưởng dự án";
                    er.OkButtonText = "OK";
                    er.ShowDialog();
                }
            }
        }

        //private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_manv.Text))
        //    {
        //        Notification notification = new Notification();
        //        notification.NotificationText = "Vui lòng chọn khen thưởng để cập nhật !";
        //        notification.OkButtonText = "OK";
        //        notification.ShowDialog();
        //        return;
        //    }

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
        //            string checkExistQuery = @"SELECT COUNT(*) FROM ChinhSach 
        //                                WHERE MaChinhSach = @MaChinhSach, IDnhanvien = @IDnhanvien 
        //                                AND NgayKT = @NgayKT 
        //                                AND MaKT = @MaKT";
        //            using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
        //            {
        //                checkExistCommand.Parameters.AddWithValue("@MaChinhSach", dtg_thuong.SelectedRows[0].Cells["MaChinhSach"].Value.ToString());
        //                checkExistCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
        //                checkExistCommand.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
        //                checkExistCommand.Parameters.AddWithValue("@MaKT", cmb_KT.SelectedValue ?? cmb_KT.Text);

        //                int existCount = (int)checkExistCommand.ExecuteScalar();

        //                if (existCount > 0)
        //                {
        //                    Notification notification = new Notification();
        //                    notification.NotificationText = "Khen thưởng và ngày đã tồn tại trong cơ sở dữ liệu!";
        //                    notification.OkButtonText = "OK";
        //                    notification.ShowDialog();
        //                    return;
        //                }
        //            }

        //                // Lấy MaChinhSach từ hàng đang chọn trong DataGridView
        //                string maChinhSach = dtg_thuong.SelectedRows[0].Cells["MaChinhSach"].Value.ToString();

        //                string queryKT = @"UPDATE ChinhSach 
        //                   SET NgayKT = @NgayKT
        //                   WHERE MaChinhSach = @MaChinhSach AND IDnhanvien = @IDnhanvien AND MaKT = @MaKT";

        //                using (SqlCommand commandKT = new SqlCommand(queryKT, connection))
        //                {
        //                    // Gán tham số cho câu truy vấn
        //                    commandKT.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
        //                    commandKT.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
        //                    commandKT.Parameters.AddWithValue("@MaKT", ((dynamic)cmb_KT.SelectedItem).Value); // Kiểm tra kiểu dữ liệu
        //                    commandKT.Parameters.AddWithValue("@MaChinhSach", maChinhSach); // Gán MaChinhSach từ DataGridView

        //                    // Thực hiện câu truy vấn
        //                    commandKT.ExecuteNonQuery();

        //                    // Load lại dữ liệu và thông báo thành công
        //                    LoadDataKT();
        //                    Success sc = new Success();
        //                    sc.ShowDialog();
        //                    reset();
        //                }

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

        //private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_manv.Text))
        //    {
        //        Notification notification = new Notification();
        //        notification.NotificationText = "Vui lòng chọn kỷ luật để cập nhật !";
        //        notification.OkButtonText = "OK";
        //        notification.ShowDialog();
        //        return;
        //    }

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
        //            string maChinhSach = dtg_phat.SelectedRows[0].Cells["MaChinhSach3"].Value.ToString();
        //            string checkExistQuery = @"SELECT COUNT(*) FROM ChinhSach 
        //                                WHERE MaChinhSach = @MaChinhSach AND IDnhanvien = @IDnhanvien 
        //                                AND NgayKL = @NgayKL
        //                                AND  MaKL = @MaKL";
        //            using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
        //            {
        //                checkExistCommand.Parameters.AddWithValue("@MaChinhSach", maChinhSach);
        //                checkExistCommand.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
        //                checkExistCommand.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
        //                checkExistCommand.Parameters.AddWithValue("@MaKL", cmb_KL.SelectedValue ?? cmb_KT.Text);

        //                int existCount = (int)checkExistCommand.ExecuteScalar();

        //                if (existCount > 0)
        //                {
        //                    Notification notification = new Notification();
        //                    notification.NotificationText = "Kỷ luật và ngày đã tồn tại trong cơ sở dữ liệu!";
        //                    notification.OkButtonText = "OK";
        //                    notification.ShowDialog();
        //                    return;
        //                }
        //            }
                    
        //            if (cmb_KL.SelectedItem != null)
        //            {
        //                string queryKL = @"UPDATE ChinhSach 
        //                       SET NgayKL = @NgayKL, MaKL = @MaKL 
        //                       WHERE MaChinhSach = @MaChinhSach AND IDnhanvien = @IDnhanvien AND MaKL = @MaKL AND NgayKL = @NgayKL";

        //                using (SqlCommand commandKL = new SqlCommand(queryKL, connection))
        //                {
        //                    commandKL.Parameters.AddWithValue("@MaChinhSach", maChinhSach);
        //                    commandKL.Parameters.AddWithValue("@IDnhanvien", txt_manv.Text);
        //                    commandKL.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
        //                    commandKL.Parameters.AddWithValue("@MaKL", ((dynamic)cmb_KL.SelectedItem).Value); // Kiểm tra kiểu dữ liệu

        //                    commandKL.ExecuteNonQuery();
        //                    LoadDataKL();
        //                    Success sc = new Success();
        //                    sc.ShowDialog();
        //                    reset();
        //                }
        //                return;
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

        private void guna2GradientCircleButton5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                Notification notification1 = new Notification();
                notification1.NotificationText = "Vui lòng chọn để xóa !";
                notification1.OkButtonText = "OK";
                notification1.ShowDialog();
                return;
            }

            // Kiểm tra xóa chính sách thưởng
            if (dtg_thuong.CurrentRow != null)
            {
                Question questionForm = new Question();
                questionForm.QuestionText = "xóa chính sách khen thưởng thưởng này?";
                questionForm.OkButtonText = "Có";
                if (questionForm.ShowDialog() == DialogResult.OK)
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
                            string query = "DELETE FROM ChinhSach WHERE MaKT = @MaKT AND NgayKT = @NgayKT";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaKT", dtg_thuong.CurrentRow.Cells["MaKT"].Value);
                                command.Parameters.AddWithValue("@NgayKT", dtp_date.Value);
                                command.ExecuteNonQuery();
                                Success sc = new Success();
                                sc.ShowDialog();
                                LoadDataKT();
                                reset();
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
                return;
            }
        }

        private void guna2GradientCircleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                Notification notification1 = new Notification();
                notification1.NotificationText = "Vui lòng chọn để xóa !";
                notification1.OkButtonText = "OK";
                notification1.ShowDialog();
                return;
            }

            // Kiểm tra xóa chính sách thưởng
            if (dtg_thuong.CurrentRow != null)
            {
                Question questionForm = new Question();
                questionForm.QuestionText = "xóa chính sách kỷ luật này?";
                questionForm.OkButtonText = "Có";
                if (questionForm.ShowDialog() == DialogResult.OK)
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
                            string query = "DELETE FROM ChinhSach WHERE MaKL = @MaKL AND NgayKL = @NgayKL";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaKL", dtg_phat.CurrentRow.Cells["MaKL"].Value);
                                command.Parameters.AddWithValue("@NgayKL", dtp_date.Value);
                                command.ExecuteNonQuery();
                                Success sc = new Success();
                                sc.ShowDialog();
                                LoadDataKL();
                                reset();
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
                return;
            }
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
