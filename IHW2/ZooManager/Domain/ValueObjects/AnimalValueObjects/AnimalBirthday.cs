namespace ZooManager.Domain.ValueObjects.AnimalValueObjects;

public class AnimalBirthday
{
    public DateOnly Birthday { get; }
    
    public AnimalBirthday(DateOnly birthday)
    {
        Birthday = birthday;
    }
}