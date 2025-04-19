namespace ZooManager.Domain.ValueObjects.AnimalValueObjects;

public class AnimalType
{
    public string Type { get; }
    
    public AnimalType(string type)
    {
        Type = type;
    }
}