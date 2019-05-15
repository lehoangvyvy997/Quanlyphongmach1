using System;
using System.Linq;
using System.Windows.Forms;

namespace Quanlyphongmach1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Presentation.fr_loaitaikhoan());
            //Application.Run(new Presentation.fr_tinhtranglamviec());
            //Application.Run(new Presentation.fr_loainhanvien());
            //Application.Run(new Presentation.fr_chucvu());
            //Application.Run(new Presentation.fr_nhanvien());
            //Application.Run(new Presentation.fr_nhacungcap());
            //Application.Run(new Presentation.fr_phieunhaphang());
            //Application.Run(new Presentation.fr_loaiduocpham());
            //Application.Run(new Presentation.fr_chitietphieunhap());
            //Application.Run(new Presentation.fr_thuockham());
            //Application.Run(new Presentation.fr_dungcuyte());
            //Application.Run(new Presentation.fr_dichvusocuutaicho());
            //Application.Run(new Presentation.fr_phongkham());
            Application.Run(new fr_dangnhap());
            //Application.Run(new Presentation.fr_phieukham());
            //Application.Run(new Presentation.fr_trangcanhan());
        }
    }
}
