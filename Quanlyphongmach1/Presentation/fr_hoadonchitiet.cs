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

namespace Quanlyphongmach1.Presentation
{
    public partial class fr_hoadonchitiet : Form
    {
        private string maBenhnhan;
        private string dV;
        private string tongTien;
        public fr_hoadonchitiet(string mabenhnhan, string dv, string tongtien)
        {
            maBenhnhan = mabenhnhan;
            dV = dv;
            tongTien = tongtien;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi_sc()
        {
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].HeaderText = "Mã phiếu khám";
            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Width = 150;

            dgv.Columns[1].HeaderText = "Mã dược phẩm";
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].HeaderText = "Mã dịch vụ";
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].HeaderText = "Số lượng";
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].HeaderText = "Thành tiền";
            dgv.Columns[4].Width = 200;

        }

        public void hienthi_sc()
        {
            string sql1 = "SELECT MaPhieuKham FROM dbo.PHIEUKHAM WHERE MaBenhNhan = N'" + maBenhnhan + "'";
            DataTable ds_maPukh = cn.taobang(sql1);
            int countPukh = ds_maPukh.Rows.Count;

            string sql = "";
            switch (countPukh)
            {
                case 0:
                    {
                        sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong, ThanhTien FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '0'";
                        break;
                    }
                case 1:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong, ThanhTien FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + maphieukham1 + "'";
                        break;
                    }
                case 2:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong, ThanhTien FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "'";
                        break;
                    }
                case 3:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString(), maphieukham3 = ds_maPukh.Rows[2].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong, ThanhTien FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "' OR MaPhieuKham = '" + maphieukham3 + "'";
                        break;
                    }
            }
            
            dgv.DataSource = cn.taobang(sql);
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

        public void khoitaoluoi_kt()
        {
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].HeaderText = "Mã phiếu khám";
            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Width = 150;

            dgv.Columns[1].HeaderText = "Mã loại dịch vụ kỹ thuật";
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].HeaderText = "Số lượng";
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].HeaderText = "Thành tiền";
            dgv.Columns[3].Width = 200;

        }

        public void hienthi_kt()
        {
            string sql1 = "SELECT MaPhieuKham FROM dbo.PHIEUKHAM WHERE MaBenhNhan = N'" + maBenhnhan + "'";
            DataTable ds_maPukh = cn.taobang(sql1);
            int countPukh = ds_maPukh.Rows.Count;

            string sql = "";
            switch (countPukh)
            {
                case 0:
                    {
                        sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD, ThanhTien FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '0'";
                        break;
                    }
                case 1:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD, ThanhTien FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + maphieukham1 + "'";
                        break;
                    }
                case 2:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD, ThanhTien FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "'";
                        break;
                    }
                case 3:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString(), maphieukham3 = ds_maPukh.Rows[2].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD, ThanhTien FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "' OR MaPhieuKham = '" + maphieukham3 + "'";
                        break;
                    }
            }

            
            dgv.DataSource = cn.taobang(sql);
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


        public void khoitaoluoi_dtk()
        {
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].HeaderText = "Mã phiếu khám";
            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Width = 150;

            dgv.Columns[1].HeaderText = "Mã thuốc";
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].HeaderText = "Số lượng";
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].HeaderText = "Cách dùng";
            dgv.Columns[3].Width = 200;
            dgv.Columns[4].HeaderText = "Thành tiền";
            dgv.Columns[4].Width = 200;

        }

        public void hienthi_dtk()
        {
            string sql1 = "SELECT MaPhieuKham FROM dbo.PHIEUKHAM WHERE MaBenhNhan = N'" + maBenhnhan + "'";
            DataTable ds_maPukh = cn.taobang(sql1);
            int countPukh = ds_maPukh.Rows.Count;

            string sql = "";
            switch (countPukh)
            {
                case 0:
                    {
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '0'";
                        break;
                    }
                case 1:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "'";
                        break;
                    }
                case 2:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "'";
                        break;
                    }
                case 3:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString(), maphieukham3 = ds_maPukh.Rows[2].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "' OR MaPhieuKham = '" + maphieukham3 + "'";
                        break;
                    }
            }

            
            dgv.DataSource = cn.taobang(sql);
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

        private void fr_hoadonchitiet_Load(object sender, EventArgs e)
        {
            switch (dV)
            {
                case "1":
                    {
                        lb_name.Text = "Chi Tiết Đơn Thuốc Khám";
                        hienthi_dtk();
                        khoitaoluoi_dtk();
                        txt_tien.Text = tongTien;
                        break;
                    }
                case "2":
                    {
                        lb_name.Text = "Chi Tiết Dịch Vụ Kỹ Thuật";
                        hienthi_kt();
                        khoitaoluoi_kt();
                        txt_tien.Text = tongTien;
                        break;
                    }
                case "3":
                    {
                        lb_name.Text = "Chi Tiết Dịch Vụ Sơ Cứu";
                        hienthi_sc();
                        khoitaoluoi_sc();
                        txt_tien.Text = tongTien;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
    }
}
