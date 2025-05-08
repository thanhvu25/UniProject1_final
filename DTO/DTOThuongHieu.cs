using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOThuongHieu
    {
        public string MaTH { get; set; }
        public string TenTH { get; set; }
        public string DiaChiTH { get; set; }
        public string SdtTH { get; set; }
        public DTOThuongHieu() { }
        public DTOThuongHieu(string maTH, string tenTH, string diaChiTH, string sdtTH)
        {
            this.MaTH = maTH;
            this.TenTH = tenTH;
            this.DiaChiTH = diaChiTH;
            this.SdtTH = sdtTH;
        }
    }
}
