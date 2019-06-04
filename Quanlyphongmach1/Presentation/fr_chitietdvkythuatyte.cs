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
    public partial class fr_chitietdvkythuatyte : Form
    {
        private string Mapukh;
        public fr_chitietdvkythuatyte()
        {
            InitializeComponent();
        }

        public fr_chitietdvkythuatyte(string mapukh)
        {
            Mapukh = mapukh;
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        E_tb_Chitietdvkythuatyte thucthi = new E_tb_Chitietdvkythuatyte();
        EC_tb_Chitietdvkythuatyte ck = new EC_tb_Chitietdvkythuatyte();
        bool themmoi;
        int dong = 0;
        
        public void setnull()
        {
            cbo_ktmadv.Text = "";
            txt_ktphisd.Text = "";
            txt_ktsolansd.Text = "";
            txt_kttendv.Text = "";
        }
        public void locktext()
        {
            cbo_ktmadv.Enabled = false;
            txt_ktphisd.Enabled = false;
            txt_ktsolansd.Enabled = false;
            txt_kttendv.Enabled = false;

            btn_ktthem.Enabled = true;
            btn_ktluu.Enabled = false;
            btn_ktsua.Enabled = false;
            btn_ktxoa.Enabled = false;
           
        }
        public void un_locktext()
        {
            cbo_ktmadv.Enabled = true;
            txt_ktphisd.Enabled = true;
            txt_ktsolansd.Enabled = true;
            txt_kttendv.Enabled = true;

            btn_ktluu.Enabled = true;
            
            btn_ktthem.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_ktds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ktds.Columns[0].HeaderText = "Mã phiếu khám";
            dgv_ktds.Columns[0].Frozen = true;
            dgv_ktds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ktds.Columns[0].Width = 250;
            dgv_ktds.Columns[1].HeaderText = "Mã Dịch vụ";
            dgv_ktds.Columns[1].Width = 170;
            dgv_ktds.Columns[2].HeaderText = "Số lần sử dụng";
            dgv_ktds.Columns[2].Width = 150;

        }

        public void hienthi(string maPukh)
        {
            string sql = "SELECT MaPhieuKham, MaDVKyThuat, SoLanSD FROM dbo.CHITIETDVKYTHUATYTE WHERE MaPhieuKham = '" + maPukh + "'";
            dgv_ktds.DataSource = cn.taobang(sql);
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



        private void cbo_ktmadv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_kttendv.Text = thucthi.Load_tendvkt(cbo_ktmadv.Text);
            txt_ktphisd.Text = thucthi.Load_chiphidvkt(cbo_ktmadv.Text);
        }

        private void dgv_ktds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                cbo_ktmadv.Text = dgv_ktds.Rows[dong].Cells[1].Value.ToString();
                txt_ktsolansd.Text = dgv_ktds.Rows[dong].Cells[2].Value.ToString();
            }

            locktext();
        }

        private void fr_chitietdvkythuatyte_Load(object sender, EventArgs e)
        {
            thucthi.load_madvkt(cbo_ktmadv);

            setnull();
            locktext();
            hienthi(Mapukh);
            khoitaoluoi();
        }

        private void btn_ktthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            cbo_ktmadv.Enabled = true;
            cbo_ktmadv.Focus();
        }

        private void btn_ktsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            cbo_ktmadv.Focus();
        }

        private void btn_ktxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MAPHIEUKHAM = Mapukh;
                    ck.MADVKYTHUAT = cbo_ktmadv.Text;
                    ck.SOLANSD = txt_ktsolansd.Text;

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

        private void btn_ktluu_Click(object sender, EventArgs e)
        {
            if (cbo_ktmadv.Text != "" && txt_ktsolansd.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MADVKYTHUAT = cbo_ktmadv.Text;
                        ck.MAPHIEUKHAM = Mapukh;
                        ck.SOLANSD = txt_ktsolansd.Text;
                        ck.THANHTIEN = (int.Parse(txt_ktsolansd.Text) * int.Parse(thucthi.Load_chiphidvkt(cbo_ktmadv.Text))).ToString();
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
                        ck.MADVKYTHUAT = cbo_ktmadv.Text;
                        ck.MAPHIEUKHAM = Mapukh;
                        ck.SOLANSD = txt_ktsolansd.Text;
                        ck.THANHTIEN = (int.Parse(txt_ktsolansd.Text) * int.Parse(thucthi.Load_chiphidvkt(cbo_ktmadv.Text))).ToString();
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
                if (cbo_ktmadv.Text == "")
                {
                    MessageBox.Show("Mã dịch vụ không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbo_ktmadv.Focus();
                }
                else
                {
                    if (txt_ktsolansd.Text == "")
                    {
                        MessageBox.Show("Số lần sử dụng không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ktsolansd.Focus();
                    }
                }
            }
        }

        private void txt_ktsolansd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbo_ktmadv_TextChanged(object sender, EventArgs e)
        {
            btn_ktsua.Enabled = true;
            btn_ktxoa.Enabled = true;
        }
    }
}
