using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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

        public int ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
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

        public bool ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
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

    }

}