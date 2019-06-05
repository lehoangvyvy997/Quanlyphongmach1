using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Presentation
{
    public partial class fr_doimatkhau : Form
    {
        private string IDNV;
        public fr_doimatkhau(string idNV)
        {
            IDNV = idNV;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        private void fr_doimatkhau_Load(object sender, EventArgs e)
        {

        }
        private bool kiemtraUsername(string username)
        {
            return cn.kiemtra("select count(*) from [TAIKHOAN] where Username='" + username + "'");
        }
        private bool kiemtraPassword(string username, string password)
        {
            return cn.kiemtra("select count(*) from [TAIKHOAN] where Password1 = '" + password + "' AND Username='" + username + "'");
        }
        private int kiemtranull()
        {
            if (txt_username.Text == "")
                return 1;
            if (txt_mkcu.Text == "")
                return 2;
            if (txt_makmoi1.Text == "")
                return 3;
            if (txt_mkmoi2.Text == "")
                return 4;
            // kiểm tra tồn tại username
            if (!kiemtraUsername(txt_username.Text))
                { return 5; }// không tồn tại username
            
            
            // kiểm tra password
            if (!kiemtraPassword(txt_username.Text, txt_mkcu.Text))
            { return 7; }

            // kiểm tra mật khẩu mới

            if (txt_makmoi1.Text != txt_mkmoi2.Text)
                return 9;
            return 0;

        }
        private void txt_luu_Click(object sender, EventArgs e)
        {
            int val = kiemtranull();

            switch (val)
            {
                case 0:
                    {
                        string sql = (@"UPDATE    dbo.TAIKHOAN
                                     SET  Password1 ='" + txt_makmoi1.Text + "'  where Username='" + txt_username.Text + "'");
                        cn.ExcuteNonQuery(sql);
                        
                        DialogResult dlr = MessageBox.Show("Đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dlr == DialogResult.OK)
                        {
                            this.Close();
                        }
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Tên đăng nhập không thể để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_username.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Mật khẩu mới không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mkcu.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Mật khẩu mới không thể để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_makmoi1.Focus();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Chưa xác nhận mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mkmoi2.Focus();
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_username.Focus();
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        MessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mkcu.Focus();
                        break;
                    }
                case 8:
                    {
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show("Mật khẩu xác nhận chưa đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mkmoi2.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void txt_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
