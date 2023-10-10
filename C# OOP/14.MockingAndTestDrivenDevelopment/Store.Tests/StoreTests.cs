using System;
using Moq;
using NUnit.Framework;
using Store.Contracts;
using Store.Tests.Fakes;

namespace Store.Tests
{
    public class StoreTests
    {

        [Test]
        public void TestVisualizeAllProductsMethodShouldWorkCorrectly()
        {
            Mock<IProductDatabase> dbMock = new();

            dbMock.Setup(db => db.GetAll())
                .Returns(new List<Product>()
                {
                    new Product() { Name = "Test", Id  = 1},
                    new Product() { Name = "Test2", Id  = 2}
                });

            Store store = new(dbMock.Object);

            string data = store.VisualizeAllProducts();

            Assert.AreEqual("1 - Test\r\n2 - Test2", data);
        }

        [Test]
        public void TestSaveMethodCallsShouldBeCorrect()
        {
            Mock<IProductDatabase> dbMock = new();
            dbMock.Setup(db => db.Save())
                .Verifiable();

            Store store = new(dbMock.Object);

            var product = new Product()
            {
                Name = "Nike range",
                Id = 3
            };
            store.AddProduct(product);

            dbMock.Verify(db=>db.Save(), Times.Once());
        }

        [Test]
        public void TestAddMethodCallsSaveDatabase()
        {
            Mock<IProductDatabase> dbMock = new();
            Store store = new(dbMock.Object);

            var product = new Product()
            {
                Name = "Nike range",
                Id = 3
            };
            store.AddProduct(product);

            dbMock.Verify(db=>db.AddProduct(product));
        }
    }
}