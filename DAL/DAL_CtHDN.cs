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
            string sql = "SELECT * FROM ChitietHDN";
            return ExecuteQuery(sql);
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
            string sql = "EXEC sp_ThemChiTietHDN   @MaHDN,  @MaTH, @MaSP, @SizeVN, @MaMau, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                {  "@MaHDN", cthdn.MaHDN },
                { "@MaTH", cthdn.MaTH },
                { "@MaSP", cthdn.MaSP },
                { "@SizeVN", cthdn.SizeVN },
                { "@MaMau", cthdn.MaMau },
                { "@SL", cthdn.SL },
                { "@MaNV", cthdn.MaNV }
            
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_SuaChiTietHDN   @MaCTN, @MaTH, @MaSP, @SizeVN,  @MaMau , @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTN", cthdn.MaCTN },
                //{  "@MaHDN", cthdn.MaHDN },
                { "@MaTH", cthdn.MaTH },
                { "@MaSP", cthdn.MaSP },
                { "@SizeVN", cthdn.SizeVN },
                { "@MaMau", cthdn.MaMau },
                { "@SL", cthdn.SL },
                { "@MaNV", cthdn.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDN(DTO_CtHDN cthdn)
        {
            string sql = "EXEC sp_XoaChiTietHDN   @MaCTN";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTN", cthdn.MaCTN }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
