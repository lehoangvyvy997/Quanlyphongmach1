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
    public partial class fr_admin_xemdsctdvsc : Form
    {
        public fr_admin_xemdsctdvsc()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        E_tb_Chitietdvsocuutaicho thucthi = new E_tb_Chitietdvsocuutaicho();
        private int dong = 0;
        public void setnull()
        {
            txt_scmadv.Text = "";
            txt_sctendv.Text = "";
            txt_scmadp.Text = "";
            txt_sccongdung.Text = "";
            txt_scdonvi.Text = "";
            txt_scsoluongdp.Text = "";
            txt_sctendp.Text = "";
        }
        public void khoitaoluoi()
        {
            dgv_scds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_scds.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_scds.Columns[0].Frozen = true;
            dgv_scds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_scds.Columns[0].Width = 200;
            dgv_scds.Columns[1].HeaderText = "Mã dược phẩm";
            dgv_scds.Columns[1].Width = 150;
            dgv_scds.Columns[2].HeaderText = "Mã loại dịch vụ";
            dgv_scds.Columns[2].Width = 150;
            dgv_scds.Columns[3].HeaderText = "Số lượng";
            dgv_scds.Columns[3].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong FROM dbo.CHITIETDVSOCUUTAICHO";
            dgv_scds.DataSource = cn.taobang(sql);
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
        public void hienthi_(string key)
        {
            string sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + key + "'";
            dgv_scds.DataSource = cn.taobang(sql);
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

        private void txt_scmadv_TextChanged(object sender, EventArgs e)
        {
            txt_sctendv.Text = thucthi.Load_tendvsc(txt_scmadv.Text);
        }

        private void txt_scmadp_TextChanged(object sender, EventArgs e)
        {
            txt_sctendp.Text = thucthi.Load_tendp(txt_scmadp.Text);
            txt_scdonvi.Text = thucthi.Load_donvidp(txt_scmadp.Text);
            txt_sccongdung.Text = thucthi.Load_congdungdp(txt_scmadp.Text);
        }

        private void dgv_scds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            txt_scmadv.Text = dgv_scds.Rows[dong].Cells[2].Value.ToString();
            txt_scmadp.Text = dgv_scds.Rows[dong].Cells[1].Value.ToString();
            txt_scsoluongdp.Text = dgv_scds.Rows[dong].Cells[3].Value.ToString();
        }

        private void fr_admin_xemdsctdvsc_Load(object sender, EventArgs e)
        {
            setnull();
            hienthi();
            khoitaoluoi();
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
