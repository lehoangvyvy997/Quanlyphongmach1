using Quanlyphongmach1.Business.Component;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using Quanlyphongmach1.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1
{
    public partial class fr_dangnhap : Form
    {
        public fr_dangnhap()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // trả về số hàng với mục tìm kiếm
        private int kiemtradangnhap(string us, string pw)
        {
            return cn.ExecuteScalar("select count(*) from [TAIKHOAN] WHERE Username = '" + us + "' AND Password1 = '" + pw + "'");
        }
        private string load_maNV(string us)
        {
            return cn.LoadLable("SELECT MaNhanVien FROM dbo.TAIKHOAN WHERE Username = '" + us + "'");
        }


        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if(kiemtradangnhap(txt_un.Text, txt_pw.Text)==1)
            {
                MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fr_trangcanhan f = new fr_trangcanhan(load_maNV(txt_un.Text));
                this.Hide();
                f.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Tài khoản đăng nhập chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_un.Text = "";
                txt_pw.Text = "";
                txt_un.Focus();
                return;
            }
            
        }

        private void fr_dangnhap_Load(object sender, EventArgs e)
        {
            txt_pw.Text = "";
            txt_un.Text = "";
        }

        private void fr_dangnhap_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
