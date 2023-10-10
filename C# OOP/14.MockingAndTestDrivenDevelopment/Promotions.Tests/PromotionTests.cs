using NUnit.Framework;

namespace Promotions.Tests
{
    public class PromotionTests
    {
        private Promotions promotions;
        [SetUp]
        public void Setup()
        {
            promotions = new();
        }

        [Test]
        public void PromotionShouldBe25Percentage()
        {
            decimal sale = promotions.GetPromotionPercentage(DayOfWeek.Monday);
            Assert.AreEqual(25, sale);
        }
    }
}