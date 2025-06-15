USE vvtDA1
GO

----------------------------------------SẢN PHẨM------------------------------------------------
<<<<<<< HEAD
-- Nike (TH001)
EXEC sp_ThemSanPham @TenSP = N'Nike Air Force 1', @MaTH = 'TH001', @DonGia = 2900000;
EXEC sp_ThemSanPham @TenSP = N'Nike Dunk Low', @MaTH = 'TH001', @DonGia = 3500000;
EXEC sp_ThemSanPham @TenSP = N'Nike Air Jordan 1 Mid', @MaTH = 'TH001', @DonGia = 4200000;

-- Puma (TH002)
EXEC sp_ThemSanPham @TenSP = N'Puma Suede Classic', @MaTH = 'TH002', @DonGia = 2000000;
EXEC sp_ThemSanPham @TenSP = N'Puma RS-X', @MaTH = 'TH002', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Puma Cali Star', @MaTH = 'TH002', @DonGia = 2300000;

-- Adidas (TH003)
EXEC sp_ThemSanPham @TenSP = N'Adidas Ultraboost 22', @MaTH = 'TH003', @DonGia = 4500000;
EXEC sp_ThemSanPham @TenSP = N'Adidas Superstar', @MaTH = 'TH003', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Adidas Stan Smith', @MaTH = 'TH003', @DonGia = 2600000;

-- Converse (TH004)
EXEC sp_ThemSanPham @TenSP = N'Converse Chuck 70 High', @MaTH = 'TH004', @DonGia = 1900000;
EXEC sp_ThemSanPham @TenSP = N'Converse Run Star Hike', @MaTH = 'TH004', @DonGia = 2600000;
EXEC sp_ThemSanPham @TenSP = N'Converse One Star', @MaTH = 'TH004', @DonGia = 2100000;

-- Vans (TH005)
EXEC sp_ThemSanPham @TenSP = N'Vans Old Skool', @MaTH = 'TH005', @DonGia = 1800000;
EXEC sp_ThemSanPham @TenSP = N'Vans Sk8-Hi', @MaTH = 'TH005', @DonGia = 2000000;
EXEC sp_ThemSanPham @TenSP = N'Vans Authentic', @MaTH = 'TH005', @DonGia = 1600000;

-- New Balance (TH006)
EXEC sp_ThemSanPham @TenSP = N'New Balance 550', @MaTH = 'TH006', @DonGia = 3800000;
EXEC sp_ThemSanPham @TenSP = N'New Balance 574', @MaTH = 'TH006', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'New Balance 2002R', @MaTH = 'TH006', @DonGia = 4200000;

-- MLB (TH007)
EXEC sp_ThemSanPham @TenSP = N'MLB Chunky Liner', @MaTH = 'TH007', @DonGia = 2800000;
EXEC sp_ThemSanPham @TenSP = N'MLB Big Ball Chunky', @MaTH = 'TH007', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'MLB Playball Origin', @MaTH = 'TH007', @DonGia = 2100000;

-- Balenciaga (TH008)
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Triple S', @MaTH = 'TH008', @DonGia = 26000000;
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Track', @MaTH = 'TH008', @DonGia = 23000000;
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Speed Trainer', @MaTH = 'TH008', @DonGia = 18500000;

-- Alexander McQueen (TH009)
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Oversized Sneaker', @MaTH = 'TH009', @DonGia = 16500000;
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Court Trainer', @MaTH = 'TH009', @DonGia = 14000000;
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Sprint Runner', @MaTH = 'TH009', @DonGia = 18000000;

-- Biti's (TH010)
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter X', @MaTH = 'TH010', @DonGia = 1000000;
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter Street', @MaTH = 'TH010', @DonGia = 850000;
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter Core', @MaTH = 'TH010', @DonGia = 950000;

-- Ananas (TH011)
EXEC sp_ThemSanPham @TenSP = N'Ananas Urbas', @MaTH = 'TH011', @DonGia = 720000;
EXEC sp_ThemSanPham @TenSP = N'Ananas Basas', @MaTH = 'TH011', @DonGia = 650000;
EXEC sp_ThemSanPham @TenSP = N'Ananas Track 6', @MaTH = 'TH011', @DonGia = 800000;

-- Onitsuka Tiger (TH012)
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Mexico 66', @MaTH = 'TH012', @DonGia = 3200000;
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Serrano', @MaTH = 'TH012', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Delegation EX', @MaTH = 'TH012', @DonGia = 3800000;
=======
-- Nike
EXEC sp_ThemSanPham @TenSP = N'Nike Air Force 1', @DonGia = 2900000;
EXEC sp_ThemSanPham @TenSP = N'Nike Dunk Low', @DonGia = 3500000;
EXEC sp_ThemSanPham @TenSP = N'Nike Air Jordan 1 Mid', @DonGia = 4200000;

-- Puma
EXEC sp_ThemSanPham @TenSP = N'Puma Suede Classic', @DonGia = 2000000;
EXEC sp_ThemSanPham @TenSP = N'Puma RS-X', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Puma Cali Star', @DonGia = 2300000;

-- Adidas
EXEC sp_ThemSanPham @TenSP = N'Adidas Ultraboost 22', @DonGia = 4500000;
EXEC sp_ThemSanPham @TenSP = N'Adidas Superstar', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Adidas Stan Smith', @DonGia = 2600000;

-- Converse
EXEC sp_ThemSanPham @TenSP = N'Converse Chuck 70 High', @DonGia = 1900000;
EXEC sp_ThemSanPham @TenSP = N'Converse Run Star Hike', @DonGia = 2600000;
EXEC sp_ThemSanPham @TenSP = N'Converse One Star', @DonGia = 2100000;

-- Vans
EXEC sp_ThemSanPham @TenSP = N'Vans Old Skool', @DonGia = 1800000;
EXEC sp_ThemSanPham @TenSP = N'Vans Sk8-Hi', @DonGia = 2000000;
EXEC sp_ThemSanPham @TenSP = N'Vans Authentic', @DonGia = 1600000;

-- New Balance
EXEC sp_ThemSanPham @TenSP = N'New Balance 550', @DonGia = 3800000;
EXEC sp_ThemSanPham @TenSP = N'New Balance 574', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'New Balance 2002R', @DonGia = 4200000;

-- MLB
EXEC sp_ThemSanPham @TenSP = N'MLB Chunky Liner', @DonGia = 2800000;
EXEC sp_ThemSanPham @TenSP = N'MLB Big Ball Chunky', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'MLB Playball Origin', @DonGia = 2100000;

-- Balenciaga
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Triple S', @DonGia = 26000000;
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Track', @DonGia = 23000000;
EXEC sp_ThemSanPham @TenSP = N'Balenciaga Speed Trainer', @DonGia = 18500000;

-- Alexander McQueen
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Oversized Sneaker', @DonGia = 16500000;
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Court Trainer', @DonGia = 14000000;
EXEC sp_ThemSanPham @TenSP = N'Alexander McQueen Sprint Runner', @DonGia = 18000000;

-- Biti's
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter X', @DonGia = 1000000;
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter Street', @DonGia = 850000;
EXEC sp_ThemSanPham @TenSP = N'Biti''s Hunter Core', @DonGia = 950000;

-- Ananas
EXEC sp_ThemSanPham @TenSP = N'Ananas Urbas', @DonGia = 720000;
EXEC sp_ThemSanPham @TenSP = N'Ananas Basas', @DonGia = 650000;
EXEC sp_ThemSanPham @TenSP = N'Ananas Track 6', @DonGia = 800000;

-- Onitsuka Tiger
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Mexico 66', @DonGia = 3200000;
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Serrano', @DonGia = 2500000;
EXEC sp_ThemSanPham @TenSP = N'Onitsuka Tiger Delegation EX', @DonGia = 3800000;
>>>>>>> a67220a4f4aec0f6fa333ec273d882b6a756ac55

----------------------------------------CHI TIẾT SẢN PHẨM------------------------------------------------
INSERT INTO SanPham_CT (MaSP, SizeVN, MaMau) 
VALUES 
('SP005', 38, 'White'),
('SP015', 40, 'White'),
('SP008', 37, 'White'),
('SP022', 42, 'White'),
('SP001', 36, 'White'),
('SP018', 39, 'White'),
('SP030', 35, 'White'),
('SP012', 40, 'White'),
('SP027', 41, 'White'),
('SP009', 36, 'White'),
('SP020', 42, 'White'),
('SP003', 39, 'White'),
('SP034', 37, 'White'),
('SP024', 35, 'White'),
('SP014', 42, 'White'),
('SP031', 38, 'White'),
('SP017', 40, 'White'),
('SP007', 36, 'White'),
('SP023', 41, 'White'),
('SP011', 39, 'White');


----------------------------------------HDN & CHI TIẾT------------------------------------------------
-- Thêm hóa đơn nhập
EXEC sp_ThemHDN @MaTH = 'TH005', @NgayNhap = '2025-01-15', @TongHD = 12000000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH011', @NgayNhap = '2025-01-20', @TongHD = 8700000,  @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH002', @NgayNhap = '2025-02-05', @TongHD = 15900000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH008', @NgayNhap = '2025-02-22', @TongHD = 21300000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH004', @NgayNhap = '2025-03-03', @TongHD = 4600000,  @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH010', @NgayNhap = '2025-03-18', @TongHD = 32500000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH001', @NgayNhap = '2025-04-01', @TongHD = 17800000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH007', @NgayNhap = '2025-04-12', @TongHD = 24500000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH006', @NgayNhap = '2025-04-29', @TongHD = 9300000,  @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH012', @NgayNhap = '2025-05-09', @TongHD = 30000000, @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH009', @NgayNhap = '2025-05-20', @TongHD = 4800000,  @MaNV = 'NV001';
EXEC sp_ThemHDN @MaTH = 'TH003', @NgayNhap = '2025-05-30', @TongHD = 19600000, @MaNV = 'NV001';


EXEC sp_ThemChiTietHDN @MaHDN = 'N0001', @MaSP = 'SP005', @SizeVN = 38, @MaMau = 'White', @SL = 20, @DonGia = 1800000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0002', @MaSP = 'SP015', @SizeVN = 40, @MaMau = 'White', @SL = 25, @DonGia = 2100000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0003', @MaSP = 'SP008', @SizeVN = 37, @MaMau = 'White', @SL = 30, @DonGia = 1500000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0004', @MaSP = 'SP022', @SizeVN = 42, @MaMau = 'White', @SL = 17, @DonGia = 2700000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0005', @MaSP = 'SP001', @SizeVN = 36, @MaMau = 'White', @SL = 22, @DonGia = 1900000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0006', @MaSP = 'SP018', @SizeVN = 39, @MaMau = 'White', @SL = 26, @DonGia = 2000000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0007', @MaSP = 'SP030', @SizeVN = 35, @MaMau = 'White', @SL = 19, @DonGia = 1750000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0008', @MaSP = 'SP012', @SizeVN = 40, @MaMau = 'White', @SL = 28, @DonGia = 1600000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0009', @MaSP = 'SP027', @SizeVN = 41, @MaMau = 'White', @SL = 24, @DonGia = 2250000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0010', @MaSP = 'SP009', @SizeVN = 36, @MaMau = 'White', @SL = 15, @DonGia = 1850000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0011', @MaSP = 'SP020', @SizeVN = 42, @MaMau = 'White', @SL = 21, @DonGia = 1950000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0012', @MaSP = 'SP003', @SizeVN = 39, @MaMau = 'White', @SL = 30, @DonGia = 1600000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0001', @MaSP = 'SP034', @SizeVN = 37, @MaMau = 'White', @SL = 17, @DonGia = 1700000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0002', @MaSP = 'SP024', @SizeVN = 35, @MaMau = 'White', @SL = 22, @DonGia = 1900000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0003', @MaSP = 'SP014', @SizeVN = 42, @MaMau = 'White', @SL = 16, @DonGia = 1550000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0004', @MaSP = 'SP031', @SizeVN = 38, @MaMau = 'White', @SL = 25, @DonGia = 1850000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0005', @MaSP = 'SP017', @SizeVN = 40, @MaMau = 'White', @SL = 18, @DonGia = 1750000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0006', @MaSP = 'SP007', @SizeVN = 36, @MaMau = 'White', @SL = 29, @DonGia = 2100000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0007', @MaSP = 'SP023', @SizeVN = 41, @MaMau = 'White', @SL = 23, @DonGia = 1950000;
EXEC sp_ThemChiTietHDN @MaHDN = 'N0008', @MaSP = 'SP011', @SizeVN = 39, @MaMau = 'White', @SL = 20, @DonGia = 2000000;


