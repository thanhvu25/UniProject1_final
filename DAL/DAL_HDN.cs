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
            string sql = "SELECT HDN.MaHDN, TenTH, NgayNhap, TongHD, TenNV\r\nFROM HDN \r\nINNER JOIN NhanVien\t\tON HDN.MaNV = NhanVien.MaNV \r\nINNER JOIN ThuongHieu\tON HDN.MaTH = ThuongHieu.MaTH";
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
            string sql = "EXEC sp_ThemHDN @MaTH, @NgayNhap, @TongHD, @MaNV, ";
            var parameters = new Dictionary<string, object>
            {
                { "@NgayNhap", hdn.NgayNhap },
                { "@TongHD", hdn.TongHD },
                { "@MaNV", hdn.MaNV },
                { "@MaHDN", hdn.MaHDN }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaHDN(DTO_HDN hdn)
        {
            string sql = "EXEC sp_SuaHDN @MaHDN, @MaTH, @NgayNhap, @TongHD, @MaNV ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", hdn.MaHDN },
                { "@MaTH", hdn.MaTH },
                { "@NgayNhap", hdn.NgayNhap },
                { "@TongHD", hdn.TongHD },
                { "@MaNV", hdn.MaNV }
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
