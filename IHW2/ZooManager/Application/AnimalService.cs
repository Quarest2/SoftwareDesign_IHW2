using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManager.Application;

public class AnimalService
{
    private readonly IAnimalStorage _animalStorage;

    public AnimalService(IAnimalStorage animalStorage)
    {
        _animalStorage = animalStorage;
    }
    
    public void AddAnimal(Animal animal)
    {
        _animalStorage.Animals.TryAdd(animal.Id, animal);
    }

    public Animal GetAnimal(Guid animalId)
    {
        return _animalStorage.GetAnimalById(animalId);
    }

    public Dictionary<Guid, Animal> GetAllAnimals()
    {
        return _animalStorage.GetAllAnimals();
    }
}