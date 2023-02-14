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
    public CommentController(DatabaseContext db) => _comment = new CommentDao(db);

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
    
    [HttpGet("user/{id}")]
    public List<Comment> GetUserComments(string id) => _comment.GetByUserId(id);
}