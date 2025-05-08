using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CtHDN
    {
        public string MaHDN { get; set; }
        public string MaSP { get; set; }
        public string MaTH { get; set; }
        public int SL { get; set; }
        public string MaNV { get; set; }
        public DTO_CtHDN() { }
        public DTO_CtHDN(string maHDN, string maSP, string maTH, int sl, string maNV)
        {
            this.MaHDN = maHDN;
            this.MaSP = maSP;
            this.MaTH = maTH;
            this.MaNV = maNV;
            this.SL = sl;
        }
    }
}
