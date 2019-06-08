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
    public partial class fr_chitietdvsocuutaicho : Form
    {
        private string Mapukh;
        public fr_chitietdvsocuutaicho()
        {
            InitializeComponent();
        }
        public fr_chitietdvsocuutaicho(string mapukh)
        {
            Mapukh = mapukh;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        E_tb_Chitietdvsocuutaicho thucthi = new E_tb_Chitietdvsocuutaicho();
        EC_tb_Chitietdvsocuutaicho ck = new EC_tb_Chitietdvsocuutaicho();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            cbo_scmadv.Text = "";
            txt_sctendv.Text = "";
            cbo_scmadp.Text = "";
            txt_sccongdung.Text = "";
            txt_scdonvi.Text = "";
            txt_scsoluongdp.Text = "";
            txt_sctendp.Text = "";
        }
        public void locktext()
        {
            cbo_scmadv.Enabled = false;
            txt_sctendv.Enabled = false;
            cbo_scmadp.Enabled = false;
            txt_sccongdung.Enabled = false;
            txt_scdonvi.Enabled = false;
            txt_scsoluongdp.Enabled = false;
            txt_sctendp.Enabled = false;
            
            btn_scthem.Enabled = true;
            btn_scluu.Enabled = false;
            btn_scsua.Enabled = false;
            btn_scxoa.Enabled = false;
        }
        public void un_locktext()
        {
            cbo_scmadv.Enabled = true;
            txt_sctendv.Enabled = true;
            cbo_scmadp.Enabled = true;
            txt_sccongdung.Enabled = true;
            txt_scdonvi.Enabled = true;
            txt_scsoluongdp.Enabled = true;
            txt_sctendp.Enabled = true;

            btn_scluu.Enabled = true;
            
            btn_scthem.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_scds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_scds.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_scds.Columns[0].Frozen = true;
            dgv_scds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_scds.Columns[0].Width = 200;
            dgv_scds.Columns[1].HeaderText = "Mã dược phẩm";
            dgv_scds.Columns[1].Width = 150;
            dgv_scds.Columns[2].HeaderText = "Mã loại dịch vụ";
            dgv_scds.Columns[2].Width = 150;
            dgv_scds.Columns[3].HeaderText = "Số lượng";
            dgv_scds.Columns[3].Width = 100;

        }
        public void hienthi(string key)
        {
            string sql = "SELECT MaPhieuKham, MaDuocPhamDVSoCuu, MaLoaiDVSoCuu, SoLuong FROM dbo.CHITIETDVSOCUUTAICHO WHERE MaPhieuKham = '" + key + "'";
            dgv_scds.DataSource = cn.taobang(sql);
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


        private void cbo_scmadv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_sctendv.Text = thucthi.Load_tendvsc(cbo_scmadv.Text);
        }

        private void dgv_scds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                cbo_scmadv.Text = dgv_scds.Rows[dong].Cells[2].Value.ToString();
                cbo_scmadp.Text = dgv_scds.Rows[dong].Cells[1].Value.ToString();
                txt_scsoluongdp.Text = dgv_scds.Rows[dong].Cells[3].Value.ToString();
            }

            locktext();
        }

        private void cbo_scmadp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_sctendp.Text = thucthi.Load_tendp(cbo_scmadp.Text);
            txt_scdonvi.Text = thucthi.Load_donvidp(cbo_scmadp.Text);
            txt_sccongdung.Text = thucthi.Load_congdungdp(cbo_scmadp.Text);
        }

        private void fr_chitietdvsocuutaicho_Load(object sender, EventArgs e)
        {
            thucthi.loadcbo_madp(cbo_scmadp);
            thucthi.load_madvsc(cbo_scmadv);
            thucthi.load_madp(cbo_scmadp);

            setnull();
            locktext();
            hienthi(Mapukh);
            khoitaoluoi();
        }

        private void btn_scthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            cbo_scmadv.Enabled = true;
            cbo_scmadv.Focus();
        }

        private void btn_scsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            cbo_scmadv.Focus();
        }

        private void btn_scxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MADUOCPHAMDVSOCUU = cbo_scmadp.Text;
                    ck.MALOAIDVSOCUU = cbo_scmadv.Text;
                    ck.MAPHIEUKHAM = Mapukh;
                    ck.SOLUONG = txt_scsoluongdp.Text;
                    ck.THANHTIEN = (int.Parse(txt_scsoluongdp.Text) * int.Parse(thucthi.Load_giaban(cbo_scmadp.Text))).ToString();
                    thucthi.xoa(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi(Mapukh);
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btn_scluu_Click(object sender, EventArgs e)
        {
            if (cbo_scmadv.Text != "" && cbo_scmadp.Text != "" && txt_scsoluongdp.Text == "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MADUOCPHAMDVSOCUU = cbo_scmadp.Text;
                        ck.MALOAIDVSOCUU = cbo_scmadv.Text;
                        ck.MAPHIEUKHAM = Mapukh;
                        ck.SOLUONG = txt_scsoluongdp.Text;
                        ck.THANHTIEN = (int.Parse(txt_scsoluongdp.Text) * int.Parse(thucthi.Load_giaban(cbo_scmadp.Text))).ToString();

                        thucthi.themoi(ck);
                        locktext();
                        hienthi(Mapukh);
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
                        ck.MADUOCPHAMDVSOCUU = cbo_scmadp.Text;
                        ck.MALOAIDVSOCUU = cbo_scmadv.Text;
                        ck.MAPHIEUKHAM = Mapukh;
                        ck.SOLUONG = txt_scsoluongdp.Text;

                        thucthi.sua(ck);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                locktext();
                hienthi(Mapukh);
            }
            else
            {
                if (cbo_scmadv.Text == "")
                {
                    MessageBox.Show("Mã dịch vụ không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbo_scmadv.Focus();
                }
                else
                {
                    if (cbo_scmadp.Text == "")
                    {
                        MessageBox.Show("Mã dược phẩm không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbo_scmadp.Focus();
                    }
                    else
                    {
                        if (txt_scsoluongdp.Text == "")
                        {
                            MessageBox.Show("Số lượng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txt_scsoluongdp.Focus();
                        }
                    }
                }
            }
        }

        private void txt_scsoluongdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbo_scmadv_TextChanged(object sender, EventArgs e)
        {
            btn_scsua.Enabled = true;
            btn_scxoa.Enabled = true;
        }
    }
}
