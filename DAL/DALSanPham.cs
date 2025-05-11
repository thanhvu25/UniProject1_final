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
            string sql = "SELECT SanPham.MaSP, TenSP, TenTH, DonGia, SLTon FROM SanPham LEFT JOIN Kho ON SanPham.MaSP = Kho.MaSP INNER JOIN ThuongHieu ON ThuongHieu.MaTH = SanPham.MaTH";
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
            string sql = "EXEC sp_ThemSanPham @TenSP, @MaTH, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@TenSP", sp.TenSP },
                { "@MaTH", sp.MaTH },
                { "@DonGia", sp.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaSP(DTOSanPham sp)
        {
            string sql = "EXEC sp_SuaSanPham @MaSP, @TenSP, @MaTH, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp.MaSP },
                { "@TenSP", sp.TenSP },
                { "@MaTH", sp.MaTH },
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
