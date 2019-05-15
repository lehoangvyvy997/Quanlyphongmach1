using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chitietdvkythuatyte
    {
        private string maphieukham;
        private string madvkythuat;
        private string solansd;
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
        public string MADVKYTHUAT
        {
            get
            {
                return madvkythuat;
            }
            set
            {
                madvkythuat = value;
                if (madvkythuat == "")
                {
                    throw new Exception("Mã không được để trống!");
                }
            }
        }
        public string SOLANSD
        {
            get
            {
                return solansd;
            }
            set
            {
                solansd = value;
                if (solansd == "")
                {
                    throw new Exception("Số lần sử dụng không được để trống!");
                }
            }
        }
    }
}
