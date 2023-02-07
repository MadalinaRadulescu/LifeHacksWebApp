using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class Comment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Text { get; set; }
    public long VoteCount { get; set; } = 0;
    public long UserId { get; set; }
    public long LifeHackId { get; set; }
}