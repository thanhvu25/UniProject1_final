using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOSanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaTH { get; set; } 
        public int DonGia { get; set; }
        public DTOSanPham() { }
        public DTOSanPham(string maSP, string tenSP, string maTH, int donGia)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.MaTH = maTH;
            this.DonGia = donGia;
        }
    }
}
