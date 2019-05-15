using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Phieunhaphang
    {
        private string maphieunhaphang;
        private string manhacungcap;
        private string ngaynhap;
        private string soluongdanhmuchangnhap;
        private string sotien;
        private string tinhtrang;

        public string MAPHIEUNHAPHANG
        {
            get
            {
                return maphieunhaphang;
            }
            set
            {
                maphieunhaphang = value;
                if (maphieunhaphang == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

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

        public string NGAYNHAP
        {
            get
            {
                return ngaynhap;
            }
            set
            {
                ngaynhap = value;
                if (ngaynhap == "")
                {
                    throw new Exception("Ngày nhập không được để trống");
                }
            }
        }
        public string SOLUONGDANHMUCHANGNHAP
        {
            get
            {
                return soluongdanhmuchangnhap;
            }
            set
            {
                soluongdanhmuchangnhap = value;
                
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
        public string SOTIEN
        {
            get
            {
                return sotien;
            }
            set
            {
                sotien = value;
                if (sotien == "")
                {
                    throw new Exception("Số tiền không được để trống");
                }
            }
        }
    }
}
