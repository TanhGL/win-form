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
namespace DangBang
{
    public partial class Form1 : Form
    {
        string StrCon = @"Data Source=DESKTOP-VJK97L8\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        SqlConnection con = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTruyVan_Click(object sender, EventArgs e)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(StrCon);
                    con.Open();
                }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                // Đối tượng thực thi truy vấn
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM KHACHHANG";

                // 
                cmd.Connection = con;

                // thực thi
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string makh = reader.GetString(0);
                    string tenkh = reader.GetString(1);
                    string sdt = reader.GetString(2);
                    DateTime ngaysinh = reader.GetDateTime(3);
                    string gt = reader.GetString(4);
                    string cccd = reader.GetString(5);
                    string qt = reader.GetString(6); 

                    // hiển thị lên giao diện
                    ListViewItem lvi = new ListViewItem(makh);
                    lvi.SubItems.Add(tenkh);
                    lvi.SubItems.Add(sdt);
                    lvi.SubItems.Add(ngaysinh.ToString());
                    lvi.SubItems.Add(gt);
                    lvi.SubItems.Add(cccd);
                    lvi.SubItems.Add(qt);

                    lsvXem.Items.Add(lvi);
                }
                // dong dau doc
                reader.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
