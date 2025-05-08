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
        public DateTime NgayBan { get; set; }
        public int DonGia { get; set; }
        public DTO_HDB() { }
        public DTO_HDB(string maHDB, DateTime ngayBan, int donGia)
        {
            this.MaHDB = maHDB;
            this.NgayBan = ngayBan;
            this.DonGia = donGia;
        }
    }
}
