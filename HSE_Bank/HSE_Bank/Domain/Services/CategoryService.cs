using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class CategoryService
{
    private readonly List<Category> _categories = new();

    public void CreateCategory(string type, string name, int userId)
    {
        var category = new Category
        {
            Id = _categories.Count + 1,
            Type = type,
            Name = name,
            UserId = userId
        };
        _categories.Add(category);
        Console.WriteLine($"Created category: {category.Name} ({category.Type})");
    }

    public void UpdateCategory(int categoryId, string type, string name)
    {
        var category = _categories.FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            category.Type = type;
            category.Name = name;
            Console.WriteLine($"Updated category: {category.Name} ({category.Type})");
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public void DeleteCategory(int categoryId)
    {
        var category = _categories.FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            _categories.Remove(category);
            Console.WriteLine($"Deleted category: {category.Name}");
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public List<Category> GetCategoriesByUser(int userId)
    {
        return _categories.Where(c => c.UserId == userId).ToList();
    }
}