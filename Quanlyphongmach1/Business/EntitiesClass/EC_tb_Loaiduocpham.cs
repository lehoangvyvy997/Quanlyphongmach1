using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Loaiduocpham
    {
        private string maloaiduocpham;
        private string tenloaiduocpham;

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

        public string TENLOAIDUOCPHAM
        {
            get
            {
                return tenloaiduocpham;
            }
            set
            {
                tenloaiduocpham = value;
                if (tenloaiduocpham == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
    }
}
