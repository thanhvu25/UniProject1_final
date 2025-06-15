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
    public class BUSLogin
    {
        DALLogin dalLogin = new DALLogin();

        public DTOLogin Login(string tenTK, string mk)
        {
            return dalLogin.Login(tenTK, mk);
        }
        public DataTable getTaiKhoan()
        {
            return dalLogin.GetAllUsers();
        }
        public bool themTaiKhoan(DTOLogin tk)
        {
            return dalLogin.themTaiKhoan(tk);
        }

        public bool suaTaiKhoan(DTOLogin tk)
        {
            return dalLogin.suaTaiKhoan(tk);
        }

        public bool xoaTaiKhoan(string tenTK)
        {
            return dalLogin.xoaTaiKhoan(tenTK);
        }
        /// <summary>
        /// 
        public bool capNhatTenHT(int id, string tenHT)
        {
            return dalLogin.UpdateTenHTByID(id, tenHT);
        }

        public bool capNhatTenTaiKhoan(int id, string tenTKMoi)
        {
            return dalLogin.UpdateTenTK(id, tenTKMoi);
        }

        public bool capNhatMatKhau(int id, string matKhauMoi)
        {
            return dalLogin.UpdatePasswordByID(id, matKhauMoi);
        }

        public bool kiemTraMatKhauCu(int id, string matKhauCu)
        {
            return dalLogin.CheckOldPasswordByID(id, matKhauCu);
        }
    }
}
