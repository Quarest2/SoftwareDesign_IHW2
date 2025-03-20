using System.Linq;
using HSE_Bank.Domain.Services;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class BankAccountServiceTests
{
    private BankAccountService _service;

    [SetUp]
    public void SetUp()
    {
        _service = new BankAccountService();
    }

    [Test]
    public void CreateAccount_ShouldAddAccountToList()
    {
        _service.CreateAccount("Main Account", 1000, 1);

        var accounts = _service.GetAccountsByUser(1);
        Assert.AreEqual(1, accounts.Count);
        Assert.AreEqual("Main Account", accounts[0].Name);
        Assert.AreEqual(1000, accounts[0].Balance);
    }

    [Test]
    public void UpdateAccount_ShouldModifyExistingAccount()
    {
        _service.CreateAccount("Main Account", 1000, 1);

        _service.UpdateAccount(1, "Updated Account", 2000);

        var account = _service.GetAccountsByUser(1).First();
        Assert.AreEqual("Updated Account", account.Name);
        Assert.AreEqual(2000, account.Balance);
    }

    [Test]
    public void DeleteAccount_ShouldRemoveAccountFromList()
    {
        _service.CreateAccount("Main Account", 1000, 1);

        _service.DeleteAccount(1);

        var accounts = _service.GetAccountsByUser(1);
        Assert.AreEqual(0, accounts.Count);
    }
}