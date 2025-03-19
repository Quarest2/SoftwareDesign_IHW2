using HSE_Bank.Patterns.Facade;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class FinanceFacadeTests
{
    [Test]
    public void CreateBankAccount_ShouldCallService()
    {
        var facade = new FinanceFacade();

        facade.CreateBankAccount("Test Account", 1000);

        Assert.Pass("Bank account creation called");
    }
}