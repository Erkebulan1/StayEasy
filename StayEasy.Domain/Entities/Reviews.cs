namespace StayEasy.Domain.Entities;

public class Reviews:BaseEntity
{
    public int PropertyId { get; set; }
    public int UserId { get; set; }
    public int BookingId { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public string? Response { get; set; }
    
    public Propertys? Property { get; set; }
    public User? User { get; set; }
    public Booking Booking { get; set; }
}