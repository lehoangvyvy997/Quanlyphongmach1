using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Dichvusocuutaicho
    {
        ConnectDB cn = new ConnectDB();
        
        public bool kiemtra(string Madv)
        {
            return cn.kiemtra("select count(*) from [DICHVUSOCUUTAICHO] where MaLoaiDVSoCuu='" + Madv + "'");
        }
        public void themmoi(EC_tb_Dichvusocuutaicho key)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.DICHVUSOCUUTAICHO
                      (MaLoaiDVSoCuu,TenLoaiDV) VALUES   ('" + key.MALOAIDVSOCUU + "',N'" + key.TENLOAIDV + "')");
        }
        public void xoa(EC_tb_Dichvusocuutaicho key)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.DICHVUSOCUUTAICHO WHERE [MaLoaiDVSoCuu] = '" + key.MALOAIDVSOCUU + "'");
        }

        public void sua(EC_tb_Dichvusocuutaicho key)
        {
            string sql = (@"UPDATE dbo.DICHVUSOCUUTAICHO
            SET TenLoaiDV =N'" + key.TENLOAIDV + "' where  MaLoaiDVSoCuu ='" + key.MALOAIDVSOCUU + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
