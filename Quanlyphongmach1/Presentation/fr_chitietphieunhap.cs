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
    public partial class fr_chitietphieunhap : Form
    {
        private string keypnh;
        public fr_chitietphieunhap()
        {
            InitializeComponent();
        }

        E_tb_Chitietphieunhap thucthi = new E_tb_Chitietphieunhap();
        ConnectDB cn = new ConnectDB();
        EC_tb_Chitietphieunhap ck = new EC_tb_Chitietphieunhap();
        
        bool themmoi;
        int dong = 0;

        //Load thông tin phiếu nhập hàng
        public fr_chitietphieunhap(string Message) : this()
        {
            txt_ttmaphieu.Text = Message;
            keypnh = Message;
        }
        

        public void setnull()
        {
            cbo_maldp.Text = "";
            txt_tttenldp.Text = "";

            cbo_ma.Text = "";
            txt_ten.Text = "";
            txt_sl.Text = "";
            txt_cd.Text = "";
            cbo_dv.Text = "";
            txt_gianhap.Text = "";
            dtm_ngay.Text = DateTime.Now.ToShortTimeString();

        }
        public void locktext()
        {
            cbo_maldp.Enabled = false;
            cbo_ma.Enabled = false;
            txt_ten.Enabled = false;
            txt_cd.Enabled = false;
            cbo_dv.Enabled = false;
            txt_sl.Enabled = false;
            dtm_ngay.Enabled = false;
            txt_gianhap.Enabled = false;
            
            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;

        }
        public void un_locktext()
        {
            cbo_maldp.Enabled = true;
            cbo_ma.Enabled = true;
            txt_ten.Enabled = true;
            txt_cd.Enabled = true;
            cbo_dv.Enabled = true;
            txt_sl.Enabled = true;
            dtm_ngay.Enabled = true;
            txt_gianhap.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private int kiemtranull()
        {
            if (cbo_maldp.Text == "")
                return 1;
            if (cbo_ma.Text == "")
                return 2;
            if (txt_ten.Text == "")
                return 3;
            if (txt_cd.Text == "")
                return 4;
            if (cbo_dv.Text == "")
                return 5;
            if (dtm_ngay.Text == "")
                return 6;
            if (txt_gianhap.Text == "")
                return 7;
            if (txt_sl.Text == "")
                return 8;
            return 0;
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã loại dược phẩm";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Mã phiếu nhập hàng";
            dgv_ds.Columns[1].Width = 150;
            dgv_ds.Columns[2].HeaderText = "Mã mặt hàng";
            dgv_ds.Columns[2].Width = 150;
            dgv_ds.Columns[3].HeaderText = "Tên mặt hàng";
            dgv_ds.Columns[3].Width = 150;
            dgv_ds.Columns[4].HeaderText = "Đơn vị";
            dgv_ds.Columns[4].Width = 150;
            dgv_ds.Columns[5].HeaderText = "Công dụng";
            dgv_ds.Columns[5].Width = 150;
            dgv_ds.Columns[6].HeaderText = "Ngày nhập";
            dgv_ds.Columns[6].Width = 150;
            dgv_ds.Columns[7].HeaderText = "Giá nhập";
            dgv_ds.Columns[7].Width = 150;
            dgv_ds.Columns[8].HeaderText = "Số lượng";
            dgv_ds.Columns[8].Width = 150;

        }
        public void hienthi(string key)
        {
            string sql = "SELECT MaLoaiDuocPham, MaPhieuNhapHang, MaHangNhap, TenHangNhap, DonVi, CongDung, NgayNhap, GiaNhap, SoLuongNhap FROM dbo.CHITIETPHIEUNHAP_TAM where MaPhieuNhapHang ='"+ key +"'";
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
            txt_soluongda.Text = thucthi.demsodanhmucdanhap(key).ToString();

        }

        

        private void fr_chitietphieunhap_Load(object sender, EventArgs e)
        {
            //load dữ liệu lên ComboBox
            thucthi.load_mahangnhap(cbo_ma);
            thucthi.load_donvi(cbo_dv);
            thucthi.load_maldp(cbo_maldp);


            locktext();
            hienthi(keypnh);
            khoitaoluoi();
        }

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            cbo_maldp.Focus();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            cbo_maldp.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MALOAIDUOCPHAM = cbo_maldp.Text;
                    ck.MAPHIEUNHAPHANG = txt_ttmaphieu.Text;
                    ck.MAHANGNHAP = cbo_ma.Text;
                    ck.TENHANGNHAP = txt_ten.Text;
                    ck.DONVI = cbo_dv.Text;
                    ck.CONGDUNG = txt_cd.Text;
                    ck.NGAYNHAP = dtm_ngay.Value.ToString();
                    ck.GIANHAP = txt_gianhap.Text;
                    ck.SOLUONGNHAP = txt_sl.Text;

                    thucthi.xoa(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    hienthi(keypnh);
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtranull();
            switch (key)
            {
                case 0:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MALOAIDUOCPHAM = cbo_maldp.Text;
                                ck.MAPHIEUNHAPHANG = txt_ttmaphieu.Text;
                                ck.MAHANGNHAP = cbo_ma.Text;

                                ck.TENHANGNHAP = txt_ten.Text;
                                ck.DONVI = cbo_dv.Text;
                                ck.CONGDUNG = txt_cd.Text;
                                ck.NGAYNHAP = dtm_ngay.Value.ToString();
                                ck.GIANHAP = txt_gianhap.Text;
                                ck.SOLUONGNHAP = txt_sl.Text;

                                thucthi.themoi(ck);
                                locktext();
                                hienthi(keypnh);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            try
                            {
                                ck.MALOAIDUOCPHAM = cbo_maldp.Text;
                                ck.MAPHIEUNHAPHANG = txt_ttmaphieu.Text;
                                ck.MAHANGNHAP = cbo_ma.Text;

                                ck.TENHANGNHAP = txt_ten.Text;
                                ck.DONVI = cbo_dv.Text;
                                ck.CONGDUNG = txt_cd.Text;
                                ck.NGAYNHAP = dtm_ngay.Value.ToString();
                                ck.GIANHAP = txt_gianhap.Text;
                                ck.SOLUONGNHAP = txt_sl.Text;

                                thucthi.sua(ck);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        locktext();
                        hienthi(keypnh);
                        break;
                    }

                case 1:
                    {
                        MessageBox.Show("Mã loại dược phẩm không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_maldp.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Mã mặt hàng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_ma.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Tên mặt hàng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ten.Focus();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Đơn vị không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_dv.Focus();
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show("Công dụng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_cd.Focus();
                        break;
                    }
                case 6:
                    {
                        MessageBox.Show("Ngày nhập không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        dtm_ngay.Focus();
                        break;
                    }
                case 7:
                    {
                        MessageBox.Show("Giá nhập không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_gianhap.Focus();
                        break;
                    }
                case 8:
                    {
                        MessageBox.Show("Số lượng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_sl.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void dgv_ds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            cbo_maldp.Text=dgv_ds.Rows[dong].Cells[0].Value.ToString();
            cbo_ma.Text = dgv_ds.Rows[dong].Cells[2].Value.ToString();

            txt_ten.Text = dgv_ds.Rows[dong].Cells[3].Value.ToString();
            cbo_dv.Text = dgv_ds.Rows[dong].Cells[4].Value.ToString();
            txt_cd.Text = dgv_ds.Rows[dong].Cells[5].Value.ToString();
            dtm_ngay.Text = dgv_ds.Rows[dong].Cells[6].Value.ToString();
            txt_gianhap.Text = dgv_ds.Rows[dong].Cells[7].Value.ToString();
            txt_sl.Text = dgv_ds.Rows[dong].Cells[8].Value.ToString();
            
            locktext();
        }
        // load mã loại dược phẩm
        private void cbo_maldp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tttenldp.Text = thucthi.load_tenldp(txt_tttenldp.Text, cbo_maldp.Text);
        }
        

        private void txt_gianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_sl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        

        private void cbo_ma_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ten.Text = thucthi.load_tenhangnhap(txt_ten.Text, cbo_ma.Text);
            txt_cd.Text = thucthi.load_congdung(txt_cd.Text, cbo_ma.Text);
            cbo_dv.Text = thucthi.load_donvi(cbo_dv.Text, cbo_ma.Text);
        }

        private void cbo_ma_TextChanged(object sender, EventArgs e)
        {
            txt_ten.Text = thucthi.load_tenhangnhap(txt_ten.Text, cbo_ma.Text);
            txt_cd.Text = thucthi.load_congdung(txt_cd.Text, cbo_ma.Text);
            cbo_dv.Text = thucthi.load_donvi(cbo_dv.Text, cbo_ma.Text);
        }

        
        
        private void txt_ttmaphieu_TextChanged(object sender, EventArgs e)
        {
            txt_ttmancc.Text = thucthi.load_mancc(txt_ttmancc.Text, txt_ttmaphieu.Text);
            txt_ttsl.Text = thucthi.load_soluongdanhmuc(txt_ttsl.Text, txt_ttmaphieu.Text);
            txt_ttngaynhap.Text = thucthi.load_ngaynhap(txt_ttngaynhap.Text, txt_ttmaphieu.Text);
            txt_ttsotien.Text = thucthi.load_sotien(txt_ttsotien.Text, txt_ttmaphieu.Text);
            txt_tttinhtrang.Text = thucthi.load_tinhtrang(txt_tttinhtrang.Text, txt_ttmaphieu.Text);
            txt_soluongcan.Text = thucthi.load_soluongdanhmuc(txt_ttsl.Text, txt_ttmaphieu.Text);
        }

        

        private void btn_luunhaplieu_Click(object sender, EventArgs e)
        {
            EC_tb_Chitietphieunhap ct = new EC_tb_Chitietphieunhap();
            EC_tb_Thuockham tk = new EC_tb_Thuockham();
            EC_tb_Dungcuyte dcyt = new EC_tb_Dungcuyte();
            EC_tb_Duocphamdvytesocuu dpdvsc = new EC_tb_Duocphamdvytesocuu();
            int slda, slcan;
            slda = int.Parse(txt_soluongda.Text.ToString());
            slcan = int.Parse(txt_soluongcan.Text.ToString());
            if (slda > slcan)
            {
                MessageBox.Show("Số lượng danh mục nhập vào nhiều hơn sô lượng cần nhập. Hãy kiểm tra lại!", "Chú Ý", MessageBoxButtons.OK);
                dgv_ds.Focus();
            }
            else
            {
                if(slda < slcan)
                {
                    MessageBox.Show("Số lượng danh mục nhập vào nhỏ hơn sô lượng cần nhập. Hãy kiểm tra lại!", "Chú Ý", MessageBoxButtons.OK);
                    dgv_ds.Focus();
                }
                else
                {
                    for (int i=0;i<slcan;i++)
                    {
                        ct.MAHANGNHAP = dgv_ds.Rows[i].Cells[2].Value.ToString();
                        ct.MALOAIDUOCPHAM = dgv_ds.Rows[i].Cells[0].Value.ToString();
                        ct.MAPHIEUNHAPHANG = dgv_ds.Rows[i].Cells[1].Value.ToString();
                        ct.TENHANGNHAP = dgv_ds.Rows[i].Cells[3].Value.ToString();
                        ct.DONVI = dgv_ds.Rows[i].Cells[4].Value.ToString();
                        ct.CONGDUNG = dgv_ds.Rows[i].Cells[5].Value.ToString();
                        ct.NGAYNHAP = dgv_ds.Rows[i].Cells[6].Value.ToString();
                        ct.GIANHAP = dgv_ds.Rows[i].Cells[7].Value.ToString();
                        ct.SOLUONGNHAP = dgv_ds.Rows[i].Cells[8].Value.ToString();

                        thucthi.themmoi_ct(ct);
                        string tenldp= thucthi.load_tenldp("", dgv_ds.Rows[i].Cells[0].Value.ToString());
                        switch (tenldp)
                        {
                            // lưu vào bảng CHITIETPHIEUKHAM và bảng THUOCKHAM
                            case "Thuốc khám":
                                {
                                    tk.MATHUOCKHAM = dgv_ds.Rows[i].Cells[2].Value.ToString();
                                    tk.MALOAIDUOCPHAM = dgv_ds.Rows[i].Cells[0].Value.ToString();
                                    tk.TENTHUOCKHAM = dgv_ds.Rows[i].Cells[3].Value.ToString();
                                    tk.DONVI = dgv_ds.Rows[i].Cells[4].Value.ToString();
                                    tk.CONGDUNG = dgv_ds.Rows[i].Cells[5].Value.ToString();
                                    tk.GIATHUOCNHAP = dgv_ds.Rows[i].Cells[7].Value.ToString();
                                    tk.NGAYNHAP = dgv_ds.Rows[i].Cells[6].Value.ToString();
                                    tk.SOLUONGCON = dgv_ds.Rows[i].Cells[8].Value.ToString();
                                    tk.TINHTRANGCONSD = "Còn sử dụng";
                                    tk.GIATHUOCBAN = "null";

                                    thucthi.themmoi_thk(tk);
                                    break;
                                }
                            // lưu vào bảng CHITIETPHIEUKHAM và bảng DUNGCUYTE
                            case "Dụng cụ y tế":
                                {
                                    dcyt.MADUNGCUYTE = dgv_ds.Rows[i].Cells[2].Value.ToString();
                                    dcyt.MALOAIDUOCPHAM = dgv_ds.Rows[i].Cells[0].Value.ToString();
                                    dcyt.TENDUNGCUYTE = dgv_ds.Rows[i].Cells[3].Value.ToString();
                                    dcyt.DONVI = dgv_ds.Rows[i].Cells[4].Value.ToString();
                                    dcyt.CONGDUNG = dgv_ds.Rows[i].Cells[5].Value.ToString();
                                    dcyt.NGAYNHAP = dgv_ds.Rows[i].Cells[6].Value.ToString();
                                    dcyt.GIANHAP= dgv_ds.Rows[i].Cells[7].Value.ToString();
                                    dcyt.TINHTRANGCONSD = "Còn sử dụng";

                                    thucthi.themmoi_dcyt(dcyt);
                                    break;
                                }
                            // lưu vào bảng CHITIETPHIEUKHAM và bảng DUOCPHAMDVYTESOCUU
                            case "Dược phẩm dịch vụ sơ cứu":
                                {
                                    dpdvsc.MADUOCPHAMDVSOCUU = dgv_ds.Rows[i].Cells[2].Value.ToString();
                                    dpdvsc.MALOAIDUOCPHAM = dgv_ds.Rows[i].Cells[0].Value.ToString();
                                    dpdvsc.TENDUOCPHAM = dgv_ds.Rows[i].Cells[3].Value.ToString();
                                    dpdvsc.DONVI = dgv_ds.Rows[i].Cells[4].Value.ToString();
                                    dpdvsc.CONGDUNG = dgv_ds.Rows[i].Cells[5].Value.ToString();
                                    dpdvsc.NGAYNHAP = dgv_ds.Rows[i].Cells[6].Value.ToString();
                                    dpdvsc.GIANHAP = dgv_ds.Rows[i].Cells[7].Value.ToString();
                                    dpdvsc.SOLUONGCON = dgv_ds.Rows[i].Cells[8].Value.ToString();

                                    dpdvsc.TINHTRANGCONSD = "Còn sử  dụng";
                                    dpdvsc.GIABAN = "null";

                                    thucthi.themmoi_dpdvsc(dpdvsc);
                                    break; 
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    
                    thucthi.xoadulieu(keypnh);
                    thucthi.suatinhtrang(keypnh);
                    if(MessageBox.Show("Lưu nhập liệu thành công!", "Chú Ý", MessageBoxButtons.OK)== DialogResult.OK)
                    {
                        hienthi(keypnh);
                        this.Close();
                    }
                }
                
            }
        }

        private void fr_chitietphieunhap_Activated(object sender, EventArgs e)
        {
            hienthi(keypnh);
        }
    }
}
