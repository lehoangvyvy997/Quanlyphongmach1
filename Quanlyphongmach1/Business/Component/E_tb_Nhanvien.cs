using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Nhanvien
    {
        SQL_tb_Nhanvien nvsql = new SQL_tb_Nhanvien();
        
        public void themoinv(EC_tb_Nhanvien nv)
        {
            if (!nvsql.kiemtranv(nv.MAHNHANVIEN))
            {
                if (!nvsql.kiemtralnv(nv.MALOAINHANVIEN))
                {
                    MessageBox.Show("Mã loại nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    if (!nvsql.kiemtracv(nv.MACHUCVU))
                    {
                        MessageBox.Show("Mã chức vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (!nvsql.kiemtrattlv(nv.MATTLV))
                        {
                            MessageBox.Show("Mã tình trạng làm việc này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (nv.MAPHONGKHAM=="")
                            {
                                nvsql.themmoinv_0pk(nv);
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if(!nvsql.kiemtramaphongkham(nv.MAPHONGKHAM))
                                {
                                    MessageBox.Show("Mã phòng khám này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    nvsql.themmoinv(nv);
                                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK);
                                }
                                
                            }
                        }
                        
                    }
                    
                }
                
            }
            else
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
            }
        }

        public void suanv(EC_tb_Nhanvien nv)
        {
            if (!nvsql.kiemtralnv(nv.MALOAINHANVIEN))
            {
                MessageBox.Show("Mã loại nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
            }
            else
            {
                if (!nvsql.kiemtracv(nv.MACHUCVU))
                {
                    MessageBox.Show("Mã chức vụ này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                }
                else
                {
                    if (!nvsql.kiemtrattlv(nv.MATTLV))
                    {
                        MessageBox.Show("Mã tình trạng làm việc này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (nv.MAPHONGKHAM == "")
                        {
                            nvsql.suanv_0(nv);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (!nvsql.kiemtramaphongkham(nv.MAPHONGKHAM))
                            {
                                MessageBox.Show("Mã phòng khám này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK);
                            }
                            else
                            {
                                nvsql.suanv(nv);//
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                        
                    }

                }

            }
            
        }

        public void xoanv(EC_tb_Nhanvien nv)
        {
            nvsql.xoanv(nv);
        }
        //load loai nhân viên
        public void loadmaloainv(ComboBox cbomaloainv)
        {
            nvsql.loadmaloainv(cbomaloainv);
        }
        public string loadtenloainv(string Tenloainv, string Maloainv)
        {
            Tenloainv = nvsql.Loadtenloainv(Tenloainv, Maloainv);
            return Tenloainv;
        }

        //load Chức vụ
        public void loadmachucvu(ComboBox cbomachucvu)
        {
            nvsql.loadmacv(cbomachucvu);
        }
        public string loadtenchucvu(string Tenchucvu, string Machucvu)
        {
            Tenchucvu = nvsql.Loadtencv(Tenchucvu, Machucvu);
            return Tenchucvu;
        }

        //load tình trạng làm việc
        public void loadmattlv(ComboBox cbomattlv)
        {
            nvsql.loadmattlv(cbomattlv);
        }
        public string loadtenttlv(string Tenttlv, string Mattlv)
        {
            Tenttlv = nvsql.Loadtenttlv(Tenttlv, Mattlv);
            return Tenttlv;
        }
        // load phòng khám
        public void loadmapk(ComboBox cbomapk)
        {
            nvsql.loadmapk(cbomapk);
        }
        public string loadtenpk(string Tenpk, string Mapk)
        {
            Tenpk = nvsql.Loadtenphongkham(Tenpk, Mapk);
            return Tenpk;
        }
    }
}
