using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Thuockham
    {
        private string mathuockham;
        private string maloaiduocpham;
        private string tenthuockham;
        private string congdung;
        private string donvi;
        private string giathuocnhap;
        private string ngaynhap;
        private string tinhtrangconsd;
        private string giathuocban;
        private string soluongcon;

        public string MATHUOCKHAM
        {
            get
            {
                return mathuockham;
            }
            set
            {
                mathuockham = value;
                if (mathuockham == "")
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

        public string TENTHUOCKHAM
        {
            get
            {
                return tenthuockham;
            }
            set
            {
                tenthuockham = value;
                if (tenthuockham == "")
                {
                    throw new Exception("Tên thuốc không được để trống");
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
        public string GIATHUOCNHAP
        {
            get
            {
                return giathuocnhap;
            }
            set
            {
                giathuocnhap = value;
                if (giathuocnhap == "")
                {
                    throw new Exception("Giá thuốc nhập không được để trống");
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

        public string TINHTRANGCONSD
        {
            get
            {
                return tinhtrangconsd;
            }
            set
            {
                tinhtrangconsd = value;
                if (tinhtrangconsd == "")
                {
                    throw new Exception("Tình trạng còn sử dụng không được để trống");
                }
            }
        }
        public string GIATHUOCBAN
        {
            get
            {
                return giathuocban;
            }
            set
            {
                giathuocban = value;
                if (giathuocban == "")
                {
                    throw new Exception("Giá thuốc bán không được để trống");
                }
            }
        }

        public string SOLUONGCON
        {
            get
            {
                return soluongcon;
            }
            set
            {
                soluongcon = value;
            }
        }
    }
}
