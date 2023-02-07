using LifesaverHub.Models;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Data;

public class DatabaseContext : DbContext
{
    public const int MaxIngredientsForPotions = 5;

    public DbSet<LifeHack> LifeHacks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserData> UsersData { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}