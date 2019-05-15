using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Chamcong
    {
        SQL_tb_Chamcong val = new SQL_tb_Chamcong();

        // kiểm tra tồn tại
        public bool kiemtra_tontai(string maNV, DateTime date)
        {
            return val.kiemtra_tontai(maNV, date);
        }
        // Thêm mới 
        public void themmoi(EC_tb_Chamcong key)
        {
            val.themmoi(key);
            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Xóa 
        public void xoa(EC_tb_Chamcong key)
        {
            val.xoa(key);
        }
        //Sửa
        public void sua(EC_tb_Chamcong key)
        {
            val.sua(key);
            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // load tên loại nhân viên
        public string load_maloaiNV(string manv)
        {
            return val.load_maloaiNV(manv);
        }
        public string load_tenloaiNV(string maloainv)
        {
            return val.load_tenloaiNV(maloainv);
        }

        // load tên chức vụ
        public string load_maCV(string manv)
        {
            return val.load_maCV(manv);
        }
        public string load_tenCV(string maCV)
        {
            return val.load_tenCV(maCV);
        }
        // load tên phong khám
        public string load_maPGKH(string manv)
        {
            return val.load_maPGKH(manv);
        }
        public string load_tenPGKH(string maPGKH)
        {
            return val.load_tenPGKH(maPGKH);
        }


        // load ComboBox
        public void load_cboLoai(ComboBox cbo)
        {
            val.load_cboLoai(cbo);
        }
        public void load_cboChuc(ComboBox cbo)
        {
            val.load_cboChuc(cbo);
        }
        public void load_cboPhong(ComboBox cbo)
        {
            val.load_cboPhong(cbo);
        }
        // load auto-complete search
        public void load_tenNVSearch(TextBox txt)
        {
            val.load_tenNVSearch(txt);
        }
        // đếm số lượng phiếu chấm công
        public int demsoChamcong_inday(DateTime date)
        {
            return val.demsoChamcong_inday(date);
        }
    }
}
