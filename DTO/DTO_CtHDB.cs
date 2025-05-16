using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CtHDB
    {
        public string MaCTB { get; set; } // Mã chi tiết hóa đơn bán
        public string MaHDB { get; set; }
        public string MaSP { get; set; }
        public int SizeVN { get; set; }
        public string MaMau { get; set; }
        public string MaKH { get; set; }       
        public int SL { get; set; }
        public string MaNV { get; set; }
        public DTO_CtHDB() { }
        public DTO_CtHDB(string maCTB, string maHDB, string maSP, int sizeVN, string maMau, string maKH, int sL, string maNV)
        {
            this.MaCTB = maCTB;
            this.MaHDB = maHDB;
            this.MaSP = maSP;
            this.SizeVN = sizeVN;
            this.MaMau = maMau;
            this.MaKH = maKH;
            this.SL = sL;
            this.MaNV = maNV;
        }
    }
}
