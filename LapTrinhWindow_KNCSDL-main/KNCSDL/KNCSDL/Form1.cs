using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KNCSDL
{
    public partial class Form1 : Form
    {
        // Tạo 2 biến cục bộ
        string StrCon = @"Data Source=DESKTOP-VJK97L8\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";// @ chuỗi có
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnMo_Click(object sender, EventArgs e)
        {
            try
            {
                if(sqlCon == null)
                {
                    sqlCon = new SqlConnection(StrCon);// khởi tạo đối tượng kn --> truyền vào chuỗi kn
                }
                // Mở kết nối thành công
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("Kết nối thành công");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == System.Data.ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đóng kết nối");
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }

        private void btnTruyvan_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(StrCon);// khởi tạo đối tượng kn --> truyền vào chuỗi kn
                }
                // Mở kết nối thành công
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                   // MessageBox.Show("Kết nối thành công");
                }
                
                // đối tượng thực thi truy vấn
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM DICHVU";
                
                // GỬI truy vấn vào kết nối csdl
                cmd.Connection = sqlCon;

                // Nhận kết quả
                int soluong = (int)cmd.ExecuteScalar();
                // MessageBox.Show("Số lượng sinh viên là: " + soluong);
                label1.Text = "So luong sinh vien" + soluong.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
