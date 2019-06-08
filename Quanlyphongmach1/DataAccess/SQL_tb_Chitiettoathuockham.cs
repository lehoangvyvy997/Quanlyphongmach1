using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chitiettoathuockham
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra_mapukh(string val)
        {
            return cn.kiemtra("select count(*) from dbo.CHITIETTOATHUOCKHAM where MaPhieuKham='" + val + "'");
        }


        // Kiểm tra mã trong bảng thuốc khám có tồn tại không
        public bool kiemtra_mathuoc(string val)
        {
            return cn.kiemtra("select count(*) from dbo.THUOCKHAM where MaThuocKham='" + val + "'");
        }
        
        public bool kiemtra(string mapukh, string mathuockham)
        {
            return cn.kiemtra("select count(*) from dbo.CHITIETTOATHUOCKHAM where MaPhieuKham = '" + mapukh + "' AND MaThuocKham='" + mathuockham + "'");
        }
        // thêm mới chi tiết dịch vụ kỹ thuật
        public void themmoi(EC_tb_Chitiettoathuockham val)
        {
            string sql = @"INSERT INTO dbo.CHITIETTOATHUOCKHAM
                      (MaPhieuKham,MaThuocKham,SoLuong,CachDung,ThanhTien)
                        VALUES   ('" + val.MAPHIEUKHAM + "','" + val.MATHUOCKHAM + "'," + val.SOLUONG + ",N'" + val.CACHDUNG + "'," + val.THANHTIEN + ")";
            cn.ExcuteNonQuery(sql);
        }
        // Xóa 
        public void xoa(EC_tb_Chitiettoathuockham val)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaThuocKham= '" + val.MATHUOCKHAM + "' AND SoLuong= " + val.SOLUONG + " AND CachDung = N'" + val.CACHDUNG + "'");
        }
        // Xóa 
        public void xoa_(EC_tb_Chitiettoathuockham val)
        {
            cn.ExcuteNonQuery("DELETE * FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "'");
        }
        // Sửa 
        public void sua(EC_tb_Chitiettoathuockham val)
        {
            string sql = (@"UPDATE    dbo.CHITIETTOATHUOCKHAM
                    SET MaThuocKham ='" + val.MATHUOCKHAM + "',CachDung =N'" + val.CACHDUNG + "',SoLuong =" + val.SOLUONG + ",ThanhTien =" + val.THANHTIEN + " WHERE MaPhieuKham='" + val.MAPHIEUKHAM + "' AND MaThuocKham= '" + val.MATHUOCKHAM + "' AND SoLuong= " + val.SOLUONG + " AND CachDung = N'" + val.CACHDUNG + "'");
            cn.ExcuteNonQuery(sql);
        }
        // load auto-complete search
        public void loadcbo_mathk(ComboBox cbo)
        {
            cn.AutoComplete_cbo(cbo, "SELECT * FROM dbo.THUOCKHAM", "MaThuocKham");
        }
        // Load mã thuốc khám
        public void load_mathuockham(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT MaThuocKham FROM dbo.THUOCKHAM", 0);
        }

        public string Load_tenthk( string mathk)
        {
            return cn.LoadLable("SELECT [TenThuocKham] From dbo.THUOCKHAM where MaThuocKham= '" + mathk + "'");
        }
        public string Load_donvithk( string mathk)
        {
            return cn.LoadLable("SELECT [DonVi] From dbo.THUOCKHAM where MaThuocKham= '" + mathk + "'");
        }
        public string Load_congdungthk( string mathk)
        {
            return cn.LoadLable("SELECT [CongDung] From dbo.THUOCKHAM where MaThuocKham= '" + mathk + "'");
        }
        public string Load_giabanthk(string mathk)
        {
            return cn.LoadLable("SELECT [GiaThuocBan] From dbo.THUOCKHAM where MaThuocKham= '" + mathk + "'");
            
        }
       
        
        public int laysohang(string mapukh)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + mapukh + "'");
        }
    }
}
