using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class 
CategoryDao : ICategoryDao
{
    private readonly DatabaseContext _context;

    public CategoryDao(DatabaseContext context) => _context = context;

    public async Task Add(Category element)
    {
        await _context.Categories.AddAsync(element);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.Categories.Remove(Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Update(Category element)
    {
        _context.Categories.Update(element);
        await _context.SaveChangesAsync();
    }

    public Category Get(int id) => _context.Categories
        .FirstOrDefaultAsync(category => category.Id == id).Result!;

    public List<Category> GetAll() => _context.Categories
        .ToListAsync().Result;
}