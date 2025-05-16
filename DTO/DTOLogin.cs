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
        public string TenHT { get; set; }

        public DTOLogin() { }
        public DTOLogin(string TenTK, string Mk, string tenHT)
        {   
            this.TenTK = TenTK;
            this.Mk = Mk;
            this.TenHT = tenHT;
        }

        public DTOLogin(string tenTK, string mk)
        {
            this.TenTK = tenTK;
            this.Mk = mk;
        }
    }
}
