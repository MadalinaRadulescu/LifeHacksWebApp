using LifesaverHub.Models.Entities;

namespace LifesaverHub.Data;

public static class DbInitializer
{   
    public static void Initialize(DatabaseContext context)
    {
        context.Database.EnsureCreated();
            
        if (context.LifeHacks.Any())
        {
            return;
        }

        var lifeHacks = new LifeHack[]
        {
            new LifeHack
            {
                Title = "How to remove the steam from the strawberries?",
                Description = "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.",
                PhotoName = "strawberries and the straw",
                VoteCount = 27
            },
            new LifeHack
            {
                Title = "How to properly close a bag of chips?",
                Description = "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.",
                PhotoName = "chips and hanger"
            },
            new LifeHack
            {
                Title = "Fastest way to catch the hair in the tail",
                Description = "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.",
                Link = "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif",
                VoteCount = -43
            }
        };

        var comments = new Comment[]
        {
            new Comment
            {
                
            }
        };

        var categories = new Category[]
        {
            new Category()
            {
                
            }
        };

        var usersData = new UserData[]
        {
            new UserData
            {
                
            }
        };
        
        context.SaveChanges();
    }
}