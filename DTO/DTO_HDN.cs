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
        public string MaTH { get; set; }
        public DateTime NgayNhap { get; set; }
        public int TongHD { get; set; }
        public string MaNV { get; set; }

        public DTO_HDN() { }

        public DTO_HDN(string maHDN, string maTH, DateTime ngayNhap, int tongHD, string maNV)
        {
            this.MaHDN = maHDN;
            this.MaTH = maTH;
            this.NgayNhap = ngayNhap;
            this.TongHD = tongHD;
            this.MaNV = maNV;
        }
    }
}
