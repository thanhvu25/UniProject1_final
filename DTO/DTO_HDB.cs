using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HDB
    {
        public string MaHDB { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayBan { get; set; }
        public int TongHD { get; set; }
        public string MaNV { get; set; }
        public DTO_HDB() { }

        public DTO_HDB(string maHDB, string maKH, DateTime ngayBan, int tongHD, string maNV)
        {
            this.MaHDB = maHDB;
            this.MaKH = maKH;
            this.NgayBan = ngayBan;
            this.TongHD = tongHD;
            this.MaNV = maNV;
        }
    }
}
