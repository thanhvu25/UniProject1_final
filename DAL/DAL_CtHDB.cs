using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace DAL
{
    public class DAL_CtHDB : DBConnect
    {
        public DataTable getCtHDB()
        {
            string sql = "SELECT * FROM ChiTietHDB";
            return ExecuteQuery(sql);
        }

        public int KiemTraMaTrung(string maCTB)
        {
            string sql = "SELECT COUNT(*) FROM ChiTietHDB WHERE MaCTB = @MaCTB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTB", maCTB }
            };
            return ExecuteScalar(sql, parameters);
        }

        public bool themCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_ThemChiTietHDB   @MaHDB, @MaKH, @MaSP, @SizeVN, @MaMau, @SL, @MaNV ";
            var parameters = new Dictionary<string, object>
            {
                {  "@MaHDB", ctHDB.MaHDB },
                { "@MaKH", ctHDB.MaKH },
                { "@MaSP", ctHDB.MaSP },
                { "@SizeVN", ctHDB.SizeVN },
                { "@MaMau", ctHDB.MaMau },
                { "@SL", ctHDB.SL },
                { "@MaNV", ctHDB.MaNV }           
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool suaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_SuaChiTietHDB  @MaCTB, @MaKH, @MaSP, @SizeVN, @MaMau, @SL, @MaNV";
            var parameters = new Dictionary<string, object>
            {
                {  "@MaCTB", ctHDB.MaCTB },              
                //{ "@MaHDB", ctHDB.MaHDB },
                { "@MaSP", ctHDB.MaSP },
                { "@SizeVN", ctHDB.SizeVN },
                { "@MaMau", ctHDB.MaMau },
                { "@MaKH", ctHDB.MaKH },
                { "@SL", ctHDB.SL },
                { "@MaNV", ctHDB.MaNV }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaCtHDB(DTO_CtHDB ctHDB)
        {
            string sql = "EXEC sp_XoaChiTietHDB  @MaCTB";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCTB", ctHDB.MaCTB }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
