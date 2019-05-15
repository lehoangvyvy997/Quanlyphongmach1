using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Loaitaikhoan
    {
        SQL_tb_Loaitaikhoan lgsql = new SQL_tb_Loaitaikhoan();
        public void themoilg(EC_tb_Loaitaikhoan lg)
        {
            if (!lgsql.kiemtra(lg.MALOAITAIKHOAN))
            {
                lgsql.themmoi(lg);
                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sualg(EC_tb_Loaitaikhoan lg)
        {
            lgsql.sua(lg);
            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void xoalg(EC_tb_Loaitaikhoan lg)
        {
            lgsql.xoa(lg);
        }
    }
}
