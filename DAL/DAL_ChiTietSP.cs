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
        /// SP + Size
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_Size()
        {
            string sql = "SELECT SanPham_Size.MaSP, TenSP, SanPham_Size.SizeVN FROM SanPham_Size INNER JOIN SanPham ON SanPham_Size.MaSP = SanPham.MaSP";
            return ExecuteQuery(sql);
        }
        public int KiemTraSP_Size(DTO_ChiTietSP sp_size)
        {
            string sql = "SELECT COUNT(*) FROM SanPham_Size WHERE MaSP = @MaSP AND SizeVN = @SizeVN";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_size.MaSP },
                { "@SizeVN", sp_size.SizeVN }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool ThemSP_Size(DTO_ChiTietSP sp_size)
        {
            string sql = "INSERT INTO SanPham_Size (MaSP, SizeVN) VALUES (@MaSP, @SizeVN)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_size.MaSP },
                { "@SizeVN", sp_size.SizeVN }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool XoaSP_Size(DTO_ChiTietSP sp_size)
        {
            string sql = "DELETE FROM SanPham_Size WHERE MaSP = @MaSP AND SizeVN = @SizeVN";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_size.MaSP },
                { "@SizeVN", sp_size.SizeVN }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// SP + Màu sắc
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_MauSac()
        {
            string sql = "SELECT SanPham.MaSP, TenSP, MauSac.MaMau, MauSac.TenMau FROM SanPham_MauSac INNER JOIN SanPham ON SanPham_MauSac.MaSP = SanPham.MaSP INNER JOIN MauSac ON SanPham_MauSac.MaMau = MauSac.MaMau";
            return ExecuteQuery(sql);
        }
        public DataTable getMauForCombo()
        {
            string sql = "SELECT MaMau, TenMau FROM MauSac";
            return ExecuteQuery(sql);
        }
        public int KiemTraSP_Mau(DTO_ChiTietSP sp_mau)
        {
            string sql = "SELECT COUNT(*) FROM SanPham_MauSac WHERE MaSP = @MaSP AND MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_mau.MaSP },
                { "@MaMau", sp_mau.MaMau }
            };
            return ExecuteScalar(sql, parameters);
        }
        public bool ThemSP_Mau(DTO_ChiTietSP sp_mau)
        {
            string sql = "INSERT INTO SanPham_MauSac (MaSP, MaMau, TenMau) VALUES (@MaSP, @MaMau, @TenMau)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_mau.MaSP },
                { "@MaMau", sp_mau.MaMau },
                { "@TenMau", sp_mau.TenMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool XoaSP_Mau(DTO_ChiTietSP sp_mau)
        {
            string sql = "DELETE FROM SanPham_MauSac WHERE MaSP = @MaSP AND MaMau = @MaMau";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaSP", sp_mau.MaSP },
                { "@MaMau", sp_mau.MaMau }
            };
            return ExecuteNonQuery(sql, parameters);
        }


    }
}
