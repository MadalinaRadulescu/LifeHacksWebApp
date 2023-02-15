using LifesaverHub.Data;
using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos.Implementations;

public class CategoryDao : Dao<Category>, ICategoryDao
{
    private readonly DatabaseContext _context;
    public CategoryDao(DatabaseContext context) : base(context) => _context = context;
}

