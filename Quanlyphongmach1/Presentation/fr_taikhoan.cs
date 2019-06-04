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
    public partial class fr_taikhoan : Form
    {
        public fr_taikhoan()
        {
            InitializeComponent();
        }

        E_tb_Taikhoan thucthi = new E_tb_Taikhoan();
        ConnectDB cn = new ConnectDB();
        EC_tb_Taikhoan ck = new EC_tb_Taikhoan();
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
            txt_username.Text = "";
            cbo_maloaitk.Text = "";
            txt_tenloaitk.Text = "";
            cbo_manhanvien.Text = "";
            txt_tennhanvien.Text = "";
            txt_password1.Text = "";
            txt_cfpassword1.Text = "";
            txt_password2.Text = "";
            txt_cfpassword2.Text = "";
        }
        public void locktext()
        {
            txt_username.Enabled = false;
            cbo_maloaitk.Enabled = false;
            txt_tenloaitk.Enabled = false;
            cbo_manhanvien.Enabled = false;
            txt_tennhanvien.Enabled = false;
            txt_password1.Enabled = false;
            txt_cfpassword1.Enabled = false;
            txt_password2.Enabled = false;
            txt_cfpassword2.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }
        public void un_locktext()
        {
            txt_username.Enabled = true;
            cbo_maloaitk.Enabled = true;
            txt_tenloaitk.Enabled = true;
            cbo_manhanvien.Enabled = true;
            txt_tennhanvien.Enabled = true;
            txt_password1.Enabled = true;
            txt_cfpassword1.Enabled = true;
            txt_password2.Enabled = true;
            txt_cfpassword2.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public void khoitaoluoi()
        {
            dgv_dstaikhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dstaikhoan.Columns[0].HeaderText = "Tên đăng nhập";
            dgv_dstaikhoan.Columns[0].Frozen = true;
            dgv_dstaikhoan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dstaikhoan.Columns[0].Width = 150;
            dgv_dstaikhoan.Columns[1].HeaderText = "Mã Loại Tài Khoản";
            dgv_dstaikhoan.Columns[1].Width = 150;
            dgv_dstaikhoan.Columns[2].HeaderText = "Mã Nhân Viên";
            dgv_dstaikhoan.Columns[2].Width = 150;
            dgv_dstaikhoan.Columns[3].HeaderText = "Password cấp 1";
            dgv_dstaikhoan.Columns[3].Width = 150;
            dgv_dstaikhoan.Columns[4].HeaderText = "Password cấp 2";
            dgv_dstaikhoan.Columns[4].Width = 150;
            
            
        }
        public void hienthi()
        {
            string sql = "SELECT Username, MaLoaiTaiKhoan, MaNhanVien, Password1, Password2 FROM dbo.TAIKHOAN";
            dgv_dstaikhoan.DataSource = cn.taobang(sql);
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
            txt_username.Enabled = true;
            txt_username.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_username.Text != "")
            {
                if (cbo_maloaitk.Text != "")
                {
                    if (themmoi == true)
                    {
                        if (txt_password1.Text != txt_cfpassword1.Text)
                        {
                            MessageBox.Show("Xác nhận mật khẩu cấp 1 chưa đúng", "Chú Ý", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (txt_password2.Text != txt_cfpassword2.Text)
                            {
                                MessageBox.Show("Xác nhận mật khẩu cấp 2 chưa đúng", "Chú Ý", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    ck.USERNAME = txt_username.Text;
                                    ck.MALOAITAIKHOAN = cbo_maloaitk.Text;
                                    ck.MANHANVIEN = cbo_manhanvien.Text;
                                    ck.PASSWORD1 = txt_password1.Text;
                                    ck.PASSWORD2 = txt_password2.Text;

                                    if (cbo_manhanvien.Text == "")
                                    {
                                        thucthi.themoitk2(ck);
                                    }
                                    else
                                    {
                                        thucthi.themoitk1(ck);
                                    }

                                    locktext();
                                    hienthi();
                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txt_password1.Text != txt_cfpassword1.Text)
                        {
                            MessageBox.Show("Xác nhận mật khẩu cấp 1 chưa đúng", "Chú Ý", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (txt_password2.Text != txt_cfpassword2.Text)
                            {
                                MessageBox.Show("Xác nhận mật khẩu cấp 2 chưa đúng", "Chú Ý", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    ck.USERNAME = txt_username.Text;
                                    ck.MALOAITAIKHOAN = cbo_maloaitk.Text;
                                    ck.MANHANVIEN = cbo_manhanvien.Text;
                                    ck.PASSWORD1 = txt_password1.Text;
                                    ck.PASSWORD2 = txt_password2.Text;

                                    if (cbo_manhanvien.Text == "")
                                    {
                                        thucthi.suatk2(ck);
                                    }
                                    else
                                    {
                                        thucthi.suatk1(ck);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    txt_username.Enabled = true;
                    locktext();
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbo_manhanvien.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txt_username.Focus();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_username.Enabled = false;
            txt_password1.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.USERNAME = txt_username.Text;

                    thucthi.xoatk(ck);
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

        private void fr_taikhoan_Load(object sender, EventArgs e)
        {
            thucthi.loadmaloaitk(cbo_maloaitk);
            thucthi.loadnhanvien(cbo_manhanvien);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void dgv_dstaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            
            if(dong!=-1)
            {
                txt_username.Text = dgv_dstaikhoan.Rows[dong].Cells[0].Value.ToString();
                cbo_maloaitk.Text = dgv_dstaikhoan.Rows[dong].Cells[1].Value.ToString();
                cbo_manhanvien.Text = dgv_dstaikhoan.Rows[dong].Cells[2].Value.ToString();
                txt_password1.Text = dgv_dstaikhoan.Rows[dong].Cells[3].Value.ToString();
                txt_password2.Text = dgv_dstaikhoan.Rows[dong].Cells[4].Value.ToString();
                //cbmaque.Text = msds.Rows[dong].Cells[5].Value.ToString();
                //txtdt.Text = msds.Rows[dong].Cells[6].Value.ToString();
            }

            locktext();
        }

        private void cbo_maloaitk_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tenloaitk.Text = thucthi.loadtenloaitk(txt_tenloaitk.Text, cbo_maloaitk.Text);
        }

        private void cbo_manhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tennhanvien.Text = thucthi.loadtennhanvien(txt_tennhanvien.Text, cbo_manhanvien.Text);
        }

        private void btn_themloaiTK_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_loaitaikhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_loaitaikhoan fr = new fr_loaitaikhoan();
                fr.ShowDialog();
            }
        }

        private void fr_taikhoan_Activated(object sender, EventArgs e)
        {
            thucthi.loadmaloaitk(cbo_maloaitk);
            thucthi.loadnhanvien(cbo_manhanvien);
        }
    }
}
