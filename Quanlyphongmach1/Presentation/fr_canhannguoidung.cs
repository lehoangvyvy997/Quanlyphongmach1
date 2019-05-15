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
    public partial class fr_canhannguoidung : Form
    {
        private string maNV;

        public fr_canhannguoidung(string manv)
        {
            maNV = manv;
            InitializeComponent();
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
            //            Lễ tân
            //Bác sĩ
            //Thu ngân
            //Dược sĩ
            //Thủ kho
            if (lb_loai.Text == "Bác sĩ")
                ptb.Image = global::Quanlyphongmach1.Properties.Resources.avatar_doc_F;

        }
    }
}
