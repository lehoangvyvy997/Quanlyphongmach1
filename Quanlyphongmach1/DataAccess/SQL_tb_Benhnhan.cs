using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Benhnhan
    {
        ConnectDB cn = new ConnectDB();

        // kiểm tra mã bệnh nhân có tồn tại không
        public bool kiemtramabn(string mabn)
        {
            return cn.kiemtra("select count(*) from dbo.BENHNHAN where MaBenhNhan='" + mabn + "'");
        }
        public bool kiemtramapk(string mapk)
        {
            return cn.kiemtra("select count(*) from dbo.PHONGKHAM where MaPhongKham='" + mapk + "'");
        }

        // thêm bệnh nhân sử dụng 1 phòng khám
        public void themmoi_1(EC_tb_Benhnhan key)
        {
            
            string sql = @"INSERT INTO dbo.BENHNHAN
                      (MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,NgayKhamBenh,ChuanDonSoLuot,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3,ThuVienPhi,NhanThuoc)
                        VALUES   ('" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.DIACHI + "','" + key.NGAYKHAMBENH + "',N'" + key.CHUANDONSOLUOT + "','" + key.MAPHONGKHAM1 + "'," + key.STTPHONGKHAM1 + ",null,0,null,0,N'" + key.THUVIENPHI + "',N'" + key.NHANTHUOC + "')";
            cn.ExcuteNonQuery(sql);

            // lưu vào bản bệnh nhân tạm
            string sql_1 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM1 + ",'" + key.MAPHONGKHAM1 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_1);

            // cộng hàng đợi lên 1
            string sql1 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM1 + "'  where MaPhongKham='" + key.MAPHONGKHAM1 + "'");
            cn.ExcuteNonQuery(sql1);
        }
        // thêm bệnh nhân sử dụng 1 phòng khám
        public void themmoi_2(EC_tb_Benhnhan key)
        {
            
            string sql = @"INSERT INTO dbo.BENHNHAN
                      (MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,NgayKhamBenh,ChuanDonSoLuot,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3,ThuVienPhi,NhanThuoc)
                        VALUES   ('" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "','" + key.TUOI + "',N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.DIACHI + "','" + key.NGAYKHAMBENH + "',N'" + key.CHUANDONSOLUOT + "','" + key.MAPHONGKHAM1 + "'," + key.STTPHONGKHAM1 + ",'"+ key.MAPHONGKHAM2+"'," + key.STTPHONGKHAM2 + ",null,0,N'" + key.THUVIENPHI + "',N'" + key.NHANTHUOC + "')";
            cn.ExcuteNonQuery(sql);

            // lưu vào bản bệnh nhân tạm
            string sql_1 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM1 + ",'" + key.MAPHONGKHAM1 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_1);
            string sql_2 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM2 + ",'" + key.MAPHONGKHAM2 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_2);

            // tăng hàng đợi lên 1
            string sql1 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM1 + "'  where MaPhongKham='" + key.MAPHONGKHAM1 + "'");
            cn.ExcuteNonQuery(sql1);

            string sql2 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM2 + "'  where MaPhongKham='" + key.MAPHONGKHAM2 + "'");
            cn.ExcuteNonQuery(sql2);
        }

        public void themmoi_3(EC_tb_Benhnhan key)
        {
            
            string sql = @"INSERT INTO dbo.BENHNHAN
                      (MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,NgayKhamBenh,ChuanDonSoLuot,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3,ThuVienPhi,NhanThuoc)
                        VALUES   ('" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "','" + key.TUOI + "',N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.DIACHI + "','" + key.NGAYKHAMBENH + "',N'" + key.CHUANDONSOLUOT + "','" + key.MAPHONGKHAM1 + "'," + key.STTPHONGKHAM1 + ",'" + key.MAPHONGKHAM2 + "'," + key.STTPHONGKHAM2 + ",'" + key.MAPHONGKHAM3 + "'," + key.STTPHONGKHAM3 + ",N'" + key.THUVIENPHI + "',N'" + key.NHANTHUOC + "')";
            cn.ExcuteNonQuery(sql);

            // lưu vào bản bệnh nhân tạm
            string sql_1 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM1 + ",'" + key.MAPHONGKHAM1 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_1);
            string sql_2 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM2 + ",'" + key.MAPHONGKHAM2 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_2);
            string sql_3 = @"INSERT INTO dbo.BENHNHAN_TAM
                      (STTPhongKham,MaPhongKham,MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,ChuanDonSoLuot)
                        VALUES   (" + key.STTPHONGKHAM3 + ",'" + key.MAPHONGKHAM3 + "','" + key.MABENHNHAN + "',N'" + key.HOTENBENHNHAN + "'," + key.TUOI + ",N'" + key.GIOITINH + "','" + key.SOCMND + "',N'" + key.CHUANDONSOLUOT + "')";
            cn.ExcuteNonQuery(sql_3);

            string sql1 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM1 + "'  where MaPhongKham='" + key.MAPHONGKHAM1 + "'");
            cn.ExcuteNonQuery(sql1);

            string sql2 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM2 + "'  where MaPhongKham='" + key.MAPHONGKHAM2 + "'");
            cn.ExcuteNonQuery(sql2);

            string sql3 = (@"UPDATE    dbo.PHONGKHAM
                    SET HangDoi ='" + key.STTPHONGKHAM3 + "'  where MaPhongKham='" + key.MAPHONGKHAM3 + "'");
            cn.ExcuteNonQuery(sql3);
        }
        // load mã phòng khám
        public void loadmapk(ComboBox mapk)
        {
            cn.LoadLenCombobox(mapk, "SELECT     MaPhongKham FROM dbo.PHONGKHAM", 0);
        }
        public string Loadtenpk(string tenpk, string mapk)
        {
            tenpk = cn.LoadLable("SELECT [TenPhongKham] From dbo.PHONGKHAM where MaPhongKham= '" + mapk + "'");
            return tenpk;
        }
        public string Loadhangdoi(string mapk)
        {
            return cn.LoadLable("SELECT HangDoi FROM dbo.PHONGKHAM where MaPhongKham= '" + mapk + "'");
            
        }
        public string Loadhieuhangdoi(string mapk)
        {
            return cn.LoadLable("SELECT HieuHangDoi From dbo.PHONGKHAM where MaPhongKham= '" + mapk + "'");
        }
        public int demsobenhnhan_inday(DateTime date)
        {
            return cn.ExecuteScalar("SELECT COUNT(*) FROM dbo.BENHNHAN WHERE NgayKhamBenh = '" + date.Year + "/"+ date.Month + "/" + date.Day + "'");
        }

    }
}
