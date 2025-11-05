namespace StayEasy.Domain.Entities;

public class PropertyImageUrl:BaseEntity
{
    public int PropertyId { get; set; }
    public string ImageUrl { get; set; }
    public bool IsMain { get; set; }
    public int Order { get; set; }
    
    public Propertys Propertys { get; set; }
    
}