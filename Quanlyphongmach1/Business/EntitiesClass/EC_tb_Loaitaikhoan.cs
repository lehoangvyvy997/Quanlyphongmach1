using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Loaitaikhoan
    {
        private string maloaitaikhoan;
        private string tenloaitaikhoan;

        public string MALOAITAIKHOAN
        {
            get
            {
                return maloaitaikhoan;
            }
            set
            {
                maloaitaikhoan = value;
                if (maloaitaikhoan == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string TENLOAITAIKHOAN
        {
            get
            {
                return tenloaitaikhoan;
            }
            set
            {
                tenloaitaikhoan = value;
                if (tenloaitaikhoan == "")
                {
                    throw new Exception("Tên loại tài khoản không được để trống!");
                }
            }
        }
    }
}
