using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class BankAccountService
{
    private readonly List<BankAccount> _accounts = new();

    public void CreateAccount(string name, decimal initialBalance, int userId)
    {
        var account = new BankAccount
        {
            Id = _accounts.Count + 1,
            Name = name,
            Balance = initialBalance,
            UserId = userId
        };
        _accounts.Add(account);
        Console.WriteLine($"Created account: {account.Name} with balance {account.Balance}");
    }

    public void UpdateAccount(int accountId, string name, decimal balance)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            account.Name = name;
            account.Balance = balance;
            Console.WriteLine($"Updated account: {account.Name} with balance {account.Balance}");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public void DeleteAccount(int accountId)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            _accounts.Remove(account);
            Console.WriteLine($"Deleted account: {account.Name}");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public List<BankAccount> GetAccountsByUser(int userId)
    {
        return _accounts.Where(a => a.UserId == userId).ToList();
    }
}