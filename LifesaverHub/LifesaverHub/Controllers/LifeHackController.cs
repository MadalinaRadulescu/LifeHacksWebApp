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
    public LifeHackController(DatabaseContext db) => _lifeHack = new LifeHackDao(db);

    [HttpGet("all")]
    public List<LifeHack> GetLifeHacks() => _lifeHack.GetAll();

    [HttpGet("{id}")]
    public LifeHack GetLifeHack(int id) => _lifeHack.Get(id);

    [HttpPost("add")]
    public async Task AddLifeHack([FromBody] LifeHack lifeHack) => await _lifeHack.Add(lifeHack);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveLifeHack(int id) => await _lifeHack.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateLifeHack([FromBody] LifeHack lifeHack) => await _lifeHack.Update(lifeHack);
    
    [HttpGet("user/{id}")]
    public List<LifeHack> GetUserLifeHacks(int id) => _lifeHack.GetByUserId(id);
}