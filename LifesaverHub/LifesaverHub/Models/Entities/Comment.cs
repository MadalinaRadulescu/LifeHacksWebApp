namespace LifesaverHub.Models.Entities;

public class Comment : DetailedBaseEntity
{
    public string Text { get; set; }
    public long LifeHackId { get; set; }
}