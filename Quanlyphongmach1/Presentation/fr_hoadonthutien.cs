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
    public partial class fr_hoadonthutien : Form
    {
        private string sumThuoc, sumDvsc, sumDvkt;
        public fr_hoadonthutien()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        EC_tb_Hoadonthutien ck = new EC_tb_Hoadonthutien();
        E_tb_Hoadonthutien thucthi = new E_tb_Hoadonthutien();
        int dong = 0;
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }
        private void setnull()
        {
            // Bệnh nhân
            txt_bnchuandoan.Text = "";
            txt_bngioitinh.Text = "";
            txt_bnhoten.Text = ""; ;
            txt_bnma.Text = ""; 
            txt_bnsocmnd.Text = "";
            txt_bntuoi.Text = "";
            // Phiếu khám
            txt_1tenbs.Text = "";
            txt_1chuandoan.Text = "";
            txt_2tenbs.Text = "";
            txt_2chuandoan.Text = "";
            txt_3tenbs.Text = "";
            txt_3chuandoan.Text = "";
            chk_1kedon.Checked = false;
            chk_1kt.Checked = false;
            chk_1sc.Checked = false;
            chk_2kedon.Checked = false;
            chk_2kt.Checked = false;
            chk_2sc.Checked = false;
            chk_3kedon.Checked = false;
            chk_3kt.Checked = false;
            chk_3sc.Checked = false;
            lb_1tiendvkt.Text = "0";
            lb_1tiendvsc.Text = "0";
            lb_1tienkedon.Text = "0";
            lb_2tiendvkt.Text = "0";
            lb_2tiendvsc.Text = "0";
            lb_2tienkedon.Text = "0";
            lb_3tiendvkt.Text = "0";
            lb_3tiendvsc.Text = "0";
            lb_3tienkedon.Text = "0";
            // Hóa đơn
            txt_hdma.Text = "";
            txt_hdtien.Text = "";
            txt_hdtienkham.Text = "30000";

        }

        private void locktext()
        {
            txt_hdtienkham.Enabled = false;
            btn_hdin.Enabled = false;
            btn_hdluu.Enabled = false;
            btn_hdxdt.Enabled = false;
            btn_hdxkt.Enabled = false;
            btn_hdxsc.Enabled = false;
        }
        private void un_locktext()
        {
            txt_hdtienkham.Enabled = true;
            btn_hdin.Enabled = true;
            btn_hdluu.Enabled = true;
            btn_hdxdt.Enabled = true;
            btn_hdxkt.Enabled = true;
            btn_hdxsc.Enabled = true;
        }
        public void khoitaoluoi()
        {
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].HeaderText = "Mã bệnh nhân";
            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].HeaderText = "Tên bệnh nhân";
            dgv.Columns[1].Width = 180;
            dgv.Columns[2].HeaderText = "Tuổi";
            dgv.Columns[2].Width = 70;
            dgv.Columns[3].HeaderText = "Giới tính";
            dgv.Columns[3].Width = 70;
            dgv.Columns[4].HeaderText = "Số CMND";
            dgv.Columns[4].Width = 150;
            dgv.Columns[5].HeaderText = "Địa chỉ";
            dgv.Columns[5].Width = 150;
            dgv.Columns[6].HeaderText = "Chuẩn đoán sơ bộ";
            dgv.Columns[6].Width = 150;
            dgv.Columns[7].HeaderText = "Ngày khám";
            dgv.Columns[7].Width = 80;
            dgv.Columns[8].HeaderText = "Mã phòng khám 1";
            dgv.Columns[8].Width = 100;
            dgv.Columns[9].HeaderText = "STT PHK1";
            dgv.Columns[9].Width = 80;
            dgv.Columns[10].HeaderText = "Mã phòng khám 2";
            dgv.Columns[10].Width = 100;
            dgv.Columns[11].HeaderText = "STT PHK2";
            dgv.Columns[11].Width = 80;
            dgv.Columns[12].HeaderText = "Mã phòng khám 3";
            dgv.Columns[12].Width = 100;
            dgv.Columns[13].HeaderText = "STT PHK3";
            dgv.Columns[13].Width = 80;

        }
        public void hienthi()
        {
            string sql = "SELECT MaBenhNhan,HoTenBenhNhan,Tuoi,GioiTinh,SoCMND,DiaChi,ChuanDonSoLuot,NgayKhamBenh,MaPhongKham1,STTPhongKham1,MaPhongKham2,STTPhongKham2,MaPhongKham3,STTPhongKham3 FROM dbo.BENHNHAN WHERE ThuVienPhi = N'Chưa thu'";
            dgv.DataSource = cn.taobang(sql);

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
            dgv.DataSource = cn.taobang(sql);

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
        private void fr_hoadonthutien_Load(object sender, EventArgs e)
        {
            setnull();
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            hienthi_(txt_search.Text);
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                txt_bnma.Text = dgv.Rows[dong].Cells[0].Value.ToString();
                txt_bnhoten.Text = dgv.Rows[dong].Cells[1].Value.ToString();
                txt_bntuoi.Text = dgv.Rows[dong].Cells[2].Value.ToString();
                txt_bngioitinh.Text = dgv.Rows[dong].Cells[3].Value.ToString();
                txt_bnsocmnd.Text = dgv.Rows[dong].Cells[4].Value.ToString();
                txt_bnchuandoan.Text = dgv.Rows[dong].Cells[6].Value.ToString();

                string sql1 = "SELECT MaPhieuKham FROM dbo.PHIEUKHAM WHERE MaBenhNhan = N'" + txt_bnma.Text + "'";
                DataTable ds_maBn = cn.taobang(sql1);
                int countPukh = ds_maBn.Rows.Count;
                switch (countPukh)
                {
                    case 0:
                        {
                            MessageBox.Show("Bệnh nhân không có phiếu khám!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case 1:
                        {
                            string maphieukham1 = ds_maBn.Rows[0].ItemArray[0].ToString();

                            ck.MAPHIEUKHAM1 = maphieukham1;
                            ck.MAPHIEUKHAM2 = "null";
                            ck.MAPHIEUKHAM3 = "null";

                            grb_1.Text = "Thông tin phiếu khám 1: " + maphieukham1;
                            txt_1tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham1));
                            txt_1chuandoan.Text = thucthi.Load_chuandoan(maphieukham1);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham1) == "Không")
                            {
                                chk_1kedon.Checked = false;
                                lb_1tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_1kedon.Checked = true;
                                lb_1tienkedon.Text = thucthi.Load_tienkedon(maphieukham1);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham1) == "Không")
                            {
                                chk_1kt.Checked = false;
                                lb_1tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_1kt.Checked = true;
                                lb_1tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham1);
                            }
                            // load CheckBox DVSC
                            if (thucthi.Load_chkdvsc(maphieukham1) == "Không")
                            {
                                chk_1sc.Checked = false;
                                lb_1tiendvsc.Text = "0";
                            }
                            else
                            {
                                chk_1sc.Checked = true;
                                lb_1tiendvsc.Text = thucthi.Load_tiendvkt(maphieukham1);
                            }
                            break;
                        }
                    case 2:
                        {
                            string maphieukham1 = ds_maBn.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maBn.Rows[1].ItemArray[0].ToString();

                            ck.MAPHIEUKHAM1 = maphieukham1;
                            ck.MAPHIEUKHAM2 = maphieukham2;
                            ck.MAPHIEUKHAM3 = "null";

                            grb_1.Text = "Thông tin phiếu khám 1: " + maphieukham1;
                            txt_1tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham1));
                            txt_1chuandoan.Text = thucthi.Load_chuandoan(maphieukham1);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham1) == "Không")
                            {
                                chk_1kedon.Checked = false;
                                lb_1tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_1kedon.Checked = true;
                                lb_1tienkedon.Text = thucthi.Load_tienkedon(maphieukham1);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham1) == "Không")
                            {
                                chk_1kt.Checked = false;
                                lb_1tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_1kt.Checked = true;
                                lb_1tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham1);
                            }

                            grb_2.Text = "Thông tin phiếu khám 2: " + maphieukham2;
                            txt_2tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham2));
                            txt_2chuandoan.Text = thucthi.Load_chuandoan(maphieukham2);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham2) == "Không")
                            {
                                chk_2kedon.Checked = false;
                                lb_2tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_2kedon.Checked = true;
                                lb_2tienkedon.Text = thucthi.Load_tienkedon(maphieukham2);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham2) == "Không")
                            {
                                chk_2kt.Checked = false;
                                lb_2tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_2kt.Checked = true;
                                lb_2tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham2);
                            }
                            // load CheckBox DVSC
                            if (thucthi.Load_chkdvsc(maphieukham2) == "Không")
                            {
                                chk_2sc.Checked = false;
                                lb_2tiendvsc.Text = "0";
                            }
                            else
                            {
                                chk_2sc.Checked = true;
                                lb_2tiendvsc.Text = thucthi.Load_tiendvkt(maphieukham2);
                            }
                            break;
                        }
                    case 3:
                        {
                            string maphieukham1 = ds_maBn.Rows[0].ItemArray[0].ToString(), maphieukham2 = ds_maBn.Rows[1].ItemArray[0].ToString(), maphieukham3 = ds_maBn.Rows[2].ItemArray[0].ToString();

                            ck.MAPHIEUKHAM1 = maphieukham1;
                            ck.MAPHIEUKHAM2 = maphieukham2;
                            ck.MAPHIEUKHAM3 = maphieukham3;


                            grb_1.Text = "Thông tin phiếu khám 1: " + maphieukham1;
                            txt_1tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham1));
                            txt_1chuandoan.Text = thucthi.Load_chuandoan(maphieukham1);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham1) == "Không")
                            {
                                chk_1kedon.Checked = false;
                                lb_1tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_1kedon.Checked = true;
                                lb_1tienkedon.Text = thucthi.Load_tienkedon(maphieukham1);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham1) == "Không")
                            {
                                chk_1kt.Checked = false;
                                lb_1tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_1kt.Checked = true;
                                lb_1tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham1);
                            }

                            grb_2.Text = "Thông tin phiếu khám 2: " + maphieukham2;
                            txt_2tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham2));
                            txt_2chuandoan.Text = thucthi.Load_chuandoan(maphieukham2);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham2) == "Không")
                            {
                                chk_2kedon.Checked = false;
                                lb_2tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_2kedon.Checked = true;
                                lb_2tienkedon.Text = thucthi.Load_tienkedon(maphieukham2);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham2) == "Không")
                            {
                                chk_2kt.Checked = false;
                                lb_2tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_2kt.Checked = true;
                                lb_2tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham2);
                            }
                            // load CheckBox DVSC
                            if (thucthi.Load_chkdvsc(maphieukham2) == "Không")
                            {
                                chk_2sc.Checked = false;
                                lb_2tiendvsc.Text = "0";
                            }
                            else
                            {
                                chk_2sc.Checked = true;
                                lb_2tiendvsc.Text = thucthi.Load_tiendvkt(maphieukham2);
                            }

                            grb_3.Text = "Thông tin phiếu khám 3: " + maphieukham3;
                            txt_3tenbs.Text = thucthi.Load_tenbs(thucthi.Load_mabs(maphieukham3));
                            txt_3chuandoan.Text = thucthi.Load_chuandoan(maphieukham3);
                            // load CheckBox đơn thuốc
                            if (thucthi.Load_chkkedon(maphieukham3) == "Không")
                            {
                                chk_3kedon.Checked = false;
                                lb_3tienkedon.Text = "0";
                            }
                            else
                            {
                                chk_3kedon.Checked = true;
                                lb_3tienkedon.Text = thucthi.Load_tienkedon(maphieukham3);
                            }
                            // load CheckBox DVKT
                            if (thucthi.Load_chkdvkt(maphieukham3) == "Không")
                            {
                                chk_3kt.Checked = false;
                                lb_3tiendvkt.Text = "0";
                            }
                            else
                            {
                                chk_3kt.Checked = true;
                                lb_3tiendvkt.Text = thucthi.Load_tiendvkt(maphieukham3);
                            }
                            // load CheckBox DVSC
                            if (thucthi.Load_chkdvsc(maphieukham3) == "Không")
                            {
                                chk_3sc.Checked = false;
                                lb_3tiendvsc.Text = "0";
                            }
                            else
                            {
                                chk_3sc.Checked = true;
                                lb_3tiendvsc.Text = thucthi.Load_tiendvkt(maphieukham3);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                ck.TIENKHAM = txt_hdtienkham.Text;

                int tienthuoc, tienkt, tiensc, tongtien;
                tienthuoc = int.Parse(lb_1tienkedon.Text) + int.Parse(lb_2tienkedon.Text) + int.Parse(lb_3tienkedon.Text);
                tienkt = int.Parse(lb_1tiendvkt.Text) + int.Parse(lb_2tiendvkt.Text) + int.Parse(lb_3tiendvkt.Text);
                tiensc = int.Parse(lb_1tiendvsc.Text) + int.Parse(lb_2tiendvsc.Text) + int.Parse(lb_3tiendvsc.Text);
                tongtien = tienthuoc + tienkt + tiensc + int.Parse(txt_hdtienkham.Text);
                txt_hdtien.Text = tongtien.ToString();
                ck.TIENTHUOC = tienthuoc.ToString();
                sumThuoc = tienthuoc.ToString();
                ck.TIENSUDUNGDVKYTHUATYTE = tienkt.ToString();
                sumDvkt = tienkt.ToString();
                ck.TIENSUDUNGDVSOCUU = tiensc.ToString();
                sumDvsc = tiensc.ToString();
                ck.TONGTIEN = txt_hdtien.Text;
                ck.NGAYLAPHOADON = DateTime.Now.ToString();
                ck.MAHOADONTHUTIEN = txt_hdma.Text;
                ck.MABENHNHAN = txt_bnma.Text;
            }
            
        }

        private void btn_hdin_Click(object sender, EventArgs e)
        {
            btn_hdin.Enabled = false;
        }

        private void btn_hdluu_Click(object sender, EventArgs e)
        {
            if(txt_hdtienkham.Text != ""&& btn_hdin.Enabled==false)
            {
                thucthi.themmoi(ck);
                thucthi.sua_Bn(txt_bnma.Text);

                hienthi();
                setnull();
                locktext();

            }
            else
            {
                if(txt_hdtienkham.Text == "")
                {
                    MessageBox.Show("Tiền khám không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_hdtienkham.Focus();
                }
                else
                {
                    if(btn_hdin.Enabled ==true)
                    {
                        MessageBox.Show("Chưa in hóa đơn!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_hdin.Focus();
                    }
                }
            }
        }

        private void btn_hdxdt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_hoadonchitiet));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_hoadonchitiet fr = new fr_hoadonchitiet(txt_bnma.Text, "1", sumThuoc);
                fr.ShowDialog();
            }
        }

        private void txt_bnhoten_TextChanged(object sender, EventArgs e)
        {
            un_locktext();
            DateTime date = DateTime.Now;
            string d1, d2, d3;
            int val = thucthi.demsohoadon_inday(date) + 1;
            // thiết lập ngày
            if (date.Day < 10)
                d1 = "0" + date.Day.ToString();
            else
                d1 = date.Day.ToString();
            // thiết lập tháng
            if (date.Month < 10)
                d2 = "0" + date.Month.ToString();
            else
                d2 = date.Month.ToString();
            // thiết lập số đếm
            if (val < 10)
                d3 = "@SHD000" + val.ToString();
            else
            {
                if (val < 100)
                    d3 = "@SHD00" + val.ToString();
                else
                {
                    if (val < 1000)
                        d3 = "@SHD0" + val.ToString();
                    else
                        d3 = "@SHD" + val.ToString();
                }
            }

            txt_hdma.Text = d1 + d2 + date.Year.ToString() + d3;
        }

        private void btn_hdxkt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_hoadonchitiet));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_hoadonchitiet fr = new fr_hoadonchitiet(txt_bnma.Text, "2", sumDvkt);
                fr.ShowDialog();
            }
        }

        private void btn_hdxsc_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_hoadonchitiet));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_hoadonchitiet fr = new fr_hoadonchitiet(txt_bnma.Text, "3", sumDvsc);
                fr.ShowDialog();
            }
        }
    }
}
