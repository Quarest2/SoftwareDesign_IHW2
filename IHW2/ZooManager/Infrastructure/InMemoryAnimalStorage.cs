using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;

namespace ZooManager.Infrastructure;

public class InMemoryAnimalStorage : IAnimalStorage
{
    public InMemoryAnimalStorage(Dictionary<Guid, Animal> animals)
    {
        Animals = animals;
    }

    public Dictionary<Guid, Animal> Animals { get; set; }
}