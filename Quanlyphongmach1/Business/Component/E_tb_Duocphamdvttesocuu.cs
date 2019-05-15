using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Duocphamdvttesocuu
    {
        SQL_tb_Duocphamdvttesocuu keysql = new SQL_tb_Duocphamdvttesocuu();
        
        public void sua(EC_tb_Duocphamdvytesocuu key)
        {
            keysql.sua(key);
            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // load auto-complete
        public void load_maduocphamyte(TextBox txt)
        {
            keysql.load_maduocphamyte(txt);
        }
        // load thông tin loại dược phẩm
        public string load_tenldp(string tenldp, string maldp)
        {
            tenldp = keysql.Load_tenldp(tenldp, maldp);
            return tenldp;
        }
    }
}
