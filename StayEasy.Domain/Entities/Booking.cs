using StayEasy.Domain.Enums;

namespace StayEasy.Domain.Entities;

public class Booking:BaseEntity
{
    public int PropertyId { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus  Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Message { get; set; }
    
    public Propertys? Property { get; set; }
    public User? User { get; set; }
    public Reviews? Reviews { get; set; }
    public required ICollection<Payments>Payments { get; set; } 
    

}