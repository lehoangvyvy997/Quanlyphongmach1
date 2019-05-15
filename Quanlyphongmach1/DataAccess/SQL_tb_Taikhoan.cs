using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Taikhoan
    {
        ConnectDB cn = new ConnectDB();


        // Kiểm tra tên đăng nhập có tồn tại không
        public bool kiemtratk(string username)
        {
            return cn.kiemtra("select count(*) from dbo.TAIKHOAN where Username='" + username + "'");
        }


        // Kiểm tra mã loại tài khoản có tồn tại không
        public bool kiemtramaloaitk(string maloaitaikhoan)
        {
            return cn.kiemtra("select count(*) from dbo.LOAITAIKHOAN where MaLoaiTaiKhoan='" + maloaitaikhoan + "'");
        }


        // Kiểm tra mã nhân viên có tồn tại không
        public bool kiemtramanhanvien(string manhanvien)
        {
            return cn.kiemtra("select count(*) from dbo.NHANVIEN where MaNhanVien='" + manhanvien + "'");
        }


        //Thêm tài khoản có khóa ngoại nhân viên
        public void themmoitk1(EC_tb_Taikhoan tk)
        {
            string sql = @"INSERT INTO dbo.TAIKHOAN
                      (Username, MaLoaiTaiKhoan, MaNhanVien, Password1, Password2)
                        VALUES   ('" + tk.USERNAME + "','" + tk.MALOAITAIKHOAN + "','" + tk.MANHANVIEN + "','" + tk.PASSWORD1 + "','" + tk.PASSWORD2 + "')";
            cn.ExcuteNonQuery(sql);
        }
        //Thêm tài khoản không có khóa ngoại nhân viên
        public void themmoitk2(EC_tb_Taikhoan tk)
        {
            string sql = @"INSERT INTO dbo.TAIKHOAN
                      (Username, MaLoaiTaiKhoan, MaNhanVien, Password1, Password2)
                        VALUES   ('" + tk.USERNAME + "','" + tk.MALOAITAIKHOAN + "', null ,'" + tk.PASSWORD1 + "','" + tk.PASSWORD2 + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoatk(EC_tb_Taikhoan tk)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.TAIKHOAN WHERE Username='" + tk.USERNAME + "'");
        }
        //Sửa tài khoản có khóa ngoại nhân viên
        public void suatk1(EC_tb_Taikhoan tk)
        {
            string sql = (@"UPDATE    dbo.TAIKHOAN
                    SET MaLoaiTaiKhoan ='" + tk.MALOAITAIKHOAN + "', MaNhanVien ='" + tk.MANHANVIEN + "', Password1 ='" + tk.PASSWORD1 + "', Password2 ='" + tk.PASSWORD2 + "'  where Username='" + tk.USERNAME + "'");
            cn.ExcuteNonQuery(sql);
        }
        //Sửa tài khoản không có khóa ngoại nhân viên
        public void suatk2(EC_tb_Taikhoan tk)
        {
            string sql = (@"UPDATE    dbo.TAIKHOAN
                    SET MaLoaiTaiKhoan ='" + tk.MALOAITAIKHOAN + "', MaNhanVien = null , Password1 ='" + tk.PASSWORD1 + "', Password2 ='" + tk.PASSWORD2 + "'  where Username='" + tk.USERNAME + "'");
            cn.ExcuteNonQuery(sql);
        }
        // load loại tài khoản
        public void loadmaloaitk(ComboBox maloaitk)
        {
            cn.LoadLenCombobox(maloaitk, "SELECT     MaLoaiTaiKhoan FROM dbo.LOAITAIKHOAN", 0);
        }
        public string Loadtenloaitk(string tenloaitk, string maloaitk)
        {
            tenloaitk = cn.LoadTextBox("SELECT [TenLoaiTaiKhoan] From dbo.LOAITAIKHOAN where MaLoaiTaiKhoan= '" + maloaitk + "'");
            return tenloaitk;
        }

        // load nhân viên

        public void loadmanhanvien(ComboBox manhanvien)
        {
            cn.LoadLenCombobox(manhanvien, "SELECT     MaNhanVien FROM dbo.NHANVIEN", 0);
        }
        public string Loadtennhanvien(string tennhanvien, string manhanvien)
        {
            tennhanvien = cn.LoadTextBox("SELECT [TenNhanVien] From dbo.NHANVIEN where MaNhanVien= '" + manhanvien + "'");
            return tennhanvien;
        }
    }
}
