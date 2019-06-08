using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Phieukham
    {
        ConnectDB cn = new ConnectDB();

        public bool kiemtramapukh(string mapukh)
        {
            return cn.kiemtra("select count(*) from [PHIEUKHAM] where MaPhieuKham='" + mapukh + "'");
        }

        // kiểm mã phiếu khám trong bảng chi tiết toa thuốc
        public bool kiemtramapukh_cttt(string mapukh)
        {
            return cn.kiemtra("select count(*) from [CHITIETTOATHUOCKHAM] where MaPhieuKham='" + mapukh + "'");
        }
        public bool kiemtramapukh_ctsc(string mapukh)
        {
            return cn.kiemtra("select count(*) from [CHITIETDVSOCUUTAICHO] where MaPhieuKham='" + mapukh + "'");
        }
        public bool kiemtramapukh_ctkt(string mapukh)
        {
            return cn.kiemtra("select count(*) from [CHITIETDVKYTHUATYTE] where MaPhieuKham='" + mapukh + "'");
        }
        public void themmoi(EC_tb_Phieukham key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.PHIEUKHAM
                      (MaPhieuKham,MaNhanVien,MaBenhNhan,NgayKham,ChuanDoanBenh,KeDonThuoc,TongTienThuoc,SuDungDVKyThuatYTe,TongTienDVKyThuat,SuDungDVSoCuu,TongTienDVSoCuu) VALUES   ('" + key.MAPHIEUKHAM + "','" + key.MAHNHANVIEN + "','" + key.MABENHNHAN + "','" + key.NGAYKHAM + "',N'" + key.CHUANDOANBENH + "',N'" + key.KEDONTHUOC + "','" + key.TONGTIENTHUOC + "',N'" + key.SUDUNGDVKYTHUATYTE + "','" + key.TONGTIENDVKYTHUAT + "',N'" + key.SUDUNGDVSOCUU + "','" + key.TONGTIENDVSOCUU + "')");
            
        }
        public void capnhatpkham(EC_tb_Phieukham key)
        {
            string sql = (@"UPDATE dbo.PHIEUKHAM
            SET ChuanDoanBenh =N'" + key.CHUANDOANBENH + "',KeDonThuoc=N'"+key.KEDONTHUOC+ "',TongTienThuoc='"+key.TONGTIENTHUOC+"',SuDungDVKyThuatYTe=N'"+key.SUDUNGDVKYTHUATYTE+"',TongTienDVKyThuat='"+key.TONGTIENDVKYTHUAT+"',SuDungDVSoCuu=N'"+key.SUDUNGDVSOCUU+"',TongTienDVSoCuu='"+key.TONGTIENDVSOCUU+"' where  MaPhieuKham ='" + key.MAPHIEUKHAM + "'");
            cn.ExcuteNonQuery(sql);
        }
        // xóa chit tiết toa thuốc khám
        public void xoa_(string tab, string val)
        {
            cn.ExcuteNonQuery("DELETE * FROM dbo." + tab + " WHERE MaPhieuKham='" + val + "'");
        }
        // Xóa bệnh nhân ở bảng tạm
        public void xoa_bn(string maBn, string maPgKh)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.BENHNHAN_TAM WHERE [MaBenhNhan] = '" + maBn + "' AND [MaPhongKham] = '" + maPgKh + "'");
        }
        // Cộng hiệu hàng đợi lên 1
        public void sua_hhd(string maPhkh, string val)
        {
            string sql = (@"UPDATE dbo.PHONGKHAM
            SET HieuHangDoi =" + val + " where  MaPhongKham ='" + maPhkh + "'");
            cn.ExcuteNonQuery(sql);
        }
        // load thông tin bác sĩ
        public string load_hotenBS( string maNV)
        {
            return cn.LoadLable("SELECT TenNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien ='" + maNV + "' ");
        }
        public string load_machuvu(string maNV)
        {
            return cn.LoadLable("SELECT MaChucVu FROM dbo.NHANVIEN WHERE MaNhanVien ='" + maNV + "' ");
        }
        public string load_tenchucvu(string maCV)
        {
            return cn.LoadLable("SELECT TenChucVu FROM dbo.CHUCVU WHERE MaChucVu ='" + maCV + "' ");
        }
        public string load_sdtnBS(string maNV)
        {
            return cn.LoadLable("SELECT SoDienThoai FROM dbo.NHANVIEN WHERE MaNhanVien ='" + maNV + "' ");
        }
        public string load_emailBS(string maNV)
        {
            return cn.LoadLable("SELECT Email FROM dbo.NHANVIEN WHERE MaNhanVien ='" + maNV + "' ");
        }
        public string load_maPGKH(string maNV)
        {
            return cn.LoadLable("SELECT MaPhongKham FROM dbo.NHANVIEN WHERE MaNhanVien ='" + maNV + "' ");
        }

        // load tên dịch vụ
        public string load_hotendvkt(string maDV)
        {
            return cn.LoadLable("SELECT TenDVKyThuat FROM dbo.DICHVUKYTHUATYTE WHERE MaDVKyThuat ='" + maDV + "' ");
        }
        public int demsophieukham_inday(DateTime date, string maNV)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.PHIEUKHAM WHERE MaNhanVien = '" + maNV + "' AND NgayKham = '" + date.Year + "/" + date.Month + "/" + date.Day + "'");
        }
    }
}
