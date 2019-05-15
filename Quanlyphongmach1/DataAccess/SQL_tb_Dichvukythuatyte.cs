using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Dichvukythuatyte
    {
        ConnectDB cn = new ConnectDB();

        public bool kiemtra(string Madv)
        {
            return cn.kiemtra("select count(*) from [DICHVUKYTHUATYTE] where MaDVKyThuat='" + Madv + "'");
        }
        public void themmoi(EC_tb_Dichvukythuatyte key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.DICHVUKYTHUATYTE
                      (MaDVKyThuat,TenDVKyThuat,ChiPhiSuDungDV) VALUES   ('" + key.MADVKYTHUAT + "',N'" + key.TENDVKYTHUAT + "','" + key.CHIPHISUDUNGDV + "')");
        }
        public void xoa(EC_tb_Dichvukythuatyte key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.DICHVUKYTHUATYTE WHERE [MaDVKyThuat] = '" + key.MADVKYTHUAT + "'");
        }

        public void sua(EC_tb_Dichvukythuatyte key)
        {
            string sql = (@"UPDATE dbo.DICHVUKYTHUATYTE
            SET TenDVKyThuat =N'" + key.TENDVKYTHUAT + "',ChiPhiSuDungDV ='" + key.CHIPHISUDUNGDV + "' where  MaDVKyThuat ='" + key.MADVKYTHUAT + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
