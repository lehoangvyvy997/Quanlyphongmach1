using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Loainhanvien
    {
        SQL_tb_Loainhanvien cvsql = new SQL_tb_Loainhanvien();
        public void themoilg(EC_tb_Loainhanvien lnv)
        {
            if (!cvsql.kiemtra(lnv.MALOAINHANVIEN))
            {
                cvsql.themmoi(lnv);
                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sualg(EC_tb_Loainhanvien lnv)
        {
            cvsql.sua(lnv);
            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void xoalg(EC_tb_Loainhanvien lnv)
        {
            cvsql.xoa(lnv);
        }
    }
}
