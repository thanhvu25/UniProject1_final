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
    public class BUS_HDN
    {
        DAL_HDN dalhdn = new DAL_HDN();
        public DataTable getHDN() //lấy ttin bảng HDN và đổ ra dgv
        {
            return dalhdn.getHDN();
        }
        public int KiemtraMaTrung(string maHDN)
        {
            return dalhdn.KiemTraMaTrung(maHDN);
        }
        public bool themHDN(DTO_HDN hdn)
        {
            return dalhdn.themHDN(hdn);
        }
        public bool suaHDN(DTO_HDN hdn)
        {
            return dalhdn.suaHDN(hdn);
        }
        public bool xoaHDN(DTO_HDN hdn)
        {
            return dalhdn.xoaHDN(hdn);
        }
    }
}
