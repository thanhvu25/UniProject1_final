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
            string sql = "SELECT Kho.MaSP, TenSP, ThuongHieu.TenTH, MaSize, MaMau, SLTon FROM Kho INNER JOIN SanPham ON Kho.MaSP = SanPham.MaSP INNER JOIN ThuongHieu ON SanPham.MaSP = ThuongHieu.MaTH";
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
            string sql = "EXEC sp_SuaKho @MaSP, @MaSize, @MaMau, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@MaSize", kho.MaSize},
            {"@MaMau", kho.MaMau},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_SuaKho @MaSP, @MaSize, @MaMau, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@MaSize", kho.MaSize},
            {"@MaMau", kho.MaMau},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_XoaKho @MaSP, @MaSize, @MaMau";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@MaSize", kho.MaSize},
            {"@MaMau", kho.MaMau}
        };
            return ExecuteNonQuery(sql, parameters);
        }
    }

}
