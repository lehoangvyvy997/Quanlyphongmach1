using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Phongkham
    {
        ConnectDB cn = new ConnectDB();

        public bool kiemtra(string Mapk)
        {
            return cn.kiemtra("select count(*) from [PHONGKHAM] where MaPhongKham='" + Mapk + "'");
        }

        public void themmoi(EC_tb_Phongkham key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.PHONGKHAM
                      (MaPhongKham,TenPhongKham,HangDoi,HieuHangDoi) VALUES   ('" + key.MAPHONGKHAM + "',N'" + key.TENPHONGKHAM + "', '0', '0')");
        }
        public void xoa(EC_tb_Phongkham key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.PHONGKHAM WHERE [MaPhongKham] = '" + key.MAPHONGKHAM + "'");
        }

        public void sua(EC_tb_Phongkham key)
        {
            string sql = (@"UPDATE dbo.PHONGKHAM
            SET TenPhongKham =N'" + key.TENPHONGKHAM + "' where  MaPhongKham ='" + key.MAPHONGKHAM + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
