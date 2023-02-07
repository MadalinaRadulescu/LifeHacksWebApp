using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class LifeHack
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoName { get; set; } = "";
    public string Link { get; set; } = "";
    public long VoteCount { get; set; } = 0;
}