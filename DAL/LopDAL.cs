using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LopDAL
    {
        public static DataTable ReadAllForTable(string maKhoa)
        {
            string query = $"SELECT MaLop, TenLop, TenKhoa, Lop.GhiChu FROM Lop JOIN Khoa ON Lop.MaKhoa = Khoa.MaKhoa WHERE Lop.MaKhoa = '{maKhoa}'";
            return KetNoiDAL.TruyVanLayDuLieu(query);
        }
        public static List<LopDTO> ReadAll()
        {
            List<LopDTO> danhSachLop = new List<LopDTO>();

            string query = "SELECT * FROM Lop";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachLop.Add(new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    MaKhoa = row["MaKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                });
            }

            return danhSachLop;
        }

        public static int Insert(LopDTO lop)
        {
            string query = $"INSERT INTO Lop (MaLop, TenLop, MaKhoa, GhiChu) VALUES ('{lop.MaLop}', N'{lop.TenLop}', '{lop.MaKhoa}', N'{lop.GhiChu}')";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Update(LopDTO lop)
        {
            string query = $"UPDATE Lop SET TenLop = N'{lop.TenLop}', MaKhoa = '{lop.MaKhoa}', GhiChu = N'{lop.GhiChu}' WHERE MaLop = '{lop.MaLop}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Delete(string maLop)
        {
            string query = $"DELETE FROM Lop WHERE MaLop = '{maLop}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static LopDTO FindByMaLop(string maLop)
        {
            string query = $"SELECT * FROM Lop WHERE MaLop = '{maLop}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    MaKhoa = row["MaKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }
        public static LopDTO FindByTenLop(string tenLop)
        {
            string query = $"SELECT * FROM Lop WHERE TenLop = N'{tenLop}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    MaKhoa = row["MaKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }
        public static DataTable FindLop(string maKhoa, string searchString)
        {
            string query = $"SELECT MaLop, TenLop, TenKhoa, Lop.GhiChu FROM Lop JOIN Khoa ON Lop.MaKhoa = Khoa.MaKhoa WHERE Lop.MaKhoa = '{maKhoa}' AND (MaLop = '{searchString}' OR TenLop LIKE N'%{searchString}%' OR Lop.GhiChu LIKE N'%{searchString}%')";
            return KetNoiDAL.TruyVanLayDuLieu(query);
        }
    }
}
