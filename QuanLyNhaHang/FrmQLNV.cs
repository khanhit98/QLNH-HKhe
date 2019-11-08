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
    public partial class FrmQLNV : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");
        
        public FrmQLNV()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_CboBP();
            load_Data();
        }

        public void load_CboBP()
        {
            conn.Open();
            string sql = "select * from BOPHAN";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CboMaBp.DataSource=dt;
            CboMaBp.DisplayMember = "TenBP";
            CboMaBp.ValueMember = "TenBP";
            conn.Close();

                     
        }
   
        public void load_Data()
        {
            conn.Open();
            string sql = "select * from NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                int v = dataGridView1.CurrentCell.RowIndex;

                txtManv.Text = dataGridView1.Rows[v].Cells[0].Value.ToString();
                txtHoten.Text = dataGridView1.Rows[v].Cells[1].Value.ToString();
                CboGioitinh.Text = dataGridView1.Rows[v].Cells[2].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[v].Cells[3].Value.ToString());
                txtDiachi.Text = dataGridView1.Rows[v].Cells[4].Value.ToString();
                txtSdt.Text = dataGridView1.Rows[v].Cells[5].Value.ToString();
                CboMaBp.Text = dataGridView1.Rows[v].Cells[6].Value.ToString();
                txtLuong.Text = dataGridView1.Rows[v].Cells[7].Value.ToString();
        }
        private void ResetValues()
        {
            txtManv.Clear();
            txtHoten.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
            txtLuong.Clear();
            dataGridView1.ClearSelection();

        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            if((txtManv.Text=="")||(txtHoten.Text=="")||(txtDiachi.Text=="")||(txtSdt.Text=="")||(txtLuong.Text=="") )
                {
                    MessageBox.Show("Không được để trường trống","Thông báo");
                }
            else
             {
                try
                {
                string them = @"INSERT INTO NHANVIEN(MaNV,HoTen,GioiTinh,NgaySinh,DiaChi,Sodt,BoPhan,Luong) 
                           VALUES ('" + txtManv.Text + "',N'" + txtHoten.Text + "',N'" + CboGioitinh.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd") +"','" + txtDiachi.Text + "','" + txtSdt.Text + "',N'" + CboMaBp.SelectedValue.ToString() + "','" + txtLuong.Text + "')";
                
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm nhân viên thành công","Thông báo");
                conn.Close();
                load_Data();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại"+ex,"Thông báo" );
            }
           }
            conn.Close();
         
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtManv.Text == "")
            {
                MessageBox.Show("Chưa chọn mã nhân viên", "Thông báo");
            }
            else
            {
                try
                { 
                    string xoa = "delete from NHANVIEN where MaNV='" + txtManv.Text + "'";
                    SqlCommand cmd = new SqlCommand(xoa, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa nhân viên", "Thông báo");
                    conn.Close();
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa xóa nhân viên", "Thông báo");
                }

            }
            conn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtManv.Text == "")
                {
                    MessageBox.Show("Chưa chọn thông tin", "Thông báo");
                }
            else
             {
               try
                {
                    
            string sua = "update NHANVIEN set HoTen=N'" + txtHoten.Text + "',GioiTinh=N'"+ CboGioitinh.Text+"',NgaySinh='" +Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd") + "',DiaChi='" + txtDiachi.Text + "',Sodt='" +txtSdt.Text+ "',BoPhan=N'" + CboMaBp.SelectedValue.ToString() + "',Luong='" + txtLuong.Text + "' where MaNV='"+txtManv.Text+"'";
            

            SqlCommand cmd = new SqlCommand(sua, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã cập nhật nhân viên thành công", "Thông báo");
            conn.Close();
            load_Data();
            ResetValues();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
           }
            conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            conn.Open();
            string tk = "SELECT * FROM NHANVIEN where MaNV='" + txttentk.Text + "'";
            SqlCommand cmd = new SqlCommand(tk, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt =new DataTable();
            dt.Load(da);
            dataGridView1.DataSource = dt;
            
            conn.Close();
        }
        private void txttentk_MouseClick(object sender, MouseEventArgs e)
        {
            txttentk.Clear();
        }
    }
}
