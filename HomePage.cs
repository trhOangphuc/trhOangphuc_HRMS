using QuanLyNhanSu.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class HomPage : Form
    {
        private Account accountForm;
        private int userId; // Biến để lưu ID người dùng
        private string username; // Biến để lưu tên tài khoản

        public HomPage(int userId, string username)
        {
            InitializeComponent();
            customizeDesing();
            InitializePanelProfile();
            openChildForm(new HomPagePanel());

            // Khởi tạo form Account và đăng ký sự kiện
            accountForm = new Account(userId);
            accountForm.ProfilePictureChanged += AccountForm_ProfilePictureChanged;

            this.userId = userId;
            this.username = username;
            // Hiển thị tên tài khoản trong label
            Profile.Text = username;

            this.KeyPreview = true; // Cho phép Form nhận sự kiện bàn phím
            this.KeyDown += new KeyEventHandler(HomPage_KeyDown);
        }

        private void AccountForm_ProfilePictureChanged(string filePath)
        {
            // Cập nhật PictureBox theo filePath được gửi từ Account
            UpdateProfilePicture(filePath);
        }

        private void UpdateProfilePicture(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath))
            {
                ptb_homepage.Image = Image.FromFile(filePath);
                ptb_homepage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                ptb_homepage.Image = null; // Đặt lại hình ảnh nếu file không tồn tại
            }
        }

        private void InitializePanelProfile()
        {
            panelProfile.Visible = false; // Đảm bảo rằng panelProfile ẩn khi bắt đầu
        }

        private bool isMinisized = false;
        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            if (isMinisized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            isMinisized = !isMinisized;
            int posX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int posY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            this.Location = new Point(posX, posY);
        }
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Sw_btn_bar_Click(object sender, EventArgs e)
        {
            HomPage homepage = new HomPage(userId, username);
            homepage.Show();
        }

        private void Sw_btn_Logout_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            Question questionForm = new Question();
            questionForm.QuestionText = "thoát không?";
            questionForm.OkButtonText = "Có";
            Login lg = new Login();
            if (questionForm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                lg.Show();
            }
        }
        private void customizeDesing()
        {
            panelDanhmuc.Visible = false;
            panelNhanvien.Visible = false;
            panelLuong.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelDanhmuc.Visible == true)
            {
                panelDanhmuc.Visible = false;
            }
            if (panelNhanvien.Visible == true)
            {
                panelNhanvien.Visible = false;
            }
            if (panelLuong.Visible == true)
            {
                panelLuong.Visible = false;
            }
        }
        private void showsSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void pn_danhmuc_Click(object sender, EventArgs e)
        {
            showsSubMenu(panelDanhmuc);
        }


        private void open_pb_Click(object sender, EventArgs e)
        {
            label3.Text = "Phòng ban";
            hideSubMenu();
            openChildForm(new PhongBan());
        }

        private void open_kl_Click(object sender, EventArgs e)
        {
            label3.Text = "Kỷ luật";
            hideSubMenu();
            openChildForm(new KyLuat());
        }

        private void open_kt_Click(object sender, EventArgs e)
        {
            label3.Text = "Khen thưởng";
            hideSubMenu();
            openChildForm(new KhenThuong());
        }

        private void btn_nv_Click(object sender, EventArgs e)
        {
            showsSubMenu(panelNhanvien);
        }

        private void open_hoso_Click(object sender, EventArgs e)
        {
            label3.Text = "Hồ sơ nhân sự";
            hideSubMenu();
            openChildForm(new HoSo());
        }

        private void open_chinhsach_Click(object sender, EventArgs e)
        {
            label3.Text = "Chính sách";
            hideSubMenu();
            openChildForm(new ChinhSach());
        }

        private void btn_luong_Click(object sender, EventArgs e)
        {
            showsSubMenu(panelLuong);
        }

        private void open_ttluong_Click(object sender, EventArgs e)
        {
            label3.Text = "Thông tin lương";
            hideSubMenu();
            openChildForm(new ThongTinLuong());
        }

        private void open_tinhluong_Click(object sender, EventArgs e)
        {
            label3.Text = "Tính lương";
            hideSubMenu();
            openChildForm(new TinhLuong());
        }

        private void home_Click(object sender, EventArgs e)
        {
            label3.Text = "Home Page";
            openChildForm(new HomPagePanel());
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!panelProfile.Visible)
            {
                hideSubMenu();
                panelProfile.BringToFront();
                panelProfile.Visible = true;
                btn_thongtin.Visible = true;
                btn_hotro.Visible = true;
                btn_caidat.Visible = true;
                btn_logout.Visible = true;
            }
            else
            {
                panelProfile.Visible = false;
                btn_thongtin.Visible = false;
                btn_hotro.Visible = false;
                btn_caidat.Visible = false;
                btn_logout.Visible = false;
            }
        }

        private void chamcong_Click(object sender, EventArgs e)
        {
            label3.Text = "Chấm công";
            openChildForm(new ChamCong());
        }

        private void btn_congtac_Click(object sender, EventArgs e)
        {
            label3.Text = "Công tác";
            openChildForm(new CongTac());
        }

        private void baocao_Click(object sender, EventArgs e)
        {
            label3.Text = "Báo cáo thống kê";
            openChildForm(new BaoCao());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ptb_homepage_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.ShowDialog();
        }

        private void btn_thongtin_Click_1(object sender, EventArgs e)
        {
            label3.Text = "Thông tin tài khoản";
            openChildForm(new Account(userId));
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            label3.Text = "Home Page";
            openChildForm(new HomPagePanel());
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Notification notification = new Notification();
            notification.NotificationText = "Tính năng đang phát triên !";
            notification.OkButtonText = "OK";
            notification.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Notification notification = new Notification();
            notification.NotificationText = "Tính năng đang phát triển !";
            notification.OkButtonText = "OK";
            notification.ShowDialog();
        }

        private void HomPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // Kiểm tra nếu phím ESC được nhấn
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    // Kích hoạt sự kiện click của Button thu nhỏ
                    guna2CircleButton4.PerformClick();
                }
            }
        }
    }
}
