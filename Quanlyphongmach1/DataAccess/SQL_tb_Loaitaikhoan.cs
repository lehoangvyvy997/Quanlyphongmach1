using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Loaitaikhoan
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string Maloaitaikhoan)
        {
            return cn.kiemtra("select count(*) from [LOAITAIKHOAN] where TenLoaiTaiKhoan=N'" + Maloaitaikhoan + "'");
        }
        public void themmoi(EC_tb_Loaitaikhoan q)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.LOAITAIKHOAN
                      (MaLoaiTaiKhoan,TenLoaiTaiKhoan) VALUES   (N'" + q.MALOAITAIKHOAN + "',N'" + q.TENLOAITAIKHOAN + "')");
        }
        public void xoa(EC_tb_Loaitaikhoan q)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.LOAITAIKHOAN WHERE [MaLoaiTaiKhoan] = N'" + q.MALOAITAIKHOAN + "'");
        }

        public void sua(EC_tb_Loaitaikhoan q)
        {
            string sql = (@"UPDATE dbo.LOAITAIKHOAN
            SET TenLoaiTaiKhoan =N'" + q.TENLOAITAIKHOAN + "' where  MaLoaiTaiKhoan =N'" + q.MALOAITAIKHOAN + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
