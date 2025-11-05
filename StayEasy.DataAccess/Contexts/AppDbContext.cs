using Microsoft.EntityFrameworkCore;
using StayEasy.DataAccess.Extensions;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyGlobalConfigurations();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        var entityAssembly = typeof(Booking).Assembly;
        var entityTypes = entityAssembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(BaseEntity).IsAssignableFrom(t));
        foreach (var type in entityTypes)
            modelBuilder.Entity(type);
    }
}