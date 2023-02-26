namespace LifesaverHub.Models.Entities;

public class DetailedBaseEntity : BaseEntity
{
    public long Points { get; set; } = 0;
    public string UserId { get; set; }
}