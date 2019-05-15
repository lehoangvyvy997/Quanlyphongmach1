using Quanlyphongmach1.Business.Component;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Presentation.Admin
{
    public partial class fr_admin_xemchitietphieukham : Form
    {
        public fr_admin_xemchitietphieukham()
        {
            InitializeComponent();
        }
        E_tb_Chitietphieunhap thucthi = new E_tb_Chitietphieunhap();
        ConnectDB cn = new ConnectDB();
        private int dong = 0;
        private void setnull()
        {
            txt_congdung.Text = "";
            txt_donvi.Text = "";
            txt_gianhap.Text = "";
            txt_mahangnhap.Text = "";
            txt_maloaidp.Text = "";
            txt_maphieunhaphang.Text = "";
            txt_ngaynhap.Text = "";
            txt_soluong.Text = "";
            txt_tenhangnhap.Text = "";
            txt_tenloaidp.Text = "";
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã loại dược phẩm";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Mã phiếu nhập hàng";
            dgv_ds.Columns[1].Width = 150;
            dgv_ds.Columns[2].HeaderText = "Mã mặt hàng";
            dgv_ds.Columns[2].Width = 150;
            dgv_ds.Columns[3].HeaderText = "Tên mặt hàng";
            dgv_ds.Columns[3].Width = 150;
            dgv_ds.Columns[4].HeaderText = "Đơn vị";
            dgv_ds.Columns[4].Width = 150;
            dgv_ds.Columns[5].HeaderText = "Công dụng";
            dgv_ds.Columns[5].Width = 150;
            dgv_ds.Columns[6].HeaderText = "Ngày nhập";
            dgv_ds.Columns[6].Width = 150;
            dgv_ds.Columns[7].HeaderText = "Giá nhập";
            dgv_ds.Columns[7].Width = 150;
            dgv_ds.Columns[8].HeaderText = "Số lượng";
            dgv_ds.Columns[8].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP ";
            dgv_ds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }
        private void ht(string sql)
        {

            dgv_ds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }
        public void hienthi_timkiem(string maphieunhaphang, string maloaidp, DateTime date)
        {
            string sql = "";
            string ngay = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if(maphieunhaphang!=""&&maloaidp!=""&&date.Day.ToString()!="")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaLoaiDuocPham = '" + maloaidp + "' AND MaPhieuNhapHang = '" + maphieunhaphang + "' AND NgayNhap = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (maphieunhaphang == "" && maloaidp != "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaLoaiDuocPham = '" + maloaidp + "' AND NgayNhap = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (maphieunhaphang != "" && maloaidp == "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE  MaPhieuNhapHang = '" + maphieunhaphang + "' AND NgayNhap = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (maphieunhaphang != "" && maloaidp != "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaLoaiDuocPham = '" + maloaidp + "' AND MaPhieuNhapHang = '" + maphieunhaphang + "'";
                ht(sql);
                return;
            }

            if (maphieunhaphang == "" && maloaidp != "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaLoaiDuocPham = '" + maloaidp + "'";
                ht(sql);
                return;
            }
            if (maphieunhaphang == "" && maloaidp == "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE  NgayNhap = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (maphieunhaphang != "" && maloaidp == "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaPhieuNhapHang = '" + maphieunhaphang + "'";
                ht(sql);
                return;
            }
            sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP WHERE MaLoaiDuocPham = '" + maloaidp + "' AND MaPhieuNhapHang = '" + maphieunhaphang + "' AND NgayNhap = '" + ngay + "'";
            ht(sql);
        }
        private string load_tenloaidp(string madp)
        {
            return cn.LoadLable("SELECT TenLoaiDuocPham FROM dbo.LOAIDUOCPHAM WHERE MaLoaiDuocPham = '" + madp + "'");
        }
        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            txt_maloaidp.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
            txt_maphieunhaphang.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
            txt_mahangnhap.Text = dgv_ds.Rows[dong].Cells[2].Value.ToString();
            txt_tenhangnhap.Text = dgv_ds.Rows[dong].Cells[3].Value.ToString();
            txt_congdung.Text = dgv_ds.Rows[dong].Cells[5].Value.ToString();
            txt_donvi.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
            txt_gianhap.Text = dgv_ds.Rows[dong].Cells[7].Value.ToString();
            txt_ngaynhap.Text = dgv_ds.Rows[dong].Cells[6].Value.ToString();
            txt_soluong.Text = dgv_ds.Rows[dong].Cells[8].Value.ToString();

            txt_tenloaidp.Text = load_tenloaidp(txt_maloaidp.Text);

        }

        private void fr_admin_xemchitietphieukham_Load(object sender, EventArgs e)
        {
            setnull();
            hienthi();

            thucthi.load_maldp(cbo_maloaiduocpham);
            thucthi.load_mapnh(cbo_maphieunhap);
            khoitaoluoi(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hienthi_timkiem(cbo_maphieunhap.Text, cbo_maloaiduocpham.Text, dtm_ngaynhap.Value);
            setnull();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
            setnull();
        }
    }
}
