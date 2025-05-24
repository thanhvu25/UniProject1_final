using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CtHDB
    {
        public string MaHDB { get; set; }
        public string MaSP { get; set; }
        public int SizeVN { get; set; }
        public string MaMau { get; set; }    
        public int SL { get; set; }
        public int DonGia { get; set; }

        public DTO_CtHDB() { }
        public DTO_CtHDB(string maHDB, string maSP, int sizeVN, string maMau, int sL, int donGia)
        {
            this.MaHDB = maHDB;
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.SL = sL;
            this.DonGia = donGia;
        }
    }
}
