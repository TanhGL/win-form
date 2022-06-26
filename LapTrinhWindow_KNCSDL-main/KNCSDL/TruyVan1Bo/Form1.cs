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

namespace TruyVan1Bo
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        string strCon =  @"Data Source=DESKTOP-VJK97L8\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKhongParamater_Click(object sender, EventArgs e)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(strCon);
                    con.Open();
                }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string maKH = txtMaKH.Text.Trim();
                
                // Đối tượng thực thi truy vấn
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM KHACHHANG WHERE MAKH = '" + maKH + "'";

                // Gửi truy vấn vào kết nối CSDL
                cmd.Connection = con;

                // Thực thi
                SqlDataReader reader = cmd.ExecuteReader();// đầu đọc.
                if (reader.Read())
                {
                    string tenkh = reader.GetString(1);
                    string sdt = reader.GetString(2);
                    string gioitinh = reader.GetString(4);
                    // Hiển thị lên giao diện:
                    txtHoTen.Text = tenkh;
                    txtSDT.Text = sdt;
                    txtGioiTinh.Text = gioitinh;
                }
                reader.Close();// đóng đầu đọc
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnParamater_Click(object sender, EventArgs e)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(strCon);
                    con.Open();
                }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string makh = txtMaKH.Text.Trim();
                // Đối tượng thực thi truy vấn
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM KHACHHANG WHERE MAKH = @MAKH";
                // Đinh nghĩa sql paramater
                SqlParameter parameter = new SqlParameter("@MAKH", System.Data.SqlDbType.VarChar);
                parameter.Value = txtMaKH.Text.Trim();
                cmd.Parameters.Add(parameter);

                cmd.Connection = con;

                // Thực thi
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   string ten = reader.GetString(1);
                   string sdt = reader.GetString(2);
                   string gioitinh = reader.GetString(4);
                   txtHoTen.Text = ten;
                    txtSDT.Text = sdt;
                    txtGioiTinh.Text = gioitinh;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
