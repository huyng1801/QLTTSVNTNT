using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        public static List<NhanVienDTO> ReadAll()
        {
            List<NhanVienDTO> danhSachNhanVien = new List<NhanVienDTO>();

            string query = "SELECT * FROM NhanVien";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachNhanVien.Add(new NhanVienDTO
                {
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    MatKhau = row["MatKhau"].ToString()
                });
            }

            return danhSachNhanVien;
        }

        public static int Insert(NhanVienDTO nhanVien)
        {
            string query = $"INSERT INTO NhanVien (MaNhanVien, HoTen, SoDienThoai, Email, DiaChi, MatKhau) " +
                           $"VALUES ('{nhanVien.MaNhanVien}', N'{nhanVien.HoTen}', '{nhanVien.SoDienThoai}', " +
                           $"'{nhanVien.Email}', N'{nhanVien.DiaChi}', '{nhanVien.MatKhau}')";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Update(NhanVienDTO nhanVien)
        {
            string query = $"UPDATE NhanVien SET HoTen = N'{nhanVien.HoTen}', SoDienThoai = '{nhanVien.SoDienThoai}', " +
                           $"Email = '{nhanVien.Email}', DiaChi = N'{nhanVien.DiaChi}', MatKhau = '{nhanVien.MatKhau}' " +
                           $"WHERE MaNhanVien = '{nhanVien.MaNhanVien}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static int Delete(string maNhanVien)
        {
            string query = $"DELETE FROM NhanVien WHERE MaNhanVien = '{maNhanVien}'";

            return KetNoiDAL.TruyVanKhongLayDuLieu(query);
        }

        public static NhanVienDTO FindByMaNhanVien(string maNhanVien)
        {
            string query = $"SELECT * FROM NhanVien WHERE MaNhanVien = '{maNhanVien}'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NhanVienDTO
                {
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    MatKhau = row["MatKhau"].ToString()
                };
            }

            return null;
        }
        public static List<NhanVienDTO> FindNhanVien(string searchString)
        {
            List<NhanVienDTO> danhSachNhanVien = new List<NhanVienDTO>();

            string query = $"SELECT * FROM NhanVien WHERE MaNhanVien = '{searchString}' OR HoTen LIKE N'%{searchString}%' OR SoDienThoai LIKE '%{searchString}%' OR Email LIKE '%{searchString}%' OR DiaChi LIKE N'%{searchString}%'";
            DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);

            foreach (DataRow row in data.Rows)
            {
                danhSachNhanVien.Add(new NhanVienDTO
                {
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    MatKhau = row["MatKhau"].ToString()
                });
            }

            return danhSachNhanVien;
        }
        public static NhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                string query = $"SELECT * FROM NhanVien WHERE MaNhanVien = '{tenDangNhap}' AND MatKhau = '{matKhau}'";

                DataTable data = KetNoiDAL.TruyVanLayDuLieu(query);
                if (data.Rows.Count > 0)
                {   
                    DataRow row = data.Rows[0];
                    return new  NhanVienDTO
                    {
                        MaNhanVien = row["MaNhanVien"].ToString(),
                        HoTen = row["HoTen"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        Email = row["Email"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        MatKhau = row["MatKhau"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return null;
        }
    }
}
