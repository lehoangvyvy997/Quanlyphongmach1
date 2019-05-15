using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Nhacungcap
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string Mancc)
        {
            return cn.kiemtra("select count(*) from [NHACUNGCAP] where MaNhaCungCap='" + Mancc + "'");
        }
        public void themmoi(EC_tb_Nhacungcap ncc)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.NHACUNGCAP
                      (MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email,MatHangCungCap,SoTaiKhoan,NganHang,TinhTrangCungCap) VALUES   ('" + ncc.MANHACUNGCAP + "',N'" + ncc.TENNHANCUNGCAP + "',N'" + ncc.DIACHI + "','" + ncc.SDT + "','" + ncc.EMAIL + "',N'" + ncc.MATHANGCC + "','" + ncc.SOTAIKHOAN + "',N'" + ncc.NGANHANG + "',N'" + ncc.TINHTRANG + "')");
        }
        public void xoa(EC_tb_Nhacungcap ncc)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.NHACUNGCAP WHERE MaNhaCungCap = '" + ncc.MANHACUNGCAP + "'");
        }

        public void sua(EC_tb_Nhacungcap ncc)
        {
            string sql = (@"UPDATE dbo.NHACUNGCAP
            SET TenNhaCungCap =N'" + ncc.TENNHANCUNGCAP + "' where  MaNhaCungCap ='" + ncc.MANHACUNGCAP + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
