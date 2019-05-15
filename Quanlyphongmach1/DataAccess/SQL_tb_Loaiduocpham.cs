using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Loaiduocpham
    {

        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string ma)
        {
            return cn.kiemtra("select count(*) from [LOAIDUOCPHAM] where MaLoaiDuocPham='" + ma + "'");
        }
        public void themmoi(EC_tb_Loaiduocpham key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.LOAIDUOCPHAM
                      (MaLoaiDuocPham,TenLoaiDuocPham) VALUES   ('" + key.MALOAIDUOCPHAM + "',N'" + key.TENLOAIDUOCPHAM + "')");
        }
        public void xoa(EC_tb_Loaiduocpham key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.LOAIDUOCPHAM WHERE [MaLoaiDuocPham] = '" + key.MALOAIDUOCPHAM + "'");
        }

        public void sua(EC_tb_Loaiduocpham key)
        {
            string sql = (@"UPDATE dbo.LOAIDUOCPHAM
            SET TenLoaiDuocPham =N'" + key.TENLOAIDUOCPHAM + "' where  MaLoaiDuocPham ='" + key.MALOAIDUOCPHAM + "'");
            cn.ExcuteNonQuery(sql);
        }

    }
}
