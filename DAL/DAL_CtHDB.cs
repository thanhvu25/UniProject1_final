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
            string sql = "SELECT MaCTB, ChiTietHDB.MaHDB, HoTen, TenSP, SizeVN, TenMau, SL, MaNV\r\nFROM ChiTietHDB INNER JOIN HDB\r\nON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang\r\nON ChiTietHDB.MaKH = KhachHang.MaKH INNER JOIN SanPham\r\nON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac\r\nON MauSaC.MaMau = ChiTietHDB.MaMau";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maCTB)
        {
            string sql = "SELECT COUNT(*) FROM ChiTietHDB WHERE MaCTB = @MaCTB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTB", maCTB }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_ThemChiTietHDB @MaHDB, @MaSP, @SizeVN, @MaMau, @SL, @DonGia ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@SizeVN", ctHDB.SizeVN },
                { "@MaMau", ctHDB.MaMau },
                { "@SL", ctHDB.SL },
                { "@DonGia" , ctHDB.DonGia }           
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_SuaChiTietHDB @MaHDB, @MaSP, @SizeVN, @MaMau, @SL, @DonGia ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@SizeVN", ctHDB.SizeVN },
                { "@MaMau", ctHDB.MaMau },
                { "@SL", ctHDB.SL },
                { "@DonGia" , ctHDB.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_XoaChiTietHDB @MaHDB, @MaSP, @SizeVN, @MaMau ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@SizeVN", ctHDB.SizeVN },
                { "@MaMau", ctHDB.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
