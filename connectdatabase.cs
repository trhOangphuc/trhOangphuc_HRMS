using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public class connectdatabase
    {

        public static bool IsDatabase;
        public static string PathName { get; set; }
        public static SqlConnection Connect()
        {

            PathName = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\quanlynhansu.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                IsDatabase = true;
                SqlConnection connection = new SqlConnection(PathName);
                return connection;
            }
            catch (Exception ex)
            {
                IsDatabase = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
