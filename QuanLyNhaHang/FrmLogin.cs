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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtTaikhoan.Text;
                string mk = txtMatkhau.Text;
                string sql="select * from NGUOIDUNG where TaiKhoan='"+tk+"' and MatKhau='"+mk+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();

                if(dta.Read()==true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Form frm = new FrmMain();
                    frm.Text = "Hệ thống";
                    frm.Show();
                    this.Hide();
                }
                    
                else
                {
                    MessageBox.Show("Đăng nhập thất bại kiểm tra lại tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối"+ex);
            }
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(tb==DialogResult.OK)
            {
                Application.Exit();
            }
        }
      
    }
}
