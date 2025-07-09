using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUSThuongHieu
    {
        DALThuongHieu dalth = new DALThuongHieu();

        public DataTable getThuongHieu() 
        {
            return dalth.getThuongHieu();
        }
//        public DataTable getTHForHDN() 
//=======
        //public DataTable getThuongHieu()
        //{
        //    return dalth.getThuongHieu();
        //}
        public DataTable getTHForHDN()
        {
            return dalth.getTHForHDN();
        }
        public int KiemTraMaTrung(string maTH)
        {
            return dalth.KiemTraMaTrung(maTH);
        }
        public bool themTH(DTOThuongHieu th)
        {
            return dalth.themTH(th);
        }
        public bool suaTH(DTOThuongHieu th)
        {
            return dalth.suaTH(th);
        }
        public bool xoaTH(DTOThuongHieu th)
        {
            return dalth.xoaTH(th);
        }
    }
}
