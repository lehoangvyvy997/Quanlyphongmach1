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
    public partial class fr_tinhtranglamviec : Form
    {
        public fr_tinhtranglamviec()
        {
            InitializeComponent();
        }

        E_tb_Tinhtranglamviec thucthi = new E_tb_Tinhtranglamviec();
        ConnectDB cn = new ConnectDB();
        EC_tb_Tinhtranglamviec ck = new EC_tb_Tinhtranglamviec();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_matinhtrang.Text = "";
            txt_tentinhtrang.Text = "";
        }

        public void locktext()
        {
            txt_matinhtrang.Enabled = false;
            txt_tentinhtrang.Enabled = false;
            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }
        public void un_locktext()
        {
            txt_matinhtrang.Enabled = true;
            txt_tentinhtrang.Enabled = true;
            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_dstinhtranglv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dstinhtranglv.Columns[0].HeaderText = "Mã tình trạng";
            dgv_dstinhtranglv.Columns[0].Frozen = true;
            dgv_dstinhtranglv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dstinhtranglv.Columns[0].Width = 150;
            dgv_dstinhtranglv.Columns[1].HeaderText = "Tên tình trạng";
            dgv_dstinhtranglv.Columns[1].Width = 200;

        }

        public void hienthi()
        {
            string sql = "SELECT MaTTLV, TenTTLV FROM TINHTRANGLAMVIEC";
            dgv_dstinhtranglv.DataSource = cn.taobang(sql);
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

        private void fr_tinhtranglamviec_Load(object sender, EventArgs e)
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
            txt_matinhtrang.Enabled = true;
            txt_tentinhtrang.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_matinhtrang.Text != "" && txt_tentinhtrang.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MATTLV = txt_matinhtrang.Text;
                        ck.TENTTLV = txt_tentinhtrang.Text;
                        thucthi.themoilg(ck);
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
                        ck.MATTLV = txt_matinhtrang.Text;
                        ck.TENTTLV = txt_tentinhtrang.Text;
                        thucthi.sualg(ck);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                txt_matinhtrang.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                if (txt_matinhtrang.Text == "")
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_matinhtrang.Focus();
                }
                else
                {
                    if (txt_tentinhtrang.Text == "")
                    {
                        MessageBox.Show("Tên loại nhân viên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_tentinhtrang.Focus();
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_matinhtrang.Enabled = false;
            txt_tentinhtrang.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MATTLV = txt_matinhtrang.Text;

                    thucthi.xoalg(ck);
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

        private void dgv_dstinhtranglv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            
            if(dong!=-1)
            {
                txt_matinhtrang.Text = dgv_dstinhtranglv.Rows[dong].Cells[0].Value.ToString();
                txt_tentinhtrang.Text = dgv_dstinhtranglv.Rows[dong].Cells[1].Value.ToString();
            }

            locktext();
        }
    }
}
