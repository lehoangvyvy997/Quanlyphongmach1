using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Hoadonthutien
    {
        SQL_tb_Hoadonthutien val = new SQL_tb_Hoadonthutien();

        public void themmoi(EC_tb_Hoadonthutien Val)
        {
            val.themmoi(Val);
        }
        public void sua_Bn(string maBenhnhan)
        {
            val.sua_Bn(maBenhnhan);
        }
        public string Load_mabs(string maPukh)
        {
            return val.Load_mabs(maPukh);
        }
        public string Load_tenbs(string maBs)
        {
            return val.Load_tenbs(maBs);
        }
        public string Load_chuandoan(string maPukh)
        {
            return val.Load_chuandoan(maPukh);
        }

        // load checkbox kê đơn thuốc
        public string Load_chkkedon(string maPukh)
        {
            return val.Load_chkkedon(maPukh);
        }
        // load checkbox DVKT
        public string Load_chkdvkt(string maPukh)
        {
            return val.Load_chkdvkt(maPukh);
        }
        // load checkbox DVSC
        public string Load_chkdvsc(string maPukh)
        {
            return val.Load_chkdvsc(maPukh);
        }
        // load tiền kê đơn thuốc
        public string Load_tienkedon(string maPukh)
        {
            return val.Load_tienkedon(maPukh);
        }
        // load tiền DVKT
        public string Load_tiendvkt(string maPukh)
        {
            return val.Load_tiendvkt(maPukh);
        }
        // load tiền DVSC
        public string Load_tiendvsc(string maPukh)
        {
            return val.Load_tiendvsc(maPukh);
        }
        // đếm số hóa đơn trong ngày
        public int demsohoadon_inday(DateTime date)
        {
            return val.demsohoadon_inday(date);
        }

    }
}
