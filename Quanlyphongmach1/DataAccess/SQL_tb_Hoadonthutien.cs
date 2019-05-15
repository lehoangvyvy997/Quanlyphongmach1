using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Hoadonthutien
    {
        ConnectDB cn = new ConnectDB();
        // Thêm mới hóa đơn
        public void themmoi(EC_tb_Hoadonthutien val)
        {
            if (val.MAPHIEUKHAM2 == "null" && val.MAPHIEUKHAM3 == "null")
            {
                // lưu TH bệnh nhân có 1 phiếu khám
                cn.ExcuteNonQuery(@"INSERT INTO dbo.HOADONTHUTIEN
                      (MaHoaDonThuTien,MaBenhNhan, MaPhieuKham1,MaPhieuKham2, MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien)
                        VALUES   ('" + val.MAHOADONTHUTIEN + "','" + val.MABENHNHAN + "','" + val.MAPHIEUKHAM1 + "',null,null,'" + val.NGAYLAPHOADON + "','" + val.TIENKHAM + "','" + val.TIENTHUOC + "','" + val.TIENSUDUNGDVKYTHUATYTE + "','" + val.TIENSUDUNGDVSOCUU + "','" + val.TONGTIEN + "')");
            }
            else
            {
                if(val.MAPHIEUKHAM2 != "null" && val.MAPHIEUKHAM3 == "null")
                {
                    // lưu TH bệnh nhân có 2 phiếu khám
                    cn.ExcuteNonQuery(@"INSERT INTO dbo.HOADONTHUTIEN
                      (MaHoaDonThuTien,MaBenhNhan, MaPhieuKham1,MaPhieuKham2, MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien)
                        VALUES   ('" + val.MAHOADONTHUTIEN + "','" + val.MABENHNHAN + "','" + val.MAPHIEUKHAM1 + "','" + val.MAPHIEUKHAM2 + "',null,'" + val.NGAYLAPHOADON + "','" + val.TIENKHAM + "','" + val.TIENTHUOC + "','" + val.TIENSUDUNGDVKYTHUATYTE + "','" + val.TIENSUDUNGDVSOCUU + "','" + val.TONGTIEN + "')");
                }
                else
                {
                    // lưu TH bệnh nhân có 3 phiếu khám
                    cn.ExcuteNonQuery(@"INSERT INTO dbo.HOADONTHUTIEN
                      (MaHoaDonThuTien,MaBenhNhan, MaPhieuKham1,MaPhieuKham2, MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien)
                        VALUES   ('" + val.MAHOADONTHUTIEN + "','" + val.MABENHNHAN + "','" + val.MAPHIEUKHAM1 + "','" + val.MAPHIEUKHAM2 + "','" + val.MAPHIEUKHAM3 + "','" + val.NGAYLAPHOADON + "','" + val.TIENKHAM + "','" + val.TIENTHUOC + "','" + val.TIENSUDUNGDVKYTHUATYTE + "','" + val.TIENSUDUNGDVSOCUU + "','" + val.TONGTIEN + "')");
                }
            }
        }
        // Sửa tình trạng thu tiền bệnh nhân
        public void sua_Bn(string maBenhnhan)
        {
            string sql = (@"UPDATE dbo.BENHNHAN
            SET ThuVienPhi =N'Đã thu' where  MaBenhNhan ='" + maBenhnhan + "'");
            cn.ExcuteNonQuery(sql);
        }

        // load tên bác sĩ
        public string Load_mabs(string maPukh)
        {
            return cn.LoadLable("SELECT MaNhanVien FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        public string Load_tenbs(string maBs)
        {
            return cn.LoadLable("SELECT TenNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = '" + maBs + "'");
        }
        // load chuẩn đoán
        public string Load_chuandoan(string maPukh)
        {
            return cn.LoadLable("SELECT ChuanDoanBenh FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load checkbox kê đơn thuốc
        public string Load_chkkedon(string maPukh)
        {
            return cn.LoadLable("SELECT KeDonThuoc FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load checkbox DVKT
        public string Load_chkdvkt(string maPukh)
        {
            return cn.LoadLable("SELECT SuDungDVKyThuatYTe FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load checkbox DVSC
        public string Load_chkdvsc(string maPukh)
        {
            return cn.LoadLable("SELECT SuDungDVSoCuu FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load tiền kê đơn thuốc
        public string Load_tienkedon(string maPukh)
        {
            return cn.LoadLable("SELECT TongTienThuoc FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load tiền DVKT
        public string Load_tiendvkt(string maPukh)
        {
            return cn.LoadLable("SELECT TongTienDVKyThuat FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // load tiền DVSC
        public string Load_tiendvsc(string maPukh)
        {
            return cn.LoadLable("SELECT TongTienDVSoCuu FROM dbo.PHIEUKHAM WHERE MaPhieuKham = '" + maPukh + "'");
        }
        // đếm số hóa đơn trong ngày
        public int demsohoadon_inday(DateTime date)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.HOADONTHUTIEN WHERE AND NgayKham = '" + date.Year + "/" + date.Month + "/" + date.Day + "'");
        }
    }
}
