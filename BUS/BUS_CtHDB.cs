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

        private static BUS_CtHDB instance;

        public static BUS_CtHDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_CtHDB();
                return instance;
            }
        }

        public DataTable getCtHDB()
        {
            return dalcthdb.getCtHDB();
        }
        public DataTable getCTHDBForHDB(string maHDB)
        {
            return dalcthdb.getCTHDBForHDB(maHDB);
        }

        public DataTable getCtHDBByMaHDB(string maHDB)
        {
            return dalcthdb.getCtHDBByMaHDB(maHDB);
        }
        public DataTable getHDBForHD(string maHDB)
        {
            return dalcthdb.getHDBForHD(maHDB);
        }

        //public int KiemTraMaTrung(string maCTB)
        //{
        //    return dalcthdb.KiemTraMaTrung(maCTB);
        //}
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
