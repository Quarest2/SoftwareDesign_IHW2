using System;
using System.Linq;
using HSE_Bank.Domain.Services;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class OperationServiceTests
{
    private OperationService _service;

    [SetUp]
    public void SetUp()
    {
        _service = new OperationService();
    }

    [Test]
    public void CreateOperation_ShouldAddOperationToList()
    {
        _service.CreateOperation("Expense", 1, 50, new DateTime(2023, 10, 1), "Grocery shopping", 1, 1);

        var operations = _service.GetOperationsByUser(1);
        Assert.AreEqual(1, operations.Count);
        Assert.AreEqual("Expense", operations[0].Type);
        Assert.AreEqual(50, operations[0].Amount);
    }

    [Test]
    public void UpdateOperation_ShouldModifyExistingOperation()
    {
        _service.CreateOperation("Expense", 1, 50, new DateTime(2023, 10, 1), "Grocery shopping", 1, 1);

        _service.UpdateOperation(1, "Income", 100, new DateTime(2023, 10, 2), "Salary", 2);

        var operation = _service.GetOperationsByUser(1).First();
        Assert.AreEqual("Income", operation.Type);
        Assert.AreEqual(100, operation.Amount);
        Assert.AreEqual(new DateTime(2023, 10, 2), operation.Date);
        Assert.AreEqual("Salary", operation.Description);
        Assert.AreEqual(2, operation.CategoryId);
    }

    [Test]
    public void DeleteOperation_ShouldRemoveOperationFromList()
    {
        _service.CreateOperation("Expense", 1, 50, new DateTime(2023, 10, 1), "Grocery shopping", 1, 1);

        _service.DeleteOperation(1);

        var operations = _service.GetOperationsByUser(1);
        Assert.AreEqual(0, operations.Count);
    }
}