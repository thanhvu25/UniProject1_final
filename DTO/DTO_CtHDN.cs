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
        public int SizeVN { get; set; }
        public string MaMau { get; set; }
        public int SL { get; set; }
        public int DonGia { get; set; }


        public DTO_CtHDN() { }
        public DTO_CtHDN(string maHDN, string maSP, int sizeVN, string maMau, int sL, int donGia)
        {
            this.MaHDN = maHDN;
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.SL = sL;
            this.DonGia = donGia;
        }
    }
}
