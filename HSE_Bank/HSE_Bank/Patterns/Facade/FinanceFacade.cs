using HSE_Bank.Domain.Services;

namespace HSE_Bank.Patterns.Facade;

public class FinanceFacade
{
    private readonly BankAccountService _bankAccountService = new();
    private readonly CategoryService _categoryService = new();
    private readonly OperationService _operationService = new();

    public void CreateBankAccount(string name, decimal initialBalance)
    {
        _bankAccountService.CreateAccount(name, initialBalance);
    }

    public void CreateCategory(string type, string name)
    {
        _categoryService.CreateCategory(type, name);
    }

    public void CreateOperation(string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
    {
        _operationService.CreateOperation(type, bankAccountId, amount, date, description, categoryId);
    }
}