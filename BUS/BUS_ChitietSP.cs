using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_ChitietSP
    {
        DAL_ChiTietSP dalCTSP = new DAL_ChiTietSP();

        /// <summary>
        /// Size
        /// </summary>
        /// <returns></returns>
        public DataTable getSize()
        {
            return dalCTSP.getSize();
        }
        public int KiemTraMaTrung(DTO_ChiTietSP size)
        {
            return dalCTSP.KiemTraMaTrung(size);
        }
        public bool ThemSize(DTO_ChiTietSP size)
        {
            return dalCTSP.ThemSize(size);
        }
        public bool XoaSize(DTO_ChiTietSP size)
        {
            return dalCTSP.XoaSize(size);
        }

        /// <summary>
        /// Màu sắc
        /// </summary>
        /// <returns></returns>
        public DataTable getMau()
        {
            return dalCTSP.getMau();
        }
        public DataTable getMauForCombo()
        {
            return dalCTSP.getMauForCombo();
        }
        public string GetMaMauByTen(string tenMau)
        {
            return dalCTSP.GetMaMauByTen(tenMau);
        }
        public int KiemTraMaMauTrung(DTO_ChiTietSP mau)
        {
            return dalCTSP.KiemTraMaMauTrung(mau);
        }
        public bool ThemMau(DTO_ChiTietSP mau)
        {
            return dalCTSP.ThemMau(mau);
        }
        public bool XoaMau(DTO_ChiTietSP mau)
        {
            return dalCTSP.XoaMau(mau);
        }
        public class BUS_Mau
        {
            DAL_ChiTietSP dalMau = new DAL_ChiTietSP();

            private static BUS_Mau instance;
            public static BUS_Mau Instance
            {
                get
                {
                    if (instance == null)
                        instance = new BUS_Mau();
                    return instance;
                }
            }

            public string GetMaMauByTen(string tenMau)
            {
                return dalMau.GetMaMauByTen(tenMau);
            }
        }


        /// <summary>
        /// CHI TIẾT SẢN PHẨM
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_CT()
        {
            return dalCTSP.getSanPham_CT();
        }
        public DataTable getCTSPForSP(string maSP)
        {
            return dalCTSP.getCTSPForSP(maSP);
        }
        public DataTable getCTSPForBH()
        {
            return dalCTSP.getCTSPForBH();
        }

        public int KiemTraSP_CT(DTO_ChiTietSP ctsp)
        {
            return dalCTSP.KiemTraSP_CT(ctsp);
        }
        public bool ThemSP_CT(DTO_ChiTietSP ctsp)
        {
            return dalCTSP.ThemSP_CT(ctsp);
        }
        public bool XoaSP_CT(DTO_ChiTietSP ctsp)
        {
            return dalCTSP.XoaSP_CT(ctsp);
        }


    }
}
