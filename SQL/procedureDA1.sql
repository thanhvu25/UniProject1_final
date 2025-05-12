USE vvtDA1
GO

-----------------------------------------------------KHÁCH HÀNG----------------------------------------
CREATE PROCEDURE sp_ThemKhachHang
    @HoTen NVARCHAR(30),
    @GioiTinh NVARCHAR(3),
    @DiaChi NVARCHAR(100),
    @Sdt CHAR(10),
    @HangKH NVARCHAR(20)
AS
BEGIN
	PRINT 'GioiTinh = ' + QUOTENAME(@GioiTinh)


    DECLARE @MaMoi CHAR(10)
    SELECT @MaMoi = MAX(MaKH) FROM KhachHang

    IF (@MaMoi IS NULL)
        SET @MaMoi = 'KH000'

    DECLARE @SoMoi INT
    SET @SoMoi = CAST(SUBSTRING(@MaMoi, 3, 3) AS INT) + 1

    SET @MaMoi = 'KH' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)

    -- Thêm khách hàng
    INSERT INTO KhachHang (MaKH, HoTen, GioiTinh, DiaChi, Sdt, HangKH)
    VALUES (@MaMoi, @HoTen, @GioiTinh, @DiaChi, @Sdt, @HangKH)
END
EXEC sp_ThemKhachHang 
    @HoTen = N'Nguyễn Văn An',
    @GioiTinh = N'Nam',
    @DiaChi = N'Hà Nội',
    @Sdt = '0987654322',
    @HangKH = N'Thân thiết'

sp_helptext 'sp_ThemKhachHang'



CREATE PROCEDURE sp_SuaKhachHang
    @MaKH CHAR(10),
    @HoTen NVARCHAR(30),
    @GioiTinh NVARCHAR(3),
    @DiaChi NVARCHAR(100),
    @Sdt CHAR(10),
    @HangKH NVARCHAR(20)
AS
BEGIN
    UPDATE KhachHang
    SET 
        HoTen = @HoTen,
        GioiTinh = @GioiTinh,
        DiaChi = @DiaChi,
        Sdt = @Sdt,
        HangKH = @HangKH
    WHERE MaKH = @MaKH
END
EXEC sp_SuaKhachHang 
    @MaKH = 'KH001',
    @HoTen = N'Nguyễn Văn Bình',
    @GioiTinh = N'Nam',
    @DiaChi = N'Đà Nẵng',
    @Sdt = '0909123456',
    @HangKH = N'Thân thiết'


CREATE PROCEDURE sp_XoaKhachHang
    @MaKH CHAR(10)
AS
BEGIN
    DELETE FROM KhachHang
    WHERE MaKH = @MaKH
END
EXEC sp_XoaKhachHang @MaKH = 'KH001'

-----------------------------------------------------NHÂN VIÊN----------------------------------------
CREATE PROCEDURE sp_ThemNhanVien
    @TenNV NVARCHAR(30),
    @GioiTinh NVARCHAR(5),
    @DiaChi NVARCHAR(50),
    @Sdt CHAR(10),
    @VaiTro NVARCHAR(30),
    @LuongCB INT
AS
BEGIN
    -- Biến chứa mã nhân viên mới
    DECLARE @MaMoi CHAR(10)

    -- Lấy mã NV lớn nhất hiện có
    SELECT @MaMoi = MAX(MaNV) FROM NhanVien

    -- Nếu chưa có nhân viên nào, bắt đầu từ NV000
    IF (@MaMoi IS NULL)
        SET @MaMoi = 'NV000'

    -- Tăng số lên 1
    DECLARE @SoMoi INT
    SET @SoMoi = CAST(SUBSTRING(@MaMoi, 3, 3) AS INT) + 1

    -- Sinh mã mới dạng NV001, NV002,...
    SET @MaMoi = 'NV' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)

    -- Thêm nhân viên mới vào bảng
    INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, DiaChi, Sdt, VaiTro, LuongCB)
    VALUES (@MaMoi, @TenNV, @GioiTinh, @DiaChi, @Sdt, @VaiTro, @LuongCB)
END
--EXEC sp_ThemNhanVien 
--    @TenNV = N'{0}',
--    @GioiTinh = N'{1}',
--    @DiaChi = N'{2}',
--    @Sdt = '{3}',
--    @VaiTro = N'{4}',
--    @LuongCB = {5} 

---------------
CREATE PROCEDURE sp_SuaNhanVien
    @MaNV CHAR(10),
    @TenNV NVARCHAR(30),
    @GioiTinh NVARCHAR(5),
    @DiaChi NVARCHAR(50),
    @Sdt CHAR(10),
    @VaiTro NVARCHAR(30),
    @LuongCB INT
AS
BEGIN
    -- Cập nhật thông tin nhân viên theo MaNV
    UPDATE NhanVien
    SET 
        TenNV = @TenNV,
        GioiTinh = @GioiTinh,
        DiaChi = @DiaChi,
        Sdt = @Sdt,
        VaiTro = @VaiTro,
        LuongCB = @LuongCB
    WHERE MaNV = @MaNV
END
--EXEC sp_SuaNhanVien
--    @MaNV = '{0}',
--    @TenNV = N'{1}',
--    @GioiTinh = N'{2}',
--    @DiaChi = N'{3}',
--    @Sdt = '{4}',
--    @VaiTro = N'{5}',
--    @LuongCB = {6}

-------------
CREATE PROCEDURE sp_XoaNhanVien
    @MaNV CHAR(10)
AS
BEGIN
    -- Xóa nhân viên theo mã nhân viên
    DELETE FROM NhanVien
    WHERE MaNV = @MaNV
END
EXEC sp_XoaNhanVien @MaNV = '{0}'


-----------------------------------------------------THƯƠNG HIỆU----------------------------------------
CREATE PROCEDURE sp_ThemThuongHieu
    @TenTH NVARCHAR(30),
    @DiaChiTH NVARCHAR(100),
    @SdtTH CHAR(20)
AS
BEGIN
    DECLARE @MaMoi CHAR(10)

    -- Lấy mã TH lớn nhất
    SELECT @MaMoi = MAX(MaTH) FROM ThuongHieu

    -- Nếu chưa có thương hiệu nào
    IF (@MaMoi IS NULL)
        SET @MaMoi = 'TH000'

    -- Tăng số lên 1
    DECLARE @SoMoi INT
    SET @SoMoi = CAST(SUBSTRING(@MaMoi, 3, 3) AS INT) + 1

    -- Sinh mã mới dạng TH001, TH002,...
    SET @MaMoi = 'TH' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)

    -- Thêm thương hiệu mới
    INSERT INTO ThuongHieu (MaTH, TenTH, DiaChiTH, SdtTH)
    VALUES (@MaMoi, @TenTH, @DiaChiTH, @SdtTH)
END
--EXEC sp_ThemThuongHieu 
--    @TenTH = N'{0}',
--    @DiaChiTH = N'{1}',
--    @SdtTH = '{2}'


CREATE PROCEDURE sp_SuaThuongHieu
    @MaTH CHAR(10),
    @TenTH NVARCHAR(30),
    @DiaChiTH NVARCHAR(100),
    @SdtTH CHAR(20)
AS
BEGIN
    -- Cập nhật thông tin thương hiệu
    UPDATE ThuongHieu
    SET 
        TenTH = @TenTH,
        DiaChiTH = @DiaChiTH,
        SdtTH = @SdtTH
    WHERE MaTH = @MaTH
END
--EXEC sp_SuaThuongHieu
--    @MaTH = '{0}',
--    @TenTH = N'{1}',
--    @DiaChiTH = N'{2}',
--    @SdtTH = '{3}'


CREATE PROCEDURE sp_XoaThuongHieu
    @MaTH CHAR(10)
AS
BEGIN
    -- Xóa thương hiệu theo mã
    DELETE FROM ThuongHieu
    WHERE MaTH = @MaTH
END
EXEC sp_XoaThuongHieu @MaTH = '{0}'

-----------------------------------------------------SẢN PHẨM----------------------------------------
CREATE PROCEDURE sp_ThemSanPham
    @TenSP NVARCHAR(50),
    @MaTH CHAR(10),
    @DonGia INT
AS
BEGIN
    DECLARE @MaMoi CHAR(10)

    -- Lấy mã sản phẩm lớn nhất hiện có
    SELECT @MaMoi = MAX(MaSP) FROM SanPham

    -- Nếu chưa có sản phẩm nào
    IF (@MaMoi IS NULL)
        SET @MaMoi = 'SP000'

    -- Tăng số lên 1
    DECLARE @SoMoi INT
    SET @SoMoi = CAST(SUBSTRING(@MaMoi, 3, 3) AS INT) + 1

    -- Sinh mã mới dạng SP001, SP002,...
    SET @MaMoi = 'SP' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)

    -- Thêm sản phẩm mới
    INSERT INTO SanPham (MaSP, TenSP, MaTH, DonGia)
    VALUES (@MaMoi, @TenSP, @MaTH,  @DonGia)
END
--EXEC sp_ThemSanPham 
--    @TenSP = N'{0}',
--    @MaTH = '{1}',
--    @DonGia = {2}


CREATE PROCEDURE sp_SuaSanPham
    @MaSP CHAR(10),
    @TenSP NVARCHAR(50),
    @MaTH CHAR(10),
    @DonGia INT
AS
BEGIN
    -- Cập nhật thông tin sản phẩm
    UPDATE SanPham
    SET 
        TenSP = @TenSP,
        MaTH = @MaTH,
        DonGia = @DonGia
    WHERE MaSP = @MaSP
END
--EXEC sp_SuaSanPham
--    @MaSP = '{0}',
--    @TenSP = N'{1}',
--    @MaTH = '{2}',
--    @DonGia = {3}

CREATE PROCEDURE sp_XoaSanPham
    @MaSP CHAR(10)
AS
BEGIN
    -- Xóa sản phẩm theo mã
    DELETE FROM SanPham
    WHERE MaSP = @MaSP
END
EXEC sp_XoaSanPham @MaSP = '{0}'


-----------------------------------------------------KHO----------------------------------------
CREATE PROCEDURE sp_ThemKho
    @MaSP CHAR(10),
    @SizeVN INT,
    @MaMau CHAR(10),
    @SLTon INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Kho WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau)
    BEGIN
        RAISERROR(N'Dữ liệu đã tồn tại.', 16, 1)
        RETURN
    END

    INSERT INTO Kho (MaSP, SizeVN, MaMau, SLTon)
    VALUES (@MaSP, @SizeVN, @MaMau, @SLTon)
END
--EXEC sp_ThemKho @MaSP = '{0}', 
--			      @SizeVN = {1}, 
--			      @MaMau = '{2}', 
--			      @SLTon = {3}

CREATE PROCEDURE sp_SuaKho
    @MaSP CHAR(10),
    @SizeVN INT,
    @MaMau CHAR(10),
    @SLTon INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Kho WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau)
    BEGIN
        RAISERROR(N'Dữ liệu không tồn tại.', 16, 1)
        RETURN
    END
    UPDATE Kho
    SET SLTon = @SLTon
    WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau
END
--EXEC sp_SuaKho @MaSP = '{0}', 
--			     @SizeVN = {1}, 
--			     @MaMau = '{2}', 
--			     @SLTon = {3}

CREATE PROCEDURE sp_CongKho
    @MaSP CHAR(10),
    @SizeVN INT,
    @MaMau CHAR(10),
    @SLTon INT
AS
BEGIN
    -- Kiểm tra tồn tại
    IF EXISTS (SELECT 1 FROM Kho WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau)
    BEGIN
        -- Cộng dồn số lượng tồn
        UPDATE Kho
        SET SLTon = SLTon + @SLTon
        WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau
    END	
END
--EXEC sp_CongKho @MaSP = '{0}', 
--			     @SizeVN = {1}, 
--			     @MaMau = '{2}', 
--			     @SLTon = {3}

CREATE PROCEDURE sp_XoaKho
    @MaSP CHAR(10),
    @SizeVN INT,
    @MaMau CHAR(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Kho WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau)
    BEGIN
        RAISERROR(N'Dữ liệu không tồn tại.', 16, 1)
        RETURN
    END

    DELETE FROM Kho
    WHERE MaSP = @MaSP AND SizeVN = @SizeVN AND MaMau = @MaMau
END
--EXEC sp_XoaKho @MaSP = '{0}', 
--			     @SizeVN = {1}, 
--			     @MaMau = '{2}'


-----------------------------------------------------HDN----------------------------------------
CREATE PROCEDURE sp_ThemHDN
    @NgayNhap DATE,
    @DonGia INT
AS
BEGIN
    DECLARE @MaMoi CHAR(10)

    -- Lấy mã HDN lớn nhất hiện có
    SELECT @MaMoi = MAX(MaHDN) FROM HDN

    -- Nếu chưa có hóa đơn nào, bắt đầu từ HDN000
    IF (@MaMoi IS NULL)
        SET @MaMoi = 'HDN000'

    -- Tăng số lên 1
    DECLARE @SoMoi INT
    SET @SoMoi = CAST(SUBSTRING(@MaMoi, 4, 3) AS INT) + 1

    -- Sinh mã mới dạng HDN001, HDN002,...
    SET @MaMoi = 'HDN' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)

    -- Thêm hóa đơn mới vào bảng
    INSERT INTO HDN (MaHDN, NgayNhap, DonGia)
    VALUES (@MaMoi, @NgayNhap, @DonGia)
END
--EXEC sp_ThemHDN 
--    @NgayNhap = '{0}',
--    @DonGia = {1}


CREATE PROCEDURE sp_SuaHDN
    @MaHDN CHAR(10),
    @NgayNhap DATE,
    @DonGia INT
AS
BEGIN
    -- Cập nhật thông tin hóa đơn nhập theo mã
    UPDATE HDN
    SET 
        NgayNhap = @NgayNhap,
        DonGia = @DonGia
    WHERE MaHDN = @MaHDN
END
--EXEC sp_SuaHDN
--    @MaHDN = '{0}',
--    @NgayNhap = '{1}',
--    @DonGia = {2}


CREATE PROCEDURE sp_XoaHDN
    @MaHDN CHAR(10)
AS
BEGIN
    -- Xóa hóa đơn nhập theo mã
    DELETE FROM HDN
    WHERE MaHDN = @MaHDN
END
--EXEC sp_XoaHDN @MaHDN = 'HDN003'



-----------------------------------------------------CHI TIẾT HDN----------------------------------------
CREATE PROCEDURE sp_ThemChiTietHDN
    @MaHDN CHAR(10),
    @MaNV CHAR(10),
    @MaSP CHAR(10),
    @MaTH CHAR(10),
    @SL INT
AS
BEGIN
    INSERT INTO ChiTietHDN (MaHDN, MaSP, MaTH, SL, MaNV)
    VALUES (@MaHDN, @MaSP, @MaTH, @SL, @MaNV)
END
--EXEC sp_ThemChiTietHDN
--    @MaHDN = '{0}',
--    @MaSP = '{1}',
--    @MaTH = '{2}',
--    @SL = {3},
--    @MaNV = '{4}'

CREATE PROCEDURE sp_SuaChiTietHDN
    @MaHDN CHAR(10),
    @MaSP CHAR(10),
    @MaNV CHAR(10),
    @MaTH CHAR(10),
    @SL INT
AS
BEGIN
    UPDATE ChiTietHDN
    SET 
        MaNV = @MaNV,
        MaTH = @MaTH,
        SL = @SL
    WHERE MaHDN = @MaHDN AND MaSP = @MaSP
END
--EXEC sp_SuaChiTietHDN
--    @MaHDN = '{0}',
--    @MaSP = '{1}',
--    @MaTH = '{2}',
--    @SL = {3},
--    @MaNV = '{4}'

CREATE PROCEDURE sp_XoaChiTietHDN
    @MaHDN CHAR(10),
    @MaSP CHAR(10)
AS
BEGIN
    DELETE FROM ChiTietHDN
    WHERE MaHDN = @MaHDN AND MaSP = @MaSP
END
--EXEC sp_XoaChiTietHDN
--    @MaHDN = '{0}',
--    @MaSP = '{1}'

-----------------------------------------------------KHUYẾN MÃI----------------------------------------
CREATE PROCEDURE sp_ThemKhuyenMai
    @MaKM CHAR(10) = NULL,   -- Cho phép NULL (không bắt buộc)
    @MaSP CHAR(10),
    @NgayBD DATE,
    @NgayKT DATE,
    @GiamGia INT
AS
BEGIN
    -- Nếu không truyền mã thì tự tạo
    IF (@MaKM IS NULL OR @MaKM = '')
    BEGIN
        DECLARE @MaMoi CHAR(10)

        SELECT @MaMoi = MAX(MaKM) FROM KhuyenMai

        IF (@MaMoi IS NULL)
            SET @MaMoi = 'KM000'

        DECLARE @SoMoi INT
        SET @SoMoi = CAST(SUBSTRING(@MaMoi, 3, 3) AS INT) + 1

        SET @MaKM = 'KM' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)
    END

    -- Thêm vào bảng
    INSERT INTO KhuyenMai (MaKM, MaSP, NgayBD, NgayKT, GiamGia)
    VALUES (@MaKM, @MaSP, @NgayBD, @NgayKT, @GiamGia)
END
--EXEC sp_ThemKhuyenMai 
--    @MaKM = '{0}',
--    @MaSP = '{1}',
--    @NgayBD = '{2}',
--    @NgayKT = '{3}',
--    @GiamGia = {4}

CREATE PROCEDURE sp_SuaKhuyenMai
    @MaKM CHAR(10),
    @MaSP CHAR(10),
    @NgayBD DATE,
    @NgayKT DATE,
    @GiamGia INT
AS
BEGIN
    UPDATE KhuyenMai
    SET 
        MaSP = @MaSP,
        NgayBD = @NgayBD,
        NgayKT = @NgayKT,
        GiamGia = @GiamGia
    WHERE MaKM = @MaKM
END
--EXEC sp_SuaKhuyenMai
--    @MaKM = '{0}',
--    @MaSP = '{1}',
--    @NgayBD = '{2}',
--    @NgayKT = '{3}',
--    @GiamGia = {4}

CREATE PROCEDURE sp_XoaKhuyenMai
    @MaKM CHAR(10)
AS
BEGIN
    DELETE FROM KhuyenMai
    WHERE MaKM = @MaKM
END
--EXEC sp_XoaKhuyenMai @MaKM = '{0}'


-----------------------------------------------------HDB-----------------------------------
CREATE PROCEDURE sp_ThemHDB
    @MaHDB CHAR(10) = NULL,
    @NgayBan DATE,
    @DonGia INT
AS
BEGIN
    BEGIN
        DECLARE @MaMoi CHAR(10)
        SELECT @MaMoi = MAX(MaHDB) FROM HDB

        IF (@MaMoi IS NULL)
            SET @MaMoi = 'HDB000'

        DECLARE @SoMoi INT
        SET @SoMoi = CAST(SUBSTRING(@MaMoi, 4, 3) AS INT) + 1

        SET @MaHDB = 'HDB' + RIGHT('000' + CAST(@SoMoi AS VARCHAR(3)), 3)
    END

    -- Thêm hóa đơn
    INSERT INTO HDB (MaHDB, NgayBan, DonGia)
    VALUES (@MaHDB, @NgayBan, @DonGia)
END
--EXEC sp_ThemHDB 
--    @NgayBan = '{0}',
--    @DonGia = {1}


CREATE PROCEDURE sp_SuaHDB
    @MaHDB CHAR(10),
    @NgayBan DATE,
    @DonGia INT
AS
BEGIN
    UPDATE HDB
    SET 
        NgayBan = @NgayBan,
        DonGia = @DonGia
    WHERE MaHDB = @MaHDB
END
--EXEC sp_SuaHDB 
--    @MaHDB = '{0}',
--    @NgayBan = '{1}',
--    @DonGia = {2}


CREATE PROCEDURE sp_XoaHDB
    @MaHDB CHAR(10)
AS
BEGIN
    DELETE FROM HDB
    WHERE MaHDB = @MaHDB
END
--EXEC sp_XoaHDB @MaHDB = '{0}'

-----------------------------------------------------CHI TIẾT HDB-----------------------------------
CREATE PROCEDURE sp_ThemChiTietHDB
    @MaHDB CHAR(10),
    @MaNV CHAR(10),
    @MaSP CHAR(10),
    @MaKH CHAR(10),
    @SL INT
AS
BEGIN
    INSERT INTO ChiTietHDB (MaHDB, MaSP, MaKH, SL, MaNV)
    VALUES (@MaHDB, @MaSP, @MaKH, @SL, @MaNV)
END
--EXEC sp_ThemChiTietHDB 
--    @MaHDB = '{0}',
--    @MaSP = '{1}',
--    @MaKH = '{2}',
--    @SL = {3},
--	@MaNV = '{4}'


CREATE PROCEDURE sp_SuaChiTietHDB
    @MaHDB CHAR(10),
    @MaSP CHAR(10),
    @MaKH CHAR(10),
    @SL INT,
	@MaNV CHAR(10)
AS
BEGIN
    UPDATE ChiTietHDB
    SET 
        MaNV = @MaNV,
        MaKH = @MaKH,
        SL = @SL
    WHERE MaHDB = @MaHDB AND MaSP = @MaSP
END
--EXEC sp_SuaChiTietHDB 
--    @MaHDB = '{0}',
--    @MaSP = '{1}',
--    @MaKH = '{2}',
--    @SL = {3},
--	@MaNV = '{4}'


CREATE PROCEDURE sp_XoaChiTietHDB
    @MaHDB CHAR(10),
    @MaSP CHAR(10)
AS
BEGIN
    DELETE FROM ChiTietHDB
    WHERE MaHDB = @MaHDB AND MaSP = @MaSP
END
--EXEC sp_XoaChiTietHDB 
--    @MaHDB = '{0}',
--    @MaSP = '{1}'
