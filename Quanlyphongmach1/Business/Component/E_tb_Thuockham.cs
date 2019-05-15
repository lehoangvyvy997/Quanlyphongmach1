using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Thuockham
    {
        SQL_tb_Thuockham keysql = new SQL_tb_Thuockham();

        public void sua(EC_tb_Thuockham key)
        {
            keysql.sua(key);
            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // load auto-complete
        public void load_mathuockham(TextBox txt)
        {
            keysql.load_mathuockham(txt);
        }
        // load thông tin loại dược phẩm
        public string load_tenldp(string tenldp, string maldp)
        {
            tenldp = keysql.Load_tenldp(tenldp, maldp);
            return tenldp;
        }
    }
}
