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
    public partial class fr_admin_xemdsbenhnhan : Form
    {
        public fr_admin_xemdsbenhnhan()
        {
            InitializeComponent();
        }
        E_tb_Benhnhan thucthi = new E_tb_Benhnhan();
        ConnectDB cn = new ConnectDB();
        private int dong = 0;

        private void setnull()
        {
            txt_socmnd.Text = "";
        }

        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã bệnh nhân";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 200;
            dgv_ds.Columns[1].HeaderText = "Tên bệnh nhân";
            dgv_ds.Columns[1].Width = 180;
            dgv_ds.Columns[2].HeaderText = "Tuổi";
            dgv_ds.Columns[2].Width = 70;
            dgv_ds.Columns[3].HeaderText = "Giới tính";
            dgv_ds.Columns[3].Width = 70;
            dgv_ds.Columns[4].HeaderText = "Số CMND";
            dgv_ds.Columns[4].Width = 150;
            dgv_ds.Columns[5].HeaderText = "Địa chỉ";
            dgv_ds.Columns[5].Width = 150;
            dgv_ds.Columns[6].HeaderText = "Chuẩn đoán sơ bộ";
            dgv_ds.Columns[6].Width = 150;
            dgv_ds.Columns[7].HeaderText = "Ngày khám";
            dgv_ds.Columns[7].Width = 80;
            dgv_ds.Columns[8].HeaderText = "Mã phòng khám 1";
            dgv_ds.Columns[8].Width = 100;
            dgv_ds.Columns[9].HeaderText = "STT PHK1";
            dgv_ds.Columns[9].Width = 80;
            dgv_ds.Columns[10].HeaderText = "Mã phòng khám 2";
            dgv_ds.Columns[10].Width = 100;
            dgv_ds.Columns[11].HeaderText = "STT PHK2";
            dgv_ds.Columns[11].Width = 80;
            dgv_ds.Columns[12].HeaderText = "Mã phòng khám 3";
            dgv_ds.Columns[12].Width = 100;
            dgv_ds.Columns[13].HeaderText = "STT PHK3";
            dgv_ds.Columns[13].Width = 80;

        }
        public void hienthi()
        {
            string sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN ";
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

        private void ht(string sql)
        {

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
        public void hienthi_timkiem(string hoten, string socmnd, DateTime date)
        {
            string sql = "";
            string ngay = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (hoten != "" && socmnd != "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE SoCMND = '" + socmnd + "' AND HoTenBenhNhan = '" + hoten + "' AND NgayKhamBenh = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (hoten == "" && socmnd != "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE SoCMND = '" + socmnd + "' AND NgayKhamBenh = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (hoten != "" && socmnd == "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE  HoTenBenhNhan = '" + hoten + "' AND NgayKhamBenh = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (hoten != "" && socmnd != "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE SoCMND = '" + socmnd + "' AND HoTenBenhNhan = '" + hoten + "'";
                ht(sql);
                return;
            }

            if (hoten == "" && socmnd != "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE SoCMND = '" + socmnd + "'";
                ht(sql);
                return;
            }
            if (hoten == "" && socmnd == "" && date.Day.ToString() != "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE  NgayKhamBenh = '" + ngay + "'";
                ht(sql);
                return;
            }
            if (hoten != "" && socmnd == "" && date.Day.ToString() == "")
            {
                sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE HoTenBenhNhan = '" + hoten + "'";
                ht(sql);
                return;
            }
            sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE SoCMND = '" + socmnd + "' AND HoTenBenhNhan = '" + hoten + "' AND NgayKhamBenh = '" + ngay + "'";
            ht(sql);
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txt_hoten.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
            txt_socmnd.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            hienthi();
            setnull();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            hienthi_timkiem(txt_shten.Text, txt_shdmnd.Text, dtm_ngaynhap.Value);
            setnull();
        }

        private void fr_admin_xemdsbenhnhan_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();


            setnull();
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }
        private void btn_xemlskb_Click(object sender, EventArgs e)
        {
            if(txt_socmnd.Text!="")
            {
                Form frm = kiemtratontai(typeof(Admin.fr_admin_xemlichsu));
                if (frm != null)
                    frm.Activate();
                else
                {
                    Admin.fr_admin_xemlichsu fr = new Admin.fr_admin_xemlichsu(txt_socmnd.Text);
                    fr.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bệnh nhân để xem lịch sử", "Chú Ý", MessageBoxButtons.OK);
                dgv_ds.Focus();
            }
        }
    }
}
