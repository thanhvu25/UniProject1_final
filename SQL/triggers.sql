

USE vvtDA1
GO


---------------------------------------------------------------------------------
--Tự động cập nhật kho sau khi thêm ChiTietHDN
CREATE TRIGGER trg_CapNhatKho_SauNhap
ON ChiTietHDN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật tồn kho nếu đã có
    UPDATE Kho
    SET SLTon = SLTon + i.SL
    FROM Kho k
    INNER JOIN inserted i
        ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau;

    -- Thêm mới vào Kho nếu chưa có
    INSERT INTO Kho (MaSP, SizeVN, MaMau, SLTon)
    SELECT i.MaSP, i.SizeVN, i.MaMau, i.SL
    FROM inserted i
    LEFT JOIN Kho k
        ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau
    WHERE k.MaSP IS NULL;
END


--Tự động cập nhật kho sau khi bán ChiTietHDB
CREATE TRIGGER trg_TruKho_SauBan
ON ChiTietHDB
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Trừ tồn kho
    UPDATE Kho
    SET SLTon = SLTon - i.SL
    FROM Kho k
    INNER JOIN inserted i
        ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau;

    -- Báo lỗi nếu SLTon bị âm 
    IF EXISTS (SELECT 1 FROM Kho k
				INNER JOIN inserted i
				ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau
				WHERE (k.SLTon - i.SL) < 0
	)
		BEGIN
			RAISERROR (N'Tồn kho không đủ để bán!', 16, 1);
			ROLLBACK TRANSACTION;
		END
END
