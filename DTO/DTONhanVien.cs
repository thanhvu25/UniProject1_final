using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTONhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string VaiTro { get; set; }
        public int LuongCB { get; set; }

        public DTONhanVien() { }
        public DTONhanVien(string maNV, string tenNV, string gioiTinh, string diaChi, string sdt, string vaiTro, int luongCB)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.Sdt = sdt;
            this.VaiTro = vaiTro;
            this.LuongCB = luongCB;
        }

}
}
