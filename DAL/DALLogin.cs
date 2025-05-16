using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALLogin : DBConnect
    {
        public int Login(string userName, string passWord)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK= @TenTK AND MK= @MK";
            var parameters = new Dictionary<string, object>
            {
                { "@TenTK", userName },
                { "@MK", passWord }
            };
            
            return ExecuteScalar(sql, parameters);
        }
    }
}
