using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUSNhanVien
    {
        DALNhanVien dalnv = new DALNhanVien();
        public DataTable getNhanVien() //lấy ttin bảng NV và đổ ra dgv
        {
            return dalnv.getNhanVien();
        }
        public int KiemTraMaTrung(string maNV)
        {
            return dalnv.KiemTraMaTrung(maNV);
        }
        public bool themNV(DTONhanVien nv)
        {
            return dalnv.themNV(nv);
        }
        public bool suaNV(DTONhanVien nv)
        {
            return dalnv.suaNV(nv);
        }
        public bool xoaNV(DTONhanVien nv)
        {
            return dalnv.xoaNV(nv);
        }

    }
}
