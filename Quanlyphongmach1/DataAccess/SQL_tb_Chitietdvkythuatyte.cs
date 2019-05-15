using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chitietdvkythuatyte
    {
        ConnectDB cn = new ConnectDB();


        // Kiểm tra mã loại dịch vụ có tồn tài không
        public bool kiemtra_maloaidv(string val)
        {
            return cn.kiemtra("select count(*) from dbo.DICHVUKYTHUATYTE where MaDVKyThuat='" + val + "'");
        }
        public bool kiemtra(string mapukh,string madv)
        {
            return cn.kiemtra("select count(*) from dbo.CHITIETDVKYTHUATYTE where MaPhieuKham = '" + mapukh + "' AND MaDVKyThuat='" + madv + "'");
        }
        // thêm mới chi tiết dịch vụ kỹ thuật
        public void themmoi(EC_tb_Chitietdvkythuatyte val)
        {
            string sql = @"INSERT INTO dbo.CHITIETDVKYTHUATYTE
                      (MaPhieuKham,MaDVKyThuat,SoLanSD, ThanhTien)
                        VALUES   ('" + val.MAPHIEUKHAM + "','" + val.MADVKYTHUAT + "'," + val.SOLANSD + "," + val.THANHTIEN + ")";
            cn.ExcuteNonQuery(sql);
        }
        // Xóa nhân viên
        public void xoa(EC_tb_Chitietdvkythuatyte val)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaDVKyThuat= '" + val.MADVKYTHUAT + "' AND SoLanSD = " + val.SOLANSD);
        }
        // Sửa nhân viên có khóa ngoại
        public void sua(EC_tb_Chitietdvkythuatyte val)
        {
            string sql = (@"UPDATE    dbo.CHITIETDVKYTHUATYTE
                    SET MaDVKyThuat ='" + val.MADVKYTHUAT + "',SoLanSD =" + val.SOLANSD  + ",ThanhTien =" + val.THANHTIEN + " WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaDVKyThuat= '" + val.MADVKYTHUAT + "' AND SoLanSD = " + val.SOLANSD);
            cn.ExcuteNonQuery(sql);
        }

        // Load mã dịch vụ
        public void load_madvkt(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT   MaDVKyThuat   FROM dbo.DICHVUKYTHUATYTE", 0);
        }
        public string Load_tendvkt(string madv)
        {
            return cn.LoadLable("SELECT [TenDVKyThuat] From dbo.DICHVUKYTHUATYTE where MaDVKyThuat= '" + madv + "'");
            
        }
        public string Load_chiphidvkt(string madv)
        {
            return cn.LoadLable("SELECT [ChiPhiSuDungDV] From dbo.DICHVUKYTHUATYTE where MaDVKyThuat= '" + madv + "'");
            
        }
        // lấy số
        public int laysohang(string mapukh)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + mapukh + "'");
        }

    }
}
