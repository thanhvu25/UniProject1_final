using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOLogin
    {
        public int ID { get; set; }
        public string TenTK { get; set; }
        public string Mk { get; set; }
        public string TenHT { get; set; }
        public string VaiTro { get; set; }

        public DTOLogin(int id, string tenTK, string mk, string tenHT, string vaiTro)
        {
            ID = id;
            TenTK = tenTK;
            Mk = mk;
            TenHT = tenHT;
            VaiTro = vaiTro;
        }
        public DTOLogin(string TenTK, string Mk, string tenHT, string vaiTro)
        {
            this.TenTK = TenTK;
            this.Mk = Mk;
            this.TenHT = tenHT;
            this.VaiTro = vaiTro;
        }

        public DTOLogin(string tenTK, string mk)
        {
            this.TenTK = tenTK;
            this.Mk = mk;
        }

        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DTOLogin(string maNV, string tenNV, string vaiTro)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.VaiTro = vaiTro;
        }

    }
}
