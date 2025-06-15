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
    public class BUS_HDB
    {
        DAL_HDB dalhdb = new DAL_HDB();
        public DataTable getHDB()
        {
            return dalhdb.getHDB();
        }
        public string GetMaHDBMoiNhat()
        {
            return dalhdb.GetMaHDBMoiNhat();
        }

        public int KiemTraMaTrung(string mahd)
        {
            return dalhdb.KiemTraMaTrung(mahd);
        }
        public bool themHDB(DTO_HDB hdb)
        {
            return dalhdb.themHDB(hdb);
        }
        public string themHDBAndGetMaHDB(DTO_HDB hdb)
        {
            return dalhdb.themHDBAndGetMaHDB(hdb);
        }
        public bool suaHDB(DTO_HDB hdb)
        {
            return dalhdb.suaHDB(hdb);
        }
        public bool xoaHDB(DTO_HDB hdb)
        {
            return dalhdb.xoaHDB(hdb);
        }

    }
}
