using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class LifeHack
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoName { get; set; } = "";
    public string Link { get; set; } = "";
    public long VoteCount { get; set; } = 0;
    public long userId { get; set; }
    public List<long> categoriesId { get; set; } = new();
    public DateTimeKind PublishedAt { get; set;  } = DateTimeKind.Utc;
}