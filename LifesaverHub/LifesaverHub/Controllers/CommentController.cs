using LifesaverHub.Daos;
using LifesaverHub.Daos.Implementations;
using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;

[ApiController, Route("/comment/")]
public class CommentController : Controller
{
    private readonly ICommentDao _comment;
    private readonly IUserDataDao _userData;
    public CommentController(DatabaseContext db)
    {
        _userData = new UserDataDao(db);
        _comment = new CommentDao(db);
    }

    [HttpGet("all")]
    public List<Comment> GetComments() => _comment.GetAll();

    [HttpGet("{id}")]
    public Comment GetComment(int id) => _comment.Get(id);

    [HttpPost("add")]
    public async Task AddComment([FromBody] Comment comment) => await _comment.Add(comment);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveComment(int id) => await _comment.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateComment([FromBody] Comment comment) => await _comment.Update(comment);
    
    [HttpGet("user/{userId}")]
    public List<Comment> GetUserComments(int userId) => _comment.GetByUserId(userId);
    
    [HttpGet("topRated")]
    public List<Comment> GetCommentsSortedByVote() => _comment.GetAll().OrderByDescending(comment => comment.Points).ToList();
    
    [HttpGet("newest")]
    public List<Comment> GetCommentsSortedByDate() => _comment.GetAll().OrderByDescending(comment => comment.RegistredTime).ToList();

    [HttpPut("upVote/{id}")] 
    public async Task IncrementCommentPoints(int id) 
    {
        await _comment.IncreasePoints(id);
        await _userData.IncreasePoints(_comment.Get(id).UserId);
    }
    
    [HttpPut("downVote/{id}")] 
    public async Task DecrementCommentPoints(int id)
    {
        await _comment.DecreasePoints(id);
        await _userData.DecreasePoints(_comment.Get(id).UserId);
    }
}