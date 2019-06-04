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
    public partial class fr_admin_xemdsctdvkt : Form
    {
        public fr_admin_xemdsctdvkt()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        E_tb_Chitietdvkythuatyte thucthi = new E_tb_Chitietdvkythuatyte();
        private int dong = 0;

        public void setnull()
        {
            txt_madv.Text = "";
            txt_ktphisd.Text = "";
            txt_ktsolansd.Text = "";
            txt_kttendv.Text = "";
        }
        public void khoitaoluoi()
        {
            dgv_ktds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ktds.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_ktds.Columns[0].Frozen = true;
            dgv_ktds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ktds.Columns[0].Width = 250;
            dgv_ktds.Columns[1].HeaderText = "Mã Dịch vụ";
            dgv_ktds.Columns[1].Width = 170;
            dgv_ktds.Columns[2].HeaderText = "Số lần sử dụng";
            dgv_ktds.Columns[2].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD FROM dbo.CHITIETDVKYTHUATYTE ";
            dgv_ktds.DataSource = cn.taobang(sql);
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

        public void hienthi_(string maPukh)
        {
            string sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + maPukh + "'";
            dgv_ktds.DataSource = cn.taobang(sql);
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


        private void fr_admin_xemdsctdvkt_Load(object sender, EventArgs e)
        {
            setnull();

            hienthi();
            khoitaoluoi();
        }

        private void dgv_ktds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                txt_madv.Text = dgv_ktds.Rows[dong].Cells[1].Value.ToString();
                txt_ktsolansd.Text = dgv_ktds.Rows[dong].Cells[2].Value.ToString();
            }
        }

        private void txt_madv_TextChanged(object sender, EventArgs e)
        {
            txt_kttendv.Text = thucthi.Load_tendvkt(txt_madv.Text);
            txt_ktphisd.Text = thucthi.Load_chiphidvkt(txt_madv.Text);
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
