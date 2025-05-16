using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DTO
{
    public class DTO_ChiTietSP
    {      
        public string MaSP { get; set; }

        public int SizeVN { get; set; }
        public int SizeUS { get; set; }
        public int SizeUK { get; set; }
        public float Centimeter { get; set; }

        public string MaMau { get; set; }
        public string TenMau { get; set; }

        public DTO_ChiTietSP() { }

        public DTO_ChiTietSP(int SizeVN, int sizeUS, int sizeUK, float centimeter)
        {
            this.SizeVN = SizeVN;
            this.SizeUS = sizeUS;
            this.SizeUK = sizeUK;
            this.Centimeter = centimeter;
        }
        public DTO_ChiTietSP(string maMau, string tenMau)
        {
            this.MaMau = maMau;
            this.TenMau = tenMau;
        }

        public DTO_ChiTietSP(string maSP, int sizeVN, string maMau, string tenMau)
        {
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.TenMau = tenMau;
        }
    }

}
