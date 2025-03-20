using System.Linq;
using HSE_Bank.Domain.Services;

namespace HSE_Bank_Test.UnitTests;

[TestFixture]
public class CategoryServiceTests
{
    private CategoryService _service;

    [SetUp]
    public void SetUp()
    {
        _service = new CategoryService();
    }

    [Test]
    public void CreateCategory_ShouldAddCategoryToList()
    {
        _service.CreateCategory("Expense", "Groceries", 1);

        var categories = _service.GetCategoriesByUser(1);
        Assert.AreEqual(1, categories.Count);
        Assert.AreEqual("Groceries", categories[0].Name);
        Assert.AreEqual("Expense", categories[0].Type);
    }

    [Test]
    public void UpdateCategory_ShouldModifyExistingCategory()
    {
        _service.CreateCategory("Expense", "Groceries", 1);

        _service.UpdateCategory(1, "Income", "Salary");

        var category = _service.GetCategoriesByUser(1).First();
        Assert.AreEqual("Salary", category.Name);
        Assert.AreEqual("Income", category.Type);
    }

    [Test]
    public void DeleteCategory_ShouldRemoveCategoryFromList()
    {
        _service.CreateCategory("Expense", "Groceries", 1);

        _service.DeleteCategory(1);

        var categories = _service.GetCategoriesByUser(1);
        Assert.AreEqual(0, categories.Count);
    }
}