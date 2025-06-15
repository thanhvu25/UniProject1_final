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
    public class DALKhachHang : DBConnect
    {
        public DataTable getKhachHang()
        {
            string sql = "SELECT * FROM KhachHang";
            return ExecuteQuery(sql);
        }
        public DataTable getKhachHangForBH()
        {
            string sql = "SELECT MaKH, HoTen, Sdt, HangKH FROM KhachHang";
            return ExecuteQuery(sql);
        }
        public DataTable getKhachHang_HD(string MaKH)
        {
            string sql = "SELECT KhachHang.MaKH, HoTen, HDB.MaHDB, NgayBan, ChiTietHDB.DonGia, TenSP, SizeVN, TenMau\r\nFROM KhachHang \r\nINNER JOIN HDB\t\t\tON KhachHang.MaKH = HDB.MaKH \r\nINNER JOIN ChiTietHDB\tON HDB.MaHDB = ChiTietHDB.MaHDB \r\nINNER JOIN MauSac\t\tON ChiTietHDB.MaMau = MauSac.MaMau \r\nINNER JOIN SanPham\t\tON SanPham.MaSP = ChiTietHDB.MaSP WHERE KhachHang.MaKH = @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", MaKH }
            };
            return ExecuteQuery(sql, parameters);
        }

        public int KiemTraMaTrung(string maKH)
        {
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH }
            };
            return ExecuteScalar(sql, parameters);
        }
        /// <summary>
        /// CRUD khách hàng
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public bool themKH(DTOKhachHang kh)
        {
            string sql = "EXEC sp_ThemKhachHang @HoTen, @GioiTinh, @DiaChi, @Sdt, @HangKH";
            var parameters = new Dictionary<string, object>
            {
                { "@HoTen", kh.HoTen },
                { "@GioiTinh", kh.GioiTinh },
                { "@DiaChi", kh.DiaChi },
                { "@Sdt", kh.Sdt },
                { "@HangKH", kh.HangKH }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaKH(DTOKhachHang kh)
        {
            string sql = "EXEC sp_SuaKhachHang @MaKH, @HoTen, @GioiTinh, @DiaChi, @Sdt, @HangKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", kh.MaKH },
                { "@HoTen", kh.HoTen },
                { "@GioiTinh", kh.GioiTinh },
                { "@DiaChi", kh.DiaChi },
                { "@Sdt", kh.Sdt },
                { "@HangKH", kh.HangKH }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaKH(DTOKhachHang kh)
        {
            string sql = "EXEC sp_XoaKhachHang @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", kh.MaKH }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public void CapNhatHangKhachHang()
        {
            string sql = @"SELECT 
                                kh.MaKH,
                                COUNT(DISTINCT hdb.MaHDB) AS SoDon,
                                SUM(ct.DonGia * ct.SL) AS TongTien
                            FROM KhachHang kh
                            LEFT JOIN HDB hdb ON kh.MaKH = hdb.MaKH
                            LEFT JOIN ChiTietHDB ct ON hdb.MaHDB = ct.MaHDB
                            WHERE MONTH(hdb.NgayBan) = MONTH(GETDATE()) AND YEAR(hdb.NgayBan) = YEAR(GETDATE())
                            GROUP BY kh.MaKH";

            DataTable dt = ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                string maKH = row["MaKH"].ToString();
                int soDon = row["SoDon"] == DBNull.Value ? 0 : Convert.ToInt32(row["SoDon"]);
                decimal tongTien = row["TongTien"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TongTien"]);
                string hangKH;

                if (soDon > 20 || tongTien > 50000000)
                    hangKH = "VIP";
                else if (soDon > 10 || tongTien > 30000000)
                    hangKH = "Thân thiết";
                else
                    hangKH = "Thường";

                string updateSql = "UPDATE KhachHang SET HangKH = @HangKH WHERE MaKH = @MaKH";
                var updateParams = new Dictionary<string, object>
                {
                    {"@HangKH", hangKH},
                    {"@MaKH", maKH}
                };

                ExecuteNonQuery(updateSql, updateParams);
            }
        }

        public DataTable getKhachHangByLevel(string HangKH)
        {
            string sql = "SELECT MaKH, HoTen, GioiTinh, DiaChi, Sdt, HangKH\r\nFROM KhachHang \r\nWHERE HangKH = @HangKH";
            var parameters = new Dictionary<string, object>
            {
                { "@HangKH", HangKH }
            };
            return ExecuteQuery(sql, parameters);
        }
    }
}