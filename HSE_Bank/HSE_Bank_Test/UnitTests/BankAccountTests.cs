using HSE_Bank.Domain.Models;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void BankAccount_ShouldInitializePropertiesCorrectly()
    {
        var account = new BankAccount
        {
            Id = 1,
            Name = "Main Account",
            Balance = 1000,
            UserId = 1
        };

        Assert.AreEqual(1, account.Id);
        Assert.AreEqual("Main Account", account.Name);
        Assert.AreEqual(1000, account.Balance);
        Assert.AreEqual(1, account.UserId);
    }
}