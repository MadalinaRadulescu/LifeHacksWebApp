// using LifesaverHub.Models.Entities;
//
// namespace LifesaverHub.Data;
//
// public static class DbInitializer
// {
//     public static void Initialize(DatabaseContext context)
//     {
//         context.Database.EnsureCreated();
//
//         if (context.LifeHacks.Any())
//         {
//             return;
//         }
//
//         var lifeHacks = new[]
//         {
//             new LifeHack
//             {
//                 Title = "How to remove the steam from the strawberries?",
//                 Description =
//                     "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.",
//                 PhotoName = "strawberries and the straw",
//                 VoteCount = 27,
//                 userId = 0
//             },
//             new LifeHack
//             {
//                 Title = "How to properly close a bag of chips?",
//                 Description =
//                     "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.",
//                 PhotoName = "chips and hanger",
//                 userId = 0
//             },
//             new LifeHack
//             {
//                 Title = "Pasta Lighter",
//                 Description =
//                     "We’re sure you’re stocking up on sweet smelling candles to make your home extra cozy for the colder months. But, if your candles are burning too low to reach the wick, there’s no reason to go without your favorite scent. Instead of burning your fingers, light a piece of uncooked spaghetti. It’ll reach into those deep candles and burn long enough to light the candles on grandpa’s birthday cake!",
//                 userId = 0,
//                 VoteCount = 12
//             },
//             new LifeHack
//             {
//                 Title = "Fastest way to catch the hair in the tail",
//                 Description =
//                     "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.",
//                 Link = "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif",
//                 VoteCount = -43,
//                 userId = 1
//             },
//             new LifeHack
//             {
//                 Title = "Useful tip for baking cupcakes",
//                 Description =
//                     "Sprinkle dried rice under your cupcake cases before baking. The rice absorbs any grease throughout baking meaning you get lovely dry cupcake bases and no greasy patches on your cases!",
//                 PhotoName = "cupcakes and rice",
//                 VoteCount = 25,
//                 userId = 1
//             }
//         };
//
//         var comments = new[]
//         {
//             new Comment
//             {
//                 Text = "That actually save my cookies!",
//                 UserId = 0,
//                 LifeHackId = 4
//             },
//             new Comment
//             {
//                 Text = "Why should i want to do that???",
//                 UserId = 0,
//                 LifeHackId = 3,
//                 VoteCount = 5
//             },
//             new Comment
//             {
//                 Text = "Boring",
//                 UserId = 1,
//                 LifeHackId = 0,
//                 VoteCount = -5
//             }
//         };
//
//         var categories = new[]
//         {
//             new Category
//             {
//                 Name = "Food"
//             },
//             new Category
//             {
//                 Name = "Home"
//             },
//             new Category
//             {
//                 Name = "Tech"
//             },
//             new Category
//             {
//                 Name = "Funny"
//             }
//         };
//         
//         lifeHacks[0].categoriesId.Add(0);
//         lifeHacks[1].categoriesId.Add(0);
//         lifeHacks[2].categoriesId.Add(1);
//         lifeHacks[3].categoriesId.Add(3);
//         lifeHacks[4].categoriesId.Add(0);
//
//         context.UsersData.Add(new UserData
//         {
//             UserId = 0,
//             CardHolder = "john doe",
//             CardNumber = "1234567890123456",
//             ExpiryMonth = 10,
//             ExpiryYear = 25,
//             Cvv = "123",
//             AddressLine1 = "123 Maple Street",
//             PhoneNumber = "5555555555",
//             City = "Columbus",
//             Country = "Ohio",
//             ZipCode = "1234"
//         });
//         
//         lifeHacks.ToList().ForEach(lifeHack => context.LifeHacks.Add(lifeHack));
//         comments.ToList().ForEach(comment => context.Comments.Add(comment));
//         categories.ToList().ForEach(category => context.Categories.Add(category));
//         
//         context.SaveChanges();
//     }
// }