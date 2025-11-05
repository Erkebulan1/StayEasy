namespace StayEasy.Domain.Entities;

public class Favorites:BaseEntity
{
    public int UserId{get;set;}
    public int PropertyId{get;set;}
    
    public User? User{get;set;}
    public Propertys? Property{get;set;}
}