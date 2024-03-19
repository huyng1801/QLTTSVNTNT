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
    public class LopBLL
    {
        public static DataTable ReadAllForTable(string maKhoa)
        {

            return LopDAL.ReadAllForTable(maKhoa);
        }
        public static List<LopDTO> ReadAll()
        {
            return LopDAL.ReadAll();
        }

        public static int Insert(LopDTO lop)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return LopDAL.Insert(lop);
        }

        public static int Update(LopDTO lop)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return LopDAL.Update(lop);
        }

        public static int Delete(string maLop)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return LopDAL.Delete(maLop);
        }

        public static LopDTO FindByMaLop(string maLop)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return LopDAL.FindByMaLop(maLop);
        }
        public static LopDTO FindByTenLop(string tenLop)
        {
    

            return LopDAL.FindByTenLop(tenLop);
        }
        public static DataTable FindLop(string tenLop, string maKhoa)
        {
            // You can perform additional business logic checks here if needed before calling DAL
            return LopDAL.FindLop(tenLop, maKhoa);
        }

    }
}
