using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Chucvu
    {
        private string  machucvu;
        private string tenchucvu;

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
        public string TENCHUCVU
        {
            get
            {
                return tenchucvu;
            }
            set
            {
                tenchucvu = value;
            }
        }
    }
}
