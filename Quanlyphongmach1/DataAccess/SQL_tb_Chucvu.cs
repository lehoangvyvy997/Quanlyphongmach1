using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using System.Windows.Forms;

namespace Quanlyphongmach1.DataAccess
{
    class SQL_tb_Chucvu
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string Machucvu)
        {
            return cn.kiemtra("select count(*) from [CHUCVU] where MaChucVu='" + Machucvu + "'");
        }
        public void themmoi(EC_tb_Chucvu cv)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.CHUCVU
                      (MaChucVu,TenChucVu) VALUES   ('" + cv.MACHUCVU + "',N'" + cv.TENCHUCVU + "')");
        }
        public void xoa(EC_tb_Chucvu cv)
        {
            cn.ExcuteNonQuery("DELETE FROM dbo.CHUCVU WHERE [MaChucVu] = '" + cv.MACHUCVU + "'");
        }

        public void sua(EC_tb_Chucvu cv)
        {
            string sql = (@"UPDATE dbo.CHUCVU
            SET TenChucVu =N'" + cv.TENCHUCVU + "' where  MaChucVu ='" + cv.MACHUCVU + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
