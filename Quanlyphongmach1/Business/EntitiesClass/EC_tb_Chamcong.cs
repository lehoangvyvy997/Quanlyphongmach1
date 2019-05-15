using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chamcong
    {
        private string machamcong;
        private string manhanvien;
        private string ngaychamcong;
        private string nghicophep;

        public string MACHAMCONG
        {
            get
            {
                return machamcong;
            }
            set
            {
                machamcong = value;
                if (machamcong == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string MANHANVIEN
        {
            get
            {
                return manhanvien;
            }
            set
            {
                manhanvien = value;
                if (manhanvien == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

        public string NGAYCHAMCONG
        {
            get
            {
                return ngaychamcong;
            }
            set
            {
                ngaychamcong = value;
                if (ngaychamcong == "")
                {
                    throw new Exception("Ngày chấm công không được để trống");
                }
            }
        }

        public string NGHICOPHEP
        {
            get
            {
                return nghicophep;
            }
            set
            {
                nghicophep = value;
                if (nghicophep == "")
                {
                    throw new Exception("Nghỉ có không được để trống");
                }
            }
        }
    }
}
