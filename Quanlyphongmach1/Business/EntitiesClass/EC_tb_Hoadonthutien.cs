using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Hoadonthutien
    {
        private string mahoadonthutien;
        private string mabenhnhan;
        private string maphieukham1;
        private string maphieukham2;
        private string maphieukham3;
        private string ngaylaphoadon;
        private string tienkham;
        private string tienthuoc;
        private string tiensudungdvkythuatyte;
        private string tiensudungdvsocuu;
        private string tongtien;

        public string MAHOADONTHUTIEN
        {
            get
            {
                return mahoadonthutien;
            }
            set
            {
                mahoadonthutien = value;
                if (mahoadonthutien == "")
                {
                    throw new Exception("Mã háo đơn không thể để trống");
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
        public string MAPHIEUKHAM1
        {
            get
            {
                return maphieukham1;
            }
            set
            {
                maphieukham1 = value;
                if (maphieukham1 == "")
                {
                    throw new Exception("Mã phiếu khám 1 không thể để trống");
                }
            }
        }

        public string MAPHIEUKHAM2
        {
            get
            {
                return maphieukham2;
            }
            set
            {
                maphieukham2 = value;
            }
        }
        public string MAPHIEUKHAM3
        {
            get
            {
                return maphieukham3;
            }
            set
            {
                maphieukham3 = value;
            }
        }
        public string NGAYLAPHOADON
        {
            get
            {
                return ngaylaphoadon;
            }
            set
            {
                ngaylaphoadon = value;
                if (ngaylaphoadon == "")
                {
                    throw new Exception("Ngày lập hóa đơn không thể để trống");
                }
            }
        }
        public string TIENKHAM
        {
            get
            {
                return tienkham;
            }
            set
            {
                tienkham = value;
                if (tienkham == "")
                {
                    throw new Exception("Tiền khám không thể để trống");
                }
            }
        }

        public string TIENTHUOC
        {
            get
            {
                return tienthuoc;
            }
            set
            {
                tienthuoc = value;
                if (tienthuoc == "")
                {
                    throw new Exception("Tiền thuốc không thể để trống");
                }
            }
        }
        public string TIENSUDUNGDVKYTHUATYTE
        {
            get
            {
                return tiensudungdvkythuatyte;
            }
            set
            {
                tiensudungdvkythuatyte = value;
            }
        }
        public string TIENSUDUNGDVSOCUU
        {
            get
            {
                return tiensudungdvsocuu;
            }
            set
            {
                tiensudungdvsocuu = value;
            }
        }
        public string TONGTIEN
        {
            get
            {
                return tongtien;
            }
            set
            {
                tongtien = value;
            }
        }
    }
}
