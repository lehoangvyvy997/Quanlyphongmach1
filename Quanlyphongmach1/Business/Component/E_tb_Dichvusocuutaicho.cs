using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Dichvusocuutaicho
    {
        SQL_tb_Dichvusocuutaicho keysql = new SQL_tb_Dichvusocuutaicho();
        
        public void themoi(EC_tb_Dichvusocuutaicho key)
        {
            if (!keysql.kiemtra(key.MALOAIDVSOCUU))
            {
                keysql.themmoi(key);
                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_Dichvusocuutaicho key)
        {
            keysql.sua(key);
            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void xoa(EC_tb_Dichvusocuutaicho key)
        {
            keysql.xoa(key);
        }

    }
}
