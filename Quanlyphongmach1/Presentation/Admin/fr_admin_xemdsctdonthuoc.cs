using Quanlyphongmach1.Business.Component;
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

namespace Quanlyphongmach1.Presentation.Admin
{
    public partial class fr_admin_xemdsctdonthuoc : Form
    {
        public fr_admin_xemdsctdonthuoc()
        {
            InitializeComponent();
        }
        E_tb_Chitiettoathuockham thucthi = new E_tb_Chitiettoathuockham();
        ConnectDB cn = new ConnectDB();

        int dong = 0;

        public void setnull()
        {
            txt_ma.Text = "";
            txt_soluong.Text = "";
            txt_cachdung.Text = "";
            txt_tenthuoc.Text = "";
            txt_donvi.Text = "";
            txt_congdung.Text = "";

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
            string sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung FROM CHITIETTOATHUOCKHAM";
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

        public void hienthi_(string mapukh)
        {
            string sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung FROM CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + mapukh + "'";
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

        private void fr_admin_xemdsctdonthuoc_Load(object sender, EventArgs e)
        {
            setnull();
            hienthi();
            khoitaoluoi();
        }

        private void dgv_dsctthk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            txt_ma.Text = dgv_dsctthk.Rows[dong].Cells[1].Value.ToString();
            txt_soluong.Text = dgv_dsctthk.Rows[dong].Cells[2].Value.ToString();
            txt_cachdung.Text = dgv_dsctthk.Rows[dong].Cells[3].Value.ToString();
        }

        private void txt_ma_TextChanged(object sender, EventArgs e)
        {
            txt_congdung.Text = thucthi.Load_congdungthk(txt_ma.Text);
            txt_tenthuoc.Text = thucthi.Load_tenthk(txt_ma.Text);
            txt_donvi.Text = thucthi.Load_donvithk(txt_ma.Text);
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            hienthi();
            setnull();
               
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            hienthi_(txt_shmaphieukham.Text);
            setnull();
        }
    }
}
