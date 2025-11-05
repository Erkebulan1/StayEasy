using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorites>
{
    public void Configure(EntityTypeBuilder<Favorites> builder)
    {
        // Relationship: Favorite -> User (Many-to-One)
        builder.HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Relationship: Favorite -> Property (Many-to-One)
        builder.HasOne(f => f.Property)
            .WithMany(p => p.Favorites)
            .HasForeignKey(f => f.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Indexes
        builder.HasIndex(f => f.UserId);
        builder.HasIndex(f => f.PropertyId);
            
        // Composite Unique Index (1 user can save 1 property only once)
        builder.HasIndex(f => new { f.UserId, f.PropertyId }).IsUnique();
    }
}