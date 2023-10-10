using Moq;
using System;

namespace Mocks
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Mock<IProductDatabase> dbMock = new Mock<IProductDatabase>();

            Store store = new(dbMock.Object);

        }
    }
}