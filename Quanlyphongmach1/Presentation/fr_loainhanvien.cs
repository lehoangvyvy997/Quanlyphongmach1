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
    public partial class fr_loainhanvien : Form
    {
        public fr_loainhanvien()
        {
            InitializeComponent();
        }

        E_tb_Loainhanvien thucthi = new E_tb_Loainhanvien();
        ConnectDB cn = new ConnectDB();
        EC_tb_Loainhanvien ck = new EC_tb_Loainhanvien();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txt_maloainhanvien.Text = "";
            txt_tenloainhanvien.Text = "";
        }

        public void locktext()
        {
            txt_maloainhanvien.Enabled = false;
            txt_tenloainhanvien.Enabled = false;
            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }

        public void un_locktext()
        {
            txt_maloainhanvien.Enabled = true;
            txt_tenloainhanvien.Enabled = true;
            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        public void khoitaoluoi()
        {
            dgv_dsloainhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloainhanvien.Columns[0].HeaderText = "Mã loại nhân viên";
            dgv_dsloainhanvien.Columns[0].Frozen = true;
            dgv_dsloainhanvien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloainhanvien.Columns[0].Width = 150;
            dgv_dsloainhanvien.Columns[1].HeaderText = "Tên loại nhân viên";
            dgv_dsloainhanvien.Columns[1].Width = 200;

        }
        public void hienthi()
        {
            string sql = "SELECT MaLoaiNhanVien, TenLoaiNhanVien FROM LOAINHANVIEN";
            dgv_dsloainhanvien.DataSource = cn.taobang(sql);
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

        private void fr_loainhanvien_Load(object sender, EventArgs e)
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
            txt_maloainhanvien.Enabled = true;
            txt_tenloainhanvien.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_maloainhanvien.Text != "" && txt_tenloainhanvien.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MALOAINHANVIEN = txt_maloainhanvien.Text;
                        ck.TENLOAINHANVIEN = txt_tenloainhanvien.Text;
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
                        ck.MALOAINHANVIEN = txt_maloainhanvien.Text;
                        ck.TENLOAINHANVIEN = txt_tenloainhanvien.Text;
                        thucthi.sualg(ck);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txt_maloainhanvien.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                if (txt_maloainhanvien.Text == "")
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_maloainhanvien.Focus();
                }
                if (txt_tenloainhanvien.Text == "")
                {
                    MessageBox.Show("Tên chức vụ Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_tenloainhanvien.Focus();
                }

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_maloainhanvien.Enabled = false;
            txt_tenloainhanvien.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MALOAINHANVIEN = txt_maloainhanvien.Text;

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

        private void dgv_dsloainhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txt_maloainhanvien.Text = dgv_dsloainhanvien.Rows[dong].Cells[0].Value.ToString();
            txt_tenloainhanvien.Text = dgv_dsloainhanvien.Rows[dong].Cells[1].Value.ToString();
            locktext();
        }
    }
}
