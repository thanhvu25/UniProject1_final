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

        /// <summary>
        /// SP + Size
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_Size()
        {
            return dalCTSP.getSanPham_Size();
        }
        public int KiemTraSP_Size(DTO_ChiTietSP sp_size)
        {
            return dalCTSP.KiemTraSP_Size(sp_size);
        }
        public bool ThemSP_Size(DTO_ChiTietSP sp_size)
        {
            return dalCTSP.ThemSP_Size(sp_size);
        }
        public bool XoaSP_Size(DTO_ChiTietSP sp_size)
        {
            return dalCTSP.XoaSP_Size(sp_size);
        }

        /// <summary>
        /// SP + Màu sắc
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham_MauSac()
        {
            return dalCTSP.getSanPham_MauSac();
        }
        public DataTable getMauForCombo()
        {
            return dalCTSP.getMauForCombo();
        }
        public int KiemTraSP_Mau(DTO_ChiTietSP sp_mau)
        {
            return dalCTSP.KiemTraSP_Mau(sp_mau);
        }
        public bool ThemSP_Mau(DTO_ChiTietSP sp_mau)
        {
            return dalCTSP.ThemSP_Mau(sp_mau);
        }
        public bool XoaSP_Mau(DTO_ChiTietSP sp_mau)
        {
            return dalCTSP.XoaSP_Mau(sp_mau);
        }


    }
}
