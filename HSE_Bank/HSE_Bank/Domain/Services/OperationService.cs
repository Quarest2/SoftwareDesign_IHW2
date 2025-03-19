using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class OperationService
{
    private static int _opNum;
    
    public void CreateOperation(string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
    {
        var operation = new Operation
        {
            Id = _opNum, 
            Type = type,
            BankAccountId = bankAccountId,
            Amount = amount,
            Date = date,
            Description = description,
            CategoryId = categoryId
        };

        _opNum++;
        Console.WriteLine($"Created operation: {operation.Type} of {operation.Amount} on {operation.Date}");
    }
}