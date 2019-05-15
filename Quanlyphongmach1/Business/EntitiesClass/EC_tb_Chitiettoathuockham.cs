using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chitiettoathuockham
    {
        private string maphieukham;
        private string mathuockham;
        private string soluong;
        private string cachdung;
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
            }
        }
        public string THANHTIEN
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        public string MATHUOCKHAM
        {
            get
            {
                return mathuockham;
            }
            set
            {
                mathuockham = value;
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
        public string CACHDUNG
        {
            get
            {
                return cachdung;
            }
            set
            {
                cachdung = value;
                if (cachdung == "")
                {
                    throw new Exception("Cách dùng không được để trống");
                }
            }
        }

    }
}
