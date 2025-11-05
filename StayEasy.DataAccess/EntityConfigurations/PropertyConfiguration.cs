using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.EntityConfigurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Propertys>
    {
        public void Configure(EntityTypeBuilder<Propertys> builder)
        {
            // Title
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);
            
            // Description
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(5000);
            
            // Price
            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);
            
            // Type
            builder.Property(p => p.Type)
                .IsRequired();
            
            // Category
            builder.Property(p => p.Category)
                .IsRequired();
            
            // Rooms
            builder.Property(p => p.Rooms)
                .IsRequired();
            
            // Area
            builder.Property(p => p.Area)
                .IsRequired()
                .HasPrecision(10, 2);
            
            // Floor (Optional)
            builder.Property(p => p.Floor);
            
            // Address
            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(500);
            
            // City
            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(100);
            
            // District
            builder.Property(p => p.District)
                .IsRequired()
                .HasMaxLength(100);
            
            // Status
            builder.Property(p => p.Status)
                .IsRequired();
            
            // Relationship: Propertys -> User (Many-to-One)
            builder.HasOne(p => p.User)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Indexes
            builder.HasIndex(p => p.UserId);
            builder.HasIndex(p => p.Type);
            builder.HasIndex(p => p.Category);
            builder.HasIndex(p => p.Status);
            builder.HasIndex(p => p.City);
            builder.HasIndex(p => p.District);
            builder.HasIndex(p => p.Price);
            builder.HasIndex(p => p.CreatedAt);
        }
    }