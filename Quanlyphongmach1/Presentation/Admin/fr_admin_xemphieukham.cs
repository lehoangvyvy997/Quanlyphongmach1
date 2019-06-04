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
    public partial class fr_admin_xemphieukham : Form
    {
        public fr_admin_xemphieukham()
        {
            InitializeComponent();
        }
        private int dong = 0;
        ConnectDB cn = new ConnectDB();
        private void setnull()
        {
            txt_chuandoan.Text = "";
            txt_maphieukham.Text = "";
            txt_ngaykham.Text = "";
            txt_tenbacsi.Text = "";

            chk_dvkt.Checked = false;
            chk_dvsc.Checked = false;
            chk_kedon.Checked = false;

            lb_tiendvkt.Text = "";
            lb_tiendvsc.Text = "";
            lb_tienkedon.Text = "";
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Mã nhân viên";
            dgv_ds.Columns[1].Width = 150;
            dgv_ds.Columns[2].HeaderText = "Mã bệnh nhân";
            dgv_ds.Columns[2].Width = 150;
            dgv_ds.Columns[3].HeaderText = "Ngày khám";
            dgv_ds.Columns[3].Width = 100;
            dgv_ds.Columns[4].HeaderText = "Chuẩn đoán bệnh";
            dgv_ds.Columns[4].Width = 150;
            dgv_ds.Columns[5].HeaderText = "Kê đơn thuốc";
            dgv_ds.Columns[5].Width = 50;
            dgv_ds.Columns[6].HeaderText = "Số tiền thuốc";
            dgv_ds.Columns[6].Width = 100;
            dgv_ds.Columns[7].HeaderText = "Sử dụng DVKT";
            dgv_ds.Columns[7].Width = 50;
            dgv_ds.Columns[8].HeaderText = "Tiền DVKT";
            dgv_ds.Columns[8].Width = 100;
            dgv_ds.Columns[9].HeaderText = "Sử dụng DVSC";
            dgv_ds.Columns[9].Width = 50;
            dgv_ds.Columns[10].HeaderText = "Tiền DVSC";
            dgv_ds.Columns[10].Width = 100;

        }
        public void hienthi()
        {
           
            string sql = "SELECT MaPhieuKham,MaNhanVien,MaBenhNhan,NgayKham,ChuanDoanBenh,KeDonThuoc,TongTienThuoc,SuDungDVKyThuatYTe,TongTienDVKyThuat,SuDungDVSoCuu,TongTienDVSoCuu FROM dbo.PHIEUKHAM ";
            
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
        public void hienthi_(DateTime date)
        {
            string ngaykham = date.Year.ToString() +"/"+ date.Month.ToString() +"/"+ date.Day.ToString();
            string sql = "SELECT MaPhieuKham,MaNhanVien,MaBenhNhan,NgayKham,ChuanDoanBenh,KeDonThuoc,TongTienThuoc,SuDungDVKyThuatYTe,TongTienDVKyThuat,SuDungDVSoCuu,TongTienDVSoCuu FROM dbo.PHIEUKHAM WHERE NgayKham = '" + ngaykham + "'";

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


        private void fr_admin_xemphieukham_Load(object sender, EventArgs e)
        {
            setnull();

            hienthi();
            khoitaoluoi();
        }
        private string load_tenbs(string maNV)
        {
            return cn.LoadLable("SELECT TenNhanVien FROM dbo.NHANVIEN WHERE MaNhanVien = N'" + maNV + "'");
        }
        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

           if(dong!=-1)
            {
                txt_maphieukham.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_tenbacsi.Text = load_tenbs(dgv_ds.Rows[dong].Cells[1].Value.ToString());
                txt_chuandoan.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
                txt_ngaykham.Text = dgv_ds.Rows[dong].Cells[3].Value.ToString();

                if (dgv_ds.Rows[dong].Cells[5].Value.ToString() == "Có")
                    chk_kedon.Checked = true;
                else
                    chk_kedon.Checked = false;

                if (dgv_ds.Rows[dong].Cells[7].Value.ToString() == "Có")
                    chk_dvkt.Checked = true;
                else
                    chk_dvkt.Checked = false;

                if (dgv_ds.Rows[dong].Cells[9].Value.ToString() == "Có")
                    chk_dvsc.Checked = true;
                else
                    chk_dvsc.Checked = false;

                lb_tienkedon.Text = dgv_ds.Rows[dong].Cells[6].Value.ToString();
                lb_tiendvkt.Text = dgv_ds.Rows[dong].Cells[8].Value.ToString();
                lb_tiendvsc.Text = dgv_ds.Rows[dong].Cells[10].Value.ToString();
            }
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            hienthi_(dtm.Value);
        }
    }
}
