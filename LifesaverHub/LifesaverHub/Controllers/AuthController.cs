using LifesaverHub.Models;
using LifesaverHub.Services;
using LifesaverHub.Utils;
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
   
    // /api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm]RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.RegisterUserAsync(model);
            if (result.IsSuccess)
                return Ok(result); // Status code: 200
            // return Ok(result);
        }
        
        

        return BadRequest("Some properties are not valid"); //Status code: 400
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.LoginUserAsync(model);
            Response.Cookies.Append("jwt", result.Message, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                }
            );
            
            // if (result.IsSuccess)
            //     return Ok(result); // Status code: 200
            // return Ok(result);
            return Ok(result);
        }
        
        return Ok(new UserManagerResponse()
        {
            Message = "Email and password required. Password has to be minimum 5 characters and maximum 50!",
            IsSuccess = false,
        });

        // return BadRequest("Some properties are not valid"); //Status code: 400
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok(new
        {
            message = "succes"
        });
    }
}