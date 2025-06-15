--CREATE DATABASE vvtDA1
GO

USE vvtDA1
GO



----------------------------Tạo bảng------------------------------------
CREATE TABLE TaiKhoan
(ID INT PRIMARY KEY IDENTITY(1,1),
TenTK CHAR(20) UNIQUE,
MK VARCHAR(100), 
TenHT NVARCHAR(20) NOT NULL,
VaiTro CHAR(10) CHECK(VaiTro IN ('nv', 'ql')) DEFAULT null
)	
INSERT INTO TaiKhoan(TenTK, MK, TenHT, VaiTro)
VALUES
('ad','ad',N'Quản lý', 'ql'),
('nv','nv',N'Thanh Vũ', 'nv')

--KHÁCH HÀNG
CREATE TABLE KhachHang
(MaKH CHAR(10) PRIMARY KEY,
HoTen NVARCHAR(30) NOT NULL,
GioiTinh NVARCHAR(3) CHECK (GioiTinh IN ('Nam',N'Nữ')),
DiaChi NVARCHAR(100),
Sdt CHAR(10) UNIQUE CHECK (Sdt LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
HangKH NVARCHAR(20)
)

--NHÂN VIÊN
CREATE TABLE NhanVien
(MaNV CHAR(10) PRIMARY KEY,
TenNV NVARCHAR(30) NOT NULL,
GioiTinh NVARCHAR(5) CHECK(GioiTinh IN('Nam', N'Nữ')),
DiaChi NVARCHAR(50),
Sdt CHAR(10) UNIQUE CHECK (Sdt LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
VaiTro NVARCHAR(30) NOT NULL,
LuongCB INT DEFAULT 0
)

 --THƯƠNG HIỆU
CREATE TABLE ThuongHieu
(MaTH CHAR(10) PRIMARY KEY,
TenTH NVARCHAR(30) NOT NULL,
DiaChiTH NVARCHAR(100),
SdtTH CHAR(20) UNIQUE
)


--SẢN PHẨM
CREATE TABLE SanPham
(MaSP CHAR(10) PRIMARY KEY,
TenSP NVARCHAR(50) NOT NULL,
MaTH CHAR(10) REFERENCES ThuongHieu(MaTH) ON UPDATE CASCADE ON DELETE CASCADE,
DonGia INT DEFAULT 0
)


CREATE TABLE Size 
(SizeVN INT PRIMARY KEY,
SizeUS INT,
SizeUK INT,
Centimeter FLOAT
)
CREATE TABLE MauSac 
(MaMau CHAR(10) PRIMARY KEY,
TenMau NVARCHAR(50)
)

CREATE TABLE SanPham_CT 
(MaSP CHAR(10),
SizeVN INT,
MaMau CHAR(10),
PRIMARY KEY (MaSP, SizeVN, MaMau),
FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (SizeVN) REFERENCES Size(SizeVN) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (MaMau) REFERENCES MauSac(MaMau) ON UPDATE CASCADE ON DELETE CASCADE
)

--KHO
CREATE TABLE Kho
(MaSP CHAR(10),
SizeVN INT,
MaMau CHAR(10),
SLTon INT DEFAULT 0,
PRIMARY KEY (MaSP, SizeVN, MaMau),
CONSTRAINT FK_Kho_CTSP FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON UPDATE CASCADE ON DELETE CASCADE
)


--KHUYẾN MÃI
CREATE TABLE KhuyenMai
(MaKM CHAR(10) PRIMARY KEY,
MaSP CHAR(10) REFERENCES SanPham(MaSP) ON UPDATE CASCADE ON DELETE CASCADE,
NgayBD DATE,
NgayKT DATE,
GiamGia INT DEFAULT 0,
HangKH NVARCHAR(20)
)


--HÓA ĐƠN NHẬP
CREATE TABLE HDN
(MaHDN CHAR(10) PRIMARY KEY,
MaTH CHAR(10) REFERENCES ThuongHieu(MaTH) ON UPDATE CASCADE ON DELETE CASCADE,
NgayNhap DATE NOT NULL,
TongHD INT DEFAULT 0,
MaNV CHAR(10) REFERENCES NhanVien(MaNV) ON UPDATE CASCADE ON DELETE CASCADE
)

--HÓA ĐƠN BÁN
CREATE TABLE HDB
(MaHDB CHAR(10) PRIMARY KEY,
MaKH CHAR(10) REFERENCES KhachHang(MaKH) ON UPDATE CASCADE ON DELETE CASCADE,
NgayBan DATE NOT NULL,
TongHD INT DEFAULT 0,
MaNV CHAR(10) REFERENCES NhanVien(MaNV) ON UPDATE CASCADE ON DELETE CASCADE
)

--CHI TIẾT BÁN
CREATE TABLE ChiTietHDB
(MaHDB CHAR(10) REFERENCES HDB(MaHDB) ON UPDATE CASCADE ON DELETE CASCADE,
MaSP CHAR(10) REFERENCES SanPham(MaSP) ON UPDATE CASCADE ON DELETE CASCADE,
SizeVN INT,
MaMau CHAR(10),

PRIMARY KEY (MaHDB, MaSP, SizeVN, MaMau), 

SL INT DEFAULT 0,
DonGia INT
)

--CHI TIẾT NHẬP
CREATE TABLE ChiTietHDN
(MaHDN CHAR(10) REFERENCES HDN(MaHDN) ON UPDATE CASCADE ON DELETE CASCADE,
MaSP CHAR(10) REFERENCES SanPham(MaSP) ,
SizeVN INT,
MaMau CHAR(10),

PRIMARY KEY (MaHDN, MaSP, SizeVN, MaMau), 

SL INT DEFAULT 0,
DonGia INT
)



--------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------DALLogin
--getTK
SELECT TenTK, MK, TenHT, VaiTro = CASE 
                WHEN VaiTro = 'ql' THEN N'Quản lý'
                WHEN VaiTro = 'nv' THEN N'Nhân viên'
                ELSE 'Khác'
             END
FROM TaiKhoan

-------------------------------------------------------------------------------------------DAL SẢN PHẨM
--Tính SLTon theo MaSP 
SELECT SP.MaSP, SP.TenSP, TH.TenTH, SP.DonGia, SL = SUM(ISNULL(Kho.SLTon, 0))
FROM SanPham SP
LEFT JOIN Kho ON SP.MaSP = Kho.MaSP
LEFT JOIN ThuongHieu TH ON SP.MaTH = TH.MaTH
GROUP BY SP.MaSP, SP.TenSP, TH.TenTH, SP.DonGia
ORDER BY SP.MaSP

--sản phẩm + slton
SELECT SanPham.MaSP, TenSP, TenTH, Kho.SizeVN, Kho.MaMau, SanPham.DonGia, SLTon
FROM SanPham INNER JOIN Kho
ON SanPham.MaSP = Kho.MaSP INNER JOIN ChiTietHDN
ON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN
ON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu
ON ThuongHieu.MaTH = HDN.MaTH 

--spbanchay
SELECT ChiTietHDB.MaSP, TenSP, SizeVN, TenMau, SUM(ChiTietHDB.SL) AS TongSL
FROM HDB
JOIN ChiTietHDB ON HDB.MaHDB = ChiTietHDB.MaHDB
JOIN SanPham ON ChiTietHDB.MaSP = SanPham.MaSP
JOIN MauSac ON ChiTietHDB.MaMau = MauSac.MaMau
WHERE HDB.NgayBan BETWEEN '2025-06-01' AND '2025-06-15'
GROUP BY ChiTietHDB.MaSP, TenSP, SizeVN, TenMau
ORDER BY TongSL DESC


-------------------------------------------------------------------------------------------DAL CHI TIẾT SP
--lấy ctsp
SELECT SanPham_CT.MaSP, TenSP, SizeVN, MauSac.MaMau, TenMau
FROM SanPham_CT INNER JOIN SanPham 
ON SanPham_CT.MaSP = SanPham.MaSP INNER JOIN MauSac
ON SanPham_CT.MaMau = MauSac.MaMau

--lấy ctsp cho BH
SELECT SanPham_CT.MaSP, TenSP, SanPham_CT.SizeVN, SLTon
FROM SanPham_CT INNER JOIN Kho
ON SanPham_CT.MaSP = Kho.MaSP 
AND SanPham_CT.SizeVN = Kho.SizeVN
AND SanPham_CT.MaMau = Kho.MaMau INNER JOIN SanPham
ON SanPham_CT.MaSP = SanPham.MaSP

--lấy ctsp cho SP
SELECT SanPham_CT.MaSP, TenSP, SizeVN,  TenMau 
FROM SanPham_CT INNER JOIN SanPham 
ON SanPham_CT.MaSP = SanPham.MaSP INNER JOIN MauSac
ON SanPham_CT.MaMau = MauSac.MaMau
WHERE SanPham_CT.MaSP = @MaSP

-------------------------------------------------------------------------------------------DAL KHÁCH HÀNG
--KH + HDB
SELECT KhachHang.MaKH, HoTen, HDB.MaHDB, NgayBan, ChiTietHDB.DonGia, TenSP, SizeVN, TenMau
FROM KhachHang 
INNER JOIN HDB			ON KhachHang.MaKH = HDB.MaKH 
INNER JOIN ChiTietHDB	ON HDB.MaHDB = ChiTietHDB.MaHDB 
INNER JOIN MauSac		ON ChiTietHDB.MaMau = MauSac.MaMau 
INNER JOIN SanPham		ON SanPham.MaSP = ChiTietHDB.MaSP
WHERE KhachHang.MaKH = @MaKH

--lọc theo level
SELECT MaKH, HoTen, GioiTinh, DiaChi, Sdt, HangKH
FROM KhachHang 
WHERE HangKH = @HangKH
--
SELECT 
    kh.MaKH,
    COUNT(DISTINCT hdb.MaHDB) AS SoDon,
    SUM(ct.DonGia * ct.SL) AS TongTien
FROM KhachHang kh
LEFT JOIN HDB hdb ON kh.MaKH = hdb.MaKH
LEFT JOIN ChiTietHDB ct ON hdb.MaHDB = ct.MaHDB
WHERE MONTH(hdb.NgayBan) = '06' AND YEAR(hdb.NgayBan) = '2025'
GROUP BY kh.MaKH

--
SELECT HDB.MaHDB, TongDT = SUM(TongHD)
FROM HDB
JOIN KhachHang ON HDB.MaKH = KhachHang.MaKH
WHERE HDB.NgayBan BETWEEN @TuNgay AND @DenNgay
GROUP BY HDB.MaHDB

--bcdoanhthu
SELECT HDB.MaHDB, NgayBan, HDB.MaKH, HoTen, TongHD
FROM HDB
JOIN KhachHang ON HDB.MaKH = KhachHang.MaKH
WHERE HDB.NgayBan BETWEEN '2025-06-01' AND '2025-06-15'
ORDER BY HDB.NgayBan

--KH + HDB
SELECT KhachHang.MaKH, HoTen, HDB.MaHDB, NgayBan
FROM KhachHang 
INNER JOIN HDB ON KhachHang.MaKH = HDB.MaKH 

-------------------------------------------------------------------------------------------DAL CtHDB
--getCTHDBForHDB
SELECT ChiTietHDB.MaHDB, TenSP, SizeVN, TenMau, SL, ChiTietHDB.DonGia
FROM ChiTietHDB INNER JOIN HDB
ON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang
ON HDB.MaKH = KhachHang.MaKH INNER JOIN SanPham
ON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac
ON MauSac.MaMau = ChiTietHDB.MaMau
WHERE ChiTietHDB.MaHDB = @MaHDB

--getCtHDBByMaHDB
SELECT cthdb.MaHDB, cthdb.MaSP, sp.TenSP, cthdb.SizeVN, m.TenMau, cthdb.MaMau, cthdb.SL, cthdb.DonGia, (cthdb.SL * cthdb.DonGia) AS ThanhTien
FROM ChiTietHDB cthdb
JOIN SanPham sp ON cthdb.MaSP = sp.MaSP
JOIN MauSac m ON cthdb.MaMau = m.MaMau
WHERE cthdb.MaHDB = @MaHDB

--forHDB
SELECT CONCAT(TenSP, ', ', SizeVN, ', ', TenMau) AS SP, SL, ctB.DonGia, ThanhTien = (SL * ctB.DonGia)
FROM ChiTietHDB ctB 
INNER JOIN HDB B ON ctB.MaHDB=B.MaHDB
INNER JOIN SanPham S ON S.MaSP = ctB.MaSP
INNER JOIN MauSac M ON M.MaMau = ctB.MaMau
WHERE ctB.MaHDB = @MaHDB

--getCtHDB
SELECT ChiTietHDB.MaHDB, TenSP, SizeVN, TenMau, SL, ChiTietHDB.DonGia
FROM ChiTietHDB INNER JOIN HDB
ON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang
ON HDB.MaKH = KhachHang.MaKH INNER JOIN SanPham
ON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac
ON MauSac.MaMau = ChiTietHDB.MaMau
           
-------------------------------------------------------------------------------------------DAL CtHDN
--getHDN
SELECT ChiTietHDN.MaHDN, TenSP, SizeVN, TenMau, SL, ChiTietHDN.DonGia
FROM ChiTietHDN
INNER JOIN HDN ON HDN.MaHDN = ChiTietHDN.MaHDN
INNER JOIN ThuongHieu ON HDN.MaTH = ThuongHieu.MaTH
INNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP
INNER JOIN MauSac ON ChiTietHDN.MaMau = MauSac.MaMau 

-------------------------------------------------------------------------------------------DAL HDN
--getHDN: MaHDN, TenTH, NgayNhap, TongHD, TenNV
SELECT HDN.MaHDN, TenTH, NgayNhap, TongHD, TenNV
FROM HDN 
INNER JOIN NhanVien		ON HDN.MaNV = NhanVien.MaNV 
INNER JOIN ThuongHieu	ON HDN.MaTH = ThuongHieu.MaTH

-------------------------------------------------------------------------------------------DAL HDB
--getHDB
SELECT HDB.MaHDB, HoTen, NgayBan, TongHD, TenNV
FROM HDB 
INNER JOIN NhanVien		ON HDB.MaNV = NhanVien.MaNV 
INNER JOIN KhachHang	ON HDB.MaKH = KhachHang.MaKH

-------------------------------------------------------------------------------------------DAL KHO
--slton kho thấp
SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon 
FROM Kho 
INNER JOIN SanPham		ON SanPham.MaSP = Kho.MaSP 
INNER JOIN SanPham_CT	ON SanPham.MaSP = SanPham_CT.MaSP 
INNER JOIN MauSac		ON MauSac.MaMau = SanPham_CT.MaMau 
INNER JOIN ChiTietHDN	ON SanPham.MaSP = ChiTietHDN.MaSP
INNER JOIN HDN			ON ChiTietHDN.MaHDN = HDN.MaHDN 
INNER JOIN ThuongHieu	ON ThuongHieu.MaTH = HDN.MaTH 
WHERE SLTon <= 10

--getKho
SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon
FROM Kho INNER JOIN SanPham 
ON SanPham.MaSP = Kho.MaSP INNER JOIN SanPham_CT
ON SanPham.MaSP = SanPham_CT.MaSP INNER JOIN MauSac
ON MauSac.MaMau = SanPham_CT.MaMau LEFT JOIN ChiTietHDN
ON SanPham.MaSP = ChiTietHDN.MaSP LEFT JOIN HDN
ON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu
ON ThuongHieu.MaTH = HDN.MaTH 

--??
SELECT Kho.MaSP, TenSP, Kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon
FROM Kho 
INNER JOIN SanPham ON SanPham.MaSP = Kho.MaSP 
INNER JOIN SanPham_CT ON SanPham.MaSP = SanPham_CT.MaSP 
INNER JOIN MauSac ON MauSac.MaMau = SanPham_CT.MaMau 
LEFT JOIN ChiTietHDN ON SanPham.MaSP = ChiTietHDN.MaSP 
LEFT JOIN HDN ON ChiTietHDN.MaHDN = HDN.MaHDN 
LEFT JOIN ThuongHieu ON ThuongHieu.MaTH = HDN.MaTH


--??
SELECT Kho.MaSP, TenSP, kho.SizeVN, TenMau, ThuongHieu.TenTH, SLTon 
FROM Kho 
INNER JOIN SanPham 
ON SanPham.MaSP = Kho.MaSP INNER JOIN SanPham_CT
ON SanPham.MaSP = SanPham_CT.MaSP INNER JOIN MauSac
ON MauSac.MaMau = SanPham_CT.MaMau INNER JOIN ChiTietHDN
ON SanPham.MaSP = ChiTietHDN.MaSP INNER JOIN HDN
ON ChiTietHDN.MaHDN = HDN.MaHDN INNER JOIN ThuongHieu
ON ThuongHieu.MaTH = HDN.MaTH  
WHERE Kho.MaSP = @MaSP

--
SELECT MaKH, HoTen, HangKH
FROM KhachHang


----------------------------------------------------------------------------------------






--CT + Kho
SELECT SanPham_CT.MaSP, TenSP, SanPham_CT.SizeVN, TenMau, SLTon
FROM SanPham_CT INNER JOIN Kho
ON SanPham_CT.MaSP = Kho.MaSP 
AND SanPham_CT.SizeVN = Kho.SizeVN 
AND SanPham_CT.MaMau = Kho.MaMau INNER JOIN SanPham
ON SanPham_CT.MaSP = SanPham.MaSP



--tính sum số HDB cho từng maKH-> HangKH
SELECT KhachHang.MaKH, HoTen, TongHD = SUM(DonGia), SoHD = COUNT(DISTINCT HDB.MaHDB)
FROM KhachHang INNER JOIN ChiTietHDB
ON KhachHang.MaKH = ChiTietHDB.MaKH INNER JOIN HDB
ON HDB.MaHDB = ChiTietHDB.MaHDB
GROUP BY KhachHang.MaKH, HoTen



--CTB +++
SELECT MaCTB, ChiTietHDB.MaHDB, HoTen, TenSP, SizeVN, TenMau, SL, MaNV
FROM ChiTietHDB INNER JOIN HDB
ON ChiTietHDB.MaHDB = HDB.MaHDB INNER JOIN KhachHang
ON ChiTietHDB.MaKH = KhachHang.MaKH INNER JOIN SanPham
ON SanPham.MaSP = ChiTietHDB.MaSP INNER JOIN MauSac
ON MauSaC.MaMau = ChiTietHDB.MaMau