using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Phieunhaphang
    {
        SQL_tb_Phieunhaphang pnhsql = new SQL_tb_Phieunhaphang();

        //Thêm tài khoản có khóa ngoại nhân viên
        public void themoipnh(EC_tb_Phieunhaphang pnh)
        {
            if (!pnhsql.kiemtrapnh(pnh.MAPHIEUNHAPHANG))
            {
                if (!pnhsql.kiemtramancc(pnh.MANHACUNGCAP))
                {
                    MessageBox.Show("Mã nhà cung cấp này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    pnhsql.themmoipnh(pnh);
                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Mã phiếu này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void suapnh(EC_tb_Phieunhaphang pnh)
        {
            if (!pnhsql.kiemtramancc(pnh.MANHACUNGCAP))
            {
                MessageBox.Show("Mã nhà cung cấp này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pnhsql.suapnh(pnh);
                MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void xoapnh(EC_tb_Phieunhaphang pnh)
        {
            pnhsql.xoapnh(pnh);
        }


        // load thông tin nhà cung cấp
        public void loadmancc(ComboBox cbomaloaitk)
        {
            pnhsql.loadmancc(cbomaloaitk);
        }
        public string loadtenncc(string tenncc, string mancc)
        {
            tenncc = pnhsql.Loadtenncc(tenncc, mancc);
            return tenncc;
        }

        public string loaddiachincc(string diachincc, string mancc)
        {
            diachincc = pnhsql.Loaddiachincc(diachincc, mancc);
            return diachincc;
        }
        public string loadsdtncc(string sdtncc, string mancc)
        {
            sdtncc = pnhsql.Loadsdtncc(sdtncc, mancc);
            return sdtncc;
        }
        public string loademailncc(string emailncc, string mancc)
        {
            emailncc = pnhsql.Loademailncc(emailncc, mancc);
            return emailncc;
        }
    }
}
