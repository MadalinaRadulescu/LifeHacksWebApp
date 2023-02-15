using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class UserDataDao : IUserDataDao
{
    private readonly DatabaseContext _context;
    
    public UserDataDao(DatabaseContext context) => _context = context;

    public async Task Add(UserData element)
    {
        await _context.UsersData.AddAsync(element);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.UsersData.Remove(Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Update(UserData element)
    {
        _context.UsersData.Update(element);
        await _context.SaveChangesAsync();
    }

    public UserData Get(int id) => _context.UsersData
        .FirstOrDefaultAsync(userData => userData!.Id == id).Result!;

    public List<UserData> GetAll() => _context.UsersData
        .ToListAsync().Result!;

    public List<UserData> GetByUserId(string userId) => _context.UsersData
        .Where(userData => userData!.UserId == userId).ToList()!;
    
    public async Task IncreasePoints(string id)
    {
        var user = GetByUserId(id);
        if (user.Count == 0) return; 
        user[0].Points++;
        await _context.SaveChangesAsync();
    }

    public async Task DecreasePoints(string id)
    {
        var user = GetByUserId(id);
        if (user.Count == 0) return; 
        user[0].Points--;
        await _context.SaveChangesAsync();
    }
}