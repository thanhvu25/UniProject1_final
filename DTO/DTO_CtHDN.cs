using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CtHDN
    {
        public string MaCTN { get; set; } 
        public string MaHDN { get; set; }
        public string MaSP { get; set; }
        public int SizeVN { get; set; }
        public string MaMau { get; set; }
        public string MaTH { get; set; }
        public int SL { get; set; }
        public string MaNV { get; set; }
        public DTO_CtHDN() { }

        public DTO_CtHDN(string maCTN, string maHDN, string maSP, int sizeVN, string maMau, string maTH, int sL, string maNV)
        {
            this.MaCTN = maCTN;
            this.MaHDN = maHDN;
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.MaTH = maTH;
            this.SL = sL;
            this.MaNV = maNV;
        }
    }
}
