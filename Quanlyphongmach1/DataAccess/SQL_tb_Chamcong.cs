using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chamcong
    {
        ConnectDB cn = new ConnectDB();
        // kiểm tra tồn tại
        public bool kiemtra_tontai(string maNV, DateTime date)
        {
            return cn.kiemtra("select count(*) from [CHAMCONG] where MaNhanVien = '" + maNV + "' AND NgayChamCong = '" + date.Year + "/" + date.Day + "/" + date.Month + "'");
        }
        // Thêm mới 
        public void themmoi(EC_tb_Chamcong key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.CHAMCONG
                      (MaChamCong,MaNhanVien,NgayChamCong,NghiCoPhep) VALUES   ('" + key.MACHAMCONG + "','" + key.MANHANVIEN + "','" + key.NGAYCHAMCONG + "',N'" + key.NGHICOPHEP + "')");
        }
        // Xóa 
        public void xoa(EC_tb_Chamcong key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHAMCONG WHERE [MaChamCong] = '" + key.MACHAMCONG + "'");
        }
        //Sửa
        public void sua(EC_tb_Chamcong key)
        {
            string sql = (@"UPDATE dbo.CHAMCONG
            SET NghiCoPhep =N'" + key.NGHICOPHEP + "' where  MaChamCong ='" + key.MACHAMCONG + "'");
            cn.ExcuteNonQuery(sql);
        }
        // load tên loại nhân viên
        public string load_maloaiNV(string manv)
        {
            return cn.LoadLable("SELECT MaLoaiNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = '" + manv + "'");
        }
        public string load_tenloaiNV(string maloainv)
        {
            return cn.LoadLable("SELECT TenLoaiNhanVien FROM dbo.LOAINHANVIEN WHERE MaLoaiNhanVien = '" + maloainv + "'");
        }

        // load tên chức vụ
        public string load_maCV(string manv)
        {
            return cn.LoadLable("SELECT MaChucVu FROM dbo.NHANVIEN WHERE MaNhanVien = '" + manv + "'");
        }
        public string load_tenCV(string maCV)
        {
            return cn.LoadLable("SELECT TenChucVu FROM dbo.CHUCVU WHERE MaChucVU = '" + maCV + "'");
        }
        // load tên phong khám
        public string load_maPGKH(string manv)
        {
            return cn.LoadLable("SELECT MaPhongKham FROM dbo.NHANVIEN WHERE MaNhanVien = '" + manv + "'");
        }
        public string load_tenPGKH(string maPGKH)
        {
            return cn.LoadLable("SELECT TenPhongKham FROM dbo.PHONGKHAM WHERE MaPhongKham = '" + maPGKH + "'");
        }

        
        // load ComboBox
        public void load_cboLoai(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     TenLoaiNhanVien FROM dbo.LOAINHANVIEN", 0);
        }
        public void load_cboChuc(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     TenChucVu FROM dbo.CHUCVU", 0);
        }
        public void load_cboPhong(ComboBox cbo)
        {
            cn.LoadLenCombobox(cbo, "SELECT     TenPhongKham FROM dbo.PHONGKHAM", 0);
        }
        // load auto-complete search
        public void load_tenNVSearch(TextBox txt)
        {
            cn.AutoComplete_txt(txt, "SELECT * FROM dbo.NHANVIEN", "TenNhanVien");
        }
        // đếm số lượng phiếu chấm công
        public int demsoChamcong_inday(DateTime date)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.CHAMCONG WHERE  NgayChamCong = '" + date.Year + "/" + date.Day + "/" + date.Month + "'");
        }
    }
}
