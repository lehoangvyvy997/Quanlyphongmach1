using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Duocphamdvytesocuu
    {
        private string maduocphamdvsocuu;
        private string maloaiduocpham;
        private string tenduocpham;
        private string congdung;
        private string donvi;
        private string gianhap;
        private string ngaynhap;
        private string tinhtrangconsd;
        private string giaban;
        private string soluongcon;

        public string MADUOCPHAMDVSOCUU
        {
            get
            {
                return maduocphamdvsocuu;
            }
            set
            {
                maduocphamdvsocuu = value;
                if (maduocphamdvsocuu == "")
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

        public string TENDUOCPHAM
        {
            get
            {
                return tenduocpham;
            }
            set
            {
                tenduocpham = value;
                if (tenduocpham == "")
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
        public string GIABAN
        {
            get
            {
                return giaban;
            }
            set
            {
                giaban = value;
                if (giaban == "")
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
