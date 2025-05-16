using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUSLogin
    {
        DALLogin dalLogin = new DALLogin();
        public int CheckLogin(string userName, string passWord)
        {
            return dalLogin.Login(userName, passWord);
        }
    }
}
