namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
             database = new(1, 2);
            
        }

        [Test]
        public void CreatingDatabaseCountShoulBeCorrect()
        {
            //Arrange
            int expectedResult = 2;

            //Act
           
            int actualResult = database.Count;
            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDataBaseAddElemeCorrectly(int[] data)
        {            
            database = new(data);            
            int[] actualResult = database.Fetch();
            
            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            
            //Assert
            Assert.Throws<InvalidOperationException>(() 
                => database = new(data), "Array's capacity must be exactly 16 integers!");


        }
        [TestCase(3)]
        [TestCase(-5)]
        public void CreatingDatabaseAddMethodShoulWorkCorrect(int number)
        {
            //Arrange
            int expectedResult = 3;

            //Act
            database.Add(number);
            int actualResult = database.Count;
            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        public void CreatingDatabaseAddMethodShoulAddElementsCorrectly(int[] numbers)
        {            
            //int expectedResult = numbers.Length + database.Count;
            database = new();
            foreach (var number in numbers)
            {
                database.Add(number);
            }
            int[] actualResult = database.Fetch();

            Assert.AreEqual(numbers, actualResult);
        }

        
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void CreatingDatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            database = new(data);
            for (int i = 11; i < 17; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => database.Add(17), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CreatingDatabaseRemoveMethodDecreaseCorrectly()
        {
            int expectedResult = 1;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void CreatingDatabaseRemoveMethodShouldSetLasElementToZero()
        {
            int[] expectedResult = Array.Empty<int>();
                       
            database.Remove();
            database.Remove();
            int[] actualResult = database.Fetch();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void CreatingDatabaseRemoveMethodShouldThrowExceptionWhenCountIsZero(int[] data)
        {
            database = new(data);
            for (int i = 0; i < 10; i++)
            {
                database.Remove();
            }

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => database.Remove(), "The collection is empty!");
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void CreatingDatabaseFetchMethodShouldReturnCorrectData(int[] data)
        {
            database = new(data);
            
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

    }
}
