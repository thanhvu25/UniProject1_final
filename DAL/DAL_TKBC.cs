using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_TKBC : DBConnect
    {
        public DataTable BaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT HDB.MaHDB, NgayBan, HDB.MaKH, HoTen, TongHD
                            FROM HDB
                            JOIN KhachHang ON HDB.MaKH = KhachHang.MaKH
                            WHERE HDB.NgayBan BETWEEN @TuNgay AND @DenNgay
                            ORDER BY HDB.NgayBan";

            var parameters = new Dictionary<string, object>
            {
                {"@TuNgay", tuNgay},
                {"@DenNgay", denNgay}
            };

            return ExecuteQuery(sql, parameters);
        }
        public string TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT SUM(TongHD) 
                           FROM HDB 
                           WHERE NgayBan BETWEEN @TuNgay AND @DenNgay";

            var parameters = new Dictionary<string, object>
            {
                { "@TuNgay", tuNgay },
                { "@DenNgay", denNgay }
            };

            return ExecuteScalarString(sql, parameters);
        }

        //public DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        //{
        //    string sql = @"
        //        SELECT CONVERT(date, NgayBan) AS Ngay, SUM(TongHD) AS DoanhThu
        //        FROM HDB
        //        WHERE NgayBan BETWEEN @TuNgay AND @DenNgay
        //        GROUP BY CONVERT(date, NgayBan)
        //        ORDER BY Ngay";

        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@TuNgay", tuNgay },
        //        { "@DenNgay", denNgay }
        //    };

        //    return ExecuteQuery(sql, parameters);
        //}

        public DataTable BaoCaoBanChay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT ChiTietHDB.MaSP, TenSP, SizeVN, TenMau, SUM(ChiTietHDB.SL) AS TongSL
                            FROM HDB
                            JOIN ChiTietHDB ON HDB.MaHDB = ChiTietHDB.MaHDB
                            JOIN SanPham ON ChiTietHDB.MaSP = SanPham.MaSP
                            JOIN MauSac ON ChiTietHDB.MaMau = MauSac.MaMau
                            WHERE HDB.NgayBan BETWEEN @TuNgay AND @DenNgay
                            GROUP BY ChiTietHDB.MaSP, TenSP, SizeVN, TenMau
                            ORDER BY TongSL DESC";

            var parameters = new Dictionary<string, object>
            {
                {"@TuNgay", tuNgay},
                {"@DenNgay", denNgay}
            };

            return ExecuteQuery(sql, parameters);
        }
    }
}
