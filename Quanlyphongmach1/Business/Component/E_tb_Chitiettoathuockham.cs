using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Chitiettoathuockham
    {
        SQL_tb_Chitiettoathuockham keysql = new SQL_tb_Chitiettoathuockham();

        public bool kiemtra_mapukh(string val)
        {
            return keysql.kiemtra_mapukh(val);
        }

        public void themoi(EC_tb_Chitiettoathuockham key)
        {

            if (!keysql.kiemtra(key.MAPHIEUKHAM, key.MATHUOCKHAM))
            {
                if (!keysql.kiemtra_mathuoc(key.MATHUOCKHAM))
                {
                    MessageBox.Show("Mã thuốc này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
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

        public void sua(EC_tb_Chitiettoathuockham key)
        {
            if (!keysql.kiemtra(key.MAPHIEUKHAM, key.MATHUOCKHAM))
            {
                if (!keysql.kiemtra_mathuoc(key.MATHUOCKHAM))
                {
                    MessageBox.Show("Mã thuốc này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
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
        public void xoa(EC_tb_Chitiettoathuockham key)
        {
            keysql.xoa(key);
        }
        public void xoa_(EC_tb_Chitiettoathuockham key)
        {
            keysql.xoa_(key);
        }

        // Load mã thuốc khám
        public void load_mathuockham(ComboBox cbo)
        {
            keysql.load_mathuockham(cbo);
        }
        public string Load_tenthk( string mathk)
        {
            return keysql.Load_tenthk(mathk);
        }
        public string Load_donvithk( string mathk)
        {
            return keysql.Load_donvithk( mathk);
        }
        public string Load_congdungthk( string mathk)
        {
            return keysql.Load_congdungthk(mathk);
        }
        public string Load_giabanthk(string mathk)
        {
            return keysql.Load_giabanthk(mathk);
        }
        // load auto-complete search
        public void loadcbo_mathk(ComboBox cbo)
        {
            keysql.loadcbo_mathk(cbo);
        }

        public int laysohang(string mapukh)
        {
            return keysql.laysohang(mapukh);
        }
    }
}
