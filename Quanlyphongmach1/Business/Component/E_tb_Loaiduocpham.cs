using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Loaiduocpham
    {
        SQL_tb_Loaiduocpham ldpsql = new SQL_tb_Loaiduocpham();
        public void themoi(EC_tb_Loaiduocpham ldp)
        {
            if (!ldpsql.kiemtra(ldp.MALOAIDUOCPHAM))
            {
                ldpsql.themmoi(ldp);
                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_Loaiduocpham ldp)
        {
            ldpsql.sua(ldp);
            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void xoa(EC_tb_Loaiduocpham ldp)
        {
            ldpsql.xoa(ldp);
        }
    }
}
