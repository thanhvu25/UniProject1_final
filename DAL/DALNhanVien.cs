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
    public class DALNhanVien : DBConnect
    {
        public virtual DataTable getNhanVien()
        {
            string sql = "SELECT * FROM NhanVien";
            return ExecuteQuery(sql);
        }
        
        public virtual int KiemTraMaTrung(string maNV)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };
            return ExecuteScalar(sql, parameters);
        }

        public virtual bool themNV(DTONhanVien nv)
        {
            string sql = "EXEC sp_ThemNhanVien @TenNV, @GioiTinh, @DiaChi, @Sdt, @VaiTro, @LuongCB";
            var parameters = new Dictionary<string, object>
            {
                {"@TenNV", nv.TenNV },
                {"@GioiTinh", nv.GioiTinh },
                {"@DiaChi", nv.DiaChi },
                {"@Sdt", nv.Sdt },
                {"@VaiTro", nv.VaiTro },
                {"@LuongCB", nv.LuongCB }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public virtual bool suaNV(DTONhanVien nv)
        {
            string sql = "EXEC sp_SuaNhanVien @MaNV, @TenNV, @GioiTinh, @DiaChi, @Sdt, @VaiTro, @LuongCB";
            var parameters = new Dictionary<string, object>
            {
                {"@MaNV", nv.MaNV },
                {"@TenNV", nv.TenNV },
                {"@GioiTinh", nv.GioiTinh },
                {"@DiaChi", nv.DiaChi },
                {"@Sdt", nv.Sdt },
                {"@VaiTro", nv.VaiTro },
                {"@LuongCB", nv.LuongCB }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public virtual bool xoaNV(DTONhanVien nv)
        {
            string sql = "EXEC sp_XoaNhanVien @MaNV";
            var parameters = new Dictionary<string, object>
            {
                {"@MaNV", nv.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}