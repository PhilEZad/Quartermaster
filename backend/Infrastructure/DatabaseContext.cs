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

        modelBuilder.Entity<Role>()
            .HasKey(x => x.Id)
            .HasName("PK_UserType");
        
        modelBuilder.Entity<Faction>()
            .HasKey(x => x.Id)
            .HasName("PK_Faction");
        
        modelBuilder.Entity<Unit>()
            .HasKey(x => x.Id)
            .HasName("PK_Unit");
        
        modelBuilder.Entity<Weapon>()
            .HasKey(x => x.Id)
            .HasName("PK_Weapon");
        
        modelBuilder.Entity<Ability>()
            .HasKey(x => x.Id)
            .HasName("PK_Ability");
        
        // Setting Foreign Keys
        
        /*
         * Setting Relationships
         */
        
        // Many-to-Many
        modelBuilder.Entity<Role>()
            .HasMany(x => x.Users)
            .WithMany(x => x.Roles)
            .UsingEntity("RolesToUsersJoinTable");
        
        modelBuilder.Entity<Weapon>()
            .HasMany(x => x.Abilities)
            .WithMany(x => x.Weapons)
            .UsingEntity("AbilitiesToWeaponsJoinTable");
        
        modelBuilder.Entity<Unit>()
            .HasMany( x => x.Abilities)
            .WithMany(x => x.Units)
            .UsingEntity("AbilitiesToUnitsJoinTable");

        // Setting Indexes
        
        // Setting Constraints
        
        // Setting Data Types
        modelBuilder.Entity<User>()
            .Property(x => x.DateCreated)
            .HasColumnType("datetime2");
    }

    public DbSet<Role> RolesTable { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Wargear> Wargear { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Faction> Factions { get; set; }
}