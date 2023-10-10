using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            //Arrange and act
            Dummy dummy = new Dummy(101, 101);

            //Assert
            Assert.AreEqual(101, dummy.Health);
            //Assert.AreEqual(101, dummy.GiveExperience());
        }

        [Test]
        public void TakeAttackShouldDecreaseHealth()
        {
            Dummy dummy = new Dummy(101, 101);
            dummy.TakeAttack(50);
            Assert.AreEqual(51, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowAnExceptionIfDummyIsDead()
        {
            Dummy dummy = new Dummy(101, 101);
            dummy.TakeAttack(101);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(51), "Dummy is dead.");
        }

        [Test]
        public void GiveExpShouldReturnCurrentExperienceIfDummyIsDead()
        {
            //Arange
            Dummy dummy = new Dummy(101, 101);

            //Act
            dummy.TakeAttack(101);

            //Assert
            Assert.AreEqual(101, dummy.GiveExperience());
        }

        [Test]
        public void GiveExpShouldThrowAnExceptionIfDummyIsNotDead()
        {
            //Arrange
            Dummy dummy = new Dummy(101, 101);

            //Act
            dummy.TakeAttack(100);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }

        [Test]
        public void IsDeadShouldCheckIfHealthIsBelowOrEqualToZero()
        {
            //Arrange
            Dummy dummy = new Dummy(101, 101);

            //Act
            dummy.TakeAttack(101);

            //Assert
            Assert.IsTrue(dummy.IsDead());
        }
    }
}