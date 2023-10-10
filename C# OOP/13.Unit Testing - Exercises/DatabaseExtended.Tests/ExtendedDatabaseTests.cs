namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {

            Person[] people =
            {
                new Person(1, "Ivo"),
                new Person(2, "Stefo"),
                new Person(3, "Ivo1"),
                new Person(4, "Stefo1"),
                new Person(5, "Ivo2"),
                new Person(6, "Stefo2"),
                new Person(7, "Ivo3"),
                new Person(8, "Stefo3"),
                new Person(9, "Ivo4"),
                new Person(10, "Stefo4"),
            };

            database = new(people);
        }
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            int expectedCount = 10;
            Assert.AreEqual(expectedCount, database.Count);
        }

        //[Test]
        //public void CreatingDataBaseCountShouldWorkCorrectly()
        //{

        //    Person person = new(1, "Ivo");
        //    Person person2 = new(2, "Stefo");
        //    Person person3 = new(3, "Ivo1");
        //    Person person4 = new(4, "Stefo1");
        //    Person person5 = new(5, "Ivo2");
        //    Person person6 = new(6, "Stefo2");
        //    Person person7 = new(7, "Ivo3");
        //    Person person8 = new(8, "Stefo3");
        //    Database database = new(person, person2, person3, person4, person5, person6, person7, person8);
        //    int expectedCount = 8;

        //    Assert.AreEqual(expectedCount, database.Count);
        //}

        [Test]
        public void CreatingDataBaseConstructorShouldThrowExceptionWhenCountIsBiggerThan16()
        {

            Person[] people =
            {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko"),
            new Person(12, "Moshko"),
            new Person(13, "Foshko"),
            new Person(14, "Loshko"),
            new Person(15, "Roshko"),
            new Person(16, "Boshko"),
            new Person(17, "Kokoshko")
            };

            Assert.Throws<ArgumentException>(
                () => new Database(people), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {

            int expectedResult = 10;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldIncreaseCount()
        {
            var person = new Person(11, "Paul");

            database.Add(person);

            int expectedResult = 11;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldWorkCorrectly()
        {
            var person = new Person(11, "Paul");

            database.Add(person);

            int expectedResult = 11;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CreatingDataBaseAddMethodShouldThrowExceptionWhenCountIsBiggerThan16()
        {

            Person person11 = new(11, "Ivo11");
            Person person12 = new(12, "Stefo11");
            Person person13 = new(13, "Ivo21");
            Person person14 = new(14, "Stefo21");
            Person person15 = new(15, "Ivo32");
            Person person16 = new(16, "Stefo32");
            Person person17 = new(17, "Stefo33");


            database.Add(person11);
            database.Add(person12);
            database.Add(person13);
            database.Add(person14);
            database.Add(person15);
            database.Add(person16);


            Assert.Throws<InvalidOperationException>(
                () => database.Add(person17), "Array's capacity must be exactly 16 integers!");
        }


        [Test]
        public void CreatingDataBaseAddMethodShouldThrowExceptionWhenUsernameIsAlreadyExisting()
        {

            Person person = new(14, "Ivo");

            Assert.Throws<InvalidOperationException>(
            () => database.Add(person), "There is already user with this username!");
        }

        [Test]
        public void CreatingDataBaseAddMethodShouldThrowExceptionWhenIdIsAlreadyExisting()
        {
            Person person = new(1, "Stefanom");


            Assert.Throws<InvalidOperationException>(
                () => database.Add(person), "There is already user with this Id!");
        }

        [Test]
        public void CreatingDataBaseRemoveMethodShouldWorkCorrectly()
        {
            int expectedCount = 9;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void CreatingDataBaseRemoveMethodShouldThrowExceptionWhenCountIsZero()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        public void CreatingDataBaseFindByUsernameMethodShouldWorkCorrectly()
        {
            string expectedResult = "Ivo";
            string actualResult = database.FindByUsername("Ivo").UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1, null)]
        [TestCase(1, "")]
        public void CreatingDataBaseFindByUsernameMethodShouldThrowExceptionWhenNameIsNull
            (long id, string name)
        {

            Person expectedPerson = new(1, "Ivo");

            Database database = new(expectedPerson);


            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(name), "Username parameter is null!");
        }

        [TestCase(1, "Ivo")]
        public void CreatingDataBaseFindByUsernameMethodShouldThrowExceptionWhenUsernameDoesntExist
            (long id, string name)
        {

            Person expectedPerson = new(id, name);

            Database database = new(expectedPerson);


            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("Ivan"), "No user is present by this username!");
        }

        [TestCase(1, "Ivo")]
        public void CreatingDataBaseFindByIdMethodShouldWorkCorrectly(long id, string name)
        {

            Person expectedPerson = new(id, name);

            Database database = new(expectedPerson);


            Person actualPerson = database.FindById(id);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestCase(-1, "Ivo")]
        public void CreatingDataBaseFindByIdMethodShouldThrowExceptionWhenNameIsNull(long id, string name)
        {

            Person expectedPerson = new(id, name);

            Database database = new(expectedPerson);


            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(id), "Id should be a positive number!");
        }

        [TestCase(1, "Ivo")]
        public void CreatingDataBaseFindByIdMethodShouldThrowExceptionWhenUsernameDoesntExist
            (long id, string name)
        {

            Person expectedPerson = new(id, name);

            Database database = new(expectedPerson);


            Assert.Throws<InvalidOperationException>(
                () => database.FindById(3), "No user is present by this ID!");
        }
    }
}