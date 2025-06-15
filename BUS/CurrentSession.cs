using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public static class CurrentSession
    {
        public static DTOLogin CurrentUser { get; private set; }

        public static void SetSession(DTOLogin user)
        {
            CurrentUser = user;
        }

        public static void ResetSession()
        {
            CurrentUser = null;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
