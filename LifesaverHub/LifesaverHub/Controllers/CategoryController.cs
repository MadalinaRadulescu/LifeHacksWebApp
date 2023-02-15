using LifesaverHub.Daos;
using LifesaverHub.Daos.Implementations;
using LifesaverHub.Data;
using LifesaverHub.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;

[ApiController, Route("/category/")]
public class CategoryController : Controller
{
    private readonly ICategoryDao _category;
    public CategoryController(DatabaseContext db) => _category = new CategoryDao(db);

    [HttpGet("all")]
    public List<Category> GetCategories()
    {
        return _category.GetAll();
    }

    [HttpGet("{id}")]
    public Category GetCategory(string id) => _category.Get(id);

    [HttpPost("add")]
    public async Task AddCategory([FromBody] Category category) => await _category.Add(category);
    
    [HttpDelete("remove/{id}")]
    public async Task RemoveCategory(string id) => await _category.Remove(id);
    
    [HttpPut("update")]
    public async Task UpdateCategory([FromBody] Category category) => await _category.Update(category);
}