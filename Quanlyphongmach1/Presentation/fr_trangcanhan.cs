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
    public partial class fr_trangcanhan : Form
    {
        private string maNV;
        public fr_trangcanhan(string manv)
        {
            maNV = manv;
            InitializeComponent();
        }
        public fr_trangcanhan()
        {
            InitializeComponent();
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }
        private void fr_trangcanhan_Load(object sender, EventArgs e)
        {
            loadthongtin();
        }
        ConnectDB cn = new ConnectDB();
        private string load_tenNV()
        {
            return cn.LoadLable("SELECT TenNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_ngaysinhNV()
        {
            return cn.LoadLable("SELECT NgaySinh FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_gioitinhNV()
        {
            return cn.LoadLable("SELECT GioiTinh FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_sdtNV()
        {
            return cn.LoadLable("SELECT SoDienThoai FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_emailNV()
        {
            return cn.LoadLable("SELECT Email FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_maloaiNV()
        {
            return cn.LoadLable("SELECT MaLoaiNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_maCVNV()
        {
            return cn.LoadLable("SELECT MaChucVu FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_maphongNV()
        {
            return cn.LoadLable("SELECT MaPhongKham FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maNV + "'");
        }
        private string load_tenCVNV()
        {
            return cn.LoadLable("SELECT TenChucVu FROM dbo.CHUCVU WHERE MaChucVu = '" + load_maCVNV() + "'");
        }
        private string load_tenloaiNV()
        {
            return cn.LoadLable("SELECT TenLoaiNhanVien FROM dbo.LOAINHANVIEN WHERE MaLoaiNhanVien = '" + load_maloaiNV() + "'");
        }
        private string load_tenphongNV()
        {
            return cn.LoadLable("SELECT TenPhongKham FROM dbo.PHONGKHAM WHERE MaPhongKham = '" + load_maphongNV() + "'");
        }


        private void loadthongtin()
        {
            lb_ma.Text = maNV;
            lb_ten.Text = load_tenNV();
            lb_ngay.Text = load_ngaysinhNV();
            lb_gioi.Text = load_gioitinhNV();
            lb_mail.Text = load_emailNV();
            lb_sdt.Text = load_sdtNV();
            lb_phong.Text = load_tenphongNV();
            lb_chuc.Text = load_tenCVNV();
            lb_loai.Text = load_tenloaiNV();
            if (lb_loai.Text == "Bác sĩ")
                ptb_avar.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;
            if(lb_loai.Text == "Lễ tân")
                ptb_avar.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;
            if (lb_loai.Text == "Thu ngân")
                ptb_avar.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;
            if (lb_loai.Text == "Dược sĩ")
                ptb_avar.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;
            if (lb_loai.Text == "Thủ kho")
                ptb_avar.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;

        }


        private string loadmaLTK(string us)
        {
            return cn.LoadLable("select MaLoaiTaiKhoan from [TAIKHOAN] WHERE Username = '" + us + "'");
        }
        private string loadtenLTK(string val)
        {
            return cn.LoadLable("select TenLoaiTaiKhoan from [LOAITAIKHOAN] WHERE MaLoaiTaiKhoan = '" + val + "'");
        }

        private string loadUsername(string idnv)
        {
            return cn.LoadLable("select Username from [TAIKHOAN] WHERE MaNhanVien = '" + idnv + "'");
        }
        private void btn_nvu_Click(object sender, EventArgs e)
        {
            string key = loadtenLTK(loadmaLTK(loadUsername(maNV)));

            switch (key)
            {
                case "Admin":
                    {
                        fr_quanlychung f = new fr_quanlychung();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ răng hàm mặt":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Răng - Hàm - Mặt");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ tai mũi họng":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Tai - Mũi - Họng");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ tim mạch":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Tim Mạch");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ da liễu":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Da Liễu");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ nội tiêu hóa":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Nội Tiêu Hóa");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ chỉnh hình":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Chỉnh Hình");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Bác sĩ đa khoa":
                    {
                        fr_phieukham f = new fr_phieukham(maNV, "Bác Sĩ Đa Khoa");
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Dược sĩ":
                    {
                        fr_diemnhanthuoc f = new fr_diemnhanthuoc();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Nhân viên thủ kho":
                    {
                        Presentation.fr_phieunhaphang f = new Presentation.fr_phieunhaphang();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Lễ tân":
                    {
                        Presentation.fr_benhnhan f = new Presentation.fr_benhnhan();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
                case "Thu ngân":
                    {
                        Presentation.fr_hoadonthutien f = new Presentation.fr_hoadonthutien();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                        break;
                    }
            }
        }

        private void btn_capntt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_capnhatthongtincanhan));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_capnhatthongtincanhan fr = new fr_capnhatthongtincanhan(maNV);
                fr.ShowDialog();
            }
        }

        private void btn_dmkh_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_doimatkhau));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_doimatkhau fr = new fr_doimatkhau(maNV);
                fr.ShowDialog();
            }
        }

        private void btn_davar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng chưa xây dựng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fr_trangcanhan_Activated(object sender, EventArgs e)
        {
            loadthongtin();
        }
    }
}
