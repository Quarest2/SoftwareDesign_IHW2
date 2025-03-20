using System;
using HSE_Bank.Domain.Models;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class OperationTests
{
    [Test]
    public void Operation_ShouldInitializePropertiesCorrectly()
    {
        var operation = new Operation
        {
            Id = 1,
            Type = "Expense",
            BankAccountId = 1,
            Amount = 50,
            Date = new DateTime(2023, 10, 1),
            Description = "Grocery shopping",
            CategoryId = 1,
            UserId = 1
        };

        Assert.AreEqual(1, operation.Id);
        Assert.AreEqual("Expense", operation.Type);
        Assert.AreEqual(1, operation.BankAccountId);
        Assert.AreEqual(50, operation.Amount);
        Assert.AreEqual(new DateTime(2023, 10, 1), operation.Date);
        Assert.AreEqual("Grocery shopping", operation.Description);
        Assert.AreEqual(1, operation.CategoryId);
        Assert.AreEqual(1, operation.UserId);
    }
}