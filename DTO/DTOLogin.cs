using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOLogin
    {
        public string TenTK { get; set; }
        public string Mk { get; set; }
        public DTOLogin() { }
        public DTOLogin(string TenTK, string Mk)
        {
            this.TenTK = TenTK;
            this.Mk = Mk;
        }
    }
}
