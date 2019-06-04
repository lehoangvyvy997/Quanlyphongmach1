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
    public partial class fr_benhnhan : Form
    {
        public fr_benhnhan()
        {
            InitializeComponent();
        }
        // khai báo
        E_tb_Benhnhan thucthi = new E_tb_Benhnhan();
        ConnectDB cn = new ConnectDB();
        EC_tb_Benhnhan ck = new EC_tb_Benhnhan();
        bool themmoi= false;
        int dong = 0;


        public void setnull()
        {
            DateTime date = DateTime.Now;
            string d1, d2, d3;
            int val = thucthi.demsobenhnhan_inday(date) + 1;
            if (date.Day < 10)
                d1 = "0" + date.Day.ToString();
            else
                d1 = date.Day.ToString();
            if (date.Month < 10)
                d2 = "0" + date.Month.ToString();
            else
                d2 = date.Month.ToString();
            if (val < 10)
                d3 = "MBN000" + val.ToString();
            else
            {
                if (val < 100)
                    d3 = "MBN00" + val.ToString();
                else
                {
                    if (val < 1000)
                        d3 = "MBN0" + val.ToString();
                    else
                        d3 = val.ToString();
                }
            }
            txt_mabenhnhan.Text = d1 + d2 + date.Year.ToString() + d3;

            txt_tenbenhnhan.Text = "";
            txt_tuoi.Text = "";
            cbo_gioitinh.Text = "Nam";
            txt_socmnd.Text = "";
            txt_diachi.Text = "";
            txt_chuandoanbenh.Text = "";
            dtm_ngaykham.Text = DateTime.Now.ToShortTimeString();

            
            cbo_mapk1.Text = "";
            txt_tenpk1.Text = "";
            txt_hdpk1.Text = "";
            txt_hhdpk1.Text = "";

            cbo_mapk2.Text = "";
            txt_tenpk2.Text = "";
            txt_hdpk2.Text = "";
            txt_hhdpk2.Text = "";

            cbo_mapk3.Text = "";
            txt_tenpk3.Text = "";
            txt_hdpk3.Text = "";
            txt_hhdpk3.Text = "";

        }

        public void locktext()
        {
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_laysopk3.Enabled = false;
            btn_laysopk2.Enabled = false;
            btn_laysopk1.Enabled = false;

            txt_mabenhnhan.Enabled = false;
            txt_tenbenhnhan.Enabled = false;
            txt_tuoi.Enabled = false;
            cbo_gioitinh.Enabled = false;
            txt_socmnd.Enabled = false;
            txt_diachi.Enabled = false;
            txt_chuandoanbenh.Enabled = false;
            dtm_ngaykham.Enabled = false;

            cbo_mapk1.Enabled = false;
            txt_tenpk1.Enabled = false;
            txt_hdpk1.Enabled = false;
            txt_hhdpk1.Enabled = false;

            cbo_mapk2.Enabled = false;
            txt_tenpk2.Enabled = false;
            txt_hdpk2.Enabled = false;
            txt_hhdpk2.Enabled = false;

            cbo_mapk3.Enabled = false;
            txt_tenpk3.Enabled = false;
            txt_hdpk3.Enabled = false;
            txt_hhdpk3.Enabled = false;
        }

        public void un_locktext()
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = true;

            txt_mabenhnhan.Enabled = false;
            txt_tenbenhnhan.Enabled = true;
            txt_tuoi.Enabled = true;
            cbo_gioitinh.Enabled = true;
            txt_socmnd.Enabled = true;
            txt_diachi.Enabled = true;
            txt_chuandoanbenh.Enabled = true;
            dtm_ngaykham.Enabled = false;

            cbo_mapk1.Enabled = true;
            txt_tenpk1.Enabled = true;
            txt_hdpk1.Enabled = true;
            txt_hhdpk1.Enabled = true;

            cbo_mapk2.Enabled = true;
            txt_tenpk2.Enabled = true;
            txt_hdpk2.Enabled = true;
            txt_hhdpk2.Enabled = true;

            cbo_mapk3.Enabled = true;
            txt_tenpk3.Enabled = true;
            txt_hdpk3.Enabled = true;
            txt_hhdpk3.Enabled = true;
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

        private void fr_benhnhan_Load(object sender, EventArgs e)
        {
            thucthi.loadmapk(cbo_mapk1);
            thucthi.loadmapk(cbo_mapk2);
            thucthi.loadmapk(cbo_mapk3);

            locktext();
            hienthi();
            khoitaoluoi();
        }
        
        private void btn_laysopk1_Click(object sender, EventArgs e)
        {
            btn_laysopk1.Enabled = false;
        }

        private void btn_laysopk2_Click(object sender, EventArgs e)
        {
            btn_laysopk2.Enabled = false;
        }

        private void btn_laysopk3_Click(object sender, EventArgs e)
        {
            btn_laysopk3.Enabled = false;
        }

        private void txt_tuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txt_mabenhnhan.Enabled = false;
            txt_tenbenhnhan.Focus();
        }
        private int kiemtranull()
        {
            // trường họp không cho lưu
            if (txt_mabenhnhan.Text == "")
                return 1;
            if (txt_tenbenhnhan.Text == "")
                return 2;
            if (txt_tuoi.Text == "")
                return 3;
            if (cbo_gioitinh.Text == "")
                return 4;
            if (txt_socmnd.Text == "")
                return 5;
            if (txt_diachi.Text == "")
                return 6;
            if (txt_chuandoanbenh.Text == "")
                return 7;
            if (dtm_ngaykham.Text == "")
                return 19;
            if (cbo_mapk1.Text == "" && cbo_mapk2.Text == "" && cbo_mapk3.Text == "")
                return 8;
            if (cbo_mapk1.Text != "" && btn_laysopk1.Enabled == true)
                return 9;
            if (cbo_mapk2.Text != "" && btn_laysopk2.Enabled == true)
                return 10;
            if (cbo_mapk3.Text != "" && btn_laysopk3.Enabled == true)
                return 11;

            // trường hợp cho lưu 1 phòng khám
            if (cbo_mapk1.Text != "" && cbo_mapk2.Text == "" && cbo_mapk3.Text == "")
                return 12;
            if (cbo_mapk1.Text == "" && cbo_mapk2.Text != "" && cbo_mapk3.Text == "")
                return 13;
            if ((cbo_mapk1.Text == "" && cbo_mapk2.Text == "" && cbo_mapk3.Text != ""))
                return 14;

            // trường hợp cho lưu 2 phòng khám
            if (cbo_mapk1.Text != "" && cbo_mapk2.Text != "" && cbo_mapk3.Text == "")
                return 15;
            if (cbo_mapk1.Text != "" && cbo_mapk2.Text == "" && cbo_mapk3.Text != "")
                return 16;
            if (cbo_mapk1.Text == "" && cbo_mapk2.Text != "" && cbo_mapk3.Text != "")
                return 17;

            return 18;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtranull();

            switch (key)
            {
                case 1:
                    {
                        MessageBox.Show("Mã bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mabenhnhan.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Tên bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_tenbenhnhan.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Tuổi bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_tuoi.Focus();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Giới tính bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbo_gioitinh.Focus();
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show("Số CMND bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_socmnd.Focus();
                        break;
                    }
                case 6:
                    {
                        MessageBox.Show("Địa chỉ bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_diachi.Focus();
                        break;
                    }
                case 7:
                    {
                        MessageBox.Show("Chuẩn đoán sơ lượt về bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mabenhnhan.Focus();
                        break;
                    }
                case 19:
                    {
                        MessageBox.Show("Ngày khám không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_mabenhnhan.Focus();
                        break;
                    }
                case 8:
                    {
                        MessageBox.Show("Hãy chọn ít nhất 1 phòng khám cho bệnh nhân!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbo_mapk1.Focus();
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show("Hãy lấy số thứ tự phòng khám 1!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_laysopk1.Focus();
                        break;
                    }
                case 10:
                    {
                        MessageBox.Show("Hãy lấy số thứ tự phòng khám 2!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_laysopk2.Focus();
                        break;
                    }
                case 11:
                    {
                        MessageBox.Show("Hãy lấy số thứ tự phòng khám 3!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_laysopk3.Focus();
                        break;
                    }
                case 12:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk1.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk1.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_1(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 13:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk2.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk2.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_1(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 14:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk3.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk3.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_1(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 15:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk1.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk1.Text;

                            ck.MAPHONGKHAM2 = cbo_mapk2.Text;
                            ck.STTPHONGKHAM2 = txt_hdpk2.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_2(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 16:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk1.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk1.Text;

                            ck.MAPHONGKHAM2 = cbo_mapk3.Text;
                            ck.STTPHONGKHAM2 = txt_hdpk3.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_2(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 17:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk2.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk2.Text;

                            ck.MAPHONGKHAM2 = cbo_mapk3.Text;
                            ck.STTPHONGKHAM2 = txt_hdpk3.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";

                            thucthi.themoi_2(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case 18:
                    {
                        try
                        {
                            ck.MABENHNHAN = txt_mabenhnhan.Text;
                            ck.HOTENBENHNHAN = txt_tenbenhnhan.Text;
                            ck.TUOI = txt_tuoi.Text;
                            ck.GIOITINH = cbo_gioitinh.Text;
                            ck.SOCMND = txt_socmnd.Text;
                            ck.DIACHI = txt_diachi.Text;
                            ck.CHUANDONSOLUOT = txt_chuandoanbenh.Text;
                            ck.NGAYKHAMBENH = dtm_ngaykham.Value.ToString();

                            ck.MAPHONGKHAM1 = cbo_mapk1.Text;
                            ck.STTPHONGKHAM1 = txt_hdpk1.Text;

                            ck.MAPHONGKHAM2 = cbo_mapk2.Text;
                            ck.STTPHONGKHAM2 = txt_hdpk2.Text;

                            ck.MAPHONGKHAM3 = cbo_mapk3.Text;
                            ck.STTPHONGKHAM3 = txt_hdpk3.Text;
                            ck.THUVIENPHI = "Chưa thu";
                            ck.NHANTHUOC = "Chưa nhận";
                            thucthi.themoi_3(ck);
                            locktext();
                            hienthi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }

            }
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            dong = e.RowIndex;

            if(dong!=-1)
            {
                txt_mabenhnhan.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_tenbenhnhan.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
                txt_tuoi.Text = dgv_ds.Rows[dong].Cells[2].Value.ToString();
                cbo_gioitinh.Text = dgv_ds.Rows[dong].Cells[3].Value.ToString();
                txt_socmnd.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
                txt_diachi.Text = dgv_ds.Rows[dong].Cells[5].Value.ToString();
                txt_chuandoanbenh.Text = dgv_ds.Rows[dong].Cells[6].Value.ToString();

                dtm_ngaykham.Text = dgv_ds.Rows[dong].Cells[7].Value.ToString();
                cbo_mapk1.Text = dgv_ds.Rows[dong].Cells[8].Value.ToString();
                cbo_mapk2.Text = dgv_ds.Rows[dong].Cells[10].Value.ToString();
                cbo_mapk3.Text = dgv_ds.Rows[dong].Cells[12].Value.ToString();
            }
            
            locktext();
        }

        private void cbo_mapk1_TextChanged(object sender, EventArgs e)
        {
            txt_tenpk1.Text = thucthi.loadtenpk(txt_tenpk1.Text, cbo_mapk1.Text);
            //txt_hdpk1.Text = dgv_ds.Rows[dong].Cells[9].Value.ToString();
            txt_hhdpk1.Text = thucthi.loadhieuhangdoi(cbo_mapk1.Text).ToString();
        }

        private void cbo_mapk2_TextChanged(object sender, EventArgs e)
        {
            if(cbo_mapk2.Text!="")
            {
                txt_tenpk2.Text = thucthi.loadtenpk(txt_tenpk2.Text, cbo_mapk2.Text);
                //txt_hdpk2.Text = dgv_ds.Rows[dong].Cells[11].Value.ToString();
                txt_hhdpk2.Text = thucthi.loadhieuhangdoi(cbo_mapk2.Text).ToString();
            }
            else
            {
                txt_tenpk2.Text = "";
                txt_hdpk2.Text = "";
                txt_hhdpk2.Text = "";
            }
        }

        private void cbo_mapk3_TextChanged(object sender, EventArgs e)
        {
            if(cbo_mapk3.Text!="")
            {
                txt_tenpk3.Text = thucthi.loadtenpk(txt_tenpk3.Text, cbo_mapk3.Text);
                //txt_hdpk3.Text = dgv_ds.Rows[dong].Cells[13].Value.ToString();
                txt_hhdpk3.Text = thucthi.loadhieuhangdoi(cbo_mapk3.Text).ToString();
            }
            else
            {
                txt_tenpk3.Text = "";
                txt_hdpk3.Text = "";
                txt_hhdpk3.Text = "";
            }
        }

        private void cbo_mapk1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mapk1.Text != cbo_mapk2.Text && cbo_mapk1.Text != cbo_mapk3.Text)
            {
                txt_tenpk1.Text = thucthi.loadtenpk(txt_tenpk1.Text, cbo_mapk1.Text);

                txt_hdpk1.Text = (int.Parse(thucthi.loadhangdoi(cbo_mapk1.Text)) + 1).ToString();

                txt_hhdpk1.Text = thucthi.loadhieuhangdoi(cbo_mapk1.Text);
                btn_laysopk1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Mã này đã được chọn, hãy chọn mã khác!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mapk1.Text = "";
                cbo_mapk1.Focus();
            }
        }

        private void cbo_mapk2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mapk2.Text != cbo_mapk3.Text && cbo_mapk2.Text != cbo_mapk1.Text)
            {
                txt_tenpk2.Text = thucthi.loadtenpk(txt_tenpk2.Text, cbo_mapk2.Text);
                txt_hdpk2.Text = (int.Parse(thucthi.loadhangdoi(cbo_mapk2.Text)) + 1).ToString();
                txt_hhdpk2.Text = thucthi.loadhieuhangdoi(cbo_mapk2.Text);
                btn_laysopk2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Mã này đã được chọn, hãy chọn mã khác!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mapk2.Text = "";
                cbo_mapk2.Focus();
            }
        }

        private void cbo_mapk3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mapk3.Text != cbo_mapk2.Text && cbo_mapk3.Text != cbo_mapk1.Text)
            {
                txt_tenpk3.Text = thucthi.loadtenpk(txt_tenpk3.Text, cbo_mapk3.Text);
                txt_hdpk3.Text = (int.Parse(thucthi.loadhangdoi(cbo_mapk3.Text)) + 1).ToString();
                txt_hhdpk3.Text = thucthi.loadhieuhangdoi(cbo_mapk3.Text);
                btn_laysopk3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Mã này đã được chọn, hãy chọn mã khác!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mapk3.Text = "";
                cbo_mapk3.Focus();
            }

        }
    }
}
