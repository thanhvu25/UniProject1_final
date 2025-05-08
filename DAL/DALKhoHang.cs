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
    public class DALKhoHang : DBConnect
    {
        public DataTable getKhoHang()
        {
            string sql = "SELECT Kho.MaSP, TenSP, ThuongHieu.TenTH, Kho.SLTon FROM Kho INNER JOIN SanPham ON Kho.MaSP = SanPham.MaSP INNER JOIN ThuongHieu ON SanPham.MaTH = ThuongHieu.MaTH";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maSP)
        {
            string sql = "SELECT COUNT(*) FROM Kho WHERE MaSP = @MaSP";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", maSP}
        };
            return ExecuteScalar(sql, parameters);
        }

        public bool themKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_ThemKho @MaSP, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_CongThemKho @MaSP, @SoLuongThem";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SoLuongThem", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_XoaKho @MaSP";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP}
        };
            return ExecuteNonQuery(sql, parameters);
        }
    }

}
