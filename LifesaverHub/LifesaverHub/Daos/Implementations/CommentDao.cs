using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifesaverHub.Daos.Implementations;

public class CommentDao : ICommentDao
{
    private readonly DatabaseContext _context;
    
    public CommentDao(DatabaseContext context) => _context = context;

    public async Task Add(Comment element)
    {
        await _context.Comments.AddAsync(element);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.Comments.Remove(Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Update(Comment element)
    {
        _context.Comments.Update(element);
        await _context.SaveChangesAsync();
    }

    public Comment Get(int id) => _context.Comments
        .FirstOrDefaultAsync(comment => comment.Id == id).Result!;

    public List<Comment> GetAll() => _context.Comments
        .ToListAsync().Result;

    public List<Comment> GetByUserId(int userId) => _context.Comments
        .Where(comment => comment.UserId == userId).ToList();
}