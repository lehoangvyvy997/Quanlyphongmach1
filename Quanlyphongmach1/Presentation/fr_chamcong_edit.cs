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
    public partial class fr_chamcong_edit : Form
    {
        public fr_chamcong_edit()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();
        EC_tb_Chamcong ck = new EC_tb_Chamcong();
        E_tb_Chamcong thucthi = new E_tb_Chamcong();
        
        int dong = 0;

        private void setnull()
        {
            cbo.Text = "";
        }

        private void locktext()
        {

            cbo.Enabled = false;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
        }
        private void un_locktext()
        {
            cbo.Enabled = true;
            btn_sua.Enabled = false;
            btn_luu.Enabled = true;
        }
        public void khoitaoluoi()
        {
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].HeaderText = "Mã chấm công";
            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Width = 200;
            dgv.Columns[1].HeaderText = "Mã nhân viên";
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].HeaderText = "Ngày chấm công";
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].HeaderText = "Tình trạng nghỉ";
            dgv.Columns[3].Width = 200;

        }
        public void hienthi(DateTime date)
        {
            string ngay = date.Year.ToString() + "/" + date.Day.ToString() + "/" + date.Month.ToString();
            string sql = "SELECT MaChamCong, MaNhanVien, NgayChamCong, NghiCoPhep FROM dbo.CHAMCONG WHERE NgayChamCong = '" + ngay + "'";
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
        public void hienthi_(DateTime date, string tenNV)
        {
            string ngay = date.Year.ToString() + "/" + date.Day.ToString() + "/" + date.Month.ToString();

            string sql1 = "SELECT MaNhanVien FROM dbo.NHANVIEN WHERE TenNhanVien = N'" + tenNV + "'";
            DataTable ds_maNV = cn.taobang(sql1);

            string sql2 = "SELECT * FROM dbo.CHAMCONG WHERE MaNhanVien = '0' ";
            string sqlngay = "NgayChamCong = '" + ngay + "'";
            string sqlMaNV;
            string sqlma_ngay;
            foreach (DataRow row in ds_maNV.Rows)
            {
                sqlMaNV = "MaNhanVien = '" + row[0].ToString() + "'";
                sqlma_ngay = "OR (" + sqlngay + " AND " + sqlMaNV + ")";
                sql2 = sql2 + sqlma_ngay;

            }
            
            dgv.DataSource = cn.taobang(sql2);
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fr_chamcong_edit_Load(object sender, EventArgs e)
        {
            thucthi.load_tenNVSearch(txt_srhten);
            hienthi(DateTime.Now);
            khoitaoluoi();
            locktext();
            btn_sua.Enabled = false;

            //string sql1 = "SELECT MaNhanVien FROM dbo.NHANVIEN WHERE TenNhanVien = N'Nguyễn Thị D'";
            //DataTable ds_maNV = cn.taobang(sql1);
            //txt_srhten.Text = ds_maNV.Rows[1].ItemArray[0].ToString();



        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;

            if(dong!=-1)
            {
                cbo.Text = dgv.Rows[dong].Cells[3].Value.ToString();
            }
            locktext();
        }

        private void cbo_TextChanged(object sender, EventArgs e)
        {
            btn_sua.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            un_locktext();
            btn_luu.Focus();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if(txt_srhten.Text=="")
            {
                DateTime date = dtm.Value;
                hienthi(date);
            }
            else
            {
                DateTime date = dtm.Value;
                hienthi_(date, txt_srhten.Text);
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (cbo.Text == "")
            {
                MessageBox.Show("Tình trạng nghỉ phép không được để trống!", "Chú Ý", MessageBoxButtons.OK);
                cbo.Focus();
            }
            else
            {
                try
                {
                    ck.MACHAMCONG = dgv.Rows[dong].Cells[0].Value.ToString();

                    ck.NGHICOPHEP = cbo.Text;
                    thucthi.sua(ck);
                    setnull();
                    locktext();
                    hienthi(DateTime.Now);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
