using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class CommentDao : DetailedDao<Comment>, ICommentDao
{
    private readonly DatabaseContext _context;
    public CommentDao(DatabaseContext context) : base(context) => _context = context;

    public List<Comment> GetByLifeHackId(string lifeHackId) => _context.Comments
        .Where(comment => comment.LifeHackId.ToString() == lifeHackId).ToListAsync().Result;
}