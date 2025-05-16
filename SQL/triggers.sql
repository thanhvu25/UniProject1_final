

USE vvtDA1
GO


---------------------------------------------------------------------------------
--Tự động cập nhật kho sau khi thêm ChiTietHDN
CREATE TRIGGER trg_UpdateKho_AfterInsert_CTHDN
ON ChiTietHDN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Nếu sản phẩm đã có trong kho thì cộng thêm
    UPDATE Kho
    SET SLTon = SLTon + i.SL
    FROM Kho k
    INNER JOIN inserted i
        ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau;

    -- Nếu sản phẩm chưa có thì thêm mới
    INSERT INTO Kho (MaSP, SizeVN, MaMau, SLTon)
    SELECT i.MaSP, i.SizeVN, i.MaMau, i.SL
    FROM inserted i
    LEFT JOIN Kho k
        ON k.MaSP = i.MaSP AND k.SizeVN = i.SizeVN AND k.MaMau = i.MaMau
    WHERE k.MaSP IS NULL;
END
