using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Tinhtranglamviec
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string mattlv)
        {
            return cn.kiemtra("select count(*) from [TINHTRANGLAMVIEC] where MaTTLV='" + mattlv + "'");
        }
        public void themmoi(EC_tb_Tinhtranglamviec ttlv)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.TINHTRANGLAMVIEC
                      (MaTTLV,TenTTLV) VALUES   ('" + ttlv.MATTLV + "',N'" + ttlv.TENTTLV + "')");
        }
        public void xoa(EC_tb_Tinhtranglamviec ttlv)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.TINHTRANGLAMVIEC WHERE [MaTTLV] = '" + ttlv.MATTLV + "'");
        }

        public void sua(EC_tb_Tinhtranglamviec ttlv)
        {
            string sql = (@"UPDATE dbo.TINHTRANGLAMVIEC
            SET TenTTLV =N'" + ttlv.TENTTLV + "' where  MaTTLV ='" + ttlv.MATTLV + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
