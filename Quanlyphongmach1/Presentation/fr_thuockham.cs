using Quanlyphongmach1.Business.Component;
using Quanlyphongmach1.Business.EntitiesClass;
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
    public partial class fr_thuockham : Form
    {
        public fr_thuockham()
        {
            InitializeComponent();
        }

        E_tb_Thuockham thucthi = new E_tb_Thuockham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Thuockham ck = new EC_tb_Thuockham();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_maloaithuoc.Text = "";
            txt_tenloaithuoc.Text = "";
            txt_mathuoc.Text = "";
            txt_tenthuoc.Text = "";
            txt_congdung.Text = "";
            txt_donvi.Text = "";
            txt_gianhap.Text = "";
            txt_ngaynhap.Text = ""; 
            cbo_tinhtrang.Text = "Còn dùng";
            txt_giaban.Text = "";
            txt_slcon.Text = "";

            txt_search1.Text = "";
            txt_search2.Text = "";

        }
        public void locktext()
        {
            txt_giaban.Enabled = false;
            txt_congdung.Enabled = false;
            cbo_tinhtrang.Enabled = false;
            
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
        }

        public void un_locktext()
        {
            txt_giaban.Enabled = true;
            txt_congdung.Enabled = true;
            cbo_tinhtrang.Enabled = true;

            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
        }
        private int kiemtranull()
        {
            if (txt_congdung.Text == "")
                return 1;
            if (cbo_tinhtrang.Text == "")
                return 2;
            if (txt_giaban.Text == "")
                return 3;
            
            return 0;
        }
        public void khoitaoluoi()
        {
            dgv_ds1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds1.Columns[0].HeaderText = "Mã loại dược phẩm";
            dgv_ds1.Columns[0].Frozen = true;
            dgv_ds1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds1.Columns[0].Width = 150;
            dgv_ds1.Columns[1].HeaderText = "Mã thuốc khám";
            dgv_ds1.Columns[1].Width = 150;
            dgv_ds1.Columns[2].HeaderText = "Tên thuốc khám";
            dgv_ds1.Columns[2].Width = 150;
            dgv_ds1.Columns[3].HeaderText = "Công dụng";
            dgv_ds1.Columns[3].Width = 150;
            dgv_ds1.Columns[4].HeaderText = "Đơn vị";
            dgv_ds1.Columns[4].Width = 150;
            dgv_ds1.Columns[5].HeaderText = "Giá thuốc nhập";
            dgv_ds1.Columns[5].Width = 150;
            dgv_ds1.Columns[6].HeaderText = "Ngày nhập";
            dgv_ds1.Columns[6].Width = 150;
            dgv_ds1.Columns[7].HeaderText = "Tình trạng";
            dgv_ds1.Columns[7].Width = 150;
            dgv_ds1.Columns[8].HeaderText = "Giá thuốc bán";
            dgv_ds1.Columns[8].Width = 150;
            dgv_ds1.Columns[9].HeaderText = "Số lượng còn";
            dgv_ds1.Columns[9].Width = 150;

            dgv_ds2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds2.Columns[0].HeaderText = "Mã loại dược phẩm";
            dgv_ds2.Columns[0].Frozen = true;
            dgv_ds2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds2.Columns[0].Width = 150;
            dgv_ds2.Columns[1].HeaderText = "Mã thuốc khám";
            dgv_ds2.Columns[1].Width = 150;
            dgv_ds2.Columns[2].HeaderText = "Tên thuốc khám";
            dgv_ds2.Columns[2].Width = 150;
            dgv_ds2.Columns[3].HeaderText = "Công dụng";
            dgv_ds2.Columns[3].Width = 150;
            dgv_ds2.Columns[4].HeaderText = "Đơn vị";
            dgv_ds2.Columns[4].Width = 150;
            dgv_ds2.Columns[5].HeaderText = "Giá thuốc nhập";
            dgv_ds2.Columns[5].Width = 150;
            dgv_ds2.Columns[6].HeaderText = "Ngày nhập";
            dgv_ds2.Columns[6].Width = 150;
            dgv_ds2.Columns[7].HeaderText = "Tình trạng";
            dgv_ds2.Columns[7].Width = 150;
            dgv_ds2.Columns[8].HeaderText = "Giá thuốc bán";
            dgv_ds2.Columns[8].Width = 150;
            dgv_ds2.Columns[9].HeaderText = "Số lượng còn";
            dgv_ds2.Columns[9].Width = 150;

        }
        public void hienthi()
        {
            string sql1 = "SELECT MaLoaiDuocPham, MaThuocKham, TenThuocKham, CongDung, DonVi, GiaThuocNhap, NgayNhap, TinhTrangConSD, GiaThuocBan, SoLuongCon FROM dbo.THUOCKHAM where GiaThuocBan != 'null'";
            dgv_ds1.DataSource = cn.taobang(sql1);

            string sql2 = "SELECT MaLoaiDuocPham, MaThuocKham, TenThuocKham, CongDung, DonVi, GiaThuocNhap, NgayNhap, TinhTrangConSD, GiaThuocBan, SoLuongCon FROM dbo.THUOCKHAM where GiaThuocBan = 'null'";
            dgv_ds2.DataSource = cn.taobang(sql2);

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

        public void hienthi_timkiem1(string key)
        {
            string sql1 = "SELECT MaLoaiDuocPham, MaThuocKham, TenThuocKham, CongDung, DonVi, GiaThuocNhap, NgayNhap, TinhTrangConSD, GiaThuocBan, SoLuongCon FROM dbo.THUOCKHAM where MaThuocKham = '" + key + "'";
            dgv_ds1.DataSource = cn.taobang(sql1);
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
        public void hienthi_timkiem2(string key)
        {
            string sql2 = "SELECT MaLoaiDuocPham, MaThuocKham, TenThuocKham, CongDung, DonVi, GiaThuocNhap, NgayNhap, TinhTrangConSD, GiaThuocBan, SoLuongCon FROM dbo.THUOCKHAM where MaThuocKham = '" + key + "'";
            dgv_ds2.DataSource = cn.taobang(sql2);
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

        private void fr_thuockham_Load(object sender, EventArgs e)
        {
            thucthi.load_mathuockham(txt_search1);
            thucthi.load_mathuockham(txt_search2);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_congdung.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtranull();
            switch (key)
            {
                case 0:
                    {
                        if(txt_mathuoc.Text=="")
                        {
                            MessageBox.Show("Mục được chọn không thể cập nhật", "Chú Ý", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (themmoi != true)
                            {
                                try
                                {
                                    ck.MATHUOCKHAM = txt_mathuoc.Text;
                                    ck.CONGDUNG = txt_congdung.Text;
                                    ck.TINHTRANGCONSD = cbo_tinhtrang.Text;
                                    ck.GIATHUOCBAN = txt_giaban.Text;
                                    thucthi.sua(ck);

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            locktext();
                            hienthi();
                        }
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Công dụng thuốc khám không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_congdung.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Tình trạng còn sử dụng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_tinhtrang.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Giá thuốc bán không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_giaban.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void btn_search2_Click(object sender, EventArgs e)
        {
            hienthi_timkiem2(txt_search2.Text);
        }

        private void btn_search1_Click(object sender, EventArgs e)
        {
            hienthi_timkiem1(txt_search1.Text);
        }

        private void btn_hienthi1_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void btn_hienthi2_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dgv_ds2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if (dong != -1)
            {
                txt_maloaithuoc.Text = dgv_ds2.Rows[dong].Cells[0].Value.ToString();
                txt_tenloaithuoc.Text = thucthi.load_tenldp(txt_tenloaithuoc.Text, txt_maloaithuoc.Text);
                txt_mathuoc.Text = dgv_ds2.Rows[dong].Cells[1].Value.ToString();
                txt_tenthuoc.Text = dgv_ds2.Rows[dong].Cells[2].Value.ToString();
                txt_congdung.Text = dgv_ds2.Rows[dong].Cells[3].Value.ToString();
                txt_donvi.Text = dgv_ds2.Rows[dong].Cells[4].Value.ToString();
                txt_gianhap.Text = dgv_ds2.Rows[dong].Cells[5].Value.ToString();
                txt_ngaynhap.Text = dgv_ds2.Rows[dong].Cells[6].Value.ToString();
                cbo_tinhtrang.Text = dgv_ds2.Rows[dong].Cells[7].Value.ToString();
                txt_giaban.Text = dgv_ds2.Rows[dong].Cells[8].Value.ToString();
                txt_slcon.Text = dgv_ds2.Rows[dong].Cells[9].Value.ToString();
            }
            
            locktext();
        }

        private void dgv_ds1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if (dong != -1)
            {
                txt_maloaithuoc.Text = dgv_ds1.Rows[dong].Cells[0].Value.ToString();
                txt_tenloaithuoc.Text = thucthi.load_tenldp(txt_tenloaithuoc.Text, txt_maloaithuoc.Text);
                txt_mathuoc.Text = dgv_ds1.Rows[dong].Cells[1].Value.ToString();
                txt_tenthuoc.Text = dgv_ds1.Rows[dong].Cells[2].Value.ToString();
                txt_congdung.Text = dgv_ds1.Rows[dong].Cells[3].Value.ToString();
                txt_donvi.Text = dgv_ds1.Rows[dong].Cells[4].Value.ToString();
                txt_gianhap.Text = dgv_ds1.Rows[dong].Cells[5].Value.ToString();
                txt_ngaynhap.Text = dgv_ds1.Rows[dong].Cells[6].Value.ToString();
                cbo_tinhtrang.Text = dgv_ds1.Rows[dong].Cells[7].Value.ToString();
                txt_giaban.Text = dgv_ds1.Rows[dong].Cells[8].Value.ToString();
                txt_slcon.Text = dgv_ds1.Rows[dong].Cells[9].Value.ToString();
            }

            locktext();
        }

        private void txt_giaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
