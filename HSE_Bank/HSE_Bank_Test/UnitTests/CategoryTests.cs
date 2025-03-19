using HSE_Bank.Domain.Models;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class CategoryTests
{
    [Test]
    public void CreateCategory_ShouldSetTypeAndName()
    {
        var category = new Category { Id = 1, Type = "Expense", Name = "Groceries" };

        Assert.AreEqual("Expense", category.Type);
        Assert.AreEqual("Groceries", category.Name);
    }
}