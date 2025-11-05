namespace StayEasy.Domain.Entities;

public class Message:BaseEntity 
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public int? PropertyId { get; set; }
    public string Content { get; set; }=string.Empty;
    public bool IsRead { get; set; }
    
    public User Sender { get; set; }=null!;
    public User Receiver { get; set; }=null!;
    public Propertys?  Property { get; set; }
}