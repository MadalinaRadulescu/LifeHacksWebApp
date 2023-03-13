namespace LifesaverHub.Models.Entities;

public class LifeHack : DetailedBaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Image { get; set; } = new ();
    public string Link { get; set; } = "";
    public List<long> categoriesId { get; set; } = new();
}