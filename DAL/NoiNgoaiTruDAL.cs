using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NoiNgoaiTruDAL
    {
        public static DataTable ReadAll(string maKhoa)
        {
            string query = $"SELECT SinhVien.MaSinhVien, HoTen, NoiNgoaiTru.TuNgay, NoiNgoaiTru.DenNgay, NoiNgoaiTru.Loai FROM NoiNgoaiTru " +
                           $"JOIN SinhVien ON NoiNgoaiTru.MaSinhVien = SinhVien.MaSinhVien " +
                           $"JOIN Lop ON SinhVien.MaLop = Lop.MaLop " +
                           $"WHERE Lop.MaKhoa = '{maKhoa}'";

            return KetNoiDAL.TruyVanLayDuLieu(query);
        }

        public static int Insert(NoiNgoaiTruDTO noiNgoaiTru)
        {
            string ma = "";
            if(noiNgoaiTru.Loai == "Nội trú")
            {
                ma = TaoMaNoiTru();
            }
            else
            {
                ma = TaoMaNgoaiTru();
            }
            string query = $"INSERT INTO NoiNgoaiTru (Ma, MaSinhVien, TuNgay, DenNgay, Loai) " +
                           $"VALUES ('{ma}','{noiNgoaiTru.MaSinhVien}', '{noiNgoaiTru.TuNgay.ToString("yyyy-MM-dd")}', " +
                           $"{(noiNgoaiTru.DenNgay.HasValue ? $"'{noiNgoaiTru.DenNgay.Value.ToString("yyyy-MM-dd")}'" : "NULL")}, " +
                           $"N'{noiNgoaiTru.Loai}')";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Update(NoiNgoaiTruDTO noiNgoaiTru)
        {
            string query = $"UPDATE NoiNgoaiTru SET " +
                           $"TuNgay = '{noiNgoaiTru.TuNgay.ToString("yyyy-MM-dd")}', " +
                           $"DenNgay = {(noiNgoaiTru.DenNgay.HasValue ? $"'{noiNgoaiTru.DenNgay.Value.ToString("yyyy-MM-dd")}'" : "NULL")}" +
                           $"WHERE MaSinhVien = '{noiNgoaiTru.MaSinhVien}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Delete(string ma)
        {
            string query = $"DELETE FROM NoiNgoaiTru WHERE Ma = '{ma}'";
            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static NoiNgoaiTruDTO FindBySinhVien(string maSinhVien)
        {
            string query = $"SELECT * FROM NoiNgoaiTru WHERE MaSinhVien = '{maSinhVien}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NoiNgoaiTruDTO
                {
                    Ma = row["Ma"].ToString(),
                    MaSinhVien = row["MaSinhVien"].ToString(),
                    TuNgay = Convert.ToDateTime(row["TuNgay"]),
                    DenNgay = row["DenNgay"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DenNgay"]),
                    Loai = row["Loai"].ToString()
                };
            }

            return null;
        }

        public static DataTable FindNoiNgoaiTru(string searchString)
        {
            string query = $"SELECT SinhVien.MaSinhVien, HoTen, TenKTX, TuNgay, DenNgay, Loai FROM NoiNgoaiTru " +
                           $"JOIN SinhVien ON NoiNgoaiTru.MaSinhVien = SinhVien.MaSinhVien " +
                           $"WHERE SinhVien.MaSinhVien = '{searchString}' OR SinhVien.TenSinhVien LIKE N'%{searchString}%' " +
                           $"OR TuNgay LIKE '{searchString}%' OR DenNgay LIKE '{searchString}%' OR Loai LIKE '{searchString}%'";

            return KetNoiDAL.TruyVanLayDuLieu(query);
        }
        public static string TaoMaNgoaiTru()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(Ma, 4, LEN(Ma)) AS INT)) AS MaxID FROM NoiNgoaiTru";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0 && data.Rows[0]["MaxID"] != DBNull.Value)
            {
                int maxID = Convert.ToInt32(data.Rows[0]["MaxID"]);
                int newID = maxID + 1;

                string newMaHD = $"NGT{newID:D7}";
                return newMaHD;
            }

            return "NGT0000001";
        }
        public static string TaoMaNoiTru()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(Ma, 4, LEN(Ma)) AS INT)) AS MaxID FROM NoiNgoaiTru";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0 && data.Rows[0]["MaxID"] != DBNull.Value)
            {
                int maxID = Convert.ToInt32(data.Rows[0]["MaxID"]);
                int newID = maxID + 1;

                string newMaHD = $"NOT{newID:D7}";
                return newMaHD;
            }

            return "NOT0000001";
        }
    }
}
