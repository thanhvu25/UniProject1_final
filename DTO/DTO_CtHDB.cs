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
        public string MaKH { get; set; }       
        public int SL { get; set; }
        public string MaNV { get; set; }
        public DTO_CtHDB() { }
        public DTO_CtHDB(string maHDB, string maSP, string maKH, int sl, string maNV)
        {
            this.MaHDB = maHDB;
            this.MaSP = maSP;
            this.MaKH = maKH;          
            this.SL = sl;
            this.MaNV = maNV;
        }
    }
}
