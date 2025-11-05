namespace StayEasy.Domain.Entities;

public class PropertyAmenities: BaseEntity
{
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public Propertys Propertys { get; set; }
}