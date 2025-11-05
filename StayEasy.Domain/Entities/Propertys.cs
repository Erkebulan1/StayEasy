using StayEasy.Domain.Enums;

namespace StayEasy.Domain.Entities;

public class Propertys:BaseEntity
{
    //BaseInfo
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    //Type and Category
    public PropertyType Type { get; set; }
    public PropertyCategory Category { get; set; }
    
    //Details
    public int Rooms { get; set; }
    public decimal Area { get; set; }
    public int Floor { get; set; }
    
    //Location
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    
    //Status
    public PropertyStatus Status { get; set; }
    
    //Navigation
    public User User { get; set; }  // Mulk egasi
    public ICollection<PropertyImageUrl> Images { get; set; }  // Rasmlar
    public ICollection<PropertyAmenities> Amenities { get; set; }  // Imkoniyatlar
    public ICollection<Booking> Bookings { get; set; }  // Bronlar
    public ICollection<Reviews> Reviews { get; set; }  // Izohlar
    public ICollection<Favorites> Favorites { get; set; }  // Kimlar saqlaganlar
    public ICollection<Message> Messages { get; set; }  // Bu uy haqida xabarlar
    
}