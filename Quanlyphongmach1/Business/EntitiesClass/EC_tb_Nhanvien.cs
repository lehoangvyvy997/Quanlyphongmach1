using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Nhanvien
    {
        private string manhanvien;
        private string maloainhanvien;
        private string machucvu;
        private string mattlv;
        private string tennhanvien;
        private string ngaysinh;
        private string gioitinh;
        private string sdt;
        private string email;
        private string ngayvaolam;
        private string tienluong;
        private string tientrocap;
        private string tienthuong;
        private string maphongkham;

        public string MAHNHANVIEN
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

        public string MACHUCVU
        {
            get
            {
                return machucvu;
            }
            set
            {
                machucvu = value;
                if (machucvu == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

        public string MATTLV
        {
            get
            {
                return mattlv;
            }
            set
            {
                mattlv = value;
                if (mattlv == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }

        public string TENNHANVIEN
        {
            get
            {
                return tennhanvien;
            }
            set
            {
                tennhanvien = value;
                if (tennhanvien == "")
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
            }
        }
        public string NGAYSINH
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
                if (ngaysinh == "")
                {
                    throw new Exception("Ngày sinh không được để trống");
                }
            }
        }

        public string GIOITINH
        {
            get
            {
                return gioitinh;
            }
            set
            {
                gioitinh = value;
                if (gioitinh == "")
                {
                    throw new Exception("Giới tính không được để trống");
                }
            }
        }

        public string SDT
        {
            get
            {
                return sdt;
            }
            set
            {
                sdt = value;
                if (sdt == "")
                {
                    throw new Exception("Số điện thoại không được để trống");
                }
            }
        }
        public string EMAIL
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                if (email == "")
                {
                    throw new Exception("Email không được để trống");
                }
            }
        }
        public string NGAYVAOLAM
        {
            get
            {
                return ngayvaolam;
            }
            set
            {
                ngayvaolam = value;
                if (ngayvaolam == "")
                {
                    throw new Exception("Ngày vào làm không được để trống");
                }
            }
        }
        public string TIENTROCAP
        {
            get
            {
                return tientrocap;
            }
            set
            {
                tientrocap = value;
            }
        }
        public string TIENTHUONG
        {
            get
            {
                return tienthuong;
            }
            set
            {
                tienthuong = value;
            }
        }
        public string TIENLUONG
        {
            get
            {
                return tienluong;
            }
            set
            {
                tienluong = value;
            }
        }
        public string MAPHONGKHAM
        {
            get
            {
                return maphongkham;
            }
            set
            {
                maphongkham = value;
            }
        }
    }
}
