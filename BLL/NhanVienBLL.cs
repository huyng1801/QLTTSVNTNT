using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        public static List<NhanVienDTO> ReadAll()
        {
            return NhanVienDAL.ReadAll();
        }

        public static int Insert(NhanVienDTO nhanVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return NhanVienDAL.Insert(nhanVien);
        }

        public static int Update(NhanVienDTO nhanVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return NhanVienDAL.Update(nhanVien);
        }

        public static int Delete(string maNhanVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return NhanVienDAL.Delete(maNhanVien);
        }

        public static NhanVienDTO FindByMaNhanVien(string maNhanVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return NhanVienDAL.FindByMaNhanVien(maNhanVien);
        }
        public static List<NhanVienDTO> FindNhanVien(string searchString)
        {
            return NhanVienDAL.FindNhanVien(searchString);
        }
        public static NhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            return NhanVienDAL.DangNhap(tenDangNhap, matKhau);
        }
    }
}
