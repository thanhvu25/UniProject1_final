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
    public class DAL_CtHDN : DBConnect
    {
        public DataTable getCtHDN()
        {
            string sql = "SELECT * FROM ChitietHDN";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maHDN)
        {
            string sql = "SELECT COUNT(*) FROM ChitietHDN WHERE MaHDN = @MaHDN";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", maHDN }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_ThemChiTietHDN @MaHDN, @MaSP, @MaTH, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP },
                { "@MaTH", cthdn.MaTH },
                { "@SL", cthdn.SL },
                { "@MaNV", cthdn.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_SuaChiTietHDN @MaHDN, @MaSP, @MaTH, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP },
                { "@MaTH", cthdn.MaTH },
                { "@SL", cthdn.SL },
                { "@MaNV", cthdn.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_XoaChiTietHDN @MaHDN, @MaSP";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
