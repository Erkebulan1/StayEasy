using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StayEasy.DataAccess.Extensions;
using StayEasy.Domain.Entities;

namespace StayEasy.DataAccess.Contexts
{
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
}



namespace StayEasy.DataAccess.Contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
           
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "../StayEasy.MobileApi");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgresSQLConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

