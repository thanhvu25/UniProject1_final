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
        public int SizeVN { get; set; }
        public string MaMau { get; set; }
        public int SLTon { get; set; }
        public int SLThem { get; set; }
        public DTOKhoHang() {}
        public DTOKhoHang(string maSP, int sizeVN, string maMau, int slTon)
        {
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.SLTon = slTon;
        }
    }
}
