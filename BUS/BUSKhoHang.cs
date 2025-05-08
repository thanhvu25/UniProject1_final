using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUSKhoHang
    {
        DALKhoHang dalkho = new DALKhoHang();
        public DataTable getKhoHang() //lấy ttin bảng Kho và đổ ra dgv
        {
            return dalkho.getKhoHang();
        }
        public int KiemTraMaTrung(string maSP)
        {
            return dalkho.KiemTraMaTrung(maSP);
        }
        public bool themNV(DTOKhoHang kho)
        {
            return dalkho.themKhoHang(kho);
        }
        public bool suaNV(DTOKhoHang kho)
        {
            return dalkho.suaKhoHang(kho);
        }
        public bool xoaNV(DTOKhoHang kho)
        {
            return dalkho.themKhoHang(kho);
        }
    }
}
