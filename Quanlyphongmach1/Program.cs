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


            //Application.Run(new Presentation.Admin.test());
            Application.Run(new fr_dangnhap());
        }
    }
}
