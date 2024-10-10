using Guna.UI2.WinForms;
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
    public partial class Question : Form
    {
        public string QuestionText { get; set; } // Biến để lưu câu hỏi
        public string OkButtonText { get; set; } // Biến để lưu text cho nút OK

        public Question()
        {
            InitializeComponent();
            this.Load += new EventHandler(Question_Load);
        }

        private void Question_Load(object sender, EventArgs e)
        {
            // Thiết lập text cho label và nút OK khi form được tải
            editText_question.Text = QuestionText;
            Question_Ok.Text = OkButtonText;
        } 

        private void Question_Ok_Click(object sender, EventArgs e)
        {
            // Thực hiện hành động nào đó khi nút OK được nhấn
            // Ví dụ gọi một hàm từ form khác hoặc đóng form
            this.DialogResult = DialogResult.OK; // Trả về giá trị OK
            this.Close(); // Đóng form
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Question_Load_1(object sender, EventArgs e)
        {

        }

        private void editText_question_Click(object sender, EventArgs e)
        {

        }
    }
}
