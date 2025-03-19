using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class CategoryService
{
    private static int _catNum;
    
    public void CreateCategory(string type, string name)
    {
        var category = new Category
        {
            Id = _catNum, 
            Type = type,
            Name = name
        };

        _catNum++;
        Console.WriteLine($"Created category: {category.Name} ({category.Type})");
    }
}