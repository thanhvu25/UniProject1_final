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
    public class DALThuongHieu : DBConnect
    {
        public DataTable getThuongHieu()
        {
            string sql = "SELECT * FROM ThuongHieu";
            return ExecuteQuery(sql);
        }
        public DataTable getTHForHDN()
        {
            string sql = "SELECT MaTH, TenTH FROM ThuongHieu";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maTH)
        {
            string sql = "SELECT COUNT(*) FROM ThuongHieu WHERE MaTH = @MaTH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaTH", maTH }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themTH(DTOThuongHieu th)
        {
            string sql = "EXEC sp_ThemThuongHieu @TenTH, @DiaChi, @SdtTH";
            var parameters = new Dictionary<string, object>
            {
                { "@TenTH", th.TenTH },
                { "@DiaChi", th.DiaChiTH },
                { "@SdtTH", th.SdtTH }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaTH(DTOThuongHieu th)
        {
            string sql = "EXEC sp_SuaThuongHieu @MaTH, @TenTH, @DiaChiTH, @SdtTH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaTH", th.MaTH },
                { "@TenTH", th.TenTH },
                { "@DiaChiTH", th.DiaChiTH },
                { "@SdtTH", th.SdtTH }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaTH(DTOThuongHieu th)
        {
            string sql = "EXEC sp_XoaThuongHieu @MaTH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaTH", th.MaTH }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
