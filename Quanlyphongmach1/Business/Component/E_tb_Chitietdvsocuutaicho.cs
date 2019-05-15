using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Chitietdvsocuutaicho
    {
        SQL_tb_Chitietdvsocuutaicho keysql = new SQL_tb_Chitietdvsocuutaicho();

        
        public void themoi(EC_tb_Chitietdvsocuutaicho key)
        {
            if (!keysql.kiemtra(key.MAPHIEUKHAM,key.MALOAIDVSOCUU, key.MADUOCPHAMDVSOCUU))
            {
                if (!keysql.kiemtra_maloaidv(key.MALOAIDVSOCUU))
                {
                    MessageBox.Show("Mã loại dịch vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    if (!keysql.kiemtra_madp(key.MADUOCPHAMDVSOCUU))
                    {
                        MessageBox.Show("Mã dược phẩm này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                    }
                    else
                    {
                        keysql.themmoi(key);
                        MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    
                }
                
            }
            else
            {
                MessageBox.Show("Thông tin này đã tồn tại,xin chọn Mã khác hoặc sửa thông tin đã có!", "Chú Ý", MessageBoxButtons.OK);
            }
        }

        public void sua(EC_tb_Chitietdvsocuutaicho key)
        {
            if (!keysql.kiemtra(key.MAPHIEUKHAM, key.MALOAIDVSOCUU, key.MADUOCPHAMDVSOCUU))
            {
                if (!keysql.kiemtra_maloaidv(key.MALOAIDVSOCUU))
                {
                    MessageBox.Show("Mã loại dịch vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    if (!keysql.kiemtra_madp(key.MADUOCPHAMDVSOCUU))
                    {
                        MessageBox.Show("Mã dược phẩm này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                    }
                    else
                    {
                        keysql.sua(key);
                        MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }

            }
            else
            {
                MessageBox.Show("Thông tin này đã tồn tại,xin chọn Mã khác hoặc sửa thông tin đã có!", "Chú Ý", MessageBoxButtons.OK);
            }
        }
        public void xoa(EC_tb_Chitietdvsocuutaicho key)
        {
            keysql.xoa(key);
        }

        public void load_madvsc(ComboBox cbo)
        {
            keysql.load_madvsc(cbo);
        }
        public string Load_tendvsc(string madv)
        {
            return keysql.Load_tendvsc( madv);
        }
        // Load mã dược phẩm sơ cứu
        public void load_madp(ComboBox cbo)
        {
            keysql.load_madp(cbo);
        }
        public string Load_tendp(string madp)
        {
            return keysql.Load_tendp( madp);
        }
        public string Load_donvidp(string madp)
        {
            return keysql.Load_donvidp(madp);
        }
        public string Load_congdungdp(string madp)
        {
            return keysql.Load_congdungdp(madp);
        }
        public string Load_giaban(string madp)
        {
            return keysql.Load_giaban(madp);
        }

        // load auto-complete search
        public void loadcbo_madp(ComboBox cbo)
        {
            keysql.loadcbo_madp(cbo);
        }

        public int laysohang(string mapukh)
        {
            return keysql.laysohang(mapukh);
        }
    }
}
