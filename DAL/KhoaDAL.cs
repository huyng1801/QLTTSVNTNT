using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhoaDAL
    {
        public static List<KhoaDTO> ReadAll()
        {
            List<KhoaDTO> danhSachKhoa = new List<KhoaDTO>();

            string query = "SELECT * FROM Khoa";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachKhoa.Add(new KhoaDTO
                {
                    MaKhoa = row["MaKhoa"].ToString(),
                    TenKhoa = row["TenKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                });
            }

            return danhSachKhoa;
        }
        public static int Insert(KhoaDTO khoa)
        {
            string query = $"INSERT INTO Khoa (MaKhoa, TenKhoa, GhiChu) VALUES ('{khoa.MaKhoa}', N'{khoa.TenKhoa}', N'{khoa.GhiChu}')";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Update(KhoaDTO khoa)
        {
            string query = $"UPDATE Khoa SET TenKhoa = N'{khoa.TenKhoa}', GhiChu = N'{khoa.GhiChu}' WHERE MaKhoa = '{khoa.MaKhoa}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Delete(string maKhoa)
        {
            string query = $"DELETE FROM Khoa WHERE MaKhoa = '{maKhoa}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static KhoaDTO FindByMaKhoa(string maKhoa)
        {
            string query = $"SELECT * FROM Khoa WHERE MaKhoa = '{maKhoa}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new KhoaDTO
                {
                    MaKhoa = row["MaKhoa"].ToString(),
                    TenKhoa = row["TenKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }
        public static KhoaDTO FindByTenKhoa(string tenKhoa)
        {
            string query = $"SELECT * FROM Khoa WHERE TenKhoa = N'{tenKhoa}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new KhoaDTO
                {
                    MaKhoa = row["MaKhoa"].ToString(),
                    TenKhoa = row["TenKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }
        public static List<KhoaDTO> FindKhoa(string searchString)
        {
            List<KhoaDTO> danhSachKhoa = new List<KhoaDTO>();
            string query = $"SELECT * FROM Khoa WHERE MaKhoa = '{searchString}' OR TenKhoa LIKE N'%{searchString}%' OR GhiChu LIKE N'%{searchString}%'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachKhoa.Add(new KhoaDTO
                {
                    MaKhoa = row["MaKhoa"].ToString(),
                    TenKhoa = row["TenKhoa"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                });
            }

            return danhSachKhoa;
        }
        public static DataTable ThongKeSinhVienByKhoaAndMonth(DateTime thang)
        {
            string query = $"SELECT Khoa.MaKhoa, TenKhoa, " +
                           $"COUNT(DISTINCT CASE WHEN NoiNgoaiTru.MaSinhVien IS NOT NULL AND NoiNgoaiTru.TuNgay <= '{thang:yyyy-MM-dd}' AND (NoiNgoaiTru.DenNgay IS NULL OR NoiNgoaiTru.DenNgay >= '{thang:yyyy-MM-dd}') AND NoiNgoaiTru.Loai = N'Nội trú' THEN NoiNgoaiTru.MaSinhVien END) AS SoLuongNoiTru, " +
                           $"COUNT(DISTINCT CASE WHEN NoiNgoaiTru.MaSinhVien IS NOT NULL AND NoiNgoaiTru.TuNgay <= '{thang:yyyy-MM-dd}' AND (NoiNgoaiTru.DenNgay IS NULL OR NoiNgoaiTru.DenNgay >= '{thang:yyyy-MM-dd}') AND NoiNgoaiTru.Loai = N'Ngoại trú' THEN NoiNgoaiTru.MaSinhVien END) AS SoLuongNgoaiTru " +
                           $"FROM Khoa " +
                           $"LEFT JOIN Lop ON Khoa.MaKhoa = Lop.MaKhoa " +
                           $"LEFT JOIN SinhVien ON Lop.MaLop = SinhVien.MaLop " +
                           $"LEFT JOIN NoiNgoaiTru ON SinhVien.MaSinhVien = NoiNgoaiTru.MaSinhVien " +
                           $"GROUP BY Khoa.MaKhoa, TenKhoa";
            System.Diagnostics.Debug.WriteLine(query);
            return KetNoiDAL.TruyVanLayDuLieu(query);
        }


    }
}
