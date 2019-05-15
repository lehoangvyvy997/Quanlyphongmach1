using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chitietphieunhap
    {
        ConnectDB cn = new ConnectDB();

        public bool kiemtra_maldp(string maldp)
        {
            return cn.kiemtra("select count(*) from dbo.LOAIDUOCPHAM where MaLoaiDuocPham='" + maldp + "'");
        }
        
        public bool kiemtra_donvi(string dv)
        {
            return cn.kiemtra("select count(*) from dbo.DONVI where DonVi='" + dv + "'");
        }
        public bool kiemtra_mathuockham(string mathk)
        {
            return cn.kiemtra("select count(*) from dbo.THUOCKHAM where MaThuocKham='" + mathk + "'");
        }
        public bool kiemtra_dcyt(string madcyt)
        {
            return cn.kiemtra("select count(*) from dbo.DUNGCUYTE where MaDungCuYTe='" + madcyt + "'");
        }
        public bool kiemtra_dpdvsc(string madpdvsc)
        {
            return cn.kiemtra("select count(*) from dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu='" + madpdvsc + "'");
        }
        // thêm mới đơn vị
        public void themmoi_dv(EC_tb_Chitietphieunhap key)
        {
            string sql = @"INSERT INTO dbo.DONVI
                      (DonVi)
                        VALUES   (N'" + key.DONVI + "')";
            cn.ExcuteNonQuery(sql);
        }
        // thêm mới 1 danh mục
        public void themmoi(EC_tb_Chitietphieunhap key)
        {
            string sql = @"INSERT INTO dbo.CHITIETPHIEUNHAP_TAM
                      (MaPhieuNhapHang,MaLoaiDuocPham,DonVi,MaHangNhap,TenHangNhap,CongDung,GiaNhap,NgayNhap,SoLuongNhap)
                        VALUES   ('" + key.MAPHIEUNHAPHANG + "','" + key.MALOAIDUOCPHAM + "',N'" + key.DONVI + "','" + key.MAHANGNHAP + "',N'" + key.TENHANGNHAP + "',N'" + key.CONGDUNG + "','" + key.GIANHAP + "','" + key.NGAYNHAP + "'," + key.SOLUONGNHAP + ")";
            cn.ExcuteNonQuery(sql);
        }
        // lưu vào bảng CHITIETPHIEUKHAM
        public void themmoi_ct(EC_tb_Chitietphieunhap key)
        {
            string sql = @"INSERT INTO dbo.CHITIETPHIEUNHAP
                      (MaPhieuNhapHang,MaLoaiDuocPham,DonVi,MaHangNhap,TenHangNhap,CongDung,GiaNhap,NgayNhap,SoLuongNhap)
                        VALUES   ('" + key.MAPHIEUNHAPHANG + "','" + key.MALOAIDUOCPHAM + "',N'" + key.DONVI + "','" + key.MAHANGNHAP + "',N'" + key.TENHANGNHAP + "',N'" + key.CONGDUNG + "','" + key.GIANHAP + "','" + key.NGAYNHAP + "'," + key.SOLUONGNHAP + ")";
            cn.ExcuteNonQuery(sql);
        }
        // thêm mới thuốc khám
        public void themmoi_thk(EC_tb_Thuockham key)
        {
            string sql = @"INSERT INTO dbo.THUOCKHAM
                      (MaThuocKham,MaLoaiDuocPham,TenThuocKham,CongDung,DonVi,GiaThuocNhap,NgayNhap,TinhTrangConSD,GiaThuocBan,SoLuongCon)
                        VALUES   ('" + key.MATHUOCKHAM + "','" + key.MALOAIDUOCPHAM + "',N'" + key.TENTHUOCKHAM + "',N'" + key.CONGDUNG + "',N'" + key.DONVI + "','" + key.GIATHUOCNHAP + "','" + key.NGAYNHAP + "',N'" + key.TINHTRANGCONSD + "','" + key.GIATHUOCBAN + "'," + key.SOLUONGCON + ")";
            cn.ExcuteNonQuery(sql);
        }
        //cập nhật số lượng còn thuốc khám
        public void suasoluongthuockham(string key, int val1, string val2)
        {
            string sldangco = cn.LoadTextBox("SELECT [SoLuongCon] From dbo.THUOCKHAM where MaThuocKham= '" + key + "'");
            val1 += int.Parse(sldangco);

            string sql = (@"UPDATE    dbo.THUOCKHAM
                    SET SoLuongCon =" + val1 + ",GiaThuocNhap = '" + val2 + "'  where MaThuocKham='" + key + "'");
            cn.ExcuteNonQuery(sql);
        }
        // thêm mới dụng cụ y tế
        public void themmoi_dcyt(EC_tb_Dungcuyte key)
        {
            string sql = @"INSERT INTO dbo.DUNGCUYTE
                      (MaDungCuYTe,MaLoaiDuocPham,TenDungCuYTe,CongDung,DonVi,GiaNhap,NgayNhap,TinhTrangSuDung)
                        VALUES   ('" + key.MADUNGCUYTE + "','" + key.MALOAIDUOCPHAM + "',N'" + key.TENDUNGCUYTE + "',N'" + key.CONGDUNG + "',N'" + key.DONVI + "','" + key.GIANHAP + "','" + key.NGAYNHAP + "',N'" + key.TINHTRANGCONSD + "')";
            cn.ExcuteNonQuery(sql);
        }
        // thêm mới dược phẩm dịch vụ y tế sơ cứu
        public void themmoi_dpdvsc(EC_tb_Duocphamdvytesocuu key)
        {
            string sql = @"INSERT INTO dbo.DUOCPHAMDVYTESOCUU
                      (MaDuocPhamDVSoCuu,MaLoaiDuocPham,TenDuocPham,CongDung,DonVi,GiaNhap,NgayNhap,TinhTrangConSD,GiaBan,SoLuongCon)
                        VALUES   ('" + key.MADUOCPHAMDVSOCUU + "','" + key.MALOAIDUOCPHAM + "',N'" + key.TENDUOCPHAM + "',N'" + key.CONGDUNG + "',N'" + key.DONVI + "','" + key.GIANHAP + "','" + key.NGAYNHAP + "','" + key.TINHTRANGCONSD + "','" + key.GIABAN + "','" + key.SOLUONGCON + "')";
            cn.ExcuteNonQuery(sql);
        }
        //cập nhật số lượng còn thuốc khám
        public void suasoluongduocphamsocuu(string key, int val1, string val2)
        {

            string sldangco = cn.LoadTextBox("SELECT [SoLuongCon] From dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu= '" + key + "'");
            val1 += int.Parse(sldangco);

            string sql = (@"UPDATE    dbo.DUOCPHAMDVYTESOCUU
                    SET SoLuongCon =" + val1 + ", GiaNhap = '" + val2 + "'  where MaDuocPhamDVSoCuu='" + key + "'");
            cn.ExcuteNonQuery(sql);
        }
        public void xoa(EC_tb_Chitietphieunhap key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHITIETPHIEUNHAP_TAM WHERE MaPhieuNhapHang='" + key.MAPHIEUNHAPHANG + "' AND MaLoaiDuocPham='" + key.MALOAIDUOCPHAM + "'AND MaHangNhap='" + key.MAHANGNHAP + "'AND NgayNhap='" + key.NGAYNHAP + "'AND SoLuongNhap='" + key.SOLUONGNHAP + "'AND GiaNhap='" + key.GIANHAP + "'");
        }
        // xóa dữ liệu
        public void xoadulieu(string key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHITIETPHIEUNHAP_TAM WHERE MaPhieuNhapHang = '" + key + "'");
        }
        // sửa tình trạng
        public void suatinhtrang(string key)
        {
            string sql = (@"UPDATE    dbo.PHIEUNHAPHANG
                    SET TinhTrang =N'Đã nhập liệu'  where MaPhieuNhapHang='" + key + "'");
            cn.ExcuteNonQuery(sql);
        }
        // đếm dữ liệu
        public int demsodanhmucdanhap(string key)
        {
            int count = cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.CHITIETPHIEUNHAP_TAM WHERE MaPhieuNhapHang='" + key + "'");
            return count;
        }
        public void sua(EC_tb_Chitietphieunhap key)
        {
            string sql = (@"UPDATE    dbo.CHITIETPHIEUNHAP_TAM
                    SET MaPhieuNhapHang ='" + key.MAPHIEUNHAPHANG + "', MaLoaiDuocPham ='" + key.MALOAIDUOCPHAM + "', DonVi =N'" + key.DONVI + "', MaHangNhap ='" + key.MAHANGNHAP + "', TenHangNhap =N'" + key.TENHANGNHAP + "', CongDung =N'" + key.CONGDUNG + "', GiaNhap ='" + key.GIANHAP + "', NgayNhap ='" + key.NGAYNHAP + "', SoLuongNhap ='" + key.SOLUONGNHAP + "' where MaPhieuNhapHang ='" + key.MAPHIEUNHAPHANG + "'");
            cn.ExcuteNonQuery(sql);
        }
        // load auto-complete
        public void load_mahangnhap(ComboBox cbo)
        {
            cn.AutoComplete_cbo(cbo, "SELECT * FROM dbo.CHITIETPHIEUNHAP", "MaHangNhap");
        }
        public string Load_tenhangnhap(string ten, string mahangnhap)
        {
            ten = cn.LoadTextBox("SELECT [TenHangNhap] From dbo.CHITIETPHIEUNHAP where MaHangNhap= '" + mahangnhap + "'");
            return ten;
        }
        public string Load_congdung(string congdung, string mahangnhap)
        {
            congdung = cn.LoadTextBox("SELECT [CongDung] From dbo.CHITIETPHIEUNHAP where MaHangNhap= '" + mahangnhap + "'");
            return congdung;
        }
        public string Load_donvi(string donvi, string mahangnhap)
        {
            donvi = cn.LoadTextBox("SELECT [DonVi] From dbo.CHITIETPHIEUNHAP where MaHangNhap= '" + mahangnhap + "'");
            return donvi;
        }
        // load phiếu nhập hàng
        public void load_mapnh(ComboBox mapnh)
        {
            cn.LoadLenCombobox(mapnh, "SELECT     MaPhieuNhapHang FROM dbo.PHIEUNHAPHANG", 0);
        }
        public string Load_mancc(string mancc, string mapnh)
        {
            mancc = cn.LoadTextBox("SELECT [MaNhaCungCap] From dbo.PHIEUNHAPHANG where MaPhieuNhapHang= '" + mapnh + "'");
            return mancc;
        }
        public string Load_ngaynhap(string ngaynhap, string mapnh)
        {
            ngaynhap = cn.LoadTextBox("SELECT [NgayNHap] From dbo.PHIEUNHAPHANG where MaPhieuNhapHang= '" + mapnh + "'");
            return ngaynhap;
        }
        public string Load_sotien(string sotien, string mapnh)
        {
            sotien = cn.LoadTextBox("SELECT [SoTien] From dbo.PHIEUNHAPHANG where MaPhieuNhapHang= '" + mapnh + "'");
            return sotien;
        }
        public string Load_soluongdanhmuc(string soluongdanhmuc, string mapnh)
        {
            soluongdanhmuc = cn.LoadTextBox("SELECT [SoLuongDanhMucHangNhap] From dbo.PHIEUNHAPHANG where MaPhieuNhapHang= '" + mapnh + "'");
            return soluongdanhmuc;
        }
        public string Load_tinhtrang(string tinhtrang, string mapnh)
        {
            tinhtrang = cn.LoadTextBox("SELECT [TinhTrang] From dbo.PHIEUNHAPHANG where MaPhieuNhapHang= '" + mapnh + "'");
            return tinhtrang;
        }
        // load loại dược phẩm
        public void load_maldp(ComboBox maldp)
        {
            cn.LoadLenCombobox(maldp, "SELECT     MaLoaiDuocPham FROM dbo.LOAIDUOCPHAM", 0);
        }
        public string Load_tenldp(string tenldp, string maldp)
        {
            tenldp = cn.LoadTextBox("SELECT [TenLoaiDuocPham] From dbo.LOAIDUOCPHAM where MaLoaiDuocPham= '" + maldp + "'");
            return tenldp;
        }
        // load đơn vị
        public void load_donvi(ComboBox dv)
        {
            cn.LoadLenCombobox(dv, "SELECT     DonVi FROM dbo.DONVI", 0);
        }


    }
}
