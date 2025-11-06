using StayEasy.DataAccess.Contexts;
using StayEasy.DataAccess.Repositories;
using StayEasy.DataAccess.Repository;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public IRepository<Booking> Bookings { get; } = new Repository<Booking>(context);
    public IRepository<User> Users { get; }= new Repository<User>(context);
    public IRepository<Favorites> Favorites { get; }= new Repository<Favorites>(context);
    public IRepository<Message> Messages { get; }= new Repository<Message>(context);
    public IRepository<Notifications> Notifications { get; }= new Repository<Notifications>(context);
    public IRepository<Payments> Payments { get; }= new Repository<Payments>(context);
    public IRepository<PropertyImageUrl> PropertyImageUrls { get; }= new Repository<PropertyImageUrl>(context);
    public IRepository<Propertys> Properties { get; }= new Repository<Propertys>(context);
    public IRepository<PropertyAmenities> PropertyAmenities { get; }= new Repository<PropertyAmenities>(context);
    public IRepository<Reviews> Reviews { get; }= new Repository<Reviews>(context);
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        context.Dispose();
        
    }
}