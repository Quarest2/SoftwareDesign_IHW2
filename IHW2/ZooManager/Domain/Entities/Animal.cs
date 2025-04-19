using ZooManager.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManager.Domain.Entities;

public class Animal
{
    public Guid Id { get; }
    public AnimalType Type { get; }
    public AnimalName Name { get; }
    public AnimalBirthday Birthday { get; }
    public AnimalGender Gender { get; }
    public AnimalFavoriteFood FavoriteFood { get; }
    public AnimalHealth Health { get; }

    public Animal(AnimalType type, AnimalName name, AnimalBirthday birthday, AnimalGender gender,
        AnimalFavoriteFood favoriteFood, AnimalHealth health)
    {
        Id = new Guid();
        Type = type;
        Name = name;
        Birthday = birthday;
        Gender = gender;
        FavoriteFood = favoriteFood;
        Health = health;
    }

    public void Feed() {}
    
    public void Heal() {}

    public void ChangeEnclosure(Enclosure newEnclosure) {}
}