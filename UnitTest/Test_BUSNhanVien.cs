using BUS;
using DAL;
using DTO;
using Moq;
using System.Data;

namespace UnitTest;

[TestFixture]
public class Test_BUSNhanVien
{
    private Mock<DALNhanVien> mockDal;
    private BUSNhanVien bus;

    [SetUp]
    public void SetUp()
    {
        mockDal = new Mock<DALNhanVien>();
        bus = new BUSNhanVien(mockDal.Object); // Inject mock vào constructor
    }


    [Test]
    public void getNhanVien_ShouldReturnDataTable()
    {
        // Arrange
        var expectedTable = new DataTable();
        expectedTable.Columns.Add("MaNV");
        expectedTable.Columns.Add("TenNV");

        var row = expectedTable.NewRow();
        row["MaNV"] = "NV001";
        row["TenNV"] = "Thanh Vũ";
        expectedTable.Rows.Add(row);

        mockDal.Setup(d => d.getNhanVien()).Returns(expectedTable);

        // Act
        var result = bus.getNhanVien();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Rows.Count);
        Assert.AreEqual("NV001", result.Rows[0]["MaNV"]);
    }

    [Test]
    public void KiemTraMaTrung_WithExistingMaNV_ShouldReturnGreaterThanZero()
    {
        // Arrange
        string maNV = "NV001";
        mockDal.Setup(d => d.KiemTraMaTrung(maNV)).Returns(1);

        // Act
        var result = bus.KiemTraMaTrung(maNV);

        // Assert
        Assert.Greater(result, 0);
    }

    [Test]
    public void themNV_ValidNhanVien_ShouldReturnTrue()
    {
        // Arrange
        var nv = new DTONhanVien
        {
            TenNV = "Nguyen Van B",
            GioiTinh = "Nam",
            DiaChi = "Ha Noi",
            Sdt = "0909090909",
            VaiTro = "Nhân viên",
            LuongCB = 7000000
        };

        mockDal.Setup(d => d.themNV(nv)).Returns(true);

        // Act
        var result = bus.themNV(nv);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void suaNV_ValidNhanVien_ShouldReturnTrue()
    {
        // Arrange
        var nv = new DTONhanVien
        {
            MaNV = "NV002",
            TenNV = "Nguyen Van C",
            GioiTinh = "Nam",
            DiaChi = "Ha Noi",
            Sdt = "0909090909",
            VaiTro = "Quản lý",
            LuongCB = 10000000
        };

        mockDal.Setup(d => d.suaNV(nv)).Returns(true);

        // Act
        var result = bus.suaNV(nv);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void xoaNV_ValidNhanVien_ShouldReturnTrue()
    {
        // Arrange
        var nv = new DTONhanVien
        {
            MaNV = "NV002"
        };

        mockDal.Setup(d => d.xoaNV(nv)).Returns(true);

        // Act
        var result = bus.xoaNV(nv);

        // Assert
        Assert.IsTrue(result);
    }
}
