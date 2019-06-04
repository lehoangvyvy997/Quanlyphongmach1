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
    public partial class fr_chucvu : Form
    {
        public fr_chucvu()
        {
            InitializeComponent();
        }

        E_tb_Chucvu thucthi = new E_tb_Chucvu();
        ConnectDB cn = new ConnectDB();
        EC_tb_Chucvu ck = new EC_tb_Chucvu();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txt_machucvu.Text = "";
            txt_tenchucvu.Text = "";
        }

        public void locktext()
        {
            txt_machucvu.Enabled = false;
            txt_tenchucvu.Enabled = false;

            btn_themmoi.Enabled = true;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
        }

        public void un_locktext()
        {
            txt_machucvu.Enabled = true;
            txt_tenchucvu.Enabled = true;
            btn_themmoi.Enabled = false;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            dgv_dschucvu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dschucvu.Columns[0].HeaderText = "Mã chức vụ";
            dgv_dschucvu.Columns[0].Frozen = true;
            dgv_dschucvu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_dschucvu.Columns[0].Width = 150;
            dgv_dschucvu.Columns[1].HeaderText = "Tên chức vụ";
            dgv_dschucvu.Columns[1].Width = 200;

        }

        public void hienthi()
        {
            string sql = "SELECT MaChucVu, TenChucVu FROM CHUCVU";
            dgv_dschucvu.DataSource = cn.taobang(sql);
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

        private void fr_chucvu_Load(object sender, EventArgs e)
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
            txt_machucvu.Enabled = true;
            txt_machucvu.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_machucvu.Text != "" && txt_tenchucvu.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.MACHUCVU = txt_machucvu.Text;
                        ck.TENCHUCVU = txt_tenchucvu.Text;
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
                    try
                    {
                        ck.MACHUCVU = txt_machucvu.Text;
                        ck.TENCHUCVU = txt_tenchucvu.Text;
                        thucthi.sualg(ck);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txt_machucvu.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                if (txt_machucvu.Text == "")
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txt_machucvu.Focus();
                }
                else
                {
                    if (txt_tenchucvu.Text == "")
                    {
                        MessageBox.Show("Tên loại nhân viên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txt_tenchucvu.Focus();
                    }
                }
               

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txt_machucvu.Enabled = false;
            txt_tenchucvu.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MACHUCVU = txt_machucvu.Text;

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

        private void dgv_dschucvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if(dong!=-1)
            {
                txt_machucvu.Text = dgv_dschucvu.Rows[dong].Cells[0].Value.ToString();
                txt_tenchucvu.Text = dgv_dschucvu.Rows[dong].Cells[1].Value.ToString();
            }
            locktext();
        }
    }
}
