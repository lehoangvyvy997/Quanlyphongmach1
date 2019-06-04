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
    public partial class fr_admin_xemdshoadon : Form
    {
        public fr_admin_xemdshoadon()
        {
            InitializeComponent();
        }
        private int dong = 0;

        ConnectDB cn = new ConnectDB();


        private void setnull()
        {
            txt_mabenhnhan.Text = "";
            txt_ngaylaphd.Text = "";
            txt_sohd.Text = ""; 
            txt_sophieukham.Text = "";
            txt_tiendvkt.Text = ""; 
            txt_tiendvsc.Text = "";
            txt_tienkham.Text = "";
            txt_tienthuoc.Text = "";
            txt_tongtien.Text = "";
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Số hóa đơn";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Mã bệnh nhân";
            dgv_ds.Columns[1].Width = 150;
            dgv_ds.Columns[2].HeaderText = "Mã phiếu khám 1";
            dgv_ds.Columns[2].Width = 150;
            dgv_ds.Columns[3].HeaderText = "Mã phiếu khám 2";
            dgv_ds.Columns[3].Width = 100;
            dgv_ds.Columns[4].HeaderText = "Mã phiếu khám 3";
            dgv_ds.Columns[4].Width = 150;
            dgv_ds.Columns[5].HeaderText = "Ngày lập hóa đơn";
            dgv_ds.Columns[5].Width = 50;
            dgv_ds.Columns[6].HeaderText = "Tiền khám";
            dgv_ds.Columns[6].Width = 100;
            dgv_ds.Columns[7].HeaderText = "tiền thuốc";
            dgv_ds.Columns[7].Width = 50;
            dgv_ds.Columns[8].HeaderText = "Tiền sử dụng DVKT";
            dgv_ds.Columns[8].Width = 100;
            dgv_ds.Columns[9].HeaderText = "Tiền sử dụng DVSC";
            dgv_ds.Columns[9].Width = 50;
            dgv_ds.Columns[10].HeaderText = "Tổng tiền";
            dgv_ds.Columns[10].Width = 100;

        }


        public void hienthi()
        {

            string sql = "SELECT MaHoaDonThuTien,MaBenhNhan,MaPhieuKham1,MaPhieuKham2,MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien FROM dbo.HOADONTHUTIEN ";

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
        public void hienthi_(string maBn, DateTime date)
        {
            string sql = "";
            string day = "";
            if (date.Day.ToString() != "")
                day = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (maBn!=""&&date.Day.ToString()!="")
            {
                sql = "SELECT MaHoaDonThuTien,MaBenhNhan,MaPhieuKham1,MaPhieuKham2,MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien FROM dbo.HOADONTHUTIEN WHERE MaBenhNhan = '" + maBn + "'  AND NgayLapHoaDon = '" + day + "'";
            }
            else
            {
                if(maBn == "" && date.Day.ToString() != "")
                {
                    sql = "SELECT MaHoaDonThuTien,MaBenhNhan,MaPhieuKham1,MaPhieuKham2,MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien FROM dbo.HOADONTHUTIEN WHERE  NgayLapHoaDon = '" + day + "'";
                }
                else
                {
                    if (maBn != "" && date.Day.ToString() == "")
                    {
                        sql = "SELECT MaHoaDonThuTien,MaBenhNhan,MaPhieuKham1,MaPhieuKham2,MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien FROM dbo.HOADONTHUTIEN WHERE MaBenhNhan = '" + maBn + "'";
                    }
                    else
                        sql = "SELECT MaHoaDonThuTien,MaBenhNhan,MaPhieuKham1,MaPhieuKham2,MaPhieuKham3,NgayLapHoaDon,TienKham,TienThuoc,TienSuDungDVKyThuatYTe,TienSuDungDVSoCuu,TongTien FROM dbo.HOADONTHUTIEN WHERE MaBenhNhan = '0'  AND NgayLapHoaDon = '" + date.ToString() + "'";

                }
            }
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

        private void fr_admin_xemdshoadon_Load(object sender, EventArgs e)
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
            hienthi_(txt_shmabenhnhan.Text, dtm_ngaylaphd.Value);
            setnull();
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                txt_sohd.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_mabenhnhan.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
                if (dgv_ds.Rows[dong].Cells[3].Value.ToString() == "" && dgv_ds.Rows[dong].Cells[4].Value.ToString() == "")
                { txt_sophieukham.Text = "1"; }
                if (dgv_ds.Rows[dong].Cells[3].Value.ToString() != "" && dgv_ds.Rows[dong].Cells[4].Value.ToString() == "")
                { txt_sophieukham.Text = "2"; }
                if (dgv_ds.Rows[dong].Cells[3].Value.ToString() != "" && dgv_ds.Rows[dong].Cells[4].Value.ToString() != "")
                { txt_sophieukham.Text = "3"; }
                txt_ngaylaphd.Text = dgv_ds.Rows[dong].Cells[5].Value.ToString();
                txt_tienkham.Text = dgv_ds.Rows[dong].Cells[6].Value.ToString();
                txt_tienthuoc.Text = dgv_ds.Rows[dong].Cells[7].Value.ToString();
                txt_tiendvkt.Text = dgv_ds.Rows[dong].Cells[8].Value.ToString();
                txt_tiendvsc.Text = dgv_ds.Rows[dong].Cells[9].Value.ToString();
                txt_tongtien.Text = dgv_ds.Rows[dong].Cells[10].Value.ToString();
            }
        }
    }
}
