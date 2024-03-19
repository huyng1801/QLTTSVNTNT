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
    public class SinhVienBLL
    {
        public static DataTable ReadAllForTable(string maLop)
        {
            return SinhVienDAL.ReadAllForTable(maLop);
        }
        public static List<SinhVienDTO> ReadAll()
        {
            return SinhVienDAL.ReadAll();
        }

        public static int Insert(SinhVienDTO sinhVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return SinhVienDAL.Insert(sinhVien);
        }

        public static int Update(SinhVienDTO sinhVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return SinhVienDAL.Update(sinhVien);
        }

        public static int Delete(string maSinhVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return SinhVienDAL.Delete(maSinhVien);
        }

        public static SinhVienDTO FindByMaSinhVien(string maSinhVien)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return SinhVienDAL.FindByMaSinhVien(maSinhVien);
        }
        public static DataTable FindBySinhVien(string maLop, string searchString)
        {
            return SinhVienDAL.FindBySinhVien(maLop, searchString);
        }
    }
}
