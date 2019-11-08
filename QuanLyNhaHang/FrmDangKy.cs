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
    public partial class FrmDangKy : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");

        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            load_Data();
        }
        public void load_Data()
        {
            conn.Open();
            string sql = "select * from NGUOIDUNG";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvDk.DataSource = dt;
            conn.Close();
        }

       
        private void ResetValues()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtSdt.Clear();
            
           dgvDk.ClearSelection();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            if((txtTaiKhoan.Text=="")||(txtMatKhau.Text=="")||(txtHoTen.Text=="")||(txtNgaySinh.Text=="")||(txtSdt.Text=="") )
                {
                    MessageBox.Show("Không được để trường trống","Thông báo");
                }
            else
             {
                
                try
                {
                string them = @"INSERT INTO NGUOIDUNG(TaiKhoan,MatKhau,HoTen,NgaySinh,Sdt) 
                           VALUES ('" + txtTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + txtHoTen.Text + "','" + Convert.ToDateTime(txtNgaySinh.Text).ToString("yyyy/MM/dd") + "','" + txtSdt.Text + "')";
                
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm tài khoản","Thông báo");
                conn.Close();
                
                load_Data();
                ResetValues();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản đã tồn tại hoặc kiểm tra dữ liệu nhập vào"+ex,"Thông báo" );
            }
           }
            conn.Close();
         
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
              conn.Open();
            if (txtTaiKhoan.Text == "")
                {
                    MessageBox.Show("Chưa chọn thông tin", "Thông báo");
                }
            else
             {
               try
                {
                    
            string sua = "update NGUOIDUNG set MatKhau=N'"+txtMatKhau.Text+"', HoTen=N'" + txtHoTen.Text + "',NgaySinh='" +txtNgaySinh.Text + "',Sdt='" +txtSdt.Text+ "' where TaiKhoan='"+txtTaiKhoan.Text+"'";
            

            SqlCommand cmd = new SqlCommand(sua, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã cập nhật tài khoản", "Thông báo");
            conn.Close();
            load_Data();
            ResetValues();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi "+ex, "Thông báo");
            }
           }
            conn.Close();
        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản", "Thông báo");
            }
            else
            {
                try
                {
                    string xoa = "delete from NGUOIDUNG where TaiKhoan='" + txtTaiKhoan.Text + "'";
                    SqlCommand cmd = new SqlCommand(xoa, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa tài khoản", "Thông báo");
                    conn.Close();
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa xóa được tài khoản", "Thông báo");
                }

            }
            conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            conn.Open();
            string tk = "SELECT * FROM NGUOIDUNG where TaiKhoan='" + txttentk.Text + "'";
            SqlCommand cmd = new SqlCommand(tk, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            dgvDk.DataSource = dt;

            conn.Close();
        }

        private void txtNgaySinh_MouseClick(object sender, MouseEventArgs e)
        {
            txtNgaySinh.Clear();
        }

        private void txttentk_MouseClick(object sender, MouseEventArgs e)
        {
            txttentk.Clear();
        }

        private void dgvDk_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int v = dgvDk.CurrentCell.RowIndex;

            txtTaiKhoan.Text = dgvDk.Rows[v].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvDk.Rows[v].Cells[1].Value.ToString();
            txtHoTen.Text = dgvDk.Rows[v].Cells[2].Value.ToString();
            txtNgaySinh.Text = dgvDk.Rows[v].Cells[3].Value.ToString();
            txtSdt.Text = dgvDk.Rows[v].Cells[4].Value.ToString();
        }
        }
    }

