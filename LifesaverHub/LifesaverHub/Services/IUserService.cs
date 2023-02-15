using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifesaverHub.Models;
using LifesaverHub.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace LifesaverHub.Services;

public interface IUserService
{
    Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
    Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
}

public class UserService : IUserService
{
    private UserManager<IdentityUser> _userManager;
    private IConfiguration _configuration;

    public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
    {
        if (model == null)
        {
            throw new NullReferenceException("Register model is null.");
        }

        if (model.ConfirmPassword != model.Password)
            return new UserManagerResponse()
            {
                Message = "Confirm password doesn't match password!",
                IsSuccess = false,
            };

        var identityUser = new IdentityUser()
        {
            Email = model.Email,
            UserName = model.Email,
        };
        var result = await _userManager.CreateAsync(identityUser, model.Password);
        if (result.Succeeded)
        {
            //TODO send confirmation email
            return new UserManagerResponse()
            {
                Message = "User created successfully!",
                IsSuccess = true,
            };
        }

        return new UserManagerResponse()
        {
            Message = "User did not create",
            IsSuccess = false,
            Errors = result.Errors.Select(e => e.Description)
        };

    }
    public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return new UserManagerResponse()
            {
                Message = "There is no user with that email address.",
                IsSuccess = false,
            };
        }

        var result = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
            return new UserManagerResponse()
            {
                Message = "Invalid password!",
                IsSuccess = false,
            };

        var claims = new[]
        {
            new Claim("Email", model.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
        
        var token = new JwtSecurityToken(
            issuer: _configuration["AuthSettings:Issuer"],
            audience: _configuration["AuthSettings:audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
        
        return new UserManagerResponse()
        {
            Message = "You have logged in!",
            IsSuccess = true,
            ExpireDate = token.ValidTo,
        };

    }
}