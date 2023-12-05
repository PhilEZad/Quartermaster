using Domain;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _config;
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Setting Primary Keys
        modelBuilder.Entity<User>()
            .HasKey(x => x.Id)
            .HasName("PK_User");

        modelBuilder.Entity<Faction>()
            .HasKey(x => x.Id)
            .HasName("PK_Faction");
        
        modelBuilder.Entity<Unit>()
            .HasKey(x => x.Id)
            .HasName("PK_Unit");
        
        modelBuilder.Entity<User>()
            .Property(x => x.DateCreated)
            .HasColumnType("datetime2");


    }

    public DbSet<Unit> Units { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Faction> Factions { get; set; }
}