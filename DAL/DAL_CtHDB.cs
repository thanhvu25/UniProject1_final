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
            string sql = "SELECT ChiTietHDB.MaHDB, TenSP, SizeVN, TenMau, SL, ChiTietHDB.DonGia\r\nFROM ChiTietHDB INNER JOIN HDB\r\nON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang\r\nON HDB.MaKH = KhachHang.MaKH INNER JOIN SanPham\r\nON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac\r\nON MauSaC.MaMau = ChiTietHDB.MaMau";
            return ExecuteQuery(sql);
        }
        public DataTable getCTHDBForHDB(string maHDB)
        {
            string sql = "SELECT ChiTietHDB.MaHDB, TenSP, SizeVN, TenMau, SL, ChiTietHDB.DonGia\r\nFROM ChiTietHDB INNER JOIN HDB\r\nON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang\r\nON HDB.MaKH = KhachHang.MaKH INNER JOIN SanPham\r\nON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac\r\nON MauSac.MaMau = ChiTietHDB.MaMau\r\nWHERE ChiTietHDB.MaHDB = @MaHDB";

            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", maHDB }
            };

            return ExecuteQuery(sql, parameters);
        }
        public DataTable getCtHDBByMaHDB(string maHDB)
        {
            string sql = "SELECT cthdb.MaHDB, cthdb.MaSP, sp.TenSP, cthdb.SizeVN, m.TenMau, cthdb.MaMau, cthdb.SL, cthdb.DonGia, (cthdb.SL * cthdb.DonGia) AS ThanhTien\r\nFROM ChiTietHDB cthdb\r\nJOIN SanPham sp ON cthdb.MaSP = sp.MaSP\r\nJOIN MauSac m ON cthdb.MaMau = m.MaMau\r\nWHERE cthdb.MaHDB = @MaHDB";

            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", maHDB }
            };

            return ExecuteQuery(sql, parameters);
        }
        public DataTable getHDBForHD(string maHDB)
        {
            string sql = "SELECT CONCAT(TenSP, ', ', SizeVN, ', ', TenMau) AS SP, SL, ctB.DonGia, ThanhTien = (SL * ctB.DonGia)\r\nFROM ChiTietHDB ctB \r\nINNER JOIN HDB B ON ctB.MaHDB=B.MaHDB\r\nINNER JOIN SanPham S ON S.MaSP = ctB.MaSP\r\nINNER JOIN MauSac M ON M.MaMau = ctB.MaMau\r\nWHERE ctB.MaHDB = @MaHDB";

            var parameters = new Dictionary<string, object>
            {
                { "@MaHDB", maHDB }
            };

            return ExecuteQuery(sql, parameters);
        }

        //public int KiemTraMaTrung(string maCTB)
        //{
        //    string sql = "SELECT COUNT(*) FROM ChiTietHDB WHERE MaCTB = @MaCTB";
        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@MaCTB", maCTB }
        //    };
        //    return ExecuteScalar(sql, parameters);
        //}

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
