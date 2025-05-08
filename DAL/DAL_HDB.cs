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
    public class DAL_HDB : DBConnect
    {
        public DataTable getHDB()
        {
            string sql = "SELECT * FROM HDB";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maHDB)
        {
            string sql = "SELECT COUNT(*) FROM HDB WHERE MaHDB = @MaHDB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", maHDB }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themHDB(DTO_HDB hdb)
        {
            string sql = "EXEC sp_ThemHDB @NgayBan, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@NgayBan", hdb.NgayBan },
                { "@DonGia", hdb.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaHDB(DTO_HDB hdb)
        {
            string sql = "EXEC sp_SuaHDB @MaHDB, @NgayBan, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", hdb.MaHDB },
                { "@NgayBan", hdb.NgayBan },
                { "@DonGia", hdb.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaHDB(DTO_HDB hdb)
        {
            string sql = "EXEC sp_XoaHDB @MaHDB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", hdb.MaHDB }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
