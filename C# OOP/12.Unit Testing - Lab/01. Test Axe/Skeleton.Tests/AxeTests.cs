using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {

        [Test]
        public void AxeShouldInitializeWithCorrectValues()
        {
            //Arrange and act
            Axe axe = new Axe(101, 101);

            //Assert
            Assert.AreEqual(101, axe.DurabilityPoints);
            Assert.AreEqual(101, axe.AttackPoints);
        }

        [Test]
        public void AttackMethodShouldDecreaseDurabilityPoints()
        {
            //Arrange
            Dummy target = new Dummy(101, 101);
            Axe axe = new Axe(100, 10);

            //Act
            axe.Attack(target);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void AttackMethodShouldThrowAnExceptionIfDurabilityIsZero()
        {
            Dummy target = new Dummy(101, 101);
            Axe axe = new Axe(10, 10);

            //Act
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(target);

            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(target), ("Axe is broken"));
        }
    }
}