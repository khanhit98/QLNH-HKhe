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
    public partial class FrmDatMon : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kit\documents\visual studio 2013\Projects\QuanLyNhaHang\QuanLyNhaHang\QLNH.mdf;Integrated Security=True");

        public FrmDatMon()
        {
            InitializeComponent();
        }
        public void load_Data()
        {
            conn.Open();
            string sql = "select * from DATMON";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dgvDs.DataSource = dt;
            conn.Close();
        }
        private void FrmDatMon_Load(object sender, EventArgs e)
        {
            hienthitenmon();
            hienthisoban();
            txtid.Enabled = false;
            load_Data();
        }
        public void hienthitenmon()
        {
            string sql = "select*from MON";
            SqlDataAdapter da=new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable()
;
            da.Fill(dt);
            CboTenMon.DataSource = dt;
            CboTenMon.DisplayMember = "TenMon";
            CboTenMon.ValueMember = "TenMon";
        }
        public void hienthisoban()
        {
            string sql = "select*from BAN";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable()
;
            da.Fill(dt);
            CboSoBan.DataSource = dt;
            CboSoBan.DisplayMember = "TenBan";
            CboSoBan.ValueMember = "TenBan";
        }
     

        private void dgvDs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int v = dgvDs.CurrentCell.RowIndex;
            txtid.Text = dgvDs.Rows[v].Cells[0].Value.ToString();
            txtManv.Text = dgvDs.Rows[v].Cells[1].Value.ToString();
            CboTenMon.Text = dgvDs.Rows[v].Cells[2].Value.ToString();
            CboSoBan.Text = dgvDs.Rows[v].Cells[3].Value.ToString();
            txtSoluong.Text = dgvDs.Rows[v].Cells[4].Value.ToString();
            CboDonGia.Text = dgvDs.Rows[v].Cells[5].Value.ToString();
        }

        private void ResetValues()
        {
            txtManv.Clear();
            txtSoluong.Clear();          
            dgvDs.ClearSelection();
        }

        private void btnDatmon_Click(object sender, EventArgs e)
        {
            conn.Open();
            if ((txtManv.Text == "") || (txtSoluong.Text == ""))
            {
                MessageBox.Show("Điền đầy đủ thông tin", "Thông báo");
            }
            else
            {
              int dem = 0;
              dem = dgvDs.Rows.Count;
               
                string s = "";
                int i = 0;
                s = Convert.ToString(dgvDs.Rows[dem-2].Cells[0].Value);
                i = Convert.ToInt32((s.Remove(0,3)));   //Loại bỏ 3 ký tự STT
                if (i + 1 < 10)
                    txtid.Text = "STT0" + (i + 1).ToString();
                else if (i + 1 < 100)
                    txtid.Text = "STT" + (i + 1).ToString(); 
                try
                {
                    string them = @"INSERT INTO DATMON(Stt,MaNV,TenMon,TenBan,SoLuong,DonGia) 
                           VALUES ('" +txtid.Text + "','" + txtManv.Text + "',N'" + CboTenMon.Text + "',N'" + CboSoBan.Text + "','" + txtSoluong.Text + "','" + CboDonGia.Text + "')";
                    SqlCommand cmd = new SqlCommand(them, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Đã đặt món thành công", "Thông báo");
                    load_Data();
                    ResetValues();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đặt món" + ex, "Thông báo");
                }
            }
            conn.Close();
        }

        private void btnThaydoi_Click(object sender, EventArgs e)
        {
            conn.Open();
            if ((txtManv.Text == "") || (txtSoluong.Text == ""))
            {
                MessageBox.Show("Chưa chọn thông tin", "Thông báo");
            }
            else
            {
                try
                {
                    string sua = "update DATMON set MaNV='" + txtManv.Text + "' ,TenMon=N'" + CboTenMon.Text + "',TenBan=N'" + CboSoBan.Text + "',SoLuong='" + txtSoluong.Text + "',DonGia='" + CboDonGia.Text + "' WHERE Stt='"+txtid.Text+"' ";

                    SqlCommand cmd = new SqlCommand(sua, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã cập nhật thông tin đặt món","Thông báo");
                    load_Data();
                    ResetValues();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa cập nhật thông tin "+ex,"Thông báo");
                }
            }
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    string xoa = "delete from DATMON where Stt='" + txtid.Text + "'";
                    SqlCommand cmd = new SqlCommand(xoa, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đã xóa thành công");
                    load_Data();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            conn.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
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
            string tk = "SELECT * FROM DATMON where TenBan='" + txttentk.Text + "'";
            SqlCommand cmd = new SqlCommand(tk, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            dgvDs.DataSource = dt;

            conn.Close();
        }

       
       
    }
}
