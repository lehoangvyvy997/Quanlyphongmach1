using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Chitietdvkythuatyte
    {
        SQL_tb_Chitietdvkythuatyte keysql = new SQL_tb_Chitietdvkythuatyte();

        public void themoi(EC_tb_Chitietdvkythuatyte key)
        {
            if (!keysql.kiemtra(key.MAPHIEUKHAM,key.MADVKYTHUAT))
            {
                if(!keysql.kiemtra_maloaidv(key.MADVKYTHUAT))
                {
                    MessageBox.Show("Mã dịch vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    keysql.themmoi(key);
                    MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Thông tin này đã tồn tại,xin chọn Mã khác hoặc sửa thông tin đã có!", "Chú Ý", MessageBoxButtons.OK);
            }
        }

        public void sua(EC_tb_Chitietdvkythuatyte key)
        {
            if (!keysql.kiemtra(key.MAPHIEUKHAM, key.MADVKYTHUAT))
            {
                if (!keysql.kiemtra_maloaidv(key.MADVKYTHUAT))
                {
                    MessageBox.Show("Mã dịch vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    keysql.sua(key);
                    MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Thông tin này đã tồn tại,xin chọn Mã khác hoặc sửa thông tin đã có!", "Chú Ý", MessageBoxButtons.OK);
            }

            
        }
        public void xoa(EC_tb_Chitietdvkythuatyte key)
        {
            keysql.xoa(key);
        }
        public int laysohang(string mapukh)
        {
            return keysql.laysohang(mapukh);
        }
        public void load_madvkt(ComboBox cbo)
        {
            keysql.load_madvkt( cbo);
        }
        public string Load_tendvkt(string madv)
        {
            return keysql.Load_tendvkt(madv);
        }
        public string Load_chiphidvkt(string madv)
        {
            return keysql.Load_chiphidvkt(madv);
        }
        
    }
}
