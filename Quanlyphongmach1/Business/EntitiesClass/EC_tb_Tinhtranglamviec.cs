using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Tinhtranglamviec
    {
        private string mattlv;
        private string tenttlv;

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
        public string TENTTLV
        {
            get
            {
                return tenttlv;
            }
            set
            {
                tenttlv = value;
                if (tenttlv == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
    }
}
