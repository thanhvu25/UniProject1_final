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
        public int MaSize { get; set; }
        public string MaMau { get; set; }
        public int SLTon { get; set; }
        public DTOKhoHang() {}
        public DTOKhoHang(string maSP, int maSize, string maMau, int slTon)
        {
            MaSP = maSP;
            MaSize = maSize;
            MaMau = maMau;
            SLTon = slTon;
        }
    }
}
