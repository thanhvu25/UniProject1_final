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
            string sql = "SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon\r\nFROM Kho INNER JOIN SanPham INNER JOIN SanPham_CT\r\nON SanPham.MaSP = SanPham_CT.MaSP INNER JOIN MauSac\r\nON MauSac.MaMau = SanPham_CT.MaMau\r\nON SanPham.MaSP = Kho.MaSP INNER JOIN ChiTietHDN\r\nON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN\r\nON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu\r\nON ThuongHieu.MaTH = HDN.MaTH ";
            return ExecuteQuery(sql);
        }
        public DataTable getKhoHangForBH(string MaSP)
        {
            string sql = "SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon\r\nFROM Kho INNER JOIN SanPham INNER JOIN SanPham_CT\r\nON SanPham.MaSP = SanPham_CT.MaSP INNER JOIN MauSac\r\nON MauSac.MaMau = SanPham_CT.MaMau\r\nON SanPham.MaSP = Kho.MaSP INNER JOIN ChiTietHDN\r\nON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN\r\nON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu\r\nON ThuongHieu.MaTH = HDN.MaTH WHERE Kho.MaSP = @MaSP";
            var parameters = new Dictionary<string, object>
        {
            {"@MaSP", MaSP}
        };
            return ExecuteQuery(sql, parameters);
        }

        public DataTable getKhoHangForOS()
        {
            string sql = "SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon \r\nFROM Kho INNER JOIN SanPham \r\nON SanPham.MaSP = Kho.MaSP INNER JOIN SanPham_CT\r\nON SanPham.MaSP = SanPham_CT.MaSP INNER JOIN MauSac\r\nON MauSac.MaMau = SanPham_CT.MaMau INNER JOIN ChiTietHDN\r\nON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN\r\nON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu\r\nON ThuongHieu.MaTH = HDN.MaTH \r\nWHERE SLTon <= 10";
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
