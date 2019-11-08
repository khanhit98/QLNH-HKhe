using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmLogin();
            frm.Text = "Đăng Nhập";
            frm.Show();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDoiMatKhau();
            frm.Text = "Đổi mật khẩu";
            frm.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLNV();
            frm.Text = "Quản lý nhân viên";
            frm.Show();
        }

        private void quảnLýMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLMon();
            frm.Text = "Quản lý món ăn";
            frm.Show();
        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLBan();
            frm.Text = "Quản lý bàn";
            frm.Show();
        }

        private void quảnLýĐặtMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDatMon();
            frm.Text = "Quản lý đặt món";
            frm.Show();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLNV() ;
            frm.Text = "Quản lý nhân viên";
            frm.Show();
        }

        private void btnQLB_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLBan();
            frm.Text = "Quản lý bàn";
            frm.Show();
        }

        private void btnQLM_Click(object sender, EventArgs e)
        {
            Form frm = new FrmQLMon();
            frm.Text = "Quản lý  món";
            frm.Show();
        }

        private void btnQLDM_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDatMon();
            frm.Text = "Quản lý đặt món";
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmLogin();
            frm.Text = "Đăng Nhập";
            frm.Show();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDangKy();
            frm.Text = "Đăng Ký";
            frm.Show();
        }

        private void quyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmUD();
            frm.Text = "Thông tin chi tiết";
            frm.Show();
        }

        private void thôngTinNhàHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmUD();
            frm.Text = "Thông tin chi tiết";
            frm.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDangKy();
            frm.Text = "Quản lý tài khoản";
            frm.Show();
        }
       
    }
}
