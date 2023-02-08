namespace LifesaverHub.Models.Entities;

public class DetaliedBaseEntity : BaseEntity
{
    public long Points { get; set; } = 0;
    public long UserId { get; set; }
}