using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Nhanvien
    {
        ConnectDB cn = new ConnectDB();

        // Kiểm tra mã nhân viên có tồn tại không
        public bool kiemtranv(string nv)
        {
            return cn.kiemtra("select count(*) from dbo.NHANVIEN where MaNhanVien='" + nv + "'");
        }
        // Kiểm tra mã loại nhân viên có tồn tại không
        public bool kiemtralnv(string lnv)
        {
            return cn.kiemtra("select count(*) from dbo.LOAINHANVIEN where MaLoaiNhanVien='" + lnv + "'");
        }
        // Kiểm tra mã chức vụ có tồn tại không
        public bool kiemtracv(string cv)
        {
            return cn.kiemtra("select count(*) from dbo.CHUCVU where MaChucVu='" + cv + "'");
        }
        // Kiểm tra mã tình trạng làm việc có tồn tại không
        public bool kiemtrattlv(string ttlv)
        {
            return cn.kiemtra("select count(*) from dbo.TINHTRANGLAMVIEC where MaTTLV='" + ttlv + "'");
        }
        public bool kiemtramaphongkham(string mapk)
        {
            return cn.kiemtra("select count(*) from dbo.PHONGKHAM where MaPhongKham='" + mapk + "'");
        }
        //Thêm nhân viên mới có khóa ngoại
        public void themmoinv(EC_tb_Nhanvien nv)
        {
            string sql = @"INSERT INTO dbo.NHANVIEN
                      (MaNhanVien, MaPhongKham, MaLoaiNhanVien, MaChucVu, MaTTLV, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, Email, NgayVaoLam, TienLuong, TienTroCap, TienThuong)
                        VALUES   ('" + nv.MAHNHANVIEN + "','" + nv.MAPHONGKHAM + "','" + nv.MALOAINHANVIEN + "','" + nv.MACHUCVU + "','" + nv.MATTLV + "',N'" + nv.TENNHANVIEN + "','" + nv.NGAYSINH + "',N'" + nv.GIOITINH + "','" + nv.SDT + "','" + nv.EMAIL + "','" + nv.NGAYVAOLAM + "','" + nv.TIENLUONG + "','" + nv.TIENTROCAP + "','" + nv.TIENTHUONG + "')";
            cn.ExcuteNonQuery(sql);
        }
        // thêm mới không có khóa ngoại
        public void themmoinv_0pk(EC_tb_Nhanvien nv)
        {
            string sql = @"INSERT INTO dbo.NHANVIEN
                      (MaNhanVien, MaPhongKham, MaLoaiNhanVien, MaChucVu, MaTTLV, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, Email, NgayVaoLam, TienLuong, TienTroCap, TienThuong)
                        VALUES   ('" + nv.MAHNHANVIEN + "','" + "null" + "','" + nv.MALOAINHANVIEN + "','" + nv.MACHUCVU + "','" + nv.MATTLV + "',N'" + nv.TENNHANVIEN + "','" + nv.NGAYSINH + "',N'" + nv.GIOITINH + "','" + nv.SDT + "','" + nv.EMAIL + "','" + nv.NGAYVAOLAM + "','" + nv.TIENLUONG + "','" + nv.TIENTROCAP + "','" + nv.TIENTHUONG + "')";
            cn.ExcuteNonQuery(sql);
        }
        // Xóa nhân viên
        public void xoanv(EC_tb_Nhanvien nv)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.NHANVIEN WHERE MaNhanVien='" + nv.MAHNHANVIEN + "'");
        }
        // Sửa nhân viên có khóa ngoại
        public void suanv(EC_tb_Nhanvien nv)
        {
            string sql = (@"UPDATE    dbo.NHANVIEN
                    SET TenNhanVien =N'" + nv.TENNHANVIEN + "',MaPhongKham ='" + nv.MAPHONGKHAM + "', GioiTinh =N'" + nv.GIOITINH + "', NgaySinh =N'" + nv.NGAYSINH + "', SoDienThoai =N'" + nv.SDT + "', Email =N'" + nv.EMAIL + "',TienLuong ='" + nv.TIENLUONG+ "',TienTroCap ='" + nv.TIENTROCAP + "',TienThuong ='" + nv.TIENTHUONG + "',NgayVaoLam =N'" + nv.NGAYVAOLAM + "',MaLoaiNhanVien ='" + nv.MALOAINHANVIEN + "',MaChucVu ='" + nv.MACHUCVU + "',MaTTLV ='" + nv.MATTLV + "'  where MaNhanVien='" + nv.MAHNHANVIEN+ "'");
            cn.ExcuteNonQuery(sql);
        }
        // Sửa nhân viên không có khóa ngoại
        public void suanv_0(EC_tb_Nhanvien nv)
        {
            string sql = (@"UPDATE    dbo.NHANVIEN
                    SET TenNhanVien =N'" + nv.TENNHANVIEN + "',MaPhongKham ='" + "null" + "', GioiTinh =N'" + nv.GIOITINH + "', NgaySinh =N'" + nv.NGAYSINH + "', SoDienThoai =N'" + nv.SDT + "', Email =N'" + nv.EMAIL + "',TienLuong ='" + nv.TIENLUONG + "',TienTroCap ='" + nv.TIENTROCAP + "',TienThuong ='" + nv.TIENTHUONG + "',NgayVaoLam =N'" + nv.NGAYVAOLAM + "',MaLoaiNhanVien ='" + nv.MALOAINHANVIEN + "',MaChucVu ='" + nv.MACHUCVU + "',MaTTLV ='" + nv.MATTLV + "'  where MaNhanVien='" + nv.MAHNHANVIEN + "'");
            cn.ExcuteNonQuery(sql);
        }
        // Load loại nhân viên
        public void loadmaloainv(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     MaLoaiNhanVien FROM dbo.LOAINHANVIEN", 0);
        }
        public string Loadtenloainv(string tenloainv, string maloainv)
        {
            tenloainv = cn.LoadLable("SELECT [TenLoaiNhanVien] From dbo.LOAINHANVIEN where MaLoaiNhanVien= '" + maloainv + "'");
            return tenloainv;
        }
        // Load chức vụ
        public void loadmacv(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     MaChucVu FROM dbo.CHUCVU", 0);
        }
        public string Loadtencv(string tencv, string macv)
        {
            tencv = cn.LoadLable("SELECT [TenChucVU] From dbo.CHUCVU where MaChucVu= '" + macv + "'");
            return tencv;
        }

        // Load tình trạng làm việc
        public void loadmattlv(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     MaTTLV FROM dbo.TINHTRANGLAMVIEC", 0);
        }
        public string Loadtenttlv(string tenttlv, string mattlv)
        {
            tenttlv = cn.LoadLable("SELECT [TenTTLV] From dbo.TINHTRANGLAMVIEC where MaTTLV= '" + mattlv + "'");
            return tenttlv;
        }
        // Load Phòng khám
        public void loadmapk(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     MaPhongKham FROM dbo.PHONGKHAM", 0);
        }
        public string Loadtenphongkham(string tenpk, string mapk)
        {
            tenpk = cn.LoadLable("SELECT [TenPhongKham] From dbo.PHONGKHAM where MaPhongKham= '" + mapk + "'");
            return tenpk;
        }


    }
}
