using LifesaverHub.Models;
using LifesaverHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
   
    // /api/auth
    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.RegisterUserAsync(model);
            if (result.IsSuccess)
                return Ok(result); // Status code: 200
            return BadRequest(result);
        }

        return BadRequest("Some properties are not valid"); //Status code: 400
    }
}