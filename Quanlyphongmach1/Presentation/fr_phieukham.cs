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
    public partial class fr_phieukham : Form
    {
        private string maNV;
        private string Key;

        ConnectDB cn = new ConnectDB();

        E_tb_Phieukham thucthi_pk = new E_tb_Phieukham();
        EC_tb_Phieukham ck_pk = new EC_tb_Phieukham();

        
        int dong_bn = 0;

        
        public fr_phieukham()
        {
            InitializeComponent();
        }
        //Răng - Hàm - Mặt
        //Tai - Mũi - Họng
        //Tim Mạch
        //Da Liễu
        //Nội Tiêu Hóa
        //Chỉnh Hình

        public fr_phieukham(string manv, string key)
        {
            InitializeComponent();
            maNV = manv;
            Key = key;
        }
        //
        // ------------------->>>[Các hàm tạo]
        //
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        public void setnull_pk1()
        {
            DateTime date = DateTime.Now;
            string d1, d2, d3;
            int val = thucthi_pk.demsophieukham_inday(date, maNV) + 1;
            if (date.Day < 10)
                d1 = "0" + date.Day.ToString();
            else
                d1 = date.Day.ToString();
            if (date.Month < 10)
                d2 = "0" + date.Month.ToString();
            else
                d2 = date.Month.ToString();
            if (val < 10)
                d3 = "#000" + val.ToString();
            else
            {
                if (val < 100)
                    d3 = "#00" + val.ToString();
                else
                {
                    if (val < 1000)
                        d3 = "#0" + val.ToString();
                    else
                        d3 = "#" + val.ToString();
                }
            }

            txt_pkma.Text = d1 + d2 + thucthi_pk.load_maPGKH(maNV) + d3;
            txt_pkchuandoan.Text = "";
            dtm_pkngay.Text = DateTime.Now.ToShortTimeString();
            chk_kt.Checked = false;
            chk_kt.Checked = false;
            chk_kt.Checked = false;
        }
        public void setnull_pk()
        {
            txt_pkma.Text = "" ;
            txt_pkchuandoan.Text = "";
            dtm_pkngay.Text = DateTime.Now.ToShortTimeString();

            chk_kt.Checked = false;
            chk_kt.Checked = false;
            chk_kt.Checked = false;
        }
        public void setnull_bn()
        {
            txt_bnchuandoan.Text = "";
            txt_bngioitinh.Text = "";
            txt_bnhoten.Text = "";
            txt_bnma.Text = "";
            txt_bnsocmnd.Text = "";
            txt_bntuoi.Text = "";


        }
        public void locktext_pk()
        {
            
            txt_pkchuandoan.Enabled = false;
            

            chk_kt.Enabled = false;
            chk_pkkedon.Enabled = false;
            chk_sc.Enabled = false;

            btn_pkthemdonthuoc.Enabled = false;
            btn_pkthemctkt.Enabled = false;
            btn_pkthemctsc.Enabled = false;

            btn_pkin.Enabled = false;
            btn_pkluu.Enabled = false;
            
        }
        
        public void un_locktext_pk()
        {
            
            txt_pkchuandoan.Enabled = true;
            

            chk_kt.Enabled = true;
            chk_pkkedon.Enabled = true;
            chk_sc.Enabled = true;
            
            btn_pkin.Enabled = true;
            btn_pkluu.Enabled = true;
            
        }
        
        public void khoitaoluoi_bn()
        {
            
            dgv_bnds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bnds.Columns[0].HeaderText = "Số thứ tự";
            dgv_bnds.Columns[0].Frozen = true;
            dgv_bnds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_bnds.Columns[0].Width = 150;
            dgv_bnds.Columns[1].HeaderText = "Mã bệnh nhân";
            dgv_bnds.Columns[1].Width = 200;
            dgv_bnds.Columns[2].HeaderText = "Tên bệnh nhân";
            dgv_bnds.Columns[2].Width = 150;
            dgv_bnds.Columns[3].HeaderText = "Tuổi";
            dgv_bnds.Columns[3].Width = 150;
            dgv_bnds.Columns[4].HeaderText = "Giới tính";
            dgv_bnds.Columns[4].Width = 150;
            dgv_bnds.Columns[5].HeaderText = "Số CMND";
            dgv_bnds.Columns[5].Width = 150;
            dgv_bnds.Columns[6].HeaderText = "Chuẩn đoán bênh nhân";
            dgv_bnds.Columns[6].Width = 150;
            dgv_bnds.Columns[7].HeaderText = "Mã phòng khám";
            dgv_bnds.Columns[7].Width = 150;

        }
        
        public void hienthi_bn( string key)
        {
            string sql = "SELECT STTPhongKham, MaBenhNhan, HoTenBenhNhan, Tuoi, GioiTinh, SoCMND, ChuanDonSoLuot, MaPhongKham FROM dbo.BENHNHAN_TAM WHERE MaPhongKham = '" + key + "'";
            dgv_bnds.DataSource = cn.taobang(sql);
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

        private void dgv_bnds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong_bn = e.RowIndex;
            //txt_mabenhnhan.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
            txt_bnma.Text = dgv_bnds.Rows[dong_bn].Cells[1].Value.ToString();
            txt_bnhoten.Text = dgv_bnds.Rows[dong_bn].Cells[2].Value.ToString();
            txt_bntuoi.Text = dgv_bnds.Rows[dong_bn].Cells[3].Value.ToString();
            txt_bngioitinh.Text = dgv_bnds.Rows[dong_bn].Cells[4].Value.ToString();
            txt_bnsocmnd.Text = dgv_bnds.Rows[dong_bn].Cells[5].Value.ToString();
            txt_bnchuandoan.Text = dgv_bnds.Rows[dong_bn].Cells[6].Value.ToString();


        }
       


        //private void txt_ktsolansd_TextChanged(object sender, EventArgs e)
        //{
        //    if(cbo_ktmadv.Text!="")
        //    {
        //        MessageBox.Show("Mã dịch vụ còn trống", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        cbo_ktmadv.Focus();
        //    }
        //    else
        //    {
        //        string sql = "SELECT ChiPhiSuDungDV FROM dbo.DICHVUKYTHUATYTE WHERE MaDVKyThuat = '" + cbo_ktmadv.Text + "'";
        //        txt_ktphisd.Text = (int.Parse(txt_ktsolansd.Text) * int.Parse(cn.LoadLable(sql))).ToString();
        //    }
        //}

        
        

        private int load_sohangdoi()
        {
            return int.Parse(cn.LoadLable("SELECT HangDoi FROM dbo.PHONGKHAM WHERE MaPhongKham='" + thucthi_pk.load_maPGKH(maNV) + "'"));
        }
        private int load_sohieuhangdoi()
        {
            return int.Parse(cn.LoadLable("SELECT HieuHangDoi FROM dbo.PHONGKHAM WHERE MaPhongKham='" + thucthi_pk.load_maPGKH(maNV) + "'"));
        }
        // tính tổng tiền sử dụng dịch vụ kỹ thuật
        private int tinhtongtienDSkt()
        {
            if (!thucthi_pk.kiemtramapukh_ctkt(txt_pkma.Text))
                return 0;
            else
            {
                return cn.ExecuteScalar("SELECT SUM(ThanhTien) FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + txt_pkma.Text + "'");
            }
        }
        // tính tổng tiền sử dụng dịch vụ sơ cứu
        private int tinhtongtienDSsc()
        {
            if (!thucthi_pk.kiemtramapukh_ctsc(txt_pkma.Text))
                return 0;
            else
            {
                return cn.ExecuteScalar("SELECT SUM(ThanhTien) FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + txt_pkma.Text + "'");
            }
        }
        // Tính tổng tiền toa thuốc khám
        private int tinhtongtienDStoathuoc()
        {
            if (!thucthi_pk.kiemtramapukh_cttt(txt_pkma.Text))
                return 0;
            else
            {
                return cn.ExecuteScalar("SELECT SUM(ThanhTien) FROM dbo.CHITIETTOATHUOCKHAM WHERE MaPhieuKham = '" + txt_pkma.Text + "'");
            }
        }
        //
        // ------------------->>>[Các hàm xử lý sự kiện]
        //
        private void fr_phieukham_Load(object sender, EventArgs e)
        {
            setnull_pk();
            setnull_bn();
            locktext_pk();
            // load Lable
            lb_title.Text = "Phiếu Khám " + Key;
            lb_sohangdoi.Text = "Tổng số hàng đợi: " + load_sohangdoi().ToString();
            lb_stting.Text = "STT đang được điều trị:" + load_sohieuhangdoi().ToString();
            //hiển thị danh sách bệnh nhân với phòng khám đang thự thi
            hienthi_bn(thucthi_pk.load_maPGKH(maNV));
            // load thông tin của bác sĩ
            txt_bscv.Text = thucthi_pk.load_tenchucvu(maNV);
            txt_bsemail.Text = thucthi_pk.load_emailBS(maNV);
            txt_bsma.Text = maNV;
            txt_bsmapgkh.Text = thucthi_pk.load_maPGKH(maNV);
            txt_bssdt.Text = thucthi_pk.load_sdtnBS(maNV);
            txt_bsten.Text = thucthi_pk.load_hotenBS(maNV);
            //
            
            
            
        }
        

        // Xử lý sự kiện Thêm - In - Lưu Phiếu khám
        // Bắt đầu
        private void txt_bnma_TextChanged(object sender, EventArgs e)
        {
            setnull_pk1();
            un_locktext_pk();
           
            txt_pkchuandoan.Focus();
        }

        private void btn_pkluu_Click(object sender, EventArgs e)
        {
            if(txt_pkma.Text!= ""&& txt_pkchuandoan.Text!=""&& btn_pkin.Enabled==false)
            {
                if (chk_pkkedon.Checked == true && !thucthi_pk.kiemtramapukh_cttt(txt_pkma.Text))
                {
                    if (MessageBox.Show("Nhập thông tin chi tiết kê đơn toa thuốc?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Form frm = kiemtratontai(typeof(fr_chitiettoathuockham));
                        if (frm != null)
                            frm.Activate();
                        else
                        {
                            fr_chitiettoathuockham fr = new fr_chitiettoathuockham(txt_pkma.Text);
                            fr.ShowDialog();
                        }
                    }
                    else
                        chk_pkkedon.Checked = false;
                }
                if (chk_kt.Checked == true && !thucthi_pk.kiemtramapukh_ctkt(txt_pkma.Text))
                {
                    if (MessageBox.Show("Nhập thông tin chi tiết dịch vụ kỹ thuật?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Form frm = kiemtratontai(typeof(fr_chitietdvkythuatyte));
                        if (frm != null)
                            frm.Activate();
                        else
                        {
                            fr_chitietdvkythuatyte fr = new fr_chitietdvkythuatyte(txt_pkma.Text);
                            fr.ShowDialog();
                        }
                    }
                    else
                        chk_kt.Checked = false;
                }
                if (chk_sc.Checked == true && !thucthi_pk.kiemtramapukh_ctsc(txt_pkma.Text))
                {
                    if (MessageBox.Show("Nhập thông tin chi tiết dịch vụ sơ cứu?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Form frm = kiemtratontai(typeof(fr_chitietdvsocuutaicho));
                        if (frm != null)
                            frm.Activate();
                        else
                        {
                            fr_chitietdvsocuutaicho fr = new fr_chitietdvsocuutaicho(txt_pkma.Text);
                            fr.ShowDialog();
                        }
                    }
                    else
                        chk_sc.Checked = false;
                }
                // bắt đầu sử lý lưu
                try
                {
                    ck_pk.MAPHIEUKHAM = txt_pkma.Text;
                    ck_pk.MAHNHANVIEN = txt_bsma.Text;
                    ck_pk.MABENHNHAN = txt_bnma.Text;
                    ck_pk.NGAYKHAM = dtm_pkngay.Value.ToLongDateString();
                    ck_pk.CHUANDOANBENH = txt_pkchuandoan.Text;

                    if (chk_pkkedon.Checked == true)
                    {
                        ck_pk.KEDONTHUOC = "Có";
                        ck_pk.TONGTIENTHUOC = tinhtongtienDStoathuoc().ToString();
                    }
                    else
                    {
                        ck_pk.KEDONTHUOC = "Không";
                        ck_pk.TONGTIENTHUOC = "0";
                    }

                    if (chk_kt.Checked == true)
                    {
                        ck_pk.SUDUNGDVKYTHUATYTE = "Có";
                        ck_pk.TONGTIENDVKYTHUAT = tinhtongtienDSkt().ToString();
                    }
                    else
                    {
                        ck_pk.SUDUNGDVKYTHUATYTE = "Không";
                        ck_pk.TONGTIENDVKYTHUAT = "0";
                    }

                    if (chk_sc.Checked == true)
                    {
                        ck_pk.SUDUNGDVSOCUU = "Có";
                        ck_pk.TONGTIENDVSOCUU = tinhtongtienDSsc().ToString();
                    }
                    else
                    {
                        ck_pk.SUDUNGDVSOCUU = "Không";
                        ck_pk.TONGTIENDVSOCUU = "0";
                    }

                    thucthi_pk.themmoi(ck_pk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // tăng hiệu hàng đợi lên 1
                thucthi_pk.sua_hhd(thucthi_pk.load_maPGKH(maNV), (load_sohieuhangdoi() + 1).ToString());
                // xóa bệnh nhân trong danh sách tạm với mã phòng khám hiện tại
                thucthi_pk.xoa_bn(txt_bnma.Text, thucthi_pk.load_maPGKH(maNV));
                // hiển thị lại danh sách bệnh nhân
                hienthi_bn(thucthi_pk.load_maPGKH(maNV));
                // load  lại 2 lable
                lb_sohangdoi.Text = "Tổng số hàng đợi: " + load_sohangdoi().ToString();
                lb_stting.Text = "STT đang được điều trị:" + load_sohieuhangdoi().ToString();
                setnull_bn();
                setnull_pk();
                locktext_pk();
            }
            else
            {
                if (txt_pkma.Text == "")
                {
                    MessageBox.Show("Mã phiếu khám không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_pkma.Focus();
                }
                else
                {
                    if (txt_pkchuandoan.Text == "")
                    {
                        MessageBox.Show("Thông tin chuẩn đoán bệnh nhân không được để trống!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_pkma.Focus();
                    }
                    else
                    {
                        if (btn_pkin.Enabled == true)
                        {
                            MessageBox.Show("Hãy in phiếu khám trước khi lưu!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }

        }

        private void btn_pkin_Click(object sender, EventArgs e)
        {
            btn_pkin.Enabled = false;
        }
        // Kết thúc

        // sự kiên CheckBox change
        // Bắt đầu
        private void chk_pkkedon_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_pkkedon.Checked==true)
            {
                btn_pkthemdonthuoc.Enabled = true;
            }
            else
            {
                if (!thucthi_pk.kiemtramapukh_cttt(txt_pkma.Text))
                {
                    chk_pkkedon.Checked = false;
                }
                else
                {
                    if (MessageBox.Show("Xóa dữ liệu toa thuốc đã nhập không?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        thucthi_pk.xoa_("CHITIETTOATHUOCKHAM", txt_pkma.Text);
                        chk_pkkedon.Checked = false;
                    }
                    else
                        chk_pkkedon.Checked = true;
                }
                // true ---> false
                // kiểm tra dữ liệu trong bảng chi tiết toa thuốc

                // nếu có dữ liệu thì thông báo mess " Có muốn xóa dữ liệu đơn thuốc đã nhập không"
                // nếu có ---> thực hiện xóa
                // nếu không vẫn để checkBox = true
            }

        }

        private void chk_kt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_kt.Checked == true)
            {
                btn_pkthemctkt.Enabled = true;
            }
            else
            {
                if (!thucthi_pk.kiemtramapukh_ctkt(txt_pkma.Text))
                {
                    chk_kt.Checked = false;
                }
                else
                {
                    if (MessageBox.Show("Xóa dữ liệu sử dụng dịch vụ kỹ thuật y tế đã nhập không?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        thucthi_pk.xoa_("CHITIETDVKYTHUATYTE", txt_pkma.Text);
                        chk_kt.Checked = false;
                    }
                    else
                        chk_kt.Checked = true;
                }
            }
        }

        private void chk_sc_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sc.Checked == true)
            {
                btn_pkthemctsc.Enabled = true;
            }
            else
            {
                if (!thucthi_pk.kiemtramapukh_ctsc(txt_pkma.Text))
                {
                    chk_sc.Checked = false;
                }
                else
                {
                    if (MessageBox.Show("Xóa dữ liệu sử dụng dịch vụsơ cứu đã nhập không?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        thucthi_pk.xoa_("CHITIETDVSOCUUTAICHO", txt_pkma.Text);
                        chk_sc.Checked = false;
                    }
                    else
                        chk_sc.Checked = true;
                }
            }
        }
        //Kết thúc

        // Sự kiện xử lý lập đơn thuốc
        private void btn_pkthemdonthuoc_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chitiettoathuockham));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chitiettoathuockham fr = new fr_chitiettoathuockham(txt_pkma.Text);
                fr.ShowDialog();
            }
        }

        private void fr_phieukham_Activated(object sender, EventArgs e)
        {
            
        }

        private void btn_pkthemctkt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chitietdvkythuatyte));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chitietdvkythuatyte fr = new fr_chitietdvkythuatyte(txt_pkma.Text);
                fr.ShowDialog();
            }
        }

        private void btn_pkthemctsc_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chitietdvsocuutaicho));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chitietdvsocuutaicho fr = new fr_chitietdvsocuutaicho(txt_pkma.Text);
                fr.ShowDialog();
            }
        }

        private void btn_bnxemlichsu_Click(object sender, EventArgs e)
        {
            if(txt_bnsocmnd.Text!="")
            {
                Form frm = kiemtratontai(typeof(Admin.fr_admin_xemlichsu));
                if (frm != null)
                    frm.Activate();
                else
                {
                    Admin.fr_admin_xemlichsu fr = new Admin.fr_admin_xemlichsu(txt_bnsocmnd.Text);
                    fr.ShowDialog();
                }
            }
        }

        private void txt_bnsocmnd_TextChanged(object sender, EventArgs e)
        {
            btn_bnxemlichsu.Enabled = true;
        }
    }

}
