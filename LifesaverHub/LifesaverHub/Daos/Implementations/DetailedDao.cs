using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class DetailedDao<T> : Dao<T>, IDetailedDao<T> where T : DetailedBaseEntity
{
    private readonly DatabaseContext _context;

    public DetailedDao(DatabaseContext context) : base(context) => _context = context;

    public List<T> GetByUserId(string userId) => typeof(T) switch
    {
        var value when value == typeof(Comment) => (_context.Comments.Where(comment => comment.UserId == userId).ToListAsync().Result as List<T>)!,
        var value when value == typeof(LifeHack) =>(_context.LifeHacks.Where(lifeHack => lifeHack.UserId == userId).ToListAsync().Result as List<T>)!,
        var value when value == typeof(UserData) => (_context.UsersData.Where(userData => userData.UserId == userId).ToListAsync().Result as List<T>)!,
        _ => new List<T>()
    };

    public async Task IncreasePoints(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
        
        var dao = new Dao<T>(_context);
        var elem = dao.Get(id);

        if (elem == null) throw new ArgumentException($"Element with ID {id} does not exist.");
        
        elem.Points++;
        await _context.SaveChangesAsync();
    }

    public async Task DecreasePoints(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

        var dao = new Dao<T>(_context);
        var elem = dao.Get(id);

        if (elem == null) throw new ArgumentException($"Element with ID {id} does not exist.");
        
        elem.Points--;
        await _context.SaveChangesAsync();
    }
}