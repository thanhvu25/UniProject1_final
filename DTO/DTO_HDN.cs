using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HDN
    {
        public string MaHDN { get; set; }
        public DateTime NgayNhap { get; set; }
        public int DonGia { get; set; }
        public DTO_HDN() { }
        public DTO_HDN(string maHDN, DateTime ngayNhap, int donGia)
        {
            this.MaHDN = maHDN;
            this.NgayNhap = ngayNhap;
            this.DonGia = donGia;
        }
    }
}
