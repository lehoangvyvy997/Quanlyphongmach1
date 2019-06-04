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
    public partial class fr_dichvukythuatyte : Form
    {
        public fr_dichvukythuatyte()
        {
            InitializeComponent();
        }

        E_tb_Dichvukythuatyte thucthi = new E_tb_Dichvukythuatyte();
        ConnectDB cn = new ConnectDB();
        EC_tb_Dichvukythuatyte ck = new EC_tb_Dichvukythuatyte();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_ma.Text = "";
            txt_ten.Text = "";
            txt_phsd.Text = "";
        }
        public void locktext()
        {
            txt_ma.Enabled = false;
            txt_ten.Enabled = false;
            txt_phsd.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }
        public void un_locktext()
        {
            txt_ma.Enabled = true;
            txt_ten.Enabled = true;
            txt_phsd.Enabled = true;

            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_ds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].HeaderText = "Mã dịch vụ";
            dgv_ds.Columns[0].Frozen = true;
            dgv_ds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ds.Columns[0].Width = 150;
            dgv_ds.Columns[1].HeaderText = "Tên dịch vụ";
            dgv_ds.Columns[1].Width = 200;
            dgv_ds.Columns[2].HeaderText = "Chi phí sử dụng";
            dgv_ds.Columns[2].Width = 150;

        }
        public void hienthi()
        {
            string sql = "SELECT MaDVKyThuat, TenDVKyThuat, ChiPhiSuDungDV FROM DICHVUKYTHUATYTE";
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
        private void fr_dichvukythuatyte_Load(object sender, EventArgs e)
        {
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_ma.Enabled = false;
            txt_ten.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MADVKYTHUAT = txt_ma.Text;

                    thucthi.xoa(ck);
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
        private int kiemtranull()
        {
            if (txt_ma.Text == "")
                return 1;
            if (txt_ten.Text == "")
                return 2;
            if (txt_phsd.Text == "")
                return 3;
            return 0;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            int key = kiemtranull();
            switch(key)
            {
                case 0:
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MADVKYTHUAT = txt_ma.Text;
                                ck.TENDVKYTHUAT = txt_ten.Text;
                                ck.CHIPHISUDUNGDV = txt_phsd.Text;

                                thucthi.themoi(ck);
                                locktext();
                                hienthi();
                                
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
                                ck.MADVKYTHUAT = txt_ma.Text;
                                ck.TENDVKYTHUAT = txt_ten.Text;
                                ck.CHIPHISUDUNGDV = txt_phsd.Text;

                                thucthi.sua(ck);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        txt_ma.Enabled = true;
                        locktext();
                        hienthi();
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ma.Focus();
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Tên dịch vụ không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_ten.Focus();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Chi phí không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_phsd.Focus();
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
            
            if(dong!=-1)
            {
                txt_ma.Text = dgv_ds.Rows[dong].Cells[0].Value.ToString();
                txt_ten.Text = dgv_ds.Rows[dong].Cells[1].Value.ToString();
                txt_phsd.Text = dgv_ds.Rows[dong].Cells[2].Value.ToString();
            }

            locktext();
        }

        private void txt_phsd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
