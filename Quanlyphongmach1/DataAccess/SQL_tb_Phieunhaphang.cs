using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Phieunhaphang
    {
        ConnectDB cn = new ConnectDB();


        public bool kiemtrapnh(string mapnh)
        {
            return cn.kiemtra("select count(*) from dbo.PHIEUNHAPHANG where MaPhieuNhapHang='" + mapnh + "'");
        }
        public bool kiemtramancc(string mancc)
        {
            return cn.kiemtra("select count(*) from dbo.NHACUNGCAP where MaNhaCungCap='" + mancc + "'");
        }
        public void themmoipnh(EC_tb_Phieunhaphang key)
        {
            string sql = @"INSERT INTO dbo.PHIEUNHAPHANG
                      (MaPhieuNhapHang, MaNhaCungCap, SoLuongDanhMucHangNhap, NgayNhap, SoTien, TinhTrang)
                        VALUES   ('" + key.MAPHIEUNHAPHANG + "','" + key.MANHACUNGCAP + "','" + key.SOLUONGDANHMUCHANGNHAP + "','" + key.NGAYNHAP + "','" + key.SOTIEN + "',N'" + key.TINHTRANG + "')";
            cn.ExcuteNonQuery(sql);
        }

        public void xoapnh(EC_tb_Phieunhaphang pnh)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.PHIEUNHAPHANG WHERE MaPhieuNhapHang='" + pnh.MAPHIEUNHAPHANG + "'");
        }

        public void suapnh(EC_tb_Phieunhaphang pnh)
        {
            string sql = (@"UPDATE    dbo.PHIEUNHAPHANG
                    SET MaNhaCungCap ='" + pnh.MANHACUNGCAP + "',SoLuongDanhMucHangNhap ='" + pnh.SOLUONGDANHMUCHANGNHAP + "', NgayNhap ='" + pnh.NGAYNHAP + "', SoTien ='" + pnh.SOTIEN + "' where MaPhieuNhapHang ='" + pnh.MAPHIEUNHAPHANG + "'");
            cn.ExcuteNonQuery(sql);
        }

        // load nhà cung cấp
        public void loadmancc(ComboBox mancc)
        {
            cn.LoadLenCombobox(mancc, "SELECT     MaNhaCungCap FROM dbo.NhaCungCap", 0);
        }
        public string Loadtenncc(string tenncc, string mancc)
        {
            tenncc = cn.LoadTextBox("SELECT [TenNhaCungCap] From dbo.NHACUNGCAP where MaNhaCungCap= '" + mancc + "'");
            return tenncc;
        }
        public string Loaddiachincc(string diachincc, string mancc)
        {
            diachincc = cn.LoadTextBox("SELECT [DiaChi] From dbo.NHACUNGCAP where MaNhaCungCap= '" + mancc + "'");
            return diachincc;
        }
        public string Loadsdtncc(string sdtncc, string mancc)
        {
            sdtncc = cn.LoadTextBox("SELECT [SoDienThoai] From dbo.NHACUNGCAP where MaNhaCungCap= '" + mancc + "'");
            return sdtncc;
        }
        public string Loademailncc(string emailncc, string mancc)
        {
            emailncc = cn.LoadTextBox("SELECT [Email] From dbo.NHACUNGCAP where MaNhaCungCap= '" + mancc + "'");
            return emailncc;
        }
        // kết thúc load nhà cung cấp
    }
}
