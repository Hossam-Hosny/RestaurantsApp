using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Contexts;

internal class AppDbContext(DbContextOptions<AppDbContext> options):IdentityDbContext<User>(options)
{
    public DbSet<Domain.Entities.Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Domain.Entities.Restaurant>()
            .HasMany(d => d.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}
