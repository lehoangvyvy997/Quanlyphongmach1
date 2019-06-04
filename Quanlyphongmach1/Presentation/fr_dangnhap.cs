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
        private string load_maloaiTK(string us)
        {
            return cn.LoadLable("SELECT MaLoaiTaiKhoan FROM dbo.TAIKHOAN WHERE Username = '" + us + "'");
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if(kiemtradangnhap(txt_un.Text, txt_pw.Text)==1)
            {
                
                if(load_maloaiTK(txt_un.Text)=="LTK00")
                {
                    fr_quanlychung f = new fr_quanlychung();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    fr_trangcanhan f = new fr_trangcanhan(load_maNV(txt_un.Text));
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                
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

        private void fr_dangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_dangnhap.PerformClick();
        }

        private void txt_pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_dangnhap.PerformClick();
        }
    }
}
