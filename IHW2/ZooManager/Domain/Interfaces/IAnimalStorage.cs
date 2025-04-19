using ZooManager.Domain.Entities;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManager.Domain.Interfaces;

public interface IAnimalStorage
{
    public Dictionary<Guid, Animal> Animals { get; set; }

    public Animal GetAnimalById(Guid id)
    {
        return Animals[id];
    }
    
    public Dictionary<Guid, Animal> GetAllAnimals()
    {
        return Animals;
    }
}