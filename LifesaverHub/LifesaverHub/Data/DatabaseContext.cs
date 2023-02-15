using LifesaverHub.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Data;

public class DatabaseContext : IdentityDbContext
{
    public DbSet<LifeHack> LifeHacks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserData> UsersData { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Comment>().Property(p => p.RegistredTime)
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<LifeHack>().Property(p => p.RegistredTime)
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<UserData>().Property(p => p.RegistredTime)
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<Category>().Property(p => p.RegistredTime)
            .HasDefaultValueSql("NOW()");

        var lifeHacks = new[]
        {
            new LifeHack
            {
                Id = 1,
                Title = "How to remove the steam from the strawberries?",
                Description =
                    "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.",
                PhotoName = "strawberries and the straw",
                Points = 27,
                UserId = "0"
            },
            new LifeHack
            {
                Id = 2,
                Title = "How to properly close a bag of chips?",
                Description =
                    "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.",
                PhotoName = "chips and hanger",
                UserId = "0"
            },
            new LifeHack
            {
                Id = 3,
                Title = "Pasta Lighter",
                Description =
                    "We’re sure you’re stocking up on sweet smelling candles to make your home extra cozy for the colder months. But, if your candles are burning too low to reach the wick, there’s no reason to go without your favorite scent. Instead of burning your fingers, light a piece of uncooked spaghetti. It’ll reach into those deep candles and burn long enough to light the candles on grandpa’s birthday cake!",
                UserId = "0",
                Points = 12
            },
            new LifeHack
            {
                Id = 4,
                Title = "Fastest way to catch the hair in the tail",
                Description =
                    "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.",
                Link = "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif",
                Points = -43,
                UserId = "1"
            },
            new LifeHack
            {
                Id = 5,
                Title = "Useful tip for baking cupcakes",
                Description =
                    "Sprinkle dried rice under your cupcake cases before baking. The rice absorbs any grease throughout baking meaning you get lovely dry cupcake bases and no greasy patches on your cases!",
                PhotoName = "cupcakes and rice",
                Points = 25,
                UserId = "1"
            }
        };

        var comments = new[]
        {
            new Comment
            {
                Id = 1,
                Text = "That actually save my cookies!",
                UserId = "0",
                LifeHackId = 4
            },
            new Comment
            {
                Id = 2,
                Text = "Why should i want to do that???",
                UserId = "0",
                LifeHackId = 3,
                Points = 5
            },
            new Comment
            {
                Id = 3,
                Text = "Boring",
                UserId = "1",
                LifeHackId = 0,
                Points = -5
            }
        };

        var categories = new[]
        {
            new Category
            {
                Id = 1,
                Name = "Food"
            },
            new Category
            {
                Id = 2,
                Name = "Home"
            },
            new Category
            {
                Id = 3,
                Name = "Tech"
            },
            new Category
            {
                Id = 4,
                Name = "Funny"
            }
        };

        lifeHacks[0].categoriesId.Add(1);
        lifeHacks[1].categoriesId.Add(1);
        lifeHacks[2].categoriesId.Add(2);
        lifeHacks[3].categoriesId.Add(4);
        lifeHacks[4].categoriesId.Add(1);

        modelBuilder.Entity<UserData>().HasData(new UserData
        {
            Id = 1,
            UserId = "0",
            CardHolder = "john doe",
            CardNumber = "1234567890123456",
            ExpiryMonth = 10,
            ExpiryYear = 25,
            Cvv = "123",
            AddressLine1 = "123 Maple Street",
            PhoneNumber = "5555555555",
            City = "Columbus",
            Country = "Ohio",
            ZipCode = "1234"
        });

        lifeHacks.ToList().ForEach(lifeHack => modelBuilder.Entity<LifeHack>().HasData(lifeHack));
        comments.ToList().ForEach(comment => modelBuilder.Entity<Comment>().HasData(comment));
        categories.ToList().ForEach(category => modelBuilder.Entity<Category>().HasData(category));
    }
}