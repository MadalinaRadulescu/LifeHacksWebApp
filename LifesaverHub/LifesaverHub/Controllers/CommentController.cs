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
    public Comment GetComment(string id) => _comment.Get(id);

    [HttpPost("add")]
    public async Task AddComment([FromBody] Comment comment) => await _comment.Add(comment);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveComment(string id) => await _comment.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateComment([FromBody] Comment comment) => await _comment.Update(comment);
    
    [HttpGet("user/{userId}")]
    public List<Comment> GetUserComments(string userId) => _comment.GetByUserId(userId);
    
    [HttpGet("lifeHack/{lifeHackId}")]
    public List<Comment> GetLifeHackComments(string lifeHackId) => _comment.GetByLifeHackId(lifeHackId);
    
    [HttpGet("topRated")]
    public List<Comment> GetCommentsSortedByVote() => _comment.GetAll().OrderByDescending(comment => comment.Points).ToList();
    
    [HttpGet("newest")]
    public List<Comment> GetCommentsSortedByDate() => _comment.GetAll().OrderByDescending(comment => comment.RegisteredTime).ToList();

    [HttpPut("upVote/{id}")] 
    public async Task IncrementCommentPoints(string id) 
    {
        await _comment.IncreasePoints(id);
        await _userData.IncreasePoints(_comment.Get(id).UserId);
    }
    
    [HttpPut("downVote/{id}")] 
    public async Task DecrementCommentPoints(string id)
    {
        await _comment.DecreasePoints(id);
        await _userData.DecreasePoints(_comment.Get(id).UserId);
    }
}