using LifesaverHub.Data;
using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos.Implementations;

public class LifeHackDao : DetailedDao<LifeHack>, ILifeHackDao
{
    private readonly DatabaseContext _context;
    
    public LifeHackDao(DatabaseContext context) : base(context) => _context = context;

    public List<LifeHack> GetByCategory(int categoryId) =>
        _context.LifeHacks.Where(lifeHack => lifeHack.categoriesId.Contains(categoryId)).ToList();
}