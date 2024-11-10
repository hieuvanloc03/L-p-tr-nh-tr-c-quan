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
    public partial class frmDangNhap : Form
    {
        frmGiaoDien formGiaoDien;
        Classes.DataBaseProcess DtBase = new Classes.DataBaseProcess();
        public frmDangNhap(frmGiaoDien frm)
        {
            InitializeComponent();
            this.formGiaoDien = frm;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            user.SetToolTip(txtUser,"Nhập số điện thoại");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int username = int.Parse(txtUser.Text);
            string password = txtPassword.Text;
            if (KiemTra(username, password))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo!");
                frmGiaoDien.hien = true;
                frmGiaoDien.user = txtUser.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo!");
                return;
            }

        }
        private bool KiemTra(int username, string password)
        {
            string sql = $"SELECT COUNT(*) FROM NhanVien WHERE SDT = {username} AND MatKhau = '{password}'";
            DataTable result = DtBase.DataReader(sql);
            return result.Rows.Count >0 && (int)result.Rows[0][0]>0;
        }
    }
}
