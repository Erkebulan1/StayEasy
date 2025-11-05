using StayEasy.Domain.Enums;

namespace StayEasy.Domain.Entities;

public class Payments:BaseEntity
{
    public int UserId {get; set;}
    public int BookingId {get; set;}
    public decimal Amount {get; set;}
    public string Currency { get; set; } = "Usd";
    public string PaymentMethod { get; set; } = string.Empty;
    public PaymentStatus PaymentStatus {get; set;}
    public int? TransactionId {get; set;}
    
    public User User {get; set;} = null!;
    public Booking Booking {get; set;} 
}