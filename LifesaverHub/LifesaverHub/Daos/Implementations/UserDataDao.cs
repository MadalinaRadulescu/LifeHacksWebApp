using LifesaverHub.Data;
using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos.Implementations;

public class UserDataDao : DetailedDao<UserData>, IUserDataDao
{
    private readonly DatabaseContext _context;
    public UserDataDao(DatabaseContext context) : base(context) => _context = context;

}