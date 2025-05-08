USE vvtDA1
GO


EXEC sp_addlogin ad,'ad'
EXEC sp_addlogin nvbh,'nvbh'
EXEC sp_addlogin nvk,'nvk'

EXEC sp_adduser ad, ad1
EXEC sp_adduser nvbh, NVBanHang
EXEC sp_adduser nvk, NVKho

EXEC sp_addrole NhanVien
EXEC sp_addrolemember NhanVien, NVBanHang
EXEC sp_addrolemember NhanVien, NVKho

----
GRANT ALL ON SanPham
TO ad1
