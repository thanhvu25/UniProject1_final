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
            string sql = "SELECT HDB.MaHDB, HoTen, NgayBan, TongHD, TenNV\r\nFROM HDB \r\nINNER JOIN NhanVien\t\tON HDB.MaNV = NhanVien.MaNV \r\nINNER JOIN KhachHang\tON HDB.MaKH = KhachHang.MaKH";
            return ExecuteQuery(sql);
        }
        public string GetMaHDBMoiNhat()
        {
            string sql = "SELECT TOP 1 MaHDB FROM HDB ORDER BY MaHDB DESC";
            object result = ExecuteScalar(sql);
            return result.ToString();
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
            string sql = "EXEC sp_ThemHDB  @MaKH, @NgayBan, @TongHD, @MaNV ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", hdb.MaKH },
                { "@NgayBan", hdb.NgayBan },
                { "@TongHD", hdb.TongHD },
                { "@MaNV", hdb.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public string themHDBAndGetMaHDB(DTO_HDB hdb)
        {
            string sql = "EXEC sp_ThemHDB @MaKH, @NgayBan, @TongHD, @MaNV, @MaHDB OUTPUT";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", hdb.MaKH ?? (object)DBNull.Value },
                { "@NgayBan", hdb.NgayBan == default(DateTime) ? (object)DBNull.Value : (object)hdb.NgayBan },
                { "@TongHD", hdb.TongHD },
                { "@MaNV", hdb.MaNV ?? (object)DBNull.Value },
                { "@MaHDB", new SqlParameter { ParameterName = "@MaHDB", SqlDbType = SqlDbType.Char, Size = 4, Direction = ParameterDirection.Output } }
            };
            string maHDB = ExecuteNonQueryWithOutput(sql, parameters, "@MaHDB", SqlDbType.Char);
            if (string.IsNullOrEmpty(maHDB))
            {
                throw new Exception("Không thể lấy MaHDB từ stored procedure.");
            }
            return maHDB.Trim(); // Loại bỏ khoảng trắng thừa do CHAR(10)
        }

        public bool suaHDB(DTO_HDB hdb)
        {
            string sql = "EXEC sp_SuaHDB, @MaHDB, @MaKH, @NgayBan, @TongHD, @MaNV ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", hdb.MaHDB },
                { "@MaKH", hdb.MaKH },
                { "@NgayBan", hdb.NgayBan },
                { "@TongHD", hdb.TongHD },
                { "@MaNV", hdb.MaNV }
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
