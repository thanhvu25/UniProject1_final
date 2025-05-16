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
            string sql = "SELECT Kho.MaSP, TenSP, SizeVN, TenMau, ThuongHieu.TenTH, SLTon FROM Kho INNER JOIN SanPham ON Kho.MaSP = SanPham.MaSP INNER JOIN ThuongHieu ON SanPham.MaTH = ThuongHieu.MaTH INNER JOIN MauSac ON MauSac.MaMau = Kho.MaMau";
            return ExecuteQuery(sql);
        }

        public DataTable getKhoHangForOS()
        {
            string sql = "SELECT Kho.MaSP, TenSP, SizeVN, TenMau, ThuongHieu.TenTH, SLTon FROM Kho INNER JOIN SanPham ON Kho.MaSP = SanPham.MaSP INNER JOIN ThuongHieu ON SanPham.MaTH = ThuongHieu.MaTH INNER JOIN MauSac ON MauSac.MaMau = Kho.MaMau WHERE SLTon <= 10";
            return ExecuteQuery(sql);
        }
        public int KiemTraMaTrung(DTOKhoHang kho)
        {
            string sql = "SELECT COUNT(*) FROM Kho WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau ";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SizeVN", kho.SizeVN},
            {"@MaMau", kho.MaMau}
        };
            return ExecuteScalar(sql, parameters);
        }

        public bool themKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_ThemKho @MaSP, @SizeVN, @MaMau, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SizeVN", kho.SizeVN},
            {"@MaMau", kho.MaMau},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool congKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_CongKho @MaSP, @SizeVN, @MaMau, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SizeVN" , kho.SizeVN},
            {"@MaMau", kho.MaMau},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }
        public bool suaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_SuaKho @MaSP, @SizeVN, @MaMau, @SLTon";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SizeVN" , kho.SizeVN},
            {"@MaMau", kho.MaMau},
            {"@SLTon", kho.SLTon}
        };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaKhoHang(DTOKhoHang kho)
        {
            string sql = "EXEC sp_XoaKho @MaSP, @SizeVN, @MaMau";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", kho.MaSP},
            {"@SizeVN" , kho.SizeVN},
            {"@MaMau", kho.MaMau}
        };
            return ExecuteNonQuery(sql, parameters);
        }
    }

}
