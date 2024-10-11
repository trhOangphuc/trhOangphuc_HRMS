using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.Dialog
{
    public partial class Error : Form
    {
        public string ErrorText { get; set; } // Biến để lưu câu hỏi
        public string OkButtonText { get; set; }
        public Error()
        {
            InitializeComponent();
            this.Load += new EventHandler(Error_Load);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Error_Load(object sender, EventArgs e)
        {
            // Thiết lập text cho label và nút OK khi form được tải
            textError.Text = ErrorText;
            Error_Ok.Text = OkButtonText;
        }

        private void Error_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Trả về giá trị OK
            this.Close(); // Đóng form
        }
    }
}
