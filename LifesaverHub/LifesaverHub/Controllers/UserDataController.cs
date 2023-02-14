using LifesaverHub.Daos;
using LifesaverHub.Daos.Implementations;
using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;

[ApiController, Route("/userData/")]
public class UserDataController : Controller
{
    private readonly IUserDataDao _userData;
    public UserDataController(DatabaseContext db) => _userData = new UserDataDao(db);

    [HttpGet("all")]
    public List<UserData> GetUsersData() => _userData.GetAll();

    [HttpGet("{id}")]
    public UserData GetUserDataByDefaultId(int id) => _userData.Get(id);

    [HttpPost("add")]
    public async Task AddUserData([FromBody] UserData userData) => await _userData.Add(userData);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveUserData(int id) => await _userData.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateUserData([FromBody] UserData userData) => await _userData.Update(userData);
    
    [HttpGet("user/{userId}")]
    public List<UserData> GetUserDataByUserId(string userId) => _userData.GetByUserId(userId);
}