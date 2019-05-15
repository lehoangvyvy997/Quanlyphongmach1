using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlyphongmach1.Business.EntitiesClass
{
    class EC_tb_Dichvukythuatyte
    {
        private string madvkythuat;
        private string tendvkythuat;
        private string chiphisudungdv;

        public string MADVKYTHUAT
        {
            get
            {
                return madvkythuat;
            }
            set
            {
                madvkythuat = value;
                if (madvkythuat == "")
                {
                    throw new Exception("Mã không được để trống");
                }
            }
        }
        public string TENDVKYTHUAT
        {
            get
            {
                return tendvkythuat;
            }
            set
            {
                tendvkythuat = value;
                if (tendvkythuat == "")
                {
                    throw new Exception("Tên loại dịch vụ kỹ thuật không được để trống!");
                }
            }
        }

        public string CHIPHISUDUNGDV
        {
            get
            {
                return chiphisudungdv;
            }
            set
            {
                chiphisudungdv = value;
                if (chiphisudungdv == "")
                {
                    throw new Exception("Chi phí sử dụng dịch vụ kỹ thuật không được để trống!");
                }
            }
        }
    }
}
