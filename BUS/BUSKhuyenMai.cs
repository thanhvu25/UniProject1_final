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
    public class BUSKhuyenMai
    {
        DALKhuyenMai dalkm = new DALKhuyenMai();
        public DataTable getKhuyenMai() //lấy ttin bảng NV và đổ ra dgv
        {
            return dalkm.getKhuyenMai();
        }
        public int KiemTraMaTrung(string maKM)
        {
            return dalkm.KiemTraMaTrung(maKM);
        }
        public bool themKM(DTOKhuyenMai km)
        {
            return dalkm.themKM(km);
        }
        public bool suaKM(DTOKhuyenMai km)
        {
            return dalkm.suaKM(km);
        }
        public bool xoaKM(DTOKhuyenMai km)
        {
            return dalkm.xoaKM(km);
        }
    }
}
