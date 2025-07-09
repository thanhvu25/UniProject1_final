using BUS;
using DAL;
using DTO;
using Moq;
using NUnit.Framework;
using System.Data;

namespace UnitTest
{
    [TestFixture]
    public class Test_BUSNhanVien
    {
        private Mock<DALNhanVien> mockDal;
        private BUSNhanVien bus;

        [SetUp]
        public void SetUp()
        {
            mockDal = new Mock<DALNhanVien>();
            bus = new BUSNhanVien(mockDal.Object);
        }

        [Test]
        public void GetNhanVien_ShouldReturnDataTable()
        {
            // Arrange
            var table = new DataTable();
            table.Columns.Add("MaNV");
            table.Rows.Add("NV001");
            mockDal.Setup(d => d.getNhanVien()).Returns(table);

            // Act
            var result = bus.getNhanVien();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("NV001", result.Rows[0]["MaNV"]);
        }

        [Test]
        public void KiemTraMaTrung_ShouldReturnCorrectValue()
        {
            mockDal.Setup(d => d.KiemTraMaTrung("NV001")).Returns(1);
            var result = bus.KiemTraMaTrung("NV001");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ThemNV_Valid_ShouldReturnTrue()
        {
            var nv = new DTONhanVien { TenNV = "Nguyen Van A" };
            mockDal.Setup(d => d.themNV(nv)).Returns(true);
            var result = bus.themNV(nv);
            Assert.IsTrue(result);
        }

        [Test]
        public void SuaNV_Valid_ShouldReturnTrue()
        {
            var nv = new DTONhanVien { MaNV = "NV002", TenNV = "Nguyen Van B" };
            mockDal.Setup(d => d.suaNV(nv)).Returns(true);
            var result = bus.suaNV(nv);
            Assert.IsTrue(result);
        }

        [Test]
        public void XoaNV_Valid_ShouldReturnTrue()
        {
            var nv = new DTONhanVien { MaNV = "NV003" };
            mockDal.Setup(d => d.xoaNV(nv)).Returns(true);
            var result = bus.xoaNV(nv);
            Assert.IsTrue(result);
        }
    }
}
