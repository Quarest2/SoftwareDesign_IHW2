using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Application;

public class AnimalTransferService
{
    private readonly IAnimalStorage _animalStorage;
    private readonly IEnclosureStorage _enclosureStorage;

    public AnimalTransferService(IAnimalStorage animalStorage, IEnclosureStorage enclosureStorage)
    {
        _animalStorage = animalStorage;
        _enclosureStorage = enclosureStorage;
    }

    private void RemoveAnimalFromEnclosure(Guid animalId, Guid enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        var animal = _animalStorage.GetAnimalById(animalId);
        enclosure.DeleteAnimal(animal);
    }

    private void AddAnimalToEnclosure(Guid animalId, Guid enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        var animal = _animalStorage.GetAnimalById(animalId);
        enclosure.AddAnimal(animal);
    }
    
    public void RemoveAnimal(Guid animalId)
    {
        _animalStorage.Animals.Remove(animalId);
        foreach (var enclosure in _enclosureStorage.Enclosures)
        {
            RemoveAnimalFromEnclosure(animalId, enclosure.Key);
        }
    }

    public void TransferAnimal(Guid animalId, Guid sourceEnclosureId, Guid targetEnclosureId)
    {
        RemoveAnimalFromEnclosure(animalId, sourceEnclosureId);
        AddAnimalToEnclosure(animalId, targetEnclosureId);
    }

    public void AddEnclosure(Enclosure enclosure)
    {
        _enclosureStorage.Enclosures.TryAdd(enclosure.Id, enclosure);
    }

    public void RemoveEnclosure(Guid enclosureId)
    {
        var enclosure = _enclosureStorage.GetEnclosureById(enclosureId);
        _enclosureStorage.Enclosures.Remove(enclosureId);
        foreach (var animal in enclosure.Animals)
        {
            RemoveAnimalFromEnclosure(animal.Id, enclosureId);
        }
    }
}