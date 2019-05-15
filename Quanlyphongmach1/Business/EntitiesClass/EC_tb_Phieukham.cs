using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Phieukham
    {
        private string maphieukham;
        private string manhanvien;
        private string mabenhnhan;
        private string ngaykham;
        private string chuandoanbenh;
        private string kedonthuoc;
        private string sudungdvkythuatyte;
        private string sudungdvsocuu;
        private string tongtienthuoc;
        private string tongtiendvkythuat;
        private string tongtiendvsocuu;

        public string KEDONTHUOC
        {
            get
            {
                return kedonthuoc;
            }
            set
            {
                kedonthuoc = value;
                if (maphieukham == "")
                {
                    throw new Exception("Kê đơn thuốc không thể để trống");
                }
            }
        }
        public string TONGTIENTHUOC
        {
            get
            {
                return tongtienthuoc;
            }
            set
            {
                tongtienthuoc = value;

            }
        }

        public string TONGTIENDVKYTHUAT
        {
            get
            {
                return tongtiendvkythuat;
            }
            set
            {
                tongtiendvkythuat = value;

            }
        }
        public string TONGTIENDVSOCUU
        {
            get
            {
                return tongtiendvsocuu;
            }
            set
            {
                tongtiendvsocuu = value;
                
            }
        }
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
                    throw new Exception("Mã không thể để trống");
                }
            }
        }
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

        public string MABENHNHAN
        {
            get
            {
                return mabenhnhan;
            }
            set
            {
                mabenhnhan = value;
                if (mabenhnhan == "")
                {
                    throw new Exception("Mã không thể để trống");
                }
            }
        }

        public string NGAYKHAM
        {
            get
            {
                return ngaykham;
            }
            set
            {
                ngaykham = value;
                if (ngaykham == "")
                {
                    throw new Exception("Ngày khám không thể để trống");
                }
            }
        }
        public string CHUANDOANBENH
        {
            get
            {
                return chuandoanbenh;
            }
            set
            {
                chuandoanbenh = value;
                if (chuandoanbenh == "")
                {
                    throw new Exception("Chuẩn đón bệnh không thể để trống");
                }
            }
        }

        public string SUDUNGDVKYTHUATYTE
        {
            get
            {
                return sudungdvkythuatyte;
            }
            set
            {
                sudungdvkythuatyte = value;
                if (sudungdvkythuatyte == "")
                {
                    throw new Exception("Sử dụng dịch vụ kỹ thuật y tế không thể để trống");
                }
            }
        }

        public string SUDUNGDVSOCUU
        {
            get
            {
                return sudungdvsocuu;
            }
            set
            {
                sudungdvsocuu = value;
                if (sudungdvsocuu == "")
                {
                    throw new Exception("Sử dụng dịch vụ sơ cứu không thể để trống");
                }
            }
        }
    }
}
