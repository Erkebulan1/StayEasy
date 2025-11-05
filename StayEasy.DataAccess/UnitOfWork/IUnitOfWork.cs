using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StayEasy.DataAccess.Repository;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    IRepository<Booking> Bookings { get; }
    IRepository<User> Users { get; }
    IRepository<Favorites>  Favorites { get; }
    IRepository<Message> Messages { get; }
    IRepository<Notifications>  Notifications { get; }
    IRepository<Payments>  Payments { get; }
    IRepository<PropertyImageUrl> PropertyImageUrls { get; }
    IRepository<Propertys> Properties { get; }
    IRepository<PropertyAmenities> PropertyAmenities { get; }
    IRepository<Reviews>  Reviews { get; }
    
    Task SaveAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackTransactionAsync();
}

