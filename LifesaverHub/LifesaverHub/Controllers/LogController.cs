using LifesaverHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LifesaverHub.Controllers;

[ApiController]
public class LogController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _logInManager;

    public LogController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> logInManager)
    {
        _userManager = userManager;
        _logInManager = logInManager;
    }

    [HttpPost("/signup/user")]
    public async Task<bool> SignUp([FromBody]SignUpModel model)
    {
        var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        
        return result.Succeeded;
    }
    
    [HttpPost("/login/user")]
    public async Task<bool> Login([FromBody]LoginModel model)
    {
        var result = await _logInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        return result.Succeeded;
    }
    //
    // [HttpGet("logout")]
    // public async void Logout()
    // {
    //     _userManager.LogOutAsync().Wait();
    // }
}