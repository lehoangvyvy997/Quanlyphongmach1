using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chitietdvsocuutaicho
    {
        ConnectDB cn = new ConnectDB();


        // Kiểm tra mã MaDuocPhamDVSoCuu có tồn tại không
        public bool kiemtra_madp(string val)
        {
            return cn.kiemtra("select count(*) from dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu='" + val + "'");
        }
        // Kiểm tra mã  MaLoaiDVSoCuu có tồn tại không

        public bool kiemtra_maloaidv(string val)
        {
            return cn.kiemtra("select count(*) from dbo.DICHVUSOCUUTAICHO where MaLoaiDVSoCuu='" + val + "'");
        }
        public bool kiemtra(string mapukh, string madv, string madp)
        {
            return cn.kiemtra("select count(*) from dbo.CHITIETDVSOCUUTAICHO where MaPhieuKham = '" + mapukh + "' AND MaLoaiDVSoCuu='" + madv + "' AND MaDuocPhamDVSoCuu='" + madp + "'");
        }
        // thêm mới chi tiết dịch vụ kỹ thuật
        public void themmoi(EC_tb_Chitietdvsocuutaicho val)
        {
            string sql = @"INSERT INTO dbo.CHITIETDVSOCUUTAICHO
                      (MaPhieuKham,MaDuocPhamDVSoCuu,MaLoaiDVSoCuu,SoLuong,ThanhTien)
                        VALUES   ('" + val.MAPHIEUKHAM + "','" + val.MADUOCPHAMDVSOCUU + "','" + val.MALOAIDVSOCUU + "'," + val.SOLUONG + "," + val.THANHTIEN + ")";
            cn.ExcuteNonQuery(sql);
        }
        // Xóa nhân viên
        public void xoa(EC_tb_Chitietdvsocuutaicho val)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaDuocPhamDVSoCuu= '" + val.MADUOCPHAMDVSOCUU + "' AND MaLoaiDVSoCuu= '" + val.MALOAIDVSOCUU + "' AND SoLuong = " + val.SOLUONG);
        }
        // Sửa nhân viên có khóa ngoại
        public void sua(EC_tb_Chitietdvsocuutaicho val)
        {
            string sql = (@"UPDATE    dbo.CHITIETDVSOCUUTAICHO
                    SET MaDuocPhamDVSoCuu ='" + val.MADUOCPHAMDVSOCUU + "',MaLoaiDVSoCuu ='" + val.MALOAIDVSOCUU + "',SoLuong =" + val.SOLUONG + ",ThanhTien =" + val.THANHTIEN + " WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaDuocPhamDVSoCuu= '" + val.MADUOCPHAMDVSOCUU + "' AND MaLoaiDVSoCuu= '" + val.MALOAIDVSOCUU + "' AND SoLuong = " + val.SOLUONG);
            cn.ExcuteNonQuery(sql);
        }



        // Load mã dịch vụ
        public void load_madvsc(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT   MaLoaiDVSoCuu   FROM dbo.DICHVUSOCUUTAICHO", 0);
        }
        public string Load_tendvsc(string madv)
        {
           return cn.LoadLable("SELECT [TenLoaiDV] From dbo.DICHVUSOCUUTAICHO where MaLoaiDVSoCuu= '" + madv + "'");
        }
        // Load mã dược phẩm sơ cứu
        public void load_madp(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT   MaDuocPhamDVSoCuu   FROM dbo.DUOCPHAMDVYTESOCUU", 0);
        }
        public string Load_tendp(string madp)
        {
            return cn.LoadLable("SELECT [TenDuocPham] From dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu= '" + madp + "'");
        }
        public string Load_donvidp( string madp)
        {
            return cn.LoadLable("SELECT [DonVi] From dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu= '" + madp + "'");
        }
        public string Load_congdungdp(string madp)
        {
            return cn.LoadLable("SELECT [CongDung] From dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu= '" + madp + "'");
        }
        public string Load_giaban(string madp)
        {
            return cn.LoadLable("SELECT [GiaBan] From dbo.DUOCPHAMDVYTESOCUU where MaDuocPhamDVSoCuu= '" + madp + "'");
        }
        // load auto-complete search
        public void loadcbo_madp(ComboBox cbo)
        {
            cn.AutoComplete_cbo(cbo, "SELECT * FROM dbo.DUOCPHAMDVYTESOCUU", "MaDuocPhamDVSoCuu");
        }
        public int laysohang(string mapukh)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + mapukh + "'");
        }
    }
}
