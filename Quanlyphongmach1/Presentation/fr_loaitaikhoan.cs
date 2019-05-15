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
    public partial class fr_loaitaikhoan : Form
    {
        public fr_loaitaikhoan()
        {
            InitializeComponent();
        }

        E_tb_Loaitaikhoan thucthi = new E_tb_Loaitaikhoan();
        ConnectDB cn = new ConnectDB();
        EC_tb_Loaitaikhoan ck = new EC_tb_Loaitaikhoan();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_maloaitk.Text = "";
            txt_tenloaitk.Text = "";
        }
        public void locktext()
        {
            txt_maloaitk.Enabled = false;
            txt_tenloaitk.Enabled = false;
            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }
        public void un_locktext()
        {
            txt_maloaitk.Enabled = true;
            txt_tenloaitk.Enabled = true;
            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_dsloaitk.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloaitk.Columns[0].HeaderText = "Mã loại tài khoản";
            dgv_dsloaitk.Columns[0].Frozen = true;
            dgv_dsloaitk.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloaitk.Columns[0].Width = 150;
            dgv_dsloaitk.Columns[1].HeaderText = "Tên loại tài khoản";
            dgv_dsloaitk.Columns[1].Width = 200;

        }
        public void hienthi()
        {
            string sql = "SELECT MaLoaiTaiKhoan, TenLoaiTaiKhoan FROM LOAITAIKHOAN";
            dgv_dsloaitk.DataSource = cn.taobang(sql);
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

        private void fr_loaitaikhoan_Load(object sender, EventArgs e)
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
            txt_maloaitk.Enabled = true;
            txt_maloaitk.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_maloaitk.Text != "" && txt_tenloaitk.Text!="")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MALOAITAIKHOAN = txt_maloaitk.Text;
                        ck.TENLOAITAIKHOAN = txt_tenloaitk.Text;
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
                        ck.MALOAITAIKHOAN = txt_maloaitk.Text;
                        ck.TENLOAITAIKHOAN = txt_tenloaitk.Text;
                        thucthi.sualg(ck);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txt_maloaitk.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                if (txt_maloaitk.Text == "")
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_maloaitk.Focus();
                }
                if (txt_tenloaitk.Text == "")
                {
                    MessageBox.Show("Tên loại tài khoản Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_tenloaitk.Focus();
                }
                
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_maloaitk.Enabled = false;
            txt_tenloaitk.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MALOAITAIKHOAN = txt_maloaitk.Text;

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

        private void dgv_dsloaitk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txt_maloaitk.Text = dgv_dsloaitk.Rows[dong].Cells[0].Value.ToString();
            txt_tenloaitk.Text = dgv_dsloaitk.Rows[dong].Cells[1].Value.ToString();
            locktext();
        }
    }
}
