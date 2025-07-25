﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUSKhachHang
    {
        DALKhachHang dalKH = new DALKhachHang();
        public DataTable getKhachHang()
        {
            return dalKH.getKhachHang();
        }
        public DataTable getKhachHangForBH()
        {
            return dalKH.getKhachHangForBH();
        }
        public DataTable getKhachHang_HD(string MaKH)
        {
            return dalKH.getKhachHang_HD(MaKH);
        }
        public DataTable getKhachHangByLevel(string HangKH)
        {
            return dalKH.getKhachHangByLevel(HangKH);
        }

        public int KiemTraMaTrung(string maKH)
        {
            return dalKH.KiemTraMaTrung(maKH);
        }
        public bool themKH(DTOKhachHang kh)
        {
            return dalKH.themKH(kh);
        }
        public bool suaKH(DTOKhachHang kh)
        {
            return dalKH.suaKH(kh);
        }
        public bool xoaKH(DTOKhachHang kh)
        {
            return dalKH.xoaKH(kh);
        }
        public void CapNhatHangKH()
        {
            dalKH.CapNhatHangKhachHang();
        }
        
    }
}
