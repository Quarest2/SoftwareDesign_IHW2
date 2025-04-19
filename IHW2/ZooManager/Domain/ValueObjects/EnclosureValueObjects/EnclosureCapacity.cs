namespace ZooManager.Domain.ValueObjects.EnclosureValueObjects;

public class EnclosureCapacity
{
    public int Capacity { get; }
    
    public EnclosureCapacity(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }
        
        Capacity = capacity;
    }
}