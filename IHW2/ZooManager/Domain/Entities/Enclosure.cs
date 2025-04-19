using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Domain.Entities;

public class Enclosure
{
    public Guid Id { get; }
    public EnclosureType Type { get; }
    public EnclosureSize Size { get; }
    public List<Animal> Animals { get; set; }
    public EnclosureAnimalsCount AnimalsCount { get; set; }
    public EnclosureCapacity Capacity { get; }
    public EnclosureCleaningTime LastCleaningTime { get; set; }
    
    public Enclosure(EnclosureType type, EnclosureSize size, EnclosureCapacity capacity)
    {
        Id = new Guid();
        Type = type;
        Size = size;
        Capacity = capacity;
        Animals = new List<Animal>();
        AnimalsCount = new EnclosureAnimalsCount(0);
        LastCleaningTime = new EnclosureCleaningTime(DateTime.Now);
    }
    
    public void AddAnimal(Animal animal) {}
    
    public void DeleteAnimal(Animal animal) {}
    
    public void CleanEnclosure()
    {
        LastCleaningTime = new EnclosureCleaningTime(DateTime.Now);
    }
}