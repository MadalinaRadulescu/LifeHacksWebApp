namespace LifesaverHub.Utils;

public class UserManagerResponse
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
}








