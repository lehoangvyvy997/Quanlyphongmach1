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
    public partial class fr_capnhatthongtincanhan : Form
    {
        private string IDNV;
        public fr_capnhatthongtincanhan(string idNV)
        {
            IDNV = idNV;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        private string load_tenNV()
        {
            return cn.LoadLable("SELECT TenNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = '" + IDNV + "'");
        }
        private string load_sdtNV()
        {
            return cn.LoadLable("SELECT SoDienThoai FROM dbo.NHANVIEN WHERE MaNhanVien = '" + IDNV + "'");
        }
        private string load_MailNV()
        {
            return cn.LoadLable("SELECT Email FROM dbo.NHANVIEN WHERE MaNhanVien = '" + IDNV + "'");
        }
       
        private void fr_capnhatthongtincanhan_Load(object sender, EventArgs e)
        {
            lb_ma.Text = IDNV;
            lb_ten.Text = load_tenNV();
            txt_sdt.Text = load_sdtNV();
            txt_mail.Text = load_MailNV();
        }
        private int kiemtranull()
        {
            if (txt_sdt.Text == "")
                return 1;
            if (txt_mail.Text == "")
                return 2;
            
            return 0;
        }

        private void txt_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_luu_Click(object sender, EventArgs e)
        {
            int val = kiemtranull();
            switch (val)
            {
                case 0:
                    {
                        string sql = (@"UPDATE    dbo.NHANVIEN
                                     SET  SoDienThoai ='" + txt_sdt.Text + "', Email ='" + txt_mail.Text + "'  where MaNhanVien='" + IDNV + "'");
                        cn.ExcuteNonQuery(sql);
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Số điện thoại không thể để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_sdt.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Email không thể để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mail.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
    }
}
