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
    public class BUS_TKBC
    {
        DAL_TKBC dalBaoCao = new DAL_TKBC();

        public DataTable LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dalBaoCao.BaoCaoDoanhThu(tuNgay, denNgay);
        }
        public string TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dalBaoCao.TongDoanhThu(tuNgay, denNgay);
        }
        //public DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        //{
        //    return dalBaoCao.LayDoanhThuTheoNgay(tuNgay, denNgay);
        //}
        public DataTable LayBaoCaoBanChay(DateTime tuNgay, DateTime denNgay)
        {
            return dalBaoCao.BaoCaoBanChay(tuNgay, denNgay);
        }
    }
}
