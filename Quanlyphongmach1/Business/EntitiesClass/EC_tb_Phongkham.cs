using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Phongkham
    {
        private string maphongkham;
        private string hangdoi;
        private string tenphongkham;
        private string hieuhangdoi;

        public string HIEUHANGDOI
        {
            get
            {
                return hieuhangdoi;
            }
            set
            {
                hieuhangdoi = value;
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
                if (maphongkham == "")
                {
                    throw new Exception("Mã phòng khám không được để trống");
                }
            }
        }
        public string HANGDOI
        {
            get
            {
                return hangdoi;
            }
            set
            {
                hangdoi = value;
            }
        }
        public string TENPHONGKHAM
        {
            get
            {
                return tenphongkham;
            }
            set
            {
                tenphongkham = value;
                if (tenphongkham == "")
                {
                    throw new Exception("Tên phòng khám không được để trống");
                }
            }
        }
    }
}
