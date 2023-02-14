using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class LifeHackDao : ILifeHackDao
{
    private readonly DatabaseContext _context;
    
    public LifeHackDao(DatabaseContext context) => _context = context;

    public async Task Add(LifeHack element)
    {
        await _context.LifeHacks.AddAsync(element);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.LifeHacks.Remove(Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Update(LifeHack element)
    {
        _context.LifeHacks.Update(element);
        await _context.SaveChangesAsync();
    }

    public LifeHack Get(int id) => _context.LifeHacks
        .FirstOrDefaultAsync(lifeHack => lifeHack.Id == id).Result!;

    public List<LifeHack> GetAll() => _context.LifeHacks
        .ToListAsync().Result;

    public List<LifeHack> GetByUserId(string userId) => _context.LifeHacks
        .Where(lifeHack => lifeHack.UserId == userId).ToList();
}