using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Factories;

public static class DomainFactory
{
    public static Operation CreateOperation(string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");

        return new Operation
        {
            Type = type,
            BankAccountId = bankAccountId,
            Amount = amount,
            Date = date,
            Description = description,
            CategoryId = categoryId
        };
    }
}

