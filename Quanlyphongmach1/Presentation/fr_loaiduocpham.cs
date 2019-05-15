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
    public partial class fr_loaiduocpham : Form
    {
        public fr_loaiduocpham()
        {
            InitializeComponent();
        }
        E_tb_Loaiduocpham thucthi = new E_tb_Loaiduocpham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Loaiduocpham ck = new EC_tb_Loaiduocpham();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_ma.Text = "";
            txt_ten.Text = "";
        }
        public void locktext()
        {
            txt_ma.Enabled = false;
            txt_ten.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }

        public void un_locktext()
        {
            txt_ma.Enabled = true;
            txt_ten.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        public void khoitaoluoi()
        {
            dgv_dsloiduocpham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloiduocpham.Columns[0].HeaderText = "Mã loại dược phẩm";
            dgv_dsloiduocpham.Columns[0].Frozen = true;
            dgv_dsloiduocpham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsloiduocpham.Columns[0].Width = 150;
            dgv_dsloiduocpham.Columns[1].HeaderText = "Tên loại dược phẩm";
            dgv_dsloiduocpham.Columns[1].Width = 200;

        }

        public void hienthi()
        {
            string sql = "SELECT MaLoaiDuocPham, TenLoaiDuocPham FROM LOAIDUOCPHAM";
            dgv_dsloiduocpham.DataSource = cn.taobang(sql);
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



        private void fr_loaiduocpham_Load(object sender, EventArgs e)
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
            txt_ma.Enabled = true;
            txt_ma.Focus();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_ma.Enabled = false;
            txt_ten.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MALOAIDUOCPHAM = txt_ma.Text;

                    thucthi.xoa(ck);
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

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text != "" && txt_ten.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MALOAIDUOCPHAM = txt_ma.Text;
                        ck.TENLOAIDUOCPHAM = txt_ten.Text;

                        thucthi.themoi(ck);
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
                        ck.MALOAIDUOCPHAM = txt_ma.Text;
                        ck.TENLOAIDUOCPHAM = txt_ten.Text;

                        thucthi.sua(ck);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                txt_ma.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                if (txt_ma.Text == "")
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_ma.Focus();
                }
                else
                {
                    if (txt_ten.Text == "")
                    {
                        MessageBox.Show("Tên loại nhân viên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ten.Focus();
                    }
                }


            }
        }

        private void dgv_dsloiduocpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txt_ma.Text = dgv_dsloiduocpham.Rows[dong].Cells[0].Value.ToString();
            txt_ten.Text = dgv_dsloiduocpham.Rows[dong].Cells[1].Value.ToString();
            locktext();
        }
    }
}
