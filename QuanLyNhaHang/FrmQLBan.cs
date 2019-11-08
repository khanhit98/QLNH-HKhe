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
    public partial class FrmQLBan : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");
        public FrmQLBan()
        {
            InitializeComponent();
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int v = dgvBan.CurrentCell.RowIndex;
            
            txtMaBan.Text = dgvBan.Rows[v].Cells[0].Value.ToString();
            txtTenBan.Text =dgvBan.Rows[v].Cells[1].Value.ToString();
           
                        
        }
        public void load_Data()
        {
            conn.Open();
            string sql = "select * from BAN";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dgvBan.DataSource = dt;
            conn.Close();
        }
        private void ResetValues()
        {
            txtMaBan.Clear();
            txtTenBan.Clear();
            dgvBan.ClearSelection();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
             conn.Open();
             if ((txtMaBan.Text == "") || (txtTenBan.Text == ""))
             {
                 MessageBox.Show("Điền đầy đủ thông tin","Thông báo");
             }
             else
             {
                 try
                 {
                     string them = @"INSERT INTO BAN(MaBan,TenBan) 
                           VALUES ('" + txtMaBan.Text + "',N'" + txtTenBan.Text + "')";
                     SqlCommand cmd = new SqlCommand(them, conn);
                     cmd.ExecuteNonQuery();
                                      
                     MessageBox.Show("Đã thêm bàn thành công","Thông báo");
                     conn.Close();    
                     load_Data();
                     ResetValues();

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Mã bàn đã tồn tại","Thông báo");
                 }

             }
             conn.Close();
        
        }

        private void FrmQLBan_Load(object sender, EventArgs e)
        {
            load_Data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Chưa chọn bàn","Thông báo");
            }
            else
            {
                try
                {

                    string sua = "update BAN set MaBan='" + txtMaBan.Text + "', TenBan='" + txtTenBan.Text + "' WHERE MaBan='" + txtMaBan.Text + "' ";
                    SqlCommand cmd = new SqlCommand(sua, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật thông tin bàn","Thông báo");
                    conn.Close();
                    load_Data();
                    ResetValues();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Chưa cập nhật được thông tin bàn"+ex,"Thông báo");
                }
            }
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Chưa chọn mã bàn", "Thông báo");
            }
            else
            {
                try
                {
                    string xoa = "delete from BAN where MaBan='" + txtMaBan.Text + "'";
                    SqlCommand cmd = new SqlCommand(xoa, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã xóa bàn","Thông báo");
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa xóa được bàn","Thông báo");
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
            string tk = "SELECT * FROM BAN where MaBan='" + txttentk.Text + "'";
            SqlCommand cmd = new SqlCommand(tk, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            dgvBan.DataSource = dt;

            conn.Close();
        }

       

        private void txttentk_MouseClick(object sender, MouseEventArgs e)
        {
            txttentk.Clear();
        }

       
    }
}
