using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class Dao<T> : IDao<T> where T : BaseEntity
{
    private readonly DatabaseContext _context;
    public Dao(DatabaseContext context) => _context = context;

    public async Task<int> Add(T element)
    {
        Console.WriteLine(element);
        switch (element)
        {
            case Category category:
                await _context.Categories.AddAsync(category);
                break;
            case Comment comment:
                await _context.Comments.AddAsync(comment);
                break;
            case LifeHack lifeHack:
                await _context.LifeHacks.AddAsync(lifeHack);
                break;
            case UserData userData:
                await _context.UsersData.AddAsync(userData);
                break;
            default:
                throw new NotSupportedException($"Type '{typeof(T)}' is not supported for Add operation.");
        }

        await _context.SaveChangesAsync();

        return element.Id;
    }

    public async Task Remove(string id)
    {
        switch (this)
        {
            case Category:
                _context.Categories.Remove((Get(id) as Category)!);
                break;
            case Comment:
                _context.Comments.Remove((Get(id) as Comment)!);
                break;
            case LifeHack:
                _context.LifeHacks.Remove((Get(id) as LifeHack)!);
                break;
            case UserData:
                _context.UsersData.Remove((Get(id) as UserData)!);
                break;
            default:
                throw new NotSupportedException($"Type '{typeof(T)}' is not supported for Remove operation.");
        }

        await _context.SaveChangesAsync();
    }

    public async Task Update(T element)
    {
        switch (element)
        {
            case Category category:
                _context.Categories.Update(category);
                break;
            case Comment comment:
                _context.Comments.Update(comment);
                break;
            case LifeHack lifeHack:
                _context.LifeHacks.Update(lifeHack);
                break;
            case UserData userData:
                _context.UsersData.Update(userData);
                break;
            default:
                throw new NotSupportedException($"Type '{typeof(T)}' is not supported for Update operation.");
        }

        await _context.SaveChangesAsync();
    }

    public T Get(string id) => typeof(T) switch
    {
        var value when value == typeof(Category) => (_context.Categories
            .FirstOrDefaultAsync(category => category.Id.ToString() == id).Result as T)!,
        var value when value == typeof(Comment) => (_context.Comments.FirstOrDefaultAsync(category => category.Id.ToString() == id)
            .Result as T)!,
        var value when value == typeof(LifeHack) => (_context.LifeHacks
            .FirstOrDefaultAsync(category => category.Id.ToString() == id).Result as T)!,
        var value when value == typeof(UserData) => (_context.UsersData
            .FirstOrDefaultAsync(category => category.Id.ToString() == id).Result as T)!,
        _ => throw new NotSupportedException($"Type '{typeof(T)}' is not supported for Get operation.")
    };

    public List<T> GetAll() => typeof(T) switch
    {
        var value when value == typeof(Category) => (_context.Categories.ToListAsync().Result as List<T>)!,
        var value when value == typeof(Comment) => (_context.Comments.ToListAsync().Result as List<T>)!,
        var value when value == typeof(LifeHack) => (_context.LifeHacks.ToListAsync().Result as List<T>)!,
        var value when value == typeof(UserData) => (_context.UsersData.ToListAsync().Result as List<T>)!,
        _ => new List<T>()
    };
}