CREATE DATABASE QLTTSVNTNT
GO
USE QLTTSVNTNT 
GO
CREATE TABLE Khoa(
	MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(50) NOT NULL UNIQUE,
    GhiChu NVARCHAR(100)
);
GO
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    DiaChi NVARCHAR(200),
    MatKhau NVARCHAR(200) NOT NULL
);
GO
CREATE TABLE Lop (
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL UNIQUE,
	MaKhoa VARCHAR(10),
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa) ON DELETE CASCADE,
    GhiChu NVARCHAR(100)
);
GO
CREATE TABLE SinhVien (
    MaSinhVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    MaLop VARCHAR(10),
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
	DanToc NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(20) NOT NULL,
    Email VARCHAR(100)
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop) ON DELETE CASCADE 
);
GO
CREATE TABLE NoiNgoaiTru (
	Ma VARCHAR(10) PRIMARY KEY,
    MaSinhVien VARCHAR(10),
	TuNgay DATE NOT NULL,
	DenNgay  DATE,
	Loai NVARCHAR(10) CHECK (Loai IN (N'Nội trú', N'Ngoại trú')),
    FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien) ON DELETE CASCADE
);
GO


INSERT INTO Khoa (MaKhoa, TenKhoa, GhiChu)
VALUES
    ('K001', N'Khoa Công nghệ thông tin', N'Ban quản trị các chương trình đào tạo CNTT'),
    ('K002', N'Khoa Kinh tế', N'Ban quản trị các chương trình đào tạo Kinh tế'),
    ('K003', N'Khoa Ngoại ngữ', N'Ban quản trị các chương trình đào tạo Ngoại ngữ'),
    ('K004', N'Khoa Khoa học Xã hội', N'Ban quản trị các chương trình đào tạo Khoa học Xã hội');
GO
INSERT INTO NhanVien (MaNhanVien, HoTen, SoDienThoai, Email, DiaChi, MatKhau)
VALUES
    ('NV001', N'Nguyễn Văn A', '0987654321', 'nguyenvana@email.com', N'Hà Nội', '1'),
    ('NV002', N'Trần Thị B', '0123456789', 'tranthib@email.com', N'Hồ Chí Minh', '1'),
    ('NV003', N'Phạm Công C', '0369852147', 'phamcongc@email.com', N'Đà Nẵng', '1'),
    ('NV004', N'Lê Thị D', '0998888777', 'lethid@email.com', N'Hải Phòng', '1');
GO

INSERT INTO Lop (MaLop, TenLop, MaKhoa, GhiChu)
VALUES
    ('L001', N'Lớp CNTT-01', 'K001', N'Lớp đầu tiên của Ngành CNTT năm 2021'),
    ('L002', N'Lớp Kinh tế-02', 'K002', N'Lớp thứ hai của Ngành Kinh tế năm 2022'),
    ('L003', N'Lớp Ngoại ngữ-03', 'K003', N'Lớp thứ ba của Ngành Ngoại ngữ năm 2022'),
    ('L004', N'Lớp CNTT-04', 'K001', N'Lớp thứ tư của Ngành CNTT năm 2023');
GO

INSERT INTO SinhVien (MaSinhVien, HoTen, MaLop, NgaySinh, GioiTinh, DanToc, DiaChi, SoDienThoai, Email)
VALUES
    ('SV001', N'Nguyễn Thị An', 'L001', '1999-05-10', 0, N'Kinh', N'Hà Nội', '0987654321', 'nguyenthi.an@email.com'),
    ('SV002', N'Trần Văn Bình', 'L001', '2000-02-15', 1, N'Kinh', N'Hồ Chí Minh', '0123456789', 'tranvan.binh@email.com'),
    ('SV003', N'Lê Minh Cường', 'L002', '1998-09-20', 1, N'Kinh', N'Đà Nẵng', '0369852147', 'leminhcuong@email.com'),
    ('SV004', N'Phạm Thị Dung', 'L002', '2001-03-25', 0, N'Kinh', N'Hải Phòng', '0998888777', 'phamthi.dung@email.com');
GO
INSERT INTO NoiNgoaiTru (Ma, MaSinhVien, TuNgay, DenNgay, Loai)
VALUES
    ('NOT0000001', 'SV001', '2024-01-01', '2024-06-30', N'Nội trú'),
    ('NGT0000002', 'SV002', '2024-02-15', '2024-07-31', N'Ngoại trú'),
    ('NOT0000003', 'SV003', '2024-03-20', '2024-08-31', N'Nội trú'),
    ('NGT0000004', 'SV004', '2024-04-25', '2024-09-30', N'Ngoại trú');
