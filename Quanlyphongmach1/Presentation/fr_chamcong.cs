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
    public partial class fr_chamcong : Form
    {
        public fr_chamcong()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();
        EC_tb_Chamcong ck = new EC_tb_Chamcong();
        E_tb_Chamcong thucthi = new E_tb_Chamcong();

        
        int dong = 0;

        private void setnull()
        {
            txt_chucvu.Text = "";
            txt_gioitinh.Text = "";
            txt_hoten.Text = "";
            txt_loaiNV.Text = "";
            txt_mail.Text = "";
            txt_maNV.Text = ""; ;
            txt_ngaysinh.Text = "";
            txt_phongkham.Text = "";
            txt_sdt.Text = "";
            txt_tinhtrang.Text = "";

            txt_ma.Text = "";
            dtm_ngay.Text = "";
            cbo_tinhtrang.Text = "";
        }

        private void locktext()
        {
            cbo_tinhtrang.Enabled = false;
            btn_luu.Enabled = false;
        }
        private void un_locktext()
        {
            cbo_tinhtrang.Enabled = true;
            btn_luu.Enabled = true;
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã nhân viên";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 100;
            dgv_ds.Columns[1].HeaderText = "Họ tên nhân viên";
            dgv_ds.Columns[1].Width = 200;
            dgv_ds.Columns[2].HeaderText = "Ngày sinh";
            dgv_ds.Columns[2].Width = 100;
            dgv_ds.Columns[3].HeaderText = "Giới tính";
            dgv_ds.Columns[3].Width = 70;
            dgv_ds.Columns[4].HeaderText = "Số điện thoại";
            dgv_ds.Columns[4].Width = 100;
            dgv_ds.Columns[5].HeaderText = "Email";
            dgv_ds.Columns[5].Width = 150;
            dgv_ds.Columns[6].HeaderText = "Mã loại nhân viên";
            dgv_ds.Columns[6].Width = 70;
            dgv_ds.Columns[7].HeaderText = "Mã chức vụ";
            dgv_ds.Columns[7].Width = 70;
            dgv_ds.Columns[8].HeaderText = "Mã tình trạng làm việc";
            dgv_ds.Columns[8].Width = 70;
            dgv_ds.Columns[9].HeaderText = "Mã Phòng khám";
            dgv_ds.Columns[9].Width = 90;

        }
        public void hienthi()
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01'";
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
        public string timkiem()
        {
            string sql;
            string maCV = cn.LoadLable("SELECT MaChucVu FROM dbo.CHUCVU WHERE TenChucVu = N'" + cbo_srhchuc.Text + "'");
            string maLoai = cn.LoadLable("SELECT MaLoaiNhanVien FROM dbo.LOAINHANVIEN WHERE TenLoaiNhanVien = N'" + cbo_srhloai.Text + "'");
            string maPhong = cn.LoadLable("SELECT MaPhongKham FROM dbo.PHONGKHAM WHERE TenPhongKham = N'" + cbo_srhphong.Text + "'");
            // Tên + 3
            if (txt_srhten.Text!=""&&cbo_srhchuc.Text!=""&&cbo_srhloai.Text!=""&&cbo_srhphong.Text!="")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaLoaiNhanVien = '" + maLoai + "'AND MaChucVu = '" + maCV + "'AND MaPhongKham = '" + maPhong + "'";
                return sql;
            }
            // tên + 2
            if (txt_srhten.Text != "" && cbo_srhchuc.Text == "" && cbo_srhloai.Text != "" && cbo_srhphong.Text != "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaLoaiNhanVien = '" + maLoai + "'AND MaPhongKham = '" + maPhong + "'";
                return sql;
            }
            if (txt_srhten.Text != "" && cbo_srhchuc.Text != "" && cbo_srhloai.Text == "" && cbo_srhphong.Text != "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaChucVu = '" + maCV + "'AND MaPhongKham = '" + maPhong + "'";
                return sql;
            }
            if (txt_srhten.Text != "" && cbo_srhchuc.Text != "" && cbo_srhloai.Text != "" && cbo_srhphong.Text == "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaLoaiNhanVien = '" + maLoai + "'AND MaChucVu = '" + maCV + "'";
                return sql;
            }
            // tên + 1
            if (txt_srhten.Text != "" && cbo_srhchuc.Text == "" && cbo_srhloai.Text == "" && cbo_srhphong.Text != "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "'AND MaPhongKham = '" + maPhong + "'";
                return sql;
            }
            if (txt_srhten.Text != "" && cbo_srhchuc.Text != "" && cbo_srhloai.Text == "" && cbo_srhphong.Text == "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaChucVu = '" + maCV + "'";
                return sql;
            }
            if (txt_srhten.Text != "" && cbo_srhchuc.Text == "" && cbo_srhloai.Text != "" && cbo_srhphong.Text == "")
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "' AND MaLoaiNhanVien = '" + maLoai + "'";
                return sql;
            }
            return "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN WHERE MaTTLV = 'TTLV01' AND TenNhanVien = N'" + txt_srhten.Text + "'";
                
        }
        public void hienthi_search()
        {
            string sql = timkiem();
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

        private void fr_chamcong_Load(object sender, EventArgs e)
        {
            thucthi.load_cboChuc(cbo_srhchuc);
            thucthi.load_cboLoai(cbo_srhloai);
            thucthi.load_cboPhong(cbo_srhphong);
            thucthi.load_tenNVSearch(txt_srhten);
            
            
            hienthi();
            khoitaoluoi();
            setnull();
            locktext();
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                txt_maNV.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_hoten.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
                txt_ngaysinh.Text = dgv_ds.Rows[dong].Cells[2].Value.ToString();
                txt_gioitinh.Text = dgv_ds.Rows[dong].Cells[3].Value.ToString();
                txt_sdt.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
                txt_mail.Text = dgv_ds.Rows[dong].Cells[5].Value.ToString();
                txt_tinhtrang.Text = "Đang làm việc";
                txt_loaiNV.Text = thucthi.load_tenloaiNV(thucthi.load_maloaiNV(txt_maNV.Text));
                txt_chucvu.Text = thucthi.load_tenCV(thucthi.load_maCV(txt_maNV.Text));
                txt_phongkham.Text = thucthi.load_tenPGKH(thucthi.load_maPGKH(txt_maNV.Text));
            }
        }

        private void btn_srhhien_Click(object sender, EventArgs e)
        {
            hienthi();
            locktext();
            setnull();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(txt_srhten.Text=="")
            {
                MessageBox.Show("Tên nhân viên bắt buộc phải nhập!", "Chú Ý", MessageBoxButtons.OK);
                txt_srhten.Focus();
            }
            else
            {
                hienthi_search();
            }
        }

        private void txt_maNV_TextChanged(object sender, EventArgs e)
        {
            un_locktext();
            DateTime date = DateTime.Now;
            string d1, d2, d3;
            int val = thucthi.demsoChamcong_inday(date) + 1;
            // d1
            if (date.Day < 10)
                d1 = "0" + date.Day.ToString();
            else
                d1 = date.Day.ToString();
            if (date.Month < 10)
                d2 = "0" + date.Month.ToString();
            else
                d2 = date.Month.ToString();
            // d3
            if (val < 10)
                d3 = "#00" + val.ToString();
            else
            {
                if (val < 100)
                    d3 = "#0" + val.ToString();
                else
                {
                    d3 = "#" + val.ToString();
                }
            }
            txt_ma.Text = d1 + d2 + date.Year.ToString() + "CC" + d3;
            btn_luu.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(cbo_tinhtrang.Text=="")
            {
                MessageBox.Show("Tình trạng nghỉ phép không được để trống!", "Chú Ý", MessageBoxButtons.OK);
                cbo_tinhtrang.Focus();
            }
            else
            {
                if(!thucthi.kiemtra_tontai(txt_maNV.Text, DateTime.Now))
                {
                    try
                    {
                        ck.MACHAMCONG = txt_ma.Text;
                        ck.MANHANVIEN = txt_maNV.Text;
                        ck.NGAYCHAMCONG = dtm_ngay.Text;
                        ck.NGHICOPHEP = cbo_tinhtrang.Text;

                        thucthi.themmoi(ck);
                        setnull();
                        locktext();
                        hienthi();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên này đã được chấm công trong ngày!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hienthi();
                    setnull();
                    locktext();
                }
            }
        }
    }
}
