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
    public partial class fr_nhacungcap : Form
    {
        public fr_nhacungcap()
        {
            InitializeComponent();
        }

        E_tb_Nhacungcap thucthi = new E_tb_Nhacungcap();
        ConnectDB cn = new ConnectDB();
        EC_tb_Nhacungcap ck = new EC_tb_Nhacungcap();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_diachincc.Text = "";
            txt_mailncc.Text = "";
            txt_mancc.Text = "";
            txt_mathangcc.Text = "";
            txt_nganhang.Text = "";
            txt_sdtncc.Text = "";
            txt_stkncc.Text = "";
            txt_tenncc.Text = "";
            cbo_tinhtrang.Text = "Đang cung cấp";

        }

        public void locktext()
        {
            txt_tenncc.Enabled = false;
            txt_stkncc.Enabled = false;
            txt_sdtncc.Enabled = false;
            txt_nganhang.Enabled = false;
            txt_mathangcc.Enabled = false;
            txt_mancc.Enabled = false;
            txt_mailncc.Enabled = false;
            txt_diachincc.Enabled = false;
            cbo_tinhtrang.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }

        public void un_locktext()
        {
            txt_tenncc.Enabled = true;
            txt_stkncc.Enabled = true;
            txt_sdtncc.Enabled = true;
            txt_nganhang.Enabled = true;
            txt_mathangcc.Enabled = true;
            txt_mancc.Enabled = true;
            txt_mailncc.Enabled = true;
            txt_diachincc.Enabled = true;
            cbo_tinhtrang.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        public void khoitaoluoi()
        {
            dgv_dsncc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsncc.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgv_dsncc.Columns[0].Frozen = true;
            dgv_dsncc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsncc.Columns[0].Width = 150;
            dgv_dsncc.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgv_dsncc.Columns[1].Width = 150;
            dgv_dsncc.Columns[2].HeaderText = "Địa chỉ";
            dgv_dsncc.Columns[2].Width = 150;
            dgv_dsncc.Columns[3].HeaderText = "Số điện thoại";
            dgv_dsncc.Columns[3].Width = 150;
            dgv_dsncc.Columns[4].HeaderText = "Email";
            dgv_dsncc.Columns[4].Width = 150;
            dgv_dsncc.Columns[5].HeaderText = "Mặt hàng cung cấp";
            dgv_dsncc.Columns[5].Width = 150;
            dgv_dsncc.Columns[6].HeaderText = "Số tài khoản";
            dgv_dsncc.Columns[6].Width = 150;
            dgv_dsncc.Columns[7].HeaderText = "Ngân hàng";
            dgv_dsncc.Columns[7].Width = 150;
            dgv_dsncc.Columns[8].HeaderText = "Tình trạng cung cấp";
            dgv_dsncc.Columns[8].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email,MatHangCungCap,SoTaiKhoan,NganHang,TinhTrangCungCap FROM dbo.NHACUNGCAP";
            dgv_dsncc.DataSource = cn.taobang(sql);
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
        private void fr_nhacungcap_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txt_mancc.Enabled = true;
            txt_mancc.Focus();
        }
        private int kiemtraNull1()
        {
            if (txt_mancc.Text == "")
                return 1;
            if (txt_tenncc.Text == "")
                return 2;
            if (txt_diachincc.Text == "")
                return 3;
            if (txt_sdtncc.Text == "")
                return 4;
            if (txt_mailncc.Text == "")
                return 5;
            if (txt_mathangcc.Text == "")
                return 6;
            if (txt_stkncc.Text == "" && txt_nganhang.Text == "")
                return 7;
            if (txt_stkncc.Text != "" && txt_nganhang.Text == "")
                return 9;
            if (txt_stkncc.Text == "" && txt_nganhang.Text != "")
                return 8;
            if (cbo_tinhtrang.Text == "")
                return 10;

            return 0;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtraNull1();

            switch (key)
            {
                case 0:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MANHACUNGCAP = txt_mancc.Text;
                                ck.TENNHANCUNGCAP = txt_tenncc.Text;
                                ck.DIACHI = txt_diachincc.Text;
                                ck.SDT = txt_sdtncc.Text;
                                ck.EMAIL = txt_mailncc.Text;
                                ck.MATHANGCC = txt_mathangcc.Text;
                                ck.SOTAIKHOAN = txt_stkncc.Text;
                                ck.NGANHANG = txt_nganhang.Text;
                                ck.TINHTRANG = cbo_tinhtrang.Text;

                                thucthi.themoilg(ck);
                                locktext();
                                hienthi();
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MANHACUNGCAP = txt_mancc.Text;
                                ck.TENNHANCUNGCAP = txt_tenncc.Text;
                                ck.DIACHI = txt_diachincc.Text;
                                ck.SDT = txt_sdtncc.Text;
                                ck.EMAIL = txt_mailncc.Text;
                                ck.MATHANGCC = txt_mathangcc.Text;
                                ck.SOTAIKHOAN = txt_stkncc.Text;
                                ck.NGANHANG = txt_nganhang.Text;
                                ck.TINHTRANG = cbo_tinhtrang.Text;

                                thucthi.sualg(ck);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txt_mancc.Enabled = true;
                        locktext();
                        hienthi();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_mancc.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Tên nhà cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_tenncc.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Địa chỉ nhà cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_diachincc.Focus();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Số điện thoại nhà cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_sdtncc.Focus();
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show("E-mail nhà cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_mailncc.Focus();
                        break;
                    }
                case 6:
                    {
                        MessageBox.Show("Tên mặt hàng cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_mathangcc.Focus();
                        break;
                    }
                case 7:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MANHACUNGCAP = txt_mancc.Text;
                                ck.TENNHANCUNGCAP = txt_tenncc.Text;
                                ck.DIACHI = txt_diachincc.Text;
                                ck.SDT = txt_sdtncc.Text;
                                ck.EMAIL = txt_mailncc.Text;
                                ck.MATHANGCC = txt_mathangcc.Text;
                                ck.SOTAIKHOAN = "null";
                                ck.NGANHANG = "null";
                                ck.TINHTRANG = cbo_tinhtrang.Text;

                                thucthi.themoilg(ck);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MANHACUNGCAP = txt_mancc.Text;
                                ck.TENNHANCUNGCAP = txt_tenncc.Text;
                                ck.DIACHI = txt_diachincc.Text;
                                ck.SDT = txt_sdtncc.Text;
                                ck.EMAIL = txt_mailncc.Text;
                                ck.MATHANGCC = txt_mathangcc.Text;
                                ck.SOTAIKHOAN = "null";
                                ck.NGANHANG = "null";
                                ck.TINHTRANG = cbo_tinhtrang.Text;

                                thucthi.sualg(ck);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txt_mancc.Enabled = true;
                        locktext();
                        hienthi();
                        break;
                    }
                case 8:
                    {
                        MessageBox.Show("Bổ sung số tài khoản của nhà cung cấp", "Chú Ý", MessageBoxButtons.OK);
                        txt_stkncc.Focus();
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show("Bổ sung tên ngân hàng của nhà cung cấp", "Chú Ý", MessageBoxButtons.OK);
                        txt_nganhang.Focus();
                        break;
                    }
                case 10:
                    {
                        MessageBox.Show("Tình trạng cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_tinhtrang.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_mancc.Enabled = false;
            txt_tenncc.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MANHACUNGCAP = txt_mancc.Text;

                    thucthi.xoalg(ck);
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

        private void dgv_dsncc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            
            if(dong!=-1)
            {
                txt_mancc.Text = dgv_dsncc.Rows[dong].Cells[0].Value.ToString();
                txt_tenncc.Text = dgv_dsncc.Rows[dong].Cells[1].Value.ToString();
                txt_diachincc.Text = dgv_dsncc.Rows[dong].Cells[2].Value.ToString();
                txt_sdtncc.Text = dgv_dsncc.Rows[dong].Cells[3].Value.ToString();
                txt_mailncc.Text = dgv_dsncc.Rows[dong].Cells[4].Value.ToString();
                txt_mathangcc.Text = dgv_dsncc.Rows[dong].Cells[5].Value.ToString();
                txt_stkncc.Text = dgv_dsncc.Rows[dong].Cells[6].Value.ToString();
                txt_nganhang.Text = dgv_dsncc.Rows[dong].Cells[7].Value.ToString();
                cbo_tinhtrang.Text = dgv_dsncc.Rows[dong].Cells[8].Value.ToString();
            }

            locktext();
        }
    }
}
