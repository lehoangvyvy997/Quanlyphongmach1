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
    public partial class fr_phieunhaphang : Form
    {
        private string maphieunhaphang;
        public fr_phieunhaphang()
        {
            InitializeComponent();
        }
        E_tb_Phieunhaphang thucthi = new E_tb_Phieunhaphang();
        ConnectDB cn = new ConnectDB();
        EC_tb_Phieunhaphang ck = new EC_tb_Phieunhaphang();
        bool themmoi;
        int dong = 1;


        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        public void setnull()
        {

            txt_ma.Text = "";
            txt_tien.Text = "";
            txt_sldm.Text = "";
            dtm_ngay.Text = DateTime.Now.ToShortTimeString();
            cbo_mancc.Text = "";
            txt_tinhtrang.Text = "Chưa nhập liệu";

            txt_diachincc.Text = "";
            txt_emailncc.Text = "";
            txt_sdtncc.Text = "";
            txt_tenncc.Text = "";
        }

        public void locktext()
        {
            txt_ma.Enabled = false;
            cbo_mancc.Enabled = false;
            txt_tien.Enabled = false;
            dtm_ngay.Enabled = false;
            txt_sldm.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            //btn_nhaplieu.Enabled = true;
        }

        public void un_locktext()
        {
            txt_ma.Enabled = true;
            cbo_mancc.Enabled = true;
            txt_tien.Enabled = true;
            dtm_ngay.Enabled = true;
            txt_sldm.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            //btn_nhaplieu.Enabled = false;
        }

        private int kiemtranull()
        {
            if (txt_ma.Text == "")
                return 1;
            if (dtm_ngay.Text == "")
                return 3;
            if (txt_sldm.Text == "")
                return 5;
            if (txt_tien.Text == "")
                return 4;
            if (cbo_mancc.Text == "")
                return 2;

            
            
            return 0;
        }
        public void khoitaoluoi()
        {
            dgv_dsphieunhap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsphieunhap.Columns[0].HeaderText = "Mã phiếu nhập hàng";
            dgv_dsphieunhap.Columns[0].Frozen = true;
            dgv_dsphieunhap.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dsphieunhap.Columns[0].Width = 150;
            dgv_dsphieunhap.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgv_dsphieunhap.Columns[1].Width = 150;
            dgv_dsphieunhap.Columns[2].HeaderText = "Số lượng danh mục";
            dgv_dsphieunhap.Columns[2].Width = 150;
            dgv_dsphieunhap.Columns[3].HeaderText = "Ngày nhập";
            dgv_dsphieunhap.Columns[3].Width = 150;
            dgv_dsphieunhap.Columns[4].HeaderText = "Số tiền";
            dgv_dsphieunhap.Columns[4].Width = 150;
            dgv_dsphieunhap.Columns[5].HeaderText = "Tình trạng";
            dgv_dsphieunhap.Columns[5].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaPhieuNhapHang, MaNhaCungCap, SoLuongDanhMucHangNhap, NgayNhap, SoTien, TinhTrang FROM dbo.PHIEUNHAPHANG";
            dgv_dsphieunhap.DataSource = cn.taobang(sql);
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



        private void fr_phieunhaphang_Load(object sender, EventArgs e)
        {
            thucthi.loadmancc(cbo_mancc);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txt_ma.Enabled = true;
            txt_ma.Focus();
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
                                ck.MAPHIEUNHAPHANG = txt_ma.Text;
                                ck.MANHACUNGCAP = cbo_mancc.Text;
                                ck.SOTIEN = txt_tien.Text;
                                ck.NGAYNHAP = dtm_ngay.Value.ToString();
                                ck.SOLUONGDANHMUCHANGNHAP = txt_sldm.Text;
                                ck.TINHTRANG = txt_tinhtrang.Text;

                                thucthi.themoipnh(ck);
                                locktext();
                                hienthi();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MAPHIEUNHAPHANG = txt_ma.Text;
                                ck.MANHACUNGCAP = cbo_mancc.Text;
                                ck.SOTIEN = txt_tien.Text;
                                ck.NGAYNHAP = dtm_ngay.Value.ToString();

                                ck.SOLUONGDANHMUCHANGNHAP = txt_sldm.Text;
                                ck.TINHTRANG = txt_tinhtrang.Text;

                                thucthi.suapnh(ck);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txt_ma.Enabled = true;
                        locktext();
                        hienthi();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Mã phiếu nhập hàng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ma.Focus();
                        break;

                    }
                case 2:
                    {
                        MessageBox.Show("Mã nhà cung cấp không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_mancc.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Ngày nhập không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_tien.Focus();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show(" Số tiền không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        
                        dtm_ngay.Focus();
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show(" Số lượng danh mục hàng nhập không được để trống", "Chú Ý", MessageBoxButtons.OK);

                        txt_sldm.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }

            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MAPHIEUNHAPHANG = txt_ma.Text;

                    thucthi.xoapnh(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_ma.Enabled = false;
            dtm_ngay.Focus();
        }

        

        private void cbo_mancc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_tenncc.Text = thucthi.loadtenncc(txt_tenncc.Text, cbo_mancc.Text);
            //txt_diachincc.Text = thucthi.loaddiachincc(txt_diachincc.Text, cbo_mancc.Text);
            //txt_emailncc.Text = thucthi.loademailncc(txt_emailncc.Text, cbo_mancc.Text);
            //txt_sdtncc.Text = thucthi.loadsdtncc(txt_sdtncc.Text, cbo_mancc.Text);

            txt_tenncc.Text = thucthi.loadtenncc("", cbo_mancc.Text);
            txt_diachincc.Text = thucthi.loaddiachincc("", cbo_mancc.Text);
            txt_emailncc.Text = thucthi.loademailncc("", cbo_mancc.Text);
            txt_sdtncc.Text = thucthi.loadsdtncc("", cbo_mancc.Text);
        }

        private void btn_themncc_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_nhacungcap));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_nhacungcap fr = new fr_nhacungcap();
                fr.ShowDialog();
            }
        }

        private void fr_phieunhaphang_Activated(object sender, EventArgs e)
        {
            thucthi.loadmancc(cbo_mancc);
            hienthi();
        }

        private void txt_tien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgv_dsphieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txt_ma.Text = dgv_dsphieunhap.Rows[dong].Cells[0].Value.ToString();
            cbo_mancc.Text = dgv_dsphieunhap.Rows[dong].Cells[1].Value.ToString();
            txt_sldm.Text = dgv_dsphieunhap.Rows[dong].Cells[2].Value.ToString();
            dtm_ngay.Text = dgv_dsphieunhap.Rows[dong].Cells[3].Value.ToString();
            txt_tien.Text = dgv_dsphieunhap.Rows[dong].Cells[4].Value.ToString();
            txt_tinhtrang.Text = dgv_dsphieunhap.Rows[dong].Cells[5].Value.ToString();

            maphieunhaphang = txt_ma.Text;
            locktext();
            if (txt_tinhtrang.Text == "Chưa nhập liệu"&& txt_ma.Text!="")
            {
                btn_nhaplieu.Enabled = true;
            }
            else
            {
                btn_nhaplieu.Enabled = false;
                btn_sua.Enabled = false;
                btn_xoa.Enabled = false;
            }
        }

        private void txt_sldm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_nhaplieu_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chitietphieunhap));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chitietphieunhap fr = new fr_chitietphieunhap(maphieunhaphang);
                fr.ShowDialog();
            }

        }
    }
}
