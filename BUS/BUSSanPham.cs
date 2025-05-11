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
    public class BUSSanPham
    {
        DALSanPham dalsp = new DALSanPham();
        public DataTable getSanPham()
        {
            return dalsp.getSanPham();
        }
        public DataTable getSanPhamForCombo()
        {
            return dalsp.getSanPhamForCombo();
        }

        public int KiemTraMaTrung(string maSP)
        {
            return dalsp.KiemTraMaTrung(maSP);
        }
        public bool themSP(DTOSanPham sp)
        {
            return dalsp.themSP(sp);
        }
        public bool suaSP(DTOSanPham sp)
        {
            return dalsp.suaSP(sp);
        }
        public bool xoaSP(DTOSanPham sp)
        {
            return dalsp.xoaSP(sp);
        }

    }
}
