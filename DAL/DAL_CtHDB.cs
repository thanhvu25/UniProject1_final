using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace DAL
{
    public class DAL_CtHDB : DBConnect
    {
        public DataTable getCtHDB()
        {
            string sql = "SELECT * FROM ChiTietHDB";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maHDB)
        {
            string sql = "SELECT COUNT(*) FROM ChiTietHDB WHERE MaHDB = @MaHDB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", maHDB }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_ThemChiTietHDB @MaHDB, @MaSP, @MaKH, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@MaKH", ctHDB.MaKH },
                { "@SL", ctHDB.SL },
                { "@MaNV", ctHDB.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_SuaChiTietHDB @MaHDB, @MaSP, @MaKH, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@MaKH", ctHDB.MaKH },
                { "@SL", ctHDB.SL },
                { "@MaNV", ctHDB.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_XoaChiTietHDB @MaHDB, @MaSP";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
