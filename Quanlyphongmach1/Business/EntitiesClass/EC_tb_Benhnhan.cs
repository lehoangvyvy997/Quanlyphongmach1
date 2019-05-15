using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Benhnhan
    {
        private string mabenhnhan;
        private string hotenbenhnhan;
        private string tuoi;
        private string gioitinh;
        private string socmnd;
        private string diachi;
        private string chuandonsoluot;
        private string ngaykhambenh;
        private string maphongkham1;
        private string sttphongkham1;
        private string maphongkham2;
        private string sttphongkham2;
        private string maphongkham3;
        private string sttphongkham3;
        private string thuvienphi;
        private string nhanthuoc;

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

        public string HOTENBENHNHAN
        {
            get
            {
                return hotenbenhnhan;
            }
            set
            {
                hotenbenhnhan = value;
                if (hotenbenhnhan == "")
                {
                    throw new Exception("Họ tên bệnh nhân không thể để trống");
                }
            }
        }

        public string TUOI
        {
            get
            {
                return tuoi;
            }
            set
            {
                tuoi = value;
                if (tuoi == "")
                {
                    throw new Exception("Tuổi bệnh nhân không thể để trống");
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
                    throw new Exception("Giới tính bệnh nhân không thể để trống");
                }
            }
        }
        public string SOCMND
        {
            get
            {
                return socmnd;
            }
            set
            {
                socmnd = value;
            }
        }
        public string DIACHI
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
                if (diachi == "")
                {
                    throw new Exception("Địa chỉ bệnh nhân không thể để trống");
                }
            }
        }

        public string CHUANDONSOLUOT
        {
            get
            {
                return chuandonsoluot;
            }
            set
            {
                chuandonsoluot = value;
                if (chuandonsoluot == "")
                {
                    throw new Exception("Chuẩn đón sơ lượt bệnh nhân không thể để trống");
                }
            }
        }
        public string NGAYKHAMBENH
        {
            get
            {
                return ngaykhambenh;
            }
            set
            {
                ngaykhambenh = value;
            }
        }
        public string MAPHONGKHAM1
        {
            get
            {
                return maphongkham1;
            }
            set
            {
                maphongkham1 = value;
                if (maphongkham1 == "")
                {
                    throw new Exception("Mã phòng khám 1 không thể để trống");
                }
            }
        }

        public string STTPHONGKHAM1
        {
            get
            {
                return sttphongkham1;
            }
            set
            {
                sttphongkham1 = value;
                if (sttphongkham1 == "")
                {
                    throw new Exception("Số thứ tự phòng khám 1 không thể để trống");
                }
            }
        }

        public string MAPHONGKHAM2
        {
            get
            {
                return maphongkham2;
            }
            set
            {
                maphongkham2 = value;
            }
        }

        public string STTPHONGKHAM2
        {
            get
            {
                return sttphongkham2;
            }
            set
            {
                sttphongkham2 = value;
            }
        }
        public string MAPHONGKHAM3
        {
            get
            {
                return maphongkham3;
            }
            set
            {
                maphongkham3 = value;
            }
        }

        public string STTPHONGKHAM3
        {
            get
            {
                return sttphongkham3;
            }
            set
            {
                sttphongkham3 = value;
            }
        }
        public string THUVIENPHI
        {
            get
            {
                return thuvienphi;
            }
            set
            {
                thuvienphi = value;
            }
        }
        public string NHANTHUOC
        {
            get
            {
                return nhanthuoc;
            }
            set
            {
                nhanthuoc = value;
            }
        }
    }
}
