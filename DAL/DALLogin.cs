using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class DALLogin : DBConnect
    {
        public DTOLogin Login(string userName, string passWord)
        {
            DTOLogin user = null;
            string sql = "SELECT * FROM TaiKhoan WHERE TenTK=@TenTK AND MK=@MK";

            var parameters = new Dictionary<string, object>
            {
                { "@TenTK", userName },
                { "@MK", passWord }
            };

            using (SqlDataReader reader = ExecuteReader(sql, parameters))
            {
                if (reader.Read())
                {
                    user = new DTOLogin(
                        Convert.ToInt32(reader["ID"]),
                        reader["TenTK"].ToString(),
                        reader["MK"].ToString(),
                        reader["TenHT"].ToString(),
                        reader["VaiTro"].ToString()
                    );
                }
            }

            return user;
        }


        public DataTable GetAllUsers()
        {
            string sql = "SELECT TenTK, MK, TenHT, VaiTro = CASE \r\nWHEN VaiTro = 'ql' THEN N'Quản lý'\r\n WHEN VaiTro = 'nv' THEN N'Nhân viên'\r\n ELSE 'Khác'\r\n END\r\n FROM TaiKhoan";
            return ExecuteQuery(sql);
        }

        public bool themTaiKhoan(DTOLogin tk)
        {
            string sql = "INSERT INTO TaiKhoan VALUES (@TenTK, @MK, @TenHT, @VaiTro)";
            var parameters = new Dictionary<string, object>
            {
                {"@TenTK", tk.TenTK},
                {"@MK", tk.Mk},
                {"@TenHT", tk.TenHT},
                {"@VaiTro", tk.VaiTro}
            };
           return ExecuteNonQuery(sql, parameters);
        }

        public bool suaTaiKhoan(DTOLogin tk)
        {
            string sql = "UPDATE TaiKhoan SET MK=@MK, TenHT=@TenHT, VaiTro=@VaiTro WHERE TenTK=@TenTK";
            var parameters = new Dictionary<string, object>
            {
                {"@TenTK", tk.TenTK},
                {"@MK", tk.Mk},
                {"@TenHT", tk.TenHT},
                {"@VaiTro", tk.VaiTro}
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool xoaTaiKhoan(string tenTK)
        {
            string sql = "DELETE FROM TaiKhoan WHERE TenTK=@TenTK";
            var parameters = new Dictionary<string, object>
            {
                {"@TenTK", tenTK}
            };
            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenTK"></param>
        /// <param name="tenHT"></param>
        /// <returns></returns>
        public bool UpdateTenHTByID(int id, string tenHT)
        {
            string sql = "UPDATE TaiKhoan SET TenHT=@TenHT WHERE ID=@ID";
            var parameters = new Dictionary<string, object>
            {
                {"@ID", id},
                {"@TenHT", tenHT}
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool UpdatePasswordByID(int id, string newMK)
        {
            string sql = "UPDATE TaiKhoan SET MK=@MK WHERE ID=@ID";
            var parameters = new Dictionary<string, object>
            {
                {"@ID", id},
                {"@MK", newMK}
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public bool CheckOldPasswordByID(int id, string mk)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE ID=@ID AND MK=@MK";
            var parameters = new Dictionary<string, object>
            {
                {"@ID", id},
                {"@MK", mk}
            };
            return ExecuteScalar(sql, parameters) > 0;
        }


        public bool UpdateTenTK(int id, string newTenTK)
        {
            string sql = "UPDATE TaiKhoan SET TenTK=@NewTenTK WHERE ID=@ID";
            var parameters = new Dictionary<string, object>
            {
                {"@ID", id},
                {"@NewTenTK", newTenTK}
            };
            return ExecuteNonQuery(sql, parameters);
        }

    }
}
