namespace ZooManager.Domain.ValueObjects.EnclosureValueObjects;

public class EnclosureSize
{
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }
    
    public EnclosureSize(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}