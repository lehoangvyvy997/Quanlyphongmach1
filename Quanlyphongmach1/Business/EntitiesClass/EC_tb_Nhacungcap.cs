using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Nhacungcap
    {
        private string manhacungcap;
        private string tennhacungcap;
        private string diachi;
        private string sdt;
        private string email;
        private string mathangcc;
        private string sotaikhoan;
        private string nganhang;
        private string tinhtrang;

        public string MANHACUNGCAP
        {
            get
            {
                return manhacungcap;
            }
            set
            {
                manhacungcap = value;
                if (manhacungcap == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string TENNHANCUNGCAP
        {
            get
            {
                return tennhacungcap;
            }
            set
            {
                tennhacungcap = value;
                if (tennhacungcap == "")
                {
                    throw new Exception("Tên nhà cung cấp không được để trống");
                }
            }
        }
        public string DIACHI
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
                if (diachi == "")
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
            }
        }
        public string SDT
        {
            get
            {
                return sdt;
            }
            set
            {
                sdt = value;
                if (sdt == "")
                {
                    throw new Exception("Số điện thoại nhà cung cấp không được để trống");
                }
            }
        }
        public string EMAIL
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                if (email == "")
                {
                    throw new Exception("Email nhà cung cấp không được để trống");
                }
            }
        }

        public string MATHANGCC
        {
            get
            {
                return mathangcc;
            }
            set
            {
                mathangcc = value;
            }
        }

        public string SOTAIKHOAN
        {
            get
            {
                return sotaikhoan;
            }
            set
            {
                sotaikhoan = value;
            }
        }
        public string NGANHANG
        {
            get
            {
                return nganhang;
            }
            set
            {
                nganhang = value;
            }
        }
        public string TINHTRANG
        {
            get
            {
                return tinhtrang;
            }
            set
            {
                tinhtrang = value;
            }
        }
    }
}
