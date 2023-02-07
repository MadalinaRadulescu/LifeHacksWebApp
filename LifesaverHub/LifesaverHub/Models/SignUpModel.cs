namespace LifesaverHub.Models;

public class SignUpModel
{
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }
    
    public SignUpModel(string email, string password, string userName)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }
}