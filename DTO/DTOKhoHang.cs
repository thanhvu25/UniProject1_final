using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOKhoHang
    {
        public string MaSP { get; set; }
        public int SLTon { get; set; }
        public DTOKhoHang() {}
        public DTOKhoHang(string maSP, int sLTon)
        {
            this.MaSP = maSP;
            this.SLTon = sLTon;
        }
    }
}
