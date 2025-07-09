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
            string sql = "SELECT SP.MaSP, SP.TenSP, TH.TenTH, SP.DonGia, SL = SUM(ISNULL(Kho.SLTon, 0))\r\nFROM SanPham SP\r\nLEFT JOIN Kho ON SP.MaSP = Kho.MaSP\r\nLEFT JOIN ThuongHieu TH ON SP.MaTH = TH.MaTH\r\nGROUP BY SP.MaSP, SP.TenSP, TH.TenTH, SP.DonGia ORDER BY SP.MaSP";
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
