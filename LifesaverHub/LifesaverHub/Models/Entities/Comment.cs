using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class Comment : DetaliedBaseEntity
{
    public string Text { get; set; }
    public long LifeHackId { get; set; }
}