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
    public class DAL_CtHDN : DBConnect
    {
        public DataTable getCtHDN()
        {
            string sql = "SELECT ChiTietHDN.MaHDN, TenSP, SizeVN, TenMau, SL, ChiTietHDN.DonGia\r\nFROM ChiTietHDN\r\nINNER JOIN HDN ON HDN.MaHDN = ChiTietHDN.MaHDN\r\nINNER JOIN ThuongHieu ON HDN.MaTH = ThuongHieu.MaTH\r\nINNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP\r\nINNER JOIN MauSac ON ChiTietHDN.MaMau = MauSac.MaMau";
            return ExecuteQuery(sql);
        }
        public DataTable getCtHDNForHDN(string maHDN)
        {

            string sql = "SELECT ChiTietHDN.MaHDN, TenSP, SizeVN, TenMau, SL, ChiTietHDN.DonGia\r\nFROM ChiTietHDN\r\nINNER JOIN HDN ON HDN.MaHDN = ChiTietHDN.MaHDN\r\nINNER JOIN ThuongHieu ON HDN.MaTH = ThuongHieu.MaTH\r\nINNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP\r\nINNER JOIN MauSac ON ChiTietHDN.MaMau = MauSac.MaMau WHERE HDN.MaHDN = @MaHDN";

            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", maHDN }
            };
            return ExecuteQuery(sql, parameters);
        }

        public int KiemTraMaTrung(string maCTN)
        {
            string sql = "SELECT COUNT(*) FROM ChitietHDN WHERE MaCTN = @MaCTN";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTN", maCTN }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_ThemChiTietHDN @MaHDN, @MaSP, @SizeVN, @MaMau, @SL, @DonGia ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP },
                { "@SizeVN", cthdn.SizeVN },
                { "@MaMau", cthdn.MaMau },
                { "@SL", cthdn.SL },
                { "@DonGia", cthdn.DonGia }

            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_SuaChiTietHDN @MaHDN, @MaSP, @SizeVN, @MaMau, @SL, @DonGia";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP },
                { "@SizeVN", cthdn.SizeVN },
                { "@MaMau", cthdn.MaMau },
                { "@SL", cthdn.SL },
                { "@DonGia", cthdn.DonGia }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_XoaChiTietHDN @MaHDN, @MaSP, @SizeVN, @MaMau ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHDN", cthdn.MaHDN },
                { "@MaSP", cthdn.MaSP },
                { "@SizeVN", cthdn.SizeVN },
                { "@MaMau", cthdn.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
