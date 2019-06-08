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
    public partial class fr_chitiettoathuockham : Form
    {
        private string Mapukh;
        public fr_chitiettoathuockham()
        {
            InitializeComponent();
        }

        public fr_chitiettoathuockham(string mapukh)
        {
            Mapukh = mapukh;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_Chitiettoathuockham thucthi = new E_tb_Chitiettoathuockham();
        EC_tb_Chitiettoathuockham ck = new EC_tb_Chitiettoathuockham();

        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            cbo_ma.Text = "";
            txt_soluong.Text = "";
            txt_cachdung.Text = "";
            txt_tenthuoc.Text = "";
            txt_donvi.Text = "";
            txt_congdung.Text = "";

        }

        public void locktext()
        {
            cbo_ma.Enabled = false;
            txt_soluong.Enabled = false;
            txt_cachdung.Enabled = false;
            txt_tenthuoc.Enabled = false;
            txt_donvi.Enabled = false;
            txt_congdung.Enabled = false;


            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        public void un_locktext()
        {
            cbo_ma.Enabled = true;
            txt_soluong.Enabled = true;
            txt_cachdung.Enabled = true;
            txt_tenthuoc.Enabled = true;
            txt_donvi.Enabled = true;
            txt_congdung.Enabled = true;

           
            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_dsctthk.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsctthk.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_dsctthk.Columns[0].Frozen = true;
            dgv_dsctthk.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsctthk.Columns[0].Width = 180;
            dgv_dsctthk.Columns[1].HeaderText = "Mã thuốc";
            dgv_dsctthk.Columns[1].Width = 140;
            dgv_dsctthk.Columns[2].HeaderText = "Số lượng";
            dgv_dsctthk.Columns[2].Width = 100;
            dgv_dsctthk.Columns[3].HeaderText = "Cách dùng";
            dgv_dsctthk.Columns[3].Width = 200;

        }

        public void hienthi()
        {
            string sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung FROM CHITIETTOATHUOCKHAM where MaPhieuKham = '" + Mapukh + "'";
            dgv_dsctthk.DataSource = cn.taobang(sql);
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
        private void fr_chitiettoathuockham_Load(object sender, EventArgs e)
        {
            grb1.Text = "Kê đơn thuốc phiếu khám:" + Mapukh;
            thucthi.loadcbo_mathk(cbo_ma);
            thucthi.load_mathuockham(cbo_ma);

            locktext();
            setnull();
            hienthi();
            khoitaoluoi();
        }

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            cbo_ma.Enabled = true;
            cbo_ma.Focus();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            cbo_ma.Enabled = true;
            cbo_ma.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MAPHIEUKHAM = Mapukh;
                    ck.MATHUOCKHAM = cbo_ma.Text;
                    ck.SOLUONG = txt_soluong.Text;
                    ck.CACHDUNG = txt_cachdung.Text;

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
        private int kiemtranull()
        {
            if (cbo_ma.Text == "")
                return 1;
            if (txt_soluong.Text == "")
                return 2;
            if (txt_cachdung.Text == "")
                return 3;
            return 0;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int val = kiemtranull();

            switch (val)
            {
                case 0:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MAPHIEUKHAM = Mapukh;
                                ck.MATHUOCKHAM = cbo_ma.Text;
                                ck.SOLUONG = txt_soluong.Text;
                                ck.CACHDUNG = txt_cachdung.Text;
                                ck.THANHTIEN = (int.Parse(txt_soluong.Text) * int.Parse(thucthi.Load_giabanthk( cbo_ma.Text))).ToString();

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
                                ck.MAPHIEUKHAM = Mapukh;
                                ck.MATHUOCKHAM = cbo_ma.Text;
                                ck.SOLUONG = txt_soluong.Text;
                                ck.CACHDUNG = txt_cachdung.Text;
                                ck.THANHTIEN = (int.Parse(txt_soluong.Text) * int.Parse(thucthi.Load_giabanthk( cbo_ma.Text))).ToString();

                                thucthi.sua(ck);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        locktext();
                        hienthi();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Mã thuốc khám trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbo_ma.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Số lượng thuốc khám trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_soluong.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Cách dùng thuốc khám trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_cachdung.Focus();
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
                cbo_ma.Text = dgv_dsctthk.Rows[dong].Cells[1].Value.ToString();
                txt_soluong.Text = dgv_dsctthk.Rows[dong].Cells[2].Value.ToString();
                txt_cachdung.Text = dgv_dsctthk.Rows[dong].Cells[3].Value.ToString();
            }

            locktext();
        }

        private void cbo_ma_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_congdung.Text = thucthi.Load_congdungthk(cbo_ma.Text);
            txt_tenthuoc.Text = thucthi.Load_tenthk(cbo_ma.Text);
            txt_donvi.Text = thucthi.Load_donvithk(cbo_ma.Text);
        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_ma_TextChanged(object sender, EventArgs e)
        {
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            txt_congdung.Text = thucthi.Load_congdungthk(cbo_ma.Text);
            txt_tenthuoc.Text = thucthi.Load_tenthk(cbo_ma.Text);
            txt_donvi.Text = thucthi.Load_donvithk(cbo_ma.Text);
        }
    }
}
