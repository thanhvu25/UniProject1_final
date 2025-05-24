using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALSanPham : DBConnect
    {
        public DataTable getSanPham()
        {
            string sql = "SELECT SanPham.MaSP, TenSP, TenTH, SanPham.DonGia, SL = SUM(ISNULL(Kho.SLTon, 0)) \r\nFROM SanPham LEFT JOIN Kho \r\nON SanPham.MaSP = Kho.MaSP INNER JOIN ChiTietHDN\r\nON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN\r\nON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu\r\nON HDN.MaHDN = ThuongHieu.MaTH\r\nGROUP BY SanPham.MaSP, TenSP, TenTH, SanPham.DonGia";
            return ExecuteQuery(sql);
        }
        public DataTable getSanPhamForCombo()
        {
            string sql = "SELECT MaSP, TenSP FROM SanPham";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maSP)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSP", maSP }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themSP(DTOSanPham sp)
        {
            string sql = "EXEC sp_ThemSanPham @TenSP, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@TenSP", sp.TenSP },
                { "@DonGia", sp.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaSP(DTOSanPham sp)
        {
            string sql = "EXEC sp_SuaSanPham @MaSP, @TenSP, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp.MaSP },
                { "@TenSP", sp.TenSP },
                { "@DonGia", sp.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaSP(DTOSanPham sp)
        {
            string sql = "EXEC sp_XoaSanPham @MaSP";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp.MaSP }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
