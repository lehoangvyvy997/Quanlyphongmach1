using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Chitietphieunhap
    {
        SQL_tb_Chitietphieunhap keysql = new SQL_tb_Chitietphieunhap();
        // thêm mới 1 mục phiếu nhập
        public void themoi(EC_tb_Chitietphieunhap key)
        {
            if (!keysql.kiemtra_maldp(key.MALOAIDUOCPHAM))
            {
                MessageBox.Show("Mã loại dược phẩm này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!keysql.kiemtra_donvi(key.DONVI))
                {
                    keysql.themmoi_dv(key);
                    keysql.themmoi(key);
                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    keysql.themmoi(key);
                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        // sửa 1 mục phiếu nhập
        public void sua(EC_tb_Chitietphieunhap key)
        {

            if (!keysql.kiemtra_maldp(key.MALOAIDUOCPHAM))
            {
                MessageBox.Show("Mã loại dược phẩm này không tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!keysql.kiemtra_donvi(key.DONVI))
                {
                    keysql.themmoi_dv(key);
                    keysql.sua(key);
                    MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    keysql.sua(key);
                    MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
        // lưu vào bảng CHITIETPHIEUKHAM
        public void themmoi_ct(EC_tb_Chitietphieunhap key)
        {
            keysql.themmoi_ct(key);
        }
        // thêm mới thuốc khám
        public void themmoi_thk(EC_tb_Thuockham key)
        {
            if (!keysql.kiemtra_mathuockham(key.MATHUOCKHAM))
            {
                keysql.themmoi_thk(key);
            }
            else
            {
                keysql.suasoluongthuockham(key.MATHUOCKHAM, int.Parse(key.SOLUONGCON), key.GIATHUOCNHAP);
            }
        }
        
        // thêm mới dụng cụ y tế
        public void themmoi_dcyt(EC_tb_Dungcuyte key)
        {
            if(!keysql.kiemtra_dcyt(key.MADUNGCUYTE))
                keysql.themmoi_dcyt(key);
        }
        // thêm mới dược phẩm dịch vụ y tế sơ cứu
        public void themmoi_dpdvsc(EC_tb_Duocphamdvytesocuu key)
        {
            if(!keysql.kiemtra_dpdvsc(key.MADUOCPHAMDVSOCUU))
            {
                keysql.themmoi_dpdvsc(key);
            }
            else
            {
                keysql.suasoluongduocphamsocuu(key.MADUOCPHAMDVSOCUU, int.Parse(key.SOLUONGCON), key.GIANHAP);
            }
            
        }
        
        public void xoa(EC_tb_Chitietphieunhap key)
        {
            keysql.xoa(key);
        }
        // xóa dữ liệu
        public void xoadulieu(string key)
        {
            keysql.xoadulieu(key);
        }
        // đếm dữ liệu 
        public int demsodanhmucdanhap(string key)
        {
            int count = keysql.demsodanhmucdanhap(key);
            return count;
        }
        //sửa tình trạng
        public void suatinhtrang(string key)
        {
            keysql.suatinhtrang(key);
        }
        // load auto-complete
        public void load_mahangnhap(ComboBox cbo_mahangnhap)
        {
            keysql.load_mahangnhap(cbo_mahangnhap);
        }
        public string load_tenhangnhap(string ten, string mahangnhap)
        {
            ten = keysql.Load_tenhangnhap(ten, mahangnhap);
            return ten;
        }
        public string load_congdung(string congdung, string mahangnhap)
        {
            congdung = keysql.Load_congdung(congdung, mahangnhap);
            return congdung;
        }
        public string load_donvi(string donvi, string mahangnhap)
        {
            donvi = keysql.Load_donvi(donvi, mahangnhap);
            return donvi;
        }

        // load thông tin phiếu nhập hàng
        public void load_mapnh(ComboBox cbo_mapnh)
        {
            keysql.load_mapnh(cbo_mapnh);
        }
        public string load_mancc(string mancc, string mapnh)
        {
            mancc = keysql.Load_mancc(mancc, mapnh);
            return mancc;
        }
        public string load_ngaynhap(string ngaynhap, string mapnh)
        {
            ngaynhap = keysql.Load_ngaynhap(ngaynhap, mapnh);
            return ngaynhap;
        }
        public string load_sotien(string sotien, string mapnh)
        {
            sotien = keysql.Load_sotien(sotien, mapnh);
            return sotien;
        }
        public string load_soluongdanhmuc(string soluongdanhmuc, string mapnh)
        {
            soluongdanhmuc = keysql.Load_soluongdanhmuc(soluongdanhmuc, mapnh);
            return soluongdanhmuc;
        }
        public string load_tinhtrang(string tinhtrang, string mapnh)
        {
            tinhtrang = keysql.Load_tinhtrang(tinhtrang, mapnh);
            return tinhtrang;
        }
        // load đơn vị 
        public void load_donvi(ComboBox cbo_donvi)
        {
            keysql.load_donvi(cbo_donvi);
        }

        // load thông tin loại dược phẩm
        public void load_maldp(ComboBox cbo_maldp)
        {
            keysql.load_maldp(cbo_maldp);
        }
        public string load_tenldp(string tenldp, string maldp)
        {
            tenldp = keysql.Load_tenldp(tenldp, maldp);
            return tenldp;
        }
    }
}
