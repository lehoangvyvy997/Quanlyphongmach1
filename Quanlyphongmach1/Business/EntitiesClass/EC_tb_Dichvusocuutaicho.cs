using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Dichvusocuutaicho
    {
        private string maloaidvsocuu;
        private string tenloaidv;

        public string MALOAIDVSOCUU
        {
            get
            {
                return maloaidvsocuu;
            }
            set
            {
                maloaidvsocuu = value;
                if (maloaidvsocuu == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string TENLOAIDV
        {
            get
            {
                return tenloaidv;
            }
            set
            {
                tenloaidv = value;
                if (tenloaidv == "")
                {
                    throw new Exception("Tên loại tài khoản không được để trống!");
                }
            }
        }
    }
}
