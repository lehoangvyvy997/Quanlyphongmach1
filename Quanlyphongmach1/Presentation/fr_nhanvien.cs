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
    public partial class fr_nhanvien : Form
    {
        public fr_nhanvien()
        {
            InitializeComponent();
        }

        E_tb_Nhanvien thucthi = new E_tb_Nhanvien();
        ConnectDB cn = new ConnectDB();
        EC_tb_Nhanvien ck = new EC_tb_Nhanvien();
        bool themmoi;
        int dong = 0;

        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        public void setnull()
        {
            
            txt_manhanvien.Text = "";
            cbo_maloainhanvien.Text = "";
            lb_tenloainv.Text = "-----";
            cbo_machucvu.Text = "";
            lb_tenchucvu.Text = "-----";
            cbo_matinhtrang.Text = "";
            lb_tentinhtrang.Text = "-----";
            cbo_maphongkham.Text = "";
            lb_tenphongkham.Text = "-----";
            txt_hotennhanvien.Text = "";
            dtm_ngaysinh.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbo_gioitinh.Text = "Nam";
            txt_sdt.Text = "";
            txt_email.Text = "@gmail.com";
            dtm_ngayvaolam.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_tienluong.Text = "0";
            txt_tientrocap.Text = "0";
            txt_tienthuong.Text = "0";
        }
        public void locktext()
        {
            txt_manhanvien.Enabled = false;
            cbo_maloainhanvien.Enabled = false;
            cbo_machucvu.Enabled = false;
            cbo_matinhtrang.Enabled = false;
            cbo_maphongkham.Enabled = false;
            txt_hotennhanvien.Enabled = false;
            dtm_ngaysinh.Enabled = false;
            cbo_gioitinh.Enabled = false;
            txt_sdt.Enabled = false;
            txt_email.Enabled = false;
            dtm_ngayvaolam.Enabled = false;
            txt_tienluong.Enabled = false;
            txt_tientrocap.Enabled = false;
            txt_tienthuong.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }
        public void un_locktext()
        {
            txt_manhanvien.Enabled = true;
            cbo_maloainhanvien.Enabled = true;
            cbo_machucvu.Enabled = true;
            cbo_matinhtrang.Enabled = true;
            cbo_maphongkham.Enabled = true;

            txt_hotennhanvien.Enabled = true;
            dtm_ngaysinh.Enabled = true;
            cbo_gioitinh.Enabled = true;
            txt_sdt.Enabled = true;
            txt_email.Enabled = true;
            dtm_ngayvaolam.Enabled = true;
            txt_tienluong.Enabled = true;
            txt_tientrocap.Enabled = true;
            txt_tienthuong.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        public void khoitaoluoi()
        {
            dgv_dsnhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgv_dsnhanvien.Columns[0].Frozen = true;
            dgv_dsnhanvien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsnhanvien.Columns[0].Width = 150;
            dgv_dsnhanvien.Columns[1].HeaderText = "Họ tên nhân viên";
            dgv_dsnhanvien.Columns[1].Width = 150;
            dgv_dsnhanvien.Columns[2].HeaderText = "Số điện thoại";
            dgv_dsnhanvien.Columns[2].Width = 150;
            dgv_dsnhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgv_dsnhanvien.Columns[3].Width = 150;
            dgv_dsnhanvien.Columns[4].HeaderText = "Tiền lương";
            dgv_dsnhanvien.Columns[4].Width = 150;
            dgv_dsnhanvien.Columns[5].HeaderText = "Tiền trợ cấp";
            dgv_dsnhanvien.Columns[5].Width = 150;
            dgv_dsnhanvien.Columns[6].HeaderText = "Tiền thưởng";
            dgv_dsnhanvien.Columns[6].Width = 150;
            dgv_dsnhanvien.Columns[7].HeaderText = "Ngày vào làm";
            dgv_dsnhanvien.Columns[7].Width = 150;
            dgv_dsnhanvien.Columns[8].HeaderText = "Giới tính";
            dgv_dsnhanvien.Columns[8].Width = 150;
            dgv_dsnhanvien.Columns[9].HeaderText = "Email";
            dgv_dsnhanvien.Columns[9].Width = 150;
            dgv_dsnhanvien.Columns[10].HeaderText = "Mã loại nhân viên";
            dgv_dsnhanvien.Columns[10].Width = 150;
            dgv_dsnhanvien.Columns[11].HeaderText = "Mã chức vụ";
            dgv_dsnhanvien.Columns[11].Width = 150;
            dgv_dsnhanvien.Columns[12].HeaderText = "Mã tình trạng làm việc";
            dgv_dsnhanvien.Columns[12].Width = 150;
            dgv_dsnhanvien.Columns[13].HeaderText = "Mã Phòng khám";
            dgv_dsnhanvien.Columns[13].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, TienLuong, TienTroCap, TienThuong, NgayVaoLam, GioiTinh, Email, MaLoaiNhanVien, MaChucVu, MaTTLV, MaPhongKham FROM dbo.NHANVIEN";
            dgv_dsnhanvien.DataSource = cn.taobang(sql);
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

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txt_manhanvien.Enabled = true;
            txt_manhanvien.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_manhanvien.Text != "")
            {
                if (cbo_maloainhanvien.Text != "")
                {
                    if (cbo_machucvu.Text != "")
                    {
                        if (cbo_matinhtrang.Text != "")
                        {
                            if (txt_hotennhanvien.Text == "" || cbo_gioitinh.Text == "" || txt_sdt.Text == "" || txt_email.Text == "" || txt_tienluong.Text == "" || txt_tienthuong.Text == "" || txt_tientrocap.Text == "")
                            {
                                MessageBox.Show("Các trường dữ liệu không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            }
                            else
                            {
 // Bắt đầu xử lý lưu
                                if (themmoi == true)
                                {
                                    try
                                    {
                                        ck.MAHNHANVIEN = txt_manhanvien.Text;
                                        ck.MALOAINHANVIEN = cbo_maloainhanvien.Text;
                                        ck.MACHUCVU = cbo_machucvu.Text;
                                        ck.MATTLV = cbo_matinhtrang.Text;
                                        ck.MAPHONGKHAM = cbo_maphongkham.Text;
                                        ck.TENNHANVIEN = txt_hotennhanvien.Text;
                                        ck.NGAYSINH = dtm_ngaysinh.Value.ToString();
                                        ck.GIOITINH = cbo_gioitinh.Text;
                                        ck.SDT = txt_sdt.Text;
                                        ck.EMAIL = txt_email.Text;
                                        ck.NGAYVAOLAM = dtm_ngayvaolam.Value.ToString();
                                        ck.TIENLUONG = txt_tienluong.Text;
                                        ck.TIENTROCAP = txt_tientrocap.Text;
                                        ck.TIENTHUONG = txt_tienthuong.Text;

                                        thucthi.themoinv(ck);
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
                                    try
                                    {
                                        ck.MAHNHANVIEN = txt_manhanvien.Text;
                                        ck.MALOAINHANVIEN = cbo_maloainhanvien.Text;
                                        ck.MACHUCVU = cbo_machucvu.Text;
                                        ck.MATTLV = cbo_matinhtrang.Text;
                                        ck.MAPHONGKHAM = cbo_maphongkham.Text;
                                        ck.TENNHANVIEN = txt_hotennhanvien.Text;
                                        ck.NGAYSINH = dtm_ngaysinh.Value.ToString();
                                        ck.GIOITINH = cbo_gioitinh.Text;
                                        ck.SDT = txt_sdt.Text;
                                        ck.EMAIL = txt_email.Text;
                                        ck.NGAYVAOLAM = dtm_ngayvaolam.Value.ToString();
                                        ck.TIENLUONG = txt_tienluong.Text;
                                        ck.TIENTROCAP = txt_tientrocap.Text;
                                        ck.TIENTHUONG = txt_tienthuong.Text;

                                        thucthi.suanv(ck);//
                                        
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                txt_manhanvien.Enabled = true;
                                locktext();
                                hienthi();
                            }
                        
                        }
                        else
                        {
                            MessageBox.Show("Mã tình trạng làm việc không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbo_maloainhanvien.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã chức vụ không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_maloainhanvien.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã loại nhân viên được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbo_maloainhanvien.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên hông được để trống", "Chú Ý", MessageBoxButtons.OK);
                txt_manhanvien.Focus();
            }
        }
        
        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_manhanvien.Enabled = false;
            txt_hotennhanvien.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MAHNHANVIEN = txt_manhanvien.Text;

                    thucthi.xoanv(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void fr_nhanvien_Load(object sender, EventArgs e)
        {
            thucthi.loadmapk(cbo_maphongkham);
            thucthi.loadmaloainv(cbo_maloainhanvien);
            thucthi.loadmachucvu(cbo_machucvu);
            thucthi.loadmattlv(cbo_matinhtrang);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void dgv_dsnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            txt_manhanvien.Text = dgv_dsnhanvien.Rows[dong].Cells[0].Value.ToString();
            cbo_maloainhanvien.Text = dgv_dsnhanvien.Rows[dong].Cells[10].Value.ToString();
            //lb_tenloainv.Text = "-----";
            cbo_machucvu.Text = dgv_dsnhanvien.Rows[dong].Cells[11].Value.ToString();
            //lb_tenchucvu.Text = "-----";
            cbo_matinhtrang.Text = dgv_dsnhanvien.Rows[dong].Cells[12].Value.ToString();
            //lb_tentinhtrang.Text = "-----";
            txt_hotennhanvien.Text = dgv_dsnhanvien.Rows[dong].Cells[1].Value.ToString();
            dtm_ngaysinh.Text = dgv_dsnhanvien.Rows[dong].Cells[3].Value.ToString();
            cbo_gioitinh.Text = dgv_dsnhanvien.Rows[dong].Cells[8].Value.ToString();
            //
            txt_sdt.Text = dgv_dsnhanvien.Rows[dong].Cells[2].Value.ToString();
            //
            txt_email.Text = dgv_dsnhanvien.Rows[dong].Cells[9].Value.ToString();
            dtm_ngayvaolam.Text = dgv_dsnhanvien.Rows[dong].Cells[7].Value.ToString();
            txt_tienluong.Text = dgv_dsnhanvien.Rows[dong].Cells[4].Value.ToString();
            txt_tientrocap.Text = dgv_dsnhanvien.Rows[dong].Cells[5].Value.ToString();
            txt_tienthuong.Text = dgv_dsnhanvien.Rows[dong].Cells[6].Value.ToString();
            cbo_maphongkham.Text= dgv_dsnhanvien.Rows[dong].Cells[13].Value.ToString();
            locktext();
        }

        private void cbo_maloainhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_tenloainv.Text = thucthi.loadtenloainv(lb_tenloainv.Text, cbo_maloainhanvien.Text);
        }

        private void cbo_machucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_tenchucvu.Text = thucthi.loadtenchucvu(lb_tenchucvu.Text, cbo_machucvu.Text);
        }

        private void cbo_matinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_tentinhtrang.Text = thucthi.loadtenttlv(lb_tentinhtrang.Text, cbo_matinhtrang.Text);
        }
        private void cbo_maphongkham_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_tenphongkham.Text = thucthi.loadtenpk(lb_tenphongkham.Text, cbo_maphongkham.Text);
        }
        private void btn_themloainhanvien_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_loainhanvien));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_loainhanvien fr = new fr_loainhanvien();
                fr.ShowDialog();
            }
        }

        private void btn_themchucvu_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chucvu));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chucvu fr = new fr_chucvu();
                fr.ShowDialog();
            }
        }

        private void btn_themtinhtrang_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_tinhtranglamviec));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_tinhtranglamviec fr = new fr_tinhtranglamviec();
                fr.ShowDialog();
            }
        }

        private void fr_nhanvien_Activated(object sender, EventArgs e)
        {
            
            thucthi.loadmaloainv(cbo_maloainhanvien);
            thucthi.loadmachucvu(cbo_machucvu);
            thucthi.loadmattlv(cbo_matinhtrang);
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_tienluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_tientrocap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_tienthuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
    }
}
