using HSE_Bank.Domain.Models;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void CreateBankAccount_ShouldSetInitialBalance()
    {
        var account = new BankAccount { Id = 1, Name = "Test Account", Balance = 1000 };

        Assert.AreEqual(1000, account.Balance);
    }
}