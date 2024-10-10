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
    public partial class Notification : Form
    {
        public string NotificationText { get; set; } 
        public string OkButtonText { get; set; } 
        public Notification()
        {
            InitializeComponent();
            this.Load += new EventHandler(Notification_Load);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Notification_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            textNotification.Text = NotificationText;
            Notification_Ok.Text = OkButtonText;
        }

        private void Notification_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
