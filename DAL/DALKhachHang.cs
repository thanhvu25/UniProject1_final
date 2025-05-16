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
            string sql = "SELECT MaKH, HoTen, HangKH FROM KhachHang";
            return ExecuteQuery(sql);
        }
        public DataTable getKhachHang_HD(string MaKH)
        {
            string sql = "SELECT KhachHang.MaKH, HoTen, HDB.MaHDB, NgayBan, HDB.DonGia, TenSP, SizeVN, TenMau FROM KhachHang INNER JOIN ChiTietHDB ON KhachHang.MaKH = ChiTietHDB.MaKH INNER JOIN HDB ON HDB.MaHDB = ChiTietHDB.MaHDB INNER JOIN MauSac ON ChiTietHDB.MaMau = MauSac.MaMau INNER JOIN SanPham ON SanPham.MaSP = ChiTietHDB.MaSP WHERE KhachHang.MaKH = @MaKH";
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
    }
}