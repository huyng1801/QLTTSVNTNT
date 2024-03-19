using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SinhVienDAL
    {
        public static DataTable ReadAllForTable(string maLop)
        {
            string query = $"SELECT MaSinhVien, HoTen, TenLop, NgaySinh, GioiTinh, DanToc, DiaChi, SoDienThoai, Email FROM SinhVien JOIN Lop ON SinhVien.MaLop = Lop.MaLop WHERE Lop.MaLop = '{maLop}'";
            return KetNoiDAL.TruyVanLayDuLieu(query);
        }
        public static List<SinhVienDTO> ReadAll()
        {
            List<SinhVienDTO> danhSachSinhVien = new List<SinhVienDTO>();

            string query = "SELECT * FROM SinhVien";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachSinhVien.Add(new SinhVienDTO
                {
                    MaSinhVien = row["MaSinhVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = Convert.ToBoolean(row["GioiTinh"]),
                    DanToc = row["DanToc"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return danhSachSinhVien;
        }

        public static int Insert(SinhVienDTO sinhVien)
        {
            string query = $"INSERT INTO SinhVien (MaSinhVien, HoTen, MaLop, NgaySinh, GioiTinh, DanToc, DiaChi, SoDienThoai, Email) " +
                           $"VALUES ('{sinhVien.MaSinhVien}', N'{sinhVien.HoTen}', '{sinhVien.MaLop}', " +
                           $"'{sinhVien.NgaySinh:yyyy-MM-dd}', '{(sinhVien.GioiTinh ? 1 : 0)}', N'{sinhVien.DanToc}', " +
                           $"N'{sinhVien.DiaChi}', '{sinhVien.SoDienThoai}', '{sinhVien.Email}')";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Update(SinhVienDTO sinhVien)
        {
            string query = $"UPDATE SinhVien SET HoTen = N'{sinhVien.HoTen}', MaLop = '{sinhVien.MaLop}', " +
                           $"NgaySinh = '{sinhVien.NgaySinh:yyyy-MM-dd}', GioiTinh = '{(sinhVien.GioiTinh ? 1 : 0)}', " +
                           $"DanToc = N'{sinhVien.DanToc}', DiaChi = N'{sinhVien.DiaChi}', " +
                           $"SoDienThoai = '{sinhVien.SoDienThoai}', Email = '{sinhVien.Email}' " +
                           $"WHERE MaSinhVien = '{sinhVien.MaSinhVien}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Delete(string maSinhVien)
        {
            string query = $"DELETE FROM SinhVien WHERE MaSinhVien = '{maSinhVien}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static SinhVienDTO FindByMaSinhVien(string maSinhVien)
        {
            string query = $"SELECT * FROM SinhVien WHERE MaSinhVien = '{maSinhVien}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new SinhVienDTO
                {
                    MaSinhVien = row["MaSinhVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = Convert.ToBoolean(row["GioiTinh"]),
                    DanToc = row["DanToc"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString()
                };
            }

            return null;
        }
        public static DataTable FindBySinhVien(string maLop, string searchString)
        {
            string query = $"SELECT MaSinhVien, HoTen, TenLop, NgaySinh, GioiTinh, DanToc, DiaChi, SoDienThoai, Email FROM SinhVien JOIN Lop ON SinhVien.MaLop = Lop.MaLop WHERE Lop.MaLop = '{maLop}' AND (MaSinhVien = '{searchString}' OR HoTen LIKE N'%{searchString}%' OR DanToc LIKE N'%{searchString}%' OR DiaChi LIKE N'%{searchString}%' OR SoDienThoai LIKE '%{searchString}%' OR Email LIKE '%{searchString}%')";
            return KetNoiDAL.TruyVanLayDuLieu(query);
        }
    }
}
