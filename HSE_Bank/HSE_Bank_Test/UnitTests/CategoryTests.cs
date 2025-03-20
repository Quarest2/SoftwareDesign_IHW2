using HSE_Bank.Domain.Models;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class CategoryTests
{
    [Test]
    public void Category_ShouldInitializePropertiesCorrectly()
    {
        var category = new Category
        {
            Id = 1,
            Type = "Expense",
            Name = "Groceries",
            UserId = 1
        };

        Assert.AreEqual(1, category.Id);
        Assert.AreEqual("Expense", category.Type);
        Assert.AreEqual("Groceries", category.Name);
        Assert.AreEqual(1, category.UserId);
    }
}