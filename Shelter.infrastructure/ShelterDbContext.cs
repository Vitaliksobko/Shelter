using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Shelter.Core.Models;

namespace Shelter.infrastructure;

public class ShelterDbContext : IdentityDbContext<User, Role, Guid>
{
    
    public DbSet<Animal> Animals { get; set; }
    
    public DbSet<Booking> Bookings { get; set; }
    
    public DbSet<News> News { get; set; }
    
    public DbSet<Question> Questions { get; set; }
    
    public ShelterDbContext(DbContextOptions<ShelterDbContext> options) : base(options)
    {
        
    }
    
   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Role>()
            .HasData(
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                           NormalizedName = "USER"
                       },
                       new Role()
                       {
                           Id = Guid.NewGuid(),
                           Name = "Admin",
                           NormalizedName = "ADMIN"
                       });
              
               
        modelBuilder.Entity<Booking>()
            .Property(b => b.StartTime)
            .HasColumnType("timestamp without time zone"); // Змінили на 'timestamp without time zone'

        modelBuilder.Entity<Booking>()
            .Property(b => b.EndTime)
            .HasColumnType("timestamp without time zone"); // Змінили на 'timestamp without time zone'
    
    }
}