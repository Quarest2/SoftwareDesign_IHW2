namespace ZooManager.Domain.ValueObjects.AnimalValueObjects;

public class AnimalFavoriteFood
{
    public string FavoriteFood { get; }
    
    public AnimalFavoriteFood(string favoriteFood)
    {
        FavoriteFood = favoriteFood;
    }
}