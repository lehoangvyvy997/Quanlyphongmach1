using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Duocphamdvttesocuu
    {
        ConnectDB cn = new ConnectDB();
        
        public void sua(EC_tb_Duocphamdvytesocuu key)
        {
            string sql = (@"UPDATE dbo.DUOCPHAMDVYTESOCUU
            SET CongDung =N'" + key.CONGDUNG + "',TinhTrangConSD =N'" + key.TINHTRANGCONSD + "',GiaBan ='" + key.GIABAN + "' where  MaDuocPhamDVSoCuu ='" + key.MADUOCPHAMDVSOCUU + "'");
            cn.ExcuteNonQuery(sql);
        }

        // load auto-complete search
        public void load_maduocphamyte(TextBox txt)
        {
            cn.AutoComplete_txt(txt, "SELECT * FROM dbo.DUOCPHAMDVYTESOCUU", "MaDuocPhamDVSoCuu");
        }
        // load tên loại dược phẩm

        public string Load_tenldp(string tenldp, string maldp)
        {
            tenldp = cn.LoadTextBox("SELECT [TenLoaiDuocPham] From dbo.LOAIDUOCPHAM where MaLoaiDuocPham= '" + maldp + "'");
            return tenldp;
        }
    }
}
