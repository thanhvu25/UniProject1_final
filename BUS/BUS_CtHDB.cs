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
    public class BUS_CtHDB
    {
        DAL_CtHDB dalcthdb = new DAL_CtHDB();
        public DataTable getCtHDB()
        {
            return dalcthdb.getCtHDB();
        }
        public int KiemTraMaTrung(string maCTB)
        {
            return dalcthdb.KiemTraMaTrung(maCTB);
        }
        public bool themCtHDB(DTO_CtHDB ct)
        {
            return dalcthdb.themCtHDB(ct);
        }
        public bool suaCtHDB(DTO_CtHDB ct)
        {
            return dalcthdb.suaCtHDB(ct);
        }
        public bool xoaCtHDB(DTO_CtHDB ct)
        {
            return dalcthdb.xoaCtHDB(ct);
        }

    }
}
