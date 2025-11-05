using StayEasy.Domain.Enums;

namespace StayEasy.Domain.Entities;

public class Notifications:BaseEntity
{
    public int UserId { get; set; }
    public NotificationType  Type { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Content { get; set; }=string.Empty;
    public bool IsRead { get; set; }
    
    public int? ReleatedEntityId { get; set; }
    
    public User User { get; set; }=null!;
    
}