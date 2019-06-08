using Quanlyphongmach1.Business.Component;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlyphongmach1.Presentation.Admin
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        E_tb_Taikhoan thucthi = new E_tb_Taikhoan();
        ConnectDB cn = new ConnectDB();
        EC_tb_Taikhoan ck = new EC_tb_Taikhoan();


        private void test_Load(object sender, EventArgs e)
        {
            thucthi.loadmaloaitk(cbo_ds);
        }
    }
}
