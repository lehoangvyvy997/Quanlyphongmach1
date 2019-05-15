using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Taikhoan
    {
        SQL_tb_Taikhoan tksql = new SQL_tb_Taikhoan();
        
        //Thêm tài khoản có khóa ngoại nhân viên
        public void themoitk1(EC_tb_Taikhoan tk)
        {
            if (!tksql.kiemtratk(tk.USERNAME))
            {
                if (!tksql.kiemtramaloaitk(tk.MALOAITAIKHOAN))
                {
                    MessageBox.Show("Mã loại tài khoản này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (tk.MANHANVIEN == "")
                    {
                        tksql.themmoitk2(tk);
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!tksql.kiemtramanhanvien(tk.MANHANVIEN))
                        {
                            MessageBox.Show("Mã nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            tksql.themmoitk1(tk);
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                
            }
            else
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Thêm tài khoản không có khóa ngoại nhân viên
        public void themoitk2(EC_tb_Taikhoan tk)
        {
            if (!tksql.kiemtratk(tk.USERNAME))
            {
                if (!tksql.kiemtramaloaitk(tk.MALOAITAIKHOAN))
                {
                    MessageBox.Show("Mã loại tài khoản này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (tk.MANHANVIEN == "")
                    {
                        tksql.themmoitk2(tk);
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!tksql.kiemtramanhanvien(tk.MANHANVIEN))
                        {
                            MessageBox.Show("Mã nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            tksql.themmoitk2(tk);
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Sửa tài khoản có khóa ngoại nhân viên
        public void suatk1(EC_tb_Taikhoan tk)
        {
            if (!tksql.kiemtramaloaitk(tk.MALOAITAIKHOAN))
            {
                MessageBox.Show("Mã loại tài khoản này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tk.MANHANVIEN == "")
                {
                    tksql.suatk2(tk);
                    MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!tksql.kiemtramanhanvien(tk.MANHANVIEN))
                    {
                        MessageBox.Show("Mã nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        tksql.suatk1(tk);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        //Sửa tài khoản không có khóa ngoại nhân viên
        public void suatk2(EC_tb_Taikhoan tk)
        {
            if (!tksql.kiemtramaloaitk(tk.MALOAITAIKHOAN))
            {
                MessageBox.Show("Mã loại tài khoản này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tk.MANHANVIEN == "")
                {
                    tksql.suatk2(tk);
                    MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!tksql.kiemtramanhanvien(tk.MANHANVIEN))
                    {
                        MessageBox.Show("Mã nhân viên này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        tksql.suatk1(tk);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            
        }
        public void xoatk(EC_tb_Taikhoan tk)
        {
            tksql.xoatk(tk);
        }
        //load loai tài khoản
        public void loadmaloaitk(ComboBox cbomaloaitk)
        {
            tksql.loadmaloaitk(cbomaloaitk);
        }
        public string loadtenloaitk(string Tenloaitk, string Maloaitk)
        {
            Tenloaitk = tksql.Loadtenloaitk(Tenloaitk, Maloaitk);
            return Tenloaitk;
        }

        //load nhân viên
        public void loadnhanvien(ComboBox cbomanhanvien)
        {
            tksql.loadmanhanvien(cbomanhanvien);
        }
        public string loadtennhanvien(string Tennhanvien, string Manhanvien)
        {
            Tennhanvien = tksql.Loadtennhanvien(Tennhanvien, Manhanvien);
            return Tennhanvien;
        }


    }
}
