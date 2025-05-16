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
        public DataTable getKhoHangForOS() // lượng hàng tồn kho <= 10
        {
            return dalkho.getKhoHangForOS();
        }
        public int KiemTraMaTrung(DTOKhoHang kho)
        {
            return dalkho.KiemTraMaTrung(kho);
        }
        public bool themSP(DTOKhoHang kho)
        {
            return dalkho.themKhoHang(kho);
        }
        public bool congSP(DTOKhoHang kho)
        {
            return dalkho.congKhoHang(kho);
        }
        public bool suaSP(DTOKhoHang kho)
        {
            return dalkho.suaKhoHang(kho);
        }
        public bool xoaSP(DTOKhoHang kho)
        {
            return dalkho.themKhoHang(kho);
        }
    }
}
