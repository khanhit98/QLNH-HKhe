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

namespace QuanLyNhaHang
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");
            //conn.Open();
            string sql = "select * from NGUOIDUNG where TaiKhoan='" + txttaikhoan.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt =new DataTable();
            da.Fill(dt);

            try
            {
                
                SqlCommand cmd = new SqlCommand();
                if((txttaikhoan.Text=="") || (txtmkhientai.Text=="") || (txtmkmoi.Text=="") || (txtnhaplaimk.Text==""))
                {
                    MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo");
                }
                else
                    if((txttaikhoan.Text==dt.Rows[0]["TaiKhoan"].ToString()) && (txtmkhientai.Text==dt.Rows[0]["MatKhau"].ToString()) 
                        && (txtmkmoi.Text==txtnhaplaimk.Text))
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText ="update NGUOIDUNG set MatKhau=N'" + txtmkmoi.Text + "' where TaiKhoan=N'" + txttaikhoan.Text + "'";

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thay đổi mật khẩu","Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi không thành công", "Thông báo");
                    }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi"+ex);
            }
            conn.Close();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            
        }
    }
}
