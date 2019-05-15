using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chitietphieunhap
    {
        private string mahangnhap;
        private string maphieunhaphang;
        private string maloaiduocpham;
        private string tenhangnhap;
        private string congdung;
        private string donvi;
        private string gianhap;
        private string ngaynhap;
        private string soluongnhap;

        public string MAHANGNHAP
        {
            get
            {
                return mahangnhap;
            }
            set
            {
                mahangnhap = value;
                if (mahangnhap == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

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

        public string MALOAIDUOCPHAM
        {
            get
            {
                return maloaiduocpham;
            }
            set
            {
                maloaiduocpham = value;
                if (maloaiduocpham == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

        public string TENHANGNHAP
        {
            get
            {
                return tenhangnhap;
            }
            set
            {
                tenhangnhap = value;
                if (tenhangnhap == "")
                {
                    throw new Exception("Tên sản phẩm không được để trống");
                }
            }
        }

        public string CONGDUNG
        {
            get
            {
                return congdung;
            }
            set
            {
                congdung = value;
                if (congdung == "")
                {
                    throw new Exception("Công dụng không được để trống");
                }
            }
        }

        public string DONVI
        {
            get
            {
                return donvi;
            }
            set
            {
                donvi = value;
                if (donvi == "")
                {
                    throw new Exception("Đơn vị không được để trống");
                }
            }
        }


        public string GIANHAP
        {
            get
            {
                return gianhap;
            }
            set
            {
                gianhap = value;
                if (gianhap == "")
                {
                    throw new Exception("Giá hàng nhập không được để trống");
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
                    throw new Exception("Công dụng không được để trống");
                }
            }
        }

        public string SOLUONGNHAP
        {
            get
            {
                return soluongnhap;
            }
            set
            {
                soluongnhap = value;
                if (soluongnhap == "")
                {
                    throw new Exception("Số lượng nhập không được để trống");
                }
            }
        }
    }
}
