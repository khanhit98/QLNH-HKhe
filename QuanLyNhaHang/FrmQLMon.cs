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
    public partial class FrmQLMon : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");

        public FrmQLMon()
        {
            InitializeComponent();
        }

        private void FrmQLMon_Load(object sender, EventArgs e)
        {
            load_Data();
        }
        public void load_Data()
        {
            conn.Open();
            string sql = "select * from MON";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dgvMon.DataSource = dt;
            conn.Close();
        }
        private void dgvMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int v=dgvMon.CurrentCell.RowIndex;

            txtMaMon.Text = dgvMon.Rows[v].Cells[0].Value.ToString();
            txtTenMon.Text = dgvMon.Rows[v].Cells[1].Value.ToString();
            txtDvt.Text = dgvMon.Rows[v].Cells[2].Value.ToString();
            txtDg.Text = dgvMon.Rows[v].Cells[3].Value.ToString();
        }
        private void ResetValues()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtDvt.Clear();
            txtDg.Clear();
            dgvMon.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            if ((txtMaMon.Text == "") || (txtTenMon.Text == ""))
            {
                MessageBox.Show("Điền đầy đủ thông tin","Thông báo");
            }
            else
            {
                try
                {
                    string them = @"INSERT INTO MON(MaMon,TenMon,DonViTinh,DonGia) 
                           VALUES ('" + txtMaMon.Text + "',N'" + txtTenMon.Text + "',N'" + txtDvt.Text + "','" + txtDg.Text + "')";
                    SqlCommand cmd = new SqlCommand(them, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã thêm món thành công","Thông báo");
                    conn.Close();
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã tồn tại mã món"+ex,"Thông báo");
                }
            }
            conn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Chưa chọn món", "Thông báo");
            }
            else
            {
                try
                {
                   
                    string sua = "update MON set TenMon=N'" + txtTenMon.Text + "',DonViTinh=N'" + txtDvt.Text + "',DonGia='" + txtDg.Text + "' WHERE MaMon='" + txtMaMon.Text + "' ";

                    SqlCommand cmd = new SqlCommand(sua, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã cập nhật thông tin món ăn", "Thông báo");
                    load_Data();
                    ResetValues();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Chưa cập nhật thông tin món ăn", "Thông báo");
                }
            }
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Chưa chọn mã món", "Thông báo");
            }
            else
            {
                try
                {
                    string xoa = "delete from MON where MaMon='" + txtMaMon.Text + "'";
                    SqlCommand cmd = new SqlCommand(xoa, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã xóa món ăn", "Thông báo");
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa xóa được món ăn" + ex, "Thông báo");
                }
            }
            conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txttentk_MouseClick(object sender, MouseEventArgs e)
        {
            txttentk.Clear();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            conn.Open();
            string tk = "SELECT * FROM MON where MaMon='" + txttentk.Text + "'";
            SqlCommand cmd = new SqlCommand(tk, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            dgvMon.DataSource = dt;

            conn.Close();
        }

       
    }
}
