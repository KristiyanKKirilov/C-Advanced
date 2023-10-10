namespace BankAccount.Tests
{
    public class BankAccountTests
    {
        [TestCase(5000, 5000)]
        [TestCase(1000, 1000)]
        public void BankAccountShouldInitializeWithAmount(decimal amount, decimal expectedAmount)
        {
            BankAccount bankAccount = new BankAccount(amount);

            Assert.AreEqual(expectedAmount, bankAccount.Amount);
        }
    }
}