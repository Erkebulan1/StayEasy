using StayEasy.Domain.Enums;

namespace StayEasy.Domain.Entities;

public class User:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRole  Role { get; set; }
    public bool IsEmailConfirmed  { get; set; }
    public string? ProfileImageUrl { get; set; }
    
    //Navigation
    public ICollection<Propertys> Properties { get; set; }  // User's properties
    public ICollection<Booking> Bookings { get; set; }  // User's bookings
    public ICollection<Reviews> Reviews { get; set; }  // User's reviews
    public ICollection<Favorites> Favorites { get; set; }  // Saved properties
    public ICollection<Message> SentMessages { get; set; }  // Sent messages
    public ICollection<Message> ReceivedMessages { get; set; }  // Received messages
    public ICollection<Notifications> Notifications { get; set; }  // User notifications
    public ICollection<Payments> Payments { get; set; }  // User payments

}