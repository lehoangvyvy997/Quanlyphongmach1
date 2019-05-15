using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Taikhoan
    {
        private string username;
        private string maloaitaikhoan;
        private string manhanvien;
        private string password1;
        private string password2;

        public string USERNAME
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                if (username == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string MALOAITAIKHOAN
        {
            get
            {
                return maloaitaikhoan;
            }
            set
            {
                maloaitaikhoan = value;
                if (maloaitaikhoan == "")
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
            }
        }
        public string PASSWORD1
        {
            get
            {
                return password1;
            }
            set
            {
                password1 = value;
                if (password1 == "")
                {
                    throw new Exception("Không được để trống Password1");
                }
            }
        }
        public string PASSWORD2
        {
            get
            {
                return password2;
            }
            set
            {
                password2 = value;
                if (password2 == "")
                {
                    throw new Exception("Không được để trống Password2");
                }
            }
        }
    }
}
