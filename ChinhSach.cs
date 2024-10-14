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
            cmb_KT.SelectedIndex = 0; 
            cmb_KL.SelectedIndex = 0; 
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
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
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
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                    }
                }
            }
        }
    }
}
