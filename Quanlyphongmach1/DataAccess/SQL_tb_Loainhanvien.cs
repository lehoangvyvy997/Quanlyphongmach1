using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Loainhanvien
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string Maloainhanvien)
        {
            return cn.kiemtra("select count(*) from [LOAINHANVIEN] where MaLoaiNhanVien='" + Maloainhanvien + "'");
        }
        public void themmoi(EC_tb_Loainhanvien lnv)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.LOAINHANVIEN
                      (MaLoaiNhanVien,TenLoaiNhanVien) VALUES   ('" + lnv.MALOAINHANVIEN + "',N'" + lnv.TENLOAINHANVIEN + "')");
        }
        public void xoa(EC_tb_Loainhanvien lnv)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.LOAINHANVIEN WHERE [MaLoaiNhanVien] = '" + lnv.MALOAINHANVIEN + "'");
        }

        public void sua(EC_tb_Loainhanvien lnv)
        {
            string sql = (@"UPDATE dbo.LOAINHANVIEN
            SET TenLoaiNhanVien =N'" + lnv.TENLOAINHANVIEN + "' where  MaLoaiNhanVien ='" + lnv.MALOAINHANVIEN + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
