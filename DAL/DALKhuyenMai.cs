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
    public class DALKhuyenMai : DBConnect
    {
        DBConnect connect = new DBConnect();

        public DataTable getKhuyenMai()
        {
            string sql = "SELECT * FROM KhuyenMai";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maKM)
        {
            string sql = "SELECT COUNT(*) FROM KhuyenMai WHERE MaKM = @MaKM";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", maKM }
            };
            return ExecuteScalar(sql, parameters);
        }
        /// <summary>
        /// CRUD khuyến mãi
        /// </summary>
        /// <param name="km"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool themKM(DTOKhuyenMai km)
        {
            string bd = km.NgayBD.ToString("yyyy/MM/dd");
            string kt = km.NgayKT.ToString("yyyy/MM/dd");

            string sql = "EXEC sp_ThemKhuyenMai @MaKM, @MaSP, @NgayBD, @NgayKT, @GiamGia, @HangKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", km.MaKM },
                { "@MaSP",  km.MaSP },
                { "@NgayBD", bd },
                { "@NgayKT", kt },
                { "@GiamGia", km.GiamGia },
                { "@HangKH", km.HangKH }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool suaKM(DTOKhuyenMai km)
        {
            string bd = km.NgayBD.ToString("yyyy/MM/dd");
            string kt = km.NgayKT.ToString("yyyy/MM/dd");

            string sql = "EXEC sp_SuaKhuyenMai @MaKM, @MaSP, @NgayBD, @NgayKT, @GiamGia, @HangKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", km.MaKM },
                { "@MaSP",  km.MaSP },
                { "@NgayBD", bd },
                { "@NgayKT", kt },
                { "@GiamGia", km.GiamGia },
                { "@HangKH", km.HangKH }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool xoaKM(DTOKhuyenMai km)
        {
            string sql = "EXEC sp_XoaKhuyenMai @MaKM";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", km.MaKM }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
