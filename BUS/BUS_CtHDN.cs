using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUS_CtHDN
    {
        DAL_CtHDN dalcthdn = new DAL_CtHDN();
        public DataTable getCtHDN() //lấy ttin bảng CT_HDN và đổ ra dgv
        {
            return dalcthdn.getCtHDN();
        }
        public DataTable getCtHDNForHDN(string maHDN)
        {
            return dalcthdn.getCtHDNForHDN(maHDN);
        }
        public int KiemTraMaTrung(string maCTN)
        {
            return dalcthdn.KiemTraMaTrung(maCTN);
        }
        public bool themCtHDN(DTO_CtHDN cthdn)
        {
            return dalcthdn.themCtHDN(cthdn);
        }
        public bool suaCtHDN(DTO_CtHDN cthdn)
        {
            return dalcthdn.suaCtHDN(cthdn);
        }
        public bool xoaCtHDN(DTO_CtHDN cthdn)
        {
            return dalcthdn.xoaCtHDN(cthdn);
        }
    }
}
