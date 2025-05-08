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
    public class DAL_HDN : DBConnect
    {
        public DataTable getHDN()
        {
            string sql = "SELECT * FROM HDN";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maHDN)
        {
            string sql = "SELECT COUNT(*) FROM HDN WHERE MaHDN = @MaHDN";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", maHDN }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themHDN(DTO_HDN hdn)
        {
            string sql = "EXEC sp_ThemHDN @NgayNhap, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@NgayNhap", hdn.NgayNhap },
                { "@DonGia", hdn.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaHDN(DTO_HDN hdn)
        {
            string sql = "EXEC sp_SuaHDN @MaHDN, @NgayNhap, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", hdn.MaHDN },
                { "@NgayNhap", hdn.NgayNhap },
                { "@DonGia", hdn.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaHDN(DTO_HDN hdn)
        {
            string sql = "EXEC sp_XoaHDN @MaHDN";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", hdn.MaHDN }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
