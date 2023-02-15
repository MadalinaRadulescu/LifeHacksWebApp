using LifesaverHub.Daos;
using LifesaverHub.Daos.Implementations;
using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;

[ApiController, Route("/lifeHack/")]
public class LifeHackController : Controller
{
    private readonly ILifeHackDao _lifeHack;
    public LifeHackController(DatabaseContext db)
    {
        _lifeHack = new LifeHackDao(db);
    }

    [HttpGet("all")]
    public List<LifeHack> GetLifeHacks() => _lifeHack.GetAll();

    [HttpGet("{id}")]
    public LifeHack GetLifeHack(string id) => _lifeHack.Get(id);

    [HttpPost("add")]
    public async Task AddLifeHack([FromBody] LifeHack lifeHack) => await _lifeHack.Add(lifeHack);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveLifeHack(string id) => await _lifeHack.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateLifeHack([FromBody] LifeHack lifeHack) => await _lifeHack.Update(lifeHack);
    
    [HttpGet("user/{userId}")]
    public List<LifeHack> GetUserLifeHacks(string userId) => _lifeHack.GetByUserId(userId);
    
    [HttpGet("category/{categoryId}")]
    public List<LifeHack> GetLifeHacksOfCategory(int categoryId) => _lifeHack.GetByCategory(categoryId);
    
    [HttpGet("topRated")]
    public List<LifeHack> GetLifeHacksSortedByVote() => _lifeHack.GetAll().OrderByDescending(comment => comment.Points).ToList();
    
    [HttpGet("newest")]
    public List<LifeHack> GetLifeHacksSortedByDate() => _lifeHack.GetAll().OrderByDescending(comment => comment.RegisteredTime).ToList();

    [HttpPut("upVote/{id}")] 
    public async Task IncrementLifeHackPoints(string id)
    {
        await _lifeHack.IncreasePoints(id);
        await _lifeHack.IncreasePoints(_lifeHack.Get(id).UserId);
    }
    
    [HttpPut("downVote/{id}")] 
    public async Task DecrementLifeHackPoints(string id)
    {
        await _lifeHack.DecreasePoints(id);
        await _lifeHack.DecreasePoints(_lifeHack.Get(id).UserId);
    }
}