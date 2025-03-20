using System;
using HSE_Bank.Domain.Factories;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class DomainFactoryTests
{
    [Test]
    public void CreateOperation_WithNegativeAmount_ShouldThrowException()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            DomainFactory.CreateOperation("Expense", 1, -50, DateTime.Now, "Invalid operation", 1)
        );

        Assert.AreEqual("Amount cannot be negative", ex.Message);
    }

    [Test]
    public void CreateOperation_WithValidData_ShouldReturnOperation()
    {
        var operation = DomainFactory.CreateOperation("Expense", 1, 50, new DateTime(2023, 10, 1), "Grocery shopping", 1);

        Assert.IsNotNull(operation);
        Assert.AreEqual("Expense", operation.Type);
        Assert.AreEqual(50, operation.Amount);
    }
}