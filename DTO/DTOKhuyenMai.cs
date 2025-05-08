using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOKhuyenMai
    {
        public string MaKM { get; set; }
        public string MaSP { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public int GiamGia { get; set; }
        public DTOKhuyenMai() { }
        public DTOKhuyenMai(string maKM, string maSP, DateTime ngayBD, DateTime ngayKT, int giamGia)
        {
            this.MaKM = maKM;
            this.MaSP = maSP;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
            this.GiamGia = giamGia;
        }
    }
}
