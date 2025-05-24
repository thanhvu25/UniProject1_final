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
    public class DAL_ChiTietSP : DBConnect
    {
        /// <summary>
        /// Size
        /// </summary>
        /// <returns></returns>
        public DataTable getSize()
        {
            string sql = "SELECT * FROM Size";
            return ExecuteQuery(sql);
        }
        public int KiemTraMaTrung(DTO_ChiTietSP size)
        {
            string sql = "SELECT COUNT(*) FROM Size WHERE SizeVN = @SizeVN";
            var parameters = new Dictionary<string, object>
            {
                { "@SizeVN", size.SizeVN }
            };
            return ExecuteScalar(sql, parameters);
        }
        public bool ThemSize(DTO_ChiTietSP size)
        {
            string sql = "INSERT INTO Size (SizeVN, SizeUS, SizeUK, Centimeter)  VALUES (@SizeVN, @SizeUS, @SizeUK, @Centimeter)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SizeVN", size.SizeVN },
                { "@SizeUS", size.SizeUS },
                { "@SizeUK", size.SizeUK },
                { "@Centimeter", size.Centimeter }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool XoaSize(DTO_ChiTietSP size)
        {
            string sql = "DELETE FROM Size WHERE SizeVN = @SizeVN";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SizeVN", size.SizeVN }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// Màu sắc
        /// </summary>
        /// <returns></returns>
        public DataTable getMau()
        {
            string sql = "SELECT * FROM MauSac";
            return ExecuteQuery(sql);
        }
        public DataTable getMauForCombo()
        {
            string sql = "SELECT MaMau, TenMau FROM MauSac";
            return ExecuteQuery(sql);
        }
        public int KiemTraMaMauTrung(DTO_ChiTietSP mau)
        {
            string sql = "SELECT COUNT(*) FROM MauSac WHERE MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMau", mau.MaMau }
            };
            return ExecuteScalar(sql, parameters);
        }
        public bool ThemMau(DTO_ChiTietSP mau)
        {
            string sql = "INSERT INTO MauSac (MaMau, TenMau) VALUES (@MaMau, @TenMau)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMau", mau.MaMau },
                { "@TenMau", mau.TenMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool XoaMau(DTO_ChiTietSP mau)
        {
            string sql = "DELETE FROM MauSac WHERE MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMau", mau.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// CHI TIẾT SẢN PHẨM
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_CT()
        {
            string sql = "SELECT SanPham_CT.MaSP, TenSP, SizeVN, MauSac.MaMau, TenMau\r\nFROM SanPham_CT INNER JOIN SanPham \r\nON SanPham_CT.MaSP = SanPham.MaSP INNER JOIN MauSac\r\nON SanPham_CT.MaMau = MauSac.MaMau";
            return ExecuteQuery(sql);
        }
        public DataTable getCTSPForBH()
        {
            string sql = "SELECT SanPham_CT.MaSP, TenSP, SanPham_CT.SizeVN, SLTon\r\nFROM SanPham_CT INNER JOIN Kho\r\nON SanPham_CT.MaSP = Kho.MaSP \r\nAND SanPham_CT.SizeVN = Kho.SizeVN \r\nAND SanPham_CT.MaMau = Kho.MaMau INNER JOIN SanPham\r\nON SanPham_CT.MaSP = SanPham.MaSP";
            return ExecuteQuery(sql);
        }
        public DataTable getCTSPForSP(string maSP)
        {
            string sql = "SELECT SanPham_CT.MaSP, TenSP, SizeVN,  TenMau \r\nFROM SanPham_CT INNER JOIN SanPham \r\nON SanPham_CT.MaSP = SanPham.MaSP INNER JOIN MauSac\r\nON SanPham_CT.MaMau = MauSac.MaMau\r\nWHERE SanPham_CT.MaSP = @MaSP";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", maSP }
            };
            return ExecuteQuery(sql, parameters);
        }
        public int KiemTraSP_CT(DTO_ChiTietSP sp_ct)
        {
            string sql = "SELECT COUNT(*) FROM SanPham_CT WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_ct.MaSP },
                { "@SizeVN", sp_ct.SizeVN },
                { "@MaMau", sp_ct.MaMau }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool ThemSP_CT(DTO_ChiTietSP sp_ct)
        {
            string sql = "INSERT INTO SanPham_CT (MaSP, SizeVN, MaMau, TenMau) VALUES (@MaSP, @SizeVN, @MaMau, @TenMau)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_ct.MaSP },
                { "@SizeVN", sp_ct.SizeVN },
                { "@MaMau", sp_ct.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool XoaSP_CT(DTO_ChiTietSP sp_ct)
        {
            string sql = "DELETE FROM SanPham_CT WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_ct.MaSP },
                { "@SizeVN", sp_ct.SizeVN },
                { "@MaMau", sp_ct.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }

    }
}
