using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Nhacungcap
    {
        SQL_tb_Nhacungcap cvsql = new SQL_tb_Nhacungcap();
        public void themoilg(EC_tb_Nhacungcap ncc)
        {
            if (!cvsql.kiemtra(ncc.MANHACUNGCAP))
            {
                cvsql.themmoi(ncc);
                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sualg(EC_tb_Nhacungcap ncc)
        {
            cvsql.sua(ncc);
            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void xoalg(EC_tb_Nhacungcap ncc)
        {
            cvsql.xoa(ncc);
        }
    }
}
