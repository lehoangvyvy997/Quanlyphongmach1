using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chitietdvsocuutaicho
    {

        private string maphieukham;
        private string maduocphamdvsocuu;
        private string maloaidvsocuu;
        private string soluong;
        private string thanhtien;

        public string MAPHIEUKHAM
        {
            get
            {
                return maphieukham;
            }
            set
            {
                maphieukham = value;
                if (maphieukham == "")
                {
                    throw new Exception("Mã phiếu khám không được để trống!");
                }
            }
        }
        public string THANHTIEN
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
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
        public string MALOAIDVSOCUU
        {
            get
            {
                return maloaidvsocuu;
            }
            set
            {
                maloaidvsocuu = value;
                if (maloaidvsocuu == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

        public string SOLUONG
        {
            get
            {
                return soluong;
            }
            set
            {
                soluong = value;
                if (soluong == "")
                {
                    throw new Exception("Số lượng không được để trống");
                }
            }
        }
    }
}
