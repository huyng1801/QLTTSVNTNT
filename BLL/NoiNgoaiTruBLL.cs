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
    public class NoiNgoaiTruBLL
    {
        public static DataTable ReadAll(string maKhoa)
        {
            return NoiNgoaiTruDAL.ReadAll(maKhoa);
        }

        public static int Insert(NoiNgoaiTruDTO noiNgoaiTru)
        {
            return NoiNgoaiTruDAL.Insert(noiNgoaiTru);
        }

        public static int Update(NoiNgoaiTruDTO noiNgoaiTru)
        {
            return NoiNgoaiTruDAL.Update(noiNgoaiTru);
        }

        public static int Delete(string ma)
        {
            return NoiNgoaiTruDAL.Delete(ma);
        }

        public static NoiNgoaiTruDTO FindBySinhVien(string maSinhVien)
        {
            return NoiNgoaiTruDAL.FindBySinhVien(maSinhVien);
        }

        public static DataTable FindNoiNgoaiTru(string searchString)
        {
            return NoiNgoaiTruDAL.FindNoiNgoaiTru(searchString);
        }

        public static string TaoMaNgoaiTru()
        {
            return NoiNgoaiTruDAL.TaoMaNgoaiTru();
        }
    }
}
