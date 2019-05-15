using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Benhnhan
    {
        SQL_tb_Benhnhan keysql = new SQL_tb_Benhnhan();

        
        public void themoi_1(EC_tb_Benhnhan key)
        {
            if (!keysql.kiemtramabn(key.MABENHNHAN))
            {
                if(!keysql.kiemtramapk(key.MAPHONGKHAM1))
                {
                    MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    keysql.themmoi_1(key);
                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
            else
            {
                MessageBox.Show("Mã bệnh nhân này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void themoi_2(EC_tb_Benhnhan key)
        {
            if (!keysql.kiemtramabn(key.MABENHNHAN))
            {
                if (!keysql.kiemtramapk(key.MAPHONGKHAM1))
                {
                    MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!keysql.kiemtramapk(key.MAPHONGKHAM2))
                    {
                        MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        keysql.themmoi_2(key);
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                
            }
            else
            {
                MessageBox.Show("Mã bệnh nhân này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void themoi_3(EC_tb_Benhnhan key)
        {
            if (!keysql.kiemtramabn(key.MABENHNHAN))
            {
                if (!keysql.kiemtramapk(key.MAPHONGKHAM1))
                {
                    MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!keysql.kiemtramapk(key.MAPHONGKHAM2))
                    {
                        MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!keysql.kiemtramapk(key.MAPHONGKHAM3))
                        {
                            MessageBox.Show("Mã Phòng khám vừa nhập không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            keysql.themmoi_3(key);
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }

                
            }
            else
            {
                MessageBox.Show("Mã bệnh nhân này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // load thông tin phòng khám
        public void loadmapk(ComboBox cbo)
        {
            keysql.loadmapk(cbo);
        }
        public string loadtenpk(string tenpk, string mapk)
        {
            tenpk = keysql.Loadtenpk(tenpk, mapk);
            return tenpk;
        }
        public string loadhangdoi(string mapk)
        {
            return keysql.Loadhangdoi( mapk);
        }
        public string loadhieuhangdoi( string mapk)
        {
            return keysql.Loadhieuhangdoi(mapk);
        }
        public int demsobenhnhan_inday(DateTime date)
        {
            return keysql.demsobenhnhan_inday(date);
        }
    }
}
