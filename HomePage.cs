using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class HomPage : Form
    {
        public HomPage()
        {
            InitializeComponent();
            customizeDesing();
            InitializePanelProfile();
            openChildForm(new HomPagePanel());
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
            HomPage homepage = new HomPage();
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
            Application.Exit();
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
    }
}
