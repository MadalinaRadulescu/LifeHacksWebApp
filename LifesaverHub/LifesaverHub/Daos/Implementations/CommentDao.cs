using LifesaverHub.Data;
using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos.Implementations;

public class CommentDao : DetailedDao<Comment>, ICommentDao
{
    private readonly DatabaseContext _context;
    public CommentDao(DatabaseContext context) : base(context) => _context = context;
}