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
    public partial class fr_diemnhanthuoc : Form
    {
        public fr_diemnhanthuoc()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        int dong = 0;

        private void setnull()
        {
            txt_bnchuandoan.Text = "";
            txt_bngioitinh.Text = "";
            txt_bnhoten.Text = ""; ;
            txt_bnma.Text = "";
            txt_bnsocmnd.Text = "";
            txt_bntuoi.Text = "";
        }
        private void lockbtn()
        {
            btn_in.Enabled = false;
            btn_luu.Enabled = false;
        }
        private void un_lockbtn()
        {
            btn_luu.Enabled = true;
            btn_in.Enabled = true;
        }
        public void khoitaoluoi_Bn()
        {
            dgv_dsBn.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsBn.Columns[0].HeaderText = "Mã bệnh nhân";
            dgv_dsBn.Columns[0].Frozen = true;
            dgv_dsBn.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsBn.Columns[0].Width = 200;
            dgv_dsBn.Columns[1].HeaderText = "Tên bệnh nhân";
            dgv_dsBn.Columns[1].Width = 180;
            dgv_dsBn.Columns[2].HeaderText = "Tuổi";
            dgv_dsBn.Columns[2].Width = 70;
            dgv_dsBn.Columns[3].HeaderText = "Giới tính";
            dgv_dsBn.Columns[3].Width = 70;
            dgv_dsBn.Columns[4].HeaderText = "Số CMND";
            dgv_dsBn.Columns[4].Width = 150;
            dgv_dsBn.Columns[5].HeaderText = "Địa chỉ";
            dgv_dsBn.Columns[5].Width = 150;
            dgv_dsBn.Columns[6].HeaderText = "Chuẩn đoán sơ bộ";
            dgv_dsBn.Columns[6].Width = 150;
            dgv_dsBn.Columns[7].HeaderText = "Ngày khám";
            dgv_dsBn.Columns[7].Width = 80;
            dgv_dsBn.Columns[8].HeaderText = "Mã phòng khám 1";
            dgv_dsBn.Columns[8].Width = 100;
            dgv_dsBn.Columns[9].HeaderText = "STT PHK1";
            dgv_dsBn.Columns[9].Width = 80;
            dgv_dsBn.Columns[10].HeaderText = "Mã phòng khám 2";
            dgv_dsBn.Columns[10].Width = 100;
            dgv_dsBn.Columns[11].HeaderText = "STT PHK2";
            dgv_dsBn.Columns[11].Width = 80;
            dgv_dsBn.Columns[12].HeaderText = "Mã phòng khám 3";
            dgv_dsBn.Columns[12].Width = 100;
            dgv_dsBn.Columns[13].HeaderText = "STT PHK3";
            dgv_dsBn.Columns[13].Width = 80;

        }
        public void hienthi_Bn()
        {
            string sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE NhanThuoc = N'Chưa nhận'";
            dgv_dsBn.DataSource = cn.taobang(sql);

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
        public void khoitaoluoi_dtk()
        {
            dgv_dsthuoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsthuoc.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_dsthuoc.Columns[0].Frozen = true;
            dgv_dsthuoc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsthuoc.Columns[0].Width = 150;

            dgv_dsthuoc.Columns[1].HeaderText = "Mã thuốc";
            dgv_dsthuoc.Columns[1].Width = 200;
            dgv_dsthuoc.Columns[2].HeaderText = "Số lượng";
            dgv_dsthuoc.Columns[2].Width = 200;
            dgv_dsthuoc.Columns[3].HeaderText = "Cách dùng";
            dgv_dsthuoc.Columns[3].Width = 200;
            dgv_dsthuoc.Columns[4].HeaderText = "Thành tiền";
            dgv_dsthuoc.Columns[4].Width = 200;

        }
        public void hienthi_dtk()
        {
            string sql1 = "SELECT MaPhieuKham FROM dbo.PHIEUKHAM WHERE MaBenhNhan = N'" + txt_bnma.Text + "'";
            DataTable ds_maPukh = cn.taobang(sql1);
            int countPukh = ds_maPukh.Rows.Count;

            string sql = "";
            switch (countPukh)
            {
                case 0:
                    {
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '0'";
                        break;
                    }
                case 1:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "'";
                        break;
                    }
                case 2:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "'";
                        break;
                    }
                case 3:
                    {
                        string maphieukham1 = ds_maPukh.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maPukh.Rows[1].ItemArray[0].ToString(), maphieukham3 = ds_maPukh.Rows[2].ItemArray[0].ToString();
                        sql = "SELECT MaPhieuKham, MaThuocKham, SoLuong, CachDung, ThanhTien FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + maphieukham1 + "' OR MaPhieuKham = '" + maphieukham2 + "' OR MaPhieuKham = '" + maphieukham3 + "'";
                        break;
                    }
            }


            dgv_dsthuoc.DataSource = cn.taobang(sql);
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
        public void hienthi_(string maBN)
        {
            string sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE MaBenhNhan = '" + maBN + "'";
            dgv_dsBn.DataSource = cn.taobang(sql);

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

        private void fr_diemnhanthuoc_Load(object sender, EventArgs e)
        {
            lockbtn();

            hienthi_Bn();
            hienthi_dtk();

            khoitaoluoi_Bn();
            khoitaoluoi_dtk();
        }

        private void txt_bnma_TextChanged(object sender, EventArgs e)
        {
            un_lockbtn();
            hienthi_dtk();
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            btn_in.Enabled = false;
        }
        private string load_sdcon(string mathuoc)
        {
            return cn.LoadLable("SELECT SoLuongCon FROM dbo.THUOCKHAM WHERE MaThuocKham = '" + mathuoc + "'");
        }
        private string load_tenthuoc(string mathuoc)
        {
            return cn.LoadLable("SELECT TenThuocKham FROM dbo.THUOCKHAM WHERE MaThuocKham = '" + mathuoc + "'");
        }
        public void sua(string mathuoc, int slc)
        {
            string sql = (@"UPDATE dbo.THUOCKHAM
            SET SoLuongCon = " + slc.ToString() + " where  MaThuocKham ='" + mathuoc + "'");
            cn.ExcuteNonQuery(sql);
        }
        // cập nhật số lượng thuốc trong kho
        private void kiemtracapnhatthuoc()
        {
            int rows = dgv_dsthuoc.Rows.Count;
            for(int i=0;i<rows;i++)
            {
                if(int.Parse(load_sdcon(dgv_dsthuoc.Rows[i].Cells[2].Value.ToString()))<int.Parse(dgv_dsthuoc.Rows[i].Cells[2].Value.ToString()))
                {
                    MessageBox.Show("Số lượng thuốc "+ load_tenthuoc(dgv_dsthuoc.Rows[i].Cells[1].Value.ToString()) + " trong kho không đủ để cấp phát!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void capnhatthuoc()
        {
            int rows = dgv_dsthuoc.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                int slc = int.Parse(load_sdcon(dgv_dsthuoc.Rows[i].Cells[2].Value.ToString())) - int.Parse(dgv_dsthuoc.Rows[i].Cells[2].Value.ToString());
                sua(dgv_dsthuoc.Rows[i].Cells[1].Value.ToString(), slc);
            }
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (btn_in.Enabled == true)
            {
                MessageBox.Show("In hướng dẫn sử dụng trước khi lưu!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_in.Focus();
            }
            else
            {
                kiemtracapnhatthuoc();
                capnhatthuoc();

                string sql = (@"UPDATE dbo.BENHNHAN
                                SET NhanThuoc =N'Đã nhận' where  MaBenhNhan ='" + txt_bnma.Text + "'");
                cn.ExcuteNonQuery(sql);
                hienthi_Bn();
                setnull();
                lockbtn();
                
            }
        }

        private void btn_shtim_Click(object sender, EventArgs e)
        {
            hienthi_(txt_shsearch.Text);
            
        }

        private void btn_shhienthi_Click(object sender, EventArgs e)
        {
            hienthi_Bn();
        }

        private void dgv_dsBn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            txt_bnma.Text = dgv_dsBn.Rows[dong].Cells[0].Value.ToString();
            txt_bnhoten.Text = dgv_dsBn.Rows[dong].Cells[1].Value.ToString();

            txt_bntuoi.Text = dgv_dsBn.Rows[dong].Cells[2].Value.ToString();
            txt_bngioitinh.Text = dgv_dsBn.Rows[dong].Cells[3].Value.ToString();
            txt_bnsocmnd.Text = dgv_dsBn.Rows[dong].Cells[4].Value.ToString();
            txt_bnchuandoan.Text = dgv_dsBn.Rows[dong].Cells[6].Value.ToString();
        }

        private void btn_thuocthaythe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng chưa được xây dựng!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
