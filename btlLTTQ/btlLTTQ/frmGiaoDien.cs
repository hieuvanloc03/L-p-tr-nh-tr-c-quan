using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btlLTTQ
{
    public partial class frmGiaoDien : Form
    {
        public static bool hien = false;
        public static string user = "";
        public frmGiaoDien()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap(this);
            frmDangNhap.ShowDialog();
            ToolStripMenuItem1.Enabled = hien;
            lbuser.Text = "Xin chào tài khoản: "+user;
        }

        private void frmGiaoDien_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem1.Enabled = hien;
        }
    }
}
