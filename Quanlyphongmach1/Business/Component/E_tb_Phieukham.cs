using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quanlyphongmach1.Business.EntitiesClass;
using Quanlyphongmach1.DataAccess;
using System.Windows.Forms;

namespace Quanlyphongmach1.Business.Component
{
    class E_tb_Phieukham
    {
        SQL_tb_Phieukham keysql = new SQL_tb_Phieukham();


        // kiểm mã phiếu khám trong bảng chi tiết toa thuốc
        public bool kiemtramapukh_cttt(string mapukh)
        {
            return keysql.kiemtramapukh_cttt(mapukh);
        }

        public bool kiemtramapukh_ctsc(string mapukh)
        {
            return keysql.kiemtramapukh_ctsc(mapukh);
        }
        public bool kiemtramapukh_ctkt(string mapukh)
        {
            return keysql.kiemtramapukh_ctkt(mapukh);
        }
        public void themmoi(EC_tb_Phieukham val)
        {
            if(!keysql.kiemtramapukh(val.MAPHIEUKHAM))
            {
                keysql.themmoi(val);
                MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Mã phiếu khám đã tồn tại, hãy chọn mã khác!", "Chú Ý", MessageBoxButtons.OK);
            }
            keysql.themmoi(val);
        }
        // Xóa bệnh nhân bảng tạm
        public void xoa_bn(string maBn, string maPgKh)
        {
            keysql.xoa_bn(maBn, maPgKh);
        }
        // xóa chit tiết phiếu khám
        public void xoa_(string tab,string val)
        {
            keysql.xoa_(tab, val);
        }
        // Cộng hiệu hàng đợi lên 1
        public void sua_hhd(string maPhkh, string val)
        {
            keysql.sua_hhd(maPhkh, val);
        }



        // load thông tin bác sĩ
        public string load_hotenBS(string maNV)
        {
            return keysql.load_hotenBS(maNV);
        }
        public string load_tenchucvu(string maCV)
        {
            return keysql.load_tenchucvu(keysql.load_machuvu(maCV));
        }
        public string load_sdtnBS(string maNV)
        {
            return keysql.load_sdtnBS(maNV);
        }
        public string load_emailBS(string maNV)
        {
            return keysql.load_emailBS(maNV);
        }
        public string load_maPGKH(string maNV)
        {
            return keysql.load_maPGKH(maNV);
        }

        // load tên dịch vụ
        public string load_hotendvkt(string maDV)
        {
            return keysql.load_hotendvkt(maDV);
        }
        public int demsophieukham_inday(DateTime date, string maNV)
        {
            return keysql.demsophieukham_inday(date, maNV);
        }
    }
}
