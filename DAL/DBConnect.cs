using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection con = new SqlConnection("Data Source=DESKTOP-7MNAKTV\\MAY1;Initial Catalog=vvtDA1;Persist Security Info=True;User ID=sa;Password=0;");

        public void ketnoi()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public void dongketnoi()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public static DBConnect instance;
        public static DBConnect Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnect();
                return instance;
            }
            private set { instance = value; }
        }
        public int ExecuteScalar(string sql, Dictionary<string, object> parameters = null) // đếm
        {
            try
            {
                ketnoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    return (int)cmd.ExecuteScalar();
                }
            }
            finally
            {
                dongketnoi();
            }
        }
        public string ExecuteScalarString(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                ketnoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? result.ToString() : null;
                }
            }
            finally
            {
                dongketnoi();
            }
        }

        public bool ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null) // trả ra dòng được thực thi
        {
            try
            {
                ketnoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            finally
            {
                dongketnoi();
            }
        }

//<<<<<<< HEAD
//        public DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters = null) 
//=======
        public DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                ketnoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    //// Log SQL và tham số để debug
                    //Console.WriteLine("SQL: " + sql);
                    //if (parameters != null)
                    //{
                    //    foreach (var param in parameters)
                    //        Console.WriteLine($"{param.Key}: {param.Value}");
                    //}

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            finally
            {
                dongketnoi();
            }
        }
        public string ExecuteNonQueryWithOutput(string query, Dictionary<string, object> parameters, string outputParameterName, SqlDbType outputType)
        {
            try
            {
                ketnoi();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    foreach (var param in parameters)
                    {
                        if (param.Key == outputParameterName)
                        {
                            var p = cmd.Parameters.Add(param.Key, outputType, 5);
                            p.Direction = ParameterDirection.Output;
                            continue;
                        }
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return cmd.Parameters[outputParameterName].Value?.ToString();
                }
            }
            finally
            {
                dongketnoi();
            }

        }

        public SqlDataReader ExecuteReader(string query, Dictionary<string, object> parameters)
        {
            try
            {
                ketnoi();
                SqlCommand cmd = new SqlCommand(query, con);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                // Xử lý lỗi nếu cần thiết
                throw;
            }
            finally
            {
                // Không đóng kết nối ở đây vì SqlDataReader sẽ tự quản lý việc đóng kết nối khi nó được dispose
                // dongketnoi();
            }
            
        }

    }

}