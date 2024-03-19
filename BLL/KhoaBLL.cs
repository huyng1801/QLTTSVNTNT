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
    public class KhoaBLL
    {
        public static List<KhoaDTO> ReadAll()
        {
            return KhoaDAL.ReadAll();
        }

        public static int Insert(KhoaDTO khoa)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return KhoaDAL.Insert(khoa);
        }

        public static int Update(KhoaDTO khoa)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return KhoaDAL.Update(khoa);
        }

        public static int Delete(string maKhoa)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return KhoaDAL.Delete(maKhoa);
        }

        public static KhoaDTO FindByMaKhoa(string maKhoa)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return KhoaDAL.FindByMaKhoa(maKhoa);
        }
        public static KhoaDTO FindByTenKhoa(string tenKhoa)
        {
        

            return KhoaDAL.FindByTenKhoa(tenKhoa);
        }
        public static List<KhoaDTO> FindKhoa(string searchString)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return KhoaDAL.FindKhoa(searchString);
        }
        public static DataTable ThongKeSinhVienByKhoaAndMonth(DateTime thang)
        {
          

            return KhoaDAL.ThongKeSinhVienByKhoaAndMonth(thang);
        }

    }
}
