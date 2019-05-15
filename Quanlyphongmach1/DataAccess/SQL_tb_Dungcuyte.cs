using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Dungcuyte
    {
        ConnectDB cn = new ConnectDB();
        public void sua(EC_tb_Dungcuyte key)
        {
            string sql = (@"UPDATE dbo.DUNGCUYTE
            SET CongDung =N'" + key.CONGDUNG + "',TinhTrangSuDung =N'" + key.TINHTRANGCONSD + "' where  MaDungCuYTe ='" + key.MADUNGCUYTE + "'");
            cn.ExcuteNonQuery(sql);
        }

        // load auto-complete search
        public void load_madungcu(TextBox txt)
        {
            cn.AutoComplete_txt(txt, "SELECT * FROM dbo.DUNGCUYTE", "MaDungCuYTe");
        }
        // load tên loại dược phẩm

        public string Load_tenldp(string tenldp, string maldp)
        {
            tenldp = cn.LoadTextBox("SELECT [TenLoaiDuocPham] From dbo.LOAIDUOCPHAM where MaLoaiDuocPham= '" + maldp + "'");
            return tenldp;
        }
    }
}
