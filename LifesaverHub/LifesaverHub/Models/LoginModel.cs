namespace LifesaverHub.Models;

public class LoginModel
{
    public string Email { get; }
    public string Password { get; }
    public bool RememberMe { get; }
    
    public LoginModel(string email, string password, bool rememberMe)
    {
        Email = email;
        Password = password;
        RememberMe = rememberMe;
    }
}