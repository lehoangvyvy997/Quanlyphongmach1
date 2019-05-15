using System;
using System.Linq;
using System.Windows.Forms;

namespace Quanlyphongmach1.Presentation
{
    public partial class fr_quanlychung : Form
    {
        public fr_quanlychung()
        {
            InitializeComponent();
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }
        private void btn_nvql_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_nhanvien));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_nhanvien fr = new fr_nhanvien();
                fr.ShowDialog();
            }
        }

        private void btn_nvcv_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chucvu));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chucvu fr = new fr_chucvu();
                fr.ShowDialog();
            }
        }

        private void btn_nvloainv_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_loainhanvien));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_loainhanvien fr = new fr_loainhanvien();
                fr.ShowDialog();
            }
        }

        private void btn_nvttlv_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_tinhtranglamviec));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_tinhtranglamviec fr = new fr_tinhtranglamviec();
                fr.ShowDialog();
            }
        }

        private void btn_nvchamcong_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_chamcong));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_chamcong fr = new fr_chamcong();
                fr.ShowDialog();
            }
        }

        private void btn_dvkt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_dichvukythuatyte));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_dichvukythuatyte fr = new fr_dichvukythuatyte();
                fr.ShowDialog();
            }
        }

        private void btn_dvsc_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_dichvusocuutaicho));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_dichvusocuutaicho fr = new fr_dichvusocuutaicho();
                fr.ShowDialog();
            }
        }

        private void btn_dvphkham_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_phongkham));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_phongkham fr = new fr_phongkham();
                fr.ShowDialog();
            }
        }

        private void btn_tkloai_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_loaitaikhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_loaitaikhoan fr = new fr_loaitaikhoan();
                fr.ShowDialog();
            }
        }

 /* Quản lý nhà cung cấp */
        private void btn_nccql_Click(object sender, EventArgs e)
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

        private void btn_nccphieunhap_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_phieunhaphang));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_phieunhaphang fr = new fr_phieunhaphang();
                fr.ShowDialog();
            }
        }

        private void btn_nccchitietphieunhap_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemchitietphieukham));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemchitietphieukham fr = new Admin.fr_admin_xemchitietphieukham();
                fr.ShowDialog();
            }
        }

        private void btn_khoqlthuockham_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_thuockham));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_thuockham fr = new fr_thuockham();
                fr.ShowDialog();
            }
        }

        private void btn_khoqlthuocdv_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_duocphamdvytesocuu));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_duocphamdvytesocuu fr = new fr_duocphamdvytesocuu();
                fr.ShowDialog();
            }
        }

        private void btn_khoqldcyt_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_dungcuyte));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_dungcuyte fr = new fr_dungcuyte();
                fr.ShowDialog();
            }
        }

        private void btn_khoqlloaidp_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_loaiduocpham));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_loaiduocpham fr = new fr_loaiduocpham();
                fr.ShowDialog();
            }
        }

 /* Xem thống kê */
        private void btn_thongke_doanhthu_Click(object sender, EventArgs e)
        {
            // cần xây dựng
        }

        private void btn_thongke_nhapkho_Click(object sender, EventArgs e)
        {
            // cần xây dựng
        }

        private void btn_thongke_xemtienluong_Click(object sender, EventArgs e)
        {
            // cần xây dựng
        }

 /* Quản lý bệnh nhân */
        private void btn_bnlq_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemdsbenhnhan));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemdsbenhnhan fr = new Admin.fr_admin_xemdsbenhnhan();
                fr.ShowDialog();
            }
        }
        
        private void btn_bnqlphieukham_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemphieukham));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemphieukham fr = new Admin.fr_admin_xemphieukham();
                fr.ShowDialog();
            }
        }

        private void btn_bnqlhoadon_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemdshoadon));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemdshoadon fr = new Admin.fr_admin_xemdshoadon();
                fr.ShowDialog();
            }
        }

        private void btn_bnxemct_DVKT_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemdsctdvkt));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemdsctdvkt fr = new Admin.fr_admin_xemdsctdvkt();
                fr.ShowDialog();
            }
        }

        private void btn_bnqlxemct_DVSC_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemdsctdvsc));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemdsctdvsc fr = new Admin.fr_admin_xemdsctdvsc();
                fr.ShowDialog();
            }
        }

        private void btn_bnqlxemct_toathuockham_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(Admin.fr_admin_xemdsctdonthuoc));
            if (frm != null)
                frm.Activate();
            else
            {
                Admin.fr_admin_xemdsctdonthuoc fr = new Admin.fr_admin_xemdsctdonthuoc();
                fr.ShowDialog();
            }
        }
    }
}
