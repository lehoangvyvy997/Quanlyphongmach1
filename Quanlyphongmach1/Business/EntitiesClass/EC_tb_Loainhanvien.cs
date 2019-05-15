using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Loainhanvien
    {
        private string maloainhanvien;
        private string tenloainhanvien;

        public string MALOAINHANVIEN
        {
            get
            {
                return maloainhanvien;
            }
            set
            {
                maloainhanvien = value;
                if (maloainhanvien == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string TENLOAINHANVIEN
        {
            get
            {
                return tenloainhanvien;
            }
            set
            {
                tenloainhanvien = value;
            }
        }
    }
}
