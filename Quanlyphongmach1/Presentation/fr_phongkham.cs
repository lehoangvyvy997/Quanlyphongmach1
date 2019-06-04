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
    public partial class fr_phongkham : Form
    {
        public fr_phongkham()
        {
            InitializeComponent();
        }

        E_tb_Phongkham thucthi = new E_tb_Phongkham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Phongkham ck = new EC_tb_Phongkham();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txt_ma.Text = "";
            txt_ten.Text = "";
            lb_hd.Text = "Hàng đợi: 0";
            lb_hhd.Text = "Hiệu hàng đợi: 0";
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
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã phòng khám";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Tên phòng khám";
            dgv_ds.Columns[1].Width = 200;
            dgv_ds.Columns[2].HeaderText = "Số lượng hàng đợi";
            dgv_ds.Columns[2].Width = 150;
            dgv_ds.Columns[3].HeaderText = "Hiệu số hàng đợi";
            dgv_ds.Columns[3].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaPhongKham, TenPhongKham, HangDoi, HieuHangDoi FROM PHONGKHAM";
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
        private void fr_phongkham_Load(object sender, EventArgs e)
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
            ck.MAPHONGKHAM = txt_ma.Text;
            string sohangdoi = cn.LoadLable("SELECT HangDoi FROM dbo.PHONGKHAM where MaPhongKham ='" + ck.MAPHONGKHAM + "'");
            if(sohangdoi=="0")
            {
                if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
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
            else
            {
                MessageBox.Show("Trường dữ liệu này đang được sử dụng, không được xóa", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int kiemtranull()
        {
            if (txt_ma.Text == "")
                return 1;
            if (txt_ten.Text == "")
                return 2;
            return 0;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtranull();
            switch (key)
            {
                case 0:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MAPHONGKHAM = txt_ma.Text;
                                ck.TENPHONGKHAM = txt_ten.Text;

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
                        {
                            try
                            {
                                ck.MAPHONGKHAM = txt_ma.Text;
                                ck.TENPHONGKHAM = txt_ten.Text;

                                thucthi.sua(ck);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        txt_ma.Enabled = true;
                        locktext();
                        hienthi();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ma.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Tên phòng khám không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ten.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            
            if(dong!=-1)
            {
                txt_ma.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_ten.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
                lb_hd.Text = "Hàng đợi: " + dgv_ds.Rows[dong].Cells[2].Value.ToString();
                lb_hhd.Text = "Hiệu hàng đợi: " + dgv_ds.Rows[dong].Cells[3].Value.ToString();
            }

            locktext();
        }
    }
}
