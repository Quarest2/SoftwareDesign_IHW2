using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class BankAccountService
{
    private static int _accNum;
    
    public void CreateAccount(string name, decimal initialBalance)
    {
        var account = new BankAccount
        {
            Id = _accNum, 
            Name = name,
            Balance = initialBalance
        };

        _accNum++;
        Console.WriteLine($"Created account: {account.Name} with balance {account.Balance}");
    }
}